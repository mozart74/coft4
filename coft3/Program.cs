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

            // Parse compiler comamand line arguments
            cmd.ParseCommandLine(args);


            // Check for errorz
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
            try
            {
                CompileC cc = new CompileC(ref cmd);
                int ret = cc.Run();
                return ret;
            }
            catch (Exception e)
            {

                Console.WriteLine("***  FATAL ERROR ***");
                Console.WriteLine("Member name: {0}", e.TargetSite.DeclaringType);
                Console.WriteLine("Class defining member: {0}", e.TargetSite.MemberType);
                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("Source: {0}", e.Source);

                return 2;
            } // Try/Catch
        
             
        } // Main
    } // End Program 
} // Namespace
