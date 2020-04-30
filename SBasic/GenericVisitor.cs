using Antlr4.Runtime.Tree;
using Parsing;

namespace SBasic
{
    public class GenericVisitor<Result>: SBasicBaseVisitor<Result>
    {

        protected string GetTextByType<nodeType>(IParseTree context)
        {
            for (int i = 0; i < context.ChildCount; i++)
            {
                if (context.GetChild(i) is nodeType)
                    return context.GetChild(i).GetText();
            }

            return default;
        }
        protected IParseTree GetNodeByType<nodeType>(IParseTree context)
        {
            for (int i = 0; i < context.ChildCount; i++)
            {
                if (context.GetChild(i) is nodeType)
                    return context.GetChild(i);
            }

            return default;
        }

    }
}
