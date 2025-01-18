# Ola.Commands.Variables

**Ola.Commands.Variables** contains commands for creating and managing variables within Open Ledger Automation (OLA). These commands enable users to create, modify, and work with variables in their OLA scripts, providing a way to store and manipulate data.

## Features
- **Variable Creation**: Commands to create variables of different types, such as integers and decimals.
- **Variable Management**: Commands to set values of variables, allowing dynamic manipulation of data during script execution.

## Commands
- **CreateIntegerCommand**: Creates a new integer variable with an initial value of 0.
- **CreateDecimalCommand**: Creates a new decimal variable with an initial value of 0.0.
- **SetCommand**: Sets the value of a variable, allowing users to modify its value as needed during script execution.

## Dependencies
- **Ola.Commands.Core**: Implements the `ICommand` interface for each variable management command.

## Project Structure
This project is focused on providing commands to manage variables in OLA scripts. It allows users to create and manipulate data, enabling complex workflows and calculations within the script.

## How to Use
- Variable commands are used to create and modify variables in OLA scripts.
- Example usage in a script:
  ```
  CREATE INTEGER AS counter
  SET counter TO 5
  CREATE DECIMAL AS amount
  SET amount TO 100.5
  PRINT counter
  PRINT amount
  ```

## How to Contribute
If you are adding new variable-related commands, ensure they provide meaningful functionality for managing data. Commands should handle both integers and decimals and be consistent with the existing command structure.

Feel free to open issues or submit pull requests to propose enhancements or bug fixes.

