﻿namespace TCP_SC
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnopenclient = new System.Windows.Forms.Button();
            this.btnclientsend = new System.Windows.Forms.Button();
            this.tbclient = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(2, 101);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(528, 206);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // btnopenclient
            // 
            this.btnopenclient.Location = new System.Drawing.Point(276, 9);
            this.btnopenclient.Name = "btnopenclient";
            this.btnopenclient.Size = new System.Drawing.Size(75, 25);
            this.btnopenclient.TabIndex = 2;
            this.btnopenclient.Text = "连接服务端";
            this.btnopenclient.UseVisualStyleBackColor = true;
            this.btnopenclient.Click += new System.EventHandler(this.btnopenclient_Click);
            // 
            // btnclientsend
            // 
            this.btnclientsend.Location = new System.Drawing.Point(276, 48);
            this.btnclientsend.Name = "btnclientsend";
            this.btnclientsend.Size = new System.Drawing.Size(75, 25);
            this.btnclientsend.TabIndex = 6;
            this.btnclientsend.Text = "发消息";
            this.btnclientsend.UseVisualStyleBackColor = true;
            this.btnclientsend.Click += new System.EventHandler(this.btnclientsend_Click);
            // 
            // tbclient
            // 
            this.tbclient.Location = new System.Drawing.Point(50, 51);
            this.tbclient.Name = "tbclient";
            this.tbclient.Size = new System.Drawing.Size(211, 20);
            this.tbclient.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(50, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(111, 20);
            this.textBox2.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(213, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 20);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "55";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Server IP";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 307);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnclientsend);
            this.Controls.Add(this.tbclient);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnopenclient);
            this.Name = "Client";
            this.Text = "客户端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnopenclient;
        private System.Windows.Forms.Button btnclientsend;
        private System.Windows.Forms.TextBox tbclient;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}