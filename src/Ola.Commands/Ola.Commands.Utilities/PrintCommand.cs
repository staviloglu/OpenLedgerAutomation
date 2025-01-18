using Ola.Commands.Core;
using System.Text.RegularExpressions;

namespace Ola.Commands.Utilities
{
    public class PrintCommand : ICommand
    {
        private const string RegexPattern = @"^PRINT \""(.+?)\""|PRINT (\w+)$";

        private readonly CommandContext _context;

        public PrintCommand(CommandContext context)
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
                if (match.Groups[1].Success)
                {
                    string textToPrint = match.Groups[1].Value;

                    Console.WriteLine(textToPrint);
                }
                else if (match.Groups[2].Success)
                {
                    string variableName = match.Groups[2].Value;

                    if (_context.Variables.ContainsKey(variableName))
                    {
                        if (_context.Variables[variableName] is decimal decimalValue)
                        {
                            Console.WriteLine(decimalValue.ToString("F"));
                        }
                        else
                        {
                            Console.WriteLine(_context.Variables[variableName]);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: Variable '{variableName}' not found.");
                    }
                }
            }

            return Task.FromResult(lineIndex + 1);
        }
    }
}