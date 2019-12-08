from elasticsearch import Elasticsearch
from time import sleep


INDEX_NAME = "aquaint"
DOC_TYPE = "doc"
FIELD = "content"


SIM = {
    "similarity": {
        "default": {
            "type": "BM25",
            "b": 0.75,
            "k1": 1.2
        }
    }
}


def printres(res):
    for r in res:
        print("%s %6.2f" % (r["_id"], r["_score"]))


if __name__ == '__main__':
    es = Elasticsearch()

    query = "tropical storms"

    res = es.search(index=INDEX_NAME, q=query, df=FIELD, _source=False, size=10).get("hits", {}).get("hits", {})

    printres(res)

    es.indices.close(index=INDEX_NAME)
    es.indices.put_settings(index=INDEX_NAME, body=SIM)
    es.indices.open(index=INDEX_NAME)

    sleep(0.1)
    print("\n")

    res = es.search(index=INDEX_NAME, q=query, df=FIELD, _source=False, size=10).get("hits", {}).get("hits", {})

    printres(res)

    res = es.indices.get_settings(index=INDEX_NAME)

    print("{}".format(res))

