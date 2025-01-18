using Ola.Commands.Core;
using System.Text.RegularExpressions;

namespace Ola.Commands.ControlFlow
{
    public class GotoCommand : ICommand
    {
        private const string RegexPattern = @"^GOTO (\w+)$";

        private readonly CommandContext _context;

        public GotoCommand(CommandContext context)
        {
            _context = context;
        }

        public bool CanExecute(string command) => Regex.IsMatch(command, RegexPattern);

        public static bool IsGotoCommand(string command) => Regex.IsMatch(command, RegexPattern);

        public Task<int> Execute(int lineIndex, string[] commands)
        {
            var command = commands[lineIndex];

            var match = Regex.Match(command, RegexPattern);

            if (match.Success)
            {
                string label = match.Groups[1].Value;

                if (_context.Labels.ContainsKey(label))
                {
                    return Task.FromResult(_context.Labels[label]);
                }
                else
                {
                    Console.WriteLine($"ERROR: Label '{label}' not found.");
                }
            }

            return Task.FromResult(lineIndex + 1);
        }
    }
}