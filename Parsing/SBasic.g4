grammar SBasic;

program : linelist EOF;

linelist : ((lineNumber? stmt terminator?) | (lineNumber (':')+ eol))*;
stmtlist : stmt? terminator (stmt terminator)*;

stmt :
      Comment 																															#Comment
	| identifier '=' expr																												#Assignment
	| 'DIM' ID parenthesizedlist (',' ID parenthesizedlist)* eol?																		#Dim
	| ('IMPLICIT%' | 'IMPLICIT$') unparenthesizedlist																					#Implicit
	| 'REFERENCE' unparenthesizedlist																									#Reference
	| 'DEFine PROCedure' procedureName parenthesizedlist? terminator linelist? localVars? linelist? lineNumber? 'END DEFine' ID?	#ProcDecl
	| 'DEFine FuNction' functionName parenthesizedlist? terminator linelist? localVars linelist? lineNumber? 'END DEFine' ID?		#FuncDecl
	| 'FOR' loopVar '=' expr 'TO' expr step? eol lineNumber? linelist lineNumber? ('END FOR' | 'NEXT') ID? terminator											#For
	| 'FOR' loopVar '=' expr 'TO' expr  stmtlist																						#For
	| 'REPeat' loopVar  stmtlist																										#Repeat
	| 'REPeat' ID eol linelist? lineNumber? 'END REPeat' ID?																				#Repeat
	| 'IF' expr 'THEN'? eol linelist? lineNumber? else? lineNumber? 'END IF'								#If
	| 'IF' expr ('THEN' | ':') stmtlist else? 																			#If
    | 'SELect ON' constexpr terminator linelist lineNumber? 'END SELect'																		#Select
	| 'ON' (constexpr) '=' rangeexpr																									#Onselect
	| ID unparenthesizedlist?																											#ProcCall
	| '=' unparenthesizedlist																											#Equal
	| 'NEXT' ID?																														#Next
	| 'DATA' unparenthesizedlist																										#Data
	| 'PRINT' '\\'* expr? '\\'* (separator '\\'* expr  )* separator? 																	#Print
	| 'READ' unparenthesizedlist																										#Read
	| 'RETurn' unparenthesizedlist?																										#Return
	;

expr :
	  '(' expr ')'																														#ParenthesizedExpr
	| ('+' | '-') expr																													#UnaryAdditiveExpr
	| expr ('&' | '&&') expr																											#BinaryExpr
	| <assoc=right> (identifier | String) 'INSTR' expr																							#InstrExpr
	| <assoc=right> expr '^' expr																										#BinaryExpr
	| expr ('*' | '/' | 'MOD' | 'DIV') expr																								#BinaryExpr
	| expr ('+' | '-') expr																												#BinaryExpr
	| expr ('=' | '==' | '<>' | '<' | '>' | '<=' | '>=') expr																		#BinaryExpr
	| ('NOT' | '~') expr																														#NotExpr
	| expr ('AND' | '&&') expr																													#BinaryExpr
	| expr ('^^' || '||' | 'OR' | 'XOR') expr																											#BinaryExpr
	| identifier																														#IdentExpr
	| (Integer | String | Real)																											#LiteralExpr
	;

constexpr : Integer | Real | String | ID;
rangeexpr : constexpr 'TO' constexpr
		  | constexpr
		  ;

else :  'ELSE' ((eol linelist) | ( stmtlist));
step : 'STEP' expr; 
functionName : ID;
procedureName : ID;
loopVar : ID;
localVars : (lineNumber? 'LOCal' unparenthesizedlist? terminator)*;
identifier : ID (parenthesizedlist )?;   // could be function call or array refrence

parenthesizedlist :	'(' expr (separator expr)* ')';
unparenthesizedlist : expr (separator expr)*;

separator : ',' | '!' | ';' | 'TO';
terminator: (eol | ':' );      

Whitespace
    :   [ \t]+
        -> skip
    ;

Let : 'LET' -> skip;
//Colon : ':' -> skip;
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
	| ([A-Za-z] | '_' | '#') ([0-9] | [A-Za-z] | '_')* '$'
	| ([A-Za-z] | '_' | '#') ([0-9] | [A-Za-z] | '_')* '%'
	| ([A-Za-z] | '_' | '#') ([0-9] | [A-Za-z] | '_')*;
	
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
