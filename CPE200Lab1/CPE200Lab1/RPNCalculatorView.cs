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
    public partial class RPNCalculatorView : Form ,View
    {
        RPNCalculatorModel model;
        RPNCalculatorController controller;

        public RPNCalculatorView()
        {
            InitializeComponent();
            model = new RPNCalculatorModel();
            model.AttachObserver(this);
            controller = new RPNCalculatorController();
            controller.AddModel(model);
            Notify(model);
        }

        public void Notify(Model m)
        {
            UpdateDisplay(((RPNCalculatorModel)m).GetDisplay());
        }

        private void UpdateDisplay(string lblDisplay)
        {
            this.lblDisplay.Text = lblDisplay;
        }

        private void btnNumber_Click(object sender, EventArgs e) => controller.NumberPerform(((Button)sender).Text);

        private void btnSpace_Click(object sender, EventArgs e) => controller.SpacePerform();
    }
}
