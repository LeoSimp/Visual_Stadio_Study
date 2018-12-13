using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Reflection;

namespace CMNCOM
{
    /// <summary>
    /// UserControl UI, for user config the setting
    /// </summary>
    public partial class UserControl_UI : UserControl
    {
        //internal EMoudle EMoudleInstance = new EMoudle();
        internal UserSerialPort ComDevice = new UserSerialPort();
        /// <summary>
        /// 程序集名字
        /// </summary>
        public string MoudleConnString = Assembly.GetExecutingAssembly().GetName().Name;
        /// <summary>
        /// 程序集名字+后缀
        /// </summary>
        public string MoudleConnString_Ext = Path.GetFileName(Assembly.GetExecutingAssembly().Location);
        
        /// <summary>
        /// 初始化
        /// </summary>
        public UserControl_UI()
        {
            InitializeComponent();
            this.drpBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.drpParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.drpDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6"});
            this.drpStopBits.Items.AddRange(new object[] {
            "1",
            "2"});
            drpBaudRate.SelectedIndex = drpBaudRate.Items.IndexOf("115200");
            drpParity.SelectedIndex = drpParity.Items.IndexOf("None");
            drpDataBits.SelectedIndex = drpDataBits.Items.IndexOf("8");
            drpStopBits.SelectedIndex = drpStopBits.Items.IndexOf("1");
            drpComList.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());

           
            drpComList.Items.AddRange(SerialPort.GetPortNames());
            if (drpComList.Items.Count > 0)
            {
                drpComList.SelectedIndex = 0;
            }
            //User_Load();
        }

       
        private void SelectOne(ComboBox cmb, string str)
        {
            for (int j = 0; j < cmb.Items.Count; j++)
            {
                if (cmb.Items[j].ToString() == str)
                {
                    cmb.SelectedIndex = j;
                    return;
                }
            }
        }

        private void CheckDeviceLoop()
        {
            while (true)
            {
                Thread.Sleep(2000);
                try
                {
                    string[] range = SerialPort.GetPortNames();
                    List<string> tempList = new List<string>(range);
                    for (int j = 0; j < range.Length; j++)
                    {
                        if (!this.drpComList.Items.Contains(range[j]))
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                this.drpComList.Items.Add(range[j]);
                            }));
                        }
                    }
                    for (int j = this.drpComList.Items.Count - 1; j >= 0; j--)
                    {
                        if (!tempList.Contains(drpComList.Items[j].ToString()))
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                drpComList.Items.RemoveAt(j);
                            }));
                        }
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// 加载配置文件并初始化及打开COM,只在EMoudle中被调用
        /// </summary>
        internal void User_Load()
        {
            try
            {
                string path = System.Windows.Forms.Application.StartupPath + @"\MoudleSettingFiles\";
                tools.pcheck(path);
                path += MoudleConnString + ".mset";

                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312")))
                    {
                        ComDevice.DeviceDiscription = sr.ReadLine();
                        ComDevice.UserPortName = sr.ReadLine();
                        ComDevice.userBaudRate = sr.ReadLine();
                        ComDevice.userParity = sr.ReadLine();
                        ComDevice.userDataBits = sr.ReadLine();
                        ComDevice.userStopBits = sr.ReadLine();                                           
                    }
                }
                else
                {
                    ComDevice.DeviceDiscription = "NewScanner";
                    ComDevice.UserPortName = "COM1";
                    ComDevice.userBaudRate = "9600";
                    ComDevice.userParity = "None";
                    ComDevice.userDataBits = "8";
                    ComDevice.userStopBits = "1";
                   
                }
                //~~~~~~~~~~
                this.DeviceName.Text = ComDevice.DeviceDiscription;
                SelectOne(drpComList, ComDevice.UserPortName);
                SelectOne(drpBaudRate, ComDevice.userBaudRate);
                SelectOne(drpParity, ComDevice.userParity);
                SelectOne(drpDataBits, ComDevice.userDataBits);
                SelectOne(drpStopBits, ComDevice.userStopBits);
                ComDevice.Open(); 
               
            }            
            catch (Exception ex)
            {
                string DialogTittle = MoudleConnString_Ext + " - " + this.DeviceName.Text;
                MessageBox.Show("User_Load初始化失败:" + ex.ToString(), DialogTittle);
            }
            Thread t2 = new Thread(delegate () {
                CheckDeviceLoop();
            });
            t2.IsBackground = true;
            t2.Start();
        } 

        /// <summary>
        /// 保存配置按钮，一次保存下次自动加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存配置,新配置将在下次软件启动时生效？", "Tip:", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    ComDevice.Close();
                    ComDevice.PortName = drpComList.SelectedItem.ToString();
                    ComDevice.Open();
                }
                catch { }
                string path = System.Windows.Forms.Application.StartupPath + @"\MoudleSettingFiles\";
                tools.pcheck(path);
                path += MoudleConnString + ".mset";
                using (StreamWriter sr = new StreamWriter(path, false, System.Text.Encoding.GetEncoding("GB2312")))
                {
                    string rst = "";
                    rst += DeviceName.Text.Replace("\r", "").Replace("\n", "") + "\r\n";
                    rst += drpComList.Text + "\r\n";
                    rst += drpBaudRate.Text + "\r\n";
                    rst += drpParity.Text + "\r\n";
                    rst += drpDataBits.Text + "\r\n";
                    rst += drpStopBits.Text + "\r\n";
                    sr.Write(rst);
                }
               
            }
        }
        
        /// <summary>
        /// 调试设备按钮，打开调试窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            FormDiag formDiag=null;
            try
            {
                if (formDiag != null) formDiag.Dispose();
                formDiag = new FormDiag();
                //formDiag.StartPosition = FormStartPosition.Manual;
                //先定义窗口名字parentForm，然后[parentForm.Text
                //int m_r = Application.OpenForms[this.Parent.Text].Right;               
                //int m_t = Application.OpenForms].Top;
                //formDiag.Location = new Point(m_r , m_t);
                formDiag.StartPosition = FormStartPosition.CenterParent;               
                formDiag.Show(this);
               
                formDiag.Text = button3.Text+"_"+ DeviceName.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }

    /// <summary>
    /// 用户输入配置SerialPort的元素
    /// </summary>
    public class UserSerialPort : SerialPort
    {
        List<string> PortList = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        public UserSerialPort()
        {
            PortList.AddRange(SerialPort.GetPortNames());
        }
        /// <summary>
        /// 声明设备描述
        /// </summary>
        public string DeviceDiscription;     
        /// <summary>
        /// 
        /// </summary>
        public string UserPortName
        {
            get
            {
                return this.PortName;
            }
            set
            {
                if (PortList.Contains(value))
                { this.PortName = value; }
                else
                {
                    //MessageBox.Show("本地计算机不存在端口:" + value);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userBaudRate
        {
            get
            {
                return this.BaudRate.ToString();
            }
            set
            {
                this.BaudRate = int.Parse(value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userParity
        {
            get
            {
                string rst = "None";
                switch (this.Parity)
                {
                    case System.IO.Ports.Parity.Even:
                        rst = "Even"; break;
                    case System.IO.Ports.Parity.Mark:
                        rst = "Mark"; break;
                    case System.IO.Ports.Parity.None:
                        rst = "None"; break;
                    case System.IO.Ports.Parity.Odd:
                        rst = "Odd"; break;
                    case System.IO.Ports.Parity.Space:
                        rst = "Space"; break;
                }
                return rst;
            }
            set
            {
                switch (value)
                {
                    case "Even":
                        this.Parity = System.IO.Ports.Parity.Even; break;
                    case "Mark":
                        this.Parity = System.IO.Ports.Parity.Mark; break;
                    case "None":
                        this.Parity = System.IO.Ports.Parity.None; break;
                    case "Odd":
                        this.Parity = System.IO.Ports.Parity.Odd; break;
                    case "Space":
                        this.Parity = System.IO.Ports.Parity.Space; break;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userDataBits
        {
            get
            {
                return this.DataBits.ToString();
            }
            set
            {
                this.DataBits = int.Parse(value);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userStopBits
        {
            get
            {
                string rst = "1";
                switch (this.StopBits)
                {
                    case System.IO.Ports.StopBits.One:
                        rst = "1"; break;
                    case System.IO.Ports.StopBits.Two:
                        rst = "2"; break;
                }
                return rst;
            }
            set
            {
                switch (value)
                {
                    case "1":
                        this.StopBits = System.IO.Ports.StopBits.One; break;
                    case "2":
                        this.StopBits = System.IO.Ports.StopBits.Two; break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] hexStringToByte(String hex)
        {
            hex = hex.ToUpper();
            int len = (hex.Length / 2);
            byte[] result = new byte[len];
            char[] achar = hex.ToCharArray();
            for (int i = 0; i < len; i++)
            {
                int pos = i * 2;
                result[i] = (byte)(toByte(achar[pos]) << 4 | toByte(achar[pos + 1]));
            }
            return result;
        }

        private static int toByte(char c)
        {
            byte b = (byte)"0123456789ABCDEF".IndexOf(c);
            return b;
        }
    }
}
