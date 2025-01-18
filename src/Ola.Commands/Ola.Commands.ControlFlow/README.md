# Ola.Commands.ControlFlow

**Ola.Commands.ControlFlow** contains all control flow commands for Open Ledger Automation (OLA). These commands allow users to control the execution flow within their scripts, including conditional branching and jumping to specific sections.

## Features
- **Conditional Execution**: Supports `IF...THEN...ENDIF` blocks to execute commands conditionally.
- **Labeling and Jumping**: Use `LABEL` and `GOTO` commands to create loops or jump to specific script locations.

## Commands
- **IfCommand**: Evaluates a condition and executes a block of commands if the condition is met.
- **GotoCommand**: Jumps to a specified label in the script.
- **LabelCommand**: Defines a label that can be referenced by `GOTO` commands.

## Dependencies
- **Ola.Commands.Core**: Implements the `ICommand` interface for each control flow command.

## Project Structure
This project is focused on control flow operations, which allow users to create sophisticated logic by controlling the sequence of commands executed in an OLA script.

## How to Use
- Control flow commands are used to manage the sequence and logic of operations within OLA scripts.
- Example usage in a script:
  ```
  CREATE INTEGER AS counter
  SET counter TO 1
  LABEL start
  PRINT counter
  INCREMENT counter
  IF counter <= 10 THEN
    GOTO start
  ENDIF
  ```

## How to Contribute
If you are adding new control flow commands, ensure they integrate seamlessly with existing control structures and provide consistent behavior. Control flow commands are critical for managing script execution, so thorough testing is essential.

Feel free to open issues or submit pull requests to propose enhancements or bug fixes.

