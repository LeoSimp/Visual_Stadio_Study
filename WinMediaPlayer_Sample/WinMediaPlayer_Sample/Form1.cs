using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinMediaPlayer_Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                label1.Text = "Add file: " + ofd.FileName;
                axWindowsMediaPlayer1.URL = ofd.FileName;
                axWindowsMediaPlayer1.close();
            }
            else
            {
                label1.Text = "No select file";
                axWindowsMediaPlayer1.URL = "";
                axWindowsMediaPlayer1.close();
            }
        }

    }
}
