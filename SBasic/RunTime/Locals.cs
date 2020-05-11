using System;
using System.Collections.Generic;
using System.Text;

namespace SBasic.RunTime
{
    class Locals
    {
        /* These are used when allocating arrays. */
        //C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
        //ORIGINAL LINE: #define SB_ARRAY_CHAR_SIZE sizeof(char)
        //C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
        //ORIGINAL LINE: #define SB_ARRAY_FLOAT_SIZE sizeof(double)
        //C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
        //ORIGINAL LINE: #define SB_ARRAY_INTEGER_SIZE sizeof(short)


        /* How big is the Local variable stack? If horrendously recursive calls
         * are made, this should be increased. It's only 32 bits per entry after all.
         * Plus each scope's list of variables of course! */

        /* How long are we allowing a LOCal variable name to be? This
         * is probably more efficient if we keep this to a power of
         * two minus 1. */


        /* How long will a string be, if no size is specified?
         * as in LOCal A$ etc. */


        /* SuperBASIC variable types are converted to C68 variable types. It's
         * best to use the following defines to be sure you have the correct
         * type especially when dealing with pointers to SuperBASIC variables.
         * Ask me how I know! */
        //C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
        //ORIGINAL LINE: #define SB_FLOAT double
        //C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
        //ORIGINAL LINE: #define SB_INTEGER short
        //C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
        //ORIGINAL LINE: #define SB_CHAR char

        /* The following struct is how we hold details of a
         * SuperBASIC LOCal variable.
         *
         * NOTES:
         *
         * 1. The maxLength field holds the total size of the variable's value(s)
         *    which will include additional elements for arrays to replicate the
         *    behaviour in SuperBASIC.
         *    EG. DIM a%(5) allows a$(0) through a%(5). We need one extra element
         *    in C68 to replicate this.
         *
         * 2. arrayDimensions[] holds the number of elements asked for by the user
         *    and does not include the extras added on to replicate SuperBASIC's
         *    array handling behaviour.
         *
         * 3. arrayValue points at the actual string for a LOCal string, or, to a
         *    chunk of allocated memory, maxLength bytes long, for array  types.
         *    This obviously includes the extra elements required.
         */
        public class SBLocalVariable
        {
            public short variableType; // INTEGER, STRING, FLOAT etc
            public string variableName = new string(new char[DefineConstants.MAX_LOCAL_NAME_SIZE +1]); // No comment!
                                                                                                       //C++ TO C# CONVERTER TODO TASK: Unions are not supported in C#:
                                                                                                       //	union variableValue
                                                                                                       //	{ // Union of possible values for this LOCal
                                                                                                       //		short integerValue; // Used if it's an integer
                                                                                                       //		double floatValue; // Guess!
                                                                                                       //		object* arrayValue; // Strings, or any array types
                                                                                                       //	}
                                                                                                       //C++ TO C# CONVERTER NOTE: Access declarations are not available in C#:
                                                                                                       //	variableValue;
            public ushort maxLength; // For strings and arrays only. Total size in bytes, inc extras.
            public short[] arrayDimensions = new short[DefineConstants.SB_ARRAY_MAX_DIMENSIONS - 1]; // For local arrays as per user's request.
        }

        /* The following struct is how we hold details of all
         * SuperBASIC LOCal variables for a PROC or FN, in a
         * linked list. There will be one linked list per scope. */
        public class LocalVariableNode
        {
            public LocalVariableNode next;
            public SBLocalVariable variable = new SBLocalVariable();
        }
    }
}
