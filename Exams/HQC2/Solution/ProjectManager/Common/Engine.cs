using System;
using Bytes2you.Validation;
using ProjectManager.Common.Contracts;

namespace ProjectManager.Common
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly ICommandProcessor processor;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ILogger logger, ICommandProcessor processor, IReader reader, IWriter writer)
        {
            Guard.WhenArgument(logger, "Engine Logger provider")
                .IsNull()
                .Throw();

            Guard.WhenArgument(processor, "Engine Processor provider")
                .IsNull()
                .Throw();

            Guard.WhenArgument(reader, "Engine Reader provider")
                .IsNull()
                .Throw();

            Guard.WhenArgument(writer, "Engine Writer provider")
                .IsNull()
                .Throw();

            this.logger = logger;
            this.processor = processor;
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            while (true)
            {
                var commandAsString = this.reader.ReadLine();

                if (commandAsString.ToLower() == "exit")
                {
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.processor.Process(commandAsString);
                    this.writer.WriteLine(executionResult);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("Opps, something happened. :(");
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
