using System;
using System.Collections.Generic;
using System.Text;

namespace SBasic.NodeClasses
{
    public class ASTDimNode : ASTStmtNode
    {
        public string varName = "";
        public SBTypes varType;
        public List<string> dimensions = new List<string>();
    }
}
