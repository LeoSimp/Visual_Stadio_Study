namespace TCP_SC
{
    partial class Server
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnopenserver = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tbserver = new System.Windows.Forms.TextBox();
            this.btnserversend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnopenserver
            // 
            this.btnopenserver.Location = new System.Drawing.Point(280, 6);
            this.btnopenserver.Name = "btnopenserver";
            this.btnopenserver.Size = new System.Drawing.Size(75, 25);
            this.btnopenserver.TabIndex = 0;
            this.btnopenserver.Text = "开启";
            this.btnopenserver.UseVisualStyleBackColor = true;
            this.btnopenserver.Click += new System.EventHandler(this.btnopenserver_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1, 98);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(525, 216);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // tbserver
            // 
            this.tbserver.Location = new System.Drawing.Point(52, 49);
            this.tbserver.Name = "tbserver";
            this.tbserver.Size = new System.Drawing.Size(211, 20);
            this.tbserver.TabIndex = 3;
            // 
            // btnserversend
            // 
            this.btnserversend.Location = new System.Drawing.Point(280, 44);
            this.btnserversend.Name = "btnserversend";
            this.btnserversend.Size = new System.Drawing.Size(75, 25);
            this.btnserversend.TabIndex = 4;
            this.btnserversend.Text = "发消息";
            this.btnserversend.UseVisualStyleBackColor = true;
            this.btnserversend.Click += new System.EventHandler(this.btnserversend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Local IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(215, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "55";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(52, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(111, 20);
            this.textBox2.TabIndex = 9;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 307);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnserversend);
            this.Controls.Add(this.tbserver);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnopenserver);
            this.Name = "Server";
            this.Text = "服务端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnopenserver;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox tbserver;
        private System.Windows.Forms.Button btnserversend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

