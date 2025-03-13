# 检查 uv 是否已安装
if (-not (Get-Command uv -ErrorAction SilentlyContinue)) {
    Write-Host "uv 未安装，正在尝试安装..."
    Invoke-WebRequest -Uri https://astral.sh/uv/install.ps1 -OutFile install.ps1; ./install.ps1
    Remove-Item install.ps1

    # 确保环境变量生效
    $env:Path = [System.Environment]::GetEnvironmentVariable("Path","User") + ";" + [System.Environment]::GetEnvironmentVariable("Path","Machine")
}

# 创建虚拟环境（如果不存在）
if (-not (Test-Path ".venv")) {
    Write-Host "创建虚拟环境..."
    uv venv .venv
}

# 激活虚拟环境
Write-Host "激活虚拟环境..."
.\.venv\Scripts\Activate.ps1

# 安装依赖
Write-Host "安装项目依赖..."
# 首先安装构建工具
uv pip install --upgrade pip setuptools wheel hatchling

# 检查项目结构
Write-Host "检查项目结构..."
python -c "import os; os.makedirs('scripts', exist_ok=True)" 2>$null
python scripts/fix_paths.py
if (-not $?) {
    Write-Host "项目结构检查失败，但继续安装..."
}

# 然后开发模式安装项目
Write-Host "安装项目..."
uv pip install -e .
if (-not $?) {
    Write-Host "常规安装失败，尝试直接安装依赖..."
    uv pip install -r requirements.txt
}

Write-Host "uv 环境已准备就绪！"
Write-Host "运行 'uvicorn app.main:app --reload --host 0.0.0.0 --port 8000' 启动服务器"
