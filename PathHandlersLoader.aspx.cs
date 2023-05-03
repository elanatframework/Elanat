using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class PathHandlersLoader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["el_path_handlers"]))
                return;


            // Check System Access
            if (string.IsNullOrEmpty(Request.QueryString["el_system_access_code"]))
                return;

            string SystemAccessCode = Request.QueryString["el_system_access_code"].ToString();

            if (!Security.IsSystemAccess("el_system_access_code=" + SystemAccessCode))
                return;

            
            string Path = Request.QueryString["el_path_handlers"].ToString();


            string TmpQueryString = "";

            foreach (string NameValue in Request.QueryString)
                if (NameValue != "el_path_handlers" && NameValue != "el_system_access_code")
                    TmpQueryString += NameValue + "=" + Request.QueryString[NameValue].ToString() + "&";

            if (!string.IsNullOrEmpty(TmpQueryString))
                Path += (Path.Contains("?")) ? "&" + TmpQueryString.Remove(TmpQueryString.Length - 1, 1) : "?" + TmpQueryString;

            Response.Write(PageLoader.PathLoadWithServer(Path));
        }
    }
}