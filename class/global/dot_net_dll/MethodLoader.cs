using System.Reflection;
using System.Runtime.Loader;

namespace Elanat
{
    public class MethodLoader
    {
        public string Start(string DllPath, string DllType, string DllMethod, object[] ObjectParameters = null, bool IsNonPublic = false)
        {
            Assembly Dll = Assembly.LoadFrom(DllPath);
            System.Type type = Dll.GetType(DllType);
            MethodInfo Method = Dll.GetTypes()[0].GetMethod(DllMethod);
            Object obj = Activator.CreateInstance(type);

            var ReturnValue = Method.Invoke(obj, ObjectParameters).ToString();

            return ReturnValue.ToString();
        }

        // Overload
        public void StartWithoutReturn(string DllPath, string DllType, string DllMethod, object[] ObjectParameters = null, bool IsNonPublic = false)
        {
            Assembly Dll = Assembly.LoadFrom(DllPath);
            System.Type type = Dll.GetType(DllType);
            MethodInfo Method = Dll.GetTypes()[0].GetMethod(DllMethod);
            Object obj = Activator.CreateInstance(type);

            Method.Invoke(obj, ObjectParameters);
        }

        // Overload
        public string Start(string DllPath, string DllType, string DllMethod)
        {
            return Start(DllPath, DllType, DllMethod);
        }

        // Overload
        public string Start(string DllPath, string DllType, string DllMethod, object[] ObjectParameters = null)
        {
            return Start(DllPath, DllType, DllMethod, ObjectParameters);
        }

        // Overload
        public string Start(string DllPath, string DllType, string DllMethod, bool IsNonPublic = false)
        {
            return Start(DllPath, DllType, DllMethod, null, IsNonPublic);
        }
    }
}

//using System.Reflection;
//using System.Runtime.Loader;

//namespace Elanat
//{
//    public class MethodLoader
//    {
//        public string Start(string DllPath, string DllType, string DllMethod, object[] ObjectParameters = null, bool IsNonPublic = false)
//        {
//            AssemblyLoadContext context = new AssemblyLoadContext(null, true);
//            Assembly Dll = context.LoadFromAssemblyPath(DllPath);
//            System.Type type = Dll.GetType(DllType);
//            MethodInfo Method = type.GetMethod(DllMethod, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
//            Object obj = Activator.CreateInstance(type);

//            var ReturnValue = Method.Invoke(obj, ObjectParameters).ToString();

//            return ReturnValue.ToString();
//        }

//        // Overload
//        public void StartWithoutReturn(string DllPath, string DllType, string DllMethod, object[] ObjectParameters = null, bool IsNonPublic = false)
//        {
//            AssemblyLoadContext context = new AssemblyLoadContext(null, true);
//            Assembly Dll = context.LoadFromAssemblyPath(DllPath);
//            System.Type type = Dll.GetType(DllType);
//            MethodInfo Method = type.GetMethod(DllMethod, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
//            Object obj = Activator.CreateInstance(type);

//            Method.Invoke(obj, ObjectParameters);
//        }

//        // Overload
//        public string Start(string DllPath, string DllType, string DllMethod)
//        {
//            return Start(DllPath, DllType, DllMethod);
//        }

//        // Overload
//        public string Start(string DllPath, string DllType, string DllMethod, object[] ObjectParameters = null)
//        {
//            return Start(DllPath, DllType, DllMethod, ObjectParameters);
//        }

//        // Overload
//        public string Start(string DllPath, string DllType, string DllMethod, bool IsNonPublic = false)
//        {
//            return Start(DllPath, DllType, DllMethod, null, IsNonPublic);
//        }
//    }
//}
