using ProjectManager.Models.Contracts;

namespace ProjectManager.Common.Contracts
{
    /// <summary>
    /// Represent a factory for createing Projects, Tasks and Users
    /// </summary>
    public interface IModelsFactory
    {
        /// <summary>
        /// Represent Create Project method which take 4 parameters - name, start date, end date and state
        /// </summary>
        /// <param name="name">String name</param>
        /// <param name="startingDate">String starting date</param>
        /// <param name="endingDate">String ending date</param>
        /// <param name="state">String state</param>
        /// <returns></returns>
        IProject CreateProject(string name, string startingDate, string endingDate, string state);

        /// <summary>
        /// Represent Create Task method which take 3 parameters - owner, name and state
        /// </summary>
        /// <param name="owner">Represent IUser</param>
        /// <param name="name">String name</param>
        /// <param name="state">String state</param>
        /// <returns></returns>
        ITask CreateTask(IUser owner, string name, string state);

        /// <summary>
        /// Represent Create User method which take 2 parameters - username and email
        /// </summary>
        /// <param name="username">String username</param>
        /// <param name="email">string email</param>
        /// <returns></returns>
        IUser CreateUser(string username, string email);
    }
}