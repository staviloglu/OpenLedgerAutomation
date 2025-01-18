using Ola.Banking.Core;
using Ola.Commands.Core;

namespace Ola.Core
{
    public class OlaInterpreter
    {
        private IBankingService _bankingService;
        private Dictionary<string, object> _variables = new Dictionary<string, object>();
        private Dictionary<string, int> _labels = new Dictionary<string, int>();
        private CommandRegistry _commandRegistry;
        private string[] _commands;

        public OlaInterpreter(string script, IBankingService bankingService)
        {
            _commands = script.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            _bankingService = bankingService;

            _commandRegistry = new CommandRegistry(_bankingService, _variables, _labels);
        }
        public async Task RunScript()
        {
            Console.WriteLine("Initial state of the bank:");
            _bankingService.PrintAccounts();
            Console.WriteLine();

            int lineIndex = 0;
            while (lineIndex < _commands.Length)
            {
                lineIndex = await _commandRegistry.ExecuteCommand(lineIndex, _commands);
            }

            Console.WriteLine();
            Console.WriteLine("Final state of the bank:");
            _bankingService.PrintAccounts();
        }

        public void TestScript()
        {
            int openIfCount = 0;

            for (int i = 0; i < _commands.Length; i++)
            {
                string command = _commands[i];
                bool canExecute = false;

                // Check if the command matches any of the known commands
                foreach (var cmd in _commandRegistry.GetCommands())
                {
                    if (cmd.CanExecute(command))
                    {
                        canExecute = true;
                        break;
                    }
                }

                // Count IF and ENDIF statements
                if (command.StartsWith("IF"))
                {
                    openIfCount++;
                }
                else if (command.StartsWith("ENDIF"))
                {
                    if (openIfCount > 0)
                    {
                        openIfCount--;
                    }
                    else
                    {
                        throw new Exception($"ERROR: Unmatched ENDIF at line {i + 1}");
                    }
                }

                if (!canExecute)
                {
                    throw new Exception($"ERROR: Unknown command - '{command}'");
                }
            }

            // If there are still open IF blocks, it means some ENDIF is missing
            if (openIfCount > 0)
            {
                throw new Exception("ERROR: Missing ENDIF statement(s)");
            }
        }
    }
}