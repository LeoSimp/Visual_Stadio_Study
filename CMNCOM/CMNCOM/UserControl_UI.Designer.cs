namespace CMNCOM
{
    partial class UserControl_UI
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.drpComList = new System.Windows.Forms.ComboBox();
            this.UC_Tittle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.drpBaudRate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.drpDataBits = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.drpParity = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.drpStopBits = new System.Windows.Forms.ComboBox();
            this.DeviceName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(19, 384);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(199, 29);
            this.button3.TabIndex = 63;
            this.button3.Text = "设备调试";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 420);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 29);
            this.button1.TabIndex = 62;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 60;
            this.label3.Text = "端口号";
            // 
            // drpComList
            // 
            this.drpComList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpComList.FormattingEnabled = true;
            this.drpComList.Location = new System.Drawing.Point(79, 166);
            this.drpComList.Margin = new System.Windows.Forms.Padding(4);
            this.drpComList.Name = "drpComList";
            this.drpComList.Size = new System.Drawing.Size(132, 23);
            this.drpComList.TabIndex = 61;
            // 
            // UC_Tittle
            // 
            this.UC_Tittle.AutoSize = true;
            this.UC_Tittle.Location = new System.Drawing.Point(16, 25);
            this.UC_Tittle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UC_Tittle.Name = "UC_Tittle";
            this.UC_Tittle.Size = new System.Drawing.Size(135, 15);
            this.UC_Tittle.TabIndex = 59;
            this.UC_Tittle.Text = "CommonCOM(V1.00)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 204);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 65;
            this.label1.Text = "波特率";
            // 
            // drpBaudRate
            // 
            this.drpBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpBaudRate.FormattingEnabled = true;
            this.drpBaudRate.Location = new System.Drawing.Point(79, 201);
            this.drpBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.drpBaudRate.Name = "drpBaudRate";
            this.drpBaudRate.Size = new System.Drawing.Size(132, 23);
            this.drpBaudRate.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 131);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 67;
            this.label4.Text = "设备名称";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CMNCOM.Properties.Resources.OneSoft_Panel;
            this.pictureBox1.Location = new System.Drawing.Point(9, 44);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 64;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 276);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 71;
            this.label5.Text = "数据位";
            // 
            // drpDataBits
            // 
            this.drpDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpDataBits.FormattingEnabled = true;
            this.drpDataBits.Location = new System.Drawing.Point(79, 273);
            this.drpDataBits.Margin = new System.Windows.Forms.Padding(4);
            this.drpDataBits.Name = "drpDataBits";
            this.drpDataBits.Size = new System.Drawing.Size(132, 23);
            this.drpDataBits.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 241);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 69;
            this.label6.Text = "校验位";
            // 
            // drpParity
            // 
            this.drpParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpParity.FormattingEnabled = true;
            this.drpParity.Location = new System.Drawing.Point(79, 238);
            this.drpParity.Margin = new System.Windows.Forms.Padding(4);
            this.drpParity.Name = "drpParity";
            this.drpParity.Size = new System.Drawing.Size(132, 23);
            this.drpParity.TabIndex = 70;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 311);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 73;
            this.label7.Text = "停止位";
            // 
            // drpStopBits
            // 
            this.drpStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpStopBits.FormattingEnabled = true;
            this.drpStopBits.Location = new System.Drawing.Point(79, 308);
            this.drpStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.drpStopBits.Name = "drpStopBits";
            this.drpStopBits.Size = new System.Drawing.Size(132, 23);
            this.drpStopBits.TabIndex = 74;
            // 
            // DeviceName
            // 
            this.DeviceName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeviceName.Location = new System.Drawing.Point(79, 125);
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            this.DeviceName.Size = new System.Drawing.Size(132, 25);
            this.DeviceName.TabIndex = 75;
            this.DeviceName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DeviceName.WordWrap = false;
            // 
            // UserControl_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DeviceName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.drpStopBits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.drpDataBits);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.drpParity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drpBaudRate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.drpComList);
            this.Controls.Add(this.UC_Tittle);
            this.Name = "UserControl_UI";
            this.Size = new System.Drawing.Size(237, 475);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        /// <summary>
        /// 申明共用，方便跨类调用
        /// </summary>
        public System.Windows.Forms.ComboBox drpComList;
        private System.Windows.Forms.Label UC_Tittle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        /// <summary>
        /// 申明共用，方便跨类调用
        /// </summary>
        public System.Windows.Forms.ComboBox drpBaudRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        /// <summary>
        /// 申明共用，方便跨类调用
        /// </summary>
        public System.Windows.Forms.ComboBox drpDataBits;
        private System.Windows.Forms.Label label6;
        /// <summary>
        /// 申明共用，方便跨类调用
        /// </summary>
        public System.Windows.Forms.ComboBox drpParity;
        private System.Windows.Forms.Label label7;
        /// <summary>
        /// 申明共用，方便跨类调用
        /// </summary>
        public System.Windows.Forms.ComboBox drpStopBits;
        /// <summary>
        /// 申明共用，方便跨类调用
        /// </summary>
        public System.Windows.Forms.TextBox DeviceName;
    }
}
