using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class Form1 : Form
    {
        string firstOperand;
        bool btn_Clicked = false;
        string operation;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
        
            if (lblDisplay.Text == "0" || btn_Clicked)
            {
                lblDisplay.Text = "";
                btn_Clicked = false;
            }
            if (lblDisplay.Text.Length < 9)
            {
                lblDisplay.Text += ((Button)sender).Text;
            }
            
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            firstOperand = lblDisplay.Text;
            btn_Clicked = true;
            operation = btn.Text;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            float result = 0;
            switch (operation)
            {
                case "+":
                    result = float.Parse(firstOperand) + float.Parse(lblDisplay.Text);
                    break;
                case "-":
                    result = float.Parse(firstOperand) - float.Parse(lblDisplay.Text);
                    break;
                case "X":
                    result = float.Parse(firstOperand) * float.Parse(lblDisplay.Text);
                    break;
                case "÷":
                    result = float.Parse(firstOperand) / float.Parse(lblDisplay.Text);
                    break;
            }
            lblDisplay.Text = Convert.ToString(result);
            btn_Clicked = true;
        }
    }
}
