using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_ANTLR.Classes
{
    internal class ThrowingErrorListener<TSymbol> : IAntlrErrorListener<TSymbol> 
    {

        public void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] TSymbol offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
        {
            throw (new ArgumentException(($"line {line}:{charPositionInLine} {msg}")));

        }

    }
}
