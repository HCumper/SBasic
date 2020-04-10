using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Parsing;
using SBasic.SymbolTable;

namespace SBasic
{
    class Program
    {
        static void Main()
        {
            string sourceFile = @"c:\users\hcump\source\repos\SBasic\Parsing\Q3.SB";
            StreamReader reader = File.OpenText(sourceFile);

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



            // | Select On expr Equal(ID | literal | toexpr) : stmtlist
            //| select On ID Newline On
             
            /*(EndRepeat ID? | { _input.Lt(1).Type == EndDef }?)*/
            //var name scope type
            //array adds parameterlist
            //function extends array adds astnode or delegate

        }
    }
}
