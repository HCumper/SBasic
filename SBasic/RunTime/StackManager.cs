using System;
using System.Collections.Generic;
using System.Text;
using static SBasic.RunTime.Locals;

namespace SBasic.RunTime
{
    static class StackManager
	{
		public const int SBLOCAL_UNDEFINED = 0;
		public const int SBLOCAL_INTEGER = 1;
		public const int SBLOCAL_FLOAT = 2;
		public const int SBLOCAL_STRING = 3;
		public const int SBLOCAL_INTEGER_ARRAY = 4;
		public const int SBLOCAL_FLOAT_ARRAY = 5;
		public const int SBLOCAL_STRING_ARRAY = 6;
		public const int SB_ARRAY_MAX_DIMENSIONS = 5; // LOCAL A%(n,n,n,n,n) maximum.
		public const int MAX_STACK_DEPTH = 2048;
		public const int MAX_LOCAL_NAME_SIZE = 31;
		public const int SB_DEFAULT_STRING_LENGTH = 100;
		public const int ERR_NC = -1; // Operation not complete.
		public const int ERR_NJ = -2; // Not a (valid) job.
		public const int ERR_OM = -3; // Out of memory.
		public const int ERR_OR = -4; // Out of range.
		public const int ERR_BO = -5; // Buffer overflow.
		public const int ERR_NO = -6; // Channel not open.
		public const int ERR_NF = -7; // File or device not found.
		public const int ERR_EX = -8; // File already exists.
		public const int ERR_IU = -9; // File or device already in use.
		public const int ERR_EF = -10; // End of file.
		public const int ERR_DF = -11; // Drive full.
		public const int ERR_BN = -12; // Bad device.
		public const int ERR_TE = -13; // Transmission error.
		public const int ERR_FF = -14; // Format failed.
		public const int ERR_BP = -15; // Bad parameter.
		public const int ERR_FE = -16; // File error.
		public const int ERR_IE = -17; // Expression error.
		public const int ERR_OV = -18; // Arithmetic overflow.
		public const int ERR_NI = -19; // Not implemented.
		public const int ERR_RO = -20; // Read only.
		public const int ERR_BL = -21; // Bad line of Basic.

		/*
		 * This is a dummy "main.c" file to ensure that  the code in SBLocal.c compiles ok.
		 * and can be called. The real tests are to be found in the TESTS directory, elsewhere.
		 */
		internal static void notmain()
		{
			LocalVariableNode mainScope = beginScope();
			Console.Write("Testing, testing, 1, 2, 3!\n\n");
			//C++ TO C# CONVERTER TODO TASK: The following line has a C format specifier which cannot be directly translated to C#:
			//ORIGINAL LINE: printf("mainScope is at %p.\n", mainScope);
			Console.Write("mainScope is at %p.\n", mainScope);
			Console.Write("\nTesting Complete.\n\n");
			endCurrentScope();
		}


		/* What type do we have for our LOCal variables? */
		/* The rest are arrays, and use pointers. */


		/* Used to translate the above into actual SuperBASIC types. */
		internal static string[] sblocal_types = {"Undefined", "Integer", "Floating Point", "String", "Integer Array", "Floating Point Array", "String Array"};

		/* Retrieve the INTEGER value for a particular Local Variable from the most
		 * recent scope. */
		public static int getSBLocalVariable_i(LocalVariableNode variable)
		{
			int result = 0;

			if (variable != null)
			{
				if (variable.variable.variableType == SBLOCAL_INTEGER)
				{
					result = variable.variable.variableValue_Renamed.integerValue;
				}
				else
				{
					Console.Error.Write("getSBLocalVariable_i(): Incompatible variable types.\n");
					Console.Error.Write("\tExpected: {0}. Found: {1}.\n", sblocal_types[SBLOCAL_INTEGER], sblocal_types[variable.variable.variableType]);
					Environment.Exit(ERR_BP);
				}
			}
			else
			{
				Console.Error.Write("getSBLocalVariable_i(): Unknown Local Integer Variable.\n");
				Environment.Exit(ERR_NF);
			}
			return result;
		}

		/* Retrieve the STRING value for a particular Local Variable from the most
		 * recent scope. */
		public static string getSBLocalVariable_s(LocalVariableNode variable)
		{
			string result = null;

			if (variable != null)
			{
				if (variable.variable.variableType == SBLOCAL_STRING)
				{
					result = (string)variable.variable.variableValue_Renamed.arrayValue;
				}
				else
				{
					Console.Error.Write("getSBLocalVariable_s(): Incompatible variable types.\n");
					Console.Error.Write("\tExpected: {0}. Found: {1}.\n", sblocal_types[SBLOCAL_STRING], sblocal_types[variable.variable.variableType]);
					Environment.Exit(ERR_BP);
				}
			}
			else
			{
				Console.Error.Write("getSBLocalVariable_s(): Unknown Local String Variable.\n");
				Environment.Exit(ERR_NF);
			}
			return result;
		}

		/* Change the FP value for a particular Local Variable in the most
		 * recent scope. */

		/* Change the value for a particular Local Variable in the most
		 * recent scope. */
		public static void setSBLocalVariable(LocalVariableNode variable, double newValue)
		{
			if (variable != null)
			{
				if (variable.variable.variableType == SBLOCAL_FLOAT)
				{
					variable.variable.variableValue_Renamed.floatValue = newValue;
				}
				else
				{
					Console.Error.Write("setSBLocalVariable(): Incompatible variable types.\n");
					Environment.Exit(ERR_BP);
				}
			}
			else
			{
				Console.Error.Write("setSBLocalVariable(): Unknown Local Floating Point Variable.\n");
				Environment.Exit(ERR_NF);
			}
		}

		/* Change the INTEGER value for a particular Local Variable in the most
		 * recent scope. */
		public static void setSBLocalVariable_i(LocalVariableNode variable, int newValue)
		{
			if (variable != null)
			{
				if (variable.variable.variableType == SBLOCAL_INTEGER)
				{
					variable.variable.variableValue_Renamed.integerValue = newValue;
				}
				else
				{
					Console.Error.Write("setSBLocalVariable_i(): Incompatible variable types.\n");
					Environment.Exit(ERR_BP);
				}
			}
			else
			{
				Console.Error.Write("setSBLocalVariable_i(): Unknown Local Integer Variable.\n");
				Environment.Exit(ERR_NF);
			}
		}

		/* Change the STRING value for a particular Local Variable in the most
		 * recent scope. */
		public static void setSBLocalVariable_s(LocalVariableNode variable, ref string newValue)
		{

			string temp;

			if (variable != null)
			{
				/* BE VERY CAREFUL!!!!!!!!!
				 * Strings, in C, can be quite evil.
				 * We must use strncpy() to limit the size of data copied to
				 * the maximum size that the string allows. Otherwise, we could
				 * blat through other data that we need. Buffer overruns anyone? */
				if (variable.variable.variableType == SBLOCAL_STRING)
				{

					temp = (string)variable.variable.variableValue_Renamed.arrayValue;
					/* printf("setSBLocalVariable_s(): setting array at %p max %d\n", temp, variable->variable.maxLength); */

					/* Can we fit all of the new value in? */
					if (newValue.Length <= variable.variable.maxLength)
					{
						/* Yes we can. strcpy() will terminate with a '\0' */
						temp = newValue;
					}
					else
					{
						/* No, we must truncate the new value. strncpy() will
						 * not terminate with a '\0' */
						temp = newValue.Substring(0, variable.variable.maxLength);
						temp = StringFunctions.ChangeCharacter(temp, variable.variable.maxLength, '\0');
					}
				}
				else
				{
					Console.Error.Write("setSBLocalVariable_s(): Incompatible variable types.\n");
					Environment.Exit(ERR_BP);
				}
			}
			else
			{
				Console.Error.Write("setSBLocalVariable_s(): Unknown Local String Variable.\n");
				Environment.Exit(ERR_NF);
			}
		}

		/* Starts a new scope and returns the root pointer. This MUST be called
		 * on entry to any PROCedure or FuNction with LOCal variables. */

		/* Starts a new scope and returns the root pointer. */
		public static LocalVariableNode beginScope()
		{
			LocalVariableNode temp = createNode();

			if (temp == null)
			{
				Console.Error.Write("beginScope(): Out of memory\n");
				Environment.Exit(ERR_OM);
			}

			/* Name this root, as root. */
			temp.variable.variableName = "**ROOT**";

			/* Stack the (new) current scope; */
			pushSBLocalScope(temp);
			return temp;
		}

		/* Ends the current scope and deletes the items and root node. This MUST be
		 * called just before exiting from a PROCedure or FuNction with LOCal variables.
		 * WARNING: PROCedures or FuNctions with multiple exit points will be nasty! */

		/* Ends the current scope and deletes the items and root node. */
		public static void endCurrentScope()
		{
			/* Get the current scope which is about to end. */
			LocalVariableNode temp = popSBLocalScope();
			if (temp != null)
			{
				deleteNode(temp);
			}
		}

		/* Create a new local variable and add to the current scope.
		 * This is called directly for new local integers or floats
		 * but indirectly for strings and arrays. See SBLocal.h for details. */

		/* Create a new local variable and add to the current scope. */
		public static LocalVariableNode newLocal(int variableType, ref string variableName)
		{
			/* Allocate a new node for this variable. */

			int nameSize = variableName.Length;
			int copySize = new int(nameSize);
			LocalVariableNode root;
			int dimn;

			/* If we can't create a node, bale out. */
			LocalVariableNode temp = createNode();
			if (temp == null)
			{
				Console.Write("newLocal(): Out of memory.n");
				Environment.Exit(ERR_OM);
			}

			/* Initialise the new node. */
			temp.variable.variableType = variableType;

			if (nameSize > MAX_LOCAL_NAME_SIZE)
			{
				Console.Write("newLocal(): Variable name '{0}' too long. Only {1:D} characters will be used.\n", variableName, MAX_LOCAL_NAME_SIZE);
				copySize = MAX_LOCAL_NAME_SIZE;
			}

			if (copySize != null)
			{
				temp.variable.variableName = variableName.Substring(0, copySize);
				temp.variable.variableName = StringFunctions.ChangeCharacter(temp.variable.variableName, copySize, '\0');
			}
			else
			{
				/* This is done in createNode, but safety! */
				temp.variable.variableName = StringFunctions.ChangeCharacter(temp.variable.variableName, 0, '\0');
			}

			switch (variableType)
			{
				case SBLOCAL_FLOAT:
					temp.variable.variableValue_Renamed.floatValue = 0.0;
					break;

				case SBLOCAL_INTEGER:
					temp.variable.variableValue_Renamed.integerValue = 0;
					break;

				case SBLOCAL_STRING:
				case SBLOCAL_FLOAT_ARRAY:
				case SBLOCAL_INTEGER_ARRAY:
				case SBLOCAL_STRING_ARRAY:
					temp.variable.variableValue_Renamed.arrayValue = null;
					temp.variable.maxLength = 0;
					break;

				default:
					Console.Write("newLocal(): Unimplemented variable type for variable '{0}'.\n", variableName);
					break;
			}

			/* Initialise the array dimensions to -1. */
			for (dimn = 0; dimn < SB_ARRAY_MAX_DIMENSIONS; dimn++)
			{
				temp.variable.arrayDimensions[dimn] = -1;
			}

			/* Add the new node to the current scope. */
			root = peekSBLocalScope();
			temp.next = root.next;
			root.next = temp;

			return temp;
		}

		/* Create a new local STRING variable and add to the current scope. Calls newLocal
		 * to get an allocation for the SBLOCAL struct and then allocates an additional
		 * space for the string contents.
		 */

		/* Create a new local string of a specific length. */
		public static LocalVariableNode newLocalString(ref string variableName, int stringLength)
		{

			/* Allocate a new SBLOCAL and then some space for a string's contents */
			/* Returns, or exits on error */
			LocalVariableNode temp = newLocal(SBLOCAL_STRING, ref variableName);
			int newSize = stringLength;

			/* Check and set the required (maximum) string length. */
			if (newSize == 0)
			{
				/* Set a default string size */
				newSize = SB_DEFAULT_STRING_LENGTH;
			}
			temp.variable.maxLength = newSize;

			/* Allocate the string plus two - die horribly if we can't.
			 * Why 2? One for the terminator and one because SuperBASIC strings
			 * count from index 1. */
			temp.variable.variableValue_Renamed.arrayValue = createArray(newSize + 2);
			if (!temp.variable.variableValue_Renamed.arrayValue)
			{
				Console.Error.Write("newLocalString(): Out of memory.n");
				Environment.Exit(ERR_OM);
			}

			return temp;
		}

		/* Create a new SBLOCAL and some space for a multi-dimensional array.
		 * This will be called with a variable number of parameters to determine
		 * the various dimensions of the array, but given how C68 arrays work, the
		 * actual space will be allocated as if it was a huge single dimension of
		 * the required type.
		 *
		 * Also, because a SuperBASIC (non-string) array can index from 0 or 1
		 * then we have to add one on to each dimension. For example,
		 * LOCal A%(5) can index a%(0) through A%(5) which is 6 actual elements.
		 * C68 has to replicate this. This also applies to every dimension. */

		/* Create a new local array of a specific length. */
		public static LocalVariableNode newLocalArray(ref string variableName, int variableType, params object[] LegacyParamArray)
		{

			/* Allocate a new SBLOCAL and then some space for a string's contents */
			/* Returns, or exits on error */
			LocalVariableNode temp = newLocal(variableType, ref variableName);

			int totalSize = 0; // Total bytes required.
			int extraCapacity = 1; // Extra elements per dimension.
			int thisDimension = 0; // Size of this dimension.
									 //	va_list args; // Variable arguments.
			object ptr; // Pointer to initialise arrays.
			int x; // Loop for initialisation.
			int dimn; // Index into the arrayDimensions table.
			object baseAddress; // Base address of allocated RAM for the array.

			/* Get our byte multiplier for later memory allocation. */
			switch (variableType)
			{
				/* Integers are 2 bytes (ints) normally. */
				case SBLOCAL_INTEGER_ARRAY:
					totalSize = sizeof(int);
					break;

				/* Floats are 8 bytes, usually. */
				case SBLOCAL_FLOAT_ARRAY:
					totalSize = sizeof(double);
					break;

				/* Strings need one extra plus a terminator, so two. */
				case SBLOCAL_STRING_ARRAY:
					totalSize = sizeof(char);
					extraCapacity = 2;
					break;

				default:
					Console.Error.Write("newLocalArray(): Unrecognised array type. ({0:D})\n", variableType);
					Console.Error.Write("newLocalArray(): Array creation ignored.");
					return null;
			}

			/* Scan the variable arguments to calculate the total bytes required to
			 * allocate the array, and any extra elements required to emulate SuperBASIC. */
			int ParamCount = -1;
			//	va_start(args, variableType);
			dimn = 0;

			do
			{
				/* Although the arguments are 'int', those get promoted to
				 * 'int', so I have to go up in steps of int, not int. */
				ParamCount++;
				thisDimension = (int)LegacyParamArray[ParamCount];

				/* Any negative value ends the list. */
				if (thisDimension < 0)
				{
					break;
				}

				/* Update the arrayDimensions table with this requested dimension. */
				temp.variable.arrayDimensions[dimn++] = thisDimension;

				/* Add on the extra capacity required, per dimension. What this means is that
				 * while arrayDimensions[dimn] says how much the user asked for, we give an
				 * extra element or two for the variable type to allow complete emulation of
				 * SuperBASIC LOCal variables. */
				thisDimension += extraCapacity;

				/* Accumulate the byte count for the array.
				 * Because we started with totalSize = the size of one element
				 * this code 'just works' and allocates the desired number of bytes. */
				totalSize *= thisDimension;
			} while (1 != 0);

			/* Don't forget this bit! */
			//	va_end(args);

			/* We now have the correct number of bytes required to allocate an array
			 * of the requested type and with enough extra elements to cater for any
			 * terminators etc to match the behaviour of SuperBASIC. */

			/* Set the required (maximum) array length. This is in bytes not elements. */
			temp.variable.maxLength = totalSize;

			/* Allocate some RAM for the array. */
			baseAddress = createArray(totalSize);

			if (baseAddress == null)
			{
				Console.Error.Write("newLocalArray(): Out of memory.n");
				Environment.Exit(ERR_OM);
			}

			/* All ok, store the base address. */
			temp.variable.variableValue_Renamed.arrayValue = baseAddress;

			/* We have to initialise FLOAT and INTEGER arrays to 0. */
			/* Start with a pointer to the data area. */
			ptr = baseAddress;

			/* Then work out how many elements we have. */
			switch (variableType)
			{
				case SBLOCAL_INTEGER_ARRAY:
					for (x = 0; x < totalSize / sizeof(int); x++)
					{
						(int)ptr = null;
						ptr += sizeof(int);
					}
					break;

				/* Floats are 8 bytes, usually. */
				case SBLOCAL_FLOAT_ARRAY:
					for (x = 0; x < totalSize / sizeof(double); x++)
					{
						(double)ptr = 0.0;
						ptr += sizeof(double);
					}
					break;
			}

			/* Finally, after all that, send the new SBLOCAL back to the caller. */
			return temp;
		}

		/* Fetch scope from the stack at the given level. 0 = oldest scope. */

		/* Fetch any scope's root node from the stack. */
		public static LocalVariableNode peekSBLocalScopeLevel(int level)
		{
			if (level > MAX_STACK_DEPTH)
			{
				Console.Error.Write("peekSBLocalScopeLevel(): Level ({0:D}) too deep.\n", level);
				Environment.Exit(ERR_OV);
			}

			/* This returns NULL if we go deeper than first scope level. */
			return SBLocalStack[level];
		}

		/* Return a pointer to the most recent scope for a particular
		 * local variable. Scans backwards through the nested scopes
		 * until we find it, or not. */

		/* Return a pointer to the most recent scope for a particular
		 * local variable. */
		public static LocalVariableNode findSBLocalVariableByName(ref string variableName)
		{
			LocalVariableNode thisScope;
			LocalVariableNode thisRoot;
			int tempSP = stackPointer - 1; // Current Scope pointer;

			/* Loop through all the scopes in reverse order. */
			while (tempSP >= 0)
			{
				thisRoot = SBLocalStack[tempSP];
				/* Does this scope have any LOCals defined yet> */
				if (thisRoot.next == null)
				{
					continue;
				}

				/* We must have some LOCals then. */
				thisScope = thisRoot.next;
				while (thisScope != null)
				{
					/* Walk the variable list. */
					if (string.Compare(variableName, 0, thisScope.variable.variableName, 0, MAX_LOCAL_NAME_SIZE) == 0)
					{
						/* We have out variable. */
						return thisScope;
					}

					/* Point at the next variable. */
					thisScope = thisScope.next;
				}

				/* Not found in this scope? Try the previous one. */
				tempSP--;
			}

			/* We did not find it. */
			Console.Error.Write("findSBLocalVariable(): Variable '{0}' not found.\n", variableName);
			Environment.Exit(ERR_NF);
			return null;
		}

		/* Return an integer description of a LOCal variable type */

		/* Return an integer description of a LOCal variable type */
		public static int getSBLocalVariableType(LocalVariableNode variable)
		{
			if (variable != null)
			{
				return variable.variable.variableType;
			}
			else
			{
				Console.Error.Write("getSBLocalVariableType(): Unknown Local Variable.\n");
				return 0;
			}
		}

		/* Return a textual description of a LOCal variable type */

		/* Return a textual description of a LOCal variable type */
		public static string getSBLocalVariableTypeName(LocalVariableNode variable)
		{
			if (variable != null)
			{
				if (variable.variable.variableType <= max_sblocal_type)
				{
					return sblocal_types[variable.variable.variableType];
				}
				else
				{
					Console.Error.Write("getSBLocalVariableTypeName(): Variable type, {0:D}, bigger than maximum, {1:D}.\n", variable.variable.variableType, max_sblocal_type);
					Environment.Exit(ERR_BP);
				}
			}
			else
			{
				Console.Error.Write("getSBLocalVariableTypeName(): Unknown Local Variable.\n");
				Environment.Exit(ERR_NF);
			}
		}

		/* Fetch an element from an Integer Array on any number of dimensions. */

		/* Return an INTEGER array element */
		public static int getArrayElement_i(LocalVariableNode variable, params object[] LegacyParamArray)
		{
			//	va_list args;
			int offset = 0;
			//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
			//ORIGINAL LINE: int *iPtr;
			int iPtr;

			/* Do we actually have an integer array? */
			if (variable.variable.variableType != SBLOCAL_INTEGER_ARRAY)
			{
				Console.Error.Write("getArrayElement_i(): Variable '{0}' is not an integer array.\n", variable.variable.variableName);
				return 0;
			}

			int ParamCount = -1;
			//	va_start(args, variable);
			offset = getArrayOffset(variable, new va_list(args));
			//	va_end(args);

			if (offset < 0)
			{
				Console.Error.Write("getArrayElement_i(): Array {0}, subscript out of range.\n", variable.variable.variableName);
				Environment.Exit(ERR_OR);
			}

			/*
			 * We now have an offset representing the number of elements.
			 * Fetch the array pointer from the variable, and manipulate it!
			 */
			iPtr = (int)variable.variable.variableValue_Renamed.arrayValue;
			return (iPtr[offset]);
		}

		/* Set an Integer Array element, on any number of dimensions. */

		/* Set an Integer Array element, on any number of dimensions. */
		public static void setArrayElement_i(LocalVariableNode variable, int newValue, params object[] LegacyParamArray)
		{
			//	va_list args;
			int offset = 1;
			int thisDimension;
			//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
			//ORIGINAL LINE: int *iPtr;
			int iPtr;

			/* Do we actually have an integer array? */
			if (variable.variable.variableType != SBLOCAL_INTEGER_ARRAY)
			{
				Console.Error.Write("setArrayElement_i(): Variable '{0}' is not an integer array.\n", variable.variable.variableName);
				return;
			}

			int ParamCount = -1;
			//	va_start(args, newValue);
			offset = getArrayOffset(variable, new va_list(args));
			//	va_end(args);


			/* Are we in range? */
			if (offset < 0)
			{
				Console.Error.Write("setArrayElement_i(): Array {0}, subscript out of range.\n", variable.variable.variableName);
				Environment.Exit(ERR_OR);
			}


			/*
			 * We now have an offset representing the number of elements.
			 * Fetch the array pointer from the variable, and manipulate it!
			 */
			iPtr = (int)variable.variable.variableValue_Renamed.arrayValue;
			iPtr[offset] = newValue;
		}

		/* Fetch an element from an Integer Array on any number of dimensions. */

		/* Return an FLOAT array element */
		public static double getArrayElement(LocalVariableNode variable, params object[] LegacyParamArray)
		{
			//	va_list args;
			int offset = 1;
			int thisDimension;
			//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
			//ORIGINAL LINE: double *fPtr;
			double fPtr;

			/* Do we actually have an integer array? */
			if (variable.variable.variableType != SBLOCAL_FLOAT_ARRAY)
			{
				Console.Error.Write("getArrayElement(): Variable '{0}' is not a floating point array.\n", variable.variable.variableName);
				return 0.0;
			}

			int ParamCount = -1;
			//	va_start(args, variable);
			offset = getArrayOffset(variable, new va_list(args));
			//	va_end(args);

			/* Are we in range? */
			if (offset < 0)
			{
				Console.Error.Write("setArrayElement(): Array {0}, subscript out of range.\n", variable.variable.variableName);
				Environment.Exit(ERR_OR);
			}

			/*
			 * We now have an offset representing the number of elements.
			 * Fetch the array pointer from the variable, and manipulate it!
			 */
			fPtr = (double)variable.variable.variableValue_Renamed.arrayValue;
			return (fPtr[offset]);
		}

		/* Set a Floating Point Array element, on any number of dimensions. */

		/* Set an FLOAT Array element, on any number of dimensions. */
		public static void setArrayElement(LocalVariableNode variable, double newValue, params object[] LegacyParamArray)
		{
			//	va_list args;
			int offset = 1;
			int thisDimension;
			//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
			//ORIGINAL LINE: double *fPtr;
			double fPtr;

			/* Do we actually have an FP array? */
			if (variable.variable.variableType != SBLOCAL_FLOAT_ARRAY)
			{
				Console.Error.Write("setArrayElement(): Variable '{0}' is not a floating point array.\n", variable.variable.variableName);
				Environment.Exit(ERR_BP);
			}

			int ParamCount = -1;
			//	va_start(args, newValue);
			offset = getArrayOffset(variable, new va_list(args));
			//	va_end(args);

			/* Are we in range? */
			if (offset < 0)
			{
				Console.Error.Write("setArrayElement(): Array {0}, subscript out of range.\n", variable.variable.variableName);
				Environment.Exit(ERR_OR);
			}

			/*
			 * We now have an offset representing the number of elements.
			 * Fetch the array pointer from the variable, and manipulate it!
			 */
			fPtr = (double)variable.variable.variableValue_Renamed.arrayValue;
			fPtr[offset] = newValue;
		}

		/* Push a root pointer to a linked list of local variables onto the
		 * scope stack. */



		/* Some defines to make things a little easier, maybe! */
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_INTEGER(v) newLocal(SBLOCAL_INTEGER, (v))
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_FLOAT(v) newLocal(SBLOCAL_FLOAT, (v))

		/* The rest are pointer based and have sizes attached. */
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_STRING(v, s) newLocalString((v), (s))

		/* Oh, how I wish we had ANSI compliance! (Variable parameter macros!)
		 *
		 * The following are defined as deep as SB_ARRAY_MAX_DIMENSIONS which is defined
		 * above. If you need to make that 6, for example, you MUST add an extra definition
		 * for LOCAL_ARRAY_INTEGER6 and so on below, as well as changing getArrayOffset().
		 */
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_ARRAY_INTEGER(v, d1) newLocalArray((v), SBLOCAL_INTEGER_ARRAY, (d1), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_ARRAY_INTEGER2(v, d1, d2) newLocalArray((v), SBLOCAL_INTEGER_ARRAY, (d1), (d2), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_ARRAY_INTEGER3(v, d1, d2, d3) newLocalArray((v), SBLOCAL_INTEGER_ARRAY, (d1), (d2), (d3), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_ARRAY_INTEGER4(v, d1, d2, d3, d4) newLocalArray((v), SBLOCAL_INTEGER_ARRAY, (d1), (d2), (d3), (d4), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_ARRAY_INTEGER5(v, d1, d2, d3, d4, d5) newLocalArray((v), SBLOCAL_INTEGER_ARRAY, (d1), (d2), (d3), (d4), (d5), -1)

		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define GET_INTEGER_ELEMENT(v, d1) getArrayElement_i(findSBLocalVariableByName((v)), (d1), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define GET_INTEGER_ELEMENT2(v, d1, d2) getArrayElement_i(findSBLocalVariableByName((v)), (d1), (d2), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define GET_INTEGER_ELEMENT3(v, d1, d2, d3) getArrayElement_i(findSBLocalVariableByName((v)), (d1), (d2), (d3), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define GET_INTEGER_ELEMENT4(v, d1, d2, d3, d4) getArrayElement_i(findSBLocalVariableByName((v)), (d1), (d2), (d3), (d4), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define GET_INTEGER_ELEMENT5(v, d1, d2, d3, d4, d5) getArrayElement_i(findSBLocalVariableByName((v)), (d1), (d2), (d3), (d4), (d5), -1)

		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define SET_INTEGER_ELEMENT(v, d1, nv) setArrayElement_i(findSBLocalVariableByName((v)), (nv), (d1), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define SET_INTEGER_ELEMENT2(v, d1, d2, nv) setArrayElement_i(findSBLocalVariableByName((v)), (nv), (d1), (d2), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define SET_INTEGER_ELEMENT3(v, d1, d2, d3, nv) setArrayElement_i(findSBLocalVariableByName((v)), (nv), (d1), (d2), (d3), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define SET_INTEGER_ELEMENT4(v, d1, d2, d3, d4, nv) setArrayElement_i(findSBLocalVariableByName((v)), (nv), (d1), (d2), (d3), (d4), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define SET_INTEGER_ELEMENT5(v, d1, d2, d3, d4, d5, nv) setArrayElement_i(findSBLocalVariableByName((v)), (nv), (d1), (d2), (d3), (d4), (d5), -1)

		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_ARRAY_FLOAT(v, d1) newLocalArray((v), SBLOCAL_FLOAT_ARRAY, (d1), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_ARRAY_FLOAT2(v, d1, d2) newLocalArray((v), SBLOCAL_FLOAT_ARRAY, (d1), (d2), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_ARRAY_FLOAT3(v, d1, d2, d3) newLocalArray((v), SBLOCAL_FLOAT_ARRAY, (d1), (d2), (d3), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_ARRAY_FLOAT4(v, d1, d2, d3, d4) newLocalArray((v), SBLOCAL_FLOAT_ARRAY, (d1), (d2), (d3), (d4), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_ARRAY_FLOAT5(v, d1, d2, d3, d4, d5) newLocalArray((v), SBLOCAL_FLOAT_ARRAY, (d1), (d2), (d3), (d4), (d5), -1)

		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define GET_FLOAT_ELEMENT(v, d1) getArrayElement(findSBLocalVariableByName((v)), (d1), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define GET_FLOAT_ELEMENT2(v, d1, d2) getArrayElement(findSBLocalVariableByName((v)), (d1), (d2), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define GET_FLOAT_ELEMENT3(v, d1, d2, d3) getArrayElement(findSBLocalVariableByName((v)), (d1), (d2), (d3), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define GET_FLOAT_ELEMENT4(v, d1, d2, d3, d4) getArrayElement(findSBLocalVariableByName((v)), (d1), (d2), (d3), (d4), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define GET_FLOAT_ELEMENT5(v, d1, d2, d3, d4, d5) getArrayElement(findSBLocalVariableByName((v)), (d1), (d2), (d3), (d4), (d5), -1)

		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define SET_FLOAT_ELEMENT(v, d1, nv) setArrayElement(findSBLocalVariableByName((v)), (nv), (d1), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define SET_FLOAT_ELEMENT2(v, d1, d2, nv) setArrayElement(findSBLocalVariableByName((v)), (nv), (d1), (d2), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define SET_FLOAT_ELEMENT3(v, d1, d2, d3, nv) setArrayElement(findSBLocalVariableByName((v)), (nv), (d1), (d2), (d3), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define SET_FLOAT_ELEMENT4(v, d1, d2, d3, d4, nv) setArrayElement(findSBLocalVariableByName((v)), (nv), (d1), (d2), (d3), (d4), -1)
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define SET_FLOAT_ELEMENT5(v, d1, d2, d3, d4, d5, nv) setArrayElement(findSBLocalVariableByName((v)), (nv), (d1), (d2), (d3), (d4), (d5), -1)

		/* This is probably useful too, or saves typing! */
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define FIND_LOCAL(v) findSBLocalVariableByName((v))


		/* Setters and getters */
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define SET_LOCAL_INTEGER(v, new) setSBLocalVariable_i(findSBLocalVariableByName((v)), (new))
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define SET_LOCAL_FLOAT(v, new) setSBLocalVariable(findSBLocalVariableByName((v)), (new))
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define SET_LOCAL_STRING(v, new) setSBLocalVariable_s(findSBLocalVariableByName((v)), (new))

		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define GET_LOCAL_INTEGER(v) getSBLocalVariable_i(findSBLocalVariableByName((v)))
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define GET_LOCAL_FLOAT(v) getSBLocalVariable(findSBLocalVariableByName((v)))
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define GET_LOCAL_STRING(v) getSBLocalVariable_s(findSBLocalVariableByName((v)))

		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_TYPE(v) getSBLocalVariableType(findSBLocalVariableByName((v)))
		//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
		//ORIGINAL LINE: #define LOCAL_TYPE_NAME(v) getSBLocalVariableTypeName(findSBLocalVariableByName((v)))




		/* This file handles all the code necessary to create, destroy, find,
		 * retrieve and set values for SuperBASIC LOCal variables.
		 *
		 * All this crud is required to emulate the way that SuperBASIC handles LOCals
		 * in that they are visible and accessible to *any* called FuNction or PROCedure
		 * called from the PROCedure or FuNction  that defined the LOCals.
		 *
		 * NOTE: because just about everything in this file is declared "static" to
		 * prevent its use from outside this file, we MUST have the declarations of
		 * the functions AND the functions in the same file.
		 *
		 * If they were declared static in a header file, any module that included the
		 * header would result in lots of warnings about functions being declared static
		 * but not defined. Ask me how I know!
		 */


		/*=================================================================== PRIVATE */

		/* Push a root pointer to a linked list of local variables onto the
		 * scope stack. */
		internal static void pushSBLocalScope(LocalVariableNode root)
		{
			/* Prevent over-run. */
			if (stackPointer < MAX_STACK_DEPTH)
			{
				SBLocalStack[stackPointer++] = root;
			}
			else
			{
				Console.Error.Write("pushSBLocalScope(): Stack overflow.\n");
				Environment.Exit(ERR_OV);
			}
		}

		/* Pop a root pointer to a linked list of local variables off of the
		 * scope stack. Returns the address of the root node for the list
		 * just popped. Remember that stackPointer is the *next* free slot,
		 * not the current TOS. */

		/* Pop a root pointer to a linked list of local variables off of the
		 * scope stack. Returns the address of the root node for the list
		 * just popped. */
		internal static LocalVariableNode popSBLocalScope()
		{
			/* Prevent under-run. */
			if (stackPointer > 0)
			{
				LocalVariableNode[] temp = SBLocalStack[--stackPointer];
				SBLocalStack[stackPointer] = null;
				return temp;
			}
			else
			{
				Console.Error.Write("popSBLocalScope(): Stack underflow.\n");
				Environment.Exit(ERR_OV);
			}
		}

		/* Fetch the current scope from the stack. If there is no item on the
		 * stack, return NULL. */

		/* Fetch the current scope from the stack. */
		internal static LocalVariableNode peekSBLocalScope()
		{
			if (stackPointer > 0)
			{
				int tempSP = stackPointer;
				return SBLocalStack[--tempSP];
			}
			else
			{
				return null;
			}
		}

		/* Internal helper routines to create nodes. Returns the node's address
		 * or NULL if we are out of memory. */

		/* Internal helper routines to create nodes. */
		internal static LocalVariableNode createNode()
		{
			LocalVariableNode temp;

			temp = new LocalVariableNode();
			if (temp != null)
			{
				/* Make sure we have no LOCals, yet. Used */
				/* by deleteNode() later. */
				temp.next = null;
				temp.variable.variableName = StringFunctions.ChangeCharacter(temp.variable.variableName, 0, '\0');
				temp.variable.variableType = SBLOCAL_UNDEFINED;
				temp.variable.variableValue_Renamed.arrayValue = null;
				temp.variable.maxLength = 0;
			}
			else
			{
				Console.Error.Write("createNode(): Out of memory\n");
				/* No exit here, caller copes. */
			}

			return temp;
		}

		/* Internal helper routine to create arrays. Returns the array's address
		 * or NULL if we are out of memory. */

		/* Internal helper routines to create arrays of any kind.
		 * These are deleted within deleteNode() below. */
		internal static object createArray(int bytesRequired)
		{

			object temp;

			/* Check if someone is being silly. */
			if (bytesRequired == 0)
			{
				Console.Error.Write("createArray(): Cannot allocate empty array\n");
				return null;
			}

			//C++ TO C# CONVERTER TODO TASK: The memory management function 'malloc' has no equivalent in C#:
			temp = malloc((int)bytesRequired);
			if (temp == null)
			{
				Console.Error.Write("createArray(): Out of memory\n");
				return null;
			}

			/* NULL out the entire array of bytes. */
			//C++ TO C# CONVERTER TODO TASK: The memory management function 'memset' has no equivalent in C#:
			memset(temp, '\0', bytesRequired);

			/* Return the array base address. */
			return temp;
		}

		/* We can delete an entire list here. Delete any array pointers first
		 * then walk along deleting each node from the tail, backwards. */

		/* And to delete them too. */
		internal static void deleteNode(LocalVariableNode node)
		{
			if (node != null)
			{
				/* Delete the list of LOCals. */

				/* If we have an array, delete the array's memory */
				if (node.variable.variableType > SBLOCAL_FLOAT)
				{
					node.variable.variableValue_Renamed.arrayValue = null;
				}

				/* Now we can delete the node(s) we point to. */
				if (node.next != null)
				{
					/* Let's go recursive... */
					deleteNode(node.next);
				}

				/* Before returning here to delete ourself. */
				node = null;
			}
		}

		//C++ TO C# CONVERTER WARNING: This 'sizeof' ratio was replaced with a direct reference to the array length:
		//ORIGINAL LINE: static int max_sblocal_type = sizeof(sblocal_types)/sizeof(sblocal_types[0]) -1;
		internal static int max_sblocal_type = sblocal_types.Length - 1;

		/* 
		 * Calculate the offset into an array on 'n' dimensions. We get called
		 * from a couple of places specifically getArrayElement() and setArrayElement()
		 * functions.
		 *
		 * NOTE: We get passed a pointer to the callers variable args, we do not call 
		 * va_start or va_end here. Ever!
		 *
		 * This is also where we check that the array indexes are in range.
		 */

		/* Calculate the offset into an array of 'n' dimensions. */
		internal static int getArrayOffset(LocalVariableNode variable, va_list args)
		{
			int thisDimension = 0;
			int offset = 0;
			int dimensionIndex = 0;
			int[] elements = new int[SB_ARRAY_MAX_DIMENSIONS - 1];

			/* Some intcuts - saves typing! */
			int x = 0;
			int y = 1;
			int z = 2;
			int a = 3;
			int b = 4;

			int dimX;
			int dimY;
			int dimZ;
			int dimA;
			int dimB;

			/* Strings have 2 extra bytes, not 1 as in other arrays. */
			int stringExtra = 0;
			int otherExtra = 1;

			if (variable.variable.variableType == SBLOCAL_STRING_ARRAY)
			{
				stringExtra = 1;
			}

			dimX = variable.variable.arrayDimensions[x] + otherExtra + stringExtra;
			dimY = variable.variable.arrayDimensions[y] + otherExtra + stringExtra;
			dimZ = variable.variable.arrayDimensions[z] + otherExtra + stringExtra;
			dimA = variable.variable.arrayDimensions[a] + otherExtra + stringExtra;
			dimB = variable.variable.arrayDimensions[b] + otherExtra + stringExtra;

			/* Extract the various dimensions, -1 ends the list. */
			while (true)
			{
				/* ints get promoted to ints, hence the following. */
				thisDimension = va_arg(args, int);

				/* Done, if negative. */
				if (thisDimension < 0)
				{
					break;
				}

				/* Are we in range? Caller has to deal with this.*/
				if (thisDimension > variable.variable.arrayDimensions[dimensionIndex])
				{
					Console.Error.Write("getArrayOffset(): Subscript out of range. Got {0:D}, maximum is {1:D}.\n", thisDimension, variable.variable.arrayDimensions[dimensionIndex]);
					return -1;
				}


				elements[dimensionIndex++] = thisDimension;
			}

			/* If we created an array[3][5] we actually created array[4][6].
			 * If we created a string array[3][5] we actually created array[4][7].
			 *
			 * The element of array[x][y] requested, comes in as [x][y][-1].
			 * arrayDimensions[] holds 3, 5, -1, -1, -1 and are the actual sizes requested.
			 *
			 * THE FOLLOWING MIGHT HELP?
			 *
			 * 1. array[dimX]
			 *    1-D array index for array[x] = [x].
			 *
			 * 2. array[dimX][dimY]
			 *    2-D array index for array[x][y] = [x*dimY +y].
			 *
			 * 3. array[dimX][dimY][dimZ]
			 *    3-D array index for array[x][y][z] = [x*dimY*dimZ + y*dimZ + z].
			 *
			 * 4. array[dimX][dimY][dimZ][dimA]
			 *    4-D array index for array[x][y][z][a] = [x*dimY*dimZ*dimA + y*dimZ*dimA + z*dimA + a].
			 *
			 * 5. array[dimX][dimY][dimZ][dimA][dimB]
			 *    5-D array index for array[x][y][z][a][b] = [x*dimY*dimZ*dimA*dimB + y*dimZ*dimA*dimB + z*dimA*dumB + a*dimB +b].
			 */


			/* I tried to do this procedurally, but failed! :-( */
			switch (dimensionIndex)
			{
				case 1: // array[x]
					offset = elements[x];
					break;

				case 2: // array[x][y]
					offset = elements[x] * dimY + elements[y];
					break;

				case 3: // array[x][y][z]
					offset = elements[x] * dimY * dimZ + elements[y] * dimZ + elements[z];
					break;

				case 4: // array[x][y][z][a]
					offset = elements[x] * dimY * dimZ * dimA + elements[y] * dimZ * dimA + elements[z] * dimA + elements[a];
					break;

				case 5: // array[x][y][z][a][b]
					offset = elements[x] * dimY * dimZ * dimA * dimB + elements[y] * dimZ * dimA * dimB + elements[z] * dimA * dimB + elements[a] * dimB + elements[b];
					break;
			}

			return offset;

		}

		/*===================================================================PRIVATE */

		/* The stack used for LOCal scopes. As a new PROCedure or FuNction is
		 * entered, which creates LOCal variable, a new scope needs to be created and
		 * the variables added to that scope.
		 *
		 * The stackPointer is the *next* slot to be used in the stack. */
		internal static int stackPointer = 0;
		internal static LocalVariableNode[] SBLocalStack = Arrays.InitializeWithDefaultInstances<LocalVariableNode>(MAX_STACK_DEPTH);


		/*====================================================================PUBLIC */

		/* Retrieve the FP value for a particular Local Variable from the most
		 * recent scope. */
		public static double getSBLocalVariable(LocalVariableNode variable)
		{
			double result = 0.0;

			if (variable != null)
			{
				if (variable.variable.variableType == SBLOCAL_FLOAT)
				{
					result = variable.variable.variableValue_Renamed.floatValue;
				}
				else
				{
					Console.Error.Write("getSBLocalVariable(): Incompatible variable types.\n");
					Console.Error.Write("\tExpected: {0}. Found: {1}.\n", sblocal_types[SBLOCAL_FLOAT], sblocal_types[variable.variable.variableType]);
					Environment.Exit(ERR_BP);
				}
			}
			else
			{
				Console.Error.Write("getSBLocalVariable(): Unknown Local Floating Point Variable.\n");
				Environment.Exit(ERR_NF);
			}
			return result;
		}


	}
}

