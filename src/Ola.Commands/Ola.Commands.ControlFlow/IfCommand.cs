using Ola.Commands.Core;
using System.Text.RegularExpressions;

namespace Ola.Commands.ControlFlow
{
    public class IfCommand : ICommand
    {
        private const string RegexPattern = @"^IF ([\w\d\.]+) (>|>=|<|<=|==|!=) ([\w\d\.]+) THEN$";
        private readonly CommandContext _context;

        public IfCommand(CommandContext context)
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
                string operand1 = match.Groups[1].Value;
                string relationalOperator = match.Groups[2].Value;
                string operand2 = match.Groups[3].Value;

                decimal operand1Value;
                decimal operand2Value;

                if (!GetDecimalOperand(operand1, out operand1Value))
                {
                    Console.WriteLine($"ERROR: '{operand1}' not found or is not a valid decimal.");
                    return lineIndex + 1;
                }

                if (!GetDecimalOperand(operand2, out operand2Value))
                {
                    Console.WriteLine($"ERROR: '{operand2}' not found or is not a valid decimal.");
                    return lineIndex + 1;
                }

                bool conditionMet = relationalOperator switch
                {
                    ">" => operand1Value > operand2Value,
                    ">=" => operand1Value >= operand2Value,
                    "<" => operand1Value < operand2Value,
                    "<=" => operand1Value <= operand2Value,
                    "==" => operand1Value == operand2Value,
                    "!=" => operand1Value != operand2Value,
                    _ => false
                };

                if (conditionMet)
                {
                    // Execute all commands in the block
                    lineIndex += 1;
                    while (lineIndex < commands.Length && !commands[lineIndex].StartsWith("ENDIF"))
                    {
                        lineIndex = await _context.CommandRegistry.ExecuteCommand(lineIndex, commands);
                    }

                    // Move to the line after ENDIF
                    return lineIndex + 1;
                }
                else
                {
                    // Skip to the line after ENDIF
                    lineIndex += 1;
                    while (lineIndex < commands.Length && !commands[lineIndex].StartsWith("ENDIF"))
                    {
                        lineIndex++;
                    }

                    return lineIndex + 1;
                }
            }

            return lineIndex + 1;
        }

        private bool GetDecimalOperand(string operand, out decimal operandValue)
        {
            if (decimal.TryParse(operand, out operandValue))
            {
                return true;
            }

            if (_context.Variables.ContainsKey(operand) && decimal.TryParse(_context.Variables[operand]?.ToString(), out operandValue))
            {
                return true;
            }

            return false;
        }
    }
}