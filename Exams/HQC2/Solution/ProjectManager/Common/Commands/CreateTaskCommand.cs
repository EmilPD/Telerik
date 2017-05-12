using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManager.Common.Commands.Abstractions;
using ProjectManager.Common.Contracts;
using ProjectManager.Data.Contracts;
using ProjectManager.Models.Enums;

namespace ProjectManager.Common.Commands
{
    public class CreateTaskCommand : CreateCommand
    {
        private readonly IDatabase database;
        private readonly IModelsFactory modelsFactory;

        public CreateTaskCommand(IDatabase database, IModelsFactory modelsFactory) 
            : base(database, modelsFactory)
        {
            this.database = database;
            this.modelsFactory = modelsFactory;
        }

        public override string Execute(IList<string> parameters)
        {
            if (parameters.Count != 4)
            {
                throw new ArgumentException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new ArgumentException("Some of the passed parameters are empty!");
            }

            var project = this.database.Projects[int.Parse(parameters[0])];

            var projectOwner = project.Users[int.Parse(parameters[1])];

            var task = this.modelsFactory.CreateTask(projectOwner, parameters[2], parameters[3]);
            project.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}