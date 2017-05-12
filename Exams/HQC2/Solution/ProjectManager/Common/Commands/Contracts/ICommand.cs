using System.Collections.Generic;

namespace ProjectManager.Common.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}