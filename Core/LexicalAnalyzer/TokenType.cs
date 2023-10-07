using System;

namespace Core.LexicalAnalyzer
{
    public enum TokenType
    {
        [Obsolete]
        Keyword,
        [Obsolete]
        Assignment,
        [Obsolete]
        Semicolon,
        [Obsolete]
        StringLiteral,
        [Obsolete]
        IntegerLiteral,

        // SQL KEYWORDS
        Select,
        From,
        Where,
        OrderBy,
        Insert,
        Into,
        Values,
        Update,
        Set,
        Delete,

        // OPERATORS
        Equals,
        Like,
        Not,

        // MISC
        Comma,
        Asterisk,
        Identifier,
        Match,
        Number,

        // ORDER
        Desc,
        Asc,

        Undefined,
    }
}
