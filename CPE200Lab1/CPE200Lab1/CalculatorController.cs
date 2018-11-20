using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorController : Controller
    {
        public void BtnNumberPerform(string num)
        {
            ((CalculatorModel)m).PerformBtnNumber(num);
        }

        public void OperatorPerform(string oper)
        {
            ((CalculatorModel)m).PerformOperate(oper);
        }

        public void EqualPerform()
        {
            ((CalculatorModel)m).PerformEqual();
        }
    }
}
