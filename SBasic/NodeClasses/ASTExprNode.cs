using System.Collections.Generic;

namespace SBasic.NodeClasses
{
    public abstract class ASTExprNode
    {
        private readonly List<ASTBaseNode> children = new List<ASTBaseNode>();
    }
}
