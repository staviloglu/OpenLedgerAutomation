namespace Ola.Commands.Core
{
    public interface ICommand
    {
        bool CanExecute(string command);
        Task<int> Execute(int lineIndex, string[] commands);
    }
}