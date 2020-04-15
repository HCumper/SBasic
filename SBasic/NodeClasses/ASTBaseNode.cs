using System;
using System.Collections.Generic;
using System.Text;

namespace SBasic.NodeClasses
{
    public enum SBTypes { Integer, Real, String };
    public class ASTBaseNode
    {
        private string operation = "";
        private int lineNumber;

        public string Operation { get => operation; set => operation = value; }
        public int LineNumber { get => lineNumber; set => lineNumber = value; }
    }
}
