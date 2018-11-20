using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorModel : Model
    {
        protected string _lblDisplay;
        protected string _firstOperand;
        protected int _oper;
        protected TheCalculatorEngine _engine;

        public CalculatorModel()
        {
            _engine = new CalculatorEngine();
            resetAll();
        }

        public void resetAll()
        {
            _firstOperand = null;
            _lblDisplay = "0";
        }

        protected bool isSetFirstOperand()
        {
            return _firstOperand != null;
        }
        
        public string GetDisplay()
        {
            return _lblDisplay;
        }

        public string getDisplay()
        {
            return _firstOperand;
        }

        public void PerformBtnNumber(string num)
        {
            if(_lblDisplay == "0")
            {
                _lblDisplay = "";
            }
            _lblDisplay += num;
            NotifyAll();
        }
    }
}
