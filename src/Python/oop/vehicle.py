# /// script
# requires-python = ">=3.11"
# dependencies = []
# ///


class Vehicle:
    """车辆基类：定义基本属性和方法"""

    def __init__(self, brand: str, model: str, year: int):
        """
        初始化车辆。

        参数:
            brand: 品牌
            model: 型号
            year: 年份
        """
        self._brand = brand
        self._model = model
        self._year = year
        self._is_running = False
        self._speed = 0.0
        self._max_speed = 120.0  # 默认最大速度

    def start_engine(self) -> None:
        """启动引擎"""
        if not self._is_running:
            self._is_running = True
            print(f"{self._brand} {self._model} 引擎启动")
        else:
            print("引擎已经在运行中")

    def stop_engine(self) -> None:
        """停止引擎"""
        if self._is_running:
            self._is_running = False
            self._speed = 0.0
            print(f"{self._brand} {self._model} 引擎停止")
        else:
            print("引擎已经停止")

    def accelerate(self, speed_increase: float) -> None:
        """加速"""
        if self._is_running:
            self._speed = min(self._max_speed, self._speed + speed_increase)
            print(f"加速至 {self._speed:.1f} km/h")
        else:
            print("请先启动引擎")

    def brake(self, speed_decrease: float) -> None:
        """刹车"""
        if self._speed > 0:
            self._speed = max(0, self._speed - speed_decrease)
            print(f"当前速度: {self._speed:.1f} km/h")
        else:
            print("车辆已经停止")

    def display_info(self) -> None:
        """显示车辆信息"""
        print(f"\n车辆信息:")
        print(f"品牌: {self._brand}")
        print(f"型号: {self._model}")
        print(f"年份: {self._year}")
        print(f"当前速度: {self._speed:.1f} km/h")
        print(f"发动机状态: {'运行中' if self._is_running else '已停止'}")


class Car(Vehicle):
    """汽车类"""

    def __init__(self, brand: str, model: str, year: int, doors: int = 4):
        """初始化汽车"""
        super().__init__(brand, model, year)
        self._doors = doors
        self._max_speed = 200.0  # 汽车最大速度
        self._is_ac_on = False

    def accelerate(self, speed_increase: float) -> None:
        """重写加速方法"""
        if self._is_running:
            self._speed = min(self._max_speed, self._speed + speed_increase)
            print(f"汽车加速至 {self._speed:.1f} km/h")
        else:
            print("请先启动引擎")

    def toggle_ac(self) -> None:
        """开关空调"""
        self._is_ac_on = not self._is_ac_on
        print(f"空调已{'开启' if self._is_ac_on else '关闭'}")

    def display_info(self) -> None:
        """重写显示信息方法"""
        super().display_info()
        print(f"车门数: {self._doors}")
        print(f"空调状态: {'开启' if self._is_ac_on else '关闭'}")


class Motorcycle(Vehicle):
    """摩托车类"""

    def __init__(self, brand: str, model: str, year: int, has_sidecar: bool = False):
        """初始化摩托车"""
        super().__init__(brand, model, year)
        self._has_sidecar = has_sidecar
        self._max_speed = 180.0  # 摩托车最大速度

    def accelerate(self, speed_increase: float) -> None:
        """重写加速方法"""
        if self._is_running:
            self._speed = min(self._max_speed, self._speed + speed_increase)
            print(f"摩托车加速至 {self._speed:.1f} km/h")
        else:
            print("请先启动引擎")

    def wheelie(self) -> None:
        """特有方法：前轮离地"""
        if self._is_running and self._speed > 20:
            print("前轮离地！")
        else:
            print("速度不够，无法前轮离地")

    def display_info(self) -> None:
        """重写显示信息方法"""
        super().display_info()
        print(f"边车: {'有' if self._has_sidecar else '无'}")


def main() -> None:
    # 创建不同类型的车辆
    vehicles: list[Vehicle] = [
        Car("特斯拉", "Model 3", 2023),
        Car("比亚迪", "汉", 2023, doors=4),
        Motorcycle("杜卡迪", "Monster", 2023),
        Motorcycle("宝马", "R1250GS", 2023, has_sidecar=True)
    ]

    # 统一处理所有车辆
    print("测试所有车辆：")
    for i, vehicle in enumerate(vehicles, 1):
        print(f"\n=== 车辆 {i} ===")
        vehicle.start_engine()
        vehicle.accelerate(40)
        vehicle.display_info()
        vehicle.brake(20)
        vehicle.stop_engine()

        # 根据类型调用特殊方法
        if isinstance(vehicle, Car):
            vehicle.toggle_ac()
        elif isinstance(vehicle, Motorcycle):
            vehicle.wheelie()


if __name__ == "__main__":
    main()
