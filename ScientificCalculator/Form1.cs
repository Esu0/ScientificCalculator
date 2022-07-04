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
        string enzanshi1;
        double valueLeft = 0;   //演算子の左側の数字==内部変数1
        double valueRight = 0;  //演算子の右側の数字==内部変数2
        double angle;   //ラジアンの値を格納する変数


        private void enzanshinyuuryoku()    //演算子の入力がどのようなものか判定
        {
            if (enzanshi == null)   //一回目の入力の時
            {
                valueLeft = double.Parse(textBox1.Text);    //内部変数に格納
                textBox1.Text = ""; //テキストをいったん消去
                textBox2.Text = "";
                textBox3.Text = "";
                enzanshi = enzanshi1;   //入力された演算子を保持
            }
            else if (textBox1.Text == "") //２回目の入力
            {
                enzanshi = enzanshi1;   //演算子のみ更新
            }
            else if (textBox1.Text != "")   //数字が入力されてる場合
            {
                valueRight = double.Parse(textBox1.Text);    //表示されている値を内部変数に格納
                enzan2();   //もともとの演算子を適用

                textBox1.Text = ""; //テキストをいったん消去
                textBox2.Text = "";
                textBox3.Text = "";
                enzanshi = enzanshi1; //新しい演算子を適用
            }
        }
        private void enzan2()   //演算子二回目以降の入力の時
        {
            //もともとの演算を適用
            if (enzanshi == "+")
            {
                valueLeft = valueLeft + valueRight;
            }
            else if (enzanshi == "-")
            {
                valueLeft = valueLeft - valueRight;
            }
            else if (enzanshi == "*")
            {
                valueLeft = valueLeft * valueRight;
            }
            else if (enzanshi == "/")
            {
                valueLeft = valueLeft / valueRight;
            }
            else if (enzanshi == "x^y")
            {
                valueLeft = Math.Pow(valueLeft, valueRight);
            }
        }
        private void jikkouButton_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                valueRight = 0;
            }
            else
            {
                valueRight = double.Parse(textBox1.Text);    //2つめの値を内部変数に格納
            }

            //演算子の判定と計算を行う
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
            else if (enzanshi == "one") //1変数関数の場合
            {

                total = valueLeft;
            }
            else if (enzanshi == "x^y")
            {
                total = Math.Pow(valueLeft, valueRight);
            }

            textBox1.Text = total.ToString();  //結果の表示
            updateText();   //進数変換

        }


        /*演算子のボタンを押したとき*/
        private void button14_Click(object sender, EventArgs e)
        {

            enzanshi1 = "*";    //入力された演算子を格納
            enzanshinyuuryoku();    //演算子の入力がどのようなものか判定

        }

        private void plusButton_Click(object sender, EventArgs e)
        {

            enzanshi1 = "+";
            enzanshinyuuryoku();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void minusButton_Click(object sender, EventArgs e)
        {

            enzanshi1 = "-";
            enzanshinyuuryoku();

        }

        private void divideButton_Click(object sender, EventArgs e)
        {

            enzanshi1 = "/";
            enzanshinyuuryoku();
        }

        private void sinButton_Click(object sender, EventArgs e)
        {
            enzanshi1 = "one";
            enzanshinyuuryoku();

            //入力されてる値に演算を適用する
            angle = Math.PI * valueLeft / 180;  //ラジアンに直す
            valueLeft = Math.Sin(angle);
            textBox1.Text = valueLeft.ToString();
        }

        private void cosButton_Click(object sender, EventArgs e)
        {
            enzanshi1 = "one";
            enzanshinyuuryoku();

            //入力されてる値に演算を適用する
            angle = Math.PI * valueLeft / 180;  //ラジアンに直す
            valueLeft = Math.Cos(angle);
            textBox1.Text = valueLeft.ToString();
        }

        private void tanButton_Click(object sender, EventArgs e)
        {
            enzanshi1 = "one";
            enzanshinyuuryoku();

            //入力されてる値に演算を適用する
            angle = Math.PI * valueLeft / 180;  //ラジアンに直す
            valueLeft = Math.Tan(angle);
            textBox1.Text = valueLeft.ToString();
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            enzanshi1 = "one";
            enzanshinyuuryoku();

            //入力されてる値に演算を適用する
            valueLeft = Math.Log10(valueLeft);  //入力値の常用対数(底10)を計算
            textBox1.Text = valueLeft.ToString();
        }

        private void arcsinButton_Click(object sender, EventArgs e)
        {
            enzanshi1 = "one";
            enzanshinyuuryoku();

            //入力されてる値に演算を適用する
            angle = Math.Asin(valueLeft);
            valueLeft = angle * 180 / Math.PI;  //ラジアンに直す
            textBox1.Text = valueLeft.ToString();
        }

        private void arccosButton_Click(object sender, EventArgs e)
        {
            enzanshi1 = "one";
            enzanshinyuuryoku();

            //入力されてる値に演算を適用する
            angle = Math.Acos(valueLeft);
            valueLeft = angle * 180 / Math.PI;  //ラジアンに直す
            textBox1.Text = valueLeft.ToString();
        }

        private void arctanButton_Click(object sender, EventArgs e)
        {
            enzanshi1 = "one";
            enzanshinyuuryoku();

            //入力されてる値に演算を適用する
            angle = Math.Atan(valueLeft);
            valueLeft = angle * 180 / Math.PI;  //ラジアンに直す
            textBox1.Text = valueLeft.ToString();
        }

        private void expButton_Click(object sender, EventArgs e)
        {

            enzanshi1 = "one";
            enzanshinyuuryoku();

            //入力されてる値に演算を適用する
            valueLeft = Math.Exp(valueLeft);  //入力値の常用対数(底10)を計算
            textBox1.Text = valueLeft.ToString();
        }

        private void powButton1_Click(object sender, EventArgs e)
        {

            enzanshi1 = "one";
            enzanshinyuuryoku();

            //入力されてる値に演算を適用する
            valueLeft = Math.Pow(valueLeft, 2);  //入力値の常用対数(底10)を計算
            textBox1.Text = valueLeft.ToString();
        }

        /*数字のボタンを押したとき*/
        private void powButton2_Click(object sender, EventArgs e)
        {

            enzanshi1 = "x^y";
            enzanshinyuuryoku();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";

        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";

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
            else if (convertibleBinHex(total))
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
            switch (e.KeyData)
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