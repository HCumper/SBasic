namespace SBasic.SymbolTable
{
    public class Symbol: ISymbol
    {
        public Symbol() {
            Name = "";
            Scope = "";
        }
        public Symbol(string name, string scope, int type)
        {
            Name = name;
            Scope = scope;
            Type = type;
        }

        public string Name { get; set; }
        public string Scope { get; set; }
        public int Type { get; set; }

        public override string ToString()
        {
            return $"{Name.PadRight(20, ' ')}  {Scope.PadRight(20, ' ')}  {DebugSymbols.names[Type].PadRight(20, ' ')}";
        }
    }
}