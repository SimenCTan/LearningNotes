import math

# Day 1 print
print(3//4)
print(3%4)
print(3**4)
print(3/4)

print('learn py')
print(type(10))
print(type(4.13))
print(type(1 + 1j))
print(type("py"))
print(type(['aaa','bbb']))

# simple
# integer
x=5
print('The value of x is {x}')
# float
y=3.14
print(f'The value of y is {y:.2f}')
# complex
z=2+3j
print(f'The value of z is {z.real} + {z.imag}j.')
# string
name="john"
print(f'hello,my name is {name}')
#boolean
is_raining=True
print(f"Is it raining outside? {is_raining}.")

#list
fruits=['apple','banana','cherry']
fruits.append('orrang')
print(f"My favorite fruit is {fruits[0]} and I have {len(fruits)} fruits in my basket.")

#truple
numbers=(1,2,3)
sum_number = sum(numbers)
print(f'The sum of numbers is {sum_number}')

#Set
colors={'red','green','blue'}
colors.add('pink')
print(f"I have {len(colors)} colors in my collection.")

# dictionary
person={"name":"john","age":"25"}
person["city"]="new york"
print(f"{person['name']}")

# define the two points
point1=(2,3)
point2=(10,8)
distance=math.sqrt((point2[0]-point1[0])**2+(point2[1]-point1[1])**2)
print(f'{distance:.2f}')



