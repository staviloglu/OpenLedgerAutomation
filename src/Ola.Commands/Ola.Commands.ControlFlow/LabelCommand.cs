using Ola.Commands.Core;
using System.Text.RegularExpressions;

namespace Ola.Commands.ControlFlow
{
    public class LabelCommand : ICommand
    {
        private const string RegexPattern = @"^LABEL (\w+)$";

        private readonly CommandContext _context;

        public LabelCommand(CommandContext context)
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
                string label = match.Groups[1].Value;
                _context.Labels[label] = lineIndex;
            }
            return Task.FromResult(lineIndex + 1);
        }
    }

}