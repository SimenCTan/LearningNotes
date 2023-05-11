# a = 3
# if a>0:
#     print(f"{a} greater than zero")
# print(f'positive') if a>0 else print('negative')

# if a>0 and a%2==0:
#     print(f'{a} is positive and even')

# fruits = ['banana', 'orange', 'mango', 'lemon']
# you_fruit = input('pls input your fruit')
# is_exist = you_fruit in fruits
# if is_exist:
#     print('That fruit already exist in the list')
# else:
#     fruits.append(you_fruit)
#     print(fruits)

# exercise
person={
    'first_name': 'Asabeneh',
    'last_name': 'Yetayeh',
    'age': 250,
    'country': 'Finland',
    'is_marred': True,
    'skills': ['JavaScript', 'React', 'Node', 'MongoDB', 'Python'],
    'address': {
        'street': 'Space street',
        'zipcode': '02210'
    }
    }
is_skillkey = 'skills' in person
if is_skillkey:
    skill_len = len(person['skills'])
    print(person['skills'][int(skill_len/2)])
if is_skillkey:
    is_python_skill = 'Python' in person['skills']
    print(is_python_skill)

if 'JavaScript' in person['skills'] and 'React' in person['skills']:
    if 'Node' in person['skills'] and 'MongoDB' in person['skills']:
        print('He is a fullstack developer')
    else:
        print('He is a front end developer')
elif 'Node' in person['skills'] and 'Python' in person['skills'] and 'MongoDB' in person['skills']:
    print('He is a backend developer')
else:
    print('unknown title')

is_marred = person.get('is_marred')
country = person.get('country')
if is_marred and country=='Finland':
    print('Asabeneh Yetayeh lives in Finland. He is married.')
