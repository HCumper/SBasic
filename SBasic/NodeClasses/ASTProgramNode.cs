using System;
using System.Collections.Generic;
using System.Text;

namespace SBasic.NodeClasses
{
    public class ASTProgramNode : ASTBaseNode
    {
        public List<ASTStmtNode> children = new List<ASTStmtNode>();
    }
}
