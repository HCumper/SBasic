using System.Collections.Generic;

namespace SBasic.NodeClasses
{
    public class ASTDimNode: ASTStmtNode
    {
        public string varName = "";
        public SBTypes varType;
        public List<string> dimensions = new List<string>();
    }
}
