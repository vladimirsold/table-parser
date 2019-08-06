using System.Collections.Generic;
using System.Text;

namespace TableParser
{
    public class FieldsParserTask
    {
        public static List<string> ParseLine(string line)
        {
            var i = PositionSkipSpaces(line, 0);
            var parseLine = new List<string>();
            while(i < line.Length)
            {
                Token field = ReadField(line, i);
                parseLine.Add(field.Value);
                i = field.GetIndexNextToToken();
                i = PositionSkipSpaces(line, i);
            }
            return parseLine;
        }

        public static Token ReadField(string line, int i)
        {
            if(IsQuote(line[i]))
            {
                return GetCompositeField(line, i + 1, line[i]);
            }
            else
            {
                return GetOrdinalField(line, i);
            }
        }

        public static Token GetOrdinalField(string line, int start)
        {
            var length = 1;
            while(!IsEndOFOrdinalField(line, start + length))
            {
                length++;
            }
            return new Token(line.Substring(start, length), start, length);
        }

        private static bool IsEndOFOrdinalField(string line, int index)
        {
            return line.Length == index
                || line[index] == ' '
                || IsQuote(line[index]);
        }

        private static int PositionSkipSpaces(string line, int i)
        {
            while(line.Length > i && char.IsWhiteSpace(line[i]))
            {
                i++;
            }
            return i;
        }

        private static Token GetCompositeField(string line, int start, char quote)
        {
            var index = start;
            var interpretString = new StringBuilder();
            while(!IsEndOfCompositeField(line, index, quote))
            {
                if(line[index] == '\\' && line.Length > index + 1)
                    index++;
                interpretString.Append(line[index]);
                index++;
            }
            int length = index - start + 1;
            return new Token(interpretString.ToString(), start, length);
        }

        private static bool IsEndOfCompositeField(string line, int index, char quote)
        {
            return line.Length == index || line[index] == quote;
        }

        private static bool IsQuote(char v)
        {
            return v == '\"' || v == '\'';
        }
    }
}