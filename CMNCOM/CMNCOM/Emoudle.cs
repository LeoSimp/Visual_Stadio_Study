using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CMNCOM
{
    /// <summary>
    /// 用于无界面引用，相对FormDiag窗口而言是自动引用
    /// </summary>
    public class EMoudle
    {
        /// <summary>
        /// 声明DeviceUI为UserControl_UI
        /// </summary>
        public UserControl_UI DeviceUI;
        /// <summary>
        /// 初始化，必须指定DeviceName.Text
        /// </summary>
        public EMoudle(string devName)
        {
            DeviceUI = new UserControl_UI(devName);
            DeviceUI.User_Load(true);
        }

        /// <summary>
        /// Send Message via COM
        /// Send完直接关闭COM，适用于无需接收数据返回的情况，比如Scanner Stop
        /// </summary>
        /// <param name="hexBool">代表发送的字符串是否为Hex</param>
        ///  <param name="Msg">代表发送的字符串</param>
        public void SendMsg(bool hexBool, string Msg)
        {
            DeviceClose();
            Thread.Sleep(10);
            DeviceOpen();
            if (DeviceUI.ComDevice.IsOpen)
            {
                //MessageBox.Show("Pause", "Pause", MessageBoxButtons.OK);
                if (hexBool)
                {
                    if (Msg.Length % 2 != 0) { MessageBox.Show("16进制必须为偶数位，请检查！", "Error", MessageBoxButtons.OK); return; }
                    byte[] buf = HexStringToByteArray(Msg);
                    Console.WriteLine(BitConverter.ToString(buf));
                    DeviceUI.ComDevice.Write(buf, 0, buf.Length);
                }
                else
                {
                    DeviceUI.ComDevice.WriteLine(Msg);
                }
            }
            else
            {
                MessageBox.Show("COM处于断开状态，请检查！", DeviceUI.MoudleConnString_Ext + " - " + DeviceUI.ComDevice.DeviceDiscription);
            }
            DeviceClose();
        }

        /// <summary>
        /// Send Message and recieve via COM
        /// 适用于不需要判断接收数据超时提醒的情况，最多只等待1S，且超时不提醒
        /// </summary>
        /// <param name="Send_hexBool"></param>
        /// <param name="Msg"></param>
        /// <param name="Recive_hexBool"></param>
        public string SendReciveMsg(bool Send_hexBool, string Msg,bool Recive_hexBool)
        {
            DeviceClose();
            Thread.Sleep(10);
            DeviceOpen();
            if (DeviceUI.ComDevice.IsOpen)
            {
                //MessageBox.Show("Pause", "Pause", MessageBoxButtons.OK);
                if (Send_hexBool)
                {
                    if (Msg.Length % 2 != 0) { MessageBox.Show("16进制必须为偶数位，请检查！", "Error", MessageBoxButtons.OK); return null; }
                    byte[] buf = HexStringToByteArray(Msg);
                    Console.WriteLine(BitConverter.ToString(buf));
                    DeviceUI.ComDevice.Write(buf, 0, buf.Length);
                }
                else
                {
                    DeviceUI.ComDevice.WriteLine(Msg);
                }
            }
            else
            {
                MessageBox.Show("COM处于断开状态，请检查！", DeviceUI.MoudleConnString_Ext + " - " + DeviceUI.ComDevice.DeviceDiscription);
                return null;
            }
            string str=RecieveMsg(Recive_hexBool);
            
            DeviceClose();
            return str;
        }

        /// <summary>
        /// Send Message and recieve via COM
        /// 适用于需要判断接收数据超时提醒的情况
        /// </summary>
        /// <param name="Send_hexBool"></param>
        /// <param name="Msg"></param>
        /// <param name="Recive_hexBool"></param>
        /// <param name="RTimeOut"></param>
        /// <returns></returns>
        public string SendReciveMsg(bool Send_hexBool, string Msg, bool Recive_hexBool,int RTimeOut)
        {
            DeviceClose();
            Thread.Sleep(10);
            DeviceOpen();
            if (DeviceUI.ComDevice.IsOpen)
            {
                //MessageBox.Show("Pause", "Pause", MessageBoxButtons.OK);
                if (Send_hexBool)
                {
                    if (Msg.Length % 2 != 0) { MessageBox.Show("16进制必须为偶数位，请检查！", "Error", MessageBoxButtons.OK); return null; }
                    byte[] buf = HexStringToByteArray(Msg);
                    Console.WriteLine(BitConverter.ToString(buf));
                    DeviceUI.ComDevice.Write(buf, 0, buf.Length);
                }
                else
                {
                    DeviceUI.ComDevice.WriteLine(Msg);
                }
            }
            else
            {
                MessageBox.Show("COM处于断开状态，请检查！", DeviceUI.MoudleConnString_Ext + " - " + DeviceUI.ComDevice.DeviceDiscription);
                return null;
            }
            string str = RecieveMsg(Recive_hexBool,RTimeOut);

            DeviceClose();
            return str;
        }

        /// <summary>
        /// Recieve Message via COM，超时无数据返回报错提醒
        /// 收取数据时不宜频繁打开关闭COM，容易造成收到的数据不完整
        /// </summary>
        /// <param name="hexBool">代表发送的字符串是否为Hex</param>
        /// <param name="timeout">代表接收串口数据的最大超时时间(S)</param>
        /// <returns>返回字符串类型的接收到的数据</returns>
        public string RecieveMsg(bool hexBool, int timeout)
        {
            string str = null;
            int inti = 0;
            do
            {
                Thread.Sleep(100);
                inti += 1;
                //Console.WriteLine("inti："+inti);
                //15S
            }
            while ((DeviceUI.ComDevice.BytesToRead == 0) && (inti < timeout*10));
            if (inti >= timeout * 10)
            {
                MessageBox.Show("读取数据包个数为0，等待超时！("+ timeout + "S)", DeviceUI.MoudleConnString_Ext + " - " + DeviceUI.ComDevice.DeviceDiscription);
                return str;
            }
            Thread.Sleep(500);
            try
            {
                string response = DeviceUI.ComDevice.ReadLine();
                if (hexBool)
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
                MessageBox.Show("读取数据包个数包个数不为0，但处理超时！", DeviceUI.MoudleConnString_Ext + " - " + DeviceUI.ComDevice.DeviceDiscription);
                return str;
            }
            return str;
        }

        /// <summary>
        /// Recieve Message via COM,数据包个数为0时，最多只等待1S，且超时不提醒，
        /// 收取数据时不宜频繁打开关闭COM，容易造成收到的数据不完整
        /// </summary>
        /// <param name="hexBool">代表发送的字符串是否为Hex</param>
        /// <returns>返回字符串类型的接收到的数据</returns>
        public string RecieveMsg(bool hexBool)
        {
            string str = null;
            int inti = 0;
            do
            {
                Thread.Sleep(100);
                inti += 1;
                //Console.WriteLine("inti："+inti);
                //15S
            }
            while ((DeviceUI.ComDevice.BytesToRead == 0) && (inti < 1 * 10));
            if (inti >= 1* 10)
            {
                //MessageBox.Show("读取数据包个数为0，等待超时！(" + 1 + "S)", DeviceUI.MoudleConnString_Ext + " - " + DeviceUI.ComDevice.DeviceDiscription);
                return str;
            }
            Thread.Sleep(500);
            try
            {
                string response = DeviceUI.ComDevice.ReadLine();
                if (hexBool)
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
                MessageBox.Show("读取数据包个数包个数不为0，但处理超时！", DeviceUI.MoudleConnString_Ext + " - " + DeviceUI.ComDevice.DeviceDiscription);
                return str;
            }
            return str;
        }

        /// <summary>
        /// DeviceUI ComDevice Open
        /// </summary>
        public void DeviceOpen()
        {
            DeviceUI.ComDevice.Open();
        }

        /// <summary>
        ///  DeviceUI ComDevice Close
        /// </summary>
        public void DeviceClose()
        {
            DeviceUI.ComDevice.Close();
        }

        private static byte[] HexStringToByteArray(string s)
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


    }
}
