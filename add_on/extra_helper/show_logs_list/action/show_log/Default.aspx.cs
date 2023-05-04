using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionShowLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["log_name"]))
                return;

            string Path = StaticObject.SitePath + "App_Data/logs/" + Request.QueryString["log_name"];
            var Lines = System.IO.File.OpenText(HttpContext.Current.Server.MapPath(Path));

            string SumLine = "";
            string TmpLine = "";


            while ((TmpLine = Lines.ReadLine()) != null)
            {
                SumLine += TmpLine + "<br/>";
            }

            Response.Write(SumLine);

            Lines.Close();
        }
    }
}