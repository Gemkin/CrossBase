using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.CrossBase.CodeGeneration.TestData
{
    public enum CalculatorOperator
    {
        Plus,
        Minus,
    }

    public class CalculatorController
    {
        private readonly List<object> actions;
        private bool isEnteringNumber;
        private int enteringNumber;
        
        public int Result
        {
            get
            {
                return CalculateByLoopingOverActions();
            }
        }


        private int CalculateByLoopingOverActions()
        {
            var result = 0;
            for (int index = 0; index < actions.Count; index++)
            {
                var left = actions[index];

                if (left is CalculatorOperator)
                {
                    if (RightTermNotExists(index))
                        continue;
                    var oper = (CalculatorOperator) left;
                    var right = (int) actions[index + 1];

                    result = Calculate(oper, result, right);
                    index++;
                }
                else
                {
                    result = (int) left;
                }
            }
            return result;
        }

        private static int Calculate(CalculatorOperator oper, int result, int right)
        {
            switch (oper)
            {
                case CalculatorOperator.Plus:
                    result +=right;
                    break;
                case CalculatorOperator.Minus:
                    result += -1*right;
                    break;
            }
            return result;
        }

        private bool RightTermNotExists(int index)
        {
            return index + 1 >= actions.Count;
        }

        public string Display
        {
            get
            {
                var s = string.Empty;
                foreach (var action in actions)
                {
                    if (action is CalculatorOperator)
                    {
                        var oper = (CalculatorOperator) action;
                        switch (oper)
                        {
                            case CalculatorOperator.Plus:
                                s += "+";
                                break;
                            case CalculatorOperator.Minus:
                                s += "-";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    else
                    {
                        s += action;
                    }
                }
                return s;
            }
        }


        public CalculatorController()
        {
            actions = new List<object>();
        }

        public void EnterNumber(int i)
        {
            if (i > 9)
                throw new EnteredNumberOutOfRangeException();
            if (isEnteringNumber)
            {
                RemoveAtEnd();
            }
            else
            {
                isEnteringNumber = true;
                enteringNumber = 0;
            }
            enteringNumber *= 10;
            enteringNumber += i;
            actions.Add(enteringNumber);
        }

        private void RemoveAtEnd()
        {
            actions.RemoveAt(actions.Count - 1);
        }

        public void EnterOperator(CalculatorOperator op)
        {
            if (isEnteringNumber)
            {
                isEnteringNumber = false;
            }
            else
            {
                RemoveAtEnd();
            }
            actions.Add(op);
        }
        
        public class EnteredNumberOutOfRangeException : Exception
        {
        }

        public class EnteredOperatorNotAllowedException : Exception
        {
        }

        public void Calculate()
        {
            

        }
    }
}
