using Ola.Banking.Core;
using System.Transactions;

namespace Ola.Banking.Mock
{
    public class MockBankingService : IBankingService
    {
        private Dictionary<string, Account> _accounts = new Dictionary<string, Account>
        {
            { "TR690006235637412755554983", new Account{ Balance=1000M, Type = "PER", Iban = "TR690006235637412755554983", Currency = "TRY", Name = "ANA HESAP" } },
            { "TR910006227111776198728537", new Account{ Balance=500M, Type = "PER", Iban = "TR910006227111776198728537", Currency = "TRY", Name = "" } },
            { "TR650006227395216767759513", new Account{ Balance=300M, Type = "PER", Iban = "TR650006227395216767759513", Currency = "TRY", Name = "" } }
        };

        public Task Transfer(decimal amount, string fromIban, string toIban)
        {
            if (!_accounts.ContainsKey(fromIban)) throw new Exception($"Account with identifier {fromIban} not found.");

            if (!_accounts.ContainsKey(toIban)) throw new Exception($"Account with identifier {toIban} not found.");

            if (_accounts[fromIban].Balance < amount) throw new Exception("Insufficient funds.");

            _accounts[fromIban].Balance -= amount;
            _accounts[toIban].Balance += amount;

            return Task.CompletedTask;
        }

        public Task<Account> CreateAccount()
        {
            var random = new Random();
            var variableDigits = new string[16];

            for (int i = 0; i < variableDigits.Length; i++)
            {
                variableDigits[i] = random.Next(0, 10).ToString();
            }

            string newIban = "TR69000623" + string.Join("", variableDigits);

            var newAccount = new Account { Balance = 0M, Currency = "TRY", Iban = newIban, Name = "", Type = "PER" };
            _accounts.Add(newIban, newAccount);

            return Task.FromResult(newAccount);
        }

        public Task<decimal> GetBalance(string iban)
        {
            if (!_accounts.ContainsKey(iban)) throw new Exception($"Account with identifier {iban} not found.");

            return Task.FromResult(_accounts[iban].Balance);
        }

        public void PrintAccounts()
        {
            foreach (var accountItem in _accounts)
            {
                Console.WriteLine(accountItem.Value);
            }
        }

        public Task<List<Account>> GetAccounts()
        {
            return Task.FromResult(_accounts.Values.ToList());
        }

        public Task<List<Transaction>> GetTransactions(string iban)
        {
            throw new NotImplementedException();
        }
    }
}