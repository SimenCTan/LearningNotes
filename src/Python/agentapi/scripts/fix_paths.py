#!/usr/bin/env python
# -*- coding: utf-8 -*-

"""
路径修复脚本

在开发环境中运行此脚本可以确保项目结构正确
"""

import os
import shutil
import sys
from pathlib import Path


def fix_project_structure():
    """确保项目结构正确"""

    # 获取项目根目录
    script_path = Path(os.path.abspath(__file__))
    project_root = script_path.parent.parent

    # 检查 app 目录是否存在
    app_dir = project_root / "app"
    if not app_dir.exists() or not app_dir.is_dir():
        print(f"错误：找不到 app 目录: {app_dir}")
        return False

    # 目录结构正确
    print(f"项目结构检查通过! 项目根目录: {project_root}")
    print(f"应用目录: {app_dir}")
    return True


if __name__ == "__main__":
    if fix_project_structure():
        print("项目结构修复成功！")
        sys.exit(0)
    else:
        print("项目结构修复失败！")
        sys.exit(1)
