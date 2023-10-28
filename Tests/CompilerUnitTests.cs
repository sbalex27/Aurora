using Core.LexicalAnalyzer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class CompilerUnitTests
    {
        public IAnalyzer _compiler;

        [TestInitialize]
        public void Initialize()
        {
            _compiler = new CSharpRegexAnalyzer();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _compiler = null;
        }

        [TestMethod]
        [DataRow("int myNumber = 23", 1)]
        [DataRow("string myString = \"Hello World\"", 1)]
        [DataRow("int myNumber = 23; string myString = \"Hello World\"", 2)]
        public void SingleKeyword(string input, int tokens)
        {
            // Act
            var result = _compiler.Tokenize(input);

            // Assert
            var list = from token in result
                       where token.Type == TokenType.Keyword
                       select token;

            Assert.AreEqual(tokens, list.Count());
        }

        [TestMethod]
        public void ComplexLine()
        {
            // Arrange
            string input = "int myCustomNumber = 23;";

            // Act
            var result = _compiler.Tokenize(input);

            // Assert
            var keywords = result.Where(e => e.Type == TokenType.Keyword).Count();
            var identifiers = result.Where(e => e.Type == TokenType.Identifier).Count();
            var semicolons = result.Where(e => e.Type == TokenType.Semicolon).Count();

            Assert.AreEqual(1, keywords, "Keywords");
            Assert.AreEqual(1, identifiers, "Identifiers");
            Assert.AreEqual(1, semicolons, "Semicolons");
        }
    }
}
