namespace Locify
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
            this.playingLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openBannedIpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBannedSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBannedIpsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openVisitedIpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playingLabel
            // 
            this.playingLabel.AutoSize = true;
            this.playingLabel.Location = new System.Drawing.Point(12, 35);
            this.playingLabel.Name = "playingLabel";
            this.playingLabel.Size = new System.Drawing.Size(41, 13);
            this.playingLabel.TabIndex = 0;
            this.playingLabel.Text = "Playing";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(205, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 136);
            this.button1.TabIndex = 1;
            this.button1.Text = "Next Song";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 93);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(187, 136);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Queue:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(301, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Feffegames";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Reset Queue";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBannedIpsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(377, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openBannedIpsToolStripMenuItem
            // 
            this.openBannedIpsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBannedSongsToolStripMenuItem,
            this.openBannedIpsToolStripMenuItem1,
            this.openVisitedIpsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveQueueToolStripMenuItem});
            this.openBannedIpsToolStripMenuItem.Name = "openBannedIpsToolStripMenuItem";
            this.openBannedIpsToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.openBannedIpsToolStripMenuItem.Text = "File";
            // 
            // openBannedSongsToolStripMenuItem
            // 
            this.openBannedSongsToolStripMenuItem.Name = "openBannedSongsToolStripMenuItem";
            this.openBannedSongsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openBannedSongsToolStripMenuItem.Text = "Open banned songs";
            this.openBannedSongsToolStripMenuItem.Click += new System.EventHandler(this.openBannedSongsToolStripMenuItem_Click);
            // 
            // openBannedIpsToolStripMenuItem1
            // 
            this.openBannedIpsToolStripMenuItem1.Name = "openBannedIpsToolStripMenuItem1";
            this.openBannedIpsToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.openBannedIpsToolStripMenuItem1.Text = "Open banned ips";
            this.openBannedIpsToolStripMenuItem1.Click += new System.EventHandler(this.openBannedIpsToolStripMenuItem1_Click);
            // 
            // openVisitedIpsToolStripMenuItem
            // 
            this.openVisitedIpsToolStripMenuItem.Name = "openVisitedIpsToolStripMenuItem";
            this.openVisitedIpsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openVisitedIpsToolStripMenuItem.Text = "Open visited ips";
            this.openVisitedIpsToolStripMenuItem.Click += new System.EventHandler(this.openVisitedIpsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // saveQueueToolStripMenuItem
            // 
            this.saveQueueToolStripMenuItem.Name = "saveQueueToolStripMenuItem";
            this.saveQueueToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveQueueToolStripMenuItem.Text = "Save Queue and exit";
            this.saveQueueToolStripMenuItem.Click += new System.EventHandler(this.saveQueueToolStripMenuItem_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(205, 69);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Pause";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 241);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.playingLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locify by Feffe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playingLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openBannedIpsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBannedSongsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBannedIpsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openVisitedIpsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveQueueToolStripMenuItem;
        private System.Windows.Forms.Button button3;
    }
}

