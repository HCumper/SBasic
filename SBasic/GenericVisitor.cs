using System.Collections.Generic;
using Antlr4.Runtime.Tree;
using Parsing;

namespace SBasic
{
    public class GenericVisitor<Result>: SBasicBaseVisitor<Result>
    {
        protected IEnumerable<int> GetPositionsByType<nodeType>(IParseTree context)
        {
            List<int> slots = new List<int>();
            for (int i = 0; i < context.ChildCount; i++)
            {
                if (context.GetChild(i) is nodeType)
                    slots.Add(i);
            }

            return slots;
        }

        protected string GetTextByType<nodeType>(IParseTree context)
        {
            for (int i = 0; i < context.ChildCount; i++)
            {
                if (context.GetChild(i) is nodeType)
                    return context.GetChild(i).GetText();
            }

            return "";
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

        protected string ConvertSbasicType(string sbType)
        {
            switch (sbType)
            {
                case "Real":
                    return "float";
                case "Integer":
                    return "int";
                case "String":
                    return "string";
                default:
                    return "";
            }
        }
    }
}
