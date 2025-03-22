# /// script
# requires-python = ">=3.11"
# dependencies = []
# ///
from abc import ABC, abstractmethod


class Account(ABC):
    @abstractmethod
    def deposit(self, amount: float) -> bool:
        """存款操作。"""
        pass

    @abstractmethod
    def withdraw(self, amount: float) -> bool:
        """取款操作。"""
        pass

    @property
    @abstractmethod
    def balance(self) -> float:
        """获取当前余额。"""
        pass

    @abstractmethod
    def display_info(self) -> None:
        """显示账户信息。"""
        pass

class BankAccount(Account):
    """银行账户类，用于管理账户信息和交易。"""

    # 类变量
    annual_interest_rate = 0.0368
    MIN_BALANCE = 110.0  # 最小余额要求

    def __init__(self, account_number: str, owner_name: str, balance: float = 0.0):
        """
        初始化银行账户。

        参数:
            account_number: 账户号码
            owner_name: 账户所有者姓名
            balance: 初始余额（默认为0.0）
        """
        # 验证账号格式
        if not BankAccount.is_valid_account_number(account_number):
            raise ValueError("无效的账号格式")

        # 验证初始余额是否满足最小余额要求
        if balance < BankAccount.MIN_BALANCE:
            raise ValueError(f"初始余额必须大于最小余额要求（¥{BankAccount.MIN_BALANCE}）")

        self._account_number = account_number
        self._owner_name = owner_name
        self._balance = balance

    @staticmethod
    def is_valid_account_number(account_number: str) -> bool:
        """
        静态方法：验证账号格式是否正确。

        参数:
            account_number: 待验证的账号
        返回:
            bool: 账号格式是否有效
        """
        # 验证账号是否为16位数字
        if not account_number.isdigit() or len(account_number) != 16:
            return False
        # 验证账号是否以622202开头（示例）
        if not account_number.startswith('622202'):
            return False
        return True

    @staticmethod
    def calculate_interest(principal: float, years: float) -> float:
        """
        静态方法：计算存款利息。

        参数:
            principal: 本金
            years: 存款年限
        返回:
            float: 利息金额
        """
        if principal < 0 or years < 0:
            raise ValueError("本金和年限必须大于0")
        return principal * BankAccount.annual_interest_rate * years

    @property
    def balance(self) -> float:
        """获取当前余额。"""
        return self._balance

    def _is_valid_amount(self, amount: float) -> bool:
        """验证存款金额是否有效。"""
        if amount <= 0:
            return False
        return True

    def __log_transaction(self, amount: float, operation: str) -> None:
        """记录交易信息。"""
        print(f"交易成功！{operation}: ¥{amount:.2f}, 当前余额: ¥{self._balance:.2f}")

    def deposit(self, amount: float) -> bool:
        """
        存款操作。

        参数:
            amount: 存款金额
        返回:
            bool: 操作是否成功
        """
        if not self._is_valid_amount(amount):
            print("存款金额必须大于0")
            return False

        self._balance += amount
        self.__log_transaction(amount, "存款")
        return True

    def withdraw(self, amount: float) -> bool:
        """
        取款操作。

        参数:
            amount: 取款金额
        返回:
            bool: 操作是否成功
        """
        if amount <= 0:
            print("取款金额必须大于0")
            return False

        # 检查取款后是否会低于最小余额要求
        if (self._balance - amount) < BankAccount.MIN_BALANCE:
            print(f"取款后余额不能低于最小余额要求（¥{BankAccount.MIN_BALANCE}）")
            return False

        self._balance -= amount
        self.__log_transaction(amount, "取款")
        return True

    def display_info(self) -> None:
        """显示账户信息。"""
        print(f"账号: {self._account_number}, 户主: {self._owner_name}, 余额: ¥{self._balance:.2f}")


def main() -> None:
    try:
        # 创建账户（需要满足最小余额要求）
        account = BankAccount("6222021234567890", "张三", 1000.0)

        # 显示账户信息
        account.display_info()

        # 测试取款（包括最小余额限制）
        print("\n测试取款：")
        account.withdraw(800.0)  # 这会失败，因为会低于最小余额
        account.withdraw(500.0)  # 这会成功

        # 测试存款
        print("\n测试存款：")
        account.deposit(200.0)

        # 显示最终余额
        print(f"\n当前余额: ¥{account.balance:.2f}")

    except ValueError as e:
        print(f"错误：{e}")


if __name__ == "__main__":
    main()
