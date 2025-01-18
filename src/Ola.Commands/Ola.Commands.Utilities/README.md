# Ola.Commands.Utilities

**Ola.Commands.Utilities** contains utility commands for Open Ledger Automation (OLA). These commands serve general-purpose functions that are useful for providing output or assisting with debugging within OLA scripts.

## Features
- **Print Output**: Commands to print messages or variable values to the console, enabling debugging and providing feedback during script execution.

## Commands
- **PrintCommand**: Prints specified text or the value of a variable to the console. This is useful for understanding the flow of the script and for debugging purposes.

## Dependencies
- **Ola.Commands.Core**: Implements the `ICommand` interface for each utility command.

## Project Structure
This project is focused on providing general-purpose utility commands that are not specific to arithmetic, control flow, or banking but are still essential for script interaction and understanding script behavior.

## How to Use
- Utility commands can be used for outputting information or providing visual feedback during the execution of OLA scripts.
- Example usage in a script:
  ```
  CREATE DECIMAL AS amount
  SET amount TO 100.5
  PRINT "The current amount is: "
  PRINT amount
  ```

## How to Contribute
If you are adding new utility commands, ensure they are simple and intuitive for users. Utility commands should improve the user experience by making scripts easier to debug or understand.

Feel free to open issues or submit pull requests to propose enhancements or bug fixes.

