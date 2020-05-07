grammar SBasic;

program : linelist EOF;

linelist : line*;

line :
	  lineNumber? stmtlist eol?
	| lineNumber ':' eol
	;

stmtlist : stmt (':' stmt)*;

stmt :
      Comment																															#Comment
	| 'DIM' ID parenthesizedlist																										#Dim
	| ('IMPLICIT%' | 'IMPLICIT$') unparenthesizedlist																					#Implicit
	| 'REFERENCE' unparenthesizedlist																									#Reference
	| 'DEFine PROCedure' procedureName parenthesizedlist? (eol | ':') localVars linelist lineNumber? 'END DEFine' ID?					#ProcDecl
	| 'DEFine FuNction' functionName parenthesizedlist? (eol | ':') localVars linelist lineNumber? 'END DEFine' ID?						#FuncDecl
	| 'FOR' loopVar '=' expr 'TO' expr step? eol linelist lineNumber? ('END FOR' | 'NEXT') ID?											#For
	| 'FOR' loopVar '=' expr 'TO' expr ':' stmtlist																						#For
	| 'REPeat' loopVar ':' stmtlist																										#Repeat
	| 'REPeat' ID eol linelist lineNumber? 'END REPeat' ID?																				#Repeat
	| 'IF' expr ('THEN' | ':')? eol linelist lineNumber? ('ELSE' (eol | ':') linelist)?   lineNumber? 'END IF'					#If
	| 'IF' expr ('THEN' | ':')? stmtlist ('ELSE' stmtlist)? 																			#If
    | 'SELect ON' constexpr eol linelist lineNumber? 'END SELect'																		#Select
	| 'ON' (constexpr) '=' rangeexpr																									#Onselect
	| 'EXIT' ID?																														#Exitstmt
	| identifier '=' expr																												#Assignment
	| ID unparenthesizedlist?																											#ProcCall
	| 'PRINT' '\\'* expr? '\\'* (separator '\\'* expr '\\'* )* separator? eol?																		#Print
	| '=' unparenthesizedlist																											#Equal
	;

expr :
	  '(' expr ')'																														#ParenthesizedExpr
	| ('+' | '-') expr																													#UnaryAdditiveExpr
	| expr '&' expr																														#BinaryExpr
	| <assoc=right> (String | ID) 'INSTR' expr																							#InstrExpr
	| <assoc=right> expr '^' expr																										#BinaryExpr
	| expr ('*' | '/' | 'MOD' | 'DIV') expr																								#BinaryExpr
	| expr ('+' | '-') expr																												#BinaryExpr
	| expr ('=' | '<>' | '<' | '>' | '<=' | '>=') expr																					#BinaryExpr
	| 'NOT' expr																														#NotExpr
	| expr ('AND') expr																													#BinaryExpr
	| expr ('||' | 'OR' | 'XOR') expr																											#BinaryExpr
	| identifier																														#IdentExpr
	| (Integer | String | Real)																											#LiteralExpr
	;

constexpr : Integer | Real | String | ID;
rangeexpr : constexpr 'TO' constexpr
		  | constexpr
		  ;

step : 'STEP' expr; 
functionName : ID;
procedureName : ID;
loopVar : ID;
localVars : (lineNumber 'LOCal' unparenthesizedlist? eol)*;
identifier : ID (parenthesizedlist )?;   // could be function call or array refrence

parenthesizedlist :	'(' expr (separator expr)* ')';
unparenthesizedlist : expr (separator expr)*;

separator : ',' | '!' | ';' | 'TO';
terminator: (eol | ':');       
Whitespace
    :   [ \t]+
        -> skip
    ;

Let : 'LET' -> skip;

Newline
    :   (( '\r' '\n') |   '\n') 
	;
eol : Newline;

String : '"' ~('"')* '"' | '\'' ~('\'')* '\'';

Comment
	:  'REMark' ~( '\r' | '\n' )*
	;

ID : 
    |'GO TO'
	| 'GO SUB'
	| ([A-Za-z] | '_') ([0-9] | [A-Za-z] | '_')* '$'
	| ([A-Za-z] | '_') ([0-9] | [A-Za-z] | '_')* '%'
	| ([A-Za-z] | '_') ([0-9] | [A-Za-z] | '_')*;
	
Integer : '#'? DIGIT+;
lineNumber : Integer;

Real : DIGIT* '.' DIGIT* ;

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
