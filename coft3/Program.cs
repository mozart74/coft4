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
            CompileC cc = new CompileC(); 
            
            // Parse compiler comamand line arguments
            cmd.ParseCommandLine(args);

            // Chheck for errorz
            if (cmd.IsHelp)
                return 0;

            if (!_cmd.IsObj)
            {
                Console.WriteLine("FATAL ERROR: Need an object file");
                return 1;
            }

            if (!cmd.IsSource)
            {
                Console.WriteLine("FATAL ERROR: Need a source file");
                return 1;
            }

            // Open the object file for writing
            int ret = 0;

            FileInfo fs = new FileInfo(cmd.ObjectFile);

            using (BinaryWriter bw = new BinaryWriter(fs.OpenWrite))
            {
                foreach (string source_file in cmd.SourceFiles)
                {
                    // Open source file for reading
                    cc,Compile(bw, source_file);
                }

            }

            // Return to system
            return 0;
        }
    }
}
