using Ola.Banking.Core;
using Ola.Commands.Core;
using System.Text.RegularExpressions;

namespace Ola.Commands.Banking
{
    public class TransferCommand : ICommand
    {
        private const string RegexPattern = @"^TRANSFER (\d+(\.\d+)?) FROM (\w+) TO (\w+)$";

        private readonly CommandContext _context;

        public TransferCommand(CommandContext context)
        {
            _context = context;
        }

        public bool CanExecute(string command) => Regex.IsMatch(command, RegexPattern);

        public async Task<int> Execute(int lineIndex, string[] commands)
        {
            var command = commands[lineIndex];

            var match = Regex.Match(command, RegexPattern);

            if (match.Success)
            {
                decimal amount = decimal.Parse(match.Groups[1].Value);
                string fromAccount = GetVariableValue(match.Groups[3].Value);
                string toAccount = GetVariableValue(match.Groups[4].Value);

                try
                {
                    await _context.BankingService.Transfer(amount, fromAccount, toAccount);

                    Console.WriteLine($"SUCCESS: Transferred {amount:F} from {fromAccount} to {toAccount}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }

            return lineIndex + 1;
        }

        private string GetVariableValue(string input)
        {
            if (_context.Variables.ContainsKey(input) && _context.Variables[input] is Account account)
            {
                return account.Iban;
            }
            return input;
        }
    }

}