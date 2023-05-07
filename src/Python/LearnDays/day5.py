# empty_list = list()
# empty_list = []
# web_techs = ['HTML','CSS','JS','REACT','VUE','SSR','CSR']
# print('web_techs:',web_techs)
# # print(empty_list[0])
# print(web_techs[0])
# last_index=len(web_techs)-1
# print(web_techs[last_index])
# print(web_techs[1:3:2])
# print(web_techs[-7:-1:2])
# web_techs[0]='XAML'
# print(web_techs[0:1])

# exist_css = 'CSS' in web_techs
# print(exist_css)

# web_techs.append('HTML')
# web_techs.insert(1,'MVVM')
# print(web_techs)
# web_techs.remove('MVVM')
# web_techs.pop()
# print(web_techs)
# web_techs.pop(-1)
# print(web_techs)
# del web_techs[0]
# print(web_techs)
# # del web_techs This should give: NameError: name 'web_techs' is not defined
# del web_techs[0:3]
# print(web_techs)
# # web_techs.clear()
# copy_web_techs = web_techs.copy()
# web_techs.extend(copy_web_techs)
# print(web_techs)
# print(web_techs.count('VUE'))
# print(web_techs.index('VUE'))
# print(web_techs.reverse())
# web_techs.sort()
# print(web_techs)
# web_techs.sort(reverse=True)
# print(web_techs)
# sorted(web_techs,reverse=True)
# print(web_techs)

"""exercise"""

# calculate
# ages = [19, 22, 19, 24, 20, 25, 26, 24, 25, 24]
# print(ages)
# ages.sort()
# print('min value of ages is {}'.format(ages[0]))
# ages.sort(reverse=True)
# print('max value of ages is {}'.format(ages[0]))
# # ages.append(ages[0])
# # ages.append(ages[-1])
# print(ages)
# age_middle = int(len(ages)/2)
# moddule_len = len(ages)%2
# if moddule_len==0:
#     print('has two middle value {},{}'.format(ages[age_middle-1],ages[age_middle]))
# else:
#     print('has one middle value {}'.format(ages[age_middle]))

# avg_age = sum(ages)/len(ages)
# print('avg age is {}'.format(avg_age))
# min_minus_avg_age = ages[-1]-avg_age
# print(abs(min_minus_avg_age))
# max_minus_ave_age = ages[0]-avg_age
# print(abs(min_minus_avg_age)>max_minus_ave_age)

# country
countries = [
  'Afghanistan',
  'Albania',
  'Algeria',
  'Andorra',
  'Angola',
  'Antigua and Barbuda',
  'Argentina',
  'Armenia',
  'Australia',
  'Austria',
  'Azerbaijan',
  'Bahamas',
  'Bahrain',
  'Bangladesh',
  'Barbados',
  'Belarus',
  'Belgium',
  'Belize',
  'Benin',
  'Bhutan',
  'Bolivia',
  'Bosnia and Herzegovina',
  'Botswana',
  'Brazil',
  'Brunei',
  'Bulgaria',
  'Burkina Faso',
  'Burundi',
  'Cambodia',
  'Cameroon',
  'Canada',
  'Cape Verde',
  'Central African Republic',
  'Chad',
  'Chile',
  'China',
  'Colombi',
  'Comoros',
  'Congo (Brazzaville)',
  'Congo',
  'Costa Rica',
  "Cote d'Ivoire",
  'Croatia',
  'Cuba',
  'Cyprus',
  'Czech Republic',
  'Denmark',
  'Djibouti',
  'Dominica',
  'Dominican Republic',
  'East Timor (Timor Timur)',
  'Ecuador',
  'Egypt',
  'El Salvador',
  'Equatorial Guinea',
  'Eritrea',
  'Estonia',
  'Ethiopia',
  'Fiji',
  'Finland',
  'France',
  'Gabon',
  'Gambia, The',
  'Georgia',
  'Germany',
  'Ghana',
  'Greece',
  'Grenada',
  'Guatemala',
  'Guinea',
  'Guinea-Bissau',
  'Guyana',
  'Haiti',
  'Honduras',
  'Hungary',
  'Iceland',
  'India',
  'Indonesia',
  'Iran',
  'Iraq',
  'Ireland',
  'Israel',
  'Italy',
  'Jamaica',
  'Japan',
  'Jordan',
  'Kazakhstan',
  'Kenya',
  'Kiribati',
  'Korea, North',
  'Korea, South',
  'Kuwait',
  'Kyrgyzstan',
  'Laos',
  'Latvia',
  'Lebanon',
  'Lesotho',
  'Liberia',
  'Libya',
  'Liechtenstein',
  'Lithuania',
  'Luxembourg',
  'Macedonia',
  'Madagascar',
  'Malawi',
  'Malaysia',
  'Maldives',
  'Mali',
  'Malta',
  'Marshall Islands',
  'Mauritania',
  'Mauritius',
  'Mexico',
  'Micronesia',
  'Moldova',
  'Monaco',
  'Mongolia',
  'Morocco',
  'Mozambique',
  'Myanmar',
  'Namibia',
  'Nauru',
  'Nepal',
  'Netherlands',
  'New Zealand',
  'Nicaragua',
  'Niger',
  'Nigeria',
  'Norway',
  'Oman',
  'Pakistan',
  'Palau',
  'Panama',
  'Papua New Guinea',
  'Paraguay',
  'Peru',
  'Philippines',
  'Poland',
  'Portugal',
  'Qatar',
  'Romania',
  'Russia',
  'Rwanda',
  'Saint Kitts and Nevis',
  'Saint Lucia',
  'Saint Vincent',
  'Samoa',
  'San Marino',
  'Sao Tome and Principe',
  'Saudi Arabia',
  'Senegal',
  'Serbia and Montenegro',
  'Seychelles',
  'Sierra Leone',
  'Singapore',
  'Slovakia',
  'Slovenia',
  'Solomon Islands',
  'Somalia',
  'South Africa',
  'Spain',
  'Sri Lanka',
  'Sudan',
  'Suriname',
  'Swaziland',
  'Sweden',
  'Switzerland',
  'Syria',
  'Taiwan',
  'Tajikistan',
  'Tanzania',
  'Thailand',
  'Togo',
  'Tonga',
  'Trinidad and Tobago',
  'Tunisia',
  'Turkey',
  'Turkmenistan',
  'Tuvalu',
  'Uganda',
  'Ukraine',
  'United Arab Emirates',
  'United Kingdom',
  'United States',
  'Uruguay',
  'Uzbekistan',
  'Vanuatu',
  'Vatican City',
  'Venezuela',
  'Vietnam',
  'Yemen',
  'Zambia',
  'Zimbabwe',
];
# middle_index = int(len(countries)/2)
# moddule_count = len(countries)%2
# first_countries = list()
# seconde_countries = []
# if moddule_count == 0:
#     first_countries = countries[:middle_index]
#     seconde_countries = countries[middle_index:]
# else:
#     first_countries = countries[:middle_index+1]
#     seconde_countries = countries[middle_index+1:]
# print(len(countries))
# print(middle_index)
# print(moddule_count)
# print(len(first_countries))
# print(len(seconde_countries))
# print(first_countries)
# print(seconde_countries)

unpack_countries = ['China', 'Russia', 'USA', 'Finland', 'Sweden', 'Norway', 'Denmark']
first_country,second_country,third_country,*rest = unpack_countries
print(first_country)
print(second_country)
print(third_country)
print(rest)









