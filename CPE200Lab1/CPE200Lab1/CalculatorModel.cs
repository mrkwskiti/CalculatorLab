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
        protected string operate;
        protected bool isOperClicked;
        protected TheCalculatorEngine _engine;

        public CalculatorModel()
        {
            _engine = new CalculatorEngine();
            resetAll();
        }

        public void resetAll()
        {
            _firstOperand = null;
            operate = null;
            isOperClicked = false;
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

        public void PerformBtnNumber(string num)
        {
            if(_lblDisplay == "0" || isOperClicked)
            {
                _lblDisplay = "";
            }
            _lblDisplay += num;
            NotifyAll();
        }

        public void PerformOperate(string oper)
        {
            operate = oper;
            if (!isSetFirstOperand())
            {
                _firstOperand = _lblDisplay;
            }
            else
            {
                PerformEqual();
            }
            isOperClicked = true;
        }

        public void PerformEqual()
        {
            if(operate == null)
            {
                return;
            }
            _firstOperand = _engine.calculate(operate, _firstOperand, _lblDisplay);
            _lblDisplay = _firstOperand;
            NotifyAll();
        }
    }
}
