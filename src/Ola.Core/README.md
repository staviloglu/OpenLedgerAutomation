# Ola.Core

**Ola.Core** is the core interpreter project for Open Ledger Automation (OLA). It is responsible for reading, interpreting, and executing OLA scripts. This project is the backbone of the OLA language, managing command execution and script control flow.

## Features
- **Script Execution**: Executes `.ola` scripts by interpreting commands line by line.
- **CommandRegistry**: Manages available commands and delegates execution to the appropriate command classes.
- **Interpreter Logic**: Implements the main logic for running and testing scripts.

## Key Components
- **OpenLedgerAutomationInterpreter**: The main class responsible for executing OLA scripts, managing variables, and handling the flow of command execution.
- **CommandRegistry**: Maintains a list of supported commands and directs the script to execute commands as needed.

## Dependencies
- **Ola.Banking.Core**: Interfaces for interacting with banking services.
- **Ola.Commands**: Various command libraries that implement the available instructions in OLA scripts, such as arithmetic, control flow, banking, utilities, and variable management.

## Project Structure
This project is the core of the OLA interpreter, providing the fundamental components needed to parse and execute scripts using the various command libraries.

## How to Use
- The `OpenLedgerAutomationInterpreter` is used to execute OLA scripts in collaboration with the command registry.
- Example usage:
  ```csharp
  // Load the appropriate banking service, which could be a mock or an actual implementation
  IBankingService bankingService = LoadBankingService();
  var interpreter = new OpenLedgerAutomationInterpreter(script, bankingService);
  await interpreter.RunScript();
  ```

## How to Contribute
If you are contributing to **Ola.Core**, please ensure that changes do not break the existing script execution flow. Any new features should be thoroughly tested with the supported command sets.

Feel free to open issues or submit pull requests to propose enhancements or bug fixes.

