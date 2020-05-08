using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SBasic.SymbolTable
{
    // Compile time structure for storing information about symbols. Single monolithic store keyed by name and scope
    public enum SymbolStatus { AlreadyExists, NewlyAdded, Missing };
    public class SymbolTable<T>: ISymbolTable<T> where T : ISymbol, new()
    {
        public static string Global = "~Global";
        private readonly IDictionary<(string name, string scope), T> table =
            new Dictionary<(string, string), T>();

        public IDictionary<(string name, string scope), T> Table => table;

        public SymbolTable()
        {
        }

        public SymbolStatus AddSymbol(string name, string scope, T symbol)
        {
            if (Table.ContainsKey((name, scope)))
            {
                return SymbolStatus.AlreadyExists;
            }
            else
            {
                Table.Add(new KeyValuePair<(string name, string scope), T>((name, scope), symbol));
                return SymbolStatus.NewlyAdded;
            }
        }

        public (SymbolStatus, T) ReadSymbol(string name, string scope)
        {
            return Table.ContainsKey((name, scope)) ? (SymbolStatus.AlreadyExists, Table[(name, scope)]) : (SymbolStatus.Missing, new T());
        }

        public (SymbolStatus, T) ReadAnySymbol(string name, string scope)
        {
            return Table.ContainsKey((name, scope)) ? (SymbolStatus.AlreadyExists, Table[(name, scope)])
: Table.ContainsKey((name, Global)) ? (SymbolStatus.AlreadyExists, Table[(name, Global)]) : (SymbolStatus.Missing, new T());
        }

        public void ListScope(string scope, string indent)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\users\hcump\source\repos\SBasic\Parsing\symboltable.txt", false))
            {
                ListSingleScope(scope, indent, file);
            }
        }

        private void ListSingleScope(string scope, string indent, StreamWriter file)
        {
            IEnumerable<((string name, string scope), T)> selectedSymbols = from entry in Table
                                                                            where entry.Key.scope == scope
                                                                            select (entry.Key, entry.Value);

            foreach (((string name, string scope), T value) sym in selectedSymbols)
            {
                file.WriteLine(indent + $"{sym.value}");
                if (sym.Item2 is FuncSymbol)
                    ListSingleScope(sym.Item1.name, indent + "\t", file);
            }
        }
    }
}