﻿using System;
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
        /// 
        /// </summary>
        /// <param name="devName"></param>
        public SmplUsngForm(string devName)
        {
            InitializeComponent();           
            AddUsrControl_NoAutoFormD(this.DevPanel, devName);
        }
        /// <summary>
        /// 
        /// </summary>
        public SmplUsngForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Add UserControl into the panel of the sample form
        /// 适用需要手动打开调试界面，程式先不加载
        /// </summary>
        /// <param name="p">is a pannel</param>
        /// <param name="devName">is the UserControl_UI.DeviceName.Text</param>
        public void AddUsrControl_NoAutoFormD(Panel p,string devName)
        {
            AddUsrControl(p, devName);
        }
        /// <summary>
        /// Add UserControl into the panel of the sample form
        /// 适用不需要手动打开调试界面，程式自动加载
        /// </summary>
        /// <param name="p"></param>
        /// <param name="devName"></param>
        public void AddUsrControl(Panel p, string devName)
        {
            UserControl_UI control = new UserControl_UI(devName); //;//实例化一个对象
            control.Dock = DockStyle.Fill;
            control.BackColor = Color.White;
            control.BorderStyle = BorderStyle.FixedSingle;
            p.Controls.Add(control);//向controls集合（Panel）增加一个控件时，它会立即出现在窗体上 
        }


    }
}
