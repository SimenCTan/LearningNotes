# empty_dict = {}
# empty_dict = dict()
# person = { 'first_name':'simen','last_name':'Yetayeh'
#           ,'age':18,'country':'China',
#             'skills':['JavaScript','React','VUE','Node','TypeScript'] ,
#             'address':{'address':'Long Road','zipcode':'5132009'}}

# print(len(person))
# print(person['first_name'])
# print(person.get('age'))
# print(person.get('city'))
# print(person.get('skills'))
# person['city']='Shenzhen'
# person['skills'].append('HTML')
# print(person)
# person['first_name']='Ely'
# person['age']=19
# print('first_name' in person)
# person.pop('city')
# person.popitem()
# del person['last_name']
# print(person)
# person_list = person.items()
# print(type(person_list))
# print(person_list)
# print(person)
# # person.clear()
# # del person
# person_copy = person.copy()
# person_copy['age']=20
# print(person_copy)
# print(person)
# person_keys = person.keys()
# print(person_keys)
# person_values = person.values()
# print(person_values)

'''exercise'''
dog_dict = {}
dog_dict = {'name':'wangcai','color':'white','breed':'Beef','legs':4,'age':2}
student_dict = {'first_name':'Ely','last_name':'Gof','gender':'male',
                'age':18,'is_married':False,'skills':{'HTML','JS'},'country':'China',
                'city':'shenzhen','address':{'address':'longroad','zipcode':'32413'}}

print(len(student_dict))
print(student_dict['skills'])
print(type(student_dict['skills']))
student_dict['skills'].update({'VUE'})
print(student_dict['skills'])
student_keys = student_dict.keys()
student_values = student_dict.values()
student_list = student_dict.items()
print(student_list)
print(type(student_list))
student_dict.pop('age')
del student_dict['city']
print(student_dict)
