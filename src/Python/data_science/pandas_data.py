import pandas as pd

# data_csv = pd.read_csv("./data/household.csv")
# print(data_csv.head())
# print(data_csv.describe())
# print(data_csv.info())
# print(data_csv.tail(10))

# print(data_csv.dropna())
# print(data_csv.fillna(0))

# data_csv.drop_duplicates()
# data_excel = pd.read_excel("./data/gdmuscore.xlsx",sheet_name="Sheet1")
# print(data_excel.describe())

# data_table = pd.DataFrame({"Name":["John","Jane","Doe","Han"],"Age":[23,24,25,30],"Salary":[1000,2000,3000,4000],"Department":["HR","IT","Finance","IT"]})

# print(data_table.sort_values(by="Salary",ascending=False))
# print(data_table.groupby("Department").count())
# print(data_table.groupby("Department").sum())
# print(data_table.groupby("Department")["Salary"].sum())

# print(data_table[data_table["Salary"] > 3000])

# print(data_table[(data_table["Salary"] > 3000) & (data_table["Department"]=="IT") ] )

# data left join/inner join/right join
data1 = pd.DataFrame({"key1":["A","B","C","D"],"value1":[1,2,3,4]})

data2=pd.DataFrame({"key1":["A","B","C","E"],"value2":[5,6,7,8]})

merge_innerjoin = pd.merge(data1,data2,on="key1",how="inner")
print(merge_innerjoin)

left_join = pd.merge(data1,data2,on="key1",how="left")
print(left_join)

right_join = pd.merge(data1,data2,on="key1",how="right")
print(right_join)

# drop right_join nan values
right_join = right_join.dropna()
print(right_join)

merged_left = pd.merge(data1,data2,on="key1",how="left",indicator=True)
print(merged_left)
merged_left_anti_join = merged_left[merged_left["_merge"]=="left_only"]
print(merged_left_anti_join)

print(merged_left_anti_join.drop("_merge",axis=1))
