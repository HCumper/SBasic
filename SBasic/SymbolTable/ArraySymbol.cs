using System.Collections.Generic;

namespace SBasic.SymbolTable
{
    public class ArraySymbol: Symbol
    {
        public ArraySymbol(string name, int type, string scope, List<int> dimensions)
            : base(name, scope, type)
        {
            Dimensions = dimensions;
        }

        private List<int> Dimensions { get; }

        public override string ToString()
        {
            var dimStr = "";
            Dimensions.ForEach(dim => dimStr = dim.ToString() + dimStr + "\t");
            return $"{Name}  {Scope}  {Type}    {dimStr}";
        }
    }
}