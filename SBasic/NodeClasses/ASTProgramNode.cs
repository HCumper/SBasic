using System.Collections.Generic;

namespace SBasic.NodeClasses
{
    public class ASTProgramNode: ASTBaseNode
    {
        public List<ASTStmtNode> children = new List<ASTStmtNode>();
    }
}
