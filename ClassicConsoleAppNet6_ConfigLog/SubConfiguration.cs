// Note - project is using implict and global usings 

namespace ClassicConsoleAppNet6_ConfigLog
{
    internal partial class Program
    {
        public class SubConfiguration
            {
            public string A { get; set; }
            public int B { get; set; }
            public override string ToString()
            {
                return $"SubConfiguration {{ Name: '{this.A}', Age: {this.B} }}";
            }

        }
    }

}
