using System.Collections.Generic;

namespace SBasic.NodeClasses
{
    public abstract class ASTStmtNode: ASTBaseNode
    {
        private readonly List<ASTBaseNode> children = new List<ASTBaseNode>();
    }
}
