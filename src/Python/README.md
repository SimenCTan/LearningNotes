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
  - 解包字符，


### Booleans类型
(is_raining=True)布尔数据类型表示两个值之一：True 或 False。
### 有序集合List
- 有序集合在集合中能存取不同的数据类型:fruits = ["apple", "banana", "cherry"]
### 字典
- 字典对象是键值对格式的无序数据集合:person = {"name": "John", "age": 36}
### Tuple 元组
- 元组和List一样是个有序集合但一旦定义就不能更改:numbers = (1, 2, 3)
### Set
集合是个只存取唯一项的无序集合: colors = {"red", "green", "blue"}

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
