using System;
using Bytes2you.Validation;
using ProjectManager.Common.Commands;
using ProjectManager.Common.Commands.Contracts;
using ProjectManager.Common.Contracts;
using ProjectManager.Data.Contracts;

namespace ProjectManager.Commands
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IModelsFactory modelsFactory;
        private readonly IDatabase database;

        public CommandsFactory(IDatabase database, IModelsFactory modelsFactory)
        {
            Guard.WhenArgument(database, "Commands Factory Database")
                .IsNull()
                .Throw();

            Guard.WhenArgument(modelsFactory, "Commands Factory Models Factory")
                .IsNull()
                .Throw();

            this.database = database;
            this.modelsFactory = modelsFactory;
        }

        public ICommand CreateCommandFromString(string commandName)
        {
            Guard.WhenArgument(commandName, "Create Command FromString")
                .IsNullOrEmpty()
                .Throw();

            var command = this.BuildCommand(commandName);

            switch (command)
            {
                case "createproject":
                    return new CreateProjectCommand(this.database, this.modelsFactory);

                case "createtask":
                    return new CreateTaskCommand(this.database, this.modelsFactory);

                case "createuser":
                    return new CreateUserCommand(this.database, this.modelsFactory);

                case "listprojects":
                    return new ListProjectsCommand(this.database);

                default: throw new ArgumentException("The passed command is not valid!");
            }
        }
        
        private string BuildCommand(string parameters)
        {
            Guard.WhenArgument(parameters, "Build Command")
                .IsNullOrEmpty()
                .Throw();

            var command = string.Empty;

                for (int i = 0; i < parameters.Length; i++)
                {
                    command += parameters[i].ToString().ToLower();
                }

            return command;
        } 
    }
}