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
        [DataRow("((", TokenType.Undefined)]
        public void TokenMatch(string input, TokenType expectedToken)
        {
            // Act
            var result = _lexicalAnalyzer.Tokenize(input);

            Assert.AreEqual(expectedToken, result[0].Type, input);
        }


        [TestMethod]
        [DataRow("SELECT * FROM Products WHERE IdProduct = 1", 0)]
        [DataRow("SELECT Id, Name FROM Brands WHERE IdBrand = (", 1)]
        [DataRow("( FROM X TO -", 2)]
        public void ErrorCount(string input, int errorCount)
        {
            // Act
            var result = _lexicalAnalyzer.Tokenize(input);

            // Assert
            Assert.AreEqual(errorCount, result.UndefinedCount);
        }

        [TestMethod]
        [DataRow("(", 0)]
        [DataRow("SELECT - FROM SOLICITUD", 7)]
        public void ErrorCharacterPosition(string input, int characterPositionIndex)
        {
            // Act
            var result = _lexicalAnalyzer.Tokenize(input);

            // Assert
            Assert.AreEqual(characterPositionIndex, result.Errors[0].Character);
        }

        [TestMethod]
        [DataRow("SELECT UPDATE", TokenType.Update)]
        [DataRow("SELECT INSERT", TokenType.Insert)]
        [DataRow("SELECT DELETE", TokenType.Delete)]
        public void FirstUnspectedToken(string input, TokenType unespected)
        {
            var result = _lexicalAnalyzer.Tokenize(input);
            var firstUnespected = result.UnespectedTokens.FirstOrDefault();
            Assert.AreEqual(unespected, firstUnespected.Type);
        }

        [TestMethod]
        // SHOULD BE FALSE
        [DataRow("SELECT * FROM PRODUCTS", false)]
        [DataRow("SELECT * FROM PRODUCTS WHERE IdProduct = 1", false)]
        [DataRow("SELECT * FROM PRODUCTS WHERE IdProduct = 1 ORDER BY Name", false)]
        [DataRow("UPDATE PRODUCTS SET Name = 'MyName' WHERE IdProduct = 1", false)]
        [DataRow("DELETE FROM PRODUCTS WHERE IdProduct = 1", false)]
        // SHOULD BE TRUE
        [DataRow("SELECT UPDATE", true)]
        [DataRow("INSERT DELETE INTO USUARIOS", true)]
        [DataRow("SELECT INSERT DELETE", true)]
        [DataRow("SELECT INSERT DELETE UPDATE", true)]
        [DataRow("DELETE * FROM USUARIO", true)]
        [DataRow("GROUP BY *", true)]
        public void ContainsUnspectedtokens(string input, bool contains)
        {
            var result = _lexicalAnalyzer.Tokenize(input);
            Assert.AreEqual(contains, result.HasErrors);
        }
    }
}
