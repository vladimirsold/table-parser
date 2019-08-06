using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableParser
{
    [TestFixture]
    public class ParserTests
    {
        void ParserTest(string stringToParse, string[] expectedResult)
        {
            var resultOfParse = FieldsParserTask.ParseLine(stringToParse);
            Assert.AreEqual(expectedResult, resultOfParse.ToArray());
        }

        [Test]
        public void SeveralFields()
        {
            ParserTest("hello world", new[] { "hello", "world" });
        }

        [Test]
        public void DelimiterMoreTheOneSpace()
        {
            ParserTest("hello  world", new[] { "hello", "world" });
        }

        [Test]
        public void OneField()
        {
            ParserTest("a", new[] { "a" });
        }

        [Test]
        public void EmptyField()
        {
            ParserTest("\"\"", new[] { "" });
        }

        [Test]
        public void NoFields()
        {
            Assert.AreEqual("", new string[0]);
        }

        [Test]
        public void QuotedFieldAfterSimpleField()
        {
            ParserTest("a \"bcd\"", new[] { "a", "bcd"});
        }

        [Test]
        public void SimpleFieldAfterQuotedField()
        {
            ParserTest("\"abc\" d", new[] { "abc", "d"});
        }

        [Test]
        public void SingleQuotesInDoubleQuotes()
        {
            ParserTest("\"b 'c' d\"", new[] { "b 'c' d" });
        }

        [Test]
        public void DoubleQuotesInSingleQuotes()
        {
            ParserTest("'\"e\" \"f\"'", new[] { "\"e\" \"f\"" });
        }

        [Test]
        public void DelimeterWithoutSpace()
        {
            ParserTest("a\"b\"", new[] { "a", "b" });
        }

        [Test]
        public void NoClosingQuotes()
        {
            ParserTest("ab \"cde", new[] { "ab", "cde" });
        }

        [Test]
        public void SpaseInQuotes()
        {
            ParserTest("\"ab c\"", new[] { "ab c" });
        }

        [Test]
        public void EscapeSlashInQuotes()
        {
            ParserTest(@"""\\""", new[] { "\\" });
        }

        [Test]
        public void EscapeDoubleQuotesInDoubleQuotes()
        {
            ParserTest(@"""a \""c\""", new[] { "a \"c\"" });
        }

        [Test]
        public void EscapeSingleQuotesInSingleQuotes()
        {
            ParserTest(@"'\'a\''", new[] { "'a'" });
        }

        [Test]
        public void SpaceAtTheBeginningOrEndingOfFeild()
        {
            ParserTest(" \"a\" ", new[] { "a" });
        }

        [Test]
        public void SpaceInTheEndFieldWithoutClosingQuotes()
        {
            ParserTest("'a b ", new[] { "a b " });
        }

        [Test]
        public void OddEscapeSlashWithQuote()
        {
            ParserTest("'\\\' 0", new[] {"' 0"});
        }
    }
}
