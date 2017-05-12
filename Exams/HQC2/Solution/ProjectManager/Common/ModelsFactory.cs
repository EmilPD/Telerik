using System;
using ProjectManager.Common;
using ProjectManager.Common.Contracts;
using ProjectManager.Models.Contracts;

namespace ProjectManager.Models
{
    public class ModelsFactory : IModelsFactory
    {
        private readonly Validator validator = new Validator();

        public IProject CreateProject(string name, string startingDate, string endingDate, string state)
        {
            DateTime starting;
            DateTime end;
            var startingDateSuccessful = DateTime.TryParse(startingDate, out starting);
            var endingDateSuccessful = DateTime.TryParse(endingDate, out end);
            
            if (!startingDateSuccessful)
            {
                throw new ArgumentException("Failed to parse the passed starting date!");
            }

            if (!endingDateSuccessful)
            {
                throw new ArgumentException("Failed to parse the passed ending date!");
            }

            var project = new Project(name, starting, end, state);
            this.validator.Validate(project);

            return project;
        }

        public ITask CreateTask(IUser owner, string name, string state)
        {
            ITask task = new Task(name, owner, state) as ITask;
            this.validator.Validate(task);

            return task;
        }
        
        public IUser CreateUser(string username, string email)
        {
            var user = new User(username, email) as IUser;
            this.validator.Validate(user);

            return user;
        }       
    }
}