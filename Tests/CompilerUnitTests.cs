using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class CompilerUnitTests
    {
        public Compiler _compiler;

        [TestInitialize]
        public void Initialize()
        {
            _compiler = new Compiler();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _compiler = null;
        }

        [TestMethod]
        [DataRow("integer myNumber = 23", 1)]
        [DataRow("string myString = \"Hello World\"", 1)]
        [DataRow("integer myNumber = 23; string myString = \"Hello World\"", 2)]
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
    }
}
