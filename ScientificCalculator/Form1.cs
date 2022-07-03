using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScientificCalculator
{
    public partial class Form1 : Form
    {
        public double total = 0;
        public int mode = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void jikkouButton_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }




        // 演算buttonの入力処理部
        private void plusButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += '+';
        }
        private void powButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "^2";
        }



        // numButtonの入力処理部
        private void numButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text += '1';
        }
        private void numButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text += '2';
        }
        private void numButton3_Click(object sender, EventArgs e)
        {
            textBox1.Text += '3';
        }
        private void numButton4_Click(object sender, EventArgs e)
        {
            textBox1.Text += '4';
        }
        private void numButton5_Click(object sender, EventArgs e)
        {
            textBox1.Text += '5';
        }
        private void numButton6_Click(object sender, EventArgs e)
        {
            textBox1.Text += '6';
        }
        private void numButton7_Click(object sender, EventArgs e)
        {
            textBox1.Text += '7';
        }
        private void numButton8_Click(object sender, EventArgs e)
        {
            textBox1.Text += '8';
        }
        private void numButton9_Click(object sender, EventArgs e)
        {
            textBox1.Text += '9';
        }
        private void numButton0_Click(object sender, EventArgs e)
        {
            textBox1.Text += '0';
        }
        private void numButtonPeriod_Click(object sender, EventArgs e)
        {
            textBox1.Text += '.';
        }


        // 初期化処理
        private void clearButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
        }

    }
}
