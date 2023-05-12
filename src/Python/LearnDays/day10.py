# count=0
# while count<5:
#     if(count>3):
#         break
#     print(count)
#     count+=1

# fruits = ['Apple','Orange','Banana']
# for fruit in fruits:
#     print(fruit)
# for word in 'Apple':
#     print(word)

# fruit_tuple=('Apple','Orange','Banana')
# for fruit in fruit_tuple:
#     print(fruit)

# person = {
#     'first_name':'Asabeneh',
#     'last_name':'Yetayeh',
#     'age':250,
#     'country':'Finland',
#     'is_marred':True,
#     'skills':['JavaScript', 'React', 'Node', 'MongoDB', 'Python'],
#     'address':{
#         'street':'Space street',
#         'zipcode':'02210'
#     }
# }
# for key in person.keys():
#     print(key)
# for key in person:
#     print(key)

# for key,value in person.items():
#     print(key,value)

# tech_set = {'HTML','CSS','JS','REACT','Node','VUE'}
# for tech in tech_set:
#     print(tech)

# range_list = range(0,11,2)
# print(type(range_list))
# for number in range_list:
#     print(number)

# for key in person:
#     if key=='skills':
#         for skill in person['skills']:
#             print(skill)

# for num in range(3):
#     pass
#     print(num)
#     pass

'''exercise'''
count=0
while count<11:
    print(count)
    count+=1
count=10
while count<=10:
    if(count<0):
        break
    print(count)
    count-=1

while count<7:
    for key in range(count):
        print('#',end='')
    print()
    count+=1

count=0
while count<9:
    for key in range(9):
        print('#',end=' ')
    print()
    count+=1

fruits = ['banana', 'orange', 'mango', 'lemon']
reverse_fruits =list()
last_index = len(fruits) -1
while last_index>=0:
    reverse_fruits.append(fruits[last_index])
    last_index-=1
print(reverse_fruits)
fruits.reverse()
print(fruits)



