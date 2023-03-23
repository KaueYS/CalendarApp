import csv

titles = set()

with open("KAUEScriptSemDuasVirgulas.csv", "r") as file:
    reader = csv.DictReader(file)
    for row in reader:
        titles.add(row["BENEFICIARIO"].upper().strip())
        # print(row["BENEFICIARIO"])
for title in sorted(titles):
    print(title)
