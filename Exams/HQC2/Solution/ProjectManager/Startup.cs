using ProjectManager.Commands;
using ProjectManager.Common;
using ProjectManager.Common.Providers;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager
{
    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReaderProvider();
            var writer = new ConsoleWriterProvider();

            var fileLogger = new FileLogger();

            var database = new Database();
            var modelsFactory = new ModelsFactory();
            var commandsFactory = new CommandsFactory(database, modelsFactory);
                
            var commandProcessor = new CommandProcessor(commandsFactory);

            var engine = new Engine(fileLogger, commandProcessor, reader, writer);

            var engineProvider = new EngineProvider(engine);
            engineProvider.Execute();
        }
    }
}