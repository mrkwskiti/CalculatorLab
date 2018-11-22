using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNCalculatorModel : Model
    {
        string _lblDisplay;
        bool hasDot;
        RPNCalculatorEngine engine;

        // set default method is rightmostDisplay
        protected bool isDot() => this.isDot(rightmostDisplay());
        protected bool isDot(string txt) => txt == ".";

        protected bool isSpace() => this.isSpace(rightmostDisplay());
        protected bool isSpace(string txt) => txt == " ";

        protected string rightmostDisplay() => _lblDisplay[_lblDisplay.Length - 1].ToString();

        public RPNCalculatorModel()
        {
            engine = new RPNCalculatorEngine();
            ResetAll();
        }

        public void ResetAll()
        {
            _lblDisplay = "0";
            hasDot = false;
        }

        public string GetDisplay()
        {
            return _lblDisplay;
        }

        public void PerformNumber(string num)
        {
            if (!engine.isNumber(rightmostDisplay()) && !isDot() && !isSpace())
            {
                _lblDisplay += " ";
            }
            if (_lblDisplay == "0")
            {
                _lblDisplay = "";
            }
            _lblDisplay += num;
            NotifyAll();
        }

        public void PerformDot()
        {
            if (hasDot)
            {
                return;
            }
            _lblDisplay += ".";
            hasDot = true;
            NotifyAll();
        }
        
        public void PerformSpace()
        {
            if (isSpace())
            {
                return;
            }
            _lblDisplay += " ";
            NotifyAll();
        }

        public void PerformOperator(string oper)
        {
            if (!isSpace())
            {
                _lblDisplay += " ";
            }
            _lblDisplay += oper;
            NotifyAll();
        }

        public void PerformEqual(string str)
        {
            _lblDisplay = engine.calculate(str);
            NotifyAll();
        }
        
    }
}
