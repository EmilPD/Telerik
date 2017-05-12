using System.Collections.Generic;
using Bytes2you.Validation;
using ProjectManager.Common.Commands.Contracts;
using ProjectManager.Common.Contracts;
using ProjectManager.Data.Contracts;

namespace ProjectManager.Common.Commands.Abstractions
{
    public abstract class CreateCommand : ICommand
    {
        private readonly IDatabase database;
        private readonly IModelsFactory modelsFactory;

        public CreateCommand(IDatabase database, IModelsFactory modelsFactory)
        {
            Guard.WhenArgument(database, "CreateCommand Database")
                .IsNull()
                .Throw();

            Guard.WhenArgument(modelsFactory, "CreateCommand ModelsFactory")
                .IsNull()
                .Throw();

            this.database = database;
            this.modelsFactory = modelsFactory;
        }

        public abstract string Execute(IList<string> parameters);
    }
}