namespace ClietApp
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblResultText = new System.Windows.Forms.Label();
            this.lblRes = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.tpCalculatePi = new System.Windows.Forms.TabControl();
            this.tpReverseString = new System.Windows.Forms.TabPage();
            this.btnExecute1 = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.tbResult1 = new System.Windows.Forms.TextBox();
            this.lblString = new System.Windows.Forms.Label();
            this.tbString = new System.Windows.Forms.TextBox();
            this.tpReverseInteger = new System.Windows.Forms.TabPage();
            this.lblRet = new System.Windows.Forms.Label();
            this.tbResult2 = new System.Windows.Forms.TextBox();
            this.btnExecute2 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblResult3 = new System.Windows.Forms.Label();
            this.tbResult3 = new System.Windows.Forms.TextBox();
            this.btnExecute3 = new System.Windows.Forms.Button();
            this.lblNDecPlaces = new System.Windows.Forms.Label();
            this.nudNDecimalPlaces = new System.Windows.Forms.NumericUpDown();
            this.tpAddTwoIntegers = new System.Windows.Forms.TabPage();
            this.lblResult4 = new System.Windows.Forms.Label();
            this.tbResult4 = new System.Windows.Forms.TextBox();
            this.btnExecute4 = new System.Windows.Forms.Button();
            this.lblVal2 = new System.Windows.Forms.Label();
            this.nudVal2 = new System.Windows.Forms.NumericUpDown();
            this.lblVal1 = new System.Windows.Forms.Label();
            this.nudVal1 = new System.Windows.Forms.NumericUpDown();
            this.chbAddNum = new System.Windows.Forms.CheckBox();
            this.pb1 = new System.Windows.Forms.ProgressBar();
            this.tmrProgressUpdater = new System.Windows.Forms.Timer(this.components);
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.tpCalculatePi.SuspendLayout();
            this.tpReverseString.SuspendLayout();
            this.tpReverseInteger.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNDecimalPlaces)).BeginInit();
            this.tpAddTwoIntegers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVal2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVal1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnConnect);
            this.pnlTop.Controls.Add(this.lblPort);
            this.pnlTop.Controls.Add(this.lblHost);
            this.pnlTop.Controls.Add(this.nudPort);
            this.pnlTop.Controls.Add(this.tbHost);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(720, 88);
            this.pnlTop.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(558, 30);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(356, 36);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(31, 13);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port:";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(42, 35);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(33, 13);
            this.lblHost.TabIndex = 2;
            this.lblHost.Text = "Host:";
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(389, 33);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(120, 20);
            this.nudPort.TabIndex = 1;
            this.nudPort.Value = new decimal(new int[] {
            1234,
            0,
            0,
            0});
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(77, 33);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(213, 20);
            this.tbHost.TabIndex = 0;
            this.tbHost.Text = "localhost";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pb1);
            this.pnlBottom.Controls.Add(this.lblResultText);
            this.pnlBottom.Controls.Add(this.lblRes);
            this.pnlBottom.Controls.Add(this.rtbLog);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 345);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(720, 100);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblResultText
            // 
            this.lblResultText.AutoSize = true;
            this.lblResultText.Location = new System.Drawing.Point(59, 13);
            this.lblResultText.Name = "lblResultText";
            this.lblResultText.Size = new System.Drawing.Size(11, 13);
            this.lblResultText.TabIndex = 2;
            this.lblResultText.Text = "-";
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.Location = new System.Drawing.Point(12, 13);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(41, 13);
            this.lblRes.TabIndex = 1;
            this.lblRes.Text = "Result:";
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(720, 100);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.tpCalculatePi);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 88);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(720, 257);
            this.pnlMiddle.TabIndex = 2;
            // 
            // tpCalculatePi
            // 
            this.tpCalculatePi.Controls.Add(this.tpReverseString);
            this.tpCalculatePi.Controls.Add(this.tpReverseInteger);
            this.tpCalculatePi.Controls.Add(this.tabPage1);
            this.tpCalculatePi.Controls.Add(this.tpAddTwoIntegers);
            this.tpCalculatePi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpCalculatePi.Location = new System.Drawing.Point(0, 0);
            this.tpCalculatePi.Name = "tpCalculatePi";
            this.tpCalculatePi.SelectedIndex = 0;
            this.tpCalculatePi.Size = new System.Drawing.Size(720, 257);
            this.tpCalculatePi.TabIndex = 0;
            // 
            // tpReverseString
            // 
            this.tpReverseString.Controls.Add(this.chbAddNum);
            this.tpReverseString.Controls.Add(this.btnExecute1);
            this.tpReverseString.Controls.Add(this.lblResult);
            this.tpReverseString.Controls.Add(this.tbResult1);
            this.tpReverseString.Controls.Add(this.lblString);
            this.tpReverseString.Controls.Add(this.tbString);
            this.tpReverseString.Location = new System.Drawing.Point(4, 22);
            this.tpReverseString.Name = "tpReverseString";
            this.tpReverseString.Padding = new System.Windows.Forms.Padding(3);
            this.tpReverseString.Size = new System.Drawing.Size(712, 231);
            this.tpReverseString.TabIndex = 0;
            this.tpReverseString.Text = "1 - Reverse String";
            this.tpReverseString.UseVisualStyleBackColor = true;
            // 
            // btnExecute1
            // 
            this.btnExecute1.Location = new System.Drawing.Point(115, 97);
            this.btnExecute1.Name = "btnExecute1";
            this.btnExecute1.Size = new System.Drawing.Size(75, 23);
            this.btnExecute1.TabIndex = 4;
            this.btnExecute1.Text = "Execute";
            this.btnExecute1.UseVisualStyleBackColor = true;
            this.btnExecute1.Click += new System.EventHandler(this.btnExecute1_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(27, 174);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(41, 13);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "Result:";
            // 
            // tbResult1
            // 
            this.tbResult1.Location = new System.Drawing.Point(115, 171);
            this.tbResult1.Name = "tbResult1";
            this.tbResult1.ReadOnly = true;
            this.tbResult1.Size = new System.Drawing.Size(539, 20);
            this.tbResult1.TabIndex = 2;
            // 
            // lblString
            // 
            this.lblString.AutoSize = true;
            this.lblString.Location = new System.Drawing.Point(27, 35);
            this.lblString.Name = "lblString";
            this.lblString.Size = new System.Drawing.Size(39, 13);
            this.lblString.TabIndex = 1;
            this.lblString.Text = "String:";
            // 
            // tbString
            // 
            this.tbString.Location = new System.Drawing.Point(115, 32);
            this.tbString.Name = "tbString";
            this.tbString.Size = new System.Drawing.Size(539, 20);
            this.tbString.TabIndex = 0;
            this.tbString.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // 
            // tpReverseInteger
            // 
            this.tpReverseInteger.Controls.Add(this.lblRet);
            this.tpReverseInteger.Controls.Add(this.tbResult2);
            this.tpReverseInteger.Controls.Add(this.btnExecute2);
            this.tpReverseInteger.Location = new System.Drawing.Point(4, 22);
            this.tpReverseInteger.Name = "tpReverseInteger";
            this.tpReverseInteger.Padding = new System.Windows.Forms.Padding(3);
            this.tpReverseInteger.Size = new System.Drawing.Size(712, 231);
            this.tpReverseInteger.TabIndex = 1;
            this.tpReverseInteger.Text = "2 - Reverse Integer";
            this.tpReverseInteger.UseVisualStyleBackColor = true;
            // 
            // lblRet
            // 
            this.lblRet.AutoSize = true;
            this.lblRet.Location = new System.Drawing.Point(34, 74);
            this.lblRet.Name = "lblRet";
            this.lblRet.Size = new System.Drawing.Size(41, 13);
            this.lblRet.TabIndex = 7;
            this.lblRet.Text = "Result:";
            // 
            // tbResult2
            // 
            this.tbResult2.Location = new System.Drawing.Point(85, 68);
            this.tbResult2.Name = "tbResult2";
            this.tbResult2.ReadOnly = true;
            this.tbResult2.Size = new System.Drawing.Size(587, 20);
            this.tbResult2.TabIndex = 6;
            // 
            // btnExecute2
            // 
            this.btnExecute2.Location = new System.Drawing.Point(25, 24);
            this.btnExecute2.Name = "btnExecute2";
            this.btnExecute2.Size = new System.Drawing.Size(75, 23);
            this.btnExecute2.TabIndex = 5;
            this.btnExecute2.Text = "Execute";
            this.btnExecute2.UseVisualStyleBackColor = true;
            this.btnExecute2.Click += new System.EventHandler(this.btnExecute2_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblResult3);
            this.tabPage1.Controls.Add(this.tbResult3);
            this.tabPage1.Controls.Add(this.btnExecute3);
            this.tabPage1.Controls.Add(this.lblNDecPlaces);
            this.tabPage1.Controls.Add(this.nudNDecimalPlaces);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(712, 231);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "3 - Calculate PI";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblResult3
            // 
            this.lblResult3.AutoSize = true;
            this.lblResult3.Location = new System.Drawing.Point(38, 132);
            this.lblResult3.Name = "lblResult3";
            this.lblResult3.Size = new System.Drawing.Size(41, 13);
            this.lblResult3.TabIndex = 4;
            this.lblResult3.Text = "Result:";
            // 
            // tbResult3
            // 
            this.tbResult3.Location = new System.Drawing.Point(132, 125);
            this.tbResult3.Name = "tbResult3";
            this.tbResult3.ReadOnly = true;
            this.tbResult3.Size = new System.Drawing.Size(523, 20);
            this.tbResult3.TabIndex = 3;
            // 
            // btnExecute3
            // 
            this.btnExecute3.Location = new System.Drawing.Point(99, 68);
            this.btnExecute3.Name = "btnExecute3";
            this.btnExecute3.Size = new System.Drawing.Size(75, 23);
            this.btnExecute3.TabIndex = 2;
            this.btnExecute3.Text = "Execute";
            this.btnExecute3.UseVisualStyleBackColor = true;
            this.btnExecute3.Click += new System.EventHandler(this.btnExecute3_Click);
            // 
            // lblNDecPlaces
            // 
            this.lblNDecPlaces.AutoSize = true;
            this.lblNDecPlaces.Location = new System.Drawing.Point(38, 28);
            this.lblNDecPlaces.Name = "lblNDecPlaces";
            this.lblNDecPlaces.Size = new System.Drawing.Size(88, 13);
            this.lblNDecPlaces.TabIndex = 1;
            this.lblNDecPlaces.Text = "#Decimal Places:";
            // 
            // nudNDecimalPlaces
            // 
            this.nudNDecimalPlaces.Location = new System.Drawing.Point(132, 26);
            this.nudNDecimalPlaces.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudNDecimalPlaces.Name = "nudNDecimalPlaces";
            this.nudNDecimalPlaces.Size = new System.Drawing.Size(120, 20);
            this.nudNDecimalPlaces.TabIndex = 0;
            this.nudNDecimalPlaces.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // tpAddTwoIntegers
            // 
            this.tpAddTwoIntegers.Controls.Add(this.lblResult4);
            this.tpAddTwoIntegers.Controls.Add(this.tbResult4);
            this.tpAddTwoIntegers.Controls.Add(this.btnExecute4);
            this.tpAddTwoIntegers.Controls.Add(this.lblVal2);
            this.tpAddTwoIntegers.Controls.Add(this.nudVal2);
            this.tpAddTwoIntegers.Controls.Add(this.lblVal1);
            this.tpAddTwoIntegers.Controls.Add(this.nudVal1);
            this.tpAddTwoIntegers.Location = new System.Drawing.Point(4, 22);
            this.tpAddTwoIntegers.Name = "tpAddTwoIntegers";
            this.tpAddTwoIntegers.Padding = new System.Windows.Forms.Padding(3);
            this.tpAddTwoIntegers.Size = new System.Drawing.Size(712, 231);
            this.tpAddTwoIntegers.TabIndex = 3;
            this.tpAddTwoIntegers.Text = "4 - Add Two Integers";
            this.tpAddTwoIntegers.UseVisualStyleBackColor = true;
            // 
            // lblResult4
            // 
            this.lblResult4.AutoSize = true;
            this.lblResult4.Location = new System.Drawing.Point(39, 122);
            this.lblResult4.Name = "lblResult4";
            this.lblResult4.Size = new System.Drawing.Size(41, 13);
            this.lblResult4.TabIndex = 6;
            this.lblResult4.Text = "Result:";
            // 
            // tbResult4
            // 
            this.tbResult4.Location = new System.Drawing.Point(91, 119);
            this.tbResult4.Name = "tbResult4";
            this.tbResult4.ReadOnly = true;
            this.tbResult4.Size = new System.Drawing.Size(251, 20);
            this.tbResult4.TabIndex = 5;
            // 
            // btnExecute4
            // 
            this.btnExecute4.Location = new System.Drawing.Point(91, 76);
            this.btnExecute4.Name = "btnExecute4";
            this.btnExecute4.Size = new System.Drawing.Size(75, 23);
            this.btnExecute4.TabIndex = 4;
            this.btnExecute4.Text = "Execute";
            this.btnExecute4.UseVisualStyleBackColor = true;
            this.btnExecute4.Click += new System.EventHandler(this.btnExecute4_Click);
            // 
            // lblVal2
            // 
            this.lblVal2.AutoSize = true;
            this.lblVal2.Location = new System.Drawing.Point(246, 37);
            this.lblVal2.Name = "lblVal2";
            this.lblVal2.Size = new System.Drawing.Size(46, 13);
            this.lblVal2.TabIndex = 3;
            this.lblVal2.Text = "Value 2:";
            // 
            // nudVal2
            // 
            this.nudVal2.Location = new System.Drawing.Point(298, 35);
            this.nudVal2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudVal2.Name = "nudVal2";
            this.nudVal2.Size = new System.Drawing.Size(120, 20);
            this.nudVal2.TabIndex = 2;
            this.nudVal2.Value = new decimal(new int[] {
            356,
            0,
            0,
            0});
            // 
            // lblVal1
            // 
            this.lblVal1.AutoSize = true;
            this.lblVal1.Location = new System.Drawing.Point(39, 35);
            this.lblVal1.Name = "lblVal1";
            this.lblVal1.Size = new System.Drawing.Size(46, 13);
            this.lblVal1.TabIndex = 1;
            this.lblVal1.Text = "Value 1:";
            // 
            // nudVal1
            // 
            this.nudVal1.Location = new System.Drawing.Point(91, 33);
            this.nudVal1.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudVal1.Name = "nudVal1";
            this.nudVal1.Size = new System.Drawing.Size(120, 20);
            this.nudVal1.TabIndex = 0;
            this.nudVal1.Value = new decimal(new int[] {
            144,
            0,
            0,
            0});
            // 
            // chbAddNum
            // 
            this.chbAddNum.AutoSize = true;
            this.chbAddNum.Checked = true;
            this.chbAddNum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAddNum.Location = new System.Drawing.Point(117, 68);
            this.chbAddNum.Name = "chbAddNum";
            this.chbAddNum.Size = new System.Drawing.Size(120, 17);
            this.chbAddNum.TabIndex = 5;
            this.chbAddNum.Text = "Add number to text";
            this.chbAddNum.UseVisualStyleBackColor = true;
            // 
            // pb1
            // 
            this.pb1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pb1.Location = new System.Drawing.Point(0, 77);
            this.pb1.Maximum = 5;
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(720, 23);
            this.pb1.TabIndex = 3;
            // 
            // tmrProgressUpdater
            // 
            this.tmrProgressUpdater.Enabled = true;
            this.tmrProgressUpdater.Tick += new System.EventHandler(this.tmrProgressUpdater_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 445);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmMain";
            this.Text = "Client Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.tpCalculatePi.ResumeLayout(false);
            this.tpReverseString.ResumeLayout(false);
            this.tpReverseString.PerformLayout();
            this.tpReverseInteger.ResumeLayout(false);
            this.tpReverseInteger.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNDecimalPlaces)).EndInit();
            this.tpAddTwoIntegers.ResumeLayout(false);
            this.tpAddTwoIntegers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVal2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVal1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TabControl tpCalculatePi;
        private System.Windows.Forms.TabPage tpReverseString;
        private System.Windows.Forms.TabPage tpReverseInteger;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tpAddTwoIntegers;
        private System.Windows.Forms.Button btnExecute1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox tbResult1;
        private System.Windows.Forms.Label lblString;
        private System.Windows.Forms.TextBox tbString;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label lblRet;
        private System.Windows.Forms.TextBox tbResult2;
        private System.Windows.Forms.Button btnExecute2;
        private System.Windows.Forms.Label lblNDecPlaces;
        private System.Windows.Forms.NumericUpDown nudNDecimalPlaces;
        private System.Windows.Forms.Label lblResult3;
        private System.Windows.Forms.TextBox tbResult3;
        private System.Windows.Forms.Button btnExecute3;
        private System.Windows.Forms.Label lblResult4;
        private System.Windows.Forms.TextBox tbResult4;
        private System.Windows.Forms.Button btnExecute4;
        private System.Windows.Forms.Label lblVal2;
        private System.Windows.Forms.NumericUpDown nudVal2;
        private System.Windows.Forms.Label lblVal1;
        private System.Windows.Forms.NumericUpDown nudVal1;
        private System.Windows.Forms.Label lblResultText;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.CheckBox chbAddNum;
        private System.Windows.Forms.ProgressBar pb1;
        private System.Windows.Forms.Timer tmrProgressUpdater;
    }
}

