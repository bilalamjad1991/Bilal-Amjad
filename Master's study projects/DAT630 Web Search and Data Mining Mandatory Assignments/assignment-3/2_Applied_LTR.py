import urllib
from urllib import parse
import requests
import json
import math
from collections import defaultdict
import csv
from sklearn.ensemble import RandomForestRegressor
import numpy as np


API = "http://gustav1.ux.uis.no:5002"
QUERY_FILE = "data/queries.txt"
GT_FILE = "data/qrels.csv"
DOC_TYPE = "doc"
INDEX_NAME = "clueweb12b"
ANCHOR_INDEX_NAME = "clueweb12b_anchors"

FIELDS = ["title", "content", "anchors"]
LAMBDA = 0.1

QD_FEATURES = "data/qd_features.txt"
QD_Q_FEATURES = "data/qd_q_features.txt"
QD_D_FEATURES = "data/qd_d_features.txt"
QD_Q_D_FEATURES = "data/qd_d_q_features.txt"

QD_OUTPUT = "data/qd.txt"
QD_D_OUTPUT = "data/qd_d.txt"
QD_Q_OUTPUT = "data/qd_q.txt"
QD_Q_D_OUTPUT = "data/qd_d_q.txt"

features = {}


# Each feature here is a Retrieval score obtained using a different ES configuration
ES_CONFIG = {
    1: {
        "field": "title",
        "similarity": {
            "default": {
                "type": "BM25",
                "b": 0.75,
                "k1": 1.2
            }
        }
    },
    2: {
        "field": "content",
        "similarity": {
            "default": {
                "type": "BM25",
                "b": 0.75,
                "k1": 1.2
            }
        }
    },
    3: {
        "field": "anchors",
        "similarity": {
            "default": {
                "type": "BM25",
                "b": 0.75,
                "k1": 1.2
            }
        }
    },
    4: {
        "field": "title",
        "similarity": {
            "default": {
                "type": "LMJelinekMercer",
                "lambda": 0.1
            }
        }
    },
    5: {
        "field": "content",
        "similarity": {
            "default": {
                "type": "LMJelinekMercer",
                "lambda": 0.1
            }
        }
    },
    6: {
        "field": "anchors",
        "similarity": {
            "default": {
                "type": "LMJelinekMercer",
                "lambda": 0.1
            }
        }
    }
}


class CollectionLM(object):
    def __init__(self, qterms):
        self._probs = {}
        # computing P(t|C_i) for each field and for each query term
        for field in FIELDS:
            self._probs[field] = {}
            for t in qterms:
                self._probs[field][t] = self.__get_prob(field, t)

    def __get_prob(self, field, term):
        # use a boolean query to find a document that contains the term
        index_name = index(field)
        hits = search(index_name, term, field, size=1).get("hits", {}).get("hits", {})
        doc_id = hits[0]["_id"] if len(hits) > 0 else None
        if doc_id is not None:
            # ask for global term statistics when requesting the term vector of that doc (`term_statistics=True`)

            tv = term_vectors(index_name, doc_id, term_statistics=True)["term_vectors"][field]
            ttf = tv["terms"].get(term, {}).get("ttf", 0)  # total term count in the collection (in that field)
            sum_ttf = tv["field_statistics"]["sum_ttf"]
            return ttf / sum_ttf

        return 0  # this only happens if none of the documents contain that term

    def prob(self, field, term):
        return self._probs.get(field, {}).get(term, 0)


class PointWiseLTRModel(object):
    def __init__(self, regressor):
        """
        :param classifier: an instance of scikit-learn regressor
        """
        self.regressor = regressor

    def _train(self, X, y):
        """
        Trains and LTR model.
        :param X: features of training instances
        :param y: relevance assessments of training instances
        :return:
        """
        assert self.regressor is not None
        self.model = self.regressor.fit(X, y)

    def rank(self, ft, doc_ids):
        """
        Predicts relevance labels and rank documents for a given query
        :param ft: a list of features for query-doc pairs
        :param ft: a list of document ids
        :return:
        """
        assert self.model is not None
        rel_labels = self.model.predict(ft)
        sort_indices = np.argsort(rel_labels)[::-1]

        results = []
        for i in sort_indices:
            results.append((doc_ids[i], rel_labels[i]))
        return results


def load_queries(query_file):
    queries = {}
    with open(query_file, "r") as fin:
        for line in fin.readlines():
            qid, query = line.strip().split(" ", 1)
            queries[qid] = query
    return queries


def search(idx_name, query, field, size=10):
    url = "/".join([API, idx_name, "_search"]) + "?" \
          + urllib.parse.urlencode({"q": query, "df": field, "size": size})
    while True:
        try:
            response = requests.get(url, timeout=10).text
        except Exception as e:
            print(e)
            continue
        break

    return json.loads(response)


def term_vectors(idx_name, doc_id, term_statistics=False):
    url = "/".join([API, idx_name, doc_id, "_termvectors"]) + "?" \
          + urllib.parse.urlencode({"term_statistics": str(term_statistics).lower()})
    response = requests.get(url).text

    return json.loads(response)


def analyze(idx_name, text):
    query_terms = []

    url = "/".join([API, idx_name, "_analyze"]) + "?" + urllib.parse.urlencode({"text": text})
    response = requests.get(url).text
    tokens = json.loads(response).get("tokens", [])
    for t in sorted(tokens, key=lambda x: x["position"]):
        query_terms.append(t["token"])

    return query_terms


def index(field):
    return ANCHOR_INDEX_NAME if field == "anchors" else INDEX_NAME


def score_lm(clm, qterms, doc_id, field):
    score = 0  # log P(q|d)

    # Getting term frequency statistics for the given document field from Elasticsearch
    # Note that global term statistics are not needed
    index_name = index(field)
    tv = term_vectors(index_name, doc_id, term_statistics=True).get("term_vectors", {})

    # compute field length $|d|$
    len_d = 0  # document field length initialization
    if field in tv:  # that document field may be NOT empty
        len_d = sum([s["term_freq"] for t, s in tv[field]["terms"].items()])

    # scoring the query
    for t in qterms:
        Pt_theta_d = 0  # P(t|\theta_d)
        if field in tv:
            Pt_d = tv[field]["terms"].get(t, {}).get("term_freq", 0) / len_d  # $P(t|d)$
        else:  # that document field is empty
            Pt_d = 0
        Pt_C = clm.prob(field, t)  # $P(t|C)$
        Pt_theta_d = (1 - LAMBDA) * Pt_d + LAMBDA * Pt_C  # $P(t|\theta_{d})$ with J-M smoothing
        score += math.log(
            Pt_theta_d) if Pt_theta_d > 0 else 0

    return score


def score_queries(field):
    index_name = index(field)
    max_rank = 20

    output_file = "data/lm_jm_{}.runfile.txt".format(field)
    print("Outputting to {}".format(output_file))
    with open(output_file, "w") as fout:
        fout.write("QueryId,DocumentId\n")  # header
        for qid, query in sorted(queries.items()):
            # get top 200 docs using BM25
            print("\tGet baseline ranking for [%s] '%s'" % (qid, query))
            res = search(index_name, query, field, size=20).get('hits', {})

            # re-score docs using MLM
            print("\tRe-scoring documents using LM")
            # get analyzed query
            qterms = analyze(index_name, query)
            # get collection LM
            # (this needs to be instantiated only once per query and can be used for scoring all documents)
            clm = CollectionLM(qterms)
            scores = {}
            for doc in res.get("hits", {}):
                doc_id = doc.get("_id")
                scores[doc_id] = score_lm(clm, qterms, doc_id, field)
            print(scores)

            # write top 20 results to file
            for doc_id, score in sorted(scores.items(), key=lambda x: x[1], reverse=True)[:max_rank]:
                print(score)
                fout.write(qid + "," + doc_id + "\n")


def compute_lm_score(query, field, res):
    index_name = index(field)
    print("\tRe-scoring documents using LM")

    qterms = analyze(index_name, query)

    clm = CollectionLM(qterms)
    scores = {}
    for doc in res.get("hits", {}):
        doc_id = doc.get("_id")
        scores[doc_id] = score_lm(clm, qterms, doc_id, field)
    return scores


def compute_qd_features():
    for fid in range(1, len(ES_CONFIG) + 1):
        print("Computing values for feature #", fid)
        size = 20
        index_name = index(ES_CONFIG[fid]["field"])
        if ES_CONFIG[fid]["field"] == "anchors":
            size = size * 10

        print("size = ", size)
        for qid, query in queries.items():
            if qid not in features:
                features[qid] = {}

            res = search(index_name, query, ES_CONFIG[fid]["field"], size)

            if fid <= 3:
                for r in res.get("hits", {}).get("hits", {}):
                    docid = r["_id"]
                    if docid not in features[qid]:
                        features[qid][docid] = {}
                    features[qid][docid][fid] = r["_score"]
            else:
                lm_res = compute_lm_score(query, ES_CONFIG[fid]["field"], res.get("hits", {}))
                for docid, score in sorted(lm_res.items(), key=lambda x: x[1], reverse=True)[:size]:
                    if docid not in features[qid]:
                        features[qid][docid] = {}
                    features[qid][docid][fid] = score


def compute_query_features():
    for qid, query in queries.items():
        print("Computing query features for query #", qid)
        len_query = len(query.split())
        res = search(INDEX_NAME, query, "content", 1)
        total_matching_documents_count_content = res.get('hits', {}).get("total")
        for doc_id in features[qid].keys():
            features[qid][doc_id][len(ES_CONFIG) + 1 +3] = len_query
            features[qid][doc_id][len(ES_CONFIG) + 1 +4] = total_matching_documents_count_content


def compute_doc_features():
    for qid, query in queries.items():
        print("Computing document features for query #", qid)
        for doc_id in features[qid].keys():
            tv = term_vectors("clueweb12b", doc_id, term_statistics=False)

            # content field length
            len_content = sum([s["term_freq"] for t, s in tv.get("content", {}).get("terms", {}).items()])
            features[qid][doc_id][len(ES_CONFIG) + 1 + 1] = len_content

            # title field length
            len_title = sum([s["term_freq"] for t, s in tv.get("title", {}).get("terms", {}).items()])
            features[qid][doc_id][len(ES_CONFIG) + 1 + 2] = len_title


def save_features(file_name, feature_type, qrels):
    with open(file_name, "w") as fout:
        for qid, query in queries.items():
            for docid, ft in features[qid].items():
                for fid in range(1, len(ES_CONFIG) + 1 + 4):
                    if fid not in ft:
                        ft[fid] = -1

                # Relevance label is determined based on the ground truth (qrels) file
                label = 1 if docid in qrels.get(qid, []) else 0
                feat_str = ""
                if feature_type == "qd":
                    feat_str = ['{}:{}'.format(k, v) for k, v in ft.items() if k <= 6]
                elif feature_type == "qd_d":
                    feat_str = ['{}:{}'.format(k, v) for k, v in ft.items() if k <= 8]
                elif feature_type == "qd_q":
                    feat_str = ['{}:{}'.format(k, v) for k, v in ft.items() if k != 7 and k != 8]
                elif feature_type == "qd_q_d":
                    feat_str = ['{}:{}'.format(k, v) for k, v in ft.items()]

                fout.write(" ".join([str(label), qid, docid] + feat_str) + "\n")


def cache_features(path):
    X, y, qids, doc_ids = [], [], [], []
    with open(path, "r") as f:
        for line in f:
            items = line.strip().split()
            label = int(items[0])
            qid = items[1]
            doc_id = items[2]
            features = np.array([float(i.split(":")[1]) for i in items[3:]])
            X.append(features)
            y.append(label)
            qids.append(qid)
            doc_ids.append(doc_id)

    return X, y, qids, doc_ids


def perform_five_cross_validation(feature_file, output_file):
    X, y, qids, doc_ids = cache_features(feature_file)
    qids_unique= list(set(qids))

    print("#queries: ", len(qids_unique))
    print("#query-doc pairs: ", len(y))
    FOLDS = 5

    fout = open(output_file, "w")
    # write header
    fout.write("QueryId,DocumentId\n")

    for f in range(FOLDS):
        train_qids, test_qids = [], []  # holds the IDs of train and test queries

        for i in range(len(qids_unique)):
            qid = qids_unique[i]
            if i % FOLDS == f:  # test query
                test_qids.append(qid)
            else:  # train query
                train_qids.append(qid)

        train_X, train_y = [], []  # training feature values and target labels
        test_X = []  # for testing we only have feature values

        for i in range(len(X)):
            if qids[i] in train_qids:
                train_X.append(X[i])
                train_y.append(y[i])
            else:
                test_X.append(X[i])

        # Create and train LTR model
        print("\tTraining model ...")
        clf = RandomForestRegressor(max_depth=3, random_state=0)
        ltr = PointWiseLTRModel(clf)
        ltr._train(train_X, train_y)

        # Apply LTR model on the remaining fold (test queries)
        print("\tApplying model ...")

        for qid in set(test_qids):
            print("\t\tRanking docs for queryID {}".format(qid))
            # Collect the features and docids for that (test) query `qid`
            test_ft, test_docids = [], []
            for i in range(len(X)):
                if qids[i] == qid:
                    test_ft.append(X[i])
                    test_docids.append(doc_ids[i])

            # Get ranking
            r = ltr.rank(test_ft, test_docids)
            # Write the results to file
            for doc, score in r:
                fout.write(qid + "," + doc + "\n")

    fout.close()


def compute_dcg(rel, p):
    dcg = rel[0]
    for i in range(1, min(p, len(rel))):
        dcg += rel[i] / math.log(i + 1, 2)  # rank position is indexed from 1..
    return dcg


def compute_ndcg(rankings, qrels):
    sum_ndcg10 = 0
    sum_ndcg20 = 0

    for qid, ranking in sorted(rankings.items()):
        if qid in qrels:
            gt = qrels[qid]
            # ("Query", qid)

            gains = []  # holds corresponding relevance levels for the ranked docs
            for doc_id in ranking:
                gain = gt.get(doc_id, 0)
                if int(gain) < 0:
                    gain = 0
                gains.append(int(gain))
            # print("\tGains:", gains)

            # relevance levels of the idealized ranking
            gain_ideal = list(map(int, sorted([v for _, v in gt.items()], reverse=True)))
            # print("\tIdeal gains:", gain_ideal)

            ndcg10 = compute_dcg(gains, 10) / compute_dcg(gain_ideal, 10)
            ndcg20 = compute_dcg(gains, 20) / compute_dcg(gain_ideal, 20)

            sum_ndcg10 += ndcg10
            sum_ndcg20 += ndcg20

            # print("\tNDCG@10:", round(ndcg10, 3), "\n\tNDCG@20:", round(ndcg20, 3))

    print("Average")
    print("\tNDCG@10:", round(sum_ndcg10 / len(rankings), 3), "\n\tNDCG@20:", round(sum_ndcg20 / len(rankings), 3))


def cache_gt_data(gt_file):
    gt = {}

    with open(gt_file, "r") as fin:
        header = fin.readline().strip()
        if header != "QueryId,DocumentId,Relevance":
            raise Exception("Incorrect file format!")
        for line in fin.readlines():
            qid, docid, level = line.strip().split(",")
            if qid not in gt:
                gt[qid] = {}
            gt[qid][docid] = float(level)

    return gt


def cache_srch_res(outfile):
    rankings = defaultdict(list)

    with open(outfile, "r") as csv_file:
        csv_reader = csv.reader(csv_file, delimiter=',')
        next(csv_reader, None)
        for row in csv_reader:
            if row[0] not in rankings:
                rankings[row[0]] = []
            rankings[row[0]].append(row[1])

    return rankings


def compute_features():
    compute_qd_features()
    compute_query_features()
    compute_doc_features()


def serialize_features(qrels):
    save_features(QD_FEATURES, "qd", qrels)
    save_features(QD_Q_FEATURES, "qd_q", qrels)
    save_features(QD_D_FEATURES, "qd_d", qrels)
    save_features(QD_Q_D_FEATURES, "qd_q_d", qrels)


def perform_validation():
    perform_five_cross_validation(QD_FEATURES, QD_OUTPUT)
    perform_five_cross_validation(QD_Q_FEATURES, QD_Q_OUTPUT)
    perform_five_cross_validation(QD_D_FEATURES, QD_D_OUTPUT)
    perform_five_cross_validation(QD_Q_D_FEATURES, QD_Q_D_OUTPUT)


def evaluate_features(qrels):
    rankings = cache_srch_res(QD_OUTPUT)
    print("")
    print("Evaluation of `Query Document´ features with ground truth relevance judgements")
    compute_ndcg(rankings, qrels)

    rankings = cache_srch_res(QD_Q_OUTPUT)
    print("")
    print("Evaluation of `Query Document + Query´ features with ground truth relevance judgements")
    compute_ndcg(rankings, qrels)

    rankings = cache_srch_res(QD_D_OUTPUT)
    print("")
    print("Evaluation of `Query Document + Document´ features with ground truth relevance judgements")
    compute_ndcg(rankings, qrels)

    rankings = cache_srch_res(QD_Q_D_OUTPUT)
    print("")
    print("Evaluation of `Query Document + Query + Document´ features with ground truth relevance judgements")
    compute_ndcg(rankings, qrels)


if __name__ == '__main__':
    queries = load_queries(QUERY_FILE)
    qrels = cache_gt_data(GT_FILE)

    compute_features()
    serialize_features(qrels)
    perform_validation()

    evaluate_features(qrels)

