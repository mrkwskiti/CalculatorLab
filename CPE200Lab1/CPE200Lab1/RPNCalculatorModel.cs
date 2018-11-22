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
        RPNCalculatorEngine engine;
        
        public RPNCalculatorModel()
        {
            engine = new RPNCalculatorEngine();
            ResetAll();
        }

        public void ResetAll()
        {
            _lblDisplay = "0";
        }

        public string GetDisplay()
        {
            return _lblDisplay;
        }

        
    }
}
