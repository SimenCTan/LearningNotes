#!/bin/bash

# 检查 uv 是否已安装
if ! command -v uv &> /dev/null; then
    echo "uv 未安装，正在尝试安装..."
    curl -LsSf https://astral.sh/uv/install.sh | sh
    # 确保 uv 在路径中
    export PATH="$HOME/.cargo/bin:$PATH"
fi

# 创建虚拟环境（如果不存在）
if [ ! -d ".venv" ]; then
    echo "创建虚拟环境..."
    uv venv .venv
fi

# 激活虚拟环境
echo "激活虚拟环境..."
source .venv/bin/activate

# 安装依赖
echo "安装项目依赖..."
# 首先安装构建工具
uv pip install --upgrade pip setuptools wheel hatchling

# 检查项目结构
echo "检查项目结构..."
python -c "import os; os.makedirs('scripts', exist_ok=True)" 2>/dev/null || true
python scripts/fix_paths.py || echo "项目结构检查失败，但继续安装..."

# 然后开发模式安装项目
echo "安装项目..."
uv pip install -e . || {
    echo "常规安装失败，尝试直接安装依赖..."
    uv pip install -r requirements.txt
}

echo "uv 环境已准备就绪！"
echo "运行 'uvicorn app.main:app --reload --host 0.0.0.0 --port 8000' 启动服务器"
