// Note - the project is using implicit and global usings 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;

namespace ClassicConsoleAppNet6_DI
{
    internal class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);
            Configuration config = new();
            builder.Build().Bind(config);
            config.Args = args; // Args from console

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            var host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   // "Program" with args and ILogger
                   services.AddTransient<MyApp>();

                   // Configuration
                   services.AddSingleton<Configuration>(config);

                   // Test
                   services.AddSingleton<SingletonTest>();
                   services.AddTransient<TransientTest>();

                   // If even ms use ServiceTest1
                   if (DateTime.Now.Millisecond % 2 == 0)
                       services.AddTransient<IServiceTest, ServiceTest1>();
                   else
                       services.AddTransient<IServiceTest, ServiceTest2>();
                   

                   /*
                        - Singleton objects are the same for every object and every request.                    
                        - Transient objects are always different; a new instance is provided to every controller and every service.
                        
                        - For ASPNET, API, etc.:
                        - Scoped objects are the same within a request, but different across different requests. 
                    */

               })
               .UseSerilog()
               .Build();
            ServiceProvider = host.Services;

            // "Main"
            var app = ServiceProvider.GetService<MyApp>();
            app.Run();

        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }
    }
}
