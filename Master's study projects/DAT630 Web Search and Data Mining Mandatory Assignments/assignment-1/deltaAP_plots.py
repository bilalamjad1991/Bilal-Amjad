import numpy
import matplotlib.pyplot as plt

RANKING_FILE_BASE = "data/baseline.txt"
QRELS_FILE = "data/qrels2.csv"
RANKING_FILE_MLM = "data/mlm_optimized.txt"


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
    ap = []
    for qid in sorted(gt.keys()):
        res = eval_query(output.get(qid, []), gt.get(qid, []))
        ap.append(res["AP"])

    # TODO compute averages over the entire query set
    return ap


def plot_default(delta_ap):
    plt.plot(delta_ap)
    plt.ylabel('deltaAP')
    plt.savefig('delta_ap_each_query.png')


def plot_hist(delta_ap):
    my_bins = [-1, -0.5, -0.25, -0.05, 0.05, 0.25, 0.5, 1]
    plt.hist(delta_ap, my_bins)
    plt.xlabel('deltaAP')
    plt.show()
    plt.savefig('distribution_queries_delta_ap.png')


if __name__ == '__main__':
    ap_bm25_def = eval(QRELS_FILE, RANKING_FILE_BASE)
    ap_mlm_opt = eval(QRELS_FILE, RANKING_FILE_MLM)
    delta_ap = numpy.subtract(ap_mlm_opt, ap_bm25_def)

    plot_default(delta_ap)
    plot_hist(delta_ap)