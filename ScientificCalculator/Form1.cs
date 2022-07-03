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
        private bool updateFlag = false;
        public Form1()
        {
            InitializeComponent();
        }

        string enzanshi;   //演算子記憶用の変数
        double valueLeft = 0;   //演算子の左側の数字
        double valueRight = 0;  //演算子の右側の数字
        double keta = 0;
        double[] s = new double[100];   //入力を入れる配列
        int cnt = 0;    //配列の何番目かカウント用変数


        //public static double Sin (double a);

        private void jikkouButton_Click(object sender, EventArgs e)
        {

            int k = 0;  //配列の要素が小さいほうが桁が大きい
            //入力された値を直す
            valueRight = 0;
            for (int i = cnt - 1; i >= 0; i--)
            {
                keta = Math.Pow(10, k);   //何桁目にするか(10^kを計算)
                valueRight = valueRight + (s[i] * keta);   //入力された値を正しく戻して代入
                k++;

            }

            cnt = 0;


            //演算子の判定
            if (enzanshi == "+")
            {
                total = valueLeft + valueRight;
            }
            else if (enzanshi == "-")
            {
                total = valueLeft - valueRight;
            }
            else if (enzanshi == "*")
            {
                total = valueLeft * valueRight;
            }
            else if (enzanshi == "/")
            {
                total = valueLeft / valueRight;
            }
            else if (enzanshi == "sin")
            {
                //total = valueLeft sin valueRight;
            }


            textBox1.Text += "=";
            textBox1.Text += total.ToString();


        }



        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
            enzanshi = "*";

            int k = 0;

            if (valueLeft == 0)
            {
                for (int i = cnt - 1; i >= 0; i--)
                {
                    keta = Math.Pow(10, k);   //何桁目にするか(10^iを計算)
                    valueLeft = valueLeft + (s[i] * keta);   //入力された値を正しく戻して代入
                    k++;

                }
                cnt = 0;
            }
            else //2回目以降
            {
                valueRight = 0;
                for (int i = cnt - 1; i >= 0; i--)
                {
                    keta = Math.Pow(10, k);   //何桁目にするか(10^iを計算)
                    valueRight = valueRight + (s[i] * keta);   //入力された値を正しく戻して代入
                    k++;

                }

                cnt = 0;
                valueLeft = valueLeft + valueRight;

            }

        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += '+';
            enzanshi = "+";
            int k = 0;

            if (valueLeft == 0)
            {
                for (int i = cnt - 1; i >= 0; i--)
                {
                    keta = Math.Pow(10, k);   //何桁目にするか(10^iを計算)
                    valueLeft = valueLeft + (s[i] * keta);   //入力された値を正しく戻して代入
                    k++;

                }
                cnt = 0;
            }
            else //2回目以降
            {
                valueRight = 0;
                for (int i = cnt - 1; i >= 0; i--)
                {
                    keta = Math.Pow(10, k);   //何桁目にするか(10^iを計算)
                    valueRight = valueRight + (s[i] * keta);   //入力された値を正しく戻して代入
                    k++;

                }

                cnt = 0;
                valueLeft = valueLeft + valueRight;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
            enzanshi = "-";

            int k = 0;

            if (valueLeft == 0)
            {
                for (int i = cnt - 1; i >= 0; i--)
                {
                    keta = Math.Pow(10, k);   //何桁目にするか(10^iを計算)
                    valueLeft = valueLeft + (s[i] * keta);   //入力された値を正しく戻して代入
                    k++;

                }
                cnt = 0;
            }
            else //2回目以降
            {
                valueRight = 0;
                for (int i = cnt - 1; i >= 0; i--)
                {
                    keta = Math.Pow(10, k);   //何桁目にするか(10^iを計算)
                    valueRight = valueRight + (s[i] * keta);   //入力された値を正しく戻して代入
                    k++;

                }

                cnt = 0;
                valueLeft = valueLeft + valueRight;

            }

        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
            enzanshi = "/";

            int k = 0;

            if (valueLeft == 0)
            {
                for (int i = cnt - 1; i >= 0; i--)
                {
                    keta = Math.Pow(10, k);   //何桁目にするか(10^iを計算)
                    valueLeft = valueLeft + (s[i] * keta);   //入力された値を正しく戻して代入
                    k++;

                }
                cnt = 0;
            }
            else //2回目以降
            {
                valueRight = 0;
                for (int i = cnt - 1; i >= 0; i--)
                {
                    keta = Math.Pow(10, k);   //何桁目にするか(10^iを計算)
                    valueRight = valueRight + (s[i] * keta);   //入力された値を正しく戻して代入
                    k++;

                }

                cnt = 0;
                valueLeft = valueLeft + valueRight;

            }
        }

        private void sinButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += "sin";
            enzanshi = "sin";
        }

        private void cosButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += "cos";
            enzanshi = "cos";
        }

        private void tanButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += "tan";
            enzanshi = "tan";
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += "log";
            enzanshi = "log";
        }

        private void arcsinButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += "arcsin";
            enzanshi = "arcsin";
        }

        private void arccosButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += "arccos";
            enzanshi = "arccos";
        }

        private void arctanButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += "arctan";
            enzanshi = "arctan";
        }

        private void expButton_Click(object sender, EventArgs e)
        {
            textBox1.Text += "exp";
            enzanshi = "exp";
        }

        private void powButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "x^2";
            enzanshi = "x^2";
        }

        private void powButton2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "x^y";
            enzanshi = "x^y";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
            s[cnt] = 1;
            cnt++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
            s[cnt] = 2;
            cnt++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
            s[cnt] = 3;
            cnt++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
            s[cnt] = 4;
            cnt++;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
            s[cnt] = 5;
            cnt++;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
            s[cnt] = 6;
            cnt++;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
            s[cnt] = 7;
            cnt++;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
            s[cnt] = 8;
            cnt++;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
            s[cnt] = 9;
            cnt++;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
            s[cnt] = 0;
            cnt++;
        }

        private bool convertibleBinHex(double x)
        {
            return x - (long)x <= double.Epsilon;
        }

        private void updateText()
        {
            if (textBox1.Text == "")
            {
                total = 0;
                textBox2.Text = "-";
                textBox3.Text = "-";
            }
            else if (!double.TryParse(textBox1.Text, out total)) 
            {
                textBox1.Text = "N/A";
                total = double.NaN;
                textBox2.Text = "-";
                textBox3.Text = "-";
            }
            else if(convertibleBinHex(total))
            {
                textBox2.Text = ((long)total).ToString("x");
                textBox3.Text = Convert.ToString((long)total, 2);
            }
            else
            {
                textBox2.Text = "-";
                textBox3.Text = "-";
            }
            //textBox2.Text = total.ToString("x");
            //textBox3.Text = Convert.ToString(total, 2);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            updateFlag = true;
            switch(e.KeyData)
            {
                case Keys.D0:
                    textBox1.Text += "0";
                    break;
                case Keys.D1:
                    textBox1.Text += "1";
                    break;
                case Keys.D2:
                    textBox1.Text += "2";
                    break;
                case Keys.D3:
                    textBox1.Text += "3";
                    break;
                case Keys.D4:
                    textBox1.Text += "4";
                    break;
                case Keys.D5:
                    textBox1.Text += "5";
                    break;
                case Keys.D6:
                    textBox1.Text += "6";
                    break;
                case Keys.D7:
                    textBox1.Text += "7";
                    break;
                case Keys.D8:
                    textBox1.Text += "8";
                    break;
                case Keys.D9:
                    textBox1.Text += "9";
                    break;
                case Keys.Back:
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                    break;
                case Keys.Decimal:
                    if (textBox1.Text.IndexOf(".") == -1)
                        textBox1.Text += ".";
                    updateFlag = false;
                    break;
                case Keys.Delete:
                    textBox1.Text = "";
                    break;
                default:
                    updateFlag = false;
                    break;
            }
            if (updateFlag) updateText();
        }
    }
}
