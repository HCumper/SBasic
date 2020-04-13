using System;
using Antlr4.Runtime;
using Antlr4.StringTemplate;

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
        public Template Template { get => template; set => template = value; }
        private Template template;

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
