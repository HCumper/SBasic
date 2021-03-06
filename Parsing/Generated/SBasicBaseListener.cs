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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="ISBasicListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class SBasicBaseListener : ISBasicListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>Parenthesizedl</c>
	/// labeled alternative in <see cref="SBasicParser.parenthesizedlist"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParenthesizedl([NotNull] SBasicParser.ParenthesizedlContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Parenthesizedl</c>
	/// labeled alternative in <see cref="SBasicParser.parenthesizedlist"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParenthesizedl([NotNull] SBasicParser.ParenthesizedlContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Unparenthesized</c>
	/// labeled alternative in <see cref="SBasicParser.unparenthesizedlist"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterUnparenthesized([NotNull] SBasicParser.UnparenthesizedContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Unparenthesized</c>
	/// labeled alternative in <see cref="SBasicParser.unparenthesizedlist"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitUnparenthesized([NotNull] SBasicParser.UnparenthesizedContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Procheader</c>
	/// labeled alternative in <see cref="SBasicParser.prochdr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProcheader([NotNull] SBasicParser.ProcheaderContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Procheader</c>
	/// labeled alternative in <see cref="SBasicParser.prochdr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProcheader([NotNull] SBasicParser.ProcheaderContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Funcheader</c>
	/// labeled alternative in <see cref="SBasicParser.funchdr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFuncheader([NotNull] SBasicParser.FuncheaderContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Funcheader</c>
	/// labeled alternative in <see cref="SBasicParser.funchdr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFuncheader([NotNull] SBasicParser.FuncheaderContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Not</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNot([NotNull] SBasicParser.NotContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Not</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNot([NotNull] SBasicParser.NotContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>UnaryAdditive</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterUnaryAdditive([NotNull] SBasicParser.UnaryAdditiveContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>UnaryAdditive</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitUnaryAdditive([NotNull] SBasicParser.UnaryAdditiveContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Ident</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIdent([NotNull] SBasicParser.IdentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Ident</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIdent([NotNull] SBasicParser.IdentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Instr</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInstr([NotNull] SBasicParser.InstrContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Instr</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInstr([NotNull] SBasicParser.InstrContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Parenthesized</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParenthesized([NotNull] SBasicParser.ParenthesizedContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Parenthesized</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParenthesized([NotNull] SBasicParser.ParenthesizedContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Literal</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLiteral([NotNull] SBasicParser.LiteralContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Literal</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLiteral([NotNull] SBasicParser.LiteralContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Binary</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBinary([NotNull] SBasicParser.BinaryContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Binary</c>
	/// labeled alternative in <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBinary([NotNull] SBasicParser.BinaryContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Loc</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLoc([NotNull] SBasicParser.LocContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Loc</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLoc([NotNull] SBasicParser.LocContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Longselect</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLongselect([NotNull] SBasicParser.LongselectContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Longselect</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLongselect([NotNull] SBasicParser.LongselectContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Exitstmt</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExitstmt([NotNull] SBasicParser.ExitstmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Exitstmt</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExitstmt([NotNull] SBasicParser.ExitstmtContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Func</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunc([NotNull] SBasicParser.FuncContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Func</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunc([NotNull] SBasicParser.FuncContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Reference</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReference([NotNull] SBasicParser.ReferenceContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Reference</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReference([NotNull] SBasicParser.ReferenceContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Dim</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDim([NotNull] SBasicParser.DimContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Dim</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDim([NotNull] SBasicParser.DimContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Longfor</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLongfor([NotNull] SBasicParser.LongforContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Longfor</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLongfor([NotNull] SBasicParser.LongforContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Proc</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProc([NotNull] SBasicParser.ProcContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Proc</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProc([NotNull] SBasicParser.ProcContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Assignment</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignment([NotNull] SBasicParser.AssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Assignment</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignment([NotNull] SBasicParser.AssignmentContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Onselect</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOnselect([NotNull] SBasicParser.OnselectContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Onselect</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOnselect([NotNull] SBasicParser.OnselectContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Shortif</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterShortif([NotNull] SBasicParser.ShortifContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Shortif</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitShortif([NotNull] SBasicParser.ShortifContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Longif</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLongif([NotNull] SBasicParser.LongifContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Longif</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLongif([NotNull] SBasicParser.LongifContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>IdentifierOnly</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIdentifierOnly([NotNull] SBasicParser.IdentifierOnlyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>IdentifierOnly</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIdentifierOnly([NotNull] SBasicParser.IdentifierOnlyContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Shortrepeat</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterShortrepeat([NotNull] SBasicParser.ShortrepeatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Shortrepeat</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitShortrepeat([NotNull] SBasicParser.ShortrepeatContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Implicit</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterImplicit([NotNull] SBasicParser.ImplicitContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Implicit</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitImplicit([NotNull] SBasicParser.ImplicitContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Shortfor</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterShortfor([NotNull] SBasicParser.ShortforContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Shortfor</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitShortfor([NotNull] SBasicParser.ShortforContext context) { }

	/// <summary>
	/// Enter a parse tree produced by the <c>Longrepeat</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLongrepeat([NotNull] SBasicParser.LongrepeatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>Longrepeat</c>
	/// labeled alternative in <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLongrepeat([NotNull] SBasicParser.LongrepeatContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProgram([NotNull] SBasicParser.ProgramContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProgram([NotNull] SBasicParser.ProgramContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.line"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLine([NotNull] SBasicParser.LineContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.line"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLine([NotNull] SBasicParser.LineContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.stmtlist"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStmtlist([NotNull] SBasicParser.StmtlistContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.stmtlist"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStmtlist([NotNull] SBasicParser.StmtlistContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.constexpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterConstexpr([NotNull] SBasicParser.ConstexprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.constexpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitConstexpr([NotNull] SBasicParser.ConstexprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.rangeexpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRangeexpr([NotNull] SBasicParser.RangeexprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.rangeexpr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRangeexpr([NotNull] SBasicParser.RangeexprContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStmt([NotNull] SBasicParser.StmtContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.stmt"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStmt([NotNull] SBasicParser.StmtContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.prochdr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProchdr([NotNull] SBasicParser.ProchdrContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.prochdr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProchdr([NotNull] SBasicParser.ProchdrContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.funchdr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunchdr([NotNull] SBasicParser.FunchdrContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.funchdr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunchdr([NotNull] SBasicParser.FunchdrContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.identifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIdentifier([NotNull] SBasicParser.IdentifierContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.identifier"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIdentifier([NotNull] SBasicParser.IdentifierContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.parenthesizedlist"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParenthesizedlist([NotNull] SBasicParser.ParenthesizedlistContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.parenthesizedlist"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParenthesizedlist([NotNull] SBasicParser.ParenthesizedlistContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.unparenthesizedlist"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterUnparenthesizedlist([NotNull] SBasicParser.UnparenthesizedlistContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.unparenthesizedlist"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitUnparenthesizedlist([NotNull] SBasicParser.UnparenthesizedlistContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.separator"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSeparator([NotNull] SBasicParser.SeparatorContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.separator"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSeparator([NotNull] SBasicParser.SeparatorContext context) { }

	/// <summary>
	/// Enter a parse tree produced by <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpr([NotNull] SBasicParser.ExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="SBasicParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpr([NotNull] SBasicParser.ExprContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
} // namespace Parsing
