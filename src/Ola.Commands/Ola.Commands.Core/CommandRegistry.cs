using Ola.Banking.Core;
using System.Reflection;

namespace Ola.Commands.Core
{
    public class CommandRegistry
    {
        private readonly List<ICommand> _commands;

        private readonly CommandContext _context;

        public CommandRegistry(IBankingService bankingService, Dictionary<string, object> variables, Dictionary<string, int> labels)
        {
            _context = new CommandContext(bankingService, variables, labels, this);
            _commands = LoadCommands();           
        }

        public async Task<int> ExecuteCommand(int lineIndex, string[] commands)
        {
            string command = commands[lineIndex];

            foreach (var cmd in _commands)
            {
                if (cmd.CanExecute(command))
                {
                    return await cmd.Execute(lineIndex, commands);
                }
            }

            throw new Exception($"ERROR: Unknown command - '{command}'");
        }

        public List<ICommand> GetCommands() => _commands;

        private List<ICommand> LoadCommands()
        {
            var commandList = new List<ICommand>();
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            var dllFiles = Directory.GetFiles(directory, "Ola.Commands.*.dll");

            foreach (var dllFile in dllFiles)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dllFile);
                    var commandTypes = assembly.GetTypes()
                        .Where(t => typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                    foreach (var type in commandTypes)
                    {
                        var constructor = type.GetConstructors()
                            .FirstOrDefault(c => c.GetParameters().Length == 1 && c.GetParameters()[0].ParameterType == typeof(CommandContext));

                        if (constructor != null)
                        {
                            var commandInstance = (ICommand)Activator.CreateInstance(type, _context);
                            commandList.Add(commandInstance);
                        }
                        else
                        {
                            throw new Exception($"ERROR: Command '{type.Name}' must have a constructor that accepts a CommandContext.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: Failed to load commands from {dllFile}: {ex.Message}");
                }
            }

            return commandList;
        }
    }
}
