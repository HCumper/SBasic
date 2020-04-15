using System;

namespace SBasic
{
    public enum Severities
    {
        Error,
        Warning,
        Info
    }

    public class ParseError: Exception
    {
        public ParseError(string message, int line)
            : base(message)
        {
            Line = line;
            Severity = Severities.Error;
        }

        private int line;
        public Severities Severity { get; set; }
        public int Line { get => line; set => line = value; }
    }
}