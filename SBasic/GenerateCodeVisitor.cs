using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Parsing;
using SBasic.SymbolTable;

namespace SBasic
{
    internal class GenerateCodeVisitor<TResult>: SBasicBaseVisitor<TResult>, ISBasicVisitor<TResult> where TResult : notnull
        {
            private SymbolTable<Symbol> _symbols { get; set; }

        protected override TResult DefaultResult => base.DefaultResult;

        public GenerateCodeVisitor(SymbolTable.SymbolTable<Symbol> symbolTable) => _symbols = symbolTable;

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override TResult Visit([NotNull] IParseTree tree)
        {
            return base.Visit(tree);
        }

        public override TResult VisitChildren([NotNull] IRuleNode node)
        {
            return base.VisitChildren(node);
        }

        public override TResult VisitTerminal([NotNull] ITerminalNode node)
        {
            return base.VisitTerminal(node);
        }

        public override TResult VisitErrorNode([NotNull] IErrorNode node)
        {
            return base.VisitErrorNode(node);
        }

        protected override TResult AggregateResult(TResult aggregate, TResult nextResult)
        {
            return base.AggregateResult(aggregate, nextResult);
        }

        protected override bool ShouldVisitNextChild([NotNull] IRuleNode node, TResult currentResult)
        {
            return base.ShouldVisitNextChild(node, currentResult);
        }

        public override TResult VisitParenthesizedl([NotNull] SBasicParser.ParenthesizedlContext context)
        {
            return base.VisitParenthesizedl(context);
        }

        public override TResult VisitUnparenthesized([NotNull] SBasicParser.UnparenthesizedContext context)
        {
            return base.VisitUnparenthesized(context);
        }

        public override TResult VisitProcheader([NotNull] SBasicParser.ProcheaderContext context)
        {
            return base.VisitProcheader(context);
        }

        public override TResult VisitFuncheader([NotNull] SBasicParser.FuncheaderContext context)
        {
            return base.VisitFuncheader(context);
        }

        public override TResult VisitNot([NotNull] SBasicParser.NotContext context)
        {
            return base.VisitNot(context);
        }

        public override TResult VisitUnaryAdditive([NotNull] SBasicParser.UnaryAdditiveContext context)
        {
            return base.VisitUnaryAdditive(context);
        }

        public override TResult VisitIdent([NotNull] SBasicParser.IdentContext context)
        {
            return base.VisitIdent(context);
        }

        public override TResult VisitInstr([NotNull] SBasicParser.InstrContext context)
        {
            return base.VisitInstr(context);
        }

        public override TResult VisitParenthesized([NotNull] SBasicParser.ParenthesizedContext context)
        {
            return base.VisitParenthesized(context);
        }

        public override TResult VisitLiteral([NotNull] SBasicParser.LiteralContext context)
        {
            return base.VisitLiteral(context);
        }

        public override TResult VisitBinary([NotNull] SBasicParser.BinaryContext context)
        {
            return base.VisitBinary(context);
        }

        public override TResult VisitLoc([NotNull] SBasicParser.LocContext context)
        {
            return base.VisitLoc(context);
        }

        public override TResult VisitLongselect([NotNull] SBasicParser.LongselectContext context)
        {
            return base.VisitLongselect(context);
        }

        public override TResult VisitExitstmt([NotNull] SBasicParser.ExitstmtContext context)
        {
            return base.VisitExitstmt(context);
        }

        public override TResult VisitFunc([NotNull] SBasicParser.FuncContext context)
        {
            return base.VisitFunc(context);
        }

        public override TResult VisitReference([NotNull] SBasicParser.ReferenceContext context)
        {
            return base.VisitReference(context);
        }

        public override TResult VisitDim([NotNull] SBasicParser.DimContext context)
        {
            return base.VisitDim(context);
        }

        public override TResult VisitLongfor([NotNull] SBasicParser.LongforContext context)
        {
            return base.VisitLongfor(context);
        }

        public override TResult VisitProc([NotNull] SBasicParser.ProcContext context)
        {
            return base.VisitProc(context);
        }

        public override TResult VisitAssignment([NotNull] SBasicParser.AssignmentContext context)
        {
            return base.VisitAssignment(context);
        }

        public override TResult VisitOnselect([NotNull] SBasicParser.OnselectContext context)
        {
            return base.VisitOnselect(context);
        }

        public override TResult VisitShortif([NotNull] SBasicParser.ShortifContext context)
        {
            return base.VisitShortif(context);
        }

        public override TResult VisitLongif([NotNull] SBasicParser.LongifContext context)
        {
            return base.VisitLongif(context);
        }

        public override TResult VisitIdentifierOnly([NotNull] SBasicParser.IdentifierOnlyContext context)
        {
            return base.VisitIdentifierOnly(context);
        }

        public override TResult VisitShortrepeat([NotNull] SBasicParser.ShortrepeatContext context)
        {
            return base.VisitShortrepeat(context);
        }

        public override TResult VisitImplicit([NotNull] SBasicParser.ImplicitContext context)
        {
            return base.VisitImplicit(context);
        }

        public override TResult VisitShortfor([NotNull] SBasicParser.ShortforContext context)
        {
            return base.VisitShortfor(context);
        }

        public override TResult VisitLongrepeat([NotNull] SBasicParser.LongrepeatContext context)
        {
            return base.VisitLongrepeat(context);
        }

        public override TResult VisitProgram([NotNull] SBasicParser.ProgramContext context)
        {
            return base.VisitProgram(context);
        }

        public override TResult VisitLine([NotNull] SBasicParser.LineContext context)
        {
            return base.VisitLine(context);
        }

        public override TResult VisitStmtlist([NotNull] SBasicParser.StmtlistContext context)
        {
            return base.VisitStmtlist(context);
        }

        public override TResult VisitConstexpr([NotNull] SBasicParser.ConstexprContext context)
        {
            return base.VisitConstexpr(context);
        }

        public override TResult VisitRangeexpr([NotNull] SBasicParser.RangeexprContext context)
        {
            return base.VisitRangeexpr(context);
        }

        public override TResult VisitStmt([NotNull] SBasicParser.StmtContext context)
        {
            return base.VisitStmt(context);
        }

        public override TResult VisitProchdr([NotNull] SBasicParser.ProchdrContext context)
        {
            return base.VisitProchdr(context);
        }

        public override TResult VisitFunchdr([NotNull] SBasicParser.FunchdrContext context)
        {
            return base.VisitFunchdr(context);
        }

        public override TResult VisitIdentifier([NotNull] SBasicParser.IdentifierContext context)
        {
            return base.VisitIdentifier(context);
        }

        public override TResult VisitParenthesizedlist([NotNull] SBasicParser.ParenthesizedlistContext context)
        {
            return base.VisitParenthesizedlist(context);
        }

        public override TResult VisitUnparenthesizedlist([NotNull] SBasicParser.UnparenthesizedlistContext context)
        {
            return base.VisitUnparenthesizedlist(context);
        }

        public override TResult VisitSeparator([NotNull] SBasicParser.SeparatorContext context)
        {
            return base.VisitSeparator(context);
        }

        public override TResult VisitExpr([NotNull] SBasicParser.ExprContext context)
        {
            return base.VisitExpr(context);
        }
    }
}