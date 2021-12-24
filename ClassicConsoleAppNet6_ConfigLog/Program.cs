// Note - the project is using implicit and global usings 
using Microsoft.Extensions.Configuration;
using Serilog;
using SerilogTimings;
using SerilogTimings.Extensions;

namespace ClassicConsoleAppNet6_ConfigLog
{
    internal partial class Program
    {
        public static Configuration configuration;
        private static ILogger logger;
        static void Main(string[] args)
        {
            // Bind to config and log
            (configuration, logger) = GetConfigurationAndLog(); 
            

            // Use the static Log-object to log
            // See appsettings for sinks (console, debug, file)
            logger.Information("App start");
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Something went wrong!");
            }
            finally
            {
                logger.Information("App end");
                Log.CloseAndFlush();
            }

            /*
                Serilog docs:
                Levels: https://github.com/serilog/serilog/wiki/Configuration-Basics#minimum-level
                Sinks:  https://github.com/serilog/serilog/wiki/Provided-Sinks
                Format: https://github.com/serilog/serilog/wiki/Formatting-Output#formatting-plain-text
            */
        }

        public static void Run()
        {            
            // Test log 
            logger.Verbose("Verbose");
            logger.Debug("Debug");
            logger.Information("Information");
            logger.Warning("Warning");
            logger.Error("Error");
            logger.Fatal("Fatal");
            
            // Special timing extension SerilogTimings (https://github.com/nblumhardt/serilog-timings)
            using (logger.TimeOperation("Testing code # {id}", 1))
            {
                Thread.Sleep(400);
            }

            // Test config
            logger.Information("A {A}", configuration.A);
            logger.Information("B {B}", configuration.B);
            logger.Information("C {C}", configuration.C);
            logger.Information("D {D}", configuration.D);
            logger.Information("E {E}", configuration.E);
            logger.Information("F {F}", configuration.F);
            logger.Information("G {G}", configuration.G);
        }

        static (Configuration, ILogger) GetConfigurationAndLog()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            var c = new Configuration();
            configuration.Bind(c);

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)                
                .CreateLogger();
            return (c, logger);
        }
    }

}
