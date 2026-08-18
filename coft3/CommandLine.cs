
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using COFT2;

namespace COFT2
{
    /// <summary>
    /// Command Line
    /// </summary>
    public class CommandLine : IDisposable, ICloneable, IEnumerable
    {
        private const int MAX_SOURCE_FILES = 255;
        public CommandLine()
        {
            _object_file = null;
            _source_files = null;

            _object_file = new string("");
            _source_files = new ArrayList();
            _count = 0;

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

        /// <summary>
        /// Dispose of class
        /// </summary>
        public void Dispose()
        {
            _object_file = null;
            _source_files = null;
            _count = 0;
        }

        /// <summary>
        /// Clone the structure
        /// </summary>
        public object Clone()
        {
            return this.+MemberwieClone();
        }

        // refrents count
        public AddRef()
        {
            _count++;
        }

        //////////////////////////////////
        ///  <summary>
        /// Parse the command line arguments and set the approprite flags and values.
        /// </summary>
        /// <param name="cmd"></param>
        public void ParseCommandLine(params string[] cmd)
        {
            if (cmd == null || cmd.Length == 0)
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

                       _is_obj = true;

                        // If verbose then more sturgg
                        if (IsVerbose() == true)
                        {

                            Console.WriteLine("Object.... ");
                            Console.WriteLine("Object File = {0}", _object_file);
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

        /// <summary>
        /// GetCount: Ger counder
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return _count;
        }

        ///////////////////////////////////////////////////////
        /// <summary>
        /// *** Properies ***
        /// </summary>
        public string ObjectFile
        {
            get { return _object_file; }
        }

        // Get sourcw file
        public void Add(string file)
        {
            _AddRef();
            __cmd_line.Insert(file);
        }

        // Get the object file
        public string Get(int index)
        {
            return _cmd_line._source_files[i];
        }

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
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

        public Count
        {
            get { return _count; }
        }

        public string this [int index]
            {
                set{_source_files.Insert(index, value); }
            get{ return _source_files[index]; }
                
                


            
        private string _object_file; // Object file to be processed
        private ArrayList _source_files; // Source file to be processed
        private bool _is_verbose; // Verbose output flag;
        private bool _is_help; // Help flag;
        private bool _is_obj; // Object file flag;
        private bool _is_source; // Source file flag
        private int _count; // Count of source files
    } // End class CommmandLine
} // end namespace COFT2
