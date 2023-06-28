# import requests
# from mypacakge import arithmetic

# url = 'https://www.w3.org/TR/PNG/iso_8859-1.txt'
# response = requests.get(url=url)
# print(response)
# print(response.status_code)
# print(response.headers)
# print(response.text)

# print(arithmetic.add_numbers(1,2,3))
'''exercise'''
import requests
from bs4 import BeautifulSoup
import re
import statistics
from collections import Counter


# romeo_and_juliet = 'http://www.gutenberg.org/files/1112/1112.txt'
# response = requests.get(romeo_and_juliet)
# regex_word = r'\w+'
# txt_words = re.findall(regex_word,response.text)
# txt_counter = Counter(txt_words)
# print(txt_counter.most_common(10))

# Make the API call to retrieve the cat breeds data
# cats_api = 'https://api.thecatapi.com/v1/breeds'
# response = requests.get(cats_api)
# breeds_data = response.json()

# # Extract weight and lifespan data from the breeds
# weights = []
# lifespans = []
# country_breed_freq = {}
# for breed in breeds_data:
#     weight_metric = breed.get('weight').get('metric')
#     lifespan_years = breed.get('life_span')
#     country = breed.get('origin')
#     breed_name = breed.get('name')

#     # Extract weight in metric units
#     weight_value = float(weight_metric.split()[0])
#     weights.append(weight_value)

#     # Extract lifespan in years
#     lifespan_value = int(lifespan_years.split()[0])
#     lifespans.append(lifespan_value)

#     # Create frequency table of country and breed
#     if country not in country_breed_freq:
#         country_breed_freq[country] = {}
#     if breed_name not in country_breed_freq[country]:
#         country_breed_freq[country][breed_name] = 0
#     country_breed_freq[country][breed_name] += 1

# print(min(weights))
# print(max(weights))
# print(statistics.mean(weights))
# print(statistics.median(weights))
# print(statistics.stdev(weights))

# for country, breed_freq in country_breed_freq.items():
#     print("Country:", country)
#     for breed, freq in breed_freq.items():
#         print("Breed:", breed, "Frequency:", freq)
#     print()

uci_url = 'https://archive.ics.uci.edu/ml/datasets.php'

# Make the request to fetch the HTML content
response = requests.get(uci_url)
html_content = response.text

soup = BeautifulSoup(html_content,'html.parser')
# Find the table containing the dataset information
table = soup.find('table', {'border': '1'})

# Extract the dataset rows from the table
dataset_rows = table.find_all('tr')

# Iterate over the dataset rows and extract the information
for row in dataset_rows:
    columns = row.find_all('td')
    if len(columns) >= 2:
        dataset_name = columns[0].text.strip()
        dataset_description = columns[1].text.strip()

        print("Dataset Name:", dataset_name)
        print("Dataset Description:", dataset_description)
        print()
