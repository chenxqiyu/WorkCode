using Microsoft.WindowsAPICodePack.DirectX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dx2D
{
    public class clsDirect2DSample
    {
        //D2D工厂对象，ID2D1Factory接口。
        private D2DFactory _d2dFactory;
        //渲染窗口，ID2D1HwndRenderTarget接口。
        private RenderTarget _renderTarget;

        //构造函数
        public clsDirect2DSample()
        {
            //创建一个D2D工厂对象
            _d2dFactory = D2DFactory.CreateFactory();

        }

        public void CreateDeviceResource(Control Target)
        {
            //如果_renderTarget没有初始化
            if (_renderTarget == null)
            {
                //初始化，在_d2dFactory创建渲染缓冲区并与Target绑定
                _renderTarget = _d2dFactory.CreateHwndRenderTarget(
                       new RenderTargetProperties(),
                       new HwndRenderTargetProperties(
                           Target.Handle,
                           new SizeU((uint)Target.Width, (uint)Target.Height),
                           PresentOptions.None
                           )
                           );
            }
        }

        public void Render()
        {
            if (_renderTarget != null)
            {
                //开始绘制
                _renderTarget.BeginDraw();

                Random ran = new Random();
                //椭圆
                Ellipse E = new Ellipse(new Point2F(ran.Next(100), ran.Next(100)), ran.Next(100), ran.Next(100));
                //定义一个画刷
                SolidColorBrush B = _renderTarget.CreateSolidColorBrush(
                        new Microsoft.WindowsAPICodePack.DirectX.Direct2D1.ColorF(0, 1, 0));


                //将椭圆绘制在渲染缓冲区

                //  _renderTarget.DrawEllipse(E, B, 5);

                _renderTarget.DrawLine(new Point2F(ran.Next(1000), ran.Next(1000)), new Point2F(ran.Next(1000), ran.Next(1000)), B, 1);

                //结束绘制

                _renderTarget.EndDraw();
            }
        }
    }
}
