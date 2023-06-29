# import pandas as pd
# import numpy as np

# nums = [1,2,3,4,5]
# s = pd.Series(nums,index=[1,2,3,4,5])
# print(s)

# dct = {'name':'you','age':23,'gender':'male','country':'India','city':'gogo'}
# s_dct = pd.Series(dct)
# print(s_dct)

# s_line = pd.Series(np.linspace(5,20,10))
# print(s_line)

# data = [
#     ['Asabeneh', 'Finland', 'Helsink'],
#     ['David', 'UK', 'London'],
#     ['John', 'Sweden', 'Stockholm']
# ]
# df = pd.DataFrame(data, columns=['Names','Country','City'])
# print(df)

# dct_data = [{'Names':'Asabeneh','Country':'Finland','City':'Helsink'},
#             {'Names':'David','Country':'UK','City':'London'},
#             {'Names':'John','Country':'Sweden','City':'Stockholm'}]
# dct_df = pd.DataFrame(dct_data)
# print(dct_df)

# csv_df = pd.read_csv('weight-height.csv')
# print(csv_df)
# print(csv_df.head())
# print(csv_df.tail())

# print(csv_df.shape)
# print(csv_df.columns)
# s_heights = csv_df['Height']
# print(s_heights)
# print(s_heights.describe())
# print(csv_df.describe())

import pandas as pd
import numpy as np
data = [
    {"Name": "Asabeneh", "Country":"Finland","City":"Helsinki"},
    {"Name": "David", "Country":"UK","City":"London"},
    {"Name": "John", "Country":"Sweden","City":"Stockholm"}]
df = pd.DataFrame(data)
print(df)
weights = [50,58,62]
df['Weight']=weights
print(df)
# df['weight']=df['weight']*0.01
# print(df)
heights = [173, 175, 169]
df['Height'] = heights

def calculate_bmi ():
    weights = df['Weight']
    heights = df['Height']
    bmi = []
    for w,h in zip(weights, heights):
        b = w/(h*h)
        bmi.append(b)
    return bmi

bmi = calculate_bmi()
df['BMI'] = bmi
print(df)
df['BMI'] = round(df['BMI'],1)

birth_year = ['1769', '1985', '1990']
current_year = pd.Series(2020, index=[0, 1,2])
df['Birth Year'] = birth_year
df['Current Year'] = current_year
print(df.Weight.dtype)
df['Birth Year'] = df['Birth Year'].astype('int')
print(df['Birth Year'].dtype)
df['Current Year'] = df['Current Year'].astype('int')

ages = df['Current Year']-df['Birth Year']
df['Ages'] = ages
print(df)

print(df[df['Ages']>120])
