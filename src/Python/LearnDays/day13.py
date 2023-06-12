# # one way
# language = 'Python'
# lst = list(language)
# print(type(lst))
# print(lst)

# # two way
# lst = [i for i in language]
# print(type(lst))
# print(lst)

# # generating numbers
# numbers = [i for i in range(11)]
# print(numbers)

# # it is possible to do mathematical operations during iteration
# squares = [i*i for i in range(11)]
# print(squares)

# # it is possible to make a list of tuples
# numbers = [(i,i**2) for i in range(11)]
# print(numbers)

# # generate even numbers
# even_numbers = [i for i in range(21) if i%2==0]
# print(even_numbers)

# # Filter numbers: let's filter out positive even numbers from the list below
# numbers = [-8, -7, -3, -1, 0, 1, 3, 4, 5, 7, 6, 8, 10]
# positive_even_numbers = [i for i in numbers if i%2==0 and i>0]
# print(positive_even_numbers)

# # Flattening a three dimensional array
# list_of_lists = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
# flatten_list = [number for row in list_of_lists for number in row]
# print(flatten_list)

# # named function
# def add_two_nums(a,b):
#     return a+b
# print(add_two_nums(2,3))

# # lambda function
# lambda_add_two_nums = lambda a,b:a+b
# print(lambda_add_two_nums(2,3))

# # self invoking lambda function
# (lambda a,b:a+b)(2,3)
# square = lambda x:x**2
# print(square(3))

# # using lambda in another function
# def power(x):
#     return lambda n:x**n

# print(power(2)(5))


''' exercise '''
numbers = [-4, -3, -2, -1, 0, 2, 4, 6]
negative_numbers = [i for i in numbers if i<=0]
print(negative_numbers)

list_of_lists =[[[1, 2, 3]], [[4, 5, 6]], [[7, 8, 9]]]
number_of_lists = [x for square in list_of_lists for row in square for x in row]
print(number_of_lists)

tuple_list = [(i,i**0,i**1,i**2,i**3,i**4,i**5,i**6) for i in range(11)]
print(tuple_list)

countries = [[('Finland', 'Helsinki')], [('Sweden', 'Stockholm')], [('Norway', 'Oslo')]]
tuple_countries = [c for list_countries in countries for c in list_countries]


