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
            if (args.Length > 0)
            { 
                for (int i = 0; i < args.Length; i++)
                    Calculate(args[i]);
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("Input expression or 0 to exit");
                    try
                    {
                        string Exp = Console.ReadLine();
                        if (Exp == "0")
                            break;

                        Calculate(Exp);
                    }
                    catch (ArgumentException arg)
                    {
                        Console.WriteLine(arg.Message);
                    }
                }
            }
        }

        static void Calculate(string args)
        {
            AntlrCalcuator calcuator = new AntlrCalcuator();
            Console.WriteLine($"result = " + calcuator.Calculate(args));

        }
    }





}
