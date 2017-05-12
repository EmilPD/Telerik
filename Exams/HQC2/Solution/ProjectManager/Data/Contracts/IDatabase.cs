using System.Collections.Generic;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Data.Contracts
{
    /// <summary>
    /// Represents List of all Projects.
    /// </summary>
    public interface IDatabase
    {
        IList<IProject> Projects { get; }
    }
}
