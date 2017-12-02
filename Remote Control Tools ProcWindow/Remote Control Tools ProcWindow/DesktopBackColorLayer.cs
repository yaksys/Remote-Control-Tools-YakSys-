using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Remote_Control_Tools_ProcWindow
{
    class DesktopBackColorLayer
    {
        [DllImport("user32.dll")]
        public static extern bool SetSysColors(int cElements, int[] lpaElements, uint[] lpaRgbValues);

        const int COLOR_DESKTOP = 1;

        uint RGB(byte byRed, byte byGreen, byte byBlue)
        {
            uint res = byBlue;
            res = res << 8;
            res += byGreen;
            res = res << 8;
            res += byRed;
            return res;
        }

        public void SetBackgroundColor(uint[] Colors)
        {
            int[] aiElements = { COLOR_DESKTOP };
            uint[] aColors = { RGB(0x00, 0x80, 0x00) };

            SetSysColors(1, aiElements, aColors);
        }
    }
}
