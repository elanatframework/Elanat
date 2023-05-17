using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class AddOnLoadNativeDll : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            string FormString = Request.Form.ToString();
            string QueryString = Request.QueryString.ToString();

            Response.Write(NativeDll.NativeMethods.Main(HttpContext.Current.Server.MapPath("main.dll"), FormString, QueryString));
        }
    }
}
