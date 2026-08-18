using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Text;
using System.IO;

using COFT2;
using System.Runtime.CompilerServices;

namespace COFT2
{
    public class Program
    {
        public static int Main(params string[] args)
        {
            // Locals
            CommandLine cmd = new CommandLine();
            
            // Parse compiler comamand line arguments
            cmd.ParseCommandLine(args);

            // Chheck for errorz
            if (cmd.IsHelp)
                return 0;

            if (!cmd.IsObj)
            {
                Console.WriteLine("FATAL ERROR: Need an object file");
                return 1;
            }

            if (!cmd.IsSource)
            {
                Console.WriteLine("FATAL ERROR: Need a source file");
                return 1;
            }

            // Run the compiler
            CompileC cc = new CompileC(cmd);
            int ret = cc.Run();

            // Return success
            return 0;
        }
    }
}
