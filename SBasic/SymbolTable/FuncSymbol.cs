namespace SBasic.SymbolTable
{
    public class FuncSymbol: Symbol
    {
        public FuncSymbol(string name, string scope, int type, int returnType)
            : base(name, scope, type)
        {
            ReturnType = returnType;
        }

        public override string ToString()
        {
            return base.ToString() + $"{DebugSymbols.Names[ReturnType]}";
        }

        private int ReturnType { get; }
    }
}