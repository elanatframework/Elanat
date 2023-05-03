using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace elanat.NativeDll
{
    static class NativeMethodsAttribute
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr LoadLibrary(string DllPath);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr GetProcAddress(IntPtr DllPath, string MethodName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr DllPath);
    }

    class NativeMethods
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr Page_Load(IntPtr FormString, IntPtr QueryString);

        public static string Main(string DllPath, string FormString, string QueryString)
        {
            IntPtr TmpDllPath = NativeMethodsAttribute.LoadLibrary(DllPath);
            IntPtr FunctionAddressPath = NativeMethodsAttribute.GetProcAddress(TmpDllPath, "Page_Load");
            Page_Load Page_Load = (Page_Load)Marshal.GetDelegateForFunctionPointer(FunctionAddressPath, typeof(Page_Load));

            IntPtr FormStringPtr = Marshal.StringToHGlobalAnsi("FormString");
            IntPtr QueryStringPtr = Marshal.StringToHGlobalAnsi("QueryString");
            IntPtr ResultPtr = Page_Load(FormStringPtr, QueryStringPtr);

            string Result = Marshal.PtrToStringAnsi(ResultPtr);

            bool FreeLibrary = NativeMethodsAttribute.FreeLibrary(TmpDllPath);
            Marshal.FreeHGlobal(ResultPtr);
            Marshal.FreeHGlobal(FormStringPtr);
            Marshal.FreeHGlobal(QueryStringPtr);

            return Result;
        }
    }
}