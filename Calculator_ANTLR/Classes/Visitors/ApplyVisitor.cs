using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static Calculator_ANTLR.CalcGrammerParser;
using Antlr4.Runtime;

namespace Calculator_ANTLR.Classes.Visitors
{
    class ApplyVisitor  :  CalcGrammerBaseVisitor<double> 
    {
        public override double VisitStart([NotNull] CalcGrammerParser.StartContext context)
        {
            return base.VisitStart(context);
        }

        public override double VisitExpr([NotNull] CalcGrammerParser.ExprContext context)
        {
            return base.VisitExpr(context);

        }
       
        public override double VisitUMS([NotNull] CalcGrammerParser.UMSContext context)
        {
           
            return DoubleRegionConverter(context.GetText());
        }

        public override double VisitMULDGRP([NotNull] CalcGrammerParser.MULDGRPContext context)
        {
            var oper = context.mulop().GetText();
            var lVal = Visit(context.expr(0));
            var RVal = Visit(context.expr(1));

            var val = PrepareValue(lVal, RVal, oper);
            return val;

        }

        public override double VisitADDRGRP([NotNull] ADDRGRPContext context)
        {
            var oper = context.addop().GetText();
            var lVal = Visit(context.expr(0));
            var RVal = Visit(context.expr(1));

            var val = PrepareValue(lVal, RVal, oper);
            return val;
        }

        public override double VisitArgumentException([NotNull] CalcGrammerParser.ArgumentExceptionContext context)
        {
            throw (new ArgumentException($"Incorect Input "+ context.parent.GetText()));
        }

        public override double VisitNUM([NotNull] NUMContext context)
        {
            var info = DoubleRegionConverter(context.GetText());
                return info;

        }

       
        public override double VisitPARGRP([NotNull] PARGRPContext context)
        {
                var Val = Visit(context.expr());
                return Val;
        }

        public override double Visit([NotNull] IParseTree tree)
        {
            return base.Visit(tree);
        }

       

        private double PrepareValue(double lVal, double rVal, string operation) =>
          operation switch
          {
              "+" => lVal + rVal,
              "-" => lVal - rVal,
              "*" => lVal * rVal,
              "/" => lVal / rVal,
              _ => 0,
          };


        //For Double value
        private double DoubleRegionConverter( string text)
        {
            double val;
           if(!double.TryParse(text,out val))
            {
                if (text.IndexOf('.') == -1)
                    text = text.Replace(',', '.');
                else
                    text = text.Replace('.', ',');

                double.TryParse(text, out val);
            }
            return val;
        }



        


        
    }
}
