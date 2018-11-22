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

        public bool isDot(string text) => text == ".";

        public void PerformNumber(string num)
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
