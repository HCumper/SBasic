using System.Collections.Generic;
using System.ComponentModel;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Antlr4.StringTemplate;
using Antlr4.StringTemplate.Compiler;
using Parsing;
using SBasic.SymbolTable;
using static Parsing.SBasicParser;

namespace SBasic
{
    internal class GenerateCodeVisitor<TResult>: GenericVisitor<TResult>, ISBasicVisitor<TResult> where TResult : notnull
    {
        private SymbolTable<Symbol> symbols;
        private string Scope = SymbolTable<Symbol>.Global;
        private TypeConverter _converter = TypeDescriptor.GetConverter(typeof (TResult));
        protected override TResult DefaultResult => base.DefaultResult;

        public TypeConverter Converter { get => _converter; set => _converter = value; }

        private readonly IDictionary<string, Template> _templates = new Dictionary<string, Template>();
        private readonly TemplateGroupFile _group;
        private SymbolTable<Symbol> GetSymbols()

        {
            return symbols;
        }

        #region Ancillary functions
        private void SetSymbols(SymbolTable<Symbol> value)
        {
            symbols = value;
        }
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

        public override TResult Visit([NotNull] IParseTree tree)
        {
            return base.Visit(tree);
        }
        private static string ConvertType(Symbol sym)
        {
            string strType = "";
            switch (sym.Type)
            {
                case SBasicLexer.Integer:
                    strType = "int ";
                    break;
                case SBasicLexer.Real:
                    strType = "float ";
                    break;
                case SBasicLexer.String:
                    strType = "string ";
                    break;
            }

            return strType;
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
        protected override bool ShouldVisitNextChild([NotNull] IRuleNode node, TResult currentResult)
        {
            var typ = node.GetType();
            if (node is LineNumberContext)
                return false;
            if (typ == typeof(EolContext))
                return false;
            return true;
        }
        public TResult GenericVisitor([NotNull] IParseTree tree, IEnumerable<int> slots, string templateName)
        {
            List<string> parseResults = new List<string>();
            List<string> args = new List<string>();
            foreach (int slot in slots)
                parseResults.Add(ConvertToString(base.Visit(tree.GetChild(slot))));
            var template = (_group.GetInstanceOf(templateName));
            foreach (FormalArgument arg in template.impl.FormalArguments)
                args.Add(arg.ToString());
            for (int i = 0; i < parseResults.Count; i++)
                template.Add(args[i], parseResults[i]);
            var temp = ConvertFromString(template.Render());
            return temp;
        }
        #endregion
        public override TResult VisitAssignment([NotNull] AssignmentContext context)
        {
            int[] slots =  { 0, 2 };
            string temp = ConvertToString(GenericVisitor(context, slots, "assignmentTemplate"));
            return ConvertFromString(temp);
        }
        public override TResult VisitBinaryExpr([NotNull] BinaryExprContext context)
        {
            string temp = $"{Visit(context.GetChild(0))} {Visit(context.GetChild(1))} {Visit(context.GetChild(2))}";
            return ConvertFromString(temp);
        }
        public override TResult VisitDim([NotNull] DimContext context)
        {
            return DefaultResult;
        }
        public override TResult VisitEol([NotNull] EolContext context)
        {
            return DefaultResult;
        }
        public override TResult VisitErrorNode([NotNull] IErrorNode node)
        {
            return base.VisitErrorNode(node);
        }
        public override TResult VisitExpr([NotNull] ExprContext context)
        {
            var temp = base.VisitExpr(context);
            return temp;
        }
        public override TResult VisitFor([NotNull] ForContext context)
        {
            //'FOR' loopVar '=' expr 'TO' expr step? eol linelist lineNumber ? 'END FOR' ID ? 
            //forTemplate(id, expr1, expr2, increment, body) ::= "for (<id> = <expr1>; <id> \<= <expr2>; <id> <increment>) { <body> }"	
            List<string> slots = new List<string>();
            slots.Add(GetTextByType<LoopVarContext>(context));
            List<int> limits = (List<int>)GetPositionsByType<ExprContext>(context);
            slots.Add(ConvertToString(Visit(context.GetChild(limits[0]))));
            slots.Add(ConvertToString(Visit(context.GetChild(limits[1]))));
            string stepExp = GetTextByType<StepContext>(context);
            if (stepExp.Length > 0)
            {
                if (stepExp[4..5] == "-")
                    slots.Add("-=" + stepExp[5..]);
                else
                    slots.Add("+=" + stepExp[4..]);
            }
            else
                slots.Add("++");

            slots.Add(ConvertToString(Visit(GetNodeByType<StmtlistContext>(context))));
            List<string> args = new List<string>();
            var template = (_group.GetInstanceOf("forTemplate"));
            foreach (FormalArgument arg in template.impl.FormalArguments)
                args.Add(arg.ToString());
            for (int i = 0; i < slots.Count; i++)
                template.Add(args[i], slots[i]);
            var temp = ConvertFromString(template.Render());

            return temp;
        }
        public override TResult VisitFuncDecl([NotNull] FuncDeclContext context)
        {
            TResult temp = procFuncHelper(context);
            return temp;
        }
        public override TResult VisitIdentifier([NotNull] IdentifierContext context)
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

        //public override TResult VisitIdentifierOnly([NotNull] IdentifierOnlyContext context)
        //{
        //    TResult id = base.VisitIdentifierOnly(context);
        //    var template = _group.GetInstanceOf("identifierOnlyTemplate");
        //    template.Add("id", id);
        //    return ConvertFromString(template.Render());
        //}

        public override TResult VisitLine([NotNull] LineContext context)
        {
            if (context.ChildCount <= 1)
                return ConvertFromString("");
            var temp = ConvertFromString("\r\n" + ConvertToString(base.Visit(context.GetChild(context.ChildCount - 2))));
            return temp;
        }
        public override TResult VisitLinelist([NotNull] LinelistContext context)
        {
            if (context.ChildCount == 0)
                return ConvertFromString("");
            string accumulatedResult = "";
            for (int i = 0; i < context.children.Count; i++)
                accumulatedResult += base.Visit(context.children[i]);
            return ConvertFromString(accumulatedResult);
        }
        public override TResult VisitLoc([NotNull] LocContext context)
        {
            string name = ConvertToString(base.VisitLoc(context));
            var sym = symbols.ReadSymbol(name, this.Scope);
            string strType = ConvertType(sym.Item2);
            return ConvertFromString($"{strType} {name};");
        }
        public override TResult VisitParenthesizedlist([NotNull] ParenthesizedlistContext context)
        {
            return base.Visit(context.GetChild(1));
        }
        public override TResult VisitPrint([NotNull] PrintContext context)
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
        public override TResult VisitProcCall([NotNull] ProcCallContext context)
        {
            TResult procName = Visit(context.GetChild(0));
            TResult parameters = (context.ChildCount > 1) ? Visit(context.GetChild(1)) : default;
            return ConvertFromString($"{procName}({parameters}); ");
        }
        public override TResult VisitProcDecl([NotNull] ProcDeclContext context)
        {
            TResult temp = procFuncHelper(context);
            return temp;
        }

        private TResult procFuncHelper(IParseTree context)
        {
            var routineName = GetTextByType<ProcedureNameContext>(context) + GetTextByType<FunctionNameContext>(context);
            this.Scope = routineName;
            List<string> parameters = new List<string>();
            var parameterList = GetNodeByType<ParenthesizedlistContext>(context);
            if (parameterList != null)
            {
                for (int i = 1; i < parameterList.ChildCount - 1; i++)
                {
                    if (parameterList.GetChild(i) is ExprContext)
                    {
                        string paramName = ConvertToString(Visit(parameterList.GetChild(i)));
                        var sym = GetSymbols().ReadSymbol(paramName, routineName);
                        string sbasicType = DebugSymbols.GetName(sym.Item2.Type);
                        parameters.Add($"{ConvertSbasicType(sbasicType)} {paramName}");
                    }
                }
            }

            var content = Visit(GetNodeByType<LinelistContext>(context));
            var template = _group.GetInstanceOf("procFuncTemplate");
            template.Add("returnType", "");   // need to look up return type
            template.Add("routineName", routineName);
            template.Add("params", parameters);
            template.Add("body", content);
            var temp = ConvertFromString(template.Render());
            this.Scope = SymbolTable<Symbol>.Global;
            return temp;
        }

        public override TResult VisitProgram([NotNull] ProgramContext context)
        {
            TResult temp = Visit(context.GetChild(0));
            return temp;
        }
        public override TResult VisitStmtlist([NotNull] StmtlistContext context)
        {
            List<string> statements = new List<string>();
            int nodes = context.ChildCount;
            if (nodes == 0)
                return default; // node was removed by find types e.g. IMPLICIT%
            for (int i = 0; i < nodes; i += 2)
                statements.Add(ConvertToString(Visit(context.GetChild(i))));
            var template = _group.GetInstanceOf("statementListTemplate");
            template.Add("statements", statements);
            return ConvertFromString(template.Render());
        }
        public override TResult VisitTerminal([NotNull] ITerminalNode node)
        {
            var temp = ConvertFromString(node.Symbol.Text);
            return temp;
        }
        public override TResult VisitUnparenthesizedlist([NotNull] UnparenthesizedlistContext context)
        {
            string listVal = "";
            for (int i = 0; i < context.ChildCount; i += 2)
            {
                if (i > 0)
                    listVal += ", ";
                listVal += base.Visit(context.GetChild(i));
            }
            return ConvertFromString(listVal);
        }


    }
}
