
namespace MapleStoryLogin
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.IPTextBoxLabel = new System.Windows.Forms.Label();
            this.PortTextBoxLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.Announcement = new System.Windows.Forms.Label();
            this.ConnectInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.DxwndCheckBox = new System.Windows.Forms.CheckBox();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ConnectInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(100, 41);
            this.IPTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(214, 27);
            this.IPTextBox.TabIndex = 1;
            this.IPTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(100, 81);
            this.PortTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(214, 27);
            this.PortTextBox.TabIndex = 2;
            this.PortTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // IPTextBoxLabel
            // 
            this.IPTextBoxLabel.AutoSize = true;
            this.IPTextBoxLabel.Location = new System.Drawing.Point(13, 44);
            this.IPTextBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IPTextBoxLabel.Name = "IPTextBoxLabel";
            this.IPTextBoxLabel.Size = new System.Drawing.Size(52, 19);
            this.IPTextBoxLabel.TabIndex = 3;
            this.IPTextBoxLabel.Text = "登入IP";
            // 
            // PortTextBoxLabel
            // 
            this.PortTextBoxLabel.AutoSize = true;
            this.PortTextBoxLabel.Location = new System.Drawing.Point(13, 85);
            this.PortTextBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PortTextBoxLabel.Name = "PortTextBoxLabel";
            this.PortTextBoxLabel.Size = new System.Drawing.Size(68, 19);
            this.PortTextBoxLabel.TabIndex = 4;
            this.PortTextBoxLabel.Text = "登入Port";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(246, 239);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(125, 32);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "啟動遊戲";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Announcement
            // 
            this.Announcement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Announcement.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Announcement.Location = new System.Drawing.Point(0, 11);
            this.Announcement.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Announcement.Name = "Announcement";
            this.Announcement.Size = new System.Drawing.Size(404, 60);
            this.Announcement.TabIndex = 5;
            this.Announcement.Text = "這裡會顯示通知";
            this.Announcement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConnectInfoGroupBox
            // 
            this.ConnectInfoGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectInfoGroupBox.Controls.Add(this.IPTextBox);
            this.ConnectInfoGroupBox.Controls.Add(this.PortTextBoxLabel);
            this.ConnectInfoGroupBox.Controls.Add(this.IPTextBoxLabel);
            this.ConnectInfoGroupBox.Controls.Add(this.PortTextBox);
            this.ConnectInfoGroupBox.Location = new System.Drawing.Point(36, 80);
            this.ConnectInfoGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectInfoGroupBox.Name = "ConnectInfoGroupBox";
            this.ConnectInfoGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.ConnectInfoGroupBox.Size = new System.Drawing.Size(334, 139);
            this.ConnectInfoGroupBox.TabIndex = 6;
            this.ConnectInfoGroupBox.TabStop = false;
            this.ConnectInfoGroupBox.Text = "連線資料";
            // 
            // DxwndCheckBox
            // 
            this.DxwndCheckBox.AutoSize = true;
            this.DxwndCheckBox.Location = new System.Drawing.Point(36, 245);
            this.DxwndCheckBox.Name = "DxwndCheckBox";
            this.DxwndCheckBox.Size = new System.Drawing.Size(76, 23);
            this.DxwndCheckBox.TabIndex = 7;
            this.DxwndCheckBox.Text = "視窗化";
            this.DxwndCheckBox.UseVisualStyleBackColor = true;
            this.DxwndCheckBox.CheckedChanged += new System.EventHandler(this.DxwndCheckBox_CheckedChanged);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "楓之谷啟動器";
            this.NotifyIcon.Visible = false;
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 293);
            this.Controls.Add(this.DxwndCheckBox);
            this.Controls.Add(this.ConnectInfoGroupBox);
            this.Controls.Add(this.Announcement);
            this.Controls.Add(this.StartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "楓之谷啟動器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ConnectInfoGroupBox.ResumeLayout(false);
            this.ConnectInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.Label IPTextBoxLabel;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label PortTextBoxLabel;
        private System.Windows.Forms.GroupBox ConnectInfoGroupBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label Announcement;
        private System.Windows.Forms.CheckBox DxwndCheckBox;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
    }
}

