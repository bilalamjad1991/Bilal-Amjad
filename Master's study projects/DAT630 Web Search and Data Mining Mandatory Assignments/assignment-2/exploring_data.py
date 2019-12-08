import matplotlib.pyplot as plt
import csv
import numpy as np


ATTRS_ALL = ["LOCATION", "W", "FINAL_MARGIN", "SHOT_NUMBER", "PERIOD", "GAME_CLOCK", "SHOT_CLOCK", "DRIBBLES", "TOUCH_TIME", "SHOT_DIST", "PTS_TYPE", "CLOSE_DEF_DIST", "Target"]
ATTRS_CATEGORICAL = ["LOCATION", "W", "PERIOD", "PTS_TYPE", "Target"]

def load_basketball_data(filename):
    records = []
    with open(filename, 'rt') as csvfile:
        csvreader = csv.reader(csvfile, delimiter=',')
        for row in csvreader:
            if len(row) == len(ATTRS_ALL):  # 13 attributes, including the target
                d = {}
                for i, attr in enumerate(ATTRS_ALL):
                    d[attr] = row[i] if attr in ATTRS_CATEGORICAL else float(row[i])
                records.append(d)
    return records

basketball_data = load_basketball_data("data/basketball.train.csv")

arr = np.array([
    [x['FINAL_MARGIN'] for x in basketball_data],
    [x['SHOT_NUMBER'] for x in basketball_data],
    [x['DRIBBLES'] for x in basketball_data],
], float)


def attr_mean(values):
    return np.mean(values)


def attr_median(values):
    return np.median(values)


def attr_range(values):
    return np.ptp(values)


def attr_var(values):
    return np.var(values, ddof=1)


def aad(values):
    values_mean = attr_mean(values)
    return sum([abs(x - values_mean) for x in values]) / (len(values)) if len(values) > 1 else 0


def mad(values):
    values_mean = attr_mean(values)
    return attr_median([abs(x - values_mean) for x in values]) if len(values) > 1 else 0


def iqr(values):
    return np.percentile(values, 75) - np.percentile(values, 25)


print("Mean of ATTR ->     [FINAL_MARGIN]: [{}]".format(attr_mean(arr[0])))
print("Mean of ATTR ->      [SHOT_NUMBER]: [{}]".format(attr_mean(arr[1])))
print("Mean of ATTR ->         [DRIBBLES]: [{}]".format(attr_mean(arr[2])))
print("")
print("Median of ATTR ->   [FINAL_MARGIN]: [{}]".format(attr_median(arr[0])))
print("Median of ATTR ->    [SHOT_NUMBER]: [{}]".format(attr_median(arr[1])))
print("Median of ATTR ->       [DRIBBLES]: [{}]".format(attr_median(arr[2])))
print("")
print("Range of ATTR ->    [FINAL_MARGIN]: [{}]".format(attr_range(arr[0])))
print("Range of ATTR ->     [SHOT_NUMBER]: [{}]".format(attr_range(arr[1])))
print("Range of ATTR ->        [DRIBBLES]: [{}]".format(attr_range(arr[2])))
print("")
print("Variance of ATTR -> [FINAL_MARGIN]: [{}]".format(attr_var(arr[0])))
print("Variance of ATTR ->  [SHOT_NUMBER]: [{}]".format(attr_var(arr[1])))
print("Variance of ATTR ->     [DRIBBLES]: [{}]".format(attr_var(arr[2])))
print("")
print("AAD of ATTR ->      [FINAL_MARGIN]: [{}]".format(aad(arr[0])))
print("AAD of ATTR ->       [SHOT_NUMBER]: [{}]".format(aad(arr[1])))
print("AAD of ATTR ->          [DRIBBLES]: [{}]".format(aad(arr[2])))
print("")
print("MAD of ATTR ->      [FINAL_MARGIN]: [{}]".format(mad(arr[0])))
print("MAD of ATTR ->       [SHOT_NUMBER]: [{}]".format(mad(arr[1])))
print("MAD of ATTR ->          [DRIBBLES]: [{}]".format(mad(arr[2])))
print("")
print("IQR of ATTR ->      [FINAL_MARGIN]: [{}]".format(iqr(arr[0])))
print("IQR of ATTR ->       [SHOT_NUMBER]: [{}]".format(iqr(arr[1])))
print("IQR of ATTR ->          [DRIBBLES]: [{}]".format(iqr(arr[2])))


boxplot_arr = np.array([
    [x['FINAL_MARGIN'] for x in basketball_data if x['Target'] == "made"],
    [x['FINAL_MARGIN'] for x in basketball_data if x['Target'] == "missed"],
], float)

tarr = np.transpose(boxplot_arr)

plt.clf()  # this is needed to clear the current figure (prevents multiple labels)
plt.boxplot(tarr, labels=["made", "missed"])
plt.show()

cat_attr_1 = []
loc_attr = [x['LOCATION'] for x in basketball_data]
for attr_val in list(set(loc_attr)):
    cat_attr_1.append(loc_attr.count(attr_val))

cat_attr_2 = []
w_attr = [x['W'] for x in basketball_data]
for attr_val in list(set(w_attr)):
    cat_attr_2.append(w_attr.count(attr_val))


plt.clf()  # this is needed to clear the current figure (prevents multiple labels)
plt.hist(cat_attr_1, bins=range(min(cat_attr_1), max(cat_attr_1) + 200, 200))
plt.hist(cat_attr_2, bins=range(min(cat_attr_2), max(cat_attr_2) + 200, 200))
plt.show()


cat_attr_arr = np.array([
    [x['LOCATION'] for x in basketball_data],
    [x['W'] for x in basketball_data],
    [x['PERIOD'] for x in basketball_data],
    [x['PTS_TYPE'] for x in basketball_data]
], str)

location = list(set(cat_attr_arr[0]))
w = list(set(cat_attr_arr[1]))
period = sorted(list(set(cat_attr_arr[2])))
pts_type = sorted(list(set(cat_attr_arr[3])))


def binarize(record):
    total_attr_val = len(location) + len(w) + len(period) + len(pts_type)
    record_bin = [0] * total_attr_val

    record_bin[location.index(record['LOCATION'])] = 1
    record_bin[w.index(record['W']) + len(location)] = 1
    record_bin[period.index(record['PERIOD']) + len(location) + len(w)] = 1
    record_bin[pts_type.index(record['PTS_TYPE']) + len(location) + len(w) + len(period)] = 1

    return record_bin

records_bin = []
for record in basketball_data:
    bin_vect = binarize(record)
    records_bin.append(bin_vect)
    print("['LOCATION': {}, 'W': {}, 'PERIOD': {}, 'PTS_TYPE': {} -> {}".format(record['LOCATION'], record['W'],
                                                                                record['PERIOD'], record['PTS_TYPE'],
                                                                                bin_vect))


c = []
for rec in basketball_data:
    if rec['Target'] == "made":
        c.append("blue")
    else:
        c.append("red")

plt.clf()  # this is needed to clear the current figure (prevents multiple labels)
plt.scatter(arr[0], arr[1], c=c)
plt.xlabel("FINAL_MARGIN")
plt.ylabel("SHOT_NUMBER")
plt.title("FINAL_MARGIN vs SHOT_NUMBER")
plt.show()
