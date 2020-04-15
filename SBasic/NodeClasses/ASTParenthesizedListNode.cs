using System;
using System.Collections.Generic;
using System.Text;

namespace SBasic.NodeClasses
{
    public class ASTParenthesizedListNode : ASTBaseNode
    {
        List<ASTExprNode> children = new List<ASTExprNode>();
    }
}
