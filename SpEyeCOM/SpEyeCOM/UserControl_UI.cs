using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using INIFileReadWrite;
using System.Threading;
using System.Diagnostics;

namespace SpEyeCOM
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UserControl_UI : UserControl
    {
        
        /// <summary>
        /// 程序集名字
        /// </summary>
        public string MoudleConnString = Assembly.GetExecutingAssembly().GetName().Name;
        /// <summary>
        /// 程序集名字+后缀
        /// </summary>
        public string MoudleConnString_Ext = Path.GetFileName(Assembly.GetExecutingAssembly().Location);
        

        private string EXEName, EXEPath, EXETittle, EXEConfigFullName;

        private static System.Diagnostics.Process p;
        //private bool HasExited = false;

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        private static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;

        /// <summary>
        /// 
        /// </summary>
        public UserControl_UI()
        {
            InitializeComponent();
            Assembly asm = Assembly.GetExecutingAssembly();
            AssemblyFileVersionAttribute asmfver = (AssemblyFileVersionAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyFileVersionAttribute));
            UC_Tittle.Text = MoudleConnString + " Ver " + asmfver.Version;
            CMNCOM.SmplUsngForm FormInstance = new CMNCOM.SmplUsngForm();
            FormInstance.AddUsrControl(panel1, "SpEye");
            EXEName = "二维码.exe";
            EXEPath = System.Windows.Forms.Application.StartupPath + @"\CameraBarcode\";                   
            EXETittle = "二维码扫描V1.5.0.1003 大西电子仪器(昆山)有限公司";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenEXE();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CloseEXE();
        }   
        private void button3_Click(object sender, EventArgs e)
        {
            MiniSizeEXE();
        }

        private void p_Exited(object sender, EventArgs e)
        {
            Console.WriteLine(p.StartInfo.FileName + " has exited");
            //HasExited = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BarcodeRead result: " + BarcodeRead());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("qBarcodeRead result: " + qBarcodeRead());
        }

        /// <summary>
        /// 
        /// </summary>
        public void OpenEXE()
        {
            if (p == null)
            {
                p = new System.Diagnostics.Process();
                p.StartInfo.FileName = EXEName;
                p.StartInfo.WorkingDirectory = EXEPath;
                if (!File.Exists(EXEPath + EXEName)) { MessageBox.Show("Not exist " + EXEPath + EXEName); return; }
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                p.EnableRaisingEvents = true;
                p.Exited += new EventHandler(p_Exited);
                EXEConfigFullName = EXEPath + @"config\barcodeconfig.ini";
                OperateIniFile.WriteIniData("setup", "bmpfile", EXEPath + "bmp", EXEConfigFullName);
                OperateIniFile.WriteIniData("setup", "logfile", EXEPath + "log", EXEConfigFullName);
                p.Start();
                //HasExited = false;
            }
            else
            {
                IntPtr handle;
                if (!CHKWINExist(EXETittle, out handle))
                {
                    p.Start();
                    //HasExited = false;
                }
            }
        }       

        /// <summary>
        /// 
        /// </summary>
        public void CloseEXE()
        {
            IntPtr handle;
            if (CHKWINExist(EXETittle, out handle))
            {
                try
                {
                    if (p != null)
                    {
                        p.CloseMainWindow();
                        p.WaitForExit(5000);    //设置最多等待5秒（处理类似用于需要用户确定关闭的对话框未关闭的情况）
                        p.Close();
                    }
                    else
                    {
                        Process[] myProcesses = System.Diagnostics.Process.GetProcesses();
                        foreach (Process myProcess in myProcesses)
                        {
                            if (myProcess.ProcessName == EXEName.Substring(0, EXEName.Length - 4)) myProcess.Kill();//强制关闭该程序
                        }

                    }
                    
                }
                catch { }             
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void MiniSizeEXE()
        {

            IntPtr handle;
            if (!CHKWINExist(EXETittle, out handle))
            {
                MessageBox.Show("该窗口: " + EXETittle + " 不存在");
            }
            else
            {
                PostMessage(handle, WM_SYSCOMMAND, SC_MINIMIZE, 0);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="WinTittle"></param>
        /// <param name="handle">out param</param>
        /// <returns></returns>
        public bool CHKWINExist(string WinTittle,out IntPtr handle)
        {
            handle = FindWindow(null, WinTittle);
            if (handle == IntPtr.Zero)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BarcodeRead()
        {

            string[] dirs = Directory.GetFiles(EXEPath + @"log\", "barcode_*.log");
            foreach (string dir in dirs)
            {
                //Console.WriteLine(dir);
                try { File.Delete(dir); } catch { }               
            }

            CMNCOM.EMoudle EMoudleInstance = new CMNCOM.EMoudle("SpEye");
            return EMoudleInstance.SendReciveMsg(false, "0", false, 5);
        }
        /// <summary>
        /// With EXE Open+MiniSize+Read is a Quick BarcodeRead
        /// </summary>
        /// <returns></returns>
        public string qBarcodeRead()
        {

            IntPtr handle;
            if (!CHKWINExist(EXETittle, out handle))
            {
                OpenEXE();
                Thread.Sleep(3000);//Sleep to wait for Camera Load
            } 
            MiniSizeEXE();
            string str=BarcodeRead();
            return str;

        }
       
    }
}
