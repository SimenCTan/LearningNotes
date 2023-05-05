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
>数字型
- 整型(x=5)、浮点型(y=3.14)、Complex(Example 1 + j, 2 + 4j)
>字符串类型(name="john")
>Booleans类型(is_raining=True)
>有序集合List
- 有序集合在集合中能存取不同的数据类型:fruits = ["apple", "banana", "cherry"]
>字典
- 字典对象是键值对格式的无序数据集合:person = {"name": "John", "age": 36}
> Tuple 元组
- 元组和List一样是个有序集合但一旦定义就不能更改:numbers = (1, 2, 3)
> Set集合是个只存取唯一项的无序集合: colors = {"red", "green", "blue"}
>类型判断 type("1+1i")
