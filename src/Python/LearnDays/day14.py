from functools import reduce
def sum_numbers(nums):
    return sum(nums)
def high_order_function(f,listnums):
    return f(listnums)
print(high_order_function(sum_numbers,[1,2,3]))

def square(x):
    return x**2
def cube(x):
    return x**3
def absolute(x):
    if(x>=0):
        return x
    else:
        return -x
def higher_order_ret_function(function_name):
    if(function_name=='square'):
        return square
    elif(function_name=='cube'):
        return cube
    elif(function_name=='absolute'):
        return absolute
result = higher_order_ret_function('cube')
print(result(3))

def add_ten():
    ten = 10
    def add(num):
        return num+ten
    return add
closure_result=add_ten()
print(closure_result(5))
print(closure_result(10))

# frist decorator
def uppercase_decorator(function):
    def wrapper():
        func = function()
        make_uppercase = func.upper()
        return make_uppercase
    return wrapper
@uppercase_decorator
def greeting():
    return 'Welcome to Python'
print(greeting())
# second decorator
def split_string_decorator(function):
    def wrapper():
        func=function()
        splitted_string=func.split()
        return splitted_string
    return wrapper
@split_string_decorator
@uppercase_decorator
def mul_greeting():
    return 'Welcome to Python'
print(mul_greeting())

def decorator_with_parameters(function):
    def wrapper_accepting_parameters(para1,para2,para3):
        function(para1,para2,para3)
        print("I live in {}".format(para3))
    return wrapper_accepting_parameters
@decorator_with_parameters
def print_full_name(first_name, last_name, country):
    print("I am {} {}. I love to teach.".format(
        first_name, last_name, country))
print_full_name("Asabeneh", "Yetayeh",'Finland')

numbers = [1,2,3,4,5] # iterable
def square(x):
    return x**2
numbers_square = map(square,numbers)
print(list(numbers_square))
numbers_lambda = map(lambda x:x**2,numbers)
print(list(numbers_lambda))

def is_odd(num):
    if num%2!=0:
        return True
    else:
        return False
odd_numbers=filter(is_odd,numbers)
print(list(odd_numbers))

numbers_str = ['1','2','3','4','5']
def add_two_nums(x,y):
    return int(x)+int(y)
total = reduce(add_two_nums,numbers_str)
print(total)
