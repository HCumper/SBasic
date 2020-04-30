﻿using System;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Parsing;
using SBasic.SymbolTable;

namespace SBasic
{
    public static class Program
    {

        private static void Main()
        {
            _ = DebugSymbols.Names[7];
            string sourceFile = @"c:\users\hcump\source\repos\SBasic\Parsing\Q3.SB";
            StreamReader reader = File.OpenText(sourceFile);
            try
            {
                ICharStream cs = new AntlrInputStream(reader);
                SBasicTokenFactory factory = new SBasicTokenFactory();
                SBasicLexer lexer = new SBasicLexer(cs)
                {
                    TokenFactory = factory
                };
                CommonTokenStream tokens = new CommonTokenStream(lexer);

                SBasicParser parser = new SBasicParser(tokens);
                IParseTree tree = parser.program();

                //PruneVisitor<int> pruner = new PruneVisitor<int>();
                //pruner.Visit(tree);

                SymbolTable<Symbol> symbolTable = new SymbolTable<Symbol>();
                PrimeSymbolTable(symbolTable);

                BuildSymbolTableVisitor<int> symbolTableVisitor = new BuildSymbolTableVisitor<int>(symbolTable)
                {
                    FirstPass = true   // Array functions and procedures
                };
                
#if (DEBUG)
                    DumpTree(tree, "");
#endif
                symbolTableVisitor.Visit(tree);
                symbolTableVisitor.FirstPass = false; // Everything else
                symbolTableVisitor.Visit(tree);

                FindTypesVisitor<int> findTypesVisitor = new FindTypesVisitor<int>(symbolTable);
                findTypesVisitor.Visit(tree);

                symbolTable.ListScope(SymbolTable<Symbol>.Global, "");

                GenerateCodeVisitor<string> generateCodeVisitor = new GenerateCodeVisitor<string>(symbolTable);

                CodeGenerator generator = new CodeGenerator(tree, symbolTable);
                generator.GenerateCode(sourceFile);
            }
            catch (ParseError pe)
            {
                Console.WriteLine($"{pe.Message} at line {pe.Line}");
            }
        }

        private static void PrimeSymbolTable(SymbolTable<Symbol> table)
        {
            string[] builtIns = new string[] { "ABS", "BEEP", "CLS", "DATE", "RND", "TURBO_repfil"};
            foreach (string item in builtIns)
                table.AddSymbol(item, SymbolTable<Symbol>.Global, new FuncSymbol(item, SymbolTable<Symbol>.Global, SBasicLexer.ProcCall, SBasicLexer.Void));
        }

        private static void DumpTree(IParseTree tree, string indent)
        {
            for (int i = 0; i < tree.ChildCount; i++)
            {
                var child = tree.GetChild(0);
                try
                {
                    child = tree.GetChild(i);
                    Console.Write(indent + child.GetType());
                    if (child is ParserRuleContext)
                    {
                        Console.WriteLine("        " + ((ParserRuleContext)child).GetText());
                    }
                    else
                    {
                        if (child is TerminalNodeImpl)
                            Console.WriteLine("        " + ((TerminalNodeImpl)child).symbol.Text);
                        else
                            Console.WriteLine("");
                    }
                }
                catch (Exception e)
                { };

                DumpTree(child, indent + "    ");
            }
        }
    }
}
