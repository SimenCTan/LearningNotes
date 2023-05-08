## 简介
>Python是一种解释型脚本语言，所以不需要编译,自带Python Shell等待用户输入代码逐行解释运行code
-- python 交互脚本
```
py.exe
python shell code

7//2 # 移除余数
5**2 # 指数
```
## [pyenv 管理py版本号](https://github.com/pyenv/pyenv)
- Windows 安装pyenv已存在python安装方法
```
pip install pyenv-win --target C:\\Users\\aren\\.pyenv
```
- 升级pyenv
  - 在python的安装目录中找到\site-packages\easy_install.pth file 如果没有的话就新建一个 增加pyenv的安装路径 C:\%USERPROFILE%\.pyenv

- 未安装过python安装方法
```
Invoke-WebRequest -UseBasicParsing -Uri "https://raw.githubusercontent.com/pyenv-win/pyenv-win/master/pyenv-win/install-pyenv-win.ps1" -OutFile "./install-pyenv-win.ps1"; &"./install-pyenv-win.ps1"
```


## 基础语法
- 以空格来区分代码块
>代码注释
- 单行注释以 # 号开头
- 多行注释以三引号开始
```
"""This is multiline comment
multiline comment takes multiple lines.
python is eating the world
"""
```

## 基础类型
### 数字型
- 整型(x=5)、浮点型(y=3.14)、Complex(Example 1 + j, 2 + 4j)
复数相乘的运算口诀："实部相乘，虚部相加"
复数除法转化为乘法，我们可以使用如下的技巧。将除数 b 的共轭复数乘以分子和分母的积，然后将除数和它的共轭复数相乘。也就是说，我们可以将 c 表示为：
```python
a = x1 + y1j
b = x2 + y2j

c = a/b = (x1 + y1j) * (x2 - y2j) / (x2^2 + y2^2)
```
### 字符串类型
(name="john")/(name='john')/(name="""john""")多行字符串是通过使用三重单引号 (''') 或三重双引号 (""") 创建的,python中的转义字符串
```
\n: new line
\t: Tab means(8 spaces)
\\: Back slash
\': Single quote (')
\": Double quote (")
```
- 格式化字符串
  - 旧式字符串格式（% 运算符：%s - 字符串（或任何具有字符串表示形式的对象，如数字）；%d - 整数；%f - 浮点数；"%.number of digitsf" - 具有固定精度的浮点数
  - 新样式字符串格式 (str.format)，另一种新的字符串格式是字符串插值，f-strings。字符串以 f 开头，我们可以在其对应的位置注入数据。
- 字符串作为字符序列
  - 解包字符:a,b,c,d='Pyth'
  - 按索引访问字符串中的字符,在编程中计数从零开始。因此，字符串的第一个字母索引为零，字符串的最后一个字母是字符串的长度减一, `print('Pt'[-1])`
  - 字符串切片`first_three = language[0:3] # starts at zero index and up to 3 but not include 3`
  - 字符串反转 `greeting = 'Hello, World! print(greeting[::-1]) # !dlroW ,olleH`
  - 切片时跳过字符 `language = 'Python'
pto = language[0:6:2] #
print(pto) # Pto`
- 字符串的方法
  1. capitalize()：将字符串的第一个字符转换为大写字母
  2. count()：返回子字符串在字符串中出现的次数，count(substring, start=.., end=..)。 start 是用于计数的起始索引，end 是要计数的最后一个索引。
  3. endswith()：检查字符串是否以指定结尾结尾
  4. expandtabs()：用空格替换制表符，默认制表符大小为6,也可以指定空格大小
  5. find()：返回第一次出现的子串的索引，如果没有找到则返回-1
  6. format()：将字符串格式化为更好的输出
  7. index()：返回子字符串的最低索引，附加参数指示开始和结束索引（默认 0 和字符串长度 - 1）。如果未找到子字符串，则会引发 valueError。
  8. rindex()：返回子字符串的最高索引，附加参数指示起始和结束索引（默认 0 和字符串长度 - 1）
  9. isalnum()：检查字母数字字符
  10. isalpha()：检查所有字符串元素是否都是字母字符（a-z 和 A-Z）
  11. isdecimal()：检查字符串中的所有字符是否都是十进制（0-9）
  12. isdigit()：检查字符串中的所有字符是否都是数字（0-9 和一些其他数字的 unicode 字符）
  13. isnumeric()：检查字符串中的所有字符是否都是数字或数字相关（就像 isdigit() 一样，只接受更多符号，如 ½）
  14. isidentifier()：检查一个有效的标识符——它检查一个字符串是否是一个有效的变量名
  15. islower()：检查字符串中的所有字母字符是否均为小写
  16. isupper()：检查字符串中的所有字母字符是否都是大写
  17. join()：返回一个连接的字符串
  18. strip()：从字符串的开头和结尾删除所有给定的字符
  19. replace()：用给定的字符串替换子字符串
  20. split()：拆分字符串，使用给定的字符串或空格作为分隔符
  21. title()：返回标题大小写的字符串
  22. swapcase()：将所有大写字符转换为小写，将所有小写字符转换为大写字符
  23. startswith()：检查字符串是否以指定字符串开头

### Booleans类型
(is_raining=True)布尔数据类型表示两个值之一：True 或 False。
### List
- 有序集合在集合中能存取不同的数据类型,是一个有序且可变（modifiable）的集合。允许重复成员,fruits = ["apple", "banana", "cherry"]
  - 使用正索引访问列表项
  ![img](./assets/list_index.png)
  - 对list进行解包 `lst = ['item','item2','item3', 'item4', 'item5'] first_item, second_item, third_item, *rest = lst`
  - 对索引进行切片,正向索引访问可以通过指定开始、结束和步骤来指定一系列正索引，返回值将是一个新列表。`web_techs[1:3:2]`，负向索引访问可以通过最后一个元素指定为（-1）开始、结束和步骤来指定负索引的范围，返回值将是一个新列表`web_techs[-7:-1:2]`
  - 对有序集合进行更改`web_techs[0]='XAML'`
  - 判断一个元素有没有在集合中 `exist_css = 'CSS' in web_techs`
  - 要将元素添加到现有列表的末尾，我们使用方法 append()`web_techs.append('HTML')`
  - 我们可以使用 insert() 方法在列表中的指定索引处插入单个项目。请注意，其他项目向右移动。 insert() 方法有两个参数：索引和要插入的项目。`web_techs.insert(1,'MVVM')`
  - remove 方法从列表中删除指定的项目 `web_techs.remove('MVVM')`
  - pop() 方法删除指定的索引（如果未指定索引，则删除最后一项）`web_techs.pop(-1)`
  - del 关键字删除指定索引，也可用于删除索引范围内的项目。它还可以完全删除列表 `del web_techs[0:3]`
  - clear() 方法清空列表 `web_techs.clear()`
  - 可以通过以下方式将列表重新分配给新变量来复制列表：list2 = list1。现在，list2 是 list1 的引用，我们对 list2 所做的任何更改也会修改原始 list1。但是在很多情况下，我们不喜欢修改原始文件，而是希望有一个不同的副本。避免上述问题的一种方法是使用 copy()。
  - 有几种方法可以加入或连接两个或多个列表
    - 加号运算符 (+)
    - 使用 extend() 方法加入 extend() 方法允许在列表中附加列表。`web_techs.extend(copy_web_techs)`
  - count() 方法返回一个项目在列表中出现的次数 `print(web_techs.count('VUE'))`
  - index() 方法返回列表中项目的索引 `web_techs.index('VUE')`
  - reverse() 方法反转列表的顺序 `web_techs.reverse()`
  - 要对列表进行排序，我们可以使用 sort() 方法或 sorted() 内置函数。 sort() 方法按升序对列表项重新排序并修改原始列表。如果 sort() 方法 reverse 的参数等于 true，它将按降序排列列表 'web_techs.sort()',sort()：此方法修改原始列表;sorted()：返回有序列表，不修改原列表
  - 我们可以使用 in 检查元组中是否存在一个项目，它返回一个布尔值
  - 我们可以使用 + 运算符连接两个或多个元组
  - 不可能删除元组中的单个项目，但可以使用 del 删除元组本身
### Tuple
- 元组和List一样是个有序集合,允许重复成员但一旦定义就不能更改:numbers = (1, 2, 3)
  - 创建元组`empty_tuple = (); empty_tuple = tuple()`
  - 元组元素的个数 `len(set_2_tuple)`
  - 通过索引访问元组元素 `set_2_tuple[-3]`
  ![img](./assets/tuples_index.png)
  ![img](./assets/tuple_negative_indexing.png)
  - 对元组进行切片 `set_2_tuple[-2:-1]`
  - 我们可以将元组更改为列表，将列表更改为元组。元组是不可变的，如果我们想修改元组，我们应该将其更改为列表。
### Set
集合用于存储唯一项，可以找到集合之间的并集、交集、差集、对称差集、子集、超集和不相交集。集合是个无序集合，不允许重复，无法通过索引访问且成员定义就不可以更改，但可以向集合中添加新项: colors = {"red", "green", "blue"}
- 创建集合我们使用大括号 {} 来创建一个集合或 set() 内置函数 `empty_set = set()`
- 要检查一个项目是否存在于 `'HTML' in web_techs`
- 一旦创建了一个集合，我们就不能更改任何项目，我们也可以添加额外的项目 `web_techs.add('VUE')`
- 使用 update() 添加多个项目 update() 允许将多个项目添加到集合中,update() 接受一个列表参数 `web_techs.update(other_web_techs)`
- 我们可以使用 remove() 方法从集合中删除一个元素。如果找不到该元素，remove() 方法将引发错误，因此最好检查该元素是否存在于给定的集合中。但是，discard() 方法不会引发任何错误 `web_techs.remove('HTML')` `web_techs.discard('HTML')`
- pop() 方法从列表中随机删除一个项目，并返回删除的项目 `print(web_techs.pop())`
- 如果我们想清除或清空集合，我们使用 clear 方法 `web_techs.clear()`
- 如果我们想删除集合本身，我们使用 del 运算符
- 我们可以将列表转换为集合，并将集合转换为列表。将列表转换为集合会删除重复项，并且只会保留唯一的项目 `web_techs_list = list(web_techs) web_techs = set(web_techs_list)`
- 我们可以使用 union() 或 update() 方法连接两个集合,重复元素仅保留一个 `fruits.union(vegetables)`
- 交集返回两个集合中的一组项目 `inter_section = fruits.intersection(vegetables)`
- 一个集合可以是其他集合的子集或超集 `is_sub_set = inter_section.issubset(fruits)`
- 检查两个集合之间的差异 `fruits.difference(inter_section)`
- 对称差：将两个集合分别做差集，再将这两个差集去重合并起来，得到一个新的集合，包含两个集合中互不相交的元素 `fruits.symmetric_difference(inter_section)`
- 如果两个集合没有一个或多个共同项，我们称它们为不相交的集合。我们可以使用 isdisjoint() 方法检查两个集合是联合的还是不相交的 ``


### 字典
- 字典对象是键值对格式的无序数据集合:person = {"name": "John", "age": 36}，可以更改有索引但不允许重复值

### 类型判断
type("1+1i")

### 类型转换
将一种数据类型转换为另一种数据类型。我们使用int(), float(), str(), list, set 进行算术运算时，字符串数字要先转为int或float，否则会返回错误。如果我们连接一个数字和一个字符串，首先应该将数字转换为字符串。我们将在字符串部分讨论连接。

### 变量
变量不能以数字开头，并且不能包括特殊字符和连字符,命令规则为
1. 变量名必须以字母或下划线字符开头
2. 变量名不能以数字开头
3. 变量名称只能包含字母数字字符和下划线（A-z、0-9 和 _）
4. 变量名区分大小写（firstname、Firstname、FirstName 和 FIRSTNAME 是不同的变量）

用snake_case命名变量 `my_variable`，在一行中声明多个变量
```
first_name, last_name, country, age, is_married = 'Asabeneh', 'Yetayeh', 'Helsink', 250, True
```

### 操作符
赋值运算符用于为变量赋值,下表显示了不同类型的 python 赋值运算符
![img](./assets/assignment_operators.png)
```
x=3
x>>=1
print(x)
x<<=3
print(x)
x^=3
print(x)
x&=3
print(x)
x|=3
print(x)
```

算术运算符
![img](./assets/arithmetic_operators.png)
比较运算符
![img](./assets/comparison_operators.png)
逻辑操作符
