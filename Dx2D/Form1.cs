using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.DirectX;
using Microsoft.WindowsAPICodePack.DirectX.Direct2D1;
using Microsoft.WindowsAPICodePack.DirectX.Graphics;

namespace Dx2D
{
    //http://www.cnblogs.com/cyjb/p/Direct2DControl.html
    //http://sharpdx.org/

    //http://blog.csdn.net/WangQingtian__Shu/article/details/45870785
    //https://github.com/aybe/Windows-API-Code-Pack-1.1
    //Paradox
    public partial class Form1 : Form
    {
        private clsDirect2DSample _D;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _D = new clsDirect2DSample();
            _D.CreateDeviceResource(this.panel1);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Render()
        {
            _D.Render();
        }
    }
}
