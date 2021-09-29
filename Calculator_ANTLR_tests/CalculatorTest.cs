using NUnit.Framework;
using Calculator_ANTLR;
using Calculator_ANTLR.Classes;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;

namespace Calculator_ANTLR_tests
{
    public class Tests
    {
        AntlrCalcuator calc;
        [SetUp]
        public void Setup()
        {
            calc = new AntlrCalcuator();
        }

        [Test]
        public void TestSimleGrammer()
        {
            var val = calc.Calculate("1 + 1");
            Assert.IsTrue(val == 2);

            val = calc.Calculate("-3 + 2");
            Assert.IsTrue(val == -1);
        }

        [Test]
        public void TestGrammer()
        {
            var val = calc.Calculate("2*(10+1)");
            Assert.IsTrue(val == 22);

            val = calc.Calculate("5 + 5 * 2 +(6 /3) ");
            Assert.IsTrue(val == 17);

            val = calc.Calculate("5 + 5 * 2 +(-3)");
            Assert.IsTrue(val == 12);
        }


        [Test]
        public void TestDoubleGrammer()
        {
            var val = calc.Calculate("2.5 * (4.2 + 1.8)");
            Assert.IsTrue(val == 15);

            val = calc.Calculate("5,6 + 5,5 * 2.3 +(6.2 /2) ");// не консистентно  и не очень хорошо
            Assert.IsTrue(val == 21.35);

        }


        [Test]
        public void TestException1()
        {
            try
            { 
                var val = calc.Calculate("2 * *(10 + 1)");
            }
            catch(Exception ex)
            { 
                Assert.IsTrue(ex is Exception);
            }
        }

        [Test]
        public void TestException2()
        {
            try
            {
                var val = calc.Calculate("2 2");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception);
            }
        }

        [Test]
        public void TestException3()
        {
            try
            {
                var val = calc.Calculate("2 2 2");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception);
            }
        }

        [Test]
        public void TestException4()
        {
            try
            {
                var val = calc.Calculate("2 + 2 (2)");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception);
            }
        }


    }
}