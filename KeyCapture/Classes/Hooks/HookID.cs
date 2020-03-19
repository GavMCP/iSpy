using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyCapture.Classes.Hooks
{
    public class HookID
    {
        public static IntPtr _hookID { get; } = IntPtr.Zero;
        //public static LowLevelKeyboardProc _proc = HookCallback;

        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        

    }
    
}
