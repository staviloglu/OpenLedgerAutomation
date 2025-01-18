# Ola.Console

**Ola.Console** is the command-line interface (CLI) project for Open Ledger Automation (OLA). It provides the main entry point for users to execute OLA scripts and interact with the OLA language via the command line.

## Features
- **Run OLA Scripts**: Execute `.ola` scripts to automate financial operations and workflows.
- **Test OLA Scripts**: Validate scripts to identify syntax errors before executing them.

## Usage
- To run an OLA script:
  ```
  ola run <script.ola>
  ```
- To test an OLA script for syntax errors without running it:
  ```
  ola test <script.ola>
  ```

## Dependencies
- **Ola.Core**: Provides the core interpreter for executing scripts.
- **Ola.Banking.Core**: Defines the banking interfaces used for financial operations.
- **Ola.Commands**: Includes various command libraries that provide functionalities for arithmetic, control flow, banking, utilities, and variable management.

## Project Structure
This project serves as the entry point for executing OLA scripts from the command line. It relies on other projects, such as `Ola.Core` and command libraries, to interpret and execute the commands defined in a script.

## How to Contribute
If you wish to contribute to **Ola.Console**, please ensure that any changes made maintain compatibility with existing command libraries and core interpreter functionality. All new features should be thoroughly tested.

Feel free to open issues or submit pull requests to propose enhancements or bug fixes.

