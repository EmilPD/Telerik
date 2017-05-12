using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using ProjectManager.Common.Commands.Contracts;
using ProjectManager.Data.Contracts;

namespace ProjectManager.Common.Commands
{
    public sealed class ListProjectsCommand : ICommand
    {
        private readonly IDatabase database;

        public ListProjectsCommand(IDatabase database)
        {
            Guard.WhenArgument(database, "ListProjectsCommand Database")
                .IsNull()
                .Throw();

            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            if (parameters.Count != 0)
            {
                throw new ArgumentException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new ArgumentException("Some of the passed parameters are empty!");
            }

            return string.Join(Environment.NewLine, this.database.Projects);
        }
    }
}