using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SpEyeCOM
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SmplUsngForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public SmplUsngForm()
        {
            InitializeComponent();
            AddUsrControl(panel1);
        }

        /// <summary>
        /// Add UserControl into the panel of the sample form
        /// </summary>
        /// <param name="p">is a pannel</param>
        public void AddUsrControl(Panel p)
        {
            UserControl_UI control = new UserControl_UI(); //;//实例化一个对象
            control.Dock = DockStyle.Fill;
            control.BackColor = Color.White;
            control.BorderStyle = BorderStyle.FixedSingle;
            p.Controls.Add(control);//向controls集合（Panel）增加一个控件时，它会立即出现在窗体上            
        }

        private void SmplUsngForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserControl_UI control = new UserControl_UI();
            control.CloseEXE();
        }

        private void SmplUsngForm_Load(object sender, EventArgs e)
        {
            UserControl_UI control = new UserControl_UI();
            control.CloseEXE();
        }
    }
}
