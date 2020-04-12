using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Tree;
using Antlr4.StringTemplate;
using Parsing;
using SBasic.SymbolTable;

namespace SBasic
{
    class CodeGenerator
    {
        private IParseTree _tree;
        private SymbolTable<Symbol> _symbolTable;
        private Template _template;


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

            GenerateGlobals(sourceFile);

            return _template.Render();
        }

        private void GenerateGlobals(string sourceFile)
        {
            var reals = from ent in _symbolTable.Table
                        where ent.Key.scope == SymbolTable<Symbol>.Global
                           && ent.Value.Type == SBasicLexer.Real
                           && !(ent.Value is ArraySymbol)
                        select ent;

            _template.Add("reals", reals);

            var realArrays = from ent in _symbolTable.Table
                       where ent.Key.scope == SymbolTable<Symbol>.Global
                           && ent.Value.Type == SBasicLexer.Real
                           && ent.Value is ArraySymbol
                       select ent;

            _template.Add("realArrays", realArrays);

            var integers = from ent in _symbolTable.Table
                        where ent.Key.scope == SymbolTable<Symbol>.Global
                           && ent.Value.Type == SBasicLexer.Integer
                           && !(ent.Value is ArraySymbol)
                        select ent;

            _template.Add("integers", integers);

            var integerArrays = from ent in _symbolTable.Table
                             where ent.Key.scope == SymbolTable<Symbol>.Global
                           && ent.Value.Type == SBasicLexer.Integer
                           && ent.Value is ArraySymbol
                             select ent;

            _template.Add("integerArrays", integerArrays);

            var strings = from ent in _symbolTable.Table
                           where ent.Key.scope == SymbolTable<Symbol>.Global
                           && ent.Value.Type == SBasicLexer.String
                           && !(ent.Value is ArraySymbol)
                           select ent;

            _template.Add("strings", strings);

            var stringArrays = from ent in _symbolTable.Table
                                where ent.Key.scope == SymbolTable<Symbol>.Global
                           && ent.Value.Type == SBasicLexer.String
                           && ent.Value is ArraySymbol
                                select ent;

            _template.Add("stringArrays", stringArrays);

        }
    }
}
