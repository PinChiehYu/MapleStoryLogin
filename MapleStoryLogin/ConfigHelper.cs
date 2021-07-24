using System.IO;

namespace MapleStoryLogin
{
    class ConfigHelper
    {
        public static string IP { get; private set; }
        public static string Port { get; private set; }
        public static bool UseDxwnd { get; private set; }

        public static void LoadConfig()
        {
            if (File.Exists(@"MSLConfig"))
            {
                StreamReader sr = new StreamReader(@"MSLConfig");
                IP = sr.ReadLine();
                Port = sr.ReadLine();
                UseDxwnd = bool.Parse(sr.ReadLine());
                sr.Close();
            }
            else
            {
                IP = "";
                Port = "";
                UseDxwnd = true;
            }
        }

        public static void SaveConfig(string ip, string port, bool useDxwnd)
        {
            StreamWriter sw = File.CreateText(@"MSLConfig");
            sw.WriteLine(ip);
            sw.WriteLine(port);
            sw.WriteLine(useDxwnd);
            sw.Close();
        }
    }
}
