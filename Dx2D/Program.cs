using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
namespace Dx2D
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            using (Form1 frm = new Form1())
            {

                //if (!frm.InitializeGraphics()) // 初始化 Direct3D
                //{
                //    MessageBox.Show("不能初始化 Direct3D.程序将退出.");
                //    return;
                //}
                frm.Show();

                // While the form is still valid, render and process messages
                while (frm.Created)
                {
                    frm.Render();
                  //  Thread.Sleep(1000);
                    Application.DoEvents(); //处理当前在消息队列中的所有 Windows 消息
                   
                }
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
