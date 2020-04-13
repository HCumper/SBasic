using System;
using System.IO;
using System.Linq;
using Antlr4.Runtime.Tree;
using Antlr4.StringTemplate;
using Parsing;
using SBasic.SymbolTable;

namespace SBasic
{
    internal class CodeGenerator
    {
        private readonly IParseTree _tree;
        private readonly SymbolTable<Symbol> _symbolTable;
        private TemplateGroup _templateGroup;

        public CodeGenerator(IParseTree tree, SymbolTable<Symbol> symbolTable)
        {
            _tree = tree;
            _symbolTable = symbolTable;
            _templateGroup = new TemplateGroupFile(@"c:/users/hcump/source/repos/SBasic/SBasic/Templates.stg");

        }

        public void GenerateCode(string sourceFile)
        {
            Template programTemplate = _templateGroup.GetInstanceOf("programTemplate");
            GenerateCodeVisitor<string> generateCodeVisitor = new GenerateCodeVisitor<string>(_symbolTable);

            programTemplate.Add("programName", sourceFile);
            programTemplate.Add("when", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
            Template declarationsTemplate = _templateGroup.GetInstanceOf("declarationsTemplate");
            programTemplate.Add("declarationsTemplate", Generatedeclarations(declarationsTemplate, SymbolTable<Symbol>.Global, ""));
            string content = generateCodeVisitor.Visit(_tree);
            programTemplate.Add("programContent", content);

            string cSharp = programTemplate.Render();
            var outputPath = @"..\..\..\Generated.cs";
            File.WriteAllText(@outputPath, cSharp);
        }

        private string Generatedeclarations(Template declarationsTemplate, string scope, string prefix)
        {
            var reals = from ent in _symbolTable.Table
                        where ent.Key.scope == scope
                           && ent.Value.Type == SBasicLexer.Real
                           && !(ent.Value is ArraySymbol)
                        select ent;

            declarationsTemplate.Add("reals", reals);

            var realArrays = from ent in _symbolTable.Table
                             where ent.Key.scope == scope
                           && ent.Value.Type == SBasicLexer.Real
                           && ent.Value is ArraySymbol
                             select ent;

            declarationsTemplate.Add("realArrays", realArrays);

            var integers = from ent in _symbolTable.Table
                           where ent.Key.scope == scope
                           && ent.Value.Type == SBasicLexer.Integer
                           && !(ent.Value is ArraySymbol)
                           select ent;

            declarationsTemplate.Add("integers", integers);

            var integerArrays = from ent in _symbolTable.Table
                                where ent.Key.scope == scope
                           && ent.Value.Type == SBasicLexer.Integer
                           && ent.Value is ArraySymbol
                                select ent;

            declarationsTemplate.Add("integerArrays", integerArrays);

            var strings = from ent in _symbolTable.Table
                          where ent.Key.scope == scope
                           && ent.Value.Type == SBasicLexer.String
                           && !(ent.Value is ArraySymbol)
                          select ent;

            declarationsTemplate.Add("strings", strings);

            var stringArrays = from ent in _symbolTable.Table
                               where ent.Key.scope == scope
                           && ent.Value.Type == SBasicLexer.String
                           && ent.Value is ArraySymbol
                               select ent;

            declarationsTemplate.Add("stringArrays", stringArrays);
            declarationsTemplate.Add("scope", prefix);
            return declarationsTemplate.Render();
        }
    }
}
