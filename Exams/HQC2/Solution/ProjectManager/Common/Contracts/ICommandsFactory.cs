using ProjectManager.Common.Commands.Contracts;

namespace ProjectManager.Common.Contracts
{
    public interface ICommandsFactory
    {
        /// <summary>
        /// Represent a commands Factory with CreateCommandFromString method
        /// </summary>
        /// <param name="commandName">Create command from string</param>
        /// <returns></returns>
        ICommand CreateCommandFromString(string commandName);
    }
}