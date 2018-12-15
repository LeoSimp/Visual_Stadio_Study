using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace CMNCOM
{
    /// <summary>
    /// 用于有界面引用，相对EMoudle而言是半自动引用
    /// </summary>
    public partial class FormDiag : Form
    {
        internal EMoudle EMoudleInstance;

        /// <summary>
        /// 初始化，必须指定DeviceName.Text
        /// </summary>
        public FormDiag(string devName)
        {
            EMoudleInstance = new EMoudle(devName);
            InitializeComponent();
            Conf_Load();
        }

        internal void Conf_Load()
        {
            try
            {
                string path = System.Windows.Forms.Application.StartupPath + @"\MoudleSettingFiles\";
                tools.pcheck(path);
                path += EMoudleInstance.DeviceUI.MoudleConnString + "_" + EMoudleInstance.DeviceUI.DeviceName.Text + ".cmdset";

                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312")))
                    {
                        Conf_Set(sr.ReadLine(),checkBox1,textBox1,button1);
                        Conf_Set(sr.ReadLine(), checkBox2, textBox2, button2);
                        Conf_Set(sr.ReadLine(), checkBox3, textBox3, button3);
                        Conf_Set(sr.ReadLine(), checkBox4, textBox4, button4);
                        Conf_Set(sr.ReadLine(), checkBox5, textBox5, button5);
                        Conf_Set(sr.ReadLine(), checkBox6, textBox6, button6);
                        Conf_Set(sr.ReadLine(), checkBox7, textBox7, button7);
                    }
                }           
            }
            catch
            {           
            }

        }

        private void Conf_Set(string str,CheckBox cb, TextBox tb,Button btn)
        {
            string[] rst = null;
            rst = str.Split(',');
            if (rst.Length == 3)
            {
                if (rst[0].ToUpper() == "H") { cb.Checked = true; }
                else { cb.Checked = false; }
                tb.Text = rst[1];btn.Text = rst[2];
            }
            else
            {
                cb.Checked = false; 
                tb.Text = null; btn.Text = "Send";

            }
        }

        private string Sen_Conf(CheckBox cb, TextBox tb, Button btn)
        {
            string[] rst = new string[3];string str = null;
            if (cb.Checked) { rst[0] = "H"; }
            else { rst[0] = "A"; }
            rst[1] = tb.Text;rst[2] = btn.Text;
            str = rst[0] + "," + rst[1] + "," + rst[2];
            return str;
        }

        private void FormDiag_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conf_Save();
        }
        private void Conf_Save()
        {
            try
            {
                string path = System.Windows.Forms.Application.StartupPath + @"\MoudleSettingFiles\";
                tools.pcheck(path);
                path += EMoudleInstance.DeviceUI.MoudleConnString + "_" + EMoudleInstance.DeviceUI.DeviceName.Text + ".cmdset";
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.GetEncoding("GB2312")))
                    {
                        string rst = "";
                        rst += Sen_Conf(checkBox1, textBox1, button1) + "\r\n";
                        rst += Sen_Conf(checkBox2, textBox2, button2) + "\r\n";
                        rst += Sen_Conf(checkBox3, textBox3, button3) + "\r\n";
                        rst += Sen_Conf(checkBox4, textBox4, button4) + "\r\n";
                        rst += Sen_Conf(checkBox5, textBox5, button5) + "\r\n";
                        rst += Sen_Conf(checkBox6, textBox6, button6) + "\r\n";
                        rst += Sen_Conf(checkBox7, textBox7, button7) + "\r\n";
                        sw.Write(rst);

                    }
              }
            catch
            {
            }
        }


        private void SendMsg_Click1(object sender, EventArgs e)
        {
            ButtonSend(cb_T_HEX, tb_SendMsg,5);
        }      

        private void ButtonSend(CheckBox cb,TextBox tb)
        {           
            WriteLog(rtb_ReciveMsg, tb.Text);
            rtb_ReciveMsg.Update();
            string rst = EMoudleInstance.SendReciveMsg(cb.Checked, tb.Text, cb_R_HEX.Checked);
            WriteLog(rtb_ReciveMsg, rst + "\r\n");
        }
        private void ButtonSend(CheckBox cb, TextBox tb,int TimeOut)
        {
            WriteLog(rtb_ReciveMsg, tb.Text);
            rtb_ReciveMsg.Update();
            string rst = EMoudleInstance.SendReciveMsg(cb.Checked, tb.Text, cb_R_HEX.Checked,TimeOut);
            WriteLog(rtb_ReciveMsg, rst + "\r\n");
        }


        #region 利用委托解决跨线程调用问题方法(WriteLog)
        private delegate void WriteLogUnSafe(RichTextBox logRichTxt, string strLog);
        private static void WriteLog(RichTextBox logRichTxt, string strLog)
        {
            if (logRichTxt.InvokeRequired)
            {
                WriteLogUnSafe InvokeWriteLog = new WriteLogUnSafe(WriteLog);
                logRichTxt.Invoke(InvokeWriteLog, new object[] { logRichTxt, strLog });
            }
            else
            {
                logRichTxt.AppendText(strLog + "\r\n");
            }
        }



        #endregion

        #region"Button1-7 and TextBox1-7 事件"
        private void button1_Click(object sender, EventArgs e)
        {
            ButtonSend(checkBox1, textBox1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ButtonSend(checkBox2, textBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonSend(checkBox3, textBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonSend(checkBox4, textBox4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ButtonSend(checkBox5, textBox5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ButtonSend(checkBox6, textBox6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ButtonSend(checkBox7, textBox7);
        }

        private void ModifyBtnText(Button btn)
        {
            string str = Interaction.InputBox("请输入右边按钮的注释文字", "提示", btn.Text, -1, -1);  //-1表示在屏幕的中间  
            if (!string.IsNullOrEmpty(str)) btn.Text = str;      
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            ModifyBtnText(button1);
        }


        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            ModifyBtnText(button2);
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            ModifyBtnText(button3);
        }

        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            ModifyBtnText(button4);
        }

        private void textBox5_DoubleClick(object sender, EventArgs e)
        {
            ModifyBtnText(button5);
        }

        private void textBox6_DoubleClick(object sender, EventArgs e)
        {
            ModifyBtnText(button6);
        }

        private void textBox7_DoubleClick(object sender, EventArgs e)
        {
            ModifyBtnText(button7);
        }
        #endregion
    }
}
