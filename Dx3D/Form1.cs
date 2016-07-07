using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Device = Microsoft.DirectX.Direct3D.Device;
using CreateFlags = Microsoft.DirectX.Direct3D.CreateFlags;

namespace Dx3D
{
    //unity是游戏引擎，directx是图形函数库，下面箭头表示调用关系。
    //你的程序-->Unity3D-->DirectX(GDI++、OpenGL)-->图形设备（显卡）。

    //当然，DirectX和OpenGL是等价的图形函数库，都是游戏引擎的下层调用接口，二者可替换。

    #region 使用说明

    //如果有人对这方面感兴趣不知道如何学习的话，我建议看两个文档<Managed DirectX 9图形和游戏编程简略中文文档>，<Managed DirectX 9 SDK 中文文档>。
    //另外最好下载个DirectX SDK (August 2007).rar。里面有些范例还是非常好的。下载地址自己到网上找，很多的。

    //http://www.cnblogs.com/top5/archive/2009/10/17/1584953.html
    //C:\Windows\Microsoft.NET\DirectX for Managed Code\1.0.2902.0
    //http://jingyan.baidu.com/article/bea41d439008dcb4c51be60b.html
    #endregion

    public partial class Form1 : Form
    {
        /// <summary>
        /// 设备对象，场景中所有图形对象的父对象
        /// </summary>
        private Device device = null;

        /// <summary>
        /// 坐标系四棱锥顶点缓冲
        /// </summary>
        VertexBuffer vertexBuffer = null;

        /// <summary>
        /// 此参数设置为必须，它定义了要创建的Direct3D设备的表示参数，如后台缓冲区的高度、宽度和像素格式、如何从后台缓冲区复制到前台缓存、以及屏幕显示的方式等等
        /// </summary>
        PresentParameters presentParameters = new PresentParameters();

        /// <summary>
        /// 暂停标志
        /// </summary>
        bool pause = false;

        /// <summary>
        /// 随机数，用来生成随机颜色用的
        /// </summary>
        Random rn = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化绘图环境
        /// </summary>
        /// <returns></returns>
        public bool InitializeGraphics()
        {
            try
            {
                //设置屏幕显示模式为窗口模式
                presentParameters.Windowed = true;
                //设置如何从后台缓冲区复制到前台缓冲区(SwapEffect.Discard表示缓冲区在显示后立即被舍弃,这样可以节省开销)
                presentParameters.SwapEffect = SwapEffect.Discard;
                //创建一个设备
                device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, presentParameters);


                //为设备释放订阅事件处理
                //        device.DeviceReset += new System.EventHandler(this.OnResetDevice);

                this.OnCreateDevice(device, null);
                this.OnResetDevice(device, null);
                pause = false;
                return true;
            }

            catch (ObjectDisposedException)
            {
                return false;
            }
        }

        /// <summary>
        /// 设备撤销的事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnResetDevice(object sender, EventArgs e)
        {
            Device dev = (Device)sender;
            //关闭剔除模式，使我们能看见此四棱锥的前面和后面
            dev.RenderState.CullMode = Cull.None;
            // 关闭场景里的灯光，显示顶点自己的颜色
            dev.RenderState.Lighting = false;
        }

        /// <summary>
        /// 设备创建时建立顶点缓冲
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnCreateDevice(object sender, EventArgs e)
        {
            Device dev = (Device)sender;

            //创建顶点缓冲,有个顶点
            //     vertexBuffer = new VertexBuffer(typeof(CustomVertex.PositionColored), 18, dev, 0, CustomVertex.PositionColored.Format, Pool.Default);
            //为创建顶点缓存订阅事件处理
            //     vertexBuffer.Created += new System.EventHandler(this.OnCreateVertexBuffer);

            //      this.OnCreateVertexBuffer(vertexBuffer, null);
        }

        /// <summary>
        /// 创建顶点缓存的事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnCreateVertexBuffer(object sender, EventArgs e)
        {

            VertexBuffer vb = (VertexBuffer)sender;
            CustomVertex.PositionColored[] verts = (CustomVertex.PositionColored[])vb.Lock(0, 0);

            //四棱锥原始的个点
            //Vector3 vertex1 = new Vector3(25, 0, 0);
            //Vector3 vertex2 = new Vector3(0, 0, -25);
            //Vector3 vertex3 = new Vector3(-25, 0, 0);
            //Vector3 vertex4 = new Vector3(0, 0, 25);
            //Vector3 vertex5 = new Vector3(0, 25, 0);

            //四棱锥中包含个三角形，所以要构造个点来绘制
            //verts[0].Position = vertex1;
            //verts[1].Position = vertex2;
            //verts[2].Position = vertex5;
            //verts[3].Position = vertex2;
            //verts[4].Position = vertex3;
            //verts[5].Position = vertex5;
            //verts[6].Position = vertex3;
            //verts[7].Position = vertex4;
            //verts[8].Position = vertex5;
            //verts[9].Position = vertex4;
            //verts[10].Position = vertex1;
            //verts[11].Position = vertex5;
            //verts[12].Position = vertex2;
            //verts[13].Position = vertex1;
            //verts[14].Position = vertex3;
            //verts[15].Position = vertex3;
            //verts[16].Position = vertex1;
            //verts[17].Position = vertex4;


            //给每个点赋予随机颜色
            for (int i = 0; i < 18; i++)
            {
                verts[i].Color = Color.FromArgb(SetColor(), SetColor(), SetColor()).ToArgb();

            }
            vb.Unlock();



        }

        /// <summary>
        /// 返回到之间的一个随机数，用来生成随机颜色
        /// </summary>
        /// <returns></returns>
        public int SetColor()
        {
            int number = rn.Next(256);
            return number;
        }

        /// <summary>
        /// 设置摄像机的位置
        /// </summary>
        private void SetupCamera()
        {
            //设置世界矩阵，根据系统运行时间而变化
            //device.Transform.World = Matrix.RotationAxis(new Vector3((float)Math.Cos(Environment.TickCount / 250.0f), 1, (float)Math.Sin(Environment.TickCount / 250.0f)), Environment.TickCount / 3000.0f);
            ////设置摄像机的位置，它在z轴上-50处，看着原点，y轴为正方向
            //device.Transform.View = Matrix.LookAtLH(new Vector3(0.0f, 0.0f, -50f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f));

            ////设置摄像机的视界，角度为度，看的最近为,看的最远处为.不再这个视界中的影像都不会被显示
            //device.Transform.Projection = Matrix.PerspectiveFovLH(((float)(float)Math.PI / 2), 1.0f, 10.0f, 200.0f);
        }

        /// <summary>
        /// 绘制图形
        /// </summary>
        public void Render()
        {
            if (device == null)
                return;

            if (pause)
                return;

            //背景设为绿色
            device.Clear(ClearFlags.Target, System.Drawing.Color.Blue, 1.0f, 0);
            //开始场景
            device.BeginScene();
            // 设置世界，视野和投影矩阵
            //    SetupCamera();

            // 给设备指定顶点缓存
            device.SetStreamSource(0, vertexBuffer, 0);

            //设置设备的顶点格式
            device.VertexFormat = CustomVertex.PositionColored.Format;

            //绘制图形，使用的方法为三角形列表，个数为个
            //      device.DrawPrimitives(PrimitiveType.TriangleList, 0, 6);


            //结束场景
            device.EndScene();

            //更新场景
            device.Present();
        }

        //重载OnPaint函数
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //绘制图形
            this.Render();
        }

    }
}




