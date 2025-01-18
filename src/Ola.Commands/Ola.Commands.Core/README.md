# Ola.Commands.Core

**Ola.Commands.Core** provides the core components and interfaces for defining commands in Open Ledger Automation (OLA). It includes the basic building blocks needed to implement OLA commands and ensures consistency across different command types.

## Features
- **ICommand Interface**: Defines the standard interface for all OLA commands, ensuring consistency in execution.
- **Command Patterns**: Provides utility methods and common patterns used across all commands to reduce duplication and simplify development.

## Key Interfaces
- **ICommand**: The primary interface that all commands must implement. It includes methods such as:
  - `bool CanExecute(string command)`: Determines if the command can execute the given script line.
  - `Task<int> Execute(int lineIndex, string[] commands)`: Executes the command and returns the next line to be executed.

## Dependencies
- No external dependencies.

## Project Structure
This project serves as the foundation for all OLA commands. It defines the interfaces and basic utilities that every command implementation relies upon, making sure they are interoperable.

## How to Use
- **ICommand** is implemented by all command classes in OLA, providing a standardized way of adding new commands.
- Developers can create new commands by implementing the `ICommand` interface and ensuring consistency with existing commands.

## How to Contribute
If you are adding new features or modifying existing functionality in **Ola.Commands.Core**, please ensure that changes are backward-compatible and maintain consistency across all commands. Proper documentation and thorough testing are required for new additions.

Feel free to open issues or submit pull requests to propose enhancements or bug fixes.

