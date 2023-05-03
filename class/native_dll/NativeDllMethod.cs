using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace elanat.NativeDllReplace
{
    public class NativeMethods
    {
        static NativeMethods()
        {
            string DllPath = HttpContext.Current.Server.MapPath(StaticObject.SitePath + "bin/Replace.dll");

            TmpReplace = (Replace)
                NativeMethods.LoadFunction<Replace>(DllPath, "Replace");
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibrary(string path);

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        public static Delegate LoadFunction<T>(string dllPath, string functionName)
        {
            var hModule = LoadLibrary(dllPath);
            var functionAddress = GetProcAddress(hModule, functionName);
            return Marshal.GetDelegateForFunctionPointer(functionAddress, typeof(T));
        }

        private delegate IntPtr Replace(IntPtr TextStringPtr, IntPtr OldTextStringPtr, IntPtr NewTextStringPtr);

        static private Replace TmpReplace;

        public string NativeReplace(string Text, string OldText, string NewText)
        {
            string ReturnValue = null;

            try
            {
                IntPtr TextStringPtr = Marshal.StringToHGlobalAnsi(Text);
                IntPtr OldTextStringPtr = Marshal.StringToHGlobalAnsi(OldText);
                IntPtr NewTextStringPtr = Marshal.StringToHGlobalAnsi(NewText);

                IntPtr ReplaceValue = TmpReplace(TextStringPtr, OldTextStringPtr, NewTextStringPtr);

                ReturnValue = Marshal.PtrToStringAnsi(ReplaceValue);

                //Marshal.FreeHGlobal(ReplaceValue);

            }
            catch (Exception ex)
            {
                Security.SetLogError(ex);
            }

            return ReturnValue;
        }
    }
}