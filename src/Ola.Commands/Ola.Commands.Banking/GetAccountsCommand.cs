using Ola.Commands.Core;
using System.Text.RegularExpressions;

namespace Ola.Commands.Banking
{
    public class GetAccountsCommand : ICommand
    {
        private const string RegexPattern = @"^GET ACCOUNTS AS (\w+)$";

        private readonly CommandContext _context;

        public GetAccountsCommand(CommandContext context)
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
                    var accounts = await _context.BankingService.GetAccounts();

                    _context.Variables[variableName] = accounts;

                    Console.WriteLine($"SUCCESS: Retrieved the list of accounts and stored in variable {variableName}");
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