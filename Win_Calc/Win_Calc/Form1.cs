using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Win_Calc
{
    public partial class Form1 : Form
    {

        double value = 0;
        string operation = "";
        bool operation_pressed = false;

        public Form1()
        {
            InitializeComponent();
            result.BackColor = Color.White;
            label_Equation.Focus();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((result.Text == "0") || (operation_pressed))
            {
                result.Clear();
                operation_pressed = false;
            }
            
            Button b = (Button)sender;
            result.Text = result.Text + b.Text;
        }

        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            value = Double.Parse(result.Text);
            operation_pressed = true;
            label_Equation.Text = value.ToString() + " " + operation;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+" :
                    result.Text = (value + Double.Parse(result.Text)).ToString();
                    break;
                case "-" :
                    result.Text = (value - Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (value * Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    result.Text = (value / Double.Parse(result.Text)).ToString();
                    break;
                default:
                    result.Text = "0";
                    break;
            }//end switch(operation)

            operation_pressed = false;
            label_Equation.Text = "";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            value = 0;
        }

        private void buttonReciprical_Click(object sender, EventArgs e)
        {
            if (Double.Parse(result.Text) != 0)
            {
                result.Text = (1 / Double.Parse(result.Text)).ToString();
            }
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            if (value != 0)
            { 
                switch (operation)
                    {
                        case "+" :
                            result.Text = (value + (value * Double.Parse(result.Text) * 0.01)).ToString();
                            break;
                        case "-" :
                            result.Text = (value - (value * Double.Parse(result.Text) * 0.01)).ToString();
                            break;
                        case "*":
                            result.Text = (value * (value * Double.Parse(result.Text) * 0.01)).ToString();
                            break;
                        case "/":
                            result.Text = (value / (value * Double.Parse(result.Text) * 0.01)).ToString();
                            break;
                        default:
                            result.Text = "0";
                            break;
                    }//end switch(operation) 
            }
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (result.Text != "0")
            {
                if (result.Text.Length > 1)
                {
                    result.Text = result.Text.Remove(result.Text.Length - 1, 1);
                }
                else
                {
                    result.Text = "0";
                }
            }
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e)
        {
            if (result.Text != "0")
            {
               result.Text = (Double.Parse(result.Text) * -1).ToString();
            }
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            result.Text = (Math.Sqrt(Double.Parse(result.Text))).ToString();
        }

    }
}
