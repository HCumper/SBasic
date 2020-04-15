using System;
using System.Collections.Generic;
using System.Text;

namespace SBasic.NodeClasses
{
    public abstract class ASTExprNode
    {
        List<ASTBaseNode> children = new List<ASTBaseNode>();
    }
}
