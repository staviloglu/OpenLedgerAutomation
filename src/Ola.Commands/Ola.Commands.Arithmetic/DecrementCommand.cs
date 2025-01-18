using Ola.Commands.Core;
using System.Text.RegularExpressions;

namespace Ola.Commands.Arithmetic
{
    public class DecrementCommand : ICommand
    {
        private const string RegexPattern = @"^DECREMENT (\w+)$";

        private readonly CommandContext _context;

        public DecrementCommand(CommandContext context)
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

                if (_context.Variables.ContainsKey(variableName))
                {
                    if (_context.Variables[variableName] is int currentValue)
                    {
                        _context.Variables[variableName] = currentValue - 1;
                        Console.WriteLine($"SUCCESS: Decremented variable '{variableName}' to {_context.Variables[variableName]}");
                    }
                    else if (_context.Variables[variableName] is decimal currentDecimalValue)
                    {
                        _context.Variables[variableName] = currentDecimalValue - 1;
                        Console.WriteLine($"SUCCESS: Decremented variable '{variableName}' to {_context.Variables[variableName]}");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: Variable '{variableName}' is not a valid number type.");
                    }
                }
                else
                {
                    Console.WriteLine($"ERROR: Variable '{variableName}' not found.");
                }
            }

            return Task.FromResult(lineIndex + 1);
        }
    }
}