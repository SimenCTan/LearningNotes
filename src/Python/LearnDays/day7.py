# empty_set = set()
# empty_set = {}

# print(len(empty_set))

# web_techs = {'HTML','CSS','JS','REACT'}
# print('HTML' in web_techs)
# web_techs.add('VUE')
# other_web_techs={'TS','SSR','CSR','ThaildCSS'}
# web_techs.update(other_web_techs)
# print(web_techs)

# web_techs.remove('HTML')
# web_techs.discard('HTML')
# # print(web_techs.pop())
# # web_techs.clear()
# # del web_techs
# web_techs_list = list(web_techs)
# web_techs = set(web_techs_list)
# print(web_techs_list)
# print(web_techs)

# fruits = {'banana', 'orange', 'mango', 'lemon'}
# vegetables = {'tomato','orange' ,'potato', 'cabbage','onion', 'carrot'}
# print(fruits.union(vegetables))
# #fruits.update(vegetables)
# print(fruits)
# inter_section = fruits.intersection(vegetables)
# print(inter_section)
# is_sub_set = inter_section.issubset(fruits)
# print(is_sub_set)
# is_sup_set = fruits.issuperset(inter_section)
# print(is_sup_set)

# print(fruits.difference(inter_section))

# symmetric_set = fruits.symmetric_difference(inter_section)
# print(symmetric_set)
# print(fruits.isdisjoint(inter_section))


"""exercise"""
# sets
it_companies = {'Facebook', 'Google', 'Microsoft', 'Apple', 'IBM', 'Oracle', 'Amazon'}
A = {19, 22, 24, 20, 25, 26}
B = {19, 22, 20, 25, 26, 24, 28, 27}
age = [22, 19, 24, 25, 26, 24, 25, 24]
print( len(it_companies))
it_companies.add('Twitter')
it_companies.update({'OpenAI','NAVIDA','AMD','TSM'})
print(it_companies)
it_companies.remove('Facebook')
it_companies.discard('Facebook')
AB_Set = A.union(B)
print(AB_Set)
AB_inter_set = A.intersection(B)
print(AB_inter_set)
print(A.issubset(B))
print(A.isdisjoint(B))
symmetric_set = A.symmetric_difference(B)
print(symmetric_set)
del symmetric_set
split_str = "I am a teacher and I love to inspire and teach people"
split_list = split_str.split()
print(type(split_list))
print(split_list)
split_set = set(split_list)
print(len(split_set))
print(split_set)



