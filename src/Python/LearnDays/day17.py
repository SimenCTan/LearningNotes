# try:
#     name = input('Enter your name:')
#     year_born = input('Year you born:')
#     age = 2023-int(year_born)
# except Exception as e:
#     print(e)
# else:
#     print('I usually run with the try block')
# finally:
#     print('I alway run.')

def sum_of_five_nums(a,b,c,d,e):
    return a+b+c+d+e
lst_nums = [1,2,3,4,5]
print(*lst_nums)
print(sum_of_five_nums(*lst_nums))

numbers = range(2,7)
args = [2,7]
print(list(numbers))
print(list(range(*args)))

countries = ['Finland', 'Sweden', 'Norway', 'Denmark', 'Iceland']
fin,sec,third,*rest = countries
print(fin,sec,third,rest)
numbers_pack = [1,2,3,4,5,6]
first,*mid,last=numbers_pack
print(first,mid,last)

def unpacking_person_info(name, country, city, age):
    return f'{name} lives in {country}, {city}. He is {age} year old.'
person_dct = {'name':'go','country':'Japen','city':'toyo','age':12}
print(unpacking_person_info(**person_dct))

def sum_all(*args):
    s = 0
    for i in args:
        s+=i
    return s
print(sum_all(1,2,3,4))

def packing_person_info(**kwargs):
    print(type(kwargs))
    for key in kwargs:
        print(f'{key}={kwargs[key]}')
    return 0
print(packing_person_info(name='Asabeneh',country="Finland", city="Helsinki", age=250))

lst_one = [1,2,3]
lst_two = [4,5,6]
lst = [0,*lst_one,*lst_two]
print(lst)

new_args = [2,7]
new_nums = range(*new_args)
print(list(new_nums))
for index,item in enumerate(range(*[2,6])):
    print(index,item)

fruits = ['banana', 'orange', 'mango', 'lemon', 'lime','gogo']
vegetables = ['Tomato', 'Potato', 'Cabbage','Onion', 'Carrot']
fruits_and_veges = list()
for f,v in zip(fruits,vegetables):
    fruits_and_veges.append({'fruit':f,'veg':v})
print(fruits_and_veges)

names = ['Finland', 'Sweden', 'Norway','Denmark','Iceland', 'Estonia','Russia']
*nordic_countries,es,ru = names
print(nordic_countries)
print(es)
print(ru)


