# Open Ledger Automation (OLA)

**Open Ledger Automation (OLA)** is a specialized scripting language I designed to **automate banking and financial operations**. With OLA, users can create, manage, and execute various banking tasks through simple, easy-to-understand scripts—such as transferring money, managing accounts, and automating financial workflows via open banking APIs or custom implementations.

Behind the scenes, **“OLA” also happens to be the initials of my newborn triplets: Oğuz, Levent, and Alper**—a personal touch that reflects the hope and promise of this language to grow and evolve, just like they will.


## Features
- **Automated Financial Transactions**: Easily automate tasks like transferring money between accounts.
- **Custom Banking Integrations**: Support for different banking service implementations, including mock banking services and potential integration with open banking APIs.
- **Rich Command Set**: Includes commands for arithmetic operations, account management, control flow, and more.
- **Simple Script Syntax**: Designed for non-technical users such as accountants, making it accessible to those without programming backgrounds.

## Project Structure
The OLA project consists of several components to provide modularity and extensibility:
- [Ola.Console](./src/Ola.Console): The main console application that runs `.ola` scripts. You can use it via the command line, e.g., `ola run Samples\all-instructions.ola`.
- [Ola.Core](./src/Ola.Core): Contains the core interpreter responsible for reading, interpreting, and executing OLA scripts.
- [Ola.Banking.Core](./src/Ola.Banking/Ola.Banking.Core): Defines the interfaces for banking services to interact with various banking systems.
- [Ola.Banking.Mock](./src/Ola.Banking/Ola.Banking.Mock): Provides a mock implementation of banking services for testing and development.
- [Ola.Commands](./src/Ola.Commands): Divided into several command libraries, each providing a specific set of instructions, including arithmetic, control flow, banking operations, utilities, and variable management.


## Getting Started

1. Clone the Repository
   Clone this project to your local machine
2. Open and Run in Visual Studio
        Open the .sln file in Visual Studio.
        The startup project is already set to Ola.Console.
        Run the solution. 
        The post-build events take care of moving required files, letting you start experimenting with OLA right away. 
        Visual Studio will automatically copy the required DLLs to the console app’s output folder so you can run sample scripts without extra steps.

If you prefer the command line, build all libraries, then navigate to the Ola.Console output folder.
Copy an Ola.Banking implementation; your own or Ola.Banking.Mock.dll to the Ola.Console output folder.
Copy all command implementations Ola.Commands.XXX.dll to the Ola.Console output folder.
Create a script of your own or try the ones under samples folder.

Run a script
```sh
   ola run <script.ola>
```

Test a script
```sh
   ola test <script.ola>
```

That’s it!  If you have questions or run into issues, feel free to open an issue or pull request.

## Example Script
Below is an example of an OLA script:
```ola
CREATE ACCOUNT AS myAccount
GET BALANCE FOR myAccount AS balance
IF balance < 1000 THEN
    TRANSFER 500 FROM savingsAccount TO myAccount
ENDIF
PRINT "Account balance is sufficient."
```
This script creates an account, checks if its balance is below 1000, and if so, transfers money from a savings account to ensure it has sufficient funds.

## License and Usage
I created OLA as a proof-of-concept to explore new ways for users to interact with finance applications through a simple scripting language instead of traditional UIs. 
I encourage you to experiment with OLA in personal and educational contexts to see what’s possible. 

However, if you plan to use OLA for commercial purposes or in a production environment, please reach out to me, Sinan TAVILOGLU, at staviloglu@gmail.com 
so we can discuss licensing options and permissions.

## Contributing
We welcome contributions to the project! If you would like to contribute:
1. Fork the repository.
2. Make your changes and add tests if applicable.
3. Submit a pull request with a detailed description of the changes.

Please make sure your changes do not break existing functionality and are thoroughly tested.

## Disclaimer
This project is in a proof-of-concept phase. It is not yet production-ready and should not be used in critical environments without proper testing and validation.

Thank you for your interest in **Open Ledger Automation (OLA)**! We hope it helps you simplify your financial automation tasks.

