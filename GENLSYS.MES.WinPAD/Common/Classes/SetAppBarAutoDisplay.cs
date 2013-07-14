using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace GENLSYS.MES.WinPAD.Common.Classes
{
    class AppBarAutoDisplay
    {
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public struct APPBARDATA
        {
            public int cbSize;
            public int hwnd;
            public int uCallbackMessage;
            public int uEdge;
            public RECT rc;
            public int lParam;
        }
        public const int ABS_ALWAYSONTOP = 0x002;
        public const int ABS_AUTOHIDE = 0x001;
        public const int ABS_BOTH = 0x003;
        public const int ABM_ACTIVATE = 0x006;
        public const int ABM_GETSTATE = 0x004;
        public const int ABM_GETTASKBARPOS = 0x005;
        public const int ABM_NEW = 0x000;
        public const int ABM_QUERYPOS = 0x002;
        public const int ABM_SETAUTOHIDEBAR = 0x008;
        public const int ABM_SETSTATE = 0x00A;

       

        /// 
        /// 向系统任务栏发送消息
        /// 
        [DllImport("shell32.dll")]
        public static extern int SHAppBarMessage(int dwmsg, ref APPBARDATA app);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        /// 
        /// 设置系统任务栏是否自动隐藏
        /// 
        ///  True 设置为自动隐藏，False 取消自动隐藏
        public static void SetAppBarAutoDisplay(bool IsAuto)
        {
            APPBARDATA abd = new APPBARDATA();
            abd.hwnd = FindWindow("Shell_TrayWnd", "");
            //abd.lParam = ABS_ALWAYSONTOP Or ABS_AUTOHIDE   '自动隐藏,且位于窗口前
            //abd.lParam = ABS_ALWAYSONTOP                   '不自动隐藏,且位于窗口前
            //abd.lParam = ABS_AUTOHIDE                       '自动隐藏,且不位于窗口前
            if (IsAuto)
            {
                abd.lParam = ABS_AUTOHIDE;
                SHAppBarMessage(ABM_SETSTATE, ref abd);
            }
            else
            {
                abd.lParam = ABS_ALWAYSONTOP;
                SHAppBarMessage(ABM_SETSTATE, ref abd);
            }
        } 
    }
}
