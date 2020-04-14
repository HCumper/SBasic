using System.Collections.Generic;
using System.ComponentModel;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Antlr4.StringTemplate;
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
            return (string)_converter.ConvertToString(result);
        }

        private TResult Emit(Template template, SBasicParser.StmtContext context)
        {
            if ((context.Parent.Parent.Parent).GetType() == typeof(SBasicParser.ProgramContext))
            {
                string strResult = template.Render() + "\n";
                Output += strResult;
                return ConvertFromString("");
            }
            else
            {
                return ConvertFromString(template.Render());
            }
        }

        private TResult EmitList(Template template, SBasicParser.StmtlistContext context)
        {
            if ((context.Parent.Parent).GetType() == typeof(SBasicParser.ProgramContext))
            {
                string strResult = template.Render() + "\n";
                Output += strResult;
                return ConvertFromString("");
            }
            else
            {
                return ConvertFromString(template.Render());
            }
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
            return (TResult)_converter.ConvertFromString(node.Symbol.Text);
        }

        public override TResult VisitAssignment([NotNull] SBasicParser.AssignmentContext context)
        {
            var ttok = Visit(context.GetChild(0));
            var tok = ConvertToString(ttok);
            var template = _group.GetInstanceOf("assignmentTemplate");
            tok = tok.TrimEnd('$');
            tok = tok.TrimEnd('%');
            template.Add("left", tok);
            template.Add("right", Visit(context.GetChild(2)));
            return Emit(template, context);
        }

        public override TResult VisitIdentifierOnly([NotNull] SBasicParser.IdentifierOnlyContext context)
        {
            TResult id = base.VisitIdentifierOnly(context);
            var template = _group.GetInstanceOf("identifierOnlyTemplate");
            template.Add("id", id);
            return Emit(template, context);
        }

        public override TResult VisitShortfor([NotNull] SBasicParser.ShortforContext context)
        {
            var loopVar = Visit(context.GetChild(1));;
            var start = Visit(context.GetChild(3));
            var end = Visit(context.GetChild(5));
            var statements = Visit(context.GetChild(7));
            var template = _group.GetInstanceOf("shortForTemplate");
            template.Add("id", loopVar);
            template.Add("expr1", start);
            template.Add("expr2", end);
            template.Add("stmtlist", statements);
            return Emit(template, context);
        }
        public override TResult VisitProgram([NotNull] SBasicParser.ProgramContext context)
        {
            _ = base.VisitProgram(context);
            return (TResult)_converter.ConvertFromString(Output);
        }
        public override TResult VisitStmtlist([NotNull] SBasicParser.StmtlistContext context)
        {
            List<string> statements = new List<string>();
            int nodes = context.ChildCount;
            for (int i = 0; i < nodes; i += 2)
                statements.Add(ConvertToString(Visit(context.GetChild(i))));
            var template = _group.GetInstanceOf("statementList");
            template.Add("statements", statements);
            return EmitList(template, context);
        }

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

        protected  override TResult AggregateResult(TResult aggregate, TResult nextResult)
        {
            return nextResult;
        }
    }
}