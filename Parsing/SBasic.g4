grammar SBasic;

program : line* EOF;

line :
	Newline? Integer? stmtlist Newline 
	| Integer ':' Newline
	;

stmtlist : stmt (':' stmt)*;

stmt :
	'DIM' ID parenthesizedlist																											#Dim
	| 'LOCal' unparenthesizedlist																										#Loc
	| ('IMPLICIT%' | 'IMPLICIT$') unparenthesizedlist																					#Implicit
	| 'REFERENCE' unparenthesizedlist																									#Reference
	| 'DEFine PROCedure' ID parenthesizedlist? Newline Integer? line* Integer? 'END DEFine' ID?											#Proc
	| 'DEFine FuNction' ID parenthesizedlist? Newline Integer? line* Integer? 'END DEFine' ID? 											#Func
	| 'FOR' ID '=' expr 'TO' expr ('STEP' expr)? Newline line* Integer? 'END FOR' ID?													#For
	| 'FOR' ID '=' expr 'TO' expr ':' stmtlist																							#For
	| 'REPeat' ID ':' stmtlist																											#Shortrepeat
	| 'REPeat' ID Newline line* Integer? 'END REPeat' ID?																				#Longrepeat
	| 'IF' expr ('THEN' | ':')? Newline line* Integer? ('ELSE' Newline line*)?  Integer? 'END IF'									#Longif
	| 'IF' expr ('THEN' | ':')? stmtlist ('ELSE' stmtlist)? 									#Longif
    | 'SELect ON' constexpr Newline line* Integer? 'END SELect'																			#Longselect
	| 'ON' (constexpr) '=' rangeexpr																									#Onselect
	| 'EXIT' ID?																														#Exitstmt
	| ID expr? (',' expr)*											#ProcCall
	| identifier '=' expr																												#Assignment
	| 'PRINT' expr? (separator expr)* Newline?																							#Print
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
	| Not expr																															#NotExpr
	| expr ('AND' | 'OR' | 'XOR') expr																									#BinaryExpr
	| identifier																														#IdentExpr
	| (Integer | String | Real)																											#LiteralExpr
	;

constexpr : Integer | Real | String | ID;
rangeexpr : constexpr 'TO' constexpr
		  | constexpr
;

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

String : '"' ~('"')* '"';

Comment
	:  'REMark' ~( '\r' | '\n' )* -> skip
	;

ID : LETTER ([0-9] | [A-Za-z] | '_')* '$'
	| LETTER ([0-9] | [A-Za-z] | '_')* '%'
	| LETTER ([0-9] | [A-Za-z] | '_')*;

Integer : DIGIT+;
LineNumber : DIGIT+;

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
