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

            // compile the source file to the object file

            // Open the object file for writing
            try
            {
                IO.FileStream obj_file = new IO.FileStream(cmd.ObjectFile, IO.FileMode.Create | IO.FileMode.Write);
            }
            catch (Exception ex)
            {
                Console.WriteLine("FATAL ERROR: Could not open object file");
                return 1;
            }

           // Compile the source file to the object file
           for(string soureFile in cmd.SourceFiles)
            {
                // Compile C file
                try
                {
                    // Open source file for reading

                }
                catch(Exception ex)
                {
        }
    }
}
