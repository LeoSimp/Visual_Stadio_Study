using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//需要添加 Reader.dll 作为引用， Reader.dll 来源于网络https://blog.csdn.net/HorseRoll/article/details/80491460
//本Source Code 只运用Reader.ReaderMethod一个对象，其他对象不懂如何使用
//已知Bug：程序退出后，需手动点击终止调试

namespace TCP_SC
{
public partial class Client : Form
{
    private Reader.ReaderMethod readerServer;//服务端消息采集
    public Client()
    {
        InitializeComponent();
        //初始化访问读写器实例
        readerServer = new Reader.ReaderMethod();
        //回调函数
        readerServer.ReceiveCallback = ReceiveDataServer;
    }

    private void btnopenclient_Click(object sender, EventArgs e)
    {
        #region ipAddress和port用户输入判断
        IPAddress ipAddress = IPAddress.None;
        if (textBox2.Text == "")  //判断是否为空
        {
            MessageBox.Show("对不起，Server IP输入不能为空！", "Error", MessageBoxButtons.OK);
            
        }
        else
        {
            try
            {
                ipAddress = IPAddress.Parse(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("对不起，Server IP输入只能为IP地址！", "Error", MessageBoxButtons.OK);
                
            }

        }
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
            }
            catch
            {
                MessageBox.Show("对不起，Port输入只能为数字！", "Error", MessageBoxButtons.OK);
                
            }
        }
        #endregion
        string strLog = string.Empty;
        string strException = string.Empty;
            int nRet = readerServer.ConnectServer(ipAddress, port, out strException);
            if (nRet != 0)//如果连接服务端失败
            {
                strLog = "连接服务端失败，请确认是否已打开服务端，失败原因： " + strException;
            }
            else
            {
                strLog = "成功连接服务端" + ipAddress + ":" + port;
            }
        
        WriteLog(richTextBox1, strLog);
    }
    /// <summary>
    /// 服务端接收数据
    /// </summary>
    /// <param name="btAryReceiveData"></param>
    private void ReceiveDataServer(byte[] btAryReceiveData)
    {
        string str = System.Text.Encoding.Default.GetString(btAryReceiveData);//数据接收转string
        //richTextBox1.AppendText("接收到数据:" + str);直接调用该方法会出现跨线程调用问题
        WriteLog(richTextBox1, "接收到数据:" + str);
    }
    #region 利用委托解决跨线程调用问题方法
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

    private void btnclientsend_Click(object sender, EventArgs e)
    {
        readerServer.ServerSendMessage(System.Text.Encoding.Default.GetBytes(tbclient.Text));//发送数据
    }
  
}
}
