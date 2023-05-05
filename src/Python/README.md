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
### 字符串类型(name="john")
### Booleans类型(is_raining=True)
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
