using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowFocus
{
    partial class Form1
    {
        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String sClassName, String sAppName);

        // Import the necessary functions from the Windows API
        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        // Import the ShowWindow function
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        [DllImport("user32.dll")]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);



        // Define constants for messages and parameters
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        // Define constants
        public const uint SWP_NOSIZE = 0x0001;
        public const uint SWP_NOZORDER = 0x0004;
        // Define constants for different window states
        public const int SW_SHOWNORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int WM_HOTKEY = 0x312;

        // Define the RECT structure
        struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        public static void MinimizeWindow(IntPtr windowHandle)
        {
            // Call ShowWindow with SW_SHOWMINIMIZED to minimize the window
            ShowWindow(windowHandle, SW_SHOWMINIMIZED);
        }

        public static void MaximizeWindow(IntPtr windowHandle)
        {
            // Call ShowWindow with SW_SHOWMAXIMIZED to maximize the window
            ShowWindow(windowHandle, SW_SHOWMAXIMIZED);
        }

        public static void RestoreWindow(IntPtr windowHandle)
        {
            // Call ShowWindow with SW_SHOWNORMAL to restore the window to its normal state
            ShowWindow(windowHandle, SW_SHOWNORMAL);
        }


    }
}
