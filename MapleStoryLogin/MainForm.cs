using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MapleStoryLogin
{
    public partial class MainForm : Form
    {
        string MSExeFullPath = "";
        private bool isMSExeExist = false;
        private bool isDxwndExist = false;
        private bool dxwndIsActivated = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckResourceExist();
        }

        private void CheckResourceExist()
        {
            string directory = Directory.GetCurrentDirectory();
            MSExeFullPath = directory + @"\MapleStory.exe";
            isMSExeExist = File.Exists(MSExeFullPath);

            if (!isMSExeExist)
            {
                IPTextBox.Enabled = false;
                PortTextBox.Enabled = false;
                DxwndCheckBox.Enabled = false;
                StartButton.Enabled = false;
            }
            SetAnnouncement(isMSExeExist ? "檢測完成" : "找不到MapleStory.exe", !isMSExeExist);

            isDxwndExist = File.Exists(@"dxwnd.dll");
            if (!isDxwndExist)
            {
                DxwndCheckBox.Enabled = false;
                DxwndCheckBox.Text = "找不到dxwnd.dll";
            }

            ConfigHelper.LoadConfig();

            IPTextBox.Text = ConfigHelper.IP;
            PortTextBox.Text = ConfigHelper.Port;
            if (isDxwndExist)
            {
                DxwndCheckBox.Checked = ConfigHelper.UseDxwnd;
            }
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

            if (isDxwndExist && DxwndCheckBox.Checked)
            {
                DxwndHelper.StartHooking(MSExeFullPath);
                dxwndIsActivated = true;
            }

            NotifyIcon.Visible = true;
            Hide();

            List<string> cmds = new List<string>()
            {
                "taskkill /f /im RuntimeBroker.exe",
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
            string strOutput = "";

            try
            {
                process.Start();

                foreach(string cmd in commandTexts)
                {
                    process.StandardInput.WriteLine(cmd);
                }
                process.StandardInput.WriteLine("exit");
                process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Close();
            }
            catch (Exception e)
            {
                strOutput = e.Message;
            }

            return strOutput;
        }

        private void DxwndCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DxwndCheckBox.Checked)
            {
                string dxwndVersion = DxwndHelper.GetDLLVersion();
                DxwndCheckBox.Text = "Dxwnd版本：" + dxwndVersion;
            }
            else
            {
                DxwndCheckBox.Text = "啟用視窗化";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dxwndIsActivated)
            {
                DxwndHelper.EndHooking();
            }

            ConfigHelper.SaveConfig(IPTextBox.Text, PortTextBox.Text, DxwndCheckBox.Checked);
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            NotifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
            Show();
            BringToFront();
        }
    }
}