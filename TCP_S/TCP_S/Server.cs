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
//需要添加 Reader.dll 作为引用， Reader.dll 来源于网络https://blog.csdn.net/HorseRoll/article/details/80491460
//本Source Code 只运用Reader.ReaderMethod一个对象，其他对象不懂如何使用
//已知Bug：程序退出后，需手动点击终止调试

namespace TCP_SC
{
public partial class Server : Form
{
    private Reader.ReaderMethod readerClient;//客户端消息采集
    IPAddress ipAddress = GetLocalIPAddress();
    
    public Server()
    {
        InitializeComponent();
        textBox2.Text = ipAddress.ToString();
        //初始化访问读写器实例
        readerClient = new Reader.ReaderMethod();
        //回调函数把收到的Byte数据传给ReceiveDataClient函数处理
        readerClient.ReceiveCallback = ReceiveDataClient;
    }
    private void btnopenserver_Click(object sender, EventArgs e)
    {
        int port=0;
        if (textBox1.Text == "")  //判断是否为空
        {
            MessageBox.Show("对不起，Port输入不能为空！", "Error", MessageBoxButtons.OK);           
        }
        else
        {
            try
            {
                port = Convert.ToInt32(textBox1.Text);
                readerClient.OpenServer(port);//打开服务器，开始监听
                WriteLog(richTextBox1, "建立TCP:" + ipAddress.ToString() + ":" + port + "成功");
            }
            catch
            {
                MessageBox.Show("对不起，Port输入只能为数字,请重试！", "Error", MessageBoxButtons.OK);               
            }
        }
    }
    /// <summary>
    /// 服务器接收数据并处理数据
    /// </summary>
    /// <param name="btAryReceiveData"></param>
    private void ReceiveDataClient(byte[] btAryReceiveData)
    {
        string str = System.Text.Encoding.Default.GetString(btAryReceiveData);//数据接收转string
        //richTextBox1.AppendText("接收到数据:" + str);直接调用该方法会出现跨线程调用问题
        WriteLog(richTextBox1,"接收到数据:" + str);
        WriteLog(richTextBox1, "Auto send Back:" + "ReciveOK");
        readerClient.ServerSendMessage(System.Text.Encoding.Default.GetBytes("ReciveOK\n\r"));//发送数据给客户端
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
    /// <summary>
    /// 发消息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnserversend_Click(object sender, EventArgs e)
    {
        WriteLog(richTextBox1, "发送数据:" + tbserver.Text);
        readerClient.ServerSendMessage(System.Text.Encoding.Default.GetBytes(tbserver.Text));//发送数据给客户端
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
        DialogResult r1 = MessageBox.Show("是否要关闭此窗口：" + this.Text, "YesNo", MessageBoxButtons.YesNo);
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
