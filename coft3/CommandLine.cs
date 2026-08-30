
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using COFT2;

namespace COFT2
{
    /// <summary>
    /// Command Line
    /// </summary>
    public class CommandLine
    {
        private const int MAX_SOURCE_FILES = 255;

        public CommandLine()
        {
            _object_file = new string("");
            _source_files = new string [MAX_SOURCE_FILES];
            _count = 0;
            _is_verbose = false;
            _is_source = false;
            _is_help = false;
            _is_obj = false;
            _is_debug = false;
        }


        public int Count
        {
            get { return _count; }
        }

        
        // refrence count
        public void AddRef()
        {
            _count++;
        }

        //////////////////////////////////
        //  <summary>
        /// Parse the command line arguments and set the approprite flags and values.
        /// </summary>
        /// <param name="cmd"></param>
        public int ParseCommandLine(params string[] cmd)
        {
            if (cmd == null || cmd.Length == 0)
            {
                _is_help = true;
                Usage();
                return 1;
            }
            else
            {
                foreach(string i in cmd)
                {
                    if (i == "-v" || i == "--verbose")
                    {
                        _is_verbose = true;
                        Console.WriteLine("Verbose output enabled.");
                    }

                    else if (i == "-h" || i == "--help")
                    {
                        _is_help = true;

                        if (_is_verbose == true)
                        {
                            Console.WriteLine("Help System");
                        }

                        // Display the usage of the program
                        CommandLine.Usage();
                        return 1;

                    }
                    else if (i == "-d" || i == "--debug")
                    {
                        _is_debug = true;

                        if (_is_verbose == true)
                            Console.WriteLine("Debug mode turned on");
                    }
                    else if (i.EndsWith(".obj") == true) // If obj then compile obj
                    {

                        _is_obj = true;

                        // If verbose then more sturgg
                        if (_is_verbose == true)
                        {
                            Console.WriteLine("Object.... {0}", _object_file);
                        }

                        _object_file = i;
                    }
                    else if (i.EndsWith(".c") == true || i.EndsWith(".cpp") == true)
                    {
                        if (_is_verbose == true)
                        {
                            Console.WriteLine("Compiling... {0}", i);
                        }

                        _is_source = true;
                        Add(i);
                    }
                    else
                    {
                        Console.WriteLine("Unknown command line argument: {0}", i);
                        _is_help = true;
                        Usage();
                        return 2;
                    } // End if
                } // End foreach
            } // END IF

            return 0;

        } // end ParseCommandLines

        //////////////////////////////////////////////////////////////
        /// <summury>
        /// Method to display the usage of the program.
        /// </summury>
        //////////////////////////////////////////////////////////////
        public static void Usage()
        {
            Console.WriteLine("coft - A C/C++ compiler suite for applications");
            Console.WriteLine("Copyright (c) 2026 KIA. All rights reserved.");
            Console.WriteLine("Licensed under the GPLv3 License. See LICENSE file in the project");
            Console.WriteLine(" ");
            Console.WriteLine("USAGE: coft [options] <object_file> <source_files");
            Console.WriteLine("options:");
            Console.WriteLine("\t-v, --verbose = Verbose output");
            Console.WriteLine("\t-h, --help = Display this help message");
            Console.WriteLine("\t<object_file>=.obj>");
            Console.WriteLine("\t<source_file>=.c.cpps <source_files>...");
        }

        /// <summary>
        /// Interface
        /// </summary>
        /// <returns></returns>

 
        ///////////////////////////////////
        /// <summary>
        /// Properties
        /// </summary>
        ////////////////////////////////
        public bool IsVerbose
        {
            get { return _is_verbose; }
        }
     
        public bool IsDebug
        {
            get { return _is_debug; }
        }

        public bool IsHelp
        {
            get { return _is_help; }
        }

        public bool IsObj
        {

            get { return _is_obj; }

        }

        public bool IsSource
        {
            get { return _is_source; }
        }
        public void Add(string fileName)
        {
            _source_files[_count] = fileName;  // store the string in the ArrayList
            _count++;                // increment the internal count
        }

        public string Get(int index)
        {
            return _source_files[index];
        }
        
        public string ObjectFile
        {
            get { return _object_file ?? string.Empty; }
        }
      
        private string _object_file; // Object file to be processed
        private string[] _source_files; // Source file to be processed
        private bool _is_verbose; // Verbose output flag;
        private bool _is_help; // Help flag;
        private bool _is_obj; // Object file flag;
        private bool _is_source; // Source file flag
        private bool _is_debug; // Debugger
        private int _count;
    } // End class CommmandLine
} // end namespace COFT2
