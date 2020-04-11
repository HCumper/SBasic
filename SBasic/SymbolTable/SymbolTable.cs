using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Antlr4.Runtime;
using Parsing;

namespace SBasic.SymbolTable
{
    // Compile time structure for storing information about symbols. Single monolithic store keyed by name and scope
    public enum SymbolStatus { AlreadyExists, NewlyAdded, Missing };
    public class SymbolTable<T>: ISymbolTable<T> where T : ISymbol, new()
    {
        public static string Global = "~Global";
        private readonly IDictionary<(string name, string scope), T> _table =
            new Dictionary<(string, string), T>();

        public SymbolTable()
        {
        }

        public SymbolStatus AddSymbol(string name, string scope, T symbol)
        {
            if (_table.ContainsKey((name, scope)))
            {
                return SymbolStatus.AlreadyExists;
            }
            else
            {
                _table.Add(new KeyValuePair<(string name, string scope), T>((name, scope), symbol));
                return SymbolStatus.NewlyAdded;
            }
        }

        public (SymbolStatus, T) ReadSymbol(string name, string scope)
        {
            return _table.ContainsKey((name, scope)) ? (SymbolStatus.AlreadyExists, _table[(name, scope)]) : (SymbolStatus.Missing, new T());
        }

        public (SymbolStatus, T) ReadAnySymbol(string name, string scope)
        {
            return _table.ContainsKey((name, scope)) ? (SymbolStatus.AlreadyExists, _table[(name, scope)])
: _table.ContainsKey((name, Global)) ? (SymbolStatus.AlreadyExists, _table[(name, Global)]) : (SymbolStatus.Missing, new T());
        }

        public void ListScope(string scope, string indent)
        {
            IEnumerable<((string name, string scope), T)> selectedSymbols = from entry in _table
                                                                            where entry.Key.scope == scope
                                                                            select (entry.Key, entry.Value);

            foreach (((string name, string scope), T value) sym in selectedSymbols)
            {
                Console.WriteLine(indent + $"{sym.value}");
                if (sym.Item2 is FuncSymbol)
                    ListScope(sym.Item1.name, indent + "\t");
            }
        }

    }
}