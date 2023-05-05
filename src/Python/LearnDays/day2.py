print(abs(3))
print(abs(1+3j))
print(abs(-3.12))

print(f'{abs(3):.2f}')
print(f'{abs(1+3j):.4f}')
print(f'{abs(-3.1221):.3f}')
fruits=["apple",'fruit','banana','香蕉']
print(fruits)
print(ascii(fruits))
print(bin(-1))
print(format(7,'b'))
print(format(7,'#b'))
print(f'{7:b}')
print(bool(2+1j))
s = 'hello, world'
b = bytearray(s, 'utf-8')
c = bytes(s,'utf-8')
print(b)
print(c)
print(bytearray((1,2,3,5)))
print(bytearray([1,2,3]))

s= max(1,2,3)
print(f'{s:b}')
s= sum([1,2,3])
print(s)
s=min({1,2,3})
print(s)
a1_jj='ddd'
print(len(a1_jj))

person_info={
    "name":"simen",
    "age":18,
    "sex":"male"
    }
print(person_info)
print(len(person_info))

multi_var1,multi_var2='aa',1
# multi_var1=input('var1 input:')
print(f'{multi_var1}')

for item in zip([1,2,3],{'a','b','c'},strict=True):
    print(item)

for single_item in zip(range(1,5)):
    print(single_item)

print(type(zip([1,2],[3,4])))

multi_var3=[1,2,3]
multi_var4=[4,5,6]
list_zip = list(zip(multi_var3,multi_var4))
print(list_zip)
x2,y2=zip(*zip(multi_var3,multi_var4))
print(x2)
print(y2)
print(list(x2)==multi_var3)
print(list(y2)==multi_var4)

num_int=10
print(num_int)
print(float(num_int))
gravity = 9.81
print(int(gravity))
num_int_2str=str(num_int)
print(num_int_2str)
# str to int or float
num_str = '10.6'
#print('num_int', int(num_str))      # 10
print('num_float', float(num_str))  # 10.6
print('num_int',int(float(num_str)))
first_name="simen"
print(list(first_name))

# Exercises
num_one,num_two=5,4
total=num_one+num_two
diff=num_one-num_two
product=num_one*num_two
division=num_one/num_two
exp=num_one**num_two
floor_division=num_one//num_two

print(total,diff,product,division,exp,floor_division)

# circle radius is 30
radius=30
area_of_circle=3.14*30**2
circum_of_circle=2*3.14*30
print('define circle radius:',area_of_circle,circum_of_circle)
radius=int(input("Pls input circle radius:"))
print(3.14*radius**2)
