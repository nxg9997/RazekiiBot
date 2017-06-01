namespace TBotGUI
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.awardBox = new System.Windows.Forms.TextBox();
            this.currBox = new System.Windows.Forms.TextBox();
            this.streamBox = new System.Windows.Forms.TextBox();
            this.oAuthBox = new System.Windows.Forms.TextBox();
            this.botBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startBot = new System.Windows.Forms.Button();
            this.stopBot = new System.Windows.Forms.Button();
            this.updateBut = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Time Until Payout in Seconds:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Points Awarded at Payout:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Currency Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Streamer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "oAuth:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bot Name:";
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(171, 182);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(100, 20);
            this.timeBox.TabIndex = 5;
            // 
            // awardBox
            // 
            this.awardBox.Location = new System.Drawing.Point(171, 156);
            this.awardBox.Name = "awardBox";
            this.awardBox.Size = new System.Drawing.Size(100, 20);
            this.awardBox.TabIndex = 4;
            // 
            // currBox
            // 
            this.currBox.Location = new System.Drawing.Point(171, 130);
            this.currBox.Name = "currBox";
            this.currBox.Size = new System.Drawing.Size(100, 20);
            this.currBox.TabIndex = 3;
            // 
            // streamBox
            // 
            this.streamBox.Location = new System.Drawing.Point(171, 104);
            this.streamBox.Name = "streamBox";
            this.streamBox.Size = new System.Drawing.Size(100, 20);
            this.streamBox.TabIndex = 2;
            this.streamBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // oAuthBox
            // 
            this.oAuthBox.Location = new System.Drawing.Point(171, 78);
            this.oAuthBox.Name = "oAuthBox";
            this.oAuthBox.Size = new System.Drawing.Size(100, 20);
            this.oAuthBox.TabIndex = 1;
            // 
            // botBox
            // 
            this.botBox.Location = new System.Drawing.Point(171, 52);
            this.botBox.Name = "botBox";
            this.botBox.Size = new System.Drawing.Size(100, 20);
            this.botBox.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(316, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addModToolStripMenuItem,
            this.addCommandToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // addModToolStripMenuItem
            // 
            this.addModToolStripMenuItem.Name = "addModToolStripMenuItem";
            this.addModToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addModToolStripMenuItem.Text = "Add Mod";
            this.addModToolStripMenuItem.Click += new System.EventHandler(this.addModToolStripMenuItem_Click);
            // 
            // addCommandToolStripMenuItem
            // 
            this.addCommandToolStripMenuItem.Name = "addCommandToolStripMenuItem";
            this.addCommandToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addCommandToolStripMenuItem.Text = "Add Command";
            this.addCommandToolStripMenuItem.Click += new System.EventHandler(this.addCommandToolStripMenuItem_Click);
            // 
            // startBot
            // 
            this.startBot.Location = new System.Drawing.Point(85, 274);
            this.startBot.Name = "startBot";
            this.startBot.Size = new System.Drawing.Size(75, 23);
            this.startBot.TabIndex = 2;
            this.startBot.Text = "Start";
            this.startBot.UseVisualStyleBackColor = true;
            this.startBot.Click += new System.EventHandler(this.startBot_Click);
            // 
            // stopBot
            // 
            this.stopBot.Enabled = false;
            this.stopBot.Location = new System.Drawing.Point(166, 274);
            this.stopBot.Name = "stopBot";
            this.stopBot.Size = new System.Drawing.Size(75, 23);
            this.stopBot.TabIndex = 3;
            this.stopBot.Text = "Stop";
            this.stopBot.UseVisualStyleBackColor = true;
            this.stopBot.Click += new System.EventHandler(this.stopBot_Click);
            // 
            // updateBut
            // 
            this.updateBut.Location = new System.Drawing.Point(184, 208);
            this.updateBut.Name = "updateBut";
            this.updateBut.Size = new System.Drawing.Size(75, 23);
            this.updateBut.TabIndex = 12;
            this.updateBut.Text = "Update";
            this.updateBut.UseVisualStyleBackColor = true;
            this.updateBut.Click += new System.EventHandler(this.updateBut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 309);
            this.Controls.Add(this.updateBut);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stopBot);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.startBot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.awardBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.currBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.streamBox);
            this.Controls.Add(this.oAuthBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Twitch Bot by NG";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox botBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.TextBox awardBox;
        private System.Windows.Forms.TextBox currBox;
        private System.Windows.Forms.TextBox streamBox;
        private System.Windows.Forms.TextBox oAuthBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCommandToolStripMenuItem;
        private System.Windows.Forms.Button startBot;
        private System.Windows.Forms.Button stopBot;
        private System.Windows.Forms.Button updateBut;
    }
}

