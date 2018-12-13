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
    public partial class DeviceUI : Form
    {
        //public Hao_DIO_32.EMoudle IOcard;
        public UserControl_UI UC_UIInstance;

        public DeviceUI()
        {
            InitializeComponent();

            UserControl c1 = UC_UIInstance;
            CreateMDIControl(c1);

        }
        private UserControl uc = null;
        private void CreateMDIControl(UserControl ucBase)
        {
            if (uc != null)
            {
                uc.Dispose();
                //uc.Close();
            }
            uc = ucBase;
            try
            {

                ucBase.Dock = DockStyle.Fill;
                this.DevPanel.Controls.Add(ucBase);
                ucBase.BackColor = Color.White;
                ucBase.Left = 5;// (pl.Width - DeviceUI.Width) / 2;
                ucBase.Top = 5;// (pl.Height - DeviceUI.Height) / 2;
                ucBase.BorderStyle = BorderStyle.FixedSingle;
                ucBase.Show();
            }
            catch 
            { }

        }

        #region "加载用户控件"
        public class cPanel : Panel
        {
            public object Obj = null;
        }
        System.Collections.Hashtable Tab_Global = new System.Collections.Hashtable();
        public cPanel UsingExtendLibInternal1(object hardware)
        {
            cPanel pl = new cPanel() { Dock = DockStyle.Fill };
            try
            {
                pl.Obj = hardware;
                Type Ts = hardware.GetType();
                try
                {
                    Ts.GetField("GlobalTable").SetValue(hardware, Tab_Global);
                }
                catch { }
                try
                {
                    Ts.GetProperty("GlobalTable").SetValue(hardware, Tab_Global, null);
                }
                catch { }
                string DisMouName;
                DisMouName = hardware.GetType().ToString();
                DisMouName = DisMouName.Substring(0, DisMouName.IndexOf("."));
                try
                {
                    UserControl DeviceUI = Ts.GetField("DeviceUI").GetValue(hardware) as UserControl;
                    DeviceUI.BackColor = Color.White;
                    DeviceUI.Left = 5;// (pl.Width - DeviceUI.Width) / 2;
                    DeviceUI.Top = 5;// (pl.Height - DeviceUI.Height) / 2;
                    DeviceUI.BorderStyle = BorderStyle.FixedSingle;
                    if (DeviceUI != null) { pl.Controls.Add(DeviceUI); }
                }
                catch { }
                try
                {
                    //Form CustomForm = Ts.GetProperty("CustomForm").GetValue(hardware,null) as Form;
                    //if (CustomForm != null) { pl.CusFrm = CustomForm; }
                }
                catch { }
                try
                {
                    Ts.GetProperty("MoudleConString").SetValue(hardware, DisMouName, null);
                }
                catch { }
            }
            catch { }
            return pl;
        }
        #endregion

    }
}
