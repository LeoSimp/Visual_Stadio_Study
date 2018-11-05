namespace sBarcode_Demo
{
    partial class COMTR
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.drpComList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.drpBaudRate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.drpParity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.drpDataBits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.drpStopBits = new System.Windows.Forms.ComboBox();
            this.COMOpen = new System.Windows.Forms.Button();
            this.COMReset = new System.Windows.Forms.Button();
            this.rtb_ReciveMsg = new System.Windows.Forms.RichTextBox();
            this.tb_SendMsg = new System.Windows.Forms.TextBox();
            this.SendMsg = new System.Windows.Forms.Button();
            this.cb_T_HEX = new System.Windows.Forms.CheckBox();
            this.cb_R_HEX = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "端口号";
            // 
            // drpComList
            // 
            this.drpComList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpComList.FormattingEnabled = true;
            this.drpComList.Location = new System.Drawing.Point(62, 12);
            this.drpComList.Name = "drpComList";
            this.drpComList.Size = new System.Drawing.Size(89, 21);
            this.drpComList.TabIndex = 45;
            this.drpComList.Click += new System.EventHandler(this.drpComList_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "波特率";
            // 
            // drpBaudRate
            // 
            this.drpBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpBaudRate.FormattingEnabled = true;
            this.drpBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.drpBaudRate.Location = new System.Drawing.Point(62, 38);
            this.drpBaudRate.Name = "drpBaudRate";
            this.drpBaudRate.Size = new System.Drawing.Size(89, 21);
            this.drpBaudRate.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "校验位";
            // 
            // drpParity
            // 
            this.drpParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpParity.FormattingEnabled = true;
            this.drpParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.drpParity.Location = new System.Drawing.Point(62, 66);
            this.drpParity.Name = "drpParity";
            this.drpParity.Size = new System.Drawing.Size(89, 21);
            this.drpParity.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "数据位";
            // 
            // drpDataBits
            // 
            this.drpDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpDataBits.FormattingEnabled = true;
            this.drpDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6"});
            this.drpDataBits.Location = new System.Drawing.Point(62, 94);
            this.drpDataBits.Name = "drpDataBits";
            this.drpDataBits.Size = new System.Drawing.Size(89, 21);
            this.drpDataBits.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "停止位";
            // 
            // drpStopBits
            // 
            this.drpStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpStopBits.FormattingEnabled = true;
            this.drpStopBits.Items.AddRange(new object[] {
            "1",
            "2"});
            this.drpStopBits.Location = new System.Drawing.Point(62, 122);
            this.drpStopBits.Name = "drpStopBits";
            this.drpStopBits.Size = new System.Drawing.Size(89, 21);
            this.drpStopBits.TabIndex = 53;
            // 
            // COMOpen
            // 
            this.COMOpen.Location = new System.Drawing.Point(18, 161);
            this.COMOpen.Name = "COMOpen";
            this.COMOpen.Size = new System.Drawing.Size(54, 25);
            this.COMOpen.TabIndex = 54;
            this.COMOpen.Text = "Open";
            this.COMOpen.UseVisualStyleBackColor = true;
            this.COMOpen.Click += new System.EventHandler(this.COMOpen_Click);
            // 
            // COMReset
            // 
            this.COMReset.Location = new System.Drawing.Point(97, 161);
            this.COMReset.Name = "COMReset";
            this.COMReset.Size = new System.Drawing.Size(54, 25);
            this.COMReset.TabIndex = 55;
            this.COMReset.Text = "Reset";
            this.COMReset.UseVisualStyleBackColor = true;
            this.COMReset.Click += new System.EventHandler(this.COMReset_Click);
            // 
            // rtb_ReciveMsg
            // 
            this.rtb_ReciveMsg.Location = new System.Drawing.Point(289, 12);
            this.rtb_ReciveMsg.Name = "rtb_ReciveMsg";
            this.rtb_ReciveMsg.Size = new System.Drawing.Size(267, 174);
            this.rtb_ReciveMsg.TabIndex = 56;
            this.rtb_ReciveMsg.Text = "";
            // 
            // tb_SendMsg
            // 
            this.tb_SendMsg.Location = new System.Drawing.Point(289, 206);
            this.tb_SendMsg.Name = "tb_SendMsg";
            this.tb_SendMsg.Size = new System.Drawing.Size(199, 20);
            this.tb_SendMsg.TabIndex = 57;
            // 
            // SendMsg
            // 
            this.SendMsg.Location = new System.Drawing.Point(504, 203);
            this.SendMsg.Name = "SendMsg";
            this.SendMsg.Size = new System.Drawing.Size(54, 25);
            this.SendMsg.TabIndex = 58;
            this.SendMsg.Text = "Send";
            this.SendMsg.UseVisualStyleBackColor = true;
            this.SendMsg.Click += new System.EventHandler(this.SendMsg_Click);
            // 
            // cb_T_HEX
            // 
            this.cb_T_HEX.AutoSize = true;
            this.cb_T_HEX.Location = new System.Drawing.Point(194, 208);
            this.cb_T_HEX.Name = "cb_T_HEX";
            this.cb_T_HEX.Size = new System.Drawing.Size(85, 17);
            this.cb_T_HEX.TabIndex = 59;
            this.cb_T_HEX.Text = "HexTransmit";
            this.cb_T_HEX.UseVisualStyleBackColor = true;
            // 
            // cb_R_HEX
            // 
            this.cb_R_HEX.AutoSize = true;
            this.cb_R_HEX.Location = new System.Drawing.Point(194, 14);
            this.cb_R_HEX.Name = "cb_R_HEX";
            this.cb_R_HEX.Size = new System.Drawing.Size(82, 17);
            this.cb_R_HEX.TabIndex = 60;
            this.cb_R_HEX.Text = "Hex Recive";
            this.cb_R_HEX.UseVisualStyleBackColor = true;
            // 
            // COMTR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 255);
            this.Controls.Add(this.cb_R_HEX);
            this.Controls.Add(this.cb_T_HEX);
            this.Controls.Add(this.SendMsg);
            this.Controls.Add(this.tb_SendMsg);
            this.Controls.Add(this.rtb_ReciveMsg);
            this.Controls.Add(this.COMReset);
            this.Controls.Add(this.COMOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drpComList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.drpBaudRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.drpParity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.drpDataBits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.drpStopBits);
            this.Name = "COMTR";
            this.Text = "COM Transmit and Recive";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drpComList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox drpBaudRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox drpParity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox drpDataBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox drpStopBits;
        private System.Windows.Forms.Button COMOpen;
        private System.Windows.Forms.Button COMReset;
        private System.Windows.Forms.RichTextBox rtb_ReciveMsg;
        private System.Windows.Forms.TextBox tb_SendMsg;
        private System.Windows.Forms.Button SendMsg;
        private System.Windows.Forms.CheckBox cb_T_HEX;
        private System.Windows.Forms.CheckBox cb_R_HEX;
    }
}

