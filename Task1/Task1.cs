
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF               =  0, // (EOF)
        SYMBOL_ERROR             =  1, // (Error)
        SYMBOL_WHITESPACE        =  2, // Whitespace
        SYMBOL_MINUS             =  3, // '-'
        SYMBOL_MINUSMINUS        =  4, // '--'
        SYMBOL_EXCLAMEQ          =  5, // '!='
        SYMBOL_LPAREN            =  6, // '('
        SYMBOL_RPAREN            =  7, // ')'
        SYMBOL_TIMES             =  8, // '*'
        SYMBOL_TIMESTIMES        =  9, // '**'
        SYMBOL_COMMA             = 10, // ','
        SYMBOL_DIV               = 11, // '/'
        SYMBOL_SEMI              = 12, // ';'
        SYMBOL_LBRACE            = 13, // '{'
        SYMBOL_RBRACE            = 14, // '}'
        SYMBOL_PLUS              = 15, // '+'
        SYMBOL_PLUSPLUS          = 16, // '++'
        SYMBOL_LT                = 17, // '<'
        SYMBOL_EQ                = 18, // '='
        SYMBOL_EQEQ              = 19, // '=='
        SYMBOL_GT                = 20, // '>'
        SYMBOL_DIGIT             = 21, // Digit
        SYMBOL_ELSE              = 22, // else
        SYMBOL_END               = 23, // End
        SYMBOL_FLOAT             = 24, // float
        SYMBOL_FUNC              = 25, // func
        SYMBOL_ID                = 26, // Id
        SYMBOL_IF                = 27, // if
        SYMBOL_INT               = 28, // int
        SYMBOL_REP               = 29, // rep
        SYMBOL_RET               = 30, // ret
        SYMBOL_START             = 31, // Start
        SYMBOL_STRING            = 32, // string
        SYMBOL_ASSIGN            = 33, // <assign>
        SYMBOL_BODY              = 34, // <Body>
        SYMBOL_CON               = 35, // <con>
        SYMBOL_CONCEPT           = 36, // <concept>
        SYMBOL_COND              = 37, // <cond>
        SYMBOL_DATA              = 38, // <data>
        SYMBOL_DATAMINUSTYPE     = 39, // <data-Type>
        SYMBOL_DECLARATION       = 40, // <declaration>
        SYMBOL_DIGIT2            = 41, // <digit>
        SYMBOL_EXP               = 42, // <exp>
        SYMBOL_EXPR              = 43, // <expr>
        SYMBOL_FACTOR            = 44, // <factor>
        SYMBOL_FUNCTION_DEC      = 45, // <function_dec>
        SYMBOL_FUNCTIONMINUSCALL = 46, // <function-call>
        SYMBOL_ID2               = 47, // <id>
        SYMBOL_MAIN              = 48, // <main>
        SYMBOL_NAME              = 49, // <name>
        SYMBOL_OP                = 50, // <op>
        SYMBOL_PARAMETER         = 51, // <parameter>
        SYMBOL_REPEAT            = 52, // <repeat>
        SYMBOL_STEP              = 53, // <step>
        SYMBOL_TERM              = 54  // <term>
    };

    enum RuleConstants : int
    {
        RULE_MAIN_START_END                                    =  0, // <main> ::= Start <Body> End
        RULE_BODY                                              =  1, // <Body> ::= <concept>
        RULE_BODY2                                             =  2, // <Body> ::= <concept> <Body>
        RULE_CONCEPT                                           =  3, // <concept> ::= <assign>
        RULE_CONCEPT2                                          =  4, // <concept> ::= <declaration>
        RULE_CONCEPT3                                          =  5, // <concept> ::= <cond>
        RULE_CONCEPT4                                          =  6, // <concept> ::= <repeat>
        RULE_CONCEPT5                                          =  7, // <concept> ::= <function_dec>
        RULE_CONCEPT6                                          =  8, // <concept> ::= <function-call>
        RULE_ASSIGN_EQ                                         =  9, // <assign> ::= <id> '=' <expr>
        RULE_ID_ID                                             = 10, // <id> ::= Id
        RULE_EXPR_PLUS                                         = 11, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                        = 12, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                              = 13, // <expr> ::= <term>
        RULE_TERM_TIMES                                        = 14, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                          = 15, // <term> ::= <term> '/' <factor>
        RULE_TERM                                              = 16, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                                 = 17, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR                                            = 18, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                 = 19, // <exp> ::= '(' <expr> ')'
        RULE_EXP                                               = 20, // <exp> ::= <id>
        RULE_EXP2                                              = 21, // <exp> ::= <digit>
        RULE_DIGIT_DIGIT                                       = 22, // <digit> ::= Digit
        RULE_COND_IF_LPAREN_RPAREN                             = 23, // <cond> ::= if '(' <con> ')' <Body>
        RULE_COND_IF_LPAREN_RPAREN_ELSE                        = 24, // <cond> ::= if '(' <con> ')' <Body> else <cond>
        RULE_CON                                               = 25, // <con> ::= <expr> <op> <expr>
        RULE_OP_LT                                             = 26, // <op> ::= '<'
        RULE_OP_GT                                             = 27, // <op> ::= '>'
        RULE_OP_EQEQ                                           = 28, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                       = 29, // <op> ::= '!='
        RULE_REPEAT_REP_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE  = 30, // <repeat> ::= rep '(' <data> <assign> ';' <con> ';' <step> ')' '{' <Body> '}'
        RULE_DATA_INT                                          = 31, // <data> ::= int
        RULE_DATA_STRING                                       = 32, // <data> ::= string
        RULE_DATA_FLOAT                                        = 33, // <data> ::= float
        RULE_STEP_MINUSMINUS                                   = 34, // <step> ::= '--' <id>
        RULE_STEP_PLUSPLUS                                     = 35, // <step> ::= '++' <id>
        RULE_STEP                                              = 36, // <step> ::= <assign>
        RULE_DECLARATION                                       = 37, // <declaration> ::= <data> <assign>
        RULE_FUNCTION_DEC_FUNC_LPAREN_RPAREN_LBRACE_RET_RBRACE = 38, // <function_dec> ::= func <data-Type> <name> '(' <parameter> ')' '{' <Body> ret <id> '}'
        RULE_NAME                                              = 39, // <name> ::= <id>
        RULE_DATATYPE                                          = 40, // <data-Type> ::= <data>
        RULE_PARAMETER                                         = 41, // <parameter> ::= <data> <id>
        RULE_PARAMETER_COMMA                                   = 42, // <parameter> ::= <data> <id> ',' <parameter>
        RULE_FUNCTIONCALL_LPAREN_RPAREN                        = 43  // <function-call> ::= <name> '(' <parameter> ')'
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNC :
                //func
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REP :
                //rep
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RET :
                //ret
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BODY :
                //<Body>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CON :
                //<con>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA :
                //<data>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATAMINUSTYPE :
                //<data-Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLARATION :
                //<declaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_DEC :
                //<function_dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONMINUSCALL :
                //<function-call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MAIN :
                //<main>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NAME :
                //<name>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETER :
                //<parameter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REPEAT :
                //<repeat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_MAIN_START_END :
                //<main> ::= Start <Body> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BODY :
                //<Body> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BODY2 :
                //<Body> ::= <concept> <Body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <declaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <cond>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <repeat>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT5 :
                //<concept> ::= <function_dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT6 :
                //<concept> ::= <function-call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ :
                //<assign> ::= <id> '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND_IF_LPAREN_RPAREN :
                //<cond> ::= if '(' <con> ')' <Body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND_IF_LPAREN_RPAREN_ELSE :
                //<cond> ::= if '(' <con> ')' <Body> else <cond>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CON :
                //<con> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_REPEAT_REP_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE :
                //<repeat> ::= rep '(' <data> <assign> ';' <con> ';' <step> ')' '{' <Body> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_INT :
                //<data> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_STRING :
                //<data> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_FLOAT :
                //<data> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECLARATION :
                //<declaration> ::= <data> <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_DEC_FUNC_LPAREN_RPAREN_LBRACE_RET_RBRACE :
                //<function_dec> ::= func <data-Type> <name> '(' <parameter> ')' '{' <Body> ret <id> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NAME :
                //<name> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATATYPE :
                //<data-Type> ::= <data>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER :
                //<parameter> ::= <data> <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER_COMMA :
                //<parameter> ::= <data> <id> ',' <parameter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONCALL_LPAREN_RPAREN :
                //<function-call> ::= <name> '(' <parameter> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
