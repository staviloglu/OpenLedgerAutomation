using System.Transactions;

namespace Ola.Banking.Core
{
    public interface IBankingService
    {
        void PrintAccounts();

        // Payment Initiation API
        Task Transfer(decimal amount, string fromIban, string toIban);

        // Account Information API
        Task<Account> CreateAccount();
        Task<decimal> GetBalance(string iban);
        Task<List<Account>> GetAccounts();

        // Transaction History API
        Task<List<Transaction>> GetTransactions(string iban);
    }
}