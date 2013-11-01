using System;
using NUnit.Framework;
using Test.CrossBase.CodeGeneration.TestData;

namespace Test.CrossBase.CodeGeneration
{
    [TestFixture]
    public class TestCalulatorController
    {
        private CalculatorController controller;

        [SetUp]
        public void SetUp()
        {
            controller = new CalculatorController();
        }

        [Test]
        public void TestEnterNumberShowsNumberInDisplay()
        {
            controller.EnterNumber(1);
            Assert.That(controller.Display, Is.EqualTo("1"));
            controller.EnterNumber(2);
            Assert.That(controller.Display, Is.EqualTo("12"));
            controller.EnterNumber(5);
            Assert.That(controller.Display, Is.EqualTo("125"));
            controller.EnterNumber(9);
            Assert.That(controller.Display, Is.EqualTo("1259"));
        }

        [Test, ExpectedException(typeof(CalculatorController.EnteredNumberOutOfRangeException))]
        public void TestEnterNumberThrowsExceptionWhenLargerThanNine()
        {
            controller.EnterNumber(10);
        }


        [Test]
        public void TestEnterOperatorShowsInDisplay()
        {
            controller.EnterNumber(1);
            controller.EnterOperator(CalculatorOperator.Plus);
            Assert.That(controller.Display, Is.EqualTo("1+"));
        }

        [Test]
        public void TestAnotherOperatorChangesTheLastOne()
        {
            controller.EnterNumber(1);
            controller.EnterOperator(CalculatorOperator.Plus);
            controller.EnterOperator(CalculatorOperator.Minus);
            Assert.That(controller.Display, Is.EqualTo("1-"));
        }

        [Test]
        public void TestCalulateMultipleTerms()
        {
            controller.EnterNumber(1);
            Assert.That(controller.Result, Is.EqualTo(1));
            controller.EnterNumber(1);
            Assert.That(controller.Result, Is.EqualTo(11));
            controller.EnterNumber(1);
            Assert.That(controller.Result, Is.EqualTo(111));
            controller.EnterOperator(CalculatorOperator.Plus);
            Assert.That(controller.Result, Is.EqualTo(111));
            controller.EnterNumber(2);
            Assert.That(controller.Result, Is.EqualTo(113));
            controller.EnterNumber(2);
            Assert.That(controller.Result, Is.EqualTo(133));
            controller.EnterNumber(2);
            Assert.That(controller.Result, Is.EqualTo(333));
            controller.EnterOperator(CalculatorOperator.Minus);
            controller.EnterNumber(4);
            controller.EnterNumber(4);
            controller.EnterNumber(4);
            Assert.That(controller.Result, Is.EqualTo(-111));
        }
    }
}
