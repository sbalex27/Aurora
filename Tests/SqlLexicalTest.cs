using Core.LexicalAnalyzer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class SqlLexicalTest
    {
        private ILexicalAnalyzer _lexicalAnalyzer;

        [TestInitialize]
        public void Initialize()
        {
            _lexicalAnalyzer = new SqlLexicalAnalyzer();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _lexicalAnalyzer = null;
        }

        [TestMethod]
        [DataRow("SELECT * FROM Products WHERE IdProduct = 1", 8)]
        [DataRow("SELECT Id, Name FROM Brands WHERE IdBrand = 1", 10)]
        [DataRow("SELECT Id, Description, FROM Categories WHERE Name LIKE '%MyValue%' ORDER BY Name DESC", 14)]
        public void TokenCount(string input, int expectedCount)
        {
            // Act
            var result = _lexicalAnalyzer.Tokenize(input);

            // Assert
            Assert.AreEqual(expectedCount, result.Count);
        }

        [TestMethod]
        [DataRow("SELECT", TokenType.Select)]
        [DataRow("FROM", TokenType.From)]
        [DataRow("WHERE", TokenType.Where)]
        [DataRow("ORDER BY", TokenType.OrderBy)]
        [DataRow("INSERT", TokenType.Insert)]
        [DataRow("INTO", TokenType.Into)]
        [DataRow("VALUES", TokenType.Values)]
        [DataRow("UPDATE", TokenType.Update)]
        [DataRow("SET", TokenType.Set)]
        [DataRow("DELETE", TokenType.Delete)]
        [DataRow("=", TokenType.Equals)]
        [DataRow("LIKE", TokenType.Like)]
        [DataRow("NOT", TokenType.Not)]
        [DataRow("DESC", TokenType.Desc)]
        [DataRow("ASC", TokenType.Asc)]
        [DataRow(",", TokenType.Comma)]
        [DataRow("*", TokenType.Asterisk)]
        [DataRow("MyIdentifier", TokenType.Identifier)]
        [DataRow("'My Value'", TokenType.Match)]
        [DataRow("'%MyLikeValue%'", TokenType.Match)]
        [DataRow("123", TokenType.Number)]
        public void TokenMatch(string input, TokenType expectedToken)
        {
            // Act
            var result = _lexicalAnalyzer.Tokenize(input);

            Assert.AreEqual(expectedToken, result[0].Type, input);
        }
    }
}
