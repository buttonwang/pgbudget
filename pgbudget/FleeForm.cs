using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ciloci.Flee;
using NCalc;

namespace pgbudget
{
    public partial class FleeForm : Form
    {
        ExpressionContext context = new ExpressionContext();

        public FleeForm()
        {
            InitializeComponent();
        }

        private void FleeForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonCal_Click(object sender, EventArgs e)
        {
            IDynamicExpression exp = context.CompileDynamic(textBoxF.Text);
            textBoxR.Text =  exp.Evaluate().ToString();
        }

        private void buttonNCal_Click(object sender, EventArgs e)
        {
            Expression exp = new Expression(textBoxF.Text);
            textBoxRNCal.Text = exp.Evaluate().ToString();
        }
    }
}
