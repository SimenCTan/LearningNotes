# class Person:
#     pass
# print(Person)
# p=Person()
# print(p)

# class PersonConct:
#     def __init__(self,name):
#         self.name = name
#     def person_info(self):
#         return f'person name is {self.name}'

# p=PersonConct('go')
# print(p.name)
# print(p)
# print(p.person_info())

# class PersonDef:
#     def __init__(self,name='go'):
#         self.name = name

# pf = PersonDef()
# print(pf.name)
# p1 = PersonDef('you')
# print(p1.name)

# class PersonModify:
#     def __init__(self,name='go',age=21,skills=[]):
#         self.name=name
#         self.age=age
#         self.skills=skills
#     def add_skill(self,skill):
#         self.skills.append(skill)

# p = PersonModify(name='go',age=21)
# p.add_skill('UI Design')
# print(p.skills)

# class StudentModify(PersonModify):
#     pass
# s = StudentModify(name='student',age=12,skills=['Swimming'])
# s.add_skill('Play')
# print(s.skills)

# class StudentOverriding(PersonModify):
#     def __init__(self, gender ,name='go', age=21, skills=[]):
#         self.gender = gender
#         super().__init__(name, age, skills)
#     def person_info(self):
#         gender = 'He' if self.gender=='male' else 'She'
#         return f'{gender} name is {self.name} and age is {self.age}'
# so = StudentOverriding(gender='male',name='ov')
# print(so.person_info())

'''exercises'''
class Statistics:
    def __init__(self, data):
        self.data=data
    def count(self):
        return len(self.data)

    def sum(self):
        return sum(self.data)

    def min(self):
        return min(self.data)

    def max(self):
        return max(self.data)

    def range(self):
        return max(self.data)-min(self.data)

    def mean(self):
        return sum(self.data)/len(self.data)

    def median(self):
        sorted_data = sorted(self.data)
        n = len(sorted_data)
        if(n%2==0):
            return (sorted_data[n//2-1]+sorted_data[n//2])/2
        else:
            return sorted_data[n//2]

    def mode(self):
        count_dict = {}
        for item in self.data:
            if item in count_dict:
                count_dict[item]+=1
            else:
                count_dict[item]=1
        mode_value = max(count_dict.values())
        mode_items = [k for k,v in count_dict.items() if v==mode_value]
        return {'mode':mode_items[0],'count':mode_value}

    def std(self):
        n = len(self.data)
        mean = self.mean()
        sum_squared_diff = sum((x-mean)**2 for x in self.data)
        variance = sum_squared_diff/(n-1)
        return variance**0.5

    def var(self):
        n = len(self.data)
        mean = self.mean()
        sum_squared_diff = sum((x-mean)**2 for x in self.data)
        return sum_squared_diff/(n-1)

    def freq_dist(self):
        count_dict = {}
        for item in self.data:
            if item in count_dict:
                count_dict[item] += 1
            else:
                count_dict[item] = 1
        freq_dist_list = [(k, v) for k, v in count_dict.items()]
        freq_dist_list.sort(key=lambda x: x[1], reverse=True)
        return freq_dist_list

ages = [31, 26, 34, 37, 27, 26, 32, 32, 26, 27, 27, 24, 32, 33, 27, 25, 26, 38, 37, 31, 34, 24, 33, 29, 26]
st_data = Statistics(ages)
print(st_data.count())
print(st_data.sum())
print(st_data.mean())
print(st_data.median())

class PersonAccount:
    def __init__(self, firstname, lastname, incomes={}, expenses={}):
        self.firstname = firstname
        self.lastname = lastname
        self.incomes = incomes
        self.expenses = expenses
    def account_info(self):
        fullname=self.lastname+self.firstname
        incomes_desc = ''
        expenses_desc = ''
        for item in self.incomes.items():
            incomes_desc +=str(item[0])+item[1]
        for item in self.expenses.items():
            expenses_desc +=str(item[0])+item[1]
        return f'name {fullname} has incomes:{incomes_desc} and expenses {expenses_desc}'

    def add_income(self,key,value):
        self.incomes[key]=value

    def add_expenses(self,key,value):
        self.expenses[key]=value

    def account_balance(self):
        return sum(self.incomes.keys())-sum(self.expenses.keys())
pa = PersonAccount('you','daa',incomes={110:'dd',1000:'ddd'},expenses={10:'ee',20:'eee'})
print(pa.account_info())
print(pa.account_balance())
