# /// script
# requires-python = ">=3.11"
# dependencies = []
# ///


class User:
    """用户类，表示系统中的一个用户。"""
    user_count = 0
    def __init__(self, user_id: int, username: str, password: str,
                 email: str = "", is_active: bool = True):
        """
        初始化用户对象。

        参数:
            user_id: 用户ID
            username: 用户名
            email: 用户邮箱 (可选)
            is_active: 用户是否激活 (默认为 True)
        """
        self._user_id = user_id
        self.username = username
        self.password = password
        self._email = email
        self.is_active = is_active
        self._login_attempts = 0
        User.user_count += 1
    def display_info(self) -> None:
        """显示用户信息。"""
        print(f"用户ID: {self._user_id}, 用户名: {self.username}, 邮箱: {self._email}, 状态: {'激活' if self.is_active else '未激活'}")

    @property
    def email(self) -> str:
        """获取用户邮箱。"""
        print("accessing email")
        return self._email

    @email.setter
    def email(self, value: str) -> None:
        """设置用户邮箱。"""
        if "@" not in value:
            raise ValueError("邮箱格式不正确")
        self._email = value

    @property
    def login_attempts(self) -> int:
        """获取登录尝试次数。"""
        return self._login_attempts


def main() -> None:
    # 创建用户实例
    user1 = User(1001, "阿伦", "123456", "aren@example.com")
    user2 = User(1002, "小明", "123456", "xiaoming@example.com")

    user1.display_info()
    user2.display_info()
    print(user1.user_count)
    print(user2.user_count)
    print(User.user_count)


if __name__ == "__main__":
    main()
