using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MapleStoryLogin
{
    [StructLayout(LayoutKind.Sequential)]
    struct TARGETMAP
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
        [DllImport(@".\dxwnd.dll", EntryPoint = "SetTarget")]
        private static extern void SetTarget(string msg);
        [DllImport(@".\dxwnd.dll", EntryPoint = "StartHook")]
        private static extern void StartHook(ref TARGETMAP tgmap);
        [DllImport(@".\dxwnd.dll", EntryPoint = "EndHook")]
        private static extern void EndHook();
        [DllImport(@".\dxwnd.dll", EntryPoint = "GetDllVersion")]
        private static extern void GetDllVersion(IntPtr dest);

        public static bool CheckDLLExist()
        {
            return File.Exists(@".\dxwnd.dll");
        }

        public static void StartHooking(string exeFullPath)
        {
            TARGETMAP map = new TARGETMAP
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
            
            StartHook(ref map);
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
