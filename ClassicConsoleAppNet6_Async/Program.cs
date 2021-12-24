// Note - the project is using implicit and global usings 
namespace ClassicConsoleAppNet6_Async
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Run(() => { });
        }
    }
}
