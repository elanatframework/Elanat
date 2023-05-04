using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class PluginDirectoryTextFile : System.Web.UI.Page
    {
        public PluginDirectoryTextFileModel model = new PluginDirectoryTextFileModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check Role Type Access
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            if (ccoc.RoleDominantType != "admin")
            {
                HttpContext.Current.Response.Redirect(StaticObject.SitePath + "page/error/401");
                return;
            }


            if (!string.IsNullOrEmpty(Request.Form["btn_Return"]))
                btn_Return_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveFile"]))
                btn_SaveFile_Click(sender, e);


            model.SetValue(Request.QueryString, Request.Form);
        }

        protected void btn_Return_Click(object sender, EventArgs e)
        {
            model.DirectoryPathValue = Request.Form["hdn_DirectoryPath"];
            model.Return();
        }

        protected void btn_SaveFile_Click(object sender, EventArgs e)
        {
            model.FileTextValue = Request.Form["txt_FileText"];
            model.DirectoryPathValue = Request.Form["hdn_DirectoryPath"];
            model.FilePathValue = Request.Form["hdn_FilePath"];
            model.SaveFile();


            model.SuccessView();
        }
    }
}