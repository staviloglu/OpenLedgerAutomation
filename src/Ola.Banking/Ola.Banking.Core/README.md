# Ola.Banking.Core

**Ola.Banking.Core** provides the core banking interfaces and data models for Open Ledger Automation (OLA). It is the foundation for integrating banking services into OLA, allowing commands to interact seamlessly with banking systems.

## Features
- **Banking Interfaces**: Defines the contracts for interacting with banking services, including account management and transactions.
- **Core Data Models**: Defines essential banking entities, such as `Account`, which includes properties like `IBAN`, `balance`, `currency`, and `type`.

## Key Interfaces
- **IBankingService**: The core interface that defines banking operations, such as:
  - `Transfer(decimal amount, string fromIban, string toIban)`: Transfers funds between accounts.
  - `CreateAccount()`: Creates a new bank account.
  - `GetBalance(string iban)`: Retrieves the balance of a specific account.
  - `GetAccounts()`: Retrieves a list of accounts.

- **Account Class**: Represents a bank account with properties like:
  - `IBAN`: The unique identifier for the account.
  - `Balance`: The current balance of the account.
  - `Currency`: The currency type of the account (e.g., "TRY").
  - `Type`: The type of the account (e.g., "personal").
  - `Name`: The name of the account.

## Dependencies
- This project has no external dependencies and is used by other projects, such as `Ola.Banking.Mock` and `Ola.Core`, to provide banking-related functionality.

## Project Structure
This project serves as the core of banking operations and defines the contracts that other implementations, such as mocks or real banking services, must adhere to.

## How to Use
**Ola.Banking.Core** is intended to be implemented by a banking service provider. Developers can create their own implementation of the `IBankingService` interface to connect OLA with actual banking systems.

For testing or demonstration purposes, you can use `Ola.Banking.Mock`, which provides a mock implementation of the banking services defined here.

## How to Contribute
If you are extending the functionality of `Ola.Banking.Core`, please ensure:
- All new features align with open banking standards and industry best practices.
- New methods added to `IBankingService` are properly documented and backward-compatible.

Contributions are welcome to improve or extend the core banking operations provided by OLA. Feel free to open issues or pull requests for discussion.

