using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace SBasic
{
    internal class SBasicTokenFactory: ITokenFactory
    {
        public IToken Create(Tuple<ITokenSource, ICharStream> source, int type, string text, int channel, int start, int stop, int line, int charPositionInLine)
        {
            return new SBasicToken(source, type, text, channel, start, stop, line, charPositionInLine);
        }

        public IToken Create(int type, string text)
        {
            return new SBasicToken(type, text);
        }
    }

    public class SBasicToken: CommonToken
    {
        public int EvaluatedType { get; set; } // SBasicLexer type such as return type of function distinct from token type which is function
        public List<IParseTree> PrunedChildren { get => prunedChildren; set => prunedChildren = value; }

        private List<IParseTree> prunedChildren = new List<IParseTree>();
        public SBasicToken(int type) : base(type)
        {
        }

        public SBasicToken(int type, string text) : base(type, text)
        {
        }

        public SBasicToken(Tuple<ITokenSource, ICharStream> source, int type, string text, int channel, int start, int stop, int line, int charPositionInLine)
            : base(source, type, channel, start, stop)
        { }
    }
}
