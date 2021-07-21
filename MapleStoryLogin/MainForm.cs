using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MapleStoryLogin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckMapleStoryExeExist();
        }

        private void CheckMapleStoryExeExist()
        {
            string directory = Directory.GetCurrentDirectory();
            bool isExist = File.Exists(directory + @"\MapleStory.exe");

            if (!isExist)
            {
                IPTextBox.Enabled = false;
                PortTextBox.Enabled = false;
            }

            SetAnnouncement(isExist ? "檢測完成" : "找不到MapleStory.exe!", !isExist);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            string ip = IPTextBox.Text;
            string port = PortTextBox.Text;

            if (!System.Net.IPAddress.TryParse(ip, out _))
            {
                SetAnnouncement("IP輸入不合法!", true);
                return;
            }

            if (!ushort.TryParse(port, out _))
            {
                SetAnnouncement("Port輸入不合法!", true);
                return;
            }

            List<string> cmds = new List<string>()
            {
                "start MapleStory.exe " + ip + " " + port
            };
            CommandOutput(cmds);
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            StartButton.Enabled = (IPTextBox.Text != "" && PortTextBox.Text != "");
        }

        private void SetAnnouncement(string announcement, bool isEmergent)
        {
            Announcement.Text = announcement;
            Announcement.ForeColor = isEmergent ? Color.Red : Color.Black;
        }
        private string CommandOutput(List<string> commandTexts)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            string strOutput = null;

            try
            {
                process.Start();

                foreach(string cmd in commandTexts)
                {
                    process.StandardInput.WriteLine(cmd);
                }
                process.StandardInput.WriteLine("exit");
                strOutput = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Close();
            }
            catch (Exception e)
            {
                strOutput = e.Message;
            }

            return strOutput;
        }
    }
}
