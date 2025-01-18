using Ola.Commands.Core;
using System.Text.RegularExpressions;

namespace Ola.Commands.Variables
{
    public class SetCommand : ICommand
    {
        private const string RegexPattern = @"^SET (\w+) TO (\d+(\.\d+)?)$";

        private readonly CommandContext _context;

        public SetCommand(CommandContext context)
        {
            _context = context;
        }

        public bool CanExecute(string command) => Regex.IsMatch(command, RegexPattern);

        public Task<int> Execute(int lineIndex, string[] commands)
        {
            var command = commands[lineIndex];

            var match = Regex.Match(command, RegexPattern);

            if (match.Success)
            {
                string variableName = match.Groups[1].Value;
                string valueStr = match.Groups[2].Value;

                if (_context.Variables.ContainsKey(variableName))
                {
                    if (decimal.TryParse(valueStr, out decimal value))
                    {
                        if (_context.Variables[variableName] is int)
                        {
                            _context.Variables[variableName] = (int)value;
                        }
                        else if (_context.Variables[variableName] is decimal)
                        {
                            _context.Variables[variableName] = value;
                        }
                        Console.WriteLine($"SUCCESS: Set variable '{variableName}' to {value}");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: Value '{valueStr}' is not a valid number.");
                    }
                }
                else
                {
                    Console.WriteLine($"ERROR: Variable '{variableName}' does not exist.");
                }
            }
            return Task.FromResult(lineIndex + 1);
        }
    }
}