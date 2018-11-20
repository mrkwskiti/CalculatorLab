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
    public partial class CalculatorView : Form, View
    {
        Model model;
        CalculatorController controller;

        public CalculatorView()
        {
            InitializeComponent();
            model = new CalculatorModel();
            model.AttachObserver(this);
            controller = new CalculatorController();
            controller.AddModel(model);
        }

        public void Notify(Model m)
        {
            UpdateDisplay(((CalculatorModel)m).GetDisplay());
        }
        
        public void UpdateDisplay(string lblDisplay)
        {
            this.lblDisplay.Text = lblDisplay;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            controller.BtnNumberPerform(((Button)sender).Text);
        }

        private void btnOper_Click(object sender, EventArgs e)
        {
            controller.OperatorPerform(((Button)sender).Text);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            controller.EqualPerform();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            controller.ClearPerform();
        }
    }
}
