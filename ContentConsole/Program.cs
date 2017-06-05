using System;
using ContentConsole.Infrastructure;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var executor = IoC.Resolve<Runner>();
            executor.Start();
        }

    }

}
