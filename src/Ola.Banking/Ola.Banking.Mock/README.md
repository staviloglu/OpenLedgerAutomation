# Ola.Banking.Mock

**Ola.Banking.Mock** provides a mock implementation of the `IBankingService` interface defined in **Ola.Banking.Core**. This mock service is useful for testing and development purposes, allowing OLA scripts to interact with simulated banking operations without the need for a real banking system.

## Features
- **Mock Banking Service**: Simulates banking operations, such as creating accounts, transferring funds, and retrieving balances.
- **Predefined Accounts**: Comes with a set of predefined accounts to facilitate quick testing and demonstration.

## Key Components
- **MockBankingService**: Implements the `IBankingService` interface and provides in-memory account management, enabling operations like:
  - **Transfer**: Simulate transferring funds between accounts.
  - **Create Account**: Create new accounts with random IBANs.
  - **Get Balance**: Retrieve the balance of an account.
  - **Get Accounts**: Retrieve a list of all available accounts.

## Dependencies
- **Ola.Banking.Core**: Implements the core interfaces (`IBankingService`, `Account`) defined in `Ola.Banking.Core`.

## Project Structure
This project is specifically designed for use in testing and development. It provides a mock environment that helps developers test the functionality of OLA scripts without depending on an actual banking API or environment.

## How to Use
- Include **Ola.Banking.Mock** in your development setup to simulate banking operations while testing OLA scripts.
- The mock service includes several predefined accounts, which you can extend or modify as needed.

Example usage:
```csharp
var bankingService = new MockBankingService();
var interpreter = new OpenLedgerAutomationInterpreter(script, bankingService);
await interpreter.RunScript();
```

## How to Contribute
If you are extending **Ola.Banking.Mock**, please ensure that the mock behavior remains consistent with real-world banking scenarios. Contributions should aim to improve the mock's usefulness for testing, such as adding more realistic transaction scenarios or supporting additional banking operations.

Feel free to open issues or submit pull requests for enhancements or bug fixes.

