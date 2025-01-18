using Ola.Banking.Core;
using Ola.Core;
using System.Reflection;

namespace Ola.Console
{
    public static class Program
    {
        static async Task<int> Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            if (args.Length < 2 || (args[0] != "run" && args[0] != "test"))
            {
                System.Console.WriteLine("Usage: ola run <script.ola> or ola test <script.ola>");
                System.Console.WriteLine("Note: <script.ola> should be a properly formatted OLA script file.");

                return ExitCodes.UnknownFeature;
            }

            string filePath = args[1];
            if (!File.Exists(filePath))
            {
                System.Console.WriteLine($"ERROR: File '{filePath}' not found.");
                return ExitCodes.ScriptFileDoesNotExists;
            }

            if (Path.GetExtension(filePath) != ".ola")
            {
                System.Console.WriteLine($"ERROR: Invalid file extension for '{filePath}'. Please provide a '.ola' file.");
                return ExitCodes.ShouldBeOlaScript;
            }

            var script = File.ReadAllText(filePath, System.Text.Encoding.UTF8);

            var bankingService = LoadBankingService();

            if (bankingService == null)
            {
                System.Console.WriteLine("ERROR: Could not load a valid banking service implementation.");
                return ExitCodes.MissingBankingService;
            }

            var interpreter = new OlaInterpreter(script, bankingService);

            try
            {
                if (args[0] == "test")
                {
                    interpreter.TestScript();
                }
                else if (args[0] == "run")
                {
                    await interpreter.RunScript();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"ERROR: An unexpected error occurred: {ex.Message}");
                return ExitCodes.Error;
            }

            return ExitCodes.Success;
        }

        private static IBankingService LoadBankingService()
        {
            try
            {
                string directory = AppDomain.CurrentDomain.BaseDirectory;
                var dllFiles = Directory.GetFiles(directory, "Ola.Banking.*.dll");
                Array.Sort(dllFiles, (x, y) => String.Compare(x, y));

                foreach (var dllFile in dllFiles)
                {
                    var assembly = Assembly.LoadFrom(dllFile);
                    var bankingServiceType = assembly.GetTypes()
                        .FirstOrDefault(t => typeof(IBankingService).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                    if (bankingServiceType != null)
                    {
                        return (IBankingService)Activator.CreateInstance(bankingServiceType);
                    }
                }

                System.Console.WriteLine("ERROR: No valid banking service implementation found in any of the Ola.Banking.*.dll files.");
                return null;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"ERROR: Failed to load banking service: {ex.Message}");
                return null;
            }
        }
    }

}