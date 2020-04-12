using System.IO;

namespace SBasic
{
    internal static class DebugSymbols
    {
        public static string[] names { get; set; } = new string[100];
        public static string[] texts { get; set; } = new string[100];

        static DebugSymbols()
        {
            int lastName = 1;
            int lastText = 1;
            string[] lines = File.ReadAllLines(@"c:\users\hcump\source\repos\SBasic\Parsing\obj\Debug\SBasic.Tokens");
            for (int i = 0; i < lines.Length; i++)
                if (lines[i].Substring(0, 1) != "'")
                    names[lastName++] = lines[i].Split('=')[0];
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Substring(0, 1) == "'")
                    texts[lastText++] = lines[i].Substring(1, lines[i].Length - 1).Split('\'')[0];
            }
        }

    }
}
