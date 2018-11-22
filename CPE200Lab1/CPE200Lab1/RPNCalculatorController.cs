using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNCalculatorController : Controller
    {

        public void NumberPerform(string num) => ((RPNCalculatorModel)m).PerformNumber(num);
    }
}
