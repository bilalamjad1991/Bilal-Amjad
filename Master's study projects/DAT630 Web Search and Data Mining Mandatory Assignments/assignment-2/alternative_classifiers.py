import csv
from pprint import pprint
import time
import numpy
from collections import Counter


ATTRS = ["LOCATION", "W", "FINAL_MARGIN", "SHOT_NUMBER", "PERIOD", "GAME_CLOCK", "SHOT_CLOCK", "DRIBBLES", "TOUCH_TIME",
         "SHOT_DIST", "PTS_TYPE", "CLOSE_DEF_DIST", "SHOT_RESULT"]
ATTRS_WO_CLASS = 12


def load_data(filename):
    train_x = []
    train_y = []
    test_x = []
    test_y = []
    with open(filename, 'rt') as csvfile:
        csvreader = csv.reader(csvfile, delimiter=',')
        i = 0
        for row in csvreader:
            if len(row) == ATTRS_WO_CLASS + 1:
                i += 1
                instance = [row[i] for i in range(ATTRS_WO_CLASS)]  # first ATTRS_WO_CLASS values are attributes
                label = row[ATTRS_WO_CLASS]  # (ATTRS_WO_CLASS + 1)th value is the class label
                if i % 2 == 0 and len(test_x) < 37142:  # test instance
                    test_x.append(instance)
                    test_y.append(label)
                else:  # train instance
                    train_x.append(instance)
                    train_y.append(label)

    return train_x, train_y, test_x, test_y


train_x, train_y, test_x, test_y = load_data("data/basketball.train.csv")

from sklearn.feature_extraction import DictVectorizer


def transform_num_attr_to_float(data_x):
    dicts_data_x = []

    for x in data_x:
        d = {}
        for i, attr in enumerate(ATTRS):
            if i < len(ATTRS) - 1: # we removed class from train_x elems
                val = x[i]
                # save as floats the values for the already-numeric attributes from dataset, keep the rest as the strings they are
                if i not in [0, 1, 4, 10]:  # indices for "LOCATION", "W", "PERIOD", "PTS_TYPE" attributes
                    val = float(val)
                d[attr] = val

        dicts_data_x.append(d)

    return dicts_data_x

dicts_train_x = transform_num_attr_to_float(train_x)
vectorizer_train = DictVectorizer()
vec_train_x = vectorizer_train.fit_transform(dicts_train_x).toarray()

dicts_test_x = transform_num_attr_to_float(test_x)
vectorizer_test = DictVectorizer()
vec_test_x = vectorizer_train.fit_transform(dicts_test_x).toarray()

from sklearn.tree import DecisionTreeClassifier
from sklearn.neighbors import KNeighborsClassifier
from sklearn.naive_bayes import GaussianNB
from sklearn.ensemble import RandomForestClassifier
from sklearn.svm import SVC, SVR, NuSVC, NuSVR
from sklearn.naive_bayes import BernoulliNB
from sklearn.neural_network import MLPClassifier
from sklearn.preprocessing import MinMaxScaler

def evaluate(predictions, true_labels):
    correct = 0
    incorrect = 0
    for i in range(len(predictions)):
        if predictions[i] == true_labels[i]:
            correct += 1
        else:
            incorrect += 1

    print("\tAccuracy:   ", correct / len(predictions))
    print("\tError rate: ", incorrect / len(predictions))

classifiers = {"Decision Tree": DecisionTreeClassifier(),
               "Nearest Neighbors": KNeighborsClassifier(n_neighbors=3),
               "Naive Bayes (Gaussian)": GaussianNB(),
               "Random Forests": RandomForestClassifier(n_estimators=10, max_features=2),  # number of trees in the forest, and maximum number of features in each tree
               #"Support Vector Machines": NuSVR(),
               "BernoulliNB": BernoulliNB(),
               #"MLPClassifier": MLPClassifier(solver='lbfgs', alpha=1e-5, hidden_layer_sizes=(5, 2), random_state=1)
                "MLPClassifier": MLPClassifier(hidden_layer_sizes=(30,30,30))
               }
for name, clf in classifiers.items():
    print(name)
    clf.fit(vec_train_x, train_y)
    predictions = clf.predict(vec_test_x)

    if len(numpy.where(predictions == "made")[0]) > 18550 and len(numpy.where(predictions == "made")[0]) <= 18560:
        if "MLPClassifier" in name:
            print("\tHurrah!: Predictions are near to ideal case...")
            out_file = "data/alternative_classifiers_pred.csv.MLP" + "_" + time.strftime("%Y%m%d%H%M%S")
            with open(out_file, "w") as pred_file:
                    pred_file.write("Id,Target\n")
                    for i, pred in enumerate(predictions):
                        pred_file.write(str(i+1) + "," + str(pred) + "\n")

    evaluate(predictions, test_y)

#count = Counter([x == "made" for x in test_y]) #made -> 18552

with open("data/")
