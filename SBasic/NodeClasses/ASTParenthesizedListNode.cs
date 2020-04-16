using System.Collections.Generic;

namespace SBasic.NodeClasses
{
    public class ASTParenthesizedListNode: ASTBaseNode
    {
        private readonly List<ASTExprNode> children = new List<ASTExprNode>();
    }
}
