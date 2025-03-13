# Agent API

基于 FastAPI 构建的 AI 代理 API 服务。

## 功能特点

- 基于 FastAPI 构建的高性能 API
- 支持多种 AI 模型集成
- 完整的数据模型和请求/响应架构
- CORS 支持，可以从多种前端访问
- 使用 uv 进行现代化的依赖管理
- VSCode 友好的调试配置

## 安装与运行

### 使用 uv（推荐）

[uv](https://github.com/astral-sh/uv) 是一个快速的 Python 包管理器和虚拟环境工具，由 Rust 编写。

#### Linux/macOS

```bash
# 一键设置环境
bash activate_uv_env.sh

# 手动设置
# 1. 安装 uv
curl -LsSf https://astral.sh/uv/install.sh | sh

# 2. 创建虚拟环境
uv venv .venv

# 3. 激活虚拟环境
source .venv/bin/activate

# 4. 安装依赖
uv pip install -e .
```

#### Windows (PowerShell)

```powershell
# 一键设置环境
.\activate_uv_env.ps1

# 手动设置
# 1. 安装 uv
Invoke-WebRequest -Uri https://astral.sh/uv/install.ps1 -OutFile install.ps1; ./install.ps1

# 2. 创建虚拟环境
uv venv .venv

# 3. 激活虚拟环境
.\.venv\Scripts\Activate.ps1

# 4. 安装依赖
uv pip install -e .
```

### 使用传统的 pip（备选）

```bash
# 创建虚拟环境
python -m venv .venv

# 激活虚拟环境
# Linux/macOS
source .venv/bin/activate
# Windows
.\.venv\Scripts\activate

# 安装依赖
pip install -r requirements.txt
```

### 运行开发服务器

```bash
# 确保你在激活的虚拟环境中
uvicorn app.main:app --reload --host 0.0.0.0 --port 8000
```

## 使用 VSCode 进行开发

本项目包含完整的 VSCode 配置，使开发和调试变得简单。

### 调试配置

打开项目后，VSCode 将自动加载调试配置。可以使用以下调试选项：

1. **FastAPI: 主应用** - 启动带有热重载的主应用服务器
2. **FastAPI: 调试端点** - 带有详细日志的调试模式
3. **Python: 当前文件** - 调试当前打开的文件
4. **Python: 修复路径脚本** - 运行项目结构修复脚本

### 使用方法

1. 在 VSCode 中打开调试面板（或按 F5）
2. 从下拉菜单中选择调试配置
3. 点击绿色的播放按钮启动调试会话
4. 设置断点，检查变量，步进代码

### 快捷任务

使用 VSCode 任务（Ctrl+Shift+P 然后选择"Tasks: Run Task"）：

- **启动 FastAPI 服务器** - 启动开发服务器
- **安装依赖** - 运行环境设置脚本
- **运行测试** - 执行测试套件
- **格式化代码** - 使用 Black 格式化代码

## API 文档

启动服务器后，可以访问以下地址查看自动生成的 API 文档：

- Swagger UI: <http://localhost:8000/docs>
- ReDoc: <http://localhost:8000/redoc>

## API 端点

- `/api/agent/generate`: 生成 AI 响应
- `/api/agent/models`: 列出可用的 AI 模型
- `/health`: 健康检查

## 开发指南

### 使用 uv 进行依赖管理

```bash
# 添加新依赖
uv pip install package_name

# 添加开发依赖
uv pip install --dev package_name

# 更新所有依赖
uv pip sync .
```

## 项目结构

```
agentapi/
│
├── .uv/                    # uv 特定配置
├── .venv/                  # 虚拟环境（自动创建）
├── .vscode/                # VSCode 配置
│   ├── launch.json         # 调试配置
│   ├── settings.json       # 编辑器设置
│   └── tasks.json          # 任务定义
├── app/                    # 应用程序包
│   ├── api/                # API 相关代码
│   │   ├── endpoints/      # API 端点
│   │   │   └── agent.py    # 代理相关端点
│   │   └── api.py          # API 路由
│   │
│   ├── core/               # 核心功能
│   │   └── config.py       # 配置
│   │
│   ├── db/                 # 数据库相关
│   │
│   ├── models/             # 数据模型
│   │   └── agent_model.py  # 代理模型
│   │
│   ├── schemas/            # 请求/响应模式
│   │   └── agent.py        # 代理相关模式
│   │
│   └── main.py             # 应用入口
│
├── scripts/                # 辅助脚本
│   └── fix_paths.py        # 路径修复脚本
│
├── activate_uv_env.sh      # Linux/macOS uv 环境激活脚本
├── activate_uv_env.ps1     # Windows uv 环境激活脚本
├── pyproject.toml          # 项目配置和依赖
├── setup.py                # 兼容性安装脚本
├── requirements.txt        # 传统依赖文件（兼容性保留）
└── README.md               # 项目说明
```

## 环境变量

可以通过 `.env` 文件或环境变量配置以下选项：

- `API_KEY`: API 密钥
- `OPENAI_API_KEY`: OpenAI API 密钥（用于 AI 模型调用）
- `PORT`: 服务端口
- `DEFAULT_MODEL`: 默认 AI 模型

### 配置 OpenAI API 密钥

有三种方式配置 OpenAI API 密钥：

1. **环境变量**：设置 `OPENAI_API_KEY` 环境变量

   ```bash
   # Linux/macOS
   export OPENAI_API_KEY="your-api-key"

   # Windows PowerShell
   $env:OPENAI_API_KEY="your-api-key"

   # Windows CMD
   set OPENAI_API_KEY=your-api-key
   ```

2. **.env 文件**：在项目根目录创建 `.env` 文件

   ```
   OPENAI_API_KEY=your-api-key
   ```

3. **请求参数**：在 API 调用时通过参数传递

   ```json
   {
     "prompt": "Hello, AI",
     "api_key": "your-api-key"
   }
   ```

4. **请求头**：在 HTTP 请求头中设置 `X-API-Key`

   ```
   X-API-Key: your-api-key
   ```
