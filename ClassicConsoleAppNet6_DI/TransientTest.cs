using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicConsoleAppNet6_DI
{
    class TransientTest
    {
        private readonly ILogger<MyApp> logger;
        private readonly Configuration config;

        public TransientTest(ILogger<MyApp> logger, Configuration config)
        {
            this.logger = logger;
            this.config = config;
            this.logger.LogInformation("In {Name}.TransientTest.ctor", this.config.Name);
        }

        public int Id { get; internal set; }
    }
}
