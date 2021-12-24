using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicConsoleAppNet6_DI
{
    class SingletonTest
    {
        private readonly ILogger<MyApp> logger;
        private readonly Configuration config;

        public SingletonTest(ILogger<MyApp> logger, Configuration config)
        {
            this.logger = logger;
            this.config = config;
            this.logger.LogInformation("In {Name}.SingletonTest.ctor", this.config.Name);
        }

        public int Id { get; internal set; }
    }
}
