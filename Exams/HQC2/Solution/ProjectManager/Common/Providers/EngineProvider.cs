using ProjectManager.Common.Contracts;

namespace ProjectManager
{
    public class EngineProvider
    {
        private readonly IEngine engine;

        public EngineProvider(IEngine engine)
        {
            this.engine = engine;
        }

        public void Execute()
        {
            this.engine.Start();
        }
    }
}