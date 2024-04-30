using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFocus
{
    class Hotkey
    {
        // I SHOULD comment more. . .
        /// <summary>
        /// Typical hotkey assigngments
        /// </summary>
        public enum fsModifiers
        {
            Alt = 0x0001,
            Control = 0x0002,
            Shift = 0x0004, 
            Window = 0x0008,
        }

        private IntPtr _hWnd;

        public Hotkey(IntPtr hWnd)
        {
            this._hWnd = hWnd;
        }

        public void RegisterHotKeys()
        {
            RegisterHotKey(_hWnd, 1, (uint)fsModifiers.Control + (uint)fsModifiers.Shift, (uint)Keys.Q);
            RegisterHotKey(_hWnd, 2, (uint)fsModifiers.Control + (uint)fsModifiers.Shift, (uint)Keys.W);
            RegisterHotKey(_hWnd, 3, (uint)fsModifiers.Control + (uint)fsModifiers.Shift, (uint)Keys.E);
            RegisterHotKey(_hWnd, 4, (uint)fsModifiers.Control + (uint)fsModifiers.Shift, (uint)Keys.A);
            RegisterHotKey(_hWnd, 10, (uint)fsModifiers.Control + (uint)fsModifiers.Shift, (uint)Keys.M);

        }

        public void UnRegisterHotKeys()
        {
            UnregisterHotKey(_hWnd, 1);
            UnregisterHotKey(_hWnd, 2);
            UnregisterHotKey(_hWnd, 3);
            UnregisterHotKey(_hWnd, 4);
            UnregisterHotKey(_hWnd, 10);
        }

        #region WindowsAPI
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        #endregion


    }
}
