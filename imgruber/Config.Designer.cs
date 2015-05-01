namespace imgruber
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.useCtrlBOX = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.useAltBOX = new System.Windows.Forms.CheckBox();
            this.HotkeyCOMBO = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.urlTB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CharCount = new System.Windows.Forms.Label();
            this.TweetPrependTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TweetThisCB = new System.Windows.Forms.CheckBox();
            this.HelpLink = new System.Windows.Forms.LinkLabel();
            this.SourceLink = new System.Windows.Forms.LinkLabel();
            this.DoneBTN = new System.Windows.Forms.Button();
            this.LinkCodeCOMBO = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // useCtrlBOX
            // 
            this.useCtrlBOX.AutoSize = true;
            this.useCtrlBOX.Enabled = false;
            this.useCtrlBOX.Location = new System.Drawing.Point(13, 70);
            this.useCtrlBOX.Name = "useCtrlBOX";
            this.useCtrlBOX.Size = new System.Drawing.Size(54, 17);
            this.useCtrlBOX.TabIndex = 0;
            this.useCtrlBOX.Text = "CTRL";
            this.useCtrlBOX.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hotkey:";
            // 
            // useAltBOX
            // 
            this.useAltBOX.AutoSize = true;
            this.useAltBOX.Enabled = false;
            this.useAltBOX.Location = new System.Drawing.Point(76, 70);
            this.useAltBOX.Name = "useAltBOX";
            this.useAltBOX.Size = new System.Drawing.Size(46, 17);
            this.useAltBOX.TabIndex = 2;
            this.useAltBOX.Text = "ALT";
            this.useAltBOX.UseVisualStyleBackColor = true;
            // 
            // HotkeyCOMBO
            // 
            this.HotkeyCOMBO.Enabled = false;
            this.HotkeyCOMBO.FormattingEnabled = true;
            this.HotkeyCOMBO.Items.AddRange(new object[] {
            "Print Screen",
            "F12",
            "~"});
            this.HotkeyCOMBO.Location = new System.Drawing.Point(128, 68);
            this.HotkeyCOMBO.Name = "HotkeyCOMBO";
            this.HotkeyCOMBO.Size = new System.Drawing.Size(121, 21);
            this.HotkeyCOMBO.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last Screenshot URL:";
            // 
            // urlTB
            // 
            this.urlTB.Location = new System.Drawing.Point(13, 26);
            this.urlTB.Name = "urlTB";
            this.urlTB.ReadOnly = true;
            this.urlTB.Size = new System.Drawing.Size(236, 20);
            this.urlTB.TabIndex = 5;
            this.urlTB.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CharCount);
            this.groupBox1.Controls.Add(this.TweetPrependTB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TweetThisCB);
            this.groupBox1.Location = new System.Drawing.Point(13, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 183);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto-tweet";
            // 
            // CharCount
            // 
            this.CharCount.AutoSize = true;
            this.CharCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CharCount.Location = new System.Drawing.Point(159, 42);
            this.CharCount.Name = "CharCount";
            this.CharCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CharCount.Size = new System.Drawing.Size(41, 13);
            this.CharCount.TabIndex = 7;
            this.CharCount.Text = "0/110";
            this.CharCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TweetPrependTB
            // 
            this.TweetPrependTB.Location = new System.Drawing.Point(13, 59);
            this.TweetPrependTB.Multiline = true;
            this.TweetPrependTB.Name = "TweetPrependTB";
            this.TweetPrependTB.Size = new System.Drawing.Size(217, 118);
            this.TweetPrependTB.TabIndex = 5;
            this.TweetPrependTB.TextChanged += new System.EventHandler(this.TweetPrependTB_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Add tweet text:";
            // 
            // TweetThisCB
            // 
            this.TweetThisCB.AutoSize = true;
            this.TweetThisCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TweetThisCB.Location = new System.Drawing.Point(13, 19);
            this.TweetThisCB.Name = "TweetThisCB";
            this.TweetThisCB.Size = new System.Drawing.Size(42, 17);
            this.TweetThisCB.TabIndex = 0;
            this.TweetThisCB.Text = "On";
            this.TweetThisCB.UseVisualStyleBackColor = true;
            // 
            // HelpLink
            // 
            this.HelpLink.AutoSize = true;
            this.HelpLink.Location = new System.Drawing.Point(13, 318);
            this.HelpLink.Name = "HelpLink";
            this.HelpLink.Size = new System.Drawing.Size(62, 13);
            this.HelpLink.TabIndex = 7;
            this.HelpLink.TabStop = true;
            this.HelpLink.Text = "Help/About";
            this.HelpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HelpLink_LinkClicked);
            // 
            // SourceLink
            // 
            this.SourceLink.AutoSize = true;
            this.SourceLink.Location = new System.Drawing.Point(89, 318);
            this.SourceLink.Name = "SourceLink";
            this.SourceLink.Size = new System.Drawing.Size(41, 13);
            this.SourceLink.TabIndex = 8;
            this.SourceLink.TabStop = true;
            this.SourceLink.Text = "Source";
            this.SourceLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SourceLink_LinkClicked);
            // 
            // DoneBTN
            // 
            this.DoneBTN.Location = new System.Drawing.Point(147, 311);
            this.DoneBTN.Name = "DoneBTN";
            this.DoneBTN.Size = new System.Drawing.Size(102, 27);
            this.DoneBTN.TabIndex = 10;
            this.DoneBTN.Text = "Done";
            this.DoneBTN.UseVisualStyleBackColor = true;
            this.DoneBTN.Click += new System.EventHandler(this.DoneBTN_Click);
            // 
            // LinkCodeCOMBO
            // 
            this.LinkCodeCOMBO.FormattingEnabled = true;
            this.LinkCodeCOMBO.Items.AddRange(new object[] {
            "Image Link",
            "Direct Link",
            "Reddit Markdown",
            "HTML",
            "BBCode",
            "Linked BBCode"});
            this.LinkCodeCOMBO.Location = new System.Drawing.Point(128, 95);
            this.LinkCodeCOMBO.Name = "LinkCodeCOMBO";
            this.LinkCodeCOMBO.Size = new System.Drawing.Size(121, 21);
            this.LinkCodeCOMBO.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Link Code Style:";
            // 
            // Config
            // 
            this.AcceptButton = this.DoneBTN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 344);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LinkCodeCOMBO);
            this.Controls.Add(this.DoneBTN);
            this.Controls.Add(this.SourceLink);
            this.Controls.Add(this.HelpLink);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.urlTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HotkeyCOMBO);
            this.Controls.Add(this.useAltBOX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.useCtrlBOX);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imgruber Options";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox useCtrlBOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox useAltBOX;
        private System.Windows.Forms.ComboBox HotkeyCOMBO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label CharCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel HelpLink;
        private System.Windows.Forms.LinkLabel SourceLink;
        private System.Windows.Forms.Button DoneBTN;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox urlTB;
        public System.Windows.Forms.CheckBox TweetThisCB;
        public System.Windows.Forms.TextBox TweetPrependTB;
        public System.Windows.Forms.ComboBox LinkCodeCOMBO;
    }
}