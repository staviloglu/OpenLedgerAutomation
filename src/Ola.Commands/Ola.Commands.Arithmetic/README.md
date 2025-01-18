# Ola.Commands.Arithmetic

**Ola.Commands.Arithmetic** contains all arithmetic-related commands for Open Ledger Automation (OLA). These commands allow users to perform arithmetic operations on variables within their OLA scripts.

## Features
- **Basic Arithmetic Operations**: Perform addition, subtraction, multiplication, and division on variables.
- **Increment and Decrement**: Quickly increase or decrease variable values by 1.

## Commands
- **AddCommand**: Adds two variables or values and stores the result in a target variable.
- **SubtractCommand**: Subtracts one value from another and stores the result.
- **MultiplyCommand**: Multiplies two values and stores the product.
- **DivideCommand**: Divides one value by another and stores the quotient.
- **IncrementCommand**: Increases the value of a variable by 1.
- **DecrementCommand**: Decreases the value of a variable by 1.

## Dependencies
- **Ola.Commands.Core**: Implements the `ICommand` interface for each arithmetic command.

## Project Structure
This project groups all arithmetic-related commands, allowing developers to extend or modify arithmetic operations independently from other parts of OLA.

## How to Use
- Arithmetic commands are used to manipulate numeric variables within OLA scripts.
- Example usage in a script:
  ```
  CREATE DECIMAL AS var1
  SET var1 TO 10.5
  CREATE DECIMAL AS var2
  SET var2 TO 2.5
  ADD var1 AND var2 AS result
  PRINT result
  ```

## How to Contribute
If you are adding new arithmetic commands, please ensure consistency in the way the commands are defined and executed. New commands should support both integer and decimal values where applicable.

Feel free to open issues or submit pull requests to propose enhancements or bug fixes.

