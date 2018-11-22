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
        protected string memory;
        protected bool isOperClicked;
        protected bool hasDot;
        protected TheCalculatorEngine _engine;

        public CalculatorModel()
        {
            _engine = new CalculatorEngine();
            resetAll();
        }

        public bool isError()
        {
            return _lblDisplay == "Error";
        }

        public void resetAll()
        {
            _firstOperand = null;
            operate = null;
            isOperClicked = false;
            hasDot = false;
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
            if (isError())
            {
                return;
            }
            if(_lblDisplay == "0" || isOperClicked)
            {
                _lblDisplay = "";
                isOperClicked = false;
                hasDot = false;
            }
            if(_lblDisplay.Length < 8)
            {
                _lblDisplay += num;
            }
            NotifyAll();
        }

        public void PerformModifyMemory(string oper)
        {
            if (isError())
            {
                return;
            }
            if(memory == null)
            {
                memory = "0";
            }
            memory = _engine.calculate(oper, memory, _lblDisplay);
            isOperClicked = true;
        }

        public void PerformMemoryRecall()
        {
            if(memory == null)
            {
                return;
            }
            _lblDisplay = memory;
            NotifyAll();
        }

        public void PerformOperate(string oper)
        {
            operate = oper;
            if (isOperClicked || isError())
            {
                return;
            }
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
            if(operate == null || isError())
            {
                return;
            }
            _firstOperand = _engine.calculate(operate, _firstOperand, _lblDisplay);
            if(_firstOperand.Length > 8)
            {
                _firstOperand = "Error";
            }
            _lblDisplay = _firstOperand;
            NotifyAll();
        }

        public void PerformClear()
        {
            resetAll();
            NotifyAll();
        }

        public void PeformDot()
        {
            if (hasDot || isError())
            {
                return;
            }
            _lblDisplay += ".";
            hasDot = true;
            NotifyAll();
        }

        public void PerFormSign()
        {
            if (isError())
            {
                return;
            }
            _lblDisplay = _engine.calculate("X", _lblDisplay, "-1");
            NotifyAll();
        }

        public void PerformUnary(string unary)
        {
            if (isError())
            {
                return;
            }
            _lblDisplay = _engine.calculate(unary, _lblDisplay);
            NotifyAll();
        }

        public void PerformPercent()
        {
            if (isError())
            {
                return;
            }
            if (isSetFirstOperand())
            {
                _lblDisplay = _engine.calculate("%", _firstOperand, _lblDisplay);
            }
            else
            {
                PerformUnary("%");
            }
            NotifyAll();
        }

        public void PerformBack()
        {
            if (isOperClicked || isError())
            {
                return;
            }
            if(_lblDisplay != "0")
            {
                if(_lblDisplay[_lblDisplay.Length - 1] == '.')
                {
                    hasDot = false;
                }
                _lblDisplay = _lblDisplay.Substring(0, _lblDisplay.Length - 1);
                if(_lblDisplay == "" || _lblDisplay == "-")
                {
                    _lblDisplay = "0";
                }
                NotifyAll();
            }
        }


    }
}
