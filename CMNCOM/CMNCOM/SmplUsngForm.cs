using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMNCOM
{
    /// <summary>
    /// This is a Form of Sample using this dll
    /// </summary>
    public partial class SmplUsngForm : Form
    {

        /// <summary>
        /// 初始化
        /// </summary>
        public SmplUsngForm()
        {
            InitializeComponent();
            AddUsrControl(this.DevPanel,"PSP-603");
        }

        /// <summary>
        /// Add UserControl into the panel of the sample form
        /// </summary>
        /// <param name="p">is a pannel</param>
        /// <param name="devName">is the UserControl_UI.DeviceName.Text</param>
        public void AddUsrControl(Panel p,string devName)
        {
            UserControl_UI control = new UserControl_UI(devName); //;//实例化一个对象
            control.Dock = DockStyle.Fill;
            control.BackColor = Color.White;
            control.BorderStyle = BorderStyle.FixedSingle;
            p.Controls.Add(control);//向controls集合（Panel）增加一个控件时，它会立即出现在窗体上            
        }

      
    }
}
