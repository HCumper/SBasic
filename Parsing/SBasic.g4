grammar SBasic;

program : linelist EOF;

linelist: line*;

line :
	eol? lineNumber? stmtlist eol 
	| lineNumber ':' eol
	;

stmtlist : stmt (':' stmt)*;

stmt :
	Comment																																#Comment
	| 'DIM' ID parenthesizedlist																										#Dim
	| ('IMPLICIT%' | 'IMPLICIT$') unparenthesizedlist																					#Implicit
	| 'REFERENCE' unparenthesizedlist																									#Reference
	| 'DEFine PROCedure' procedureName parenthesizedlist? eol lineNumber? loc? linelist lineNumber? 'END DEFine' ID?										#Proc
	| 'DEFine FuNction' ID parenthesizedlist? eol lineNumber? loc? linelist lineNumber? 'END DEFine' ID? 										#Func
	| 'FOR' ID '=' expr 'TO' expr ('STEP' expr)? eol linelist lineNumber? 'END FOR' ID?													#For
	| 'FOR' ID '=' expr 'TO' expr ':' stmtlist																							#For
	| 'REPeat' ID ':' stmtlist																											#Shortrepeat
	| 'REPeat' ID eol linelist lineNumber? 'END REPeat' ID?																				#Longrepeat
	| 'IF' expr ('THEN' | ':')? eol linelist lineNumber? ('ELSE' eol linelist)?  lineNumber? 'END IF'											#If
	| 'IF' expr ('THEN' | ':')? stmtlist ('ELSE' stmtlist)? 																			#If
    | 'SELect ON' constexpr eol linelist lineNumber? 'END SELect'																			#Longselect
	| 'ON' (constexpr) '=' rangeexpr																									#Onselect
	| 'EXIT' ID?																														#Exitstmt
	| ID expr? (',' expr)*																												#ProcCall
	| identifier '=' expr																												#Assignment
	| 'PRINT' expr? (separator expr)* eol?																								#Print
	| identifier																														#IdentifierOnly
	;

expr :
	  '(' expr ')'																														#ParenthesizedExpr
	| ('+' | '-') expr																													#UnaryAdditiveExpr
	| expr 'AMP' expr																													#BinaryExpr
	| <assoc=right> (String | ID) 'INSTR' expr																							#InstrExpr
	| <assoc=right> expr '^' expr																										#BinaryExpr
	| expr ('+' | '-' | '*' | '/' | 'MOD' | 'DIV') expr																					#BinaryExpr
	| expr ('=' | '<>' | '<' | '>' | '<=' | '>=') expr																					#BinaryExpr
	| 'NOT' expr																														#NotExpr
	| expr ('AND' | 'OR' | 'XOR') expr																									#BinaryExpr
	| identifier																														#IdentExpr
	| (Integer | String | Real)																											#LiteralExpr
	;

constexpr : Integer | Real | String | ID;
rangeexpr : constexpr 'TO' constexpr
		  | constexpr
;

procedureName : ID;
loc : 'LOCal' unparenthesizedlist;	
identifier : ID (parenthesizedlist )?;

parenthesizedlist :	'(' expr (separator expr)* ')';
unparenthesizedlist : expr (separator expr)*;

separator : ',' | '!' | ';' | 'TO';
       
Whitespace
    :   [ \t]+
        -> skip
    ;

Let : 'LET' -> skip;

Newline
    :   (( '\r' '\n') |   '\n') 
	;
eol : Newline;

String : '"' ~('"')* '"';

Comment
	:  'REMark' ~( '\r' | '\n' )*
	;

ID : LETTER ([0-9] | [A-Za-z] | '_')* '$'
	| LETTER ([0-9] | [A-Za-z] | '_')* '%'
	| LETTER ([0-9] | [A-Za-z] | '_')*;

Integer : DIGIT+;
lineNumber : Integer;

Real
	: DIGIT+ '.' DIGIT*
	| '.' DIGIT+
	;

Unknowntype:;
Scalar:;
FuncCall:;
Ignore:;
DefProc:;
DefFunc:;
ProcCall:;
Void:;

fragment LETTER : [a-zA-Z];
fragment DIGIT : [0-9];
fragment ESC : '\\"' | '\\\\' ;
