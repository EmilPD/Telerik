using System;
using System.Linq;
using Bytes2you.Validation;
using ProjectManager.Common.Contracts;

namespace ProjectManager.Common
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly ICommandsFactory commandsFactory;

        public CommandProcessor(ICommandsFactory factory)
        {
            Guard.WhenArgument(factory, "Command Processor Factory")
                .IsNull()
                .Throw();

            this.commandsFactory = factory;
        }

        public string Process(string commandsList)
        {
            Guard.WhenArgument(commandsList, "Process - No command has been provided!")
                .IsNull()
                .Throw();

            var command = this.commandsFactory.CreateCommandFromString(commandsList.Split(' ')[0]);

            if (commandsList.Split(' ').Count() > 10)
            {
                throw new ArgumentException("Commands list is too large!");
            }

            return command.Execute(commandsList.Split(' ').Skip(1).ToList());
        }
    }
}