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
            if ((isNumber(parts[0]) && isNumber(parts[1]) && isOperator(parts[2])))
            {
                return calculate(parts[2], parts[0], parts[1], 4);
            }
            else
            {
                return "E";
            }
        }
    }
}
