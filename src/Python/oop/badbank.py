# /// script
# requires-python = ">=3.11"
# dependencies = []
# ///


class badbank:  # 不好的实践：类名没有使用驼峰命名法
    balance = 0  # 不好的实践：使用公开的类变量存储余额
    accountNum = "123"  # 不好的实践：使用驼峰命名变量
    user_name = ""  # 混合使用不同的命名风格

    def __init__(self, name):  # 不好的实践：缺少类型提示
        self.user_name = name
        # 不好的实践：没有参数验证

    def Deposit(self, money):  # 不好的实践：方法名使用大写
        # 不好的实践：直接修改类变量
        badbank.balance = badbank.balance + money

    def withdraw(self, money):  # 不好的实践：不一致的方法命名风格
        # 不好的实践：没有余额检查
        badbank.balance = badbank.balance - money

    def show(self):  # 不好的实践：方法名不清晰
        # 不好的实践：直接打印而不是返回值
        print(f"账户 {self.accountNum} 余额是 {badbank.balance}")

    @staticmethod
    def interest(b, y):  # 不好的实践：参数名不清晰
        # 不好的实践：魔法数字
        return b * 0.0368 * y


def main() -> None:
    # 测试 badbank 类
    # 不好的实践：没有异常处理
    b1 = badbank("张三")
    b2 = badbank("李四")

    # 不好的实践：直接访问类变量
    print(f"初始余额: {badbank.balance}")

    # 不好的实践：不同实例共享余额
    b1.Deposit(100)
    print(f"张三存款后余额: {badbank.balance}")

    b2.Deposit(50)
    print(f"李四存款后余额: {badbank.balance}")

    # 不好的实践：可以随意取款，没有余额检查
    b1.withdraw(1000)
    print(f"张三取款后余额: {badbank.balance}")

    # 不好的实践：不一致的方法调用风格
    b1.show()
    b2.show()

    # 不好的实践：静态方法参数不明确
    print(f"利息: {badbank.interest(100, 2)}")


if __name__ == "__main__":
    main()
