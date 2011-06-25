﻿using System;
using System.Runtime.InteropServices;

namespace Jedi
{
    internal class NativeHelpers
    {
        public static string ActiveApplTitle()
        {
            IntPtr hwnd = GetforegroundWindow();
            if (hwnd.Equals(IntPtr.Zero))
            {
                return "";
            }
            string lpString = new string('\0', 100);
            int num = GetWindowText(hwnd, lpString, lpString.Length);
            if ((num > 0) && (num <= lpString.Length))
            {
                return lpString.Trim();
            }
            return "unknown";
        }

        public static IntPtr GetforegroundWindow()
        {
            return GetForegroundWindow();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetForegroundWindow();
        public static int GetWindowProcessId(IntPtr hwnd)
        {
            int num;
            GetWindowThreadProcessId(hwnd, out num);
            return num;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hwnd, string lpString, int cch);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
    }
}