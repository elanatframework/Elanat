using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace elanat
{
    public class ActionShowCaptchaModel
    {      
        public void SetValue()
        {
            HttpContext.Current.Response.Write(Security.GetCaptchaImage());
        }
    }
}