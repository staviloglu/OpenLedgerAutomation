using Ola.Banking.Core;

namespace Ola.Commands.Core
{
    public class CommandContext
    {
        public IBankingService BankingService { get; }
        public Dictionary<string, object> Variables { get; }

        public Dictionary<string,int> Labels { get; }

        public CommandRegistry CommandRegistry { get; }

        public CommandContext(IBankingService bankingService, Dictionary<string, object> variables, Dictionary<string, int> labels, CommandRegistry commandRegistry)
        {
            BankingService = bankingService;
            Variables = variables;
            Labels = labels;
            CommandRegistry = commandRegistry;
        }
    }
}
