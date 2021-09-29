using System;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Calculator_ANTLR.Classes;
using Calculator_ANTLR.Classes.Visitors;


namespace Calculator_ANTLR
{
    class Program
    {
        static void Main(string[] args)
        {
           
            while(true)
            {
                Console.WriteLine("Input expression or 0 to exit");
                try
                {
                    string Exp = Console.ReadLine();

                    if (Exp == "0")
                        break;

                    AntlrCalcuator calcuator = new AntlrCalcuator();

                    Console.WriteLine($"result = " + calcuator.Calculate(Exp));
                }
                catch (ArgumentException arg)
                {
                    Console.WriteLine(arg.Message);
                }
            } 



        }
    }





}
