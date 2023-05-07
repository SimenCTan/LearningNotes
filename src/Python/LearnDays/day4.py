import random
# unpack_str = "Pyth"
# a,b,c,d="Okkk"
# print(d)
# print('Pt'[-1])
# print(unpack_str[0:2])
# print(unpack_str[1:2])
# print(unpack_str[2:4])
# print(unpack_str[-2:])
# print(unpack_str[0:4:2])

# method_of_str = "python method"
# print(method_of_str.capitalize())
# print(method_of_str.count('t',0,13))
# print(method_of_str.endswith('hod'))
# print(method_of_str.endswith('hd'))

# method_of_str = 'python\tmethod'
# # print(method_of_str.expandtabs())
# # print(method_of_str.expandtabs(2))
# print(method_of_str.find('od'))
# print(method_of_str.index('\t'))
# print(method_of_str.rindex('t'))
# print(method_of_str.isalnum())
# print(method_of_str.isalpha())
# print(method_of_str.isdecimal())
# print(method_of_str.isidentifier())
# print('&'.join(method_of_str))
# str_list = ['Hello',"Sam"]
# print(','.join(str_list))
# method_of_str='python'
# print(method_of_str.strip('t'))
# challenge = 'thirty days of pythoonnn'
# print(challenge.strip('noth')) # 'irty days of py'
# print(challenge.split())
# print(challenge.split(','))
# print(challenge.title())
# print(challenge.swapcase())
# print(challenge.startswith("th"))

# exercises
# a,b,c,d='Thirty', 'Days', 'Of', 'Python'
# single_str = a+b+c+d
# print(single_str)
# company='Coding For All'
# print(company.upper())
# print(company.lower())
# print(company.capitalize())
# print(company.title())
# print(company.swapcase())
# print(company[:1])
# print(company.index('Coding'))
# print(company.rfind('Coding'))
# print(company[10:11])

# py_str='Python For Everyone'
# abb = ''
# print(py_str.strip('Pyone'))
# py_list = py_str.split()
# print(type(py_list))
# for word in py_list:
#     abb += word[0]
# print(abb)

# slice_str =  'You cannot end a sentence with because because because is a conjunction'
# print(slice_str.index('because'))
# print(slice_str.rindex('because'))
# print(slice_str[31:54])

# strip_str = '   Coding For All      '
# print(strip_str.strip())

# lib_list = ['Django', 'Flask', 'Bottle', 'Pyramid', 'Falcon']
# print(' '.join(lib_list))
# print('I am enjoying this challenge.\nI just wonder what is next.')
# print('Name\tAge\tCountry\tCity')
# print('Asabeneh\t250\tFinland\tHelsinki')

# format_str = '{:1}'.format(1)
# print(len(format_str))

# video simple
num_input=5
while num_input>0:
    print(num_input)
    num_input-=1
print('finish')
num_list = [i for i in range(10)]
print(num_list)

num_list=[]
for i in range(3):
    num_list.append(list(range(1,6)))
print(num_list)

pos = [ i for i in range(-5,6) if i>=0]
print(pos)
random.shuffle(pos)
print(pos)
