using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CMNCOM
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。(当为类库时就没有入口点)
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SmplUsngForm());
        }
    }
}
