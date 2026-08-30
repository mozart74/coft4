/////////////////////////////////////////////////////
// Author; EP
// (c) Copyright 2026 Edward Principe
/////////////////////////////////////////////////////
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

            // Parse command
            int ret = cmd.ParseCommandLine(args);

            if (ret != 0)
                return ret;

            // Check for errorz
            if (cmd.IsHelp)
            {
                CommandLine.Usage();
                return 0;
            }

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
            try
            {
                CompileC cc = new CompileC(cmd);
                ret = cc.Run();
                return ret;

            }
            catch (Exception e)
            {
                Console.WriteLine("***  FATAL ERROR ***");                
                Console.WriteLine("Member name: {0}", e.Message);

                return 2;
            } // Try/Catch
        
        } // Main
    } // End Program 
} // Namespace
