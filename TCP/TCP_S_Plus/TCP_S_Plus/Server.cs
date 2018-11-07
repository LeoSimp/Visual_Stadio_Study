using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//1对多通信2个Bug
//Bug:1. 当其中2个client连接上没有马上发送数据的时候，先连上的client发送了数据（非空），server会显示收到数据为空
//    2. 当其中2个clientt连接上没有马上发送数据的时候,后连上的client发送了数据a(长度为n)，这个时候先连上的client发送数据b(长度为m),
//    server会显示收到数据为长度为m的数据a(假设n>m,a数据就不完整)
//这2个Bug目前无法修复
//短期解决办法是采用每个线程一次收发完后，server端主动断开与client的连接，以保证传输的正确率

namespace TCP_SC
{
    public partial class Server : Form
    {
        static Byte[] bytes;
        static string data;
        static TcpListener server;
        static Thread thread;
        static TcpClient client;
        IPAddress ipAddress = GetLocalIPAddress();

        public Server()
        {
            InitializeComponent();
            textBox2.Text = ipAddress.ToString();
        }
        private void btnopenserver_Click(object sender, EventArgs e)
        {
            int port = 0;
            if (textBox1.Text == "")  //判断是否为空
            {
                MessageBox.Show("对不起，Port输入不能为空！", "Error", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    port = Convert.ToInt32(textBox1.Text);
                    server = new TcpListener(ipAddress, port);
                    thread = new Thread(new ThreadStart(ResponseClient));
                    thread.Start();
                    WriteLog(richTextBox1, "建立TCP:" + ipAddress.ToString() + ":" + port + "成功");
                    Console.WriteLine("建立TCP:" + ipAddress.ToString() + ":" + port + "成功");
                }
                catch
                {
                    MessageBox.Show("对不起，Port输入只能为数字,请重试！", "Error", MessageBoxButtons.OK);
                }
            }
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
        private void ResponseClient()
        {
            while (true)
            {
                server.Start(); // 开始侦听
                // Enter the listening loop.
                Console.WriteLine("Waiting for connection... ");
                WriteLog(richTextBox1, "Waiting for connection... ");
                client = server.AcceptTcpClient();
                string ClientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                int ClientPort = ((IPEndPoint)client.Client.RemoteEndPoint).Port;
                Console.WriteLine("Client IP:{0}:{1} Connected", ClientIP, ClientPort);
                WriteLog(richTextBox1, "Client IP:" + ClientIP + ":" + ClientPort + " Connected");
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }

        }
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            string ClientIP = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            int ClientPort = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Port;
            data = null;
            NetworkStream stream = tcpClient.GetStream();
            bytes = new Byte[256];

            if (stream.CanRead)
            {
                //stream.Read(bytes, 0, bytes.Length 接收数据流，并存于bytes数组，数据流结束后继续下面的语句，否则一直等待数据流开始流入            
                while (true)
                {
                    int i = 0;
                    try
                    {
                        i = stream.Read(bytes, 0, bytes.Length);
                    }
                    catch
                    {
                        //a socket error has occured
                        break;
                    }
                    if (i == 0)
                    {
                        //the client has disconnected from the server
                        break;
                    }
                    data = Encoding.Default.GetString(bytes, 0, i);
                    Console.WriteLine("Received from {0}:{1}：{2}", ClientIP, ClientPort, data);
                    WriteLog(richTextBox1, "Received from" + ClientIP + ":" + ClientPort + "：" + data);
                    // Process the data sent by the client.
                    data = data.ToUpper();

                    byte[] msg = System.Text.Encoding.Default.GetBytes(data);

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Send to {0}:{1}：{2}", ClientIP, ClientPort, data);
                    WriteLog(richTextBox1, "Send to" + ClientIP + ":" + ClientPort + "：" + data);
                    tcpClient.Close();
                    stream.Close();
                }
            }
            else
            {
                Console.WriteLine("You cannot read data from this stream.");
                WriteLog(richTextBox1, "You cannot read data from this stream.");
                tcpClient.Close();
                stream.Close();
            }
        }

        static IPAddress GetLocalIPAddress()
        {
            IPAddress[] ipadrlist = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress ipa_return = IPAddress.Parse("127.0.0.1");
            foreach (IPAddress ipa in ipadrlist)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipa_return = ipa;
                }

            }
            return ipa_return;
        }
        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r1 = MessageBox.Show("是否要关闭此窗口：" + Text, "YesNo", MessageBoxButtons.YesNo);
            if (r1 == DialogResult.Yes)
            {
                e.Cancel = false;

            }
            else
            {
                e.Cancel = true;
            }
        }

    }
}



