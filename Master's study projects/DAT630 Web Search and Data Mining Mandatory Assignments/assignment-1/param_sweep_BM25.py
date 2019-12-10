from elasticsearch import Elasticsearch
import time
import matplotlib.pyplot as plt

INDEX_NAME = "aquaint"
DOC_TYPE = "doc"
FIELD = "content"

QUERY_FILE = "data/queries.txt"
OUTPUT_FILE = "data/baseline_param_sweep_BM25.txt"
QRELS_FILE = "data/qrels2.csv"


def load_queries(query_file):
    queries = {}
    with open(query_file, "r") as fin:
        for line in fin.readlines():
            qid, query = line.strip().split(" ", 1)
            queries[qid] = query
    return queries


def eval_query(ranking, gt):
    p10, ap, rr, num_rel = 0, 0, 0, 0

    # TODO
    for i, doc_id in enumerate(ranking):
        if doc_id in gt:  # doc is relevant
            num_rel += 1
            pi = num_rel / (i + 1)  # P@i
            ap += pi  # AP

            if i < 10:  # P@10
                p10 += 1
            if rr == 0:  # Reciprocal rank
                rr = 1 / (i + 1)


    p10 /= 10
    ap /= len(gt)

    return {"P10": p10, "AP": ap, "RR": rr}


def eval(gt_file, output_file):
    # load data from ground truth file
    gt = {}  # holds a list of relevant documents for each queryID
    with open(gt_file, "r") as fin:
        header = fin.readline().strip()
        if header != "queryID,docIDs":
            raise Exception("Incorrect file format!")
        for line in fin.readlines():
            qid, docids = line.strip().split(",")
            gt[qid] = docids.split()

    # load data from output file
    output = {}
    with open(output_file, "r") as fin:
        header = fin.readline().strip()
        if header != "QueryId,DocumentId":
            raise Exception("Incorrect file format!")
        for line in fin.readlines():
            qid, docid = line.strip().split(",")
            if qid not in output:
                output[qid] = []
            output[qid].append(docid)

    # evaluate each query that is in the ground truth
    sum_ap, num_query = 0, 0
    for qid in sorted(gt.keys()):
        res = eval_query(output.get(qid, []), gt.get(qid, []))
        sum_ap += res["AP"]

    # TODO compute averages over the entire query set
    num_query = len(gt)
    sum_ap = sum_ap/num_query

    return sum_ap


def perform_sweep_b_k():
    map_scores = []
    x, y = [], []
    b, k = 0, 0

    for b in range(11):
        b = round(b / 10, 2)
        for k in range(10, 21):
            k = round(k / 10, 2)
            x.append(b)
            y.append(k)

            SIM = {
                "similarity": {
                    "default": {
                        "type": "BM25",
                        "b": b,
                        "k1": k
                    }
                }
            }

            # change params
            es.indices.close(index=INDEX_NAME)
            es.indices.put_settings(index=INDEX_NAME, body=SIM)
            es.indices.open(index=INDEX_NAME)
            # need to wait a bit before firing queries
            time.sleep(1)

            # run retrieval and write it to a file (so that we can easily reuse previous code)
            with open(OUTPUT_FILE, "w") as fout:
                # write header
                fout.write("QueryId,DocumentId\n")
                for qid, query in queries.items():
                    res = es.search(index=INDEX_NAME, q=query, df=FIELD, _source=False, size=100).get("hits", {})
                    for doc in res.get("hits", {}):
                        fout.write(qid + "," + doc.get("_id") + "\n")

                        # evaluate
            map_score = eval(QRELS_FILE, OUTPUT_FILE)
            map_scores.append(map_score)

            print("Running queries for b = %.2f, k = %.2f, MAP = %.3f " % (b, k, map_score))

    print("MAP = {}".format(max(map_scores)))
    del map_scores[:]

    #plt.plot(x, map_scores)
    #plt.title("BM25 performance (k1=1.2, varying b)")
    #plt.xlabel("b")
    #plt.ylabel("MAP")
    #plt.savefig("bm25_b_sweep.png")
    #plt.show()


if __name__ == '__main__':
    queries = load_queries(QUERY_FILE)

    es = Elasticsearch()

    perform_sweep_b_k()








