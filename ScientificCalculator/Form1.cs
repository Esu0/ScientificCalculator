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
        delegate double TwoValFunc(double val1, double val2);

        //public double total = 0;
        private double num = 0;//直接変更しない

        ///<summary>
        ///ープロパティー
        ///変数と同じようにアクセスできます
        ///例：
        ///double Left = 20.0, Right = 10.0;
        ///InOutNumber = Right + Left;
        ///
        ///変数を書き換えると表示を勝手に更新してくれる仕様です。
        ///(2進数、16進数欄も勝手に更新される)
        ///</summary>

        public double InOutNumber
        {
            get { return num; }
            set { UpdateTotal(value); }
        }

        void NumberMem(bool a) // 演算子で使うとき引数true
        {
            if (Operate == Operations.Noop)
            {
                textRight.Text = "";
                textLeft.Text = "";
            }
            else
            {
                if (a)
                {
                    textRight.Text = "";
                    textLeft.Text = valueLeft.ToString();
                }
                else
                {
                    textRight.Text = valueRight.ToString();
                    textLeft.Text = valueLeft.ToString();
                }
            }
        }


        public Form1()
        {
            InitializeComponent();
        }


        string enzanshi1;   //演算子記憶用の変数
        double valueLeft = 0;   //演算子の左側の数字==内部変数1
        double valueRight = 0;  //演算子の右側の数字==内部変数2

        TwoValFunc Operate = Operations.Noop;
        bool OperatorSettingFlag = true;
        bool InputReset = false;

#pragma warning disable IDE1006 //名づけ違反のメッセージを抑制

        private void enzanshinyuuryoku()    //演算子の入力がどのようなものか判定
        {
            valueLeft = InOutNumber;    //内部変数に格納
            Operate = SelectOperator(enzanshi1);//入力された演算子を保持
            OperatorSettingFlag = true;
            InputReset = true;
            /*
            if (Operate == Operations.Noop)   //一回目の入力の時
            {
                valueLeft = InOutNumber;    //内部変数に格納
                DeleteAll();
                Operate = SelectOperator(enzanshi1);//入力された演算子を保持
                OperatorSettingFlag = true;
            }
            else if (InOutNumber <= double.Epsilon) //２回目の入力
            {
                Operate = SelectOperator(enzanshi1);//演算子のみ更新
                OperatorSettingFlag = true;
            }
            else   //数字が入力されてる場合
            {
                if (OperatorSettingFlag)
                {
                    valueRight = InOutNumber;    //表示されている値を内部変数に格納
                    enzan2();   //もともとの演算子を適用
                }

                DeleteAll();
                OperatorSettingFlag = true;
                Operate = SelectOperator(enzanshi1);//新しい演算子を適用
            }
            */
        }

        private void singleOperator(string op, bool right = true)
        {
            textEnzanshi.Text = op;
            Operate = Operations.Noop;
            if (right)
            {
                textRight.Text = InOutNumber.ToString();
                textLeft.Text = "";
            }
            else
            {
                textLeft.Text = InOutNumber.ToString();
                textRight.Text = "";
            }
            InOutNumber = valueLeft;
        }

        private void UnexpectedError(Exception ex)
        {
            DialogResult result = MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            if (result == DialogResult.Abort)
            {
                Application.Exit();
            }
            else if (result == DialogResult.Retry)
            {
                Application.Restart();
            }
        }

        /*演算子のボタンを押したとき*/
        private void button14_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "*";    //入力された演算子を格納
                enzanshinyuuryoku();    //演算子の入力がどのようなものか判定
                textEnzanshi.Text = "*";

                NumberMem(true);
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void plusButton_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "+";
                enzanshinyuuryoku();
                textEnzanshi.Text = "+";

                NumberMem(true);
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void minusButton_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "-";
                enzanshinyuuryoku();
                textEnzanshi.Text = "-";

                NumberMem(true);
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void divideButton_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "/";
                enzanshinyuuryoku();
                textEnzanshi.Text = "/";

                NumberMem(true);
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }
        // 初期化ボタンを押したとき
        private void clearButton_Click(object sender, MouseEventArgs e)
        {
            try
            {
                ResetAll();
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void sinButton_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "one";
                enzanshinyuuryoku();

                //入力されてる値に演算を適用する
                double angle = Math.PI * InOutNumber / 180;  //ラジアンに直す
                valueLeft = Math.Sin(angle);
                singleOperator("sin");
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void cosButton_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "one";
                enzanshinyuuryoku();

                //入力されてる値に演算を適用する
                double angle = Math.PI * valueLeft / 180;  //ラジアンに直す
                valueLeft = Math.Cos(angle);
                singleOperator("cos");
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void tanButton_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "one";
                enzanshinyuuryoku();

                //入力されてる値に演算を適用する
                double angle = Math.PI * valueLeft / 180;  //ラジアンに直す
                valueLeft = Math.Tan(angle);
                singleOperator("tan");
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void logButton_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "one";
                enzanshinyuuryoku();

                //入力されてる値に演算を適用する
                valueLeft = Math.Log10(valueLeft);  //入力値の常用対数(底10)を計算
                singleOperator("log");
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void arcsinButton_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "one";
                enzanshinyuuryoku();

                //入力されてる値に演算を適用する
                double angle = Math.Asin(valueLeft);
                valueLeft = angle * 180 / Math.PI;  //ラジアンに直す
                singleOperator("arcsin");
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void arccosButton_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "one";
                enzanshinyuuryoku();

                //入力されてる値に演算を適用する
                double angle = Math.Acos(valueLeft);
                valueLeft = angle * 180 / Math.PI;  //ラジアンに直す
                singleOperator("arccos");
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void arctanButton_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "one";
                enzanshinyuuryoku();

                //入力されてる値に演算を適用する
                double angle = Math.Atan(valueLeft);
                valueLeft = angle * 180 / Math.PI;  //ラジアンに直す
                singleOperator("arctan");
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void expButton_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "one";
                enzanshinyuuryoku();

                //入力されてる値に演算を適用する
                valueLeft = Math.Exp(valueLeft);
                singleOperator("exp");
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void powButton1_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "one";
                enzanshinyuuryoku();

                //入力されてる値に演算を適用する
                valueLeft = Math.Pow(valueLeft, 2);
                singleOperator("^2", false);
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        /*数字のボタンを押したとき*/
        private void powButton2_Click(object sender, MouseEventArgs e)
        {
            try
            {
                enzanshi1 = "x^y";
                enzanshinyuuryoku();
                textEnzanshi.Text = "^";

                NumberMem(true);
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private TwoValFunc SelectOperator(string op)
        {
            if (op == "+") return Operations.Add;
            else if (op == "-") return Operations.Sub;
            else if (op == "*") return Operations.Mul;
            else if (op == "/") return Operations.Div;
            else if (op == "x^y") return Math.Pow;
            else return Operations.Noop;
        }

        private void button1_Click(object sender, MouseEventArgs e)
        {
            InputDigit('1');
        }

        private void button2_Click(object sender, MouseEventArgs e)
        {
            InputDigit('2');
        }

        private void button3_Click(object sender, MouseEventArgs e)
        {
            InputDigit('3');
        }

        private void button4_Click(object sender, MouseEventArgs e)
        {
            InputDigit('4');
        }

        private void button5_Click(object sender, MouseEventArgs e)
        {
            InputDigit('5');
        }

        private void button6_Click(object sender, MouseEventArgs e)
        {
            InputDigit('6');
        }

        private void button7_Click(object sender, MouseEventArgs e)
        {
            InputDigit('7');
        }

        private void button8_Click(object sender, MouseEventArgs e)
        {
            InputDigit('8');
        }

        private void button9_Click(object sender, MouseEventArgs e)
        {
            InputDigit('9');
        }

        private void button0_Click(object sender, MouseEventArgs e)
        {
            InputDigit('0');
        }

        private bool convertibleBinHex(double x)
        {
            return Math.Abs(x - (long)x) <= double.Epsilon;
        }

        //この関数は使わない
        private void UpdateTotal(double value)
        {
            num = value;
            textBox1.Text = num.ToString();
            if (convertibleBinHex(value))
            {
                textBox3.Text = ((long)num).ToString("x");
                textBox2.Text = Convert.ToString((long)num, 2);
            }
            else
            {
                textBox2.Text = "-";
                textBox3.Text = "-";
            }
        }

        private void UpdateTotal(double value, string textOut)
        {
            num = value;
            textBox1.Text = textOut;
            if (convertibleBinHex(value))
            {
                textBox3.Text = ((long)num).ToString("x");
                textBox2.Text = Convert.ToString((long)num, 2);
            }
            else
            {
                textBox2.Text = "-";
                textBox3.Text = "-";
            }
        }

        private void UpdateWithTail(double value, string tail)
        {
            num = value;
            textBox1.Text = num.ToString() + tail;
            if (convertibleBinHex(value))
            {
                textBox3.Text = ((long)num).ToString("x");
                textBox2.Text = Convert.ToString((long)num, 2);
            }
            else
            {
                textBox2.Text = "-";
                textBox3.Text = "-";
            }
        }
        //数字一文字を入力
        private void InputDigit(char digit)
        {
            if (InputReset)
            {
                textBox1.Text = "";
                InputReset = false;
            }
            textBox1.Text += digit;
            if (double.TryParse(textBox1.Text, out double value))
            {
                InOutNumber = value;
            }
            else
            {
                InOutNumber = double.NaN;
            }
        }

        //マイナス(符号)を入力
        private void InputMinus()
        {
            if (InputReset)
            {
                textBox1.Text = "";
                InputReset = false;
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "-";
                return;
            }
            else if (textBox1.Text.FirstOrDefault() == '-')
            {
                textBox1.Text = textBox1.Text.Remove(0, 1);
            }
            else
            {
                textBox1.Text = "-" + textBox1.Text;
            }
            if (textBox1.Text.LastOrDefault() != '.')
            {
                if (double.TryParse(textBox1.Text, out double value))
                {
                    InOutNumber = value;
                }
                else
                {
                    InOutNumber = double.NaN;
                }
            }
        }

        //小数点を入力
        private void InputDot()
        {
            if (InputReset)
            {
                textBox1.Text = "";
                InputReset = false;
            }
            if (textBox1.Text.LastIndexOf('.') == -1)
            {
                textBox1.Text += ".";
            }
        }

        //1文字消去
        private void DeleteOne()
        {
            if (InputReset)
            {
                textBox1.Text = "";
                InputReset = false;
            }
            if (textBox1.Text != "") textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            if (textBox1.Text == "-") UpdateTotal(0, "-");
            else if (textBox1.Text == "") InOutNumber = 0;
            else if (textBox1.Text.LastOrDefault() != '.')
            {
                if (double.TryParse(textBox1.Text, out double value))
                {
                    InOutNumber = value;
                }
                else
                {
                    InOutNumber = double.NaN;
                }
            }
            else
            {
                if (double.TryParse(textBox1.Text.Remove(textBox1.Text.Length - 1), out double value))
                {
                    UpdateWithTail(value, ".");
                }
                else
                {
                    InOutNumber = double.NaN;
                }
            }
        }

        //全消去
        private void DeleteAll()
        {
            textBox1.Text = "";
            InOutNumber = 0;
        }

        //全リセット
        private void ResetAll()
        {
            InOutNumber = 0;
            Operate = Operations.Noop;
            OperatorSettingFlag = true;
            textRight.Text = "";
            textLeft.Text = "";
            textEnzanshi.Text = "";
            valueLeft = 0;
        }
        //押されたキー判定と入力された数字を保存
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                char add_char;
                switch (e.KeyData)
                {
                    case Keys.D0:
                        add_char = '0';
                        break;
                    case Keys.D1:
                        add_char = '1';
                        break;
                    case Keys.D2:
                        add_char = '2';
                        break;
                    case Keys.D3:
                        add_char = '3';
                        break;
                    case Keys.D4:
                        add_char = '4';
                        break;
                    case Keys.D5:
                        add_char = '5';
                        break;
                    case Keys.D6:
                        add_char = '6';
                        break;
                    case Keys.D7:
                        add_char = '7';
                        break;
                    case Keys.D8:
                        add_char = '8';
                        break;
                    case Keys.D9:
                        add_char = '9';
                        break;
                    case Keys.Back:
                        add_char = 'r';
                        break;
                    case Keys.Decimal:
                        add_char = '.';
                        break;
                    case Keys.Delete:
                        add_char = 'd';
                        break;
                    case Keys.Escape:
                        ResetAll();
                        add_char = '\0';
                        break;
                    default:
                        add_char = '\0';
                        break;
                }
                if (add_char == 'r') DeleteOne();
                else if (add_char == 'd') DeleteAll();
                else if (add_char != '\0')
                {
                    InputDigit(add_char);
                }
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '.') InputDot();
                else if (e.KeyChar == '-') InputMinus();
                else if (e.KeyChar == '+') plusButton_Click(null, null);
                else if (e.KeyChar == '*') button14_Click(null, null);
                else if (e.KeyChar == '/') divideButton_Click(null, null);
                else if (e.KeyChar == '^') powButton2_Click(null, null);
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

        private void jikkouButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (OperatorSettingFlag) valueRight = InOutNumber; //2つめの値を内部変数に格納
                OperatorSettingFlag = false;


                NumberMem(false);

                //演算子の判定と計算を行う
                InOutNumber = Operate(valueLeft, valueRight);
                valueLeft = InOutNumber;
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }

#pragma warning restore IDE1006
        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) jikkouButton_Click(null, null);
            }
            catch (Exception ex)
            {
                UnexpectedError(ex);
            }
        }
    }
}
