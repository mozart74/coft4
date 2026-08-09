
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using COFT2;

namespace COFT2
{
    public class CommandLine
    {
        public CommandLine()
        {
            Stack<string> _source_file = new Stack<string>();


            _object_file = "";
            _is_verbose = new bool();
            _is_help = new bool();
            _is_obj = new bool();
            _is_source = new bool();

            _object_file = new string("");

            _is_source = false;
            _is_verbose = false;
            _is_help = false;
            _is_obj = false;
        }


        //////////////////////////////////
        ///  <summary>
        /// Parse the command line arguments and set the approprite flags and values.
        /// </summary>
        /// <param name="cmd"></param>
        public void ParseCommandLine(params string[] cmd)
        {
            if (cmd == null)
            {
                _is_help = true;
                Usage();

            }
            else
            {
                foreach (string i in cmd)
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

                    }
                    else if (i.EndsWith(".obj") == true) // If obj then compile obj
                    {

                        this._is_obj = true;

                        // If verbose then more sturgg
                        if (this._is_verbose == true)
                            Console.WriteLine("Object.... ");

                        this._object_file = i;

                        if (this._is_verbose == true)
                        {
                            Console.WriteLine("Object File = {0}", _object_file);
                        }
                    }
                    else if (i.EndsWith(".c") == true || i.EndsWith(".cpp") == true)
                    {
                        if (_is_verbose == true)
                        {
                            Console.WriteLine("Compiling... {0}", i);
                        }

                        _is_source = true;

                        this.SourceFiles =  i;

                    }
                    // End if
                    else
                    {
                        Console.WriteLine("Unknown command line argument: {0}", i);
                        _is_help = true;
                        Usage();
                    } // End if
                } // End foreach
            } // END IF
        } // end ParseCommandLines




        //////////////////////////////////////////////////////////////
        /// <summury>
        /// Method to display the usage of the program.
        /// </summury>
        //////////////////////////////////////////////////////////////
        public static void Usage()
        {
            Console.WriteLine("coft2 - A C/C++ compiler suite for applications");
            Console.WriteLine("Copyright (c) 2026 KIA. All rights reserved.");
            Console.WriteLine("Licensed under the GPLv3 License. See LICENSE file in the project");
            Console.WriteLine(" ");
            Console.WriteLine("USAGE: coft2 [options] <object_file> <source_files");
            Console.WriteLine("options:");
            Console.WriteLine("\t-v, --verbose = Verbose output");
            Console.WriteLine("\t-h, --help = Display this help message");
            Console.WriteLine("\t<object_file>=.obj>");
            Console.WriteLine("\t<>=.c.cpps <souce_files>...");
        }

        ///////////////////////////////////////////////////////
        /// <summary>
        /// *** Properies ***
        /// </summary>
        public string ObjectFile
        {
            get { return _object_file; }
        }

        public bool IsVerbose
        {
            get { return _is_verbose; }
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

        public string SourceFiles
        {
            get
            {
                
            }
            set
            {
                _source_file.Push(value);
            }
        }

        private string _object_file; // Object file to be processed
        private stack<string> _source_file // Source files to be proccessed
        private bool _is_verbose; // Verbose output flag;
        private bool _is_help; // Help flag;
        private bool _is_obj; // Object file flag;
        private bool _is_source; // Source file flag
    } // End class CommmandLine
} // end namespace COFT2
