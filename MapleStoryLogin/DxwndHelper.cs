using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MapleStoryLogin
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct TARGETMAP
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string path;
        public int dxversion;
        public int flags;
        public int initx;
        public int inity;
        public int minx;
        public int miny;
        public int maxx;
        public int maxy;
    };

    public unsafe class DxwndHelper
    {
        [DllImport(@"dxwnd.dll", EntryPoint = "SetTarget")]
        private static extern int SetTarget(TARGETMAP[] tgmaps);
        [DllImport(@"dxwnd.dll", EntryPoint = "StartHook")]
        private static extern int StartHook();
        [DllImport(@"dxwnd.dll", EntryPoint = "EndHook")]
        private static extern int EndHook();
        [DllImport(@"dxwnd.dll", EntryPoint = "GetDllVersion")]
        private static extern void GetDllVersion(IntPtr dest);

        public static void StartHooking(string exeFullPath)
        {
            MessageBox.Show("目標路徑：" + exeFullPath);

            TARGETMAP[] maps = new TARGETMAP[256];
            maps[0] = new TARGETMAP
            {
                path = exeFullPath,
                dxversion = 8,
                flags = 0,
                initx = 0,
                inity = 0,
                minx = 0,
                miny = 0,
                maxx = 639,
                maxy = 479
            };

            SetTarget(maps);
            StartHook();
        }

        public static void EndHooking()
        {
            EndHook();
        }

        public static string GetDLLVersion()
        {
            byte[] version = new byte[20];
            var handle = GCHandle.Alloc(version, GCHandleType.Pinned);
            IntPtr ptr = handle.AddrOfPinnedObject();

            GetDllVersion(ptr);

            string result = Marshal.PtrToStringAnsi(ptr);

            if (handle.IsAllocated) handle.Free();

            return result;
        }
    }
}
