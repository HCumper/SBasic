grammar SBasic;

program : linelist EOF;

linelist : line*;

line :
	Integer? stmtlist Newline 
	| Integer Colon Newline
	;

stmtlist : stmt (':' stmt)*;

constexpr : Integer | Real | String | ID;
rangeexpr : constexpr To constexpr
		  | constexpr
;

stmt :
	Dimension ID parenthesizedlist																					#Dim
	| Local unparenthesizedlist																						#Loc
	| Implic unparenthesizedlist																					#Implicit
	| Refer unparenthesizedlist																						#Reference
	| 'DEFine PROCedure' identifier parenthesizedlist? Newline Integer? linelist Integer? 'END DEFine' ID?			#Proc
	| 'DEFine FuNction' identifier parenthesizedlist? Newline Integer? linelist Integer? 'END DEFine' ID? 			#Func
	| For ID Equal expr To expr ('STEP' expr)? Newline linelist Integer? EndFor ID?									#For
	| For ID Equal expr To expr Colon stmtlist																		#For
	| Repeat ID Colon stmtlist																						#Shortrepeat
	| Repeat ID Newline line* Integer? (EndRepeat ID? /*| { _input.Lt(1).Type == EndDef }?*/)						#Longrepeat
	| If expr (Then | Colon) stmtlist (Colon Else Colon stmtlist)?													#Shortif
	| If expr (Then)? Newline line+ (Integer? Else line+)? Integer? EndIf											#Longif
    | Select constexpr Newline line* Integer? EndSelect																#Longselect
	| On (constexpr) Equal rangeexpr																				#Onselect
	| Exit ID?																										#Exitstmt
	| identifier Equal expr																							#Assignment
	| PRINT expr? (separator expr)* Newline?																		#Print
	| identifier																									#IdentifierOnly
	;

identifier :
	ID (parenthesizedlist | unparenthesizedlist)?;

parenthesizedlist :	'(' expr (separator expr)* RightParen;
unparenthesizedlist : expr (separator expr)*;

separator : Comma | Bang | Semi | To;

expr :
	  '(' expr ')'																									#ParenthesizedExpr
	| ('+' | '-') expr																								#UnaryAdditiveExpr
	| expr Amp expr																									#BinaryExpr
	| <assoc=right> (String | ID) Instr expr																		#InstrExpr
	| <assoc=right> expr Caret expr																					#BinaryExpr
	| expr ('+' | '-' | '*' | '/' | 'MOD' | 'DIV') expr																#BinaryExpr
	| expr ('=' | '<>' | '<' | '>' | '<=' | '>=') expr																#BinaryExpr
	| Not expr																										#NotExpr
	| expr ('AND' | 'OR' | 'XOR') expr																				#BinaryExpr
	| identifier																									#IdentExpr
	| (Integer | String | Real)																						#LiteralExpr
	;

/* Tokens */
Refer : 'REFERENCE';
Implic : 'IMPLICIT%' | 'IMPLICIT$';
Local : 'LOCal';
Dimension : 'DIM';
If : 'IF';
Else : 'ELSE';
Then : 'THEN';
EndIf : 'END IF';
Select : 'SELect ON';
EndSelect : 'END SELect';
On : 'ON';
For : 'FOR';
Next : 'NEXT';
To : 'TO';
EndFor : 'END FOR';
Step : 'STEP';
Repeat : 'REPeat';
Exit : 'EXIT';
Until : 'UNTIL';
EndRepeat : 'END REPeat';
PRINT : 'PRINT';

And : 'AND';
Or : 'OR';
Xor : 'XOR';
Caret : '^';
Not : 'NOT';
Tilde : '~';

Instr : 'INSTR';
Amp : '&';
Question : '?';
Colon : ':';
Semi : ';';
Comma : ',';
Point : '.';

Bang : '!';
       
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


Real
	: DIGIT+ Point DIGIT*
	| Point DIGIT+
	;

Unknowntype:;
Void:;
Scalar:;
LineNumber:;
ProcCall:;
FuncCall:;
Ignore:;


fragment LETTER : [a-zA-Z];
fragment DIGIT : [0-9];
fragment ESC : '\\"' | '\\\\' ;
