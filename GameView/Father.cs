using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameView
{
    class Father : Interface
    {
        private int age { set; get; }
        public Interface inf { set; get; }
        public string Home { set; get; }

        public Father()
        {
            this.Home = "GX";
        }

        public void Run()
        {
            MessageBox.Show("Father");
      
        }

        public void OK()
        {
            inf.Run();
            MessageBox.Show("OK-Father");
        }
        int y = 4;


        public int x
        {
            get
            {
                return y;
            }
            set
            {
                y = 4;
            }
        }


        public Son s
        {
            get
            {
                return new Son(y.ToString());
            }
            set
            {
                Son ss=new Son(y.ToString());
            }
        }
    }
}
