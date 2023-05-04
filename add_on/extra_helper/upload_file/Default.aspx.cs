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
    public partial class ExtraHelperUploadFile : System.Web.UI.Page
    {
        public ExtraHelperUploadFileModel model = new ExtraHelperUploadFileModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_StartUpload"]))
                btn_StartUpload_Click(sender, e);


            model.SetValue();
        }

        protected void btn_StartUpload_Click(object sender, EventArgs e)
        {
            model.UseFilePathValue = Request.Form["cbx_UseFilePath"] == "on";
            model.FilePathUploadValue = Request.Files["upd_FilePath"];
            model.FilePathTextValue = Request.Form["txt_FilePath"];
            model.StartUpload();
        }
    }
}