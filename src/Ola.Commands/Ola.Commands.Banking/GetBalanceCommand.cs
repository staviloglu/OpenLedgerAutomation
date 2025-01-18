using Ola.Banking.Core;
using Ola.Commands.Core;
using System.Text.RegularExpressions;

namespace Ola.Commands.Banking
{
    public class GetBalanceCommand : ICommand
    {
        private const string RegexPattern = @"^GET BALANCE OF (\w+)(?:\[(\w+)\])? AS (\w+)";

        private readonly CommandContext _context;

        public GetBalanceCommand(CommandContext context)
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
                string variableOrIban = match.Groups[1].Value;
                string indexVariable = match.Groups[2].Value;
                string variableName = match.Groups[3].Value;

                if (!string.IsNullOrEmpty(indexVariable))
                {
                    int index = 0;

                    if (int.TryParse(indexVariable, out index)) goto HAS_INDEX;

                    if (!_context.Variables.ContainsKey(indexVariable) || !int.TryParse(_context.Variables[indexVariable].ToString(), out index))
                    {
                        Console.WriteLine($"ERROR: Index variable '{indexVariable}' not found or not a valid integer.");
                        return lineIndex + 1;
                    }

                HAS_INDEX:
                    if (_context.Variables[variableOrIban] is not List<Account> accountList)
                    {
                        Console.WriteLine($"ERROR: Variable '{variableOrIban}' is not a valid list of accounts.");
                        return lineIndex + 1;
                    }

                    if (accountList.Count <= index)
                    {
                        Console.WriteLine($"ERROR: Index '{index}' out of range for accounts list '{variableOrIban}'.");
                        return lineIndex + 1;
                    }

                    var accountFromList = accountList[index];
                    _context.Variables[variableName] = accountFromList.Balance;
                    Console.WriteLine($"SUCCESS: Retrieved balance for {variableOrIban}[{index}] and stored in variable '{variableName}'");
                    return lineIndex + 1;
                }

                if (_context.Variables.ContainsKey(variableOrIban) && _context.Variables[variableOrIban] is Account account)
                {
                    _context.Variables[variableName] = account.Balance;
                    Console.WriteLine($"SUCCESS: Retrieved balance for {variableOrIban} and stored in variable '{variableName}'");
                    return lineIndex + 1;
                }

                string iban;

                if (_context.Variables.ContainsKey(variableOrIban) && _context.Variables[variableOrIban] is string ibanString)
                {
                    iban = ibanString;
                }
                else
                {
                    iban = variableOrIban; // Assume it's an IBAN directly provided.
                }

                try
                {
                    var balance = await _context.BankingService.GetBalance(iban);
                    _context.Variables[variableName] = balance;
                    Console.WriteLine($"SUCCESS: Retrieved balance for {iban} and stored in variable '{variableName}'");
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