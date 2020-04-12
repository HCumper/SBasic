//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\hcump\source\repos\SBasic\Parsing\SBasic.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Parsing {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class SBasicLexer : Lexer {
	public const int
		Refer=1, Implic=2, Local=3, Dimension=4, DefProc=5, DefFunc=6, EndDef=7, 
		If=8, Else=9, Then=10, EndIf=11, Select=12, EndSelect=13, On=14, For=15, 
		Next=16, To=17, EndFor=18, Step=19, Repeat=20, Exit=21, Until=22, EndRepeat=23, 
		LeftParen=24, RightParen=25, LeftBracket=26, RightBracket=27, Equal=28, 
		NotEqual=29, Less=30, LessEqual=31, Greater=32, GreaterEqual=33, Plus=34, 
		Minus=35, Multiply=36, Divide=37, Mod=38, Div=39, And=40, Or=41, Xor=42, 
		Caret=43, Not=44, Tilde=45, Instr=46, Amp=47, Question=48, Colon=49, Semi=50, 
		Comma=51, Point=52, Bang=53, Whitespace=54, Let=55, Newline=56, String=57, 
		Comment=58, ID=59, Integer=60, Real=61, Unknowntype=62, Void=63, Scalar=64, 
		LineNumber=65, ProcCall=66;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"Refer", "Implic", "Local", "Dimension", "DefProc", "DefFunc", "EndDef", 
		"If", "Else", "Then", "EndIf", "Select", "EndSelect", "On", "For", "Next", 
		"To", "EndFor", "Step", "Repeat", "Exit", "Until", "EndRepeat", "LeftParen", 
		"RightParen", "LeftBracket", "RightBracket", "Equal", "NotEqual", "Less", 
		"LessEqual", "Greater", "GreaterEqual", "Plus", "Minus", "Multiply", "Divide", 
		"Mod", "Div", "And", "Or", "Xor", "Caret", "Not", "Tilde", "Instr", "Amp", 
		"Question", "Colon", "Semi", "Comma", "Point", "Bang", "Whitespace", "Let", 
		"Newline", "String", "Comment", "ID", "Integer", "Real", "Unknowntype", 
		"Void", "Scalar", "LineNumber", "ProcCall", "LETTER", "DIGIT", "ESC"
	};


	public SBasicLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "'REFERENCE'", null, "'LOCal'", "'DIM'", "'DEFine PROCedure'", "'DEFine FuNction'", 
		"'END DEFine'", "'IF'", "'ELSE'", "'THEN'", "'END IF'", "'SELect ON'", 
		"'END SELect'", "'ON'", "'FOR'", "'NEXT'", "'TO'", "'END FOR'", "'STEP'", 
		"'REPeat'", "'EXIT'", "'UNTIL'", "'END REPeat'", "'('", "')'", "'['", 
		"']'", "'='", "'<>'", "'<'", "'<='", "'>'", "'>='", "'+'", "'-'", "'*'", 
		"'/'", "'MOD'", "'DIV'", "'AND'", "'OR'", "'XOR'", "'^'", "'NOT'", "'~'", 
		"'INSTR'", "'&'", "'?'", "':'", "';'", "','", "'.'", "'!'", null, "'LET'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "Refer", "Implic", "Local", "Dimension", "DefProc", "DefFunc", "EndDef", 
		"If", "Else", "Then", "EndIf", "Select", "EndSelect", "On", "For", "Next", 
		"To", "EndFor", "Step", "Repeat", "Exit", "Until", "EndRepeat", "LeftParen", 
		"RightParen", "LeftBracket", "RightBracket", "Equal", "NotEqual", "Less", 
		"LessEqual", "Greater", "GreaterEqual", "Plus", "Minus", "Multiply", "Divide", 
		"Mod", "Div", "And", "Or", "Xor", "Caret", "Not", "Tilde", "Instr", "Amp", 
		"Question", "Colon", "Semi", "Comma", "Point", "Bang", "Whitespace", "Let", 
		"Newline", "String", "Comment", "ID", "Integer", "Real", "Unknowntype", 
		"Void", "Scalar", "LineNumber", "ProcCall"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "SBasic.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\x44\x203\b\x1\x4"+
		"\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b"+
		"\x4\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4"+
		"\x10\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15"+
		"\t\x15\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A\t\x1A"+
		"\x4\x1B\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F\x4 "+
		"\t \x4!\t!\x4\"\t\"\x4#\t#\x4$\t$\x4%\t%\x4&\t&\x4\'\t\'\x4(\t(\x4)\t"+
		")\x4*\t*\x4+\t+\x4,\t,\x4-\t-\x4.\t.\x4/\t/\x4\x30\t\x30\x4\x31\t\x31"+
		"\x4\x32\t\x32\x4\x33\t\x33\x4\x34\t\x34\x4\x35\t\x35\x4\x36\t\x36\x4\x37"+
		"\t\x37\x4\x38\t\x38\x4\x39\t\x39\x4:\t:\x4;\t;\x4<\t<\x4=\t=\x4>\t>\x4"+
		"?\t?\x4@\t@\x4\x41\t\x41\x4\x42\t\x42\x4\x43\t\x43\x4\x44\t\x44\x4\x45"+
		"\t\x45\x4\x46\t\x46\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x3"+
		"\x2\x3\x2\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x5\x3\xAA\n\x3\x3\x4"+
		"\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x5\x3\x5\x3\x5\x3\x5\x3\x6\x3\x6\x3"+
		"\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6"+
		"\x3\x6\x3\x6\x3\x6\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3"+
		"\b\x3\b\x3\b\x3\t\x3\t\x3\t\x3\n\x3\n\x3\n\x3\n\x3\n\x3\v\x3\v\x3\v\x3"+
		"\v\x3\v\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\r\x3\r\x3\r\x3\r\x3\r\x3"+
		"\r\x3\r\x3\r\x3\r\x3\r\x3\xE\x3\xE\x3\xE\x3\xE\x3\xE\x3\xE\x3\xE\x3\xE"+
		"\x3\xE\x3\xE\x3\xE\x3\xF\x3\xF\x3\xF\x3\x10\x3\x10\x3\x10\x3\x10\x3\x11"+
		"\x3\x11\x3\x11\x3\x11\x3\x11\x3\x12\x3\x12\x3\x12\x3\x13\x3\x13\x3\x13"+
		"\x3\x13\x3\x13\x3\x13\x3\x13\x3\x13\x3\x14\x3\x14\x3\x14\x3\x14\x3\x14"+
		"\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x15\x3\x16\x3\x16\x3\x16"+
		"\x3\x16\x3\x16\x3\x17\x3\x17\x3\x17\x3\x17\x3\x17\x3\x17\x3\x18\x3\x18"+
		"\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x19"+
		"\x3\x19\x3\x1A\x3\x1A\x3\x1B\x3\x1B\x3\x1C\x3\x1C\x3\x1D\x3\x1D\x3\x1E"+
		"\x3\x1E\x3\x1E\x3\x1F\x3\x1F\x3 \x3 \x3 \x3!\x3!\x3\"\x3\"\x3\"\x3#\x3"+
		"#\x3$\x3$\x3%\x3%\x3&\x3&\x3\'\x3\'\x3\'\x3\'\x3(\x3(\x3(\x3(\x3)\x3)"+
		"\x3)\x3)\x3*\x3*\x3*\x3+\x3+\x3+\x3+\x3,\x3,\x3-\x3-\x3-\x3-\x3.\x3.\x3"+
		"/\x3/\x3/\x3/\x3/\x3/\x3\x30\x3\x30\x3\x31\x3\x31\x3\x32\x3\x32\x3\x33"+
		"\x3\x33\x3\x34\x3\x34\x3\x35\x3\x35\x3\x36\x3\x36\x3\x37\x6\x37\x193\n"+
		"\x37\r\x37\xE\x37\x194\x3\x37\x3\x37\x3\x38\x3\x38\x3\x38\x3\x38\x3\x38"+
		"\x3\x38\x3\x39\x3\x39\x3\x39\x5\x39\x1A2\n\x39\x3:\x3:\a:\x1A6\n:\f:\xE"+
		":\x1A9\v:\x3:\x3:\x3;\x3;\x3;\x3;\x3;\x3;\x3;\x3;\a;\x1B5\n;\f;\xE;\x1B8"+
		"\v;\x3;\x3;\x3<\x3<\a<\x1BE\n<\f<\xE<\x1C1\v<\x3<\x3<\x3<\x3<\a<\x1C7"+
		"\n<\f<\xE<\x1CA\v<\x3<\x3<\x3<\x3<\a<\x1D0\n<\f<\xE<\x1D3\v<\x5<\x1D5"+
		"\n<\x3=\x6=\x1D8\n=\r=\xE=\x1D9\x3>\x6>\x1DD\n>\r>\xE>\x1DE\x3>\x3>\a"+
		">\x1E3\n>\f>\xE>\x1E6\v>\x3>\x3>\x6>\x1EA\n>\r>\xE>\x1EB\x5>\x1EE\n>\x3"+
		"?\x3?\x3@\x3@\x3\x41\x3\x41\x3\x42\x3\x42\x3\x43\x3\x43\x3\x44\x3\x44"+
		"\x3\x45\x3\x45\x3\x46\x3\x46\x3\x46\x3\x46\x5\x46\x202\n\x46\x2\x2\x2"+
		"G\x3\x2\x3\x5\x2\x4\a\x2\x5\t\x2\x6\v\x2\a\r\x2\b\xF\x2\t\x11\x2\n\x13"+
		"\x2\v\x15\x2\f\x17\x2\r\x19\x2\xE\x1B\x2\xF\x1D\x2\x10\x1F\x2\x11!\x2"+
		"\x12#\x2\x13%\x2\x14\'\x2\x15)\x2\x16+\x2\x17-\x2\x18/\x2\x19\x31\x2\x1A"+
		"\x33\x2\x1B\x35\x2\x1C\x37\x2\x1D\x39\x2\x1E;\x2\x1F=\x2 ?\x2!\x41\x2"+
		"\"\x43\x2#\x45\x2$G\x2%I\x2&K\x2\'M\x2(O\x2)Q\x2*S\x2+U\x2,W\x2-Y\x2."+
		"[\x2/]\x2\x30_\x2\x31\x61\x2\x32\x63\x2\x33\x65\x2\x34g\x2\x35i\x2\x36"+
		"k\x2\x37m\x2\x38o\x2\x39q\x2:s\x2;u\x2<w\x2=y\x2>{\x2?}\x2@\x7F\x2\x41"+
		"\x81\x2\x42\x83\x2\x43\x85\x2\x44\x87\x2\x2\x89\x2\x2\x8B\x2\x2\x3\x2"+
		"\b\x4\x2\v\v\"\"\x3\x2$$\x4\x2\f\f\xF\xF\x6\x2\x32;\x43\\\x61\x61\x63"+
		"|\x4\x2\x43\\\x63|\x3\x2\x32;\x20F\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2\x2\x2"+
		"\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2\x2"+
		"\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2\x2"+
		"\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2\x2\x2\x2\x1B\x3\x2\x2\x2\x2\x1D\x3"+
		"\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3\x2\x2\x2\x2#\x3\x2\x2\x2\x2%\x3\x2"+
		"\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3\x2\x2\x2\x2+\x3\x2\x2\x2\x2-\x3\x2\x2\x2"+
		"\x2/\x3\x2\x2\x2\x2\x31\x3\x2\x2\x2\x2\x33\x3\x2\x2\x2\x2\x35\x3\x2\x2"+
		"\x2\x2\x37\x3\x2\x2\x2\x2\x39\x3\x2\x2\x2\x2;\x3\x2\x2\x2\x2=\x3\x2\x2"+
		"\x2\x2?\x3\x2\x2\x2\x2\x41\x3\x2\x2\x2\x2\x43\x3\x2\x2\x2\x2\x45\x3\x2"+
		"\x2\x2\x2G\x3\x2\x2\x2\x2I\x3\x2\x2\x2\x2K\x3\x2\x2\x2\x2M\x3\x2\x2\x2"+
		"\x2O\x3\x2\x2\x2\x2Q\x3\x2\x2\x2\x2S\x3\x2\x2\x2\x2U\x3\x2\x2\x2\x2W\x3"+
		"\x2\x2\x2\x2Y\x3\x2\x2\x2\x2[\x3\x2\x2\x2\x2]\x3\x2\x2\x2\x2_\x3\x2\x2"+
		"\x2\x2\x61\x3\x2\x2\x2\x2\x63\x3\x2\x2\x2\x2\x65\x3\x2\x2\x2\x2g\x3\x2"+
		"\x2\x2\x2i\x3\x2\x2\x2\x2k\x3\x2\x2\x2\x2m\x3\x2\x2\x2\x2o\x3\x2\x2\x2"+
		"\x2q\x3\x2\x2\x2\x2s\x3\x2\x2\x2\x2u\x3\x2\x2\x2\x2w\x3\x2\x2\x2\x2y\x3"+
		"\x2\x2\x2\x2{\x3\x2\x2\x2\x2}\x3\x2\x2\x2\x2\x7F\x3\x2\x2\x2\x2\x81\x3"+
		"\x2\x2\x2\x2\x83\x3\x2\x2\x2\x2\x85\x3\x2\x2\x2\x3\x8D\x3\x2\x2\x2\x5"+
		"\xA9\x3\x2\x2\x2\a\xAB\x3\x2\x2\x2\t\xB1\x3\x2\x2\x2\v\xB5\x3\x2\x2\x2"+
		"\r\xC6\x3\x2\x2\x2\xF\xD6\x3\x2\x2\x2\x11\xE1\x3\x2\x2\x2\x13\xE4\x3\x2"+
		"\x2\x2\x15\xE9\x3\x2\x2\x2\x17\xEE\x3\x2\x2\x2\x19\xF5\x3\x2\x2\x2\x1B"+
		"\xFF\x3\x2\x2\x2\x1D\x10A\x3\x2\x2\x2\x1F\x10D\x3\x2\x2\x2!\x111\x3\x2"+
		"\x2\x2#\x116\x3\x2\x2\x2%\x119\x3\x2\x2\x2\'\x121\x3\x2\x2\x2)\x126\x3"+
		"\x2\x2\x2+\x12D\x3\x2\x2\x2-\x132\x3\x2\x2\x2/\x138\x3\x2\x2\x2\x31\x143"+
		"\x3\x2\x2\x2\x33\x145\x3\x2\x2\x2\x35\x147\x3\x2\x2\x2\x37\x149\x3\x2"+
		"\x2\x2\x39\x14B\x3\x2\x2\x2;\x14D\x3\x2\x2\x2=\x150\x3\x2\x2\x2?\x152"+
		"\x3\x2\x2\x2\x41\x155\x3\x2\x2\x2\x43\x157\x3\x2\x2\x2\x45\x15A\x3\x2"+
		"\x2\x2G\x15C\x3\x2\x2\x2I\x15E\x3\x2\x2\x2K\x160\x3\x2\x2\x2M\x162\x3"+
		"\x2\x2\x2O\x166\x3\x2\x2\x2Q\x16A\x3\x2\x2\x2S\x16E\x3\x2\x2\x2U\x171"+
		"\x3\x2\x2\x2W\x175\x3\x2\x2\x2Y\x177\x3\x2\x2\x2[\x17B\x3\x2\x2\x2]\x17D"+
		"\x3\x2\x2\x2_\x183\x3\x2\x2\x2\x61\x185\x3\x2\x2\x2\x63\x187\x3\x2\x2"+
		"\x2\x65\x189\x3\x2\x2\x2g\x18B\x3\x2\x2\x2i\x18D\x3\x2\x2\x2k\x18F\x3"+
		"\x2\x2\x2m\x192\x3\x2\x2\x2o\x198\x3\x2\x2\x2q\x1A1\x3\x2\x2\x2s\x1A3"+
		"\x3\x2\x2\x2u\x1AC\x3\x2\x2\x2w\x1D4\x3\x2\x2\x2y\x1D7\x3\x2\x2\x2{\x1ED"+
		"\x3\x2\x2\x2}\x1EF\x3\x2\x2\x2\x7F\x1F1\x3\x2\x2\x2\x81\x1F3\x3\x2\x2"+
		"\x2\x83\x1F5\x3\x2\x2\x2\x85\x1F7\x3\x2\x2\x2\x87\x1F9\x3\x2\x2\x2\x89"+
		"\x1FB\x3\x2\x2\x2\x8B\x201\x3\x2\x2\x2\x8D\x8E\aT\x2\x2\x8E\x8F\aG\x2"+
		"\x2\x8F\x90\aH\x2\x2\x90\x91\aG\x2\x2\x91\x92\aT\x2\x2\x92\x93\aG\x2\x2"+
		"\x93\x94\aP\x2\x2\x94\x95\a\x45\x2\x2\x95\x96\aG\x2\x2\x96\x4\x3\x2\x2"+
		"\x2\x97\x98\aK\x2\x2\x98\x99\aO\x2\x2\x99\x9A\aR\x2\x2\x9A\x9B\aN\x2\x2"+
		"\x9B\x9C\aK\x2\x2\x9C\x9D\a\x45\x2\x2\x9D\x9E\aK\x2\x2\x9E\x9F\aV\x2\x2"+
		"\x9F\xAA\a\'\x2\x2\xA0\xA1\aK\x2\x2\xA1\xA2\aO\x2\x2\xA2\xA3\aR\x2\x2"+
		"\xA3\xA4\aN\x2\x2\xA4\xA5\aK\x2\x2\xA5\xA6\a\x45\x2\x2\xA6\xA7\aK\x2\x2"+
		"\xA7\xA8\aV\x2\x2\xA8\xAA\a&\x2\x2\xA9\x97\x3\x2\x2\x2\xA9\xA0\x3\x2\x2"+
		"\x2\xAA\x6\x3\x2\x2\x2\xAB\xAC\aN\x2\x2\xAC\xAD\aQ\x2\x2\xAD\xAE\a\x45"+
		"\x2\x2\xAE\xAF\a\x63\x2\x2\xAF\xB0\an\x2\x2\xB0\b\x3\x2\x2\x2\xB1\xB2"+
		"\a\x46\x2\x2\xB2\xB3\aK\x2\x2\xB3\xB4\aO\x2\x2\xB4\n\x3\x2\x2\x2\xB5\xB6"+
		"\a\x46\x2\x2\xB6\xB7\aG\x2\x2\xB7\xB8\aH\x2\x2\xB8\xB9\ak\x2\x2\xB9\xBA"+
		"\ap\x2\x2\xBA\xBB\ag\x2\x2\xBB\xBC\a\"\x2\x2\xBC\xBD\aR\x2\x2\xBD\xBE"+
		"\aT\x2\x2\xBE\xBF\aQ\x2\x2\xBF\xC0\a\x45\x2\x2\xC0\xC1\ag\x2\x2\xC1\xC2"+
		"\a\x66\x2\x2\xC2\xC3\aw\x2\x2\xC3\xC4\at\x2\x2\xC4\xC5\ag\x2\x2\xC5\f"+
		"\x3\x2\x2\x2\xC6\xC7\a\x46\x2\x2\xC7\xC8\aG\x2\x2\xC8\xC9\aH\x2\x2\xC9"+
		"\xCA\ak\x2\x2\xCA\xCB\ap\x2\x2\xCB\xCC\ag\x2\x2\xCC\xCD\a\"\x2\x2\xCD"+
		"\xCE\aH\x2\x2\xCE\xCF\aw\x2\x2\xCF\xD0\aP\x2\x2\xD0\xD1\a\x65\x2\x2\xD1"+
		"\xD2\av\x2\x2\xD2\xD3\ak\x2\x2\xD3\xD4\aq\x2\x2\xD4\xD5\ap\x2\x2\xD5\xE"+
		"\x3\x2\x2\x2\xD6\xD7\aG\x2\x2\xD7\xD8\aP\x2\x2\xD8\xD9\a\x46\x2\x2\xD9"+
		"\xDA\a\"\x2\x2\xDA\xDB\a\x46\x2\x2\xDB\xDC\aG\x2\x2\xDC\xDD\aH\x2\x2\xDD"+
		"\xDE\ak\x2\x2\xDE\xDF\ap\x2\x2\xDF\xE0\ag\x2\x2\xE0\x10\x3\x2\x2\x2\xE1"+
		"\xE2\aK\x2\x2\xE2\xE3\aH\x2\x2\xE3\x12\x3\x2\x2\x2\xE4\xE5\aG\x2\x2\xE5"+
		"\xE6\aN\x2\x2\xE6\xE7\aU\x2\x2\xE7\xE8\aG\x2\x2\xE8\x14\x3\x2\x2\x2\xE9"+
		"\xEA\aV\x2\x2\xEA\xEB\aJ\x2\x2\xEB\xEC\aG\x2\x2\xEC\xED\aP\x2\x2\xED\x16"+
		"\x3\x2\x2\x2\xEE\xEF\aG\x2\x2\xEF\xF0\aP\x2\x2\xF0\xF1\a\x46\x2\x2\xF1"+
		"\xF2\a\"\x2\x2\xF2\xF3\aK\x2\x2\xF3\xF4\aH\x2\x2\xF4\x18\x3\x2\x2\x2\xF5"+
		"\xF6\aU\x2\x2\xF6\xF7\aG\x2\x2\xF7\xF8\aN\x2\x2\xF8\xF9\ag\x2\x2\xF9\xFA"+
		"\a\x65\x2\x2\xFA\xFB\av\x2\x2\xFB\xFC\a\"\x2\x2\xFC\xFD\aQ\x2\x2\xFD\xFE"+
		"\aP\x2\x2\xFE\x1A\x3\x2\x2\x2\xFF\x100\aG\x2\x2\x100\x101\aP\x2\x2\x101"+
		"\x102\a\x46\x2\x2\x102\x103\a\"\x2\x2\x103\x104\aU\x2\x2\x104\x105\aG"+
		"\x2\x2\x105\x106\aN\x2\x2\x106\x107\ag\x2\x2\x107\x108\a\x65\x2\x2\x108"+
		"\x109\av\x2\x2\x109\x1C\x3\x2\x2\x2\x10A\x10B\aQ\x2\x2\x10B\x10C\aP\x2"+
		"\x2\x10C\x1E\x3\x2\x2\x2\x10D\x10E\aH\x2\x2\x10E\x10F\aQ\x2\x2\x10F\x110"+
		"\aT\x2\x2\x110 \x3\x2\x2\x2\x111\x112\aP\x2\x2\x112\x113\aG\x2\x2\x113"+
		"\x114\aZ\x2\x2\x114\x115\aV\x2\x2\x115\"\x3\x2\x2\x2\x116\x117\aV\x2\x2"+
		"\x117\x118\aQ\x2\x2\x118$\x3\x2\x2\x2\x119\x11A\aG\x2\x2\x11A\x11B\aP"+
		"\x2\x2\x11B\x11C\a\x46\x2\x2\x11C\x11D\a\"\x2\x2\x11D\x11E\aH\x2\x2\x11E"+
		"\x11F\aQ\x2\x2\x11F\x120\aT\x2\x2\x120&\x3\x2\x2\x2\x121\x122\aU\x2\x2"+
		"\x122\x123\aV\x2\x2\x123\x124\aG\x2\x2\x124\x125\aR\x2\x2\x125(\x3\x2"+
		"\x2\x2\x126\x127\aT\x2\x2\x127\x128\aG\x2\x2\x128\x129\aR\x2\x2\x129\x12A"+
		"\ag\x2\x2\x12A\x12B\a\x63\x2\x2\x12B\x12C\av\x2\x2\x12C*\x3\x2\x2\x2\x12D"+
		"\x12E\aG\x2\x2\x12E\x12F\aZ\x2\x2\x12F\x130\aK\x2\x2\x130\x131\aV\x2\x2"+
		"\x131,\x3\x2\x2\x2\x132\x133\aW\x2\x2\x133\x134\aP\x2\x2\x134\x135\aV"+
		"\x2\x2\x135\x136\aK\x2\x2\x136\x137\aN\x2\x2\x137.\x3\x2\x2\x2\x138\x139"+
		"\aG\x2\x2\x139\x13A\aP\x2\x2\x13A\x13B\a\x46\x2\x2\x13B\x13C\a\"\x2\x2"+
		"\x13C\x13D\aT\x2\x2\x13D\x13E\aG\x2\x2\x13E\x13F\aR\x2\x2\x13F\x140\a"+
		"g\x2\x2\x140\x141\a\x63\x2\x2\x141\x142\av\x2\x2\x142\x30\x3\x2\x2\x2"+
		"\x143\x144\a*\x2\x2\x144\x32\x3\x2\x2\x2\x145\x146\a+\x2\x2\x146\x34\x3"+
		"\x2\x2\x2\x147\x148\a]\x2\x2\x148\x36\x3\x2\x2\x2\x149\x14A\a_\x2\x2\x14A"+
		"\x38\x3\x2\x2\x2\x14B\x14C\a?\x2\x2\x14C:\x3\x2\x2\x2\x14D\x14E\a>\x2"+
		"\x2\x14E\x14F\a@\x2\x2\x14F<\x3\x2\x2\x2\x150\x151\a>\x2\x2\x151>\x3\x2"+
		"\x2\x2\x152\x153\a>\x2\x2\x153\x154\a?\x2\x2\x154@\x3\x2\x2\x2\x155\x156"+
		"\a@\x2\x2\x156\x42\x3\x2\x2\x2\x157\x158\a@\x2\x2\x158\x159\a?\x2\x2\x159"+
		"\x44\x3\x2\x2\x2\x15A\x15B\a-\x2\x2\x15B\x46\x3\x2\x2\x2\x15C\x15D\a/"+
		"\x2\x2\x15DH\x3\x2\x2\x2\x15E\x15F\a,\x2\x2\x15FJ\x3\x2\x2\x2\x160\x161"+
		"\a\x31\x2\x2\x161L\x3\x2\x2\x2\x162\x163\aO\x2\x2\x163\x164\aQ\x2\x2\x164"+
		"\x165\a\x46\x2\x2\x165N\x3\x2\x2\x2\x166\x167\a\x46\x2\x2\x167\x168\a"+
		"K\x2\x2\x168\x169\aX\x2\x2\x169P\x3\x2\x2\x2\x16A\x16B\a\x43\x2\x2\x16B"+
		"\x16C\aP\x2\x2\x16C\x16D\a\x46\x2\x2\x16DR\x3\x2\x2\x2\x16E\x16F\aQ\x2"+
		"\x2\x16F\x170\aT\x2\x2\x170T\x3\x2\x2\x2\x171\x172\aZ\x2\x2\x172\x173"+
		"\aQ\x2\x2\x173\x174\aT\x2\x2\x174V\x3\x2\x2\x2\x175\x176\a`\x2\x2\x176"+
		"X\x3\x2\x2\x2\x177\x178\aP\x2\x2\x178\x179\aQ\x2\x2\x179\x17A\aV\x2\x2"+
		"\x17AZ\x3\x2\x2\x2\x17B\x17C\a\x80\x2\x2\x17C\\\x3\x2\x2\x2\x17D\x17E"+
		"\aK\x2\x2\x17E\x17F\aP\x2\x2\x17F\x180\aU\x2\x2\x180\x181\aV\x2\x2\x181"+
		"\x182\aT\x2\x2\x182^\x3\x2\x2\x2\x183\x184\a(\x2\x2\x184`\x3\x2\x2\x2"+
		"\x185\x186\a\x41\x2\x2\x186\x62\x3\x2\x2\x2\x187\x188\a<\x2\x2\x188\x64"+
		"\x3\x2\x2\x2\x189\x18A\a=\x2\x2\x18A\x66\x3\x2\x2\x2\x18B\x18C\a.\x2\x2"+
		"\x18Ch\x3\x2\x2\x2\x18D\x18E\a\x30\x2\x2\x18Ej\x3\x2\x2\x2\x18F\x190\a"+
		"#\x2\x2\x190l\x3\x2\x2\x2\x191\x193\t\x2\x2\x2\x192\x191\x3\x2\x2\x2\x193"+
		"\x194\x3\x2\x2\x2\x194\x192\x3\x2\x2\x2\x194\x195\x3\x2\x2\x2\x195\x196"+
		"\x3\x2\x2\x2\x196\x197\b\x37\x2\x2\x197n\x3\x2\x2\x2\x198\x199\aN\x2\x2"+
		"\x199\x19A\aG\x2\x2\x19A\x19B\aV\x2\x2\x19B\x19C\x3\x2\x2\x2\x19C\x19D"+
		"\b\x38\x2\x2\x19Dp\x3\x2\x2\x2\x19E\x19F\a\xF\x2\x2\x19F\x1A2\a\f\x2\x2"+
		"\x1A0\x1A2\a\f\x2\x2\x1A1\x19E\x3\x2\x2\x2\x1A1\x1A0\x3\x2\x2\x2\x1A2"+
		"r\x3\x2\x2\x2\x1A3\x1A7\a$\x2\x2\x1A4\x1A6\n\x3\x2\x2\x1A5\x1A4\x3\x2"+
		"\x2\x2\x1A6\x1A9\x3\x2\x2\x2\x1A7\x1A5\x3\x2\x2\x2\x1A7\x1A8\x3\x2\x2"+
		"\x2\x1A8\x1AA\x3\x2\x2\x2\x1A9\x1A7\x3\x2\x2\x2\x1AA\x1AB\a$\x2\x2\x1AB"+
		"t\x3\x2\x2\x2\x1AC\x1AD\aT\x2\x2\x1AD\x1AE\aG\x2\x2\x1AE\x1AF\aO\x2\x2"+
		"\x1AF\x1B0\a\x63\x2\x2\x1B0\x1B1\at\x2\x2\x1B1\x1B2\am\x2\x2\x1B2\x1B6"+
		"\x3\x2\x2\x2\x1B3\x1B5\n\x4\x2\x2\x1B4\x1B3\x3\x2\x2\x2\x1B5\x1B8\x3\x2"+
		"\x2\x2\x1B6\x1B4\x3\x2\x2\x2\x1B6\x1B7\x3\x2\x2\x2\x1B7\x1B9\x3\x2\x2"+
		"\x2\x1B8\x1B6\x3\x2\x2\x2\x1B9\x1BA\b;\x2\x2\x1BAv\x3\x2\x2\x2\x1BB\x1BF"+
		"\x5\x87\x44\x2\x1BC\x1BE\t\x5\x2\x2\x1BD\x1BC\x3\x2\x2\x2\x1BE\x1C1\x3"+
		"\x2\x2\x2\x1BF\x1BD\x3\x2\x2\x2\x1BF\x1C0\x3\x2\x2\x2\x1C0\x1C2\x3\x2"+
		"\x2\x2\x1C1\x1BF\x3\x2\x2\x2\x1C2\x1C3\a&\x2\x2\x1C3\x1D5\x3\x2\x2\x2"+
		"\x1C4\x1C8\x5\x87\x44\x2\x1C5\x1C7\t\x5\x2\x2\x1C6\x1C5\x3\x2\x2\x2\x1C7"+
		"\x1CA\x3\x2\x2\x2\x1C8\x1C6\x3\x2\x2\x2\x1C8\x1C9\x3\x2\x2\x2\x1C9\x1CB"+
		"\x3\x2\x2\x2\x1CA\x1C8\x3\x2\x2\x2\x1CB\x1CC\a\'\x2\x2\x1CC\x1D5\x3\x2"+
		"\x2\x2\x1CD\x1D1\x5\x87\x44\x2\x1CE\x1D0\t\x5\x2\x2\x1CF\x1CE\x3\x2\x2"+
		"\x2\x1D0\x1D3\x3\x2\x2\x2\x1D1\x1CF\x3\x2\x2\x2\x1D1\x1D2\x3\x2\x2\x2"+
		"\x1D2\x1D5\x3\x2\x2\x2\x1D3\x1D1\x3\x2\x2\x2\x1D4\x1BB\x3\x2\x2\x2\x1D4"+
		"\x1C4\x3\x2\x2\x2\x1D4\x1CD\x3\x2\x2\x2\x1D5x\x3\x2\x2\x2\x1D6\x1D8\x5"+
		"\x89\x45\x2\x1D7\x1D6\x3\x2\x2\x2\x1D8\x1D9\x3\x2\x2\x2\x1D9\x1D7\x3\x2"+
		"\x2\x2\x1D9\x1DA\x3\x2\x2\x2\x1DAz\x3\x2\x2\x2\x1DB\x1DD\x5\x89\x45\x2"+
		"\x1DC\x1DB\x3\x2\x2\x2\x1DD\x1DE\x3\x2\x2\x2\x1DE\x1DC\x3\x2\x2\x2\x1DE"+
		"\x1DF\x3\x2\x2\x2\x1DF\x1E0\x3\x2\x2\x2\x1E0\x1E4\x5i\x35\x2\x1E1\x1E3"+
		"\x5\x89\x45\x2\x1E2\x1E1\x3\x2\x2\x2\x1E3\x1E6\x3\x2\x2\x2\x1E4\x1E2\x3"+
		"\x2\x2\x2\x1E4\x1E5\x3\x2\x2\x2\x1E5\x1EE\x3\x2\x2\x2\x1E6\x1E4\x3\x2"+
		"\x2\x2\x1E7\x1E9\x5i\x35\x2\x1E8\x1EA\x5\x89\x45\x2\x1E9\x1E8\x3\x2\x2"+
		"\x2\x1EA\x1EB\x3\x2\x2\x2\x1EB\x1E9\x3\x2\x2\x2\x1EB\x1EC\x3\x2\x2\x2"+
		"\x1EC\x1EE\x3\x2\x2\x2\x1ED\x1DC\x3\x2\x2\x2\x1ED\x1E7\x3\x2\x2\x2\x1EE"+
		"|\x3\x2\x2\x2\x1EF\x1F0\x3\x2\x2\x2\x1F0~\x3\x2\x2\x2\x1F1\x1F2\x3\x2"+
		"\x2\x2\x1F2\x80\x3\x2\x2\x2\x1F3\x1F4\x3\x2\x2\x2\x1F4\x82\x3\x2\x2\x2"+
		"\x1F5\x1F6\x3\x2\x2\x2\x1F6\x84\x3\x2\x2\x2\x1F7\x1F8\x3\x2\x2\x2\x1F8"+
		"\x86\x3\x2\x2\x2\x1F9\x1FA\t\x6\x2\x2\x1FA\x88\x3\x2\x2\x2\x1FB\x1FC\t"+
		"\a\x2\x2\x1FC\x8A\x3\x2\x2\x2\x1FD\x1FE\a^\x2\x2\x1FE\x202\a$\x2\x2\x1FF"+
		"\x200\a^\x2\x2\x200\x202\a^\x2\x2\x201\x1FD\x3\x2\x2\x2\x201\x1FF\x3\x2"+
		"\x2\x2\x202\x8C\x3\x2\x2\x2\x15\x2\xA9\x194\x1A1\x1A7\x1B6\x1BD\x1BF\x1C6"+
		"\x1C8\x1CF\x1D1\x1D4\x1D9\x1DE\x1E4\x1EB\x1ED\x201\x3\b\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace Parsing
