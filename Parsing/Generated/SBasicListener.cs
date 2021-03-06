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
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="SBasicParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface ISBasicListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>Parenthesizedl</c>
	/// labeled alternative in <see cref="SBasicParser.parenthesizedlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParenthesizedl([NotNull] SBasicParser.ParenthesizedlContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Parenthesizedl</c>
	/// labeled alternative in <see cref="SBasicParser.parenthesizedlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParenthesizedl([NotNull] SBasicParser.ParenthesizedlContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Unparenthesized</c>
	/// labeled alternative in <see cref="SBasicParser.unparenthesizedlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnparenthesized([NotNull] SBasicParser.UnparenthesizedContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Unparenthesized</c>
	/// labeled alternative in <see cref="SBasicParser.unparenthesizedlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnparenthesized([NotNull] SBasicParser.UnparenthesizedContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Procheader</c>
	/// labeled alternative in <see cref="SBasicParser.prochdr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProcheader([NotNull] SBasicParser.ProcheaderContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Procheader</c>
	/// labeled alternative in <see cref="SBasicParser.prochdr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProcheader([NotNull] SBasicParser.ProcheaderContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Funcheader</c>
	/// labeled alternative in <see cref="SBasicParser.funchdr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncheader([NotNull] SBasicParser.FuncheaderContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Funcheader</c>
	/// labeled alternative in <see cref="SBasicParser.funchdr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncheader([NotNull] SBasicParser.FuncheaderContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Not</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNot([NotNull] SBasicParser.NotContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Not</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNot([NotNull] SBasicParser.NotContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>UnaryAdditive</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryAdditive([NotNull] SBasicParser.UnaryAdditiveContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>UnaryAdditive</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryAdditive([NotNull] SBasicParser.UnaryAdditiveContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Ident</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdent([NotNull] SBasicParser.IdentContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Ident</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdent([NotNull] SBasicParser.IdentContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Instr</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInstr([NotNull] SBasicParser.InstrContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Instr</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInstr([NotNull] SBasicParser.InstrContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Parenthesized</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParenthesized([NotNull] SBasicParser.ParenthesizedContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Parenthesized</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParenthesized([NotNull] SBasicParser.ParenthesizedContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Literal</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteral([NotNull] SBasicParser.LiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Literal</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteral([NotNull] SBasicParser.LiteralContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Binary</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBinary([NotNull] SBasicParser.BinaryContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Binary</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBinary([NotNull] SBasicParser.BinaryContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Loc</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLoc([NotNull] SBasicParser.LocContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Loc</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLoc([NotNull] SBasicParser.LocContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Longselect</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLongselect([NotNull] SBasicParser.LongselectContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Longselect</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLongselect([NotNull] SBasicParser.LongselectContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Exitstmt</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExitstmt([NotNull] SBasicParser.ExitstmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Exitstmt</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExitstmt([NotNull] SBasicParser.ExitstmtContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Func</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunc([NotNull] SBasicParser.FuncContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Func</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunc([NotNull] SBasicParser.FuncContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Reference</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReference([NotNull] SBasicParser.ReferenceContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Reference</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReference([NotNull] SBasicParser.ReferenceContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Dim</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDim([NotNull] SBasicParser.DimContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Dim</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDim([NotNull] SBasicParser.DimContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Longfor</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLongfor([NotNull] SBasicParser.LongforContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Longfor</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLongfor([NotNull] SBasicParser.LongforContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Proc</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProc([NotNull] SBasicParser.ProcContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Proc</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProc([NotNull] SBasicParser.ProcContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Assignment</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] SBasicParser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Assignment</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] SBasicParser.AssignmentContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Onselect</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOnselect([NotNull] SBasicParser.OnselectContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Onselect</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOnselect([NotNull] SBasicParser.OnselectContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Shortif</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterShortif([NotNull] SBasicParser.ShortifContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Shortif</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitShortif([NotNull] SBasicParser.ShortifContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Longif</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLongif([NotNull] SBasicParser.LongifContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Longif</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLongif([NotNull] SBasicParser.LongifContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>IdentifierOnly</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifierOnly([NotNull] SBasicParser.IdentifierOnlyContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>IdentifierOnly</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifierOnly([NotNull] SBasicParser.IdentifierOnlyContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Shortrepeat</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterShortrepeat([NotNull] SBasicParser.ShortrepeatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Shortrepeat</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitShortrepeat([NotNull] SBasicParser.ShortrepeatContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Implicit</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterImplicit([NotNull] SBasicParser.ImplicitContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Implicit</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitImplicit([NotNull] SBasicParser.ImplicitContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Shortfor</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterShortfor([NotNull] SBasicParser.ShortforContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Shortfor</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitShortfor([NotNull] SBasicParser.ShortforContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>Longrepeat</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLongrepeat([NotNull] SBasicParser.LongrepeatContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>Longrepeat</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLongrepeat([NotNull] SBasicParser.LongrepeatContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] SBasicParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] SBasicParser.ProgramContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLine([NotNull] SBasicParser.LineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLine([NotNull] SBasicParser.LineContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.stmtlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStmtlist([NotNull] SBasicParser.StmtlistContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.stmtlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStmtlist([NotNull] SBasicParser.StmtlistContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.constexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstexpr([NotNull] SBasicParser.ConstexprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.constexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstexpr([NotNull] SBasicParser.ConstexprContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.rangeexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRangeexpr([NotNull] SBasicParser.RangeexprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.rangeexpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRangeexpr([NotNull] SBasicParser.RangeexprContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStmt([NotNull] SBasicParser.StmtContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStmt([NotNull] SBasicParser.StmtContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.prochdr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProchdr([NotNull] SBasicParser.ProchdrContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.prochdr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProchdr([NotNull] SBasicParser.ProchdrContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.funchdr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunchdr([NotNull] SBasicParser.FunchdrContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.funchdr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunchdr([NotNull] SBasicParser.FunchdrContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifier([NotNull] SBasicParser.IdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifier([NotNull] SBasicParser.IdentifierContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.parenthesizedlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParenthesizedlist([NotNull] SBasicParser.ParenthesizedlistContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.parenthesizedlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParenthesizedlist([NotNull] SBasicParser.ParenthesizedlistContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.unparenthesizedlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnparenthesizedlist([NotNull] SBasicParser.UnparenthesizedlistContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.unparenthesizedlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnparenthesizedlist([NotNull] SBasicParser.UnparenthesizedlistContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.separator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSeparator([NotNull] SBasicParser.SeparatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.separator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSeparator([NotNull] SBasicParser.SeparatorContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpr([NotNull] SBasicParser.ExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpr([NotNull] SBasicParser.ExprContext context);
}
} // namespace Parsing
