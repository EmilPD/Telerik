using System;
using System.Collections.Generic;
using System.Linq;
using ProjectManager.Common.Commands.Abstractions;
using ProjectManager.Common.Contracts;
using ProjectManager.Data.Contracts;

namespace ProjectManager.Common.Commands
{
    public class CreateUserCommand : CreateCommand
    {
        private readonly IDatabase database;
        private readonly IModelsFactory modelsFactory;

        public CreateUserCommand(IDatabase database, IModelsFactory modelsFactory)
            : base(database, modelsFactory)
        {
            this.database = database;
            this.modelsFactory = modelsFactory;
        }

        public override string Execute(IList<string> parameters)
        {
            if (parameters.Count != 3)
            {
                throw new ArgumentException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new ArgumentException("Some of the passed parameters are empty!");
            }

            if (this.database.Projects[int.Parse(parameters[0])].Users.Any() &&
                this.database.Projects[int.Parse(parameters[0])].Users.Any(x => x.UserName == parameters[1]))
            {
                throw new ArgumentException("A user with that username already exists!");
            }

            this.database.Projects[int.Parse(parameters[0])].Users
                .Add(this.modelsFactory.CreateUser(parameters[1], parameters[2]));

            return "Successfully created a new user!";
        }
    }
}