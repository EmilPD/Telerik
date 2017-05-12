using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManager.Common.Commands.Abstractions;
using ProjectManager.Common.Contracts;
using ProjectManager.Data.Contracts;

namespace ProjectManager.Common.Commands
{
    public class CreateProjectCommand : CreateCommand
    {
        private readonly IDatabase database;
        private readonly IModelsFactory modelsFactory;

        public CreateProjectCommand(IDatabase database, IModelsFactory modelsFactory)
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

            if (this.database.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new ArgumentException("A project with that name already exists!");
            }

            var project = this.modelsFactory.CreateProject(parameters[0], parameters[1], parameters[2], parameters[3]);
            this.database.Projects.Add(project);

            return "Successfully created a new project!";
        }
    }
}