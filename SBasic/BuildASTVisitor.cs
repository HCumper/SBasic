using System.Collections.Generic;
using System.ComponentModel;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Antlr4.StringTemplate;
using Parsing;
using SBasic.NodeClasses;
using SBasic.SymbolTable;

namespace SBasic
{
    internal class BuildASTVisitor<TResult>: SBasicBaseVisitor<TResult>, ISBasicVisitor<TResult> where TResult : notnull
    {

        public ASTBaseNode previousNode = new ASTBaseNode();
        private TypeConverter _converter = TypeDescriptor.GetConverter(typeof (TResult));

        public TypeConverter Converter { get => _converter; set => _converter = value; }

        protected override TResult DefaultResult => base.DefaultResult;

        public BuildASTVisitor()
        {
        }

        private TResult ConvertFromString(string text)
        {
            return (TResult)_converter.ConvertFromString(text);
        }
        private string ConvertToString(TResult result)
        {
            return (string)_converter.ConvertToString(result);
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override TResult Visit([NotNull] IParseTree tree)
        {

            return base.Visit(tree);
        }

        public override TResult VisitTerminal([NotNull] ITerminalNode node)
        {
            ASTDimNode onode = (ASTDimNode)previousNode;
            onode.dimensions.Add(node.GetText());
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

        public override TResult VisitProcheader([NotNull] SBasicParser.ProcheaderContext context)
        {
            return base.VisitProcheader(context);
        }

        public override TResult VisitFuncheader([NotNull] SBasicParser.FuncheaderContext context)
        {
            return base.VisitFuncheader(context);
        }

        public override TResult VisitIdentExpr([NotNull] SBasicParser.IdentExprContext context)
        {
            return base.VisitIdentExpr(context);
        }

        public override TResult VisitBinaryExpr([NotNull] SBasicParser.BinaryExprContext context)
        {
            return base.VisitBinaryExpr(context);
        }

        public override TResult VisitLiteralExpr([NotNull] SBasicParser.LiteralExprContext context)
        {
            return base.VisitLiteralExpr(context);
        }

        public override TResult VisitParenthesizedExpr([NotNull] SBasicParser.ParenthesizedExprContext context)
        {
            return base.VisitParenthesizedExpr(context);
        }

        public override TResult VisitInstrExpr([NotNull] SBasicParser.InstrExprContext context)
        {
            return base.VisitInstrExpr(context);
        }

        public override TResult VisitNotExpr([NotNull] SBasicParser.NotExprContext context)
        {
            return base.VisitNotExpr(context);
        }

        public override TResult VisitUnaryAdditiveExpr([NotNull] SBasicParser.UnaryAdditiveExprContext context)
        {
            return base.VisitUnaryAdditiveExpr(context);
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
            ASTDimNode node = new ASTDimNode();
            node.LineNumber = context.Start.Line;
            node.Operation = context.Payload.ToString();
            ((ASTProgramNode)previousNode).children.Add(node);
            previousNode = node;

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
            ASTProgramNode node = new ASTProgramNode();
            node.LineNumber = context.Start.Line;
            node.Operation = context.Payload.ToString();
            previousNode = node;
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


        /////////////////////////////////////////////////////////////////////////////////////////////////////
        // Antlr runtime implementation
        public override TResult VisitChildren([NotNull] IRuleNode node)
        {
            TResult result = this.DefaultResult;
            int childCount = node.ChildCount;
            for (int i = 0; i < childCount && this.ShouldVisitNextChild(node, result); ++i)
            {
                TResult nextResult = node.GetChild(i).Accept<TResult>((IParseTreeVisitor<TResult>) this);
                result = this.AggregateResult(result, nextResult);
            }
            return result;
        }

        //// Antlr runtime implementation
        //protected  override TResult AggregateResult(TResult aggregate, TResult nextResult)
        //{
        //    return nextResult;
        //}

    }
}