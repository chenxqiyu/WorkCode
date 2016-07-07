using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameView
{
    class Son : Father, Interface
    {
        public Son()
        {
            // this.Home = "GD";


        }
        public Son(string y)
        {
            // this.Home = "GD";
            MessageBox.Show(y);

        }
        public void Run()
        {
            MessageBox.Show("Son");
        }

        public void OK()
        {
            base.OK();
            base.Run();
        }


    }
}
