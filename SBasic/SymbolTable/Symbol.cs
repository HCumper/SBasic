namespace SBasic.SymbolTable
{
    public class Symbol: ISymbol
    {
        public Symbol() { }
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
            return $"{Name}  {Scope}  {Type}";
        }
    }
}