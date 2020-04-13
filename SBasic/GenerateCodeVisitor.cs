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

        private TResult Convert(string text)
        {
            return (TResult)_converter.ConvertFromString(text);
        }
        private TResult Emit(Template template)
        {
            string strResult = template.Render() + "\n";
            Output += strResult;
            return Convert("");
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
            TResult result = base.VisitChildren(node);
            return result;
        }

        public override TResult VisitTerminal([NotNull] ITerminalNode node)
        {
            return base.VisitTerminal(node);
        }

        public override TResult VisitAssignment([NotNull] SBasicParser.AssignmentContext context)
        {
            var tok = (SBasicToken)(context.GetChild(0).GetChild(0).Payload);
            var template = _group.GetInstanceOf("assignmentTemplate");
            tok.Text = tok.Text.TrimEnd('$');
            tok.Text = tok.Text.TrimEnd('%');
            template.Add("left", tok.Text);
            template.Add("right", base.VisitAssignment(context));
            return Emit(template);
        }

        public override TResult VisitIdentifierOnly([NotNull] SBasicParser.IdentifierOnlyContext context)
        {
            TResult id = base.VisitIdentifierOnly(context);
            var template = _group.GetInstanceOf("identifierOnlyTemplate");
            template.Add("id", id);
            return Emit(template);
        }

        public override TResult VisitShortfor([NotNull] SBasicParser.ShortforContext context)
        {
            TResult forVar = base.VisitShortfor(context);
            var template = _group.GetInstanceOf("shortForTemplate");
            //template.Add("id", id);
            return Emit(template);
        }

        public override TResult VisitProgram([NotNull] SBasicParser.ProgramContext context)
        {
            _ = base.VisitProgram(context);
            return (TResult)_converter.ConvertFromString(Output);
        }

    }
}