from elasticsearch import Elasticsearch
from time import sleep


INDEX_NAME = "aquaint"
DOC_TYPE = "doc"

QUERY_FILE = "data/queries.txt"  # make sure the query file exists on this location

OUTPUT_FILE = "data/baseline_optimized.txt"  # output the ranking

SIM = {
    "similarity": {
        "default": {
            "type": "BM25",
            "b": 0.10,
            "k1": 1.10
        }
    }
}


def load_queries(query_file):
    queries = {}
    with open(query_file, "r") as fin:
        for line in fin.readlines():
            qid, query = line.strip().split(" ", 1)
            queries[qid] = query
    return queries


if __name__ == '__main__':
    es = Elasticsearch()

    es.indices.close(index=INDEX_NAME)
    es.indices.put_settings(index=INDEX_NAME, body=SIM)
    es.indices.open(index=INDEX_NAME)

    sleep(0.1)

    queries = load_queries(QUERY_FILE)

    with open(OUTPUT_FILE, "w") as fout:
        fout.write("QueryId,DocumentId\n")
        for q_id, query in queries.items():
            # TODO generate ranking
            res = es.search(index=INDEX_NAME, q=query, df="content", _source=False, size=100).get('hits', {})

            # TODO write results to file
            for doc in res.get("hits", {}):
                doc_id = doc.get("_id")
                fout.write(q_id + "," + doc_id + "\n")
