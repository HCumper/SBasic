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
        private Template? _template;


        public CodeGenerator(IParseTree tree, SymbolTable<Symbol> symbolTable)
        {
            _tree = tree;
            _symbolTable = symbolTable;
        }

        public void GenerateCode(string sourceFile)
        {
            string cSharp = Generate(sourceFile);
            var path = @"..\..\..\Generated.cs";
            File.WriteAllText(@path, cSharp);
        }

        private string Generate(string sourceFile)
        {
            var path = @"..\..\..\Code.st";
            var file = new FileInfo(path);

            using (StreamReader reader = file.OpenText())
                _template = new Template(reader.ReadToEnd());

            _template.Add("programName", sourceFile);
            _template.Add("when", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());

            string declarations = GenerateGlobals(SymbolTable<Symbol>.Global, "public");
            _template.Add("declarations", declarations);

            GenerateCodeVisitor<int> generateCodeVisitor = new GenerateCodeVisitor<int>(_symbolTable);
            generateCodeVisitor.Visit(_tree);

            return _template.Render();
        }

        private string GenerateGlobals(string scope, string prefix)
        {
            var reals = from ent in _symbolTable.Table
                        where ent.Key.scope == scope
                           && ent.Value.Type == SBasicLexer.Real
                           && !(ent.Value is ArraySymbol)
                        select ent;

            TemplateGroup group = new TemplateGroupFile(@"c:/users/hcump/source/repos/SBasic/SBasic/SupportTemplates.stg");
            //            TemplateGroup group = new TemplateGroupFile(@"..\..\..\SupportTemplates.stg");
            Template declarations = group.GetInstanceOf("declarationsTemplate");

            declarations.Add("reals", reals);

            var realArrays = from ent in _symbolTable.Table
                             where ent.Key.scope == scope
                           && ent.Value.Type == SBasicLexer.Real
                           && ent.Value is ArraySymbol
                             select ent;

            declarations.Add("realArrays", realArrays);

            var integers = from ent in _symbolTable.Table
                           where ent.Key.scope == scope
                           && ent.Value.Type == SBasicLexer.Integer
                           && !(ent.Value is ArraySymbol)
                           select ent;

            declarations.Add("integers", integers);

            var integerArrays = from ent in _symbolTable.Table
                                where ent.Key.scope == scope
                           && ent.Value.Type == SBasicLexer.Integer
                           && ent.Value is ArraySymbol
                                select ent;

            declarations.Add("integerArrays", integerArrays);

            var strings = from ent in _symbolTable.Table
                          where ent.Key.scope == scope
                           && ent.Value.Type == SBasicLexer.String
                           && !(ent.Value is ArraySymbol)
                          select ent;

            declarations.Add("strings", strings);

            var stringArrays = from ent in _symbolTable.Table
                               where ent.Key.scope == scope
                           && ent.Value.Type == SBasicLexer.String
                           && ent.Value is ArraySymbol
                               select ent;

            declarations.Add("stringArrays", stringArrays);
            declarations.Add("scope", prefix);
            return declarations.Render();
        }
    }
}
