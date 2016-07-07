using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LianZhao
{

    public partial class Form1 : Form
    {
        private string baseCode = string.Empty;

        private string 上 = string.Empty;
        private string 下 = string.Empty;
        private string 左 = string.Empty;
        private string 右 = string.Empty;

        private string 左上 = string.Empty;
        private string 左下 = string.Empty;
        private string 右上 = string.Empty;
        private string 右下 = string.Empty;

        private string A = string.Empty;
        private string B = string.Empty;
        private string C = string.Empty;
        private string D = string.Empty;

        private string DelayOne = "";
        private string DelayTwo = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DelayOne = textBox7.Text;
            DelayTwo = textBox8.Text;

            if (!String.IsNullOrWhiteSpace(textBox2.Text))
            {
                string 左1 = Asc(textBoxAA.Text.ToUpper()).ToString();
                左 = "dm.KeyDown " + 左1 + Environment.NewLine + "dm.Delay " + DelayOne + Environment.NewLine + "dm.KeyUp " + 左1 + Environment.NewLine; ;

                string 右1 = Asc(textBoxDD.Text.ToUpper()).ToString();
                右 = "dm.KeyDown " + 右1 + Environment.NewLine + "dm.Delay " + DelayOne + Environment.NewLine + "dm.KeyUp " + 右1 + Environment.NewLine; ;

                string 上1 = Asc(textBoxWW.Text.ToUpper()).ToString();
                上 = "dm.KeyDown " + 上1 + Environment.NewLine + "dm.Delay " + DelayOne + Environment.NewLine + "dm.KeyUp " + 上1 + Environment.NewLine; ;

                string 下1 = Asc(textBoxSS.Text.ToUpper()).ToString();
                下 = "dm.KeyDown " + 下1 + Environment.NewLine + "dm.Delay " + DelayOne + Environment.NewLine + "dm.KeyUp " + 下1 + Environment.NewLine; ;

                左下 = "dm.KeyDown " + 左1 + Environment.NewLine + "dm.KeyDown " + 下1 + Environment.NewLine + "dm.Delay " + DelayOne + Environment.NewLine + "dm.KeyUp " + 左1 + Environment.NewLine + "dm.KeyUp " + 下1 + Environment.NewLine;

                左上 = "dm.KeyDown " + 左1 + Environment.NewLine + "dm.KeyDown " + 上1 + Environment.NewLine + "dm.Delay " + DelayOne + Environment.NewLine + "dm.KeyUp " + 左1 + Environment.NewLine + "dm.KeyUp " + 上1 + Environment.NewLine;

                右下 = "dm.KeyDown " + 右1 + Environment.NewLine + "dm.KeyDown " + 下1 + Environment.NewLine + "dm.Delay " + DelayOne + Environment.NewLine + "dm.KeyUp " + 右1 + Environment.NewLine + "dm.KeyUp " + 下1 + Environment.NewLine;

                右上 = "dm.KeyDown " + 右1 + Environment.NewLine + "dm.KeyDown " + 上1 + Environment.NewLine + "dm.Delay " + DelayOne + Environment.NewLine + "dm.KeyUp " + 右1 + Environment.NewLine + "dm.KeyUp " + 上1 + Environment.NewLine;

                A = Asc(textBoxA.Text.ToUpper()).ToString();
                A = "dm.KeyDown " + A + Environment.NewLine + "dm.Delay " + DelayOne + Environment.NewLine + "dm.KeyUp " + A + Environment.NewLine;

                B = Asc(textBoxB.Text.ToUpper()).ToString();
                B = "dm.KeyDown " + B + Environment.NewLine + "dm.Delay " + DelayOne + Environment.NewLine + "dm.KeyUp " + B + Environment.NewLine;

                C = Asc(textBoxC.Text.ToUpper()).ToString();
                C = "dm.KeyDown " + C + Environment.NewLine + "dm.Delay " + DelayOne + Environment.NewLine + "dm.KeyUp " + C + Environment.NewLine;

                D = Asc(textBoxD.Text.ToUpper()).ToString();
                D = "dm.KeyDown " + D + Environment.NewLine + "dm.Delay " + DelayOne + Environment.NewLine + "dm.KeyUp " + D + Environment.NewLine;

                string code = string.Empty;



                code += "Sub " + textBox1.Text + Environment.NewLine;

                string rc = textBox2.Text;

                char[] cha = rc.ToCharArray();
                rc = string.Empty;
                for (int i = 0; i < cha.Length; i++)
                {
                    if (i == cha.Length - 1)
                    {
                        rc += cha[i];
                    }
                    else
                    {
                        rc += cha[i] + ".";
                    }

                }


                string[] P = rc.Split('.');


                string cc = string.Empty;

                string[] o = rc.Split('.');
                string c = string.Empty;


                for (int i = 0; i < o.Length; i++)
                {
                    string rechange = string.Empty;
                    if (o[i].Equals("6"))
                    {
                        rechange = "4";
                        if (i == o.Length - 1)
                        {
                            c += rechange;
                        }
                        else
                        {
                            c += rechange + ".";
                        }
                    }
                    else if (o[i].Equals("4"))
                    {
                        rechange = "6";
                        if (o[i] == o[o.Length - 1])
                        {
                            c += rechange;
                        }
                        else
                        {
                            c += rechange + ".";
                        }
                    }
                    else if (o[i].Equals("1"))
                    {
                        rechange = "3";
                        if (o[i] == o[o.Length - 1])
                        {
                            c += rechange;
                        }
                        else
                        {
                            c += rechange + ".";
                        }
                    }
                    else if (o[i].Equals("3"))
                    {
                        rechange = "1";
                        if (o[i] == o[o.Length - 1])
                        {
                            c += rechange;
                        }
                        else
                        {
                            c += rechange + ".";
                        }
                    }
                    else if (o[i].Equals("7"))
                    {
                        rechange = "9";
                        if (o[i] == o[o.Length - 1])
                        {
                            c += rechange;
                        }
                        else
                        {
                            c += rechange + ".";
                        }
                    }
                    else if (o[i].Equals("9"))
                    {
                        rechange = "7";
                        if (o[i] == o[o.Length - 1])
                        {
                            c += rechange;
                        }
                        else
                        {
                            c += rechange + ".";
                        }
                    }
                    else
                    {
                        if (i == o.Length - 1)
                        {
                            c += o[i];
                        }
                        else
                        {
                            c += o[i] + ".";
                        }

                    }
                }

                cc = c;

                string[] RP = cc.Split('.');

                int mid = P.Length / 2;
                string M = string.Empty;

                for (int i = 0; i < P.Length; i++)
                {
                    switch (P[i].ToUpper())
                    {
                        case "1":
                            if (i == mid)
                            {
                                code += 左下.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 左下 + Environment.NewLine;
                            break;
                        case "2":
                            if (i == mid)
                            {
                                code += 下.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 下 + Environment.NewLine;
                            break;
                        case "3":
                            if (i == mid)
                            {
                                code += 右下.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 右下 + Environment.NewLine;
                            break;
                        case "4":
                            if (i == mid)
                            {
                                code += 左.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 左 + Environment.NewLine;
                            break;
                        case "5":
                            break;
                        case "6":
                            if (i == mid)
                            {
                                code += 右.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 右 + Environment.NewLine;

                            break;
                        case "7":
                            if (i == mid)
                            {
                                code += 左上.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 左上 + Environment.NewLine;

                            break;
                        case "8":
                            if (i == mid)
                            {
                                code += 上.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 上 + Environment.NewLine;

                            break;
                        case "9":
                            if (i == mid)
                            {
                                code += 右上.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 右上 + Environment.NewLine;

                            break;
                        case "J":
                            code += A + Environment.NewLine;

                            break;
                        case "K":
                            code += B + Environment.NewLine;

                            break;
                        case "L":
                            code += C + Environment.NewLine;

                            break;
                        case "I":
                            code += D + Environment.NewLine;

                            break;
                        default:
                            break;
                    }

                }
                code += "End Sub" + Environment.NewLine;
                textBox3.Text = code;

                code = string.Empty;
                code += "Sub " + textBox1.Text + Environment.NewLine;

                for (int i = 0; i < RP.Length; i++)
                {
                    switch (RP[i].ToUpper())
                    {
                        case "1":
                            if (i == mid)
                            {
                                code += 左下.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 左下 + Environment.NewLine;
                            break;
                        case "2":
                            if (i == mid)
                            {
                                code += 下.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 下 + Environment.NewLine;
                            break;
                        case "3":
                            if (i == mid)
                            {
                                code += 右下.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 右下 + Environment.NewLine;
                            break;
                        case "4":
                            if (i == mid)
                            {
                                code += 左.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 左 + Environment.NewLine;
                            break;
                        case "5":
                            break;
                        case "6":
                            if (i == mid)
                            {
                                code += 右.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 右 + Environment.NewLine;

                            break;
                        case "7":
                            if (i == mid)
                            {
                                code += 左上.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 左上 + Environment.NewLine;

                            break;
                        case "8":
                            if (i == mid)
                            {
                                code += 上.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 上 + Environment.NewLine;

                            break;
                        case "9":
                            if (i == mid)
                            {
                                code += 右上.Replace(DelayOne, DelayTwo) + Environment.NewLine;
                            }
                            else
                                code += 右上 + Environment.NewLine;

                            break;
                        case "J":
                            code += A + Environment.NewLine;

                            break;
                        case "K":
                            code += B + Environment.NewLine;

                            break;
                        case "L":
                            code += C + Environment.NewLine;

                            break;
                        case "I":
                            code += D + Environment.NewLine;

                            break;
                        default:
                            break;
                    }
                }
                code += "End Sub" + Environment.NewLine;
                textBox4.Text = code;


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";


            baseCode += "key = WaitKey" + Environment.NewLine;
        }
        public int Asc(string word)
        {
            word = word.Trim();
            if (word.Length == 1)
            {
                ASCIIEncoding asc = new ASCIIEncoding();
                return asc.GetBytes(word)[0];
            }
            else
            {
                return 0;
            }
        }
        public char rAsc(string word)
        {
            int r;
            char c = '0';

            if (Int32.TryParse(word, out  r))
            {
                c = (char)r;
                return c;
            }
            else
            {
                return '0';
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Text = Asc(textBox5.Text.ToUpper()).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string code = string.Empty;
            code += "Plugin.RegDll.Reg \"C:\\tz_kof\\dm.dll";
            code += "set dm = createobject(\"dm.dmsoft\")";
            code += "Call dm.SetPath(\"C:\tz_kof\")";
            code += "Call dm.SetShowErrorMsg(0)";
            code += "hwnd = Plugin.Window.Foreground()";
            code += "Plugin.RegDll.Reg \"C:\\tz_kof\\dm.dll";
            code += "Do key = WaitKey If Key = 70 Then  Call Test End If Loop";

            Clipboard.SetText(code);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {




        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Text = rAsc(textBox6.Text.ToUpper()).ToString();
            }
        }
    }
}
