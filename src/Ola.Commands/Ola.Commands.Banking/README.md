# Ola.Commands.Banking

**Ola.Commands.Banking** contains all banking-related commands for Open Ledger Automation (OLA). These commands allow users to perform operations like creating accounts, transferring funds, and retrieving balances.

## Features
- **Account Creation**: Create new accounts and store their details in variables.
- **Funds Transfer**: Transfer money between accounts using simple OLA commands.
- **Balance Inquiry**: Retrieve and store the balance of an account for further operations.

## Commands
- **CreateAccountCommand**: Creates a new bank account and stores the account information in a variable.
- **TransferCommand**: Transfers funds from one account to another.
- **GetBalanceCommand**: Retrieves the balance of a specified account and stores it in a variable.

## Dependencies
- **Ola.Commands.Core**: Implements the `ICommand` interface for each banking command.
- **Ola.Banking.Core**: Uses the banking interfaces and models (`IBankingService`, `Account`) to perform banking operations.

## Project Structure
This project is dedicated to banking-related commands, which allow users to automate financial workflows and interact with banking services within their OLA scripts.

## How to Use
- Banking commands are used to interact with accounts within OLA scripts.
- Example usage in a script:
  ```
  CREATE ACCOUNT AS account1
  GET BALANCE FOR account1 AS balance1
  PRINT balance1
  TRANSFER 100 FROM account1 TO account2
  ```

## How to Contribute
If you are adding new banking commands, ensure they align with standard banking procedures and maintain security best practices. All new commands should integrate well with the existing `IBankingService` interface.

Feel free to open issues or submit pull requests to propose enhancements or bug fixes.

