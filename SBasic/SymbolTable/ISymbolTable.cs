namespace SBasic.SymbolTable
{
    public interface ISymbolTable<T>
    {
        SymbolStatus AddSymbol(string name, string scope, T symbol);
        (SymbolStatus, T) ReadAnySymbol(string name, string scope);
        (SymbolStatus, T) ReadSymbol(string name, string scope);
    }
}