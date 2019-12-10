import urllib
from urllib import parse
import requests
import json
import csv
import math
from collections import defaultdict


API = "http://gustav1.ux.uis.no:5002"
QUERY_FILE = "data/queries.txt"
TITLE_OUTFILE = "data/baseline_title.txt"
CONTENT_OUTFILE = "data/baseline_content.txt"
ANCHOR_OUTFILE = "data/baseline_anchor.txt"
GT_FILE = "data/qrels.csv"
INDEX_NAME = "clueweb12b"
ANCHOR_INDEX_NAME = "clueweb12b_anchors"


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
    response = requests.get(url).text
    return json.loads(response)


def exists(idx_name, doc_id):
    url = "/".join([API, idx_name, doc_id, "_exists"])
    response = requests.get(url).text
    return json.loads(response)


def perform_retrieval(idx_name, field, queries_list, size, outfile):
    out = open(outfile, "w")

    csv_writer = csv.writer(out, delimiter=',')

    csv_writer.writerow(['QueryId'] + ['DocumentId'])

    for qid, query in queries_list.items():
        res = search(idx_name, query, field, size)
        for r in res.get("hits", {}).get("hits", {}):
            csv_writer.writerow([qid] + [r["_id"]])

    out.close()


def perform_retrieval_ach(idx_name, field, queries_list, size, outfile):
    out = open(outfile, "w")

    csv_writer = csv.writer(out, delimiter=',')

    csv_writer.writerow(['QueryId'] + ['DocumentId'])

    for qid, query in queries_list.items():
        res = search(idx_name, query, field, size)
        src_cnt = 0
        for r in res.get("hits", {}).get("hits", {}):
            if src_cnt < 20:
                assert_doc_id_exist = exists(INDEX_NAME, r["_id"])
                if assert_doc_id_exist["exists"]:
                    src_cnt += 1
            else:
                break

            csv_writer.writerow([qid] + [r["_id"]])

    out.close()


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


if __name__ == '__main__':
    queries = load_queries(QUERY_FILE)

    srch_conf = dict()
    srch_conf["title"] = [INDEX_NAME, TITLE_OUTFILE]
    srch_conf["content"] = [INDEX_NAME, CONTENT_OUTFILE]
    srch_conf["anchors"] = [ANCHOR_INDEX_NAME, ANCHOR_OUTFILE]

    for field, src_cfg_lst in srch_conf.items():
        if "anchors" not in field:
            perform_retrieval(src_cfg_lst[0], field, queries, 20, src_cfg_lst[1])
        else:
            perform_retrieval(src_cfg_lst[0], field, queries, 600, src_cfg_lst[1])

    qrels = cache_gt_data(GT_FILE)

    rankings = cache_srch_res(TITLE_OUTFILE)
    print("")
    print("Evaluation of `TITLE´ search results with ground truth relevance judgements")
    compute_ndcg(rankings, qrels)

    rankings = cache_srch_res(CONTENT_OUTFILE)
    print("")
    print("Evaluation of `CONTENT´ search results with ground truth relevance judgements")
    compute_ndcg(rankings, qrels)

    rankings = cache_srch_res(ANCHOR_OUTFILE)
    print("")
    print("Evaluation of `ANCHOR´ search results with ground truth relevance judgements")
    compute_ndcg(rankings, qrels)
