using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicConsoleAppNet6_DI
{
    internal class ServiceTest1 : IServiceTest
    {
        private readonly ILogger<ServiceTest1> logger;
        private readonly Configuration config;

        public ServiceTest1(ILogger<ServiceTest1> logger, Configuration config)
        {
            this.logger = logger;
            this.config = config;
            this.logger = logger;
        }
        public void Test()
        {
            logger.LogInformation("In {Name}.ServiceTest1.Test()", config.Name);
        }
    }

    internal class ServiceTest2 : IServiceTest
    {
        private readonly ILogger<ServiceTest1> logger;
        private readonly Configuration config;

        public ServiceTest2(ILogger<ServiceTest1> logger, Configuration config)
        {
            this.logger = logger;
            this.config = config;
        }
        public void Test()
        {
            logger.LogInformation("In {Name}.ServiceTest2.Test()", config.Name);
        }
    }

}
