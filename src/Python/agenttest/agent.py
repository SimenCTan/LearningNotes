# /// script
# requires-python = ">=3.11"
# dependencies = [
#     "openai-agents",
# ]
# ///
from agents import Agent, Runner

# Code within the code,
# Functions calling themselves,
# Infinite loop's dance.

def main() -> None:
    agent = Agent(name="Assistant", instructions="You are a helpful assistant")

    result = Runner.run_sync(agent, "Write a haiku about recursion in programming.")
    print(result.final_output)
    print("Hello from agent.py!")


if __name__ == "__main__":
    main()
