// Note - the project is using implicit and global usings 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ClassicConsoleAppNet6_DI
{
    class MyApp
    {
        private readonly ILogger<MyApp> logger;
        private readonly Configuration config;
        private readonly SingletonTest singletonTest;
        private readonly TransientTest transientTest;
        private readonly IServiceTest serviceTest;

        public MyApp(ILogger<MyApp> logger, Configuration config, SingletonTest singletonTest, TransientTest transientTest, IServiceTest serviceTest)
        {            
            this.logger = logger;
            this.config = config;
            this.singletonTest = singletonTest;
            this.transientTest = transientTest;
            this.serviceTest = serviceTest;
        }

        public void Run()
        {
            logger.LogInformation("Starting {Name} version {Version}", config.Name, config.Version);
            singletonTest.Id = 1;
            transientTest.Id = 1;

            // Getting a new instance
            var s1 = Program.ServiceProvider.GetService<SingletonTest>();
            logger.LogInformation("s1.Id = {Id}", s1.Id);   // Same object = Id = 1
            var t1 = Program.ServiceProvider.GetService<TransientTest>();
            logger.LogInformation("t1.Id = {Id}", t1.Id);   // New object = Id = 0

            serviceTest.Test();

            logger.LogInformation("Ending {Name} version {Version}", config.Name, config.Version);
        }
    }
}
