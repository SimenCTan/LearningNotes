# empty_tuple = ()
# empty_tuple = tuple()
# set_2_tuple = tuple({1,2,3})
# print(len(set_2_tuple))
# print(set_2_tuple[-3])
# slice_tuple = set_2_tuple[-2:-1]
# print(set_2_tuple[-2:])
# print(slice_tuple)
# print(list(slice_tuple))
# list_2_tuple = tuple(list(slice_tuple))
# print(list_2_tuple)
# join_tuple = slice_tuple + set_2_tuple
# print(join_tuple)
# del slice_tuple

"""exercise"""
first_person,second_person,*rest_perp=tuple({"grandmam","grandfather","mam","father","brother","sister"})
print(first_person)
print(second_person)
print(rest_perp)
fruits = tuple(['apple','banana','orange'])
vegetables = tuple(['lettuce','celery','carrot'])
animal = tuple(['mouse','lion','monkey'])
food_stuff_tp = fruits+vegetables+animal
print(food_stuff_tp)
food_stuff_list = list(food_stuff_tp)
print(food_stuff_list)
middle_index =int(len(food_stuff_tp)/2)
slice_food = food_stuff_tp[0:middle_index]
print(slice_food)
del food_stuff_tp
nordic_countries = ('Denmark', 'Finland','Iceland', 'Norway', 'Sweden')
print('Iceland' in nordic_countries)
print('Estonia' in nordic_countries)




