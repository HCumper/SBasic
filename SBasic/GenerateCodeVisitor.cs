﻿using System.Collections.Generic;
using System.ComponentModel;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Antlr4.StringTemplate;
using Antlr4.StringTemplate.Compiler;
using Parsing;
using SBasic.SymbolTable;

namespace SBasic
{
    internal class GenerateCodeVisitor<TResult>: SBasicBaseVisitor<TResult>, ISBasicVisitor<TResult> where TResult : notnull
    {
        private SymbolTable<Symbol> symbols;

        private SymbolTable<Symbol> GetSymbols()
        {
            return symbols;
        }

        private void SetSymbols(SymbolTable<Symbol> value)
        {
            symbols = value;
        }

        private TypeConverter _converter = TypeDescriptor.GetConverter(typeof (TResult));
        private string Output { get; set; } = "";
        protected override TResult DefaultResult => base.DefaultResult;

        public TypeConverter Converter { get => _converter; set => _converter = value; }

        private readonly IDictionary<string, Template> _templates = new Dictionary<string, Template>();
        private readonly TemplateGroupFile _group;

        public GenerateCodeVisitor(SymbolTable.SymbolTable<Symbol> symbolTable)
        {
            SetSymbols(symbolTable);
            _group = new TemplateGroupFile(@"c:/users/hcump/source/repos/SBasic/SBasic/Templates.stg");

            string[] templateNames = { "assignmentTemplate", "identifierOnlyTemplate" };
            foreach (string templateName in templateNames)
                _templates.Add(templateName, _group.GetInstanceOf(templateName));
        }

        private TResult ConvertFromString(string text)
        {
            return (TResult)_converter.ConvertFromString(text);
        }
        private string ConvertToString(TResult result)
        {
            return _converter.ConvertToString(result);
        }

        private TResult Emit(Template template, SBasicParser.StmtContext context)
        {
            //if ((context.Parent.Parent.Parent).GetType() == typeof(SBasicParser.ProgramContext))
            //{
            //    string strResult = template.Render() + "\n";
            //    Output += strResult;
            //    return ConvertFromString("");
            //}
            //else
            //{
            return ConvertFromString(template.Render());
            //}
        }

        private TResult EmitList(Template template, SBasicParser.StmtlistContext context)
        {
            //if ((context.Parent.Parent).GetType() == typeof(SBasicParser.ProgramContext))
            //{
            //    string strResult = template.Render() + "\n";
            //    Output += strResult;
            //    return ConvertFromString("");
            //}
            //else
            //{
            return ConvertFromString(template.Render());
            //}
        }

        public override TResult Visit([NotNull] IParseTree tree)
        {
            return base.Visit(tree);
        }

        public TResult GenericVisitor([NotNull] IParseTree tree, IEnumerable<int> slots, string templateName)
        {
            List<string> parseResults = new List<string>();
            List<string> args = new List<string>();
            foreach (int slot in slots)
                parseResults.Add(ConvertToString(base.Visit(tree.GetChild(slot))));
            var template = (_group.GetInstanceOf(templateName));
            foreach (FormalArgument arg in template.impl.FormalArguments) args.Add(arg.ToString());
            for (int i = 0; i < parseResults.Count; i++)
                template.Add(args[i], parseResults[i]);
            var temp = ConvertFromString(template.Render());
            return temp;
        }

        public override TResult VisitAssignment([NotNull] SBasicParser.AssignmentContext context)
        {
            int[] slots =  { 0, 2 };
            return GenericVisitor(context, slots, "assignmentTemplate");
        }

        public override TResult VisitDim([NotNull] SBasicParser.DimContext context)
        {
            return DefaultResult;
        }
        public override TResult VisitExpr([NotNull] SBasicParser.ExprContext context)
        {
            var temp = base.VisitExpr(context);
            return temp;
        }
        public override TResult VisitLongfor([NotNull] SBasicParser.LongforContext context)
        {
            // For ID Equal expr To expr Newline linelist Integer? EndFor ID?	
            int[] slots =  { 1, 3, 5, 7 };
            return GenericVisitor(context, slots, "forTemplate");
        }
        public override TResult VisitFunc([NotNull] SBasicParser.FuncContext context)
        {
            var functionName = ConvertToString(Visit(context.GetChild(1).GetChild(0)));
            List<string> parameters = new List<string>();
            var parameterList= context.GetChild(1).GetChild(1);
            for (int i = 1; i < parameterList.ChildCount - 1; i += 2)
            {
                parameters.Add(ConvertToString(Visit(parameterList.GetChild(i))));
            }
            var returnType = "object";
            var content = Visit(context.GetChild(4));
            var template = _group.GetInstanceOf("functionTemplate");
            template.Add("returnType", returnType);
            template.Add("functionName", functionName);
            template.Add("params", parameters);
            template.Add("body", content);
            return Emit(template, context);

//            return ConvertFromString(functionName);
        }
        public override TResult VisitIdentifier([NotNull] SBasicParser.IdentifierContext context)
        {
            var ttok = Visit(context.GetChild(0));
            var tok = ConvertToString(ttok);
            if (context.ChildCount > 1)
            {
                // () for function calls/definitions [] for arrays
                SymbolTable<Symbol> symbols = GetSymbols();
                Symbol sym = symbols.ReadSymbol(tok, SymbolTable<Symbol>.Global).Item2;
                ttok = Visit(context.GetChild(1));
                var tok2 = ConvertToString(ttok);
                tok = (sym.GetType() == typeof(ArraySymbol)) ? $"{tok}[{tok2}]" : $"{tok}({tok2})";
            }
            return ConvertFromString(tok);
        }

        public override TResult VisitIdentExpr([NotNull] SBasicParser.IdentExprContext context)
        {
            return base.VisitIdentExpr(context);
        }
        public override TResult VisitIdentifierOnly([NotNull] SBasicParser.IdentifierOnlyContext context)
        {
            TResult id = base.VisitIdentifierOnly(context);
            var template = _group.GetInstanceOf("identifierOnlyTemplate");
            template.Add("id", id);
            return Emit(template, context);
        }
        public override TResult VisitLine([NotNull] SBasicParser.LineContext context)
        {
            var temp = base.Visit(context.GetChild(context.ChildCount - 2));
            return temp;
        }
        public override TResult VisitParenthesizedlist([NotNull] SBasicParser.ParenthesizedlistContext context)
        {
            return base.Visit(context.GetChild(1));
        }
        public override TResult VisitPrint([NotNull] SBasicParser.PrintContext context)
        {
            List<string> expressions = new List<string>();
            int nodes = context.ChildCount;
            for (int i = 1; i < nodes; i += 2)
                expressions.Add(ConvertToString(Visit(context.GetChild(i))));
            var template = _group.GetInstanceOf("printTemplate");
            template.Add("params", expressions);
            var temp = ConvertFromString(template.Render());
            return temp;
        }
        public override TResult VisitProc([NotNull] SBasicParser.ProcContext context)
        {
            return base.VisitProc(context);
        }
        public override TResult VisitProgram([NotNull] SBasicParser.ProgramContext context)
        {
            _ = base.VisitProgram(context);
            return (TResult)_converter.ConvertFromString(Output);
        }
        
        public override TResult VisitShortfor([NotNull] SBasicParser.ShortforContext context)
        {
            int[] slots =  { 1, 3, 5, 7 };
            return GenericVisitor(context, slots, "forTemplate");
        }
        public override TResult VisitStmtlist([NotNull] SBasicParser.StmtlistContext context)
        {
            List<string> statements = new List<string>();
            int nodes = context.ChildCount;
            for (int i = 0; i < nodes; i += 2)
                statements.Add(ConvertToString(Visit(context.GetChild(i))));
            var template = _group.GetInstanceOf("statementListTemplate");
            template.Add("statements", statements);
            return EmitList(template, context);
        }
        public override TResult VisitTerminal([NotNull] ITerminalNode node)
        {
            var temp = ConvertFromString(node.Symbol.Text);
            return temp;
        }


        /// /////////////////////////////////////////////////////////////////////////////////////////////////////
        //// Antlr runtime implementation
        //public override TResult VisitChildren([NotNull] IRuleNode node)
        //{
        //    TResult result = this.DefaultResult;
        //    int childCount = node.ChildCount;
        //    for (int i = 0; i < childCount && this.ShouldVisitNextChild(node, result); ++i)
        //    {
        //        TResult nextResult = node.GetChild(i).Accept<TResult>((IParseTreeVisitor<TResult>) this);
        //        result = this.AggregateResult(result, nextResult);
        //    }
        //    return result;
        //}

        //// Antlr runtime implementation
        //protected  override TResult AggregateResult(TResult aggregate, TResult nextResult)
        //{
        //    return nextResult;
        //}
    }
}