// Note - project is using implict and global usings 

namespace ClassicConsoleAppNet6_ConfigLog
{
    internal partial class Program
    {
        public class Configuration
        {
            public string A { get; set; }
            public int B { get; set; }
            public bool C { get; set; }
            public DateTime D { get; set; }
            public double E { get; set; }
            public SubConfiguration F { get; set; }
            public List<SubConfiguration> G { get; set; }

        }
    }

}
