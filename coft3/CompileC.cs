using COFT2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;


namespace COFT2
{
    /// <summary>
    /// Compiler in  C
    /// </summary>
   public class CompileC
    {
        public CompileC()
        {
            _keywords = null;
            
            _keywords = new List<string>();
            _keywords.AddRange(new string[] {
              "auto", "break", "case", "char", "const", "continue", "default", "do", "double",
            "else", "enum", "extern", "float", "for", "goto", "if", "inline", "int", "long", "register",
            "restrict", "return", "short", "signed", "sizeof", "static", "struct", "switch", "typedef",
            "union", "unsigned", "void", "volatile", "while", "_Alignas", "_Alignof", "_Atomic",
            "_Bool", "_Complex", "_Decimal128", "_Decimal32",
            "_Decimal64", "_Genric", "_Imaginary", "_Noreturn", "_Static_assert", "_Thread_local"
            });

            _keys = KEYWORDS._NONE;


            
        }

        /// <summary>
        /// Run the C compiler
        /// </summary>

        /////////////////////////////////////////////
        // Propetyies
        /////////////////////////////////////////////
        KEYWORDS Keyword
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

        private enum KEYWORDS
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
            _Decimal64,
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
