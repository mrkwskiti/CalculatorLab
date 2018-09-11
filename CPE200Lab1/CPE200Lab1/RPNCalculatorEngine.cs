using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            // your code 
            string[] parts = str.Split(' ');
            Stack<string> operands = new Stack<string>();
            for (int i = 0; i < parts.Length; i++)
            {
                if (isNumber(parts[i]))
                {
                    operands.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                if (operands.Count < 2)
                    {
                        return "E";
                    }
                string secondOperands = operands.Pop();
                operands.Push(calculate(parts[i], operands.Pop(), secondOperands));
                }
            }
            if(operands.Count == 1)
            {
                return operands.Pop();
            }
            return "E";
        }
    }
}

