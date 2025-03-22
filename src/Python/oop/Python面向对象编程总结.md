# Python面向对象编程总结

## 目录

- [1. Python命名规则](#1-python命名规则)
- [2. 类与对象的基础](#2-类与对象的基础)
- [3. 对象的组合](#3-对象的组合)
- [4. 类、对象、属性、方法与self](#4-类对象属性方法与self)
- [5. 访问与修改对象数据](#5-访问与修改对象数据)
- [6. 访问修饰符](#6-访问修饰符)
- [7. Getter与Setter方法](#7-getter与setter方法)
- [8. 属性（Properties）](#8-属性properties)
- [9. 静态属性与方法](#9-静态属性与方法)
- [10. 封装（Encapsulation）](#10-封装encapsulation)
- [11. 抽象（Abstraction）](#11-抽象abstraction)
- [12. 继承（Inheritance）](#12-继承inheritance)
- [13. 多态（Polymorphism）](#13-多态polymorphism)

## 1. Python命名规则

Python中有一些约定俗成的命名规则，遵循这些规则可以使代码更易读、更符合Python风格。

### 一般命名约定

1. **使用有意义的名称**：名称应当反映变量、函数或类的用途

### 变量和函数命名

2. **小写字母加下划线**：变量和函数名应使用小写字母，多个单词之间用下划线连接（snake_case）

```python
user_name = "张三"
def calculate_total_price(price, quantity):
    pass
```

### 类命名

3. **大驼峰命名法**：类名的每个单词首字母大写（CamelCase）

```python
class BankAccount:
    pass

class CustomerService:
    pass
```

### 常量命名

4. **全部大写加下划线**：常量名应全部使用大写字母，多个单词用下划线连接

```python
MAX_CONNECTIONS = 100
PI = 3.14159
```

### 特殊命名约定

5. **私有和受保护成员**：
   - 以单下划线开头表示受保护的属性或方法：`_protected_attr`
   - 以双下划线开头表示私有的属性或方法：`__private_attr`

6. **魔术方法**：双下划线开头和结尾的方法是特殊方法，如 `__init__`、`__str__`

7. **避免使用的名称**：
   - 避免使用Python关键字和内置函数名
   - 避免使用单个字符作为变量名（除非在非常短小的上下文中）
   - 避免使用数字开头的名称（不合法）

### PEP 8 风格指南

Python官方的PEP 8风格指南提供了详细的命名约定建议，遵循这些约定有助于编写出更Pythonic的代码。命名规则是Python代码可读性的重要组成部分，良好的命名习惯可以提高代码质量和团队协作效率。

## 2. 类与对象的基础

### 类的定义

类是对象的蓝图或模板，它定义了对象可能具有的属性和方法。

```python
class Dog:
    # 初始化方法（构造函数）
    def __init__(self, name, age):
        self.name = name
        self.age = age

    # 实例方法
    def bark(self):
        return f"{self.name}汪汪叫！"
```

### 创建对象

对象是类的实例，通过调用类名来创建：

```python
my_dog = Dog("小黑", 3)
print(my_dog.name)  # 输出：小黑
print(my_dog.bark())  # 输出：小黑汪汪叫！
```

## 3. 对象的组合

对象组合是指一个类包含其他类的对象作为其属性。

```python
class Person:
    def __init__(self, name):
        self.name = name

class Family:
    def __init__(self):
        self.members = []

    def add_member(self, person):
        self.members.append(person)

    def get_names(self):
        return [person.name for person in self.members]
```

使用示例：

```python
dad = Person("爸爸")
mom = Person("妈妈")
child = Person("孩子")

family = Family()
family.add_member(dad)
family.add_member(mom)
family.add_member(child)

print(family.get_names())  # 输出：['爸爸', '妈妈', '孩子']
```

## 4. 类、对象、属性、方法与self

### 属性

属性是与对象关联的数据。

### 方法

方法是与对象关联的函数，可以访问和操作对象的属性。

### self参数

`self`是一个指向实例本身的引用，在实例方法中必须作为第一个参数。

```python
class Person:
    def __init__(self, name, age):
        self.name = name  # 实例属性
        self.age = age    # 实例属性

    def introduce(self):  # 实例方法
        return f"我叫{self.name}，今年{self.age}岁。"
```

## 5. 访问与修改对象数据

Python中可以直接访问和修改对象的属性：

```python
person = Person("张三", 25)
print(person.name)  # 访问属性
person.age = 26     # 修改属性
```

## 6. 访问修饰符

Python使用命名约定而非强制访问控制来实现访问修饰符。

### 公有属性

默认情况下，属性是公有的，可以从类外部访问：

```python
class Example:
    def __init__(self):
        self.public_attr = "公有属性"
```

### 受保护属性

以单下划线开头的属性被视为受保护的，表示它们只应在类内部或子类中使用：

```python
class Example:
    def __init__(self):
        self._protected_attr = "受保护属性"
```

### 私有属性

以双下划线开头的属性被视为私有的，Python会对其名称进行修改，使其难以从外部访问：

```python
class Example:
    def __init__(self):
        self.__private_attr = "私有属性"

# 无法直接访问__private_attr
# 但可以通过 _Example__private_attr 访问（名称重整）
```

### 何时使用受保护与私有属性

- **受保护属性**：当你希望子类可以访问但外部代码不应访问时使用
- **私有属性**：当你确定属性仅应在当前类内使用，且不希望子类覆盖时使用

### Python的"成年人共识"哲学

Python社区奉行"我们都是成年人"的哲学，这意味着开发者应该遵循约定而非强制规则。

## 7. Getter与Setter方法

Getter和Setter方法允许控制对属性的访问和修改。

```python
class Person:
    def __init__(self, name, age):
        self._name = name
        self._age = age

    # Getter方法
    def get_name(self):
        return self._name

    # Setter方法
    def set_name(self, name):
        if isinstance(name, str) and name:
            self._name = name
        else:
            raise ValueError("名字必须是非空字符串")
```

### 为什么使用Getter和Setter？

1. **数据验证**：确保属性值符合预期要求
2. **计算属性**：返回计算后的值而非存储的值
3. **封装改变**：在不改变公共接口的情况下修改内部实现

## 8. 属性（Properties）

属性是Python的一个特性，提供比传统getter/setter更优雅的属性访问控制。

### 定义属性

```python
class Person:
    def __init__(self, name, age):
        self._name = name
        self._age = age

    @property
    def name(self):
        """Getter属性"""
        return self._name

    @name.setter
    def name(self, value):
        """Setter属性"""
        if isinstance(value, str) and value:
            self._name = value
        else:
            raise ValueError("名字必须是非空字符串")
```

### 使用属性

```python
person = Person("张三", 25)
print(person.name)  # 访问属性（调用getter）
person.name = "李四"  # 修改属性（调用setter）
```

## 9. 静态属性与方法

### 静态属性

静态属性属于类而非实例，所有实例共享同一个静态属性：

```python
class Circle:
    pi = 3.14159  # 静态属性

    def __init__(self, radius):
        self.radius = radius  # 实例属性

    def area(self):
        return Circle.pi * self.radius ** 2
```

### 静态方法

静态方法不接收特定的第一个参数，可以通过类或实例调用：

```python
class MathUtils:
    @staticmethod
    def add(a, b):
        return a + b

# 通过类调用
print(MathUtils.add(5, 3))  # 输出：8
```

### 何时使用静态方法？

静态方法适用于以下情况：

- 方法不需要访问实例属性或方法
- 方法逻辑与类相关但不依赖于特定实例
- 用作工具或辅助功能

## 10. 封装（Encapsulation）

封装是将数据（属性）和对数据的操作（方法）绑定到一起，并对外部隐藏实现细节的机制。

### 封装的实现方式

- 将数据声明为私有或受保护
- 通过公共方法提供对数据的访问

```python
class BankAccount:
    def __init__(self, account_number, balance):
        self._account_number = account_number
        self._balance = balance

    def deposit(self, amount):
        if amount > 0:
            self._balance += amount
            return True
        return False

    def withdraw(self, amount):
        if 0 < amount <= self._balance:
            self._balance -= amount
            return True
        return False

    @property
    def balance(self):
        return self._balance
```

### 封装的重要性

1. **隐藏实现细节**：使用者不需要了解内部工作原理
2. **提高安全性**：防止直接访问并可能破坏数据
3. **提供灵活性**：可以在不影响用户代码的情况下更改实现

## 11. 抽象（Abstraction）

抽象是通过隐藏复杂实现细节而向用户暴露必要功能的过程。Python使用抽象类和抽象方法来实现抽象。

```python
from abc import ABC, abstractmethod

class Shape(ABC):
    @abstractmethod
    def area(self):
        pass

    @abstractmethod
    def perimeter(self):
        pass

class Rectangle(Shape):
    def __init__(self, width, height):
        self.width = width
        self.height = height

    def area(self):
        return self.width * self.height

    def perimeter(self):
        return 2 * (self.width + self.height)
```

抽象类不能被直接实例化，必须通过子类实现所有抽象方法。

## 12. 继承（Inheritance）

继承允许一个类（子类）获取另一个类（父类）的属性和方法。

```python
class Animal:
    def __init__(self, name):
        self.name = name

    def speak(self):
        pass

class Dog(Animal):
    def speak(self):
        return f"{self.name}汪汪叫！"

class Cat(Animal):
    def speak(self):
        return f"{self.name}喵喵叫！"
```

### 使用继承

```python
dog = Dog("小黑")
cat = Cat("咪咪")

print(dog.speak())  # 输出：小黑汪汪叫！
print(cat.speak())  # 输出：咪咪喵喵叫！
```

## 13. 多态（Polymorphism）

多态允许不同类的对象对相同消息（方法调用）做出不同响应。

### 简单示例

```python
def animal_sound(animal):
    return animal.speak()

dog = Dog("小黑")
cat = Cat("咪咪")

print(animal_sound(dog))  # 输出：小黑汪汪叫！
print(animal_sound(cat))  # 输出：咪咪喵喵叫！
```

### 重构解决方案

在更复杂的场景中，可以使用更多面向对象的设计原则来利用多态：

```python
from abc import ABC, abstractmethod

class PaymentMethod(ABC):
    @abstractmethod
    def process_payment(self, amount):
        pass

class CreditCard(PaymentMethod):
    def process_payment(self, amount):
        return f"使用信用卡支付{amount}元"

class PayPal(PaymentMethod):
    def process_payment(self, amount):
        return f"使用PayPal支付{amount}元"

class AliPay(PaymentMethod):
    def process_payment(self, amount):
        return f"使用支付宝支付{amount}元"

def make_payment(payment_method, amount):
    return payment_method.process_payment(amount)
```

多态使我们可以编写更灵活、可扩展的代码，通过遵循"对接口编程，而非实现"的原则，可以在不修改现有代码的情况下添加新功能。
