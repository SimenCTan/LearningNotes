# import mymodule
# print(mymodule.generate_full_name('simen','your'))
# from mymodule import generate_full_name,sum_all_numbers
# generate_full_name('you','hi')
# print(sum_all_numbers(1,2,3,4))
from mymodule import generate_full_name as fullname,sum_all_numbers as total
import os
import sys
import statistics
from math import *
import string
from random import random,randint
fullname('sime','you')
total(1,2,3)

# Getting current working directory
print(os.getcwd())
# Creating a directory
# os.mkdir('test')
# Removing directory
# os.rmdir('test')

#print('Welcome {}. enjoy {} challenge!'.format(sys.argv[0],sys.argv[1]))

# env path
# print(sys.path)
# print(sys.maxsize)
# ages = [20, 20, 20, 24, 25, 26, 26, 20, 23, 26, 26]
# print(statistics.mean(ages))
# print(statistics.median(ages))
# print(statistics.mode(ages))
# print(statistics.stdev(ages))
# print(pi)
# print(string.ascii_letters)
# print(string.punctuation)
# print(string.digits)

# print(randint(5,12))
# print(random())

'''exercise'''
def shuffle_list(lis):
    shufflelist = list()
    for item in lis:
        shufflelist.append(item*randint(1,5))
    return shufflelist
print(shuffle_list([1,2,3]))

def unique_random_lis():
    unique_list = list()
    while(len(unique_list)<7):
        item = randint(0,9)
        if(item in unique_list):
            continue
        else:
            unique_list.append(item)
    return unique_list

print(unique_random_lis())
