# import os
# import json
# import csv
# import xlrd
# import xml.etree.ElementTree as ET
# # f = open('./src/Python/files/reading_file_example.txt')
# # print(f)
# # txt = f.read().splitlines()
# # print(type(txt))
# # print(txt)
# # line_txt = f.readline()
# # print(line_txt)
# # all_line_txt = f.readlines()
# # print(all_line_txt)

# with open('./src/Python/files/reading_file_example.txt','a') as f:
#     f.writelines('\nThis text has to be appended at the end')
#     f.close()
# with open('./src/Python/files/reading_file_example.txt') as f:
#     print(f.read())
#     f.close()

# with open('./src/Python/files/reading_file_example.txt','w') as f:
#     f.write('This text will be written in a newly created file')
#     f.close()
# with open('./src/Python/files/reading_file_example.txt') as f:
#     print(f.read())
#     f.close()

# # if os.path.exists('./src/Python/files/reading_file_example.txt'):
# #     os.remove('./src/Python/files/reading_file_example.txt')
# # else:
# #     print('file not exist')
# person_dct = {
#     "name":"Asabeneh",
#     "country":"Finland",
#     "city":"Helsinki",
#     "skills":["JavaScrip", "React","Python"]
# }
# person_jsonstr1 = "{\"name\": \"Asabeneh\", \"country\": \"Finland\", \"city\": \"Helsinki\", \"skills\": [\"JavaScrip\", \"React\", \"Python\"]}"
# person_jsonstr2 = '''{
#     "name":"Asabeneh",
#     "country":"Finland",
#     "city":"Helsinki",
#     "skills":["JavaScrip", "React","Python"]
# }'''
# person_dct1 = json.loads(person_jsonstr1)
# person_dct2 = json.loads(person_jsonstr2)
# print(person_dct1)
# print(person_dct1['name'])
# person_dct_str = json.dumps(person_dct,indent=4)
# print(person_dct_str)

# with open('./src/Python/files/json_example.json','w') as f:
#     json.dump(person_dct,f,ensure_ascii=False,indent=4)
#     f.close()

# with open('./src/Python/files/csv_example.csv','r') as f:
#     csv_reader = csv.reader(f,delimiter=',')
#     line_count =0
#     for row in csv_reader:
#         print(row)
#         if (line_count == 0):
#             print(f'Columns names are: {",".join(row)}')
#             line_count+=1
#         else:
#             print(f'\t{row[0]} is a teachers. He lives in {row[1]}, {row[2]}.')
#             line_count+=1
#     print(f'Number of lines:  {line_count}')
#     f.close()

# # excel_book = xlrd.open_workbook('./src/Python/files/sample.xls')
# # print(excel_book.nsheets)
# # print(excel_book.sheet_names)
# tree = ET.parse('./src/Python/files/xml_example.xml')
# root = tree.getroot()
# print('Root tag:',root.tag)
# print('Attribute:',root.attrib)
# for child in root:
#     print('field:',child.tag)

"""exercises"""
import json
import re
from collections import Counter
with open('./src/Python/data/obama_speech.txt') as f:
    txt_lines = f.read().splitlines()
    word_count = 0
    for txt in txt_lines:
        word_count += txt.__len__()
    print(f'txt word count is: {word_count}')
    print(txt_lines.__len__())

def most_spoken_languages(filename, n):
    with open(filename, 'r',encoding='utf-8') as file:
        data = json.load(file)
        file.close()

    languages = {}
    for country in data:
        for language in country['languages']:
            if language in languages:
                languages[language] += 1
            else:
                languages[language] = 1

    sorted_languages = sorted(languages.items(), key=lambda x: x[1], reverse=True)
    return sorted_languages[:n]

print(most_spoken_languages('./src/Python/data/countries_data.json',3))

def most_populated_country(file_path,n):
    with open(file_path,'r',encoding='utf-8') as f:
        data = json.load(f)
        f.close()
    populated_countries = list(data)
    sorted_populated_countries = sorted(populated_countries,key=lambda x:x['population'],reverse=True)
    return sorted_populated_countries[:n]
print(most_populated_country('./src/Python/data/countries_data.json',3))

def extract_all_emails(file_path):
    with open(file_path,'r',encoding='utf-8') as file:
        txt = file.read()
        regex_email = r'^[\w\.-]+@[\w\.-]+\.\w+$'
        return re.findall(regex_email,txt,re.MULTILINE)
print(extract_all_emails('./src/Python/data/email_exchanges_big.txt'))

def find_most_common_word(file_path,n):
    with open(file_path,'r',encoding='utf-8') as file:
        data = file.read()
        file.close()
    regex_word = r'\w+'
    word_txt = re.findall(regex_word,data,re.I)
    word_counter = Counter(word_txt)
    return word_counter.most_common(n)
print(find_most_common_word('./src/Python/data/email_exchanges_big.txt',10))
