using System.Collections.Generic;
using Parsing;
using SBasic.SymbolTable;

namespace SBasic
{
    internal class GenerateCodeVisitor<TResult>: SBasicBaseVisitor<TResult>, ISBasicVisitor<TResult> where TResult : notnull
        {
            private SymbolTable<Symbol> SymbolTable { get; set; }

            public GenerateCodeVisitor(SymbolTable<Symbol> symbolTable)
            {
                SymbolTable = symbolTable;
            }

        }
    }