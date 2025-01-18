using Ola.Commands.Core;
using System.Text.RegularExpressions;

namespace Ola.Commands.Arithmetic
{
    public class AddCommand : ICommand
    {
        private const string RegexPattern = @"^ADD (\w+) AND ([\w\d\.]+) AS (\w+)$";
        private readonly CommandContext _context;

        public AddCommand(CommandContext context)
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
                string variable1 = match.Groups[1].Value;
                string operand2 = match.Groups[2].Value;
                string resultVariable = match.Groups[3].Value;

                if (_context.Variables.ContainsKey(variable1))
                {
                    var value1 = _context.Variables[variable1];
                    decimal value2;

                    if (_context.Variables.ContainsKey(operand2))
                    {
                        var valueFromVariable = _context.Variables[operand2];
                        if (valueFromVariable is int intValue)
                        {
                            value2 = Convert.ToDecimal(intValue);
                        }
                        else if (valueFromVariable is decimal decimalValue)
                        {
                            value2 = decimalValue;
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: Incompatible type for variable '{operand2}'.");
                            return Task.FromResult(lineIndex + 1);
                        }
                    }
                    else if (decimal.TryParse(operand2, out decimal constantValue))
                    {
                        value2 = constantValue;
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: Operand '{operand2}' is neither a valid variable nor a constant value.");
                        return Task.FromResult(lineIndex + 1);
                    }

                    if (value1 is int int1)
                    {
                        _context.Variables[resultVariable] = Convert.ToDecimal(int1) + value2;
                    }
                    else if (value1 is decimal dec1)
                    {
                        _context.Variables[resultVariable] = dec1 + value2;
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: Cannot add incompatible types for variable '{variable1}' and operand '{operand2}'.");
                    }
                }
                else
                {
                    Console.WriteLine($"ERROR: Variable '{variable1}' not found.");
                }
            }

            return Task.FromResult(lineIndex + 1);
        }
    }
}