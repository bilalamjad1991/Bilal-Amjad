RANKING_FILE = "data/mlm_optimized.txt"  # file with the document rankings
QRELS_FILE = "data/qrels2.csv"  # file with the relevance judgments (ground truth)


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
    print("  QID  P@10   (M)AP  (M)RR")
    sum_p10, sum_ap, sum_rr, num_query = 0, 0, 0, 0
    for qid in sorted(gt.keys()):
        res = eval_query(output.get(qid, []), gt.get(qid, []))
        print("%5s %6.3f %6.3f %6.3f" % (qid, res["P10"], res["AP"], res["RR"]))

        sum_p10 += res["P10"]
        sum_ap += res["AP"]
        sum_rr += res["RR"]

    # TODO compute averages over the entire query set
    num_query = len(gt)
    sum_p10 = sum_p10/num_query
    sum_ap = sum_ap/num_query
    sum_rr = sum_rr/num_query

    # print averages
    print("%5s %6.3f %6.3f %6.3f" % ("ALL", sum_p10, sum_ap, sum_rr))


if __name__ == '__main__':
    eval(QRELS_FILE, RANKING_FILE)