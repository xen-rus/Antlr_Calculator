using Antlr4.Runtime;
using Calculator_ANTLR.Classes.Visitors;
using System;
using System.Collections.Generic;
using System.Text;


namespace Calculator_ANTLR.Classes
{
    public class AntlrCalcuator
    {
        public double Calculate(string input)
        {
            string extention = input; 
            var charStream = new AntlrInputStream(extention);

            //Create lexer Grammer and add trow listner
            var lexer = new CalcGrammerLexer(charStream);
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowingErrorListener<int>());
            //lexer.AddErrorListener(new BaseErrorListener());
            var tokenStream = new CommonTokenStream(lexer);

            //Create parser Grammer and add trow listner
            var parser = new CalcGrammerParser(tokenStream);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(new ThrowingErrorListener<IToken>());

            //Create parsetree and calculate           
            var info = parser.start();
            var visitor = new ApplyVisitor().Visit(info);

            return visitor;
        }

    }
}
