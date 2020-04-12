using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Parsing;
using SBasic.SymbolTable;
using static SBasic.DebugSymbols;

namespace SBasic
{
    public static class Program
    {
        public static string SourceFile;

    //    public static string SourceFile { get => sourceFile; set => sourceFile = value; }

        static void Main()
        {
            _ = DebugSymbols.names[7];
            SourceFile = @"c:\users\hcump\source\repos\SBasic\Parsing\Q3.SB";
            StreamReader reader = File.OpenText(SourceFile);

            ICharStream cs = new AntlrInputStream(reader);
            SBasicTokenFactory factory = new SBasicTokenFactory();
            SBasicLexer lexer = new SBasicLexer(cs)
            {
                TokenFactory = factory
            };
            CommonTokenStream tokens = new CommonTokenStream(lexer);

            SBasicParser parser = new SBasicParser(tokens);
            IParseTree tree = parser.program();

            System.Diagnostics.Debug.WriteLine(tree.ToStringTree(parser));

            SymbolTable<Symbol> symbolTable = new SymbolTable<Symbol>();
            BuildSymbolTableVisitor<int> symbolTableVisitor = new BuildSymbolTableVisitor<int>(symbolTable)
            {
                FirstPass = true   // Array functions and procedures
            };
            symbolTableVisitor.Visit(tree);
            symbolTableVisitor.FirstPass = false; // Everything else
            symbolTableVisitor.Visit(tree);

            FindTypesVisitor<int> findTypesVisitor = new FindTypesVisitor<int>(symbolTable);
            findTypesVisitor.Visit(tree);

            symbolTable.ListScope(SymbolTable<Symbol>.Global, "");

            GenerateCodeVisitor<int> generateCodeVisitor = new GenerateCodeVisitor<int>(symbolTable);
            generateCodeVisitor.Visit(tree);
        }
    }
}
