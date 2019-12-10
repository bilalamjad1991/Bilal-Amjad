import urllib
from urllib import parse
import requests
import json
from collections import defaultdict
import csv
import numpy as np
from sklearn.ensemble import RandomForestRegressor
import math


API = "http://gustav1.ux.uis.no:5002"

QUERY_FILE = "data/queries.txt"
QRELS_FILE = "data/qrels.csv"
FEATURES_FILE = "data/features_test.txt"
QUERY2_FILE = "data/queries2.txt"
FEATURES2_FILE = "data/features2.txt"
OUTPUT_FILE = "data/ltr2.txt"

INDEX_NAME = "clueweb12b"
ANCHOR_INDEX_NAME = "clueweb12b_anchors"

FIELDS = ["title", "content", "anchors"]
LAMBDA = 0.1

NUM_DOCS = 200
NUM_FEAT = 3
TOP_DOCS = 20

LM_FILE_CONTENT = "data/lm_jm_content.runfile.txt"
LM_FILE_TITLE = "data/lm_jm_title.runfile.txt"
LM_FILE_ANCHORS = "data/lm_jm_anchors.runfile.txt"


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
    """
    param text: string to analyze.
    """
    query_terms = []

    url = "/".join([API, idx_name, "_analyze"]) + "?" + urllib.parse.urlencode({"text": text})
    response = requests.get(url).text
    tokens = json.loads(response).get("tokens", [])
    for t in sorted(tokens, key=lambda x: x["position"]):
        query_terms.append(t["token"])

    return query_terms


def analyze_query(idx_name, query):
    url = "/".join([API, idx_name, "_analyze"]) + "?" \
          + urllib.parse.urlencode({"text": query})
    response = requests.get(url).text
    r = json.loads(response)
    return [t["token"] for t in r["tokens"]]


def index(field):
    return ANCHOR_INDEX_NAME if field == "anchors" else INDEX_NAME


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


def cache_features(path):
    X, y, qids, doc_ids = [], [], [], []
    with open(path, "r") as f:
        for line in f:
            items = line.strip().split()
            label = int(float(items[0]))
            qid = items[1]
            doc_id = items[2]
            features = np.array([float(i.split(":")[1]) for i in items[3:]])
            X.append(features)
            y.append(label)
            qids.append(qid)
            doc_ids.append(doc_id)

    return X, y, qids, doc_ids


def exists(idx_name, doc_id):
    url = "/".join([API, idx_name, doc_id, "_exists"])
    response = requests.get(url).text
    return json.loads(response)


def min_max_norm(feats, fid):
    min_x = 10000  # sufficiently large number
    max_x = -10000  # sufficiently small number

    for docid, feat in feats.items():
        if fid in feats[docid].keys():
            x = feats[docid][fid]
            if x < min_x:
                min_x = x
            if x > max_x:
                max_x = x

    for docid, feat in feats.items():
        if fid in feats[docid].keys():
            x = feats[docid][fid]
            if max_x - min_x > 0:
                feats[docid][fid] = (x - min_x) / (max_x - min_x)
            else:
                feats[docid][fid] = 0
    return feats


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


def get_lm_score(query,field,res,size):
    index_name = index(field)
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
    return scores


def get_features(qid, query):
    # global NUM_FEAT
    feats = {}
    print("Getting features for query #{} '{}'".format(qid, query))

    # Analyze query (will be needed for some features)
    qterms = analyze_query("clueweb12b", query)

    # Feature 1: BM25 content score
    res1 = search("clueweb12b", query, "content", size=NUM_DOCS)
    # Initializing feature vector with values for Feature 1
    print("\tElasticsearch content field ...")
    for doc in res1.get('hits', {}).get("hits", {}):
        doc_id = doc.get("_id")
        feats[doc_id] = {1: doc.get("_score")}

    # Feature 2: BM25 title score
    print("\tElasticsearch title field ...")
    res2 = search("clueweb12b", query, "title", size=NUM_DOCS)
    for doc in res2.get('hits', {}).get("hits", {}):
        doc_id = doc.get("_id")
        if doc_id in feats:
            feats[doc_id][2] = doc.get("_score")

    # Feature 3: BM25 anchors score
    # NOTE: we retrieve more candidate documents here
    print("\tElasticsearch anchors field ...")
    res3 = search("clueweb12b_anchors", query, "anchors", size=NUM_DOCS * 10)
    for doc in res3.get('hits', {}).get("hits", {}):
        doc_id = doc.get("_id")
        if doc_id in feats:
            feats[doc_id][3] = doc.get("_score")

    print("Computing query features for query #", qid)
    len_query = len(query.split())
    total_matching_documents_count_content = res1.get('hits', {}).get("total")
    total_matching_documents_count_title = res2.get('hits', {}).get("total")
    total_matching_documents_count_anchor = res3.get('hits', {}).get("total")
    print("len of query = ", len_query)
    print("total_matching_documents_count_content = ", total_matching_documents_count_content)
    print("total_matching_documents_count_title = ", total_matching_documents_count_title)
    print("total_matching_documents_count_anchor = ", total_matching_documents_count_anchor)
    for doc_id, feat in feats.items():
        feats[doc_id][6] = len_query
        feats[doc_id][7] = total_matching_documents_count_content
        feats[doc_id][8] = total_matching_documents_count_title
        feats[doc_id][9] = total_matching_documents_count_anchor

    print("Computing document features for query #", qid)
    for doc_id, feat in feats.items():
        tv = term_vectors("clueweb12b", doc_id, term_statistics=False)

        len_content = sum([s["term_freq"] for t, s in tv.get("content", {}).get("terms", {}).items()])
        feats[doc_id][4] = len_content

        len_title = sum([s["term_freq"] for t, s in tv.get("title", {}).get("terms", {}).items()])
        feats[doc_id][5] = len_title

    print("Normalizing features for query #", qid)
    for fid in range(1, 3 + 1):  # normalize first 6 features
        normalized_feats = min_max_norm(feats, fid)

    print("")

    return feats


def get_training_data(queries, qrels, output_file):
    with open(output_file, "w") as fout:
        for qid, query in sorted(queries.items()):
            # get feature vectors
            feats = get_features(qid, query)
            # assign target labels and write to file
            for doc_id, feat in feats.items():
                if doc_id in qrels[qid]: # we only consider docs where we have the target label
                    rel = qrels[qid][doc_id]
                    # we use -1 as value for the missing features
                    for fid in range(1, NUM_FEAT + 1):
                        if fid not in feat:
                            feat[fid] = -1
                    # write to file
                    feat_str = ['{}:{}'.format(k,v) for k,v in sorted(feat.items())]
                    fout.write(" ".join([str(rel), qid, doc_id] + feat_str) + "\n")


if __name__ == '__main__':
    queries = load_queries(QUERY_FILE)
    qrels = cache_gt_data(QRELS_FILE)

    get_training_data(queries, qrels, FEATURES_FILE)

    train_X, train_y, qids, doc_ids = cache_features(FEATURES_FILE)
    qids_unique = list(set(qids))
    print("#queries: ", len(qids_unique))
    print("#query-doc pairs: ", len(train_y))
    print(train_X)
    print(train_y)

    clf = RandomForestRegressor(max_depth=3, random_state=0)
    ltr = PointWiseLTRModel(clf)
    ltr._train(train_X, train_y)

    queries2 = load_queries(QUERY2_FILE)

    output_format = "kaggle"

    with open(OUTPUT_FILE, "w") as fout:
        for qid, query in sorted(queries2.items()):
            # Get feature vectors
            feats = get_features(qid, query)

            # Convert into the format required by the `PointWiseLTRModel` class
            # and deal with missing feature values
            doc_fts = []
            doc_ids = []

            for doc_id, feat in feats.items():
                for fid in range(1, NUM_FEAT + 1):
                    if fid not in feat:
                        feat[fid] = -1
                doc_fts.append(np.array([float(val) for fid, val in sorted(feat.items())]))
                doc_ids.append(doc_id)

            # Get ranking
            r = ltr.rank(doc_fts, doc_ids)
            # Write the results to file
            rank = 1
            for doc_id, score in r:
                if rank <= TOP_DOCS:
                    if output_format == "trec":
                        fout.write(("\t".join(["{}"] * 6) + "\n").format(qid, "Q0", doc_id, str(rank),
                                                                         str(score), "A3_3_Baseline"))
                    else:
                        fout.write(qid + "," + doc_id + "\n")
                rank += 1
