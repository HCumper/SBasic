using System.IO;

namespace SBasic
{
    internal static class DebugSymbols
    {
        public static string[] Names { get; set; } = new string[100];
        public static string[] Texts { get; set; } = new string[100];

        static DebugSymbols()
        {
            int lastName = 1;
            int lastText = 1;
            string[] lines = File.ReadAllLines(@"c:\users\hcump\source\repos\SBasic\Parsing\obj\Debug\SBasic.Tokens");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Substring(0, 1) != "'")
                    Names[lastName++] = lines[i].Split('=')[0];
            }

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Substring(0, 1) == "'")
                    Texts[lastText++] = lines[i][1..].Split('\'')[0];
            }
        }

    }
}
