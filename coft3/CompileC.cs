using COFT2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;

namespace COFT2
{
    /// <summary>
    /// Compiler in  C
    /// </summary>
   public class CompileC
    {
        public CompileC(CommandLine cmdLine)
        {
            _cmd_line = cmdLine;

            _keywords = new string;

            _keywords.AddRange(new string[] {
              "auto", "break", "case", "char", "const", "continue", "default", "do", "double",
            "else", "enum", "extern", "float", "for", "goto", "if", "inline", "int", "long", "register",
            "restrict", "return", "short", "signed", "sizeof", "static", "struct", "switch", "typedef",
            "union", "unsigned", "void", "volatile", "while", "_Alignas", "_Alignof", "_Atomic",
            "_Bool", "_Complex", "_Decimal128", "_Decimal32",
            "_Decimal64", "_Genric", "_Imaginary", "_Noreturn", "_Static_assert", "_Thread_local"
            });

            _keys = KEYWORDS._NONE;

            _cmd_line = cmdLine;
            
        }

        /// <summary>
        /// Run the C compiler
        /// </summary>
        /// 
        public int Run()
        {
            // Look fo errors
            if (_cmd_line == null)
            {
                Console.WriteLine("FATAL ERROR: Not expecting the command line to be null");
                return 2;
            }
      
            if (_cmd_line.ObjectFile == null || _cmd_line.ObjectFile == "")
            {
                Console.WriteLine("FATAL E#RROR: No object file");
                return 2;
            }


            FileStream fs = File.OpenWrite(_cmd_line.ObjectFile);

            if (fs == null)
            {
                Console.WriteLine("FATAL ERROR: Can't open {0}");
                return 2;
            }

            // Open souurce file
            for (int index = 0; index <= _cmd_line.Count; index++)
            {
                string source = _cmd_line.Get(index);

                // Open Text
                StreamReader fi = File.OpenText(source);
            
                // Check the file
                if (fi == null)
                {
                   Console.WriteLine("FATAL ERROR: Can't openm the source file");
                   return 2;
                }
          
                fi.Close();
            }

            // Close file
            fs.Close();

            // Return
            return 0;
            
        }

        /////////////////////////////////////////////
        // Propetyies
        /////////////////////////////////////////////
        public KEYWORDS Keyword
        {
            set
            {
                _keys = value;
            }

            get
            {
                return _keys;
            }
        }

        public enum KEYWORDS
        {
            AUTO,
            BREAK,  
            CASE,
            CHAR,
            CONST,
            CONTINUE,
            DEFAULT,
            DO,
            DOUBLE,
            ELSE,
            ENUM,
            EXTERN,
            FLOAT,
            FOR,
            GOTO,
            IF,
            INLINE,
            INT,
            LONG,
            REGISTER,
            RETURN,
            SHORT,
            SIGNED,
            SIZEOF,
            STATIC,
            SWITCH,
            TYPEDEF,
            UNION,
            UNSIGNED,
            VOID,
            VOLITILE,
            WHILE,
            _ALIGNAS,
            _ALIGNOF,
            _ATOMIC,
            _BOOL,
            _COMPLEX,
            _DECIMAL128,
            _DECIMAL32,
            _DECIMAL64,
            _GENERIC,
            _IMAGINARY,
            _NORETURN,
            _STATIC_ASSERT,
            _THREAD_LOCAL,
            _NONE
        };

        private KEYWORDS _keys;
        private readonly List<string> _keywords;
        private readonly CommandLine _cmd_line;
    }
}
