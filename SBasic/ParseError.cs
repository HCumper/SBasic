using System;

namespace SBasic
{
    public enum Severities
    {
        Error,
        Warning,
        Info
    }

    public class ParseError : Exception
    {
        public ParseError(string message)
            : base(message)
        {
            Severity = Severities.Error;
        }

        public Severities Severity { get; set; }
    }
}