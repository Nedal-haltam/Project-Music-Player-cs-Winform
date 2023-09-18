namespace Project_Music_Player
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.songlist = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnaddsong = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.wmplayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wmplayer)).BeginInit();
            this.SuspendLayout();
            // 
            // songlist
            // 
            this.songlist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.songlist.BackColor = System.Drawing.Color.SeaShell;
            this.songlist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.songlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songlist.FormattingEnabled = true;
            this.songlist.ItemHeight = 20;
            this.songlist.Location = new System.Drawing.Point(11, 385);
            this.songlist.Margin = new System.Windows.Forms.Padding(2);
            this.songlist.Name = "songlist";
            this.songlist.ScrollAlwaysVisible = true;
            this.songlist.Size = new System.Drawing.Size(806, 197);
            this.songlist.Sorted = true;
            this.songlist.TabIndex = 1;
            this.songlist.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Songlist_DrawItem);
            this.songlist.SelectedIndexChanged += new System.EventHandler(this.Songlist_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(63, 358);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(242, 26);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // btnaddsong
            // 
            this.btnaddsong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnaddsong.Location = new System.Drawing.Point(821, 385);
            this.btnaddsong.Margin = new System.Windows.Forms.Padding(2);
            this.btnaddsong.Name = "btnaddsong";
            this.btnaddsong.Size = new System.Drawing.Size(100, 31);
            this.btnaddsong.TabIndex = 3;
            this.btnaddsong.Text = "Emport Music";
            this.btnaddsong.UseVisualStyleBackColor = true;
            this.btnaddsong.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(821, 440);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "multiple track mode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // wmplayer
            // 
            this.wmplayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wmplayer.Enabled = true;
            this.wmplayer.Location = new System.Drawing.Point(9, 7);
            this.wmplayer.Margin = new System.Windows.Forms.Padding(2);
            this.wmplayer.Name = "wmplayer";
            this.wmplayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmplayer.OcxState")));
            this.wmplayer.Size = new System.Drawing.Size(1088, 335);
            this.wmplayer.TabIndex = 0;
            this.wmplayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.Wmpplayer_PlayStateChange);
            this.wmplayer.ClickEvent += new AxWMPLib._WMPOCXEvents_ClickEventHandler(this.Wmpplayer_ClickEvent);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(12, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Search:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(982, 455);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 593);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnaddsong);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.songlist);
            this.Controls.Add(this.wmplayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wmplayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer wmplayer;
        private System.Windows.Forms.ListBox songlist;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnaddsong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}

