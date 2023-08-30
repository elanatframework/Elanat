using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionCheckLockLoginController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (StaticObject.LockLogin)
            {
                Write("false");
                return;
            }

            Write("true");
        }
    }
}