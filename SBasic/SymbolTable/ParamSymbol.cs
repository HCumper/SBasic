namespace SBasic.SymbolTable
{
    public class ParamSymbol: Symbol
    {
        public ParamSymbol(string name, int type, string scope, bool reference)
            : base(name, scope, type)
        {
            Reference = reference;
        }
        private bool Reference { get; }
        public override string ToString()
        {
            return $"{Name}  {Scope}  {Type}     {Reference}";
        }
    }
}