using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
//验证Scanner barcode pass

namespace sBarcode
{
    public partial class COMTR : Form
    {
        static SerialPort _serialPort;
        public COMTR()
        {
            InitializeComponent();

            drpBaudRate.SelectedIndex = drpBaudRate.Items.IndexOf("115200");
            drpParity.SelectedIndex = drpParity.Items.IndexOf("None");
            drpDataBits.SelectedIndex = drpDataBits.Items.IndexOf("8");
            drpStopBits.SelectedIndex = drpStopBits.Items.IndexOf("1");
            _serialPort = new SerialPort();
        }

        private void COMOpen_Click(object sender, EventArgs e)
        {
            int numPorts = SerialPort.GetPortNames().Length;
            if (string.IsNullOrEmpty(drpComList.Text))
            {
                MessageBox.Show("无可用或未选择端口号，请检查端口号是否存在", "Error", MessageBoxButtons.OK);
                UpdateComList();
            }
            else
            {
                _serialPort.PortName = drpComList.Text;
                _serialPort.BaudRate = int.Parse(drpBaudRate.Text);
                _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), drpParity.Text);
                _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), drpStopBits.Text);
                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;
                try
                {
                    _serialPort.Open();
                    COMOpen.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("对不起，COM Port Open失败,请重试！", "Error", MessageBoxButtons.OK);
                }
                
               
            }

        }

        private void COMReset_Click(object sender, EventArgs e)
        {
            if( _serialPort.IsOpen) { _serialPort.Close(); }
            COMOpen.Enabled = true;

        }

        private void drpComList_Click(object sender, EventArgs e)
        {
            UpdateComList();
        }
        public void UpdateComList()
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                drpComList.Items.Add(s);
                drpComList.SelectedIndex = 0;
            }
        }

        public void SendMsg_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                //MessageBox.Show("Pause", "Pause", MessageBoxButtons.OK);
                if (cb_T_HEX.Checked)
                {
                    if (tb_SendMsg.Text.Length % 2 != 0){ MessageBox.Show("16进制必须为偶数位，请检查！", "Error", MessageBoxButtons.OK); return; }
                    byte[] buf = HexStringToByteArray(tb_SendMsg.Text);
                    Console.WriteLine(BitConverter.ToString(buf));
                    WriteLog(rtb_ReciveMsg, BitConverter.ToString(buf));
                    _serialPort.Write(buf, 0, buf.Length);
                }
                else
                {
                    WriteLog(rtb_ReciveMsg, tb_SendMsg.Text);
                    _serialPort.WriteLine(tb_SendMsg.Text);
                }
                WriteLog(rtb_ReciveMsg, ReadStrHex()+ "\r\n");
            }
            else
            {
                MessageBox.Show("COM处于断开状态，请检查！", "Error", MessageBoxButtons.OK);
            }

        }
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            Console.WriteLine(s.Length / 2);
            for (int i = 0; i < s.Length; i += 2)
            {
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            }
            return buffer;
        }
        public string ReadStrHex()
        {
            string str = null;
            int inti = 0;
            do
            {
                Thread.Sleep(100);
                inti += 1;
            }
            while ((_serialPort.BytesToRead == 0) && (inti < 150));
            Thread.Sleep(500);
            try
            {
                string response = _serialPort.ReadLine();
                if (cb_R_HEX.Checked)
                {
                    byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(response);
                    String RecvDataText = null;
                    for (int i = 0; i < byteArray.Length - 1; i++)
                    {
                        RecvDataText += (byteArray[i].ToString("X2") + " ");
                    }
                    str = RecvDataText;
                }
                else
                {
                    str = response;
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show("读取等待超时，Time out=15S！", "Error", MessageBoxButtons.OK);
                return str;
            }
            
            return str;
        }
        #region 利用委托解决跨线程调用问题方法(WriteLog)
        private delegate void WriteLogUnSafe(RichTextBox logRichTxt, string strLog);
        public static void WriteLog(RichTextBox logRichTxt, string strLog)
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
    }
}
