using Ola.Commands.Core;
using System.Text.RegularExpressions;


namespace Ola.Commands.Banking
{
    public class CreateAccountCommand : ICommand
    {
        private const string RegexPattern = @"^CREATE ACCOUNT AS (\w+)$";

        private readonly CommandContext _context;

        public CreateAccountCommand(CommandContext context)
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
                string variableName = match.Groups[1].Value;

                try
                {
                    var newAccount = await _context.BankingService.CreateAccount();

                    _context.Variables[variableName] = newAccount;

                    Console.WriteLine($"SUCCESS: Created account with IBAN {newAccount.Iban} and stored in variable {variableName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }

            return lineIndex + 1;
        }
    }

}