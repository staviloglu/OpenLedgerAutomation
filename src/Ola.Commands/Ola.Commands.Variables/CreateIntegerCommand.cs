using Ola.Commands.Core;
using System.Text.RegularExpressions;

namespace Ola.Commands.Variables
{
    public class CreateIntegerCommand : ICommand
    {
        private const string RegexPattern = @"^CREATE INTEGER AS (\w+)$";

        private readonly CommandContext _context;

        public CreateIntegerCommand(CommandContext context)
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

                if (!_context.Variables.ContainsKey(variableName))
                {
                    _context.Variables[variableName] = 0;

                    Console.WriteLine($"SUCCESS: Created integer variable '{variableName}' with initial value 0");
                }
                else
                {
                    Console.WriteLine($"ERROR: Variable '{variableName}' already exists.");
                }
            }

            return Task.FromResult(lineIndex + 1);
        }
    }
}