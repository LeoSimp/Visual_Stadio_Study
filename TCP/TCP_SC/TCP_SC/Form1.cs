using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
//已测试单独开启server模式和单独开启客户端模式都OK，同时开启也都OK，但是同时开启时不能用同一个端口
//作为客户端时，由于发包后自动断开，因此，无法同时接收服务端数据，即单项通信，作为服务端时双向通信
//还有优化的空间

namespace TCP_SC
{
    public partial class Form1 : Form
    {
        //定义一个委托，用于更新Form1上控件。
        protected delegate void UpdateDisplayDelegate(string text);
        public Thread thread = null;
        public TcpClient tcpClientReceiver = null;
        TcpListener tcpListener = null;
        public Boolean boolStop = false;
        IPAddress LocalIp = GetLocalIPAddress();
        int port = 0;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = LocalIp.ToString();
            if (LocalIp.ToString() == "127.0.0.1")
            {
                MessageBox.Show("本机IP地址异常", "Error", MessageBoxButtons.OK);
                return;
            }       
        }

        public void Listen()
        {
            tcpListener = new TcpListener(LocalIp, port);
            tcpClientReceiver = new TcpClient();
            tcpListener.Start();
            //richTextBox1.AppendText("As server start..." ); 直接调用该方法会出现跨线程调用问题
            Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] { "As server start..." });
            Byte[] bytes = new Byte[256];
            String data = null;
            while (true)
            {                     
              if (!tcpListener.Pending())
                {
                    //为了避免每次都被tcpListener.AcceptTcpClient()阻塞线程，添加了此判断，
                    //no connection requests have arrived。
                    //当没有连接请求时，什么也不做，有了请求再执行到tcpListener.AcceptTcpClient()
                    //Console.WriteLine("no connection requests have arrived……");
                    //Thread.Sleep(500);
                }
                else
                {                                
                    tcpClientReceiver = tcpListener.AcceptTcpClient(); //当有被连接上才会继续
                    //MessageBox.Show("Pause1", "Pause", MessageBoxButtons.OK); 
                    NetworkStream ns = tcpClientReceiver.GetStream();
                    //StreamReader sr = new StreamReader(ns);
                    //string result = sr.ReadToEnd();//当连接上又断开才会继续 
                    int i;
                    // Loop to receive all the data sent by the client.
                    while ((i = ns.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.Default.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);
                        Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] { "接受数据" + data });
                        // Process the data sent by the client.
                        data = data.ToUpper();
                        byte[] msg = System.Text.Encoding.Default.GetBytes(data);
                        // Send back a response.
                        ns.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                        Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] {"自动回传数据"+ data });
                    }
                    // Shutdown and end connection
                    tcpClientReceiver.Close();
                    //MessageBox.Show("Pause2", "Pause", MessageBoxButtons.OK);
                }
                if (boolStop)
                {
                    tcpClientReceiver.Close();
                    tcpListener.Stop();
                    // Even Stop connection and listening for new clients, still have thread hung issue when exit
                    // Only need stop conection by client itself can aviod this issue
                    break;
                }
            }

        }

        public void UpdateDisplay(string text)
        {
            string currentContents = richTextBox1.Text;
            currentContents += text + "\r\n";   //必须用"\r\n"在窗口中才能体现出换行
            richTextBox1.Text = currentContents;
        }

        //send message
        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage();
        }
        public void SendMessage()
        {
            try
            {
                TcpClient tcpClient = new TcpClient(textBox4.Text, Int32.Parse(textBox3.Text));
                NetworkStream ns = tcpClient.GetStream();
                string message = richTextBox2.Text;
                Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] { "发送数据" + message });
                byte[] contentBytes = Encoding.Default.GetBytes(message); //将string类型转换为byte[]
                for (int i = 0; i < contentBytes.Length; i++)
                {
                    ns.WriteByte(contentBytes[i]);
                }
                //ns.Close();
                //tcpClient.Close();
                richTextBox2.Text = "";
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] { "SocketException:" + e });
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")  //判断是否为空
            {
                MessageBox.Show("对不起，Port输入不能为空！", "Error", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    port = Convert.ToInt32(textBox2.Text);
                    thread = new Thread(new ThreadStart(Listen));
                    thread.Start();
                    button2.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("对不起，Port输入只能为数字,请重试！", "Error", MessageBoxButtons.OK);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
           IPAddress ipAddress = IPAddress.None;
            if (textBox4.Text == "")  //判断是否为空
            {
                MessageBox.Show("对不起，Server IP输入不能为空！", "Error", MessageBoxButtons.OK);           
            }
            else
            {
                try
                {
                    ipAddress = IPAddress.Parse(textBox4.Text);
                }
                catch
                {
                    MessageBox.Show("对不起，Server IP输入只能为IP地址！", "Error", MessageBoxButtons.OK);              
                }
            }
            if (textBox3.Text == "")  //判断是否为空
            {
                MessageBox.Show("对不起，Port输入不能为空！", "Error", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    port = Convert.ToInt32(textBox3.Text);
                    button3.Enabled = false;
                    Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] { "As client start..." });
                }
                catch
                {
                    MessageBox.Show("对不起，Port输入只能为数字,请重试！", "Error", MessageBoxButtons.OK);
                }
            }
        }
        

        //获得本地的IP地址
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

        //在关闭之前，将boolStop设置为true，thread既可以结束了。
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            boolStop = true;
        }

       
      
    
    }
}
