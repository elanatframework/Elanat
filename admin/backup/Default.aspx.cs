using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;

namespace elanat
{
    public partial class AdminBackup : System.Web.UI.Page
    {
        public AdminBackupModel model = new AdminBackupModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_StartBackup"]))
                btn_StartBackup_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_StartUpload"]))
                btn_StartUpload_Click(sender, e);


            model.SetValue();
        }

        protected void btn_StartBackup_Click(object sender, EventArgs e)
        {
            model.DataBaseValue = Request.Form["cbx_DataBase"] == "on";
            model.AllFileAndDirectoryValue = Request.Form["cbx_AllFileAndDirectory"] == "on";
            model.ActionDirectoryValue = Request.Form["cbx_ActionDirectory"] == "on";
            model.AdminDirectoryValue = Request.Form["cbx_AdminDirectory"] == "on";
            model.AddOnDirectoryValue = Request.Form["cbx_AddOnDirectory"] == "on";
            model.AppDataDirectoryValue = Request.Form["cbx_AppDataDirectory"] == "on";
            model.BinDirectoryValue = Request.Form["cbx_BinDirectory"] == "on";
            model.ClientDirectoryValue = Request.Form["cbx_ClientDirectory"] == "on";
            model.IncludeDirectoryValue = Request.Form["cbx_IncludeDirectory"] == "on";
            model.LanguageDirectoryValue = Request.Form["cbx_LanguageDirectory"] == "on";
            model.MemberDirectoryValue = Request.Form["cbx_MemberDirectory"] == "on";
            model.PageDirectoryValue = Request.Form["cbx_PageDirectory"] == "on";
            model.TemplateDirectoryValue = Request.Form["cbx_TemplateDirectory"] == "on";
            model.UploadDirectoryValue = Request.Form["cbx_UploadDirectory"] == "on";
            model.RobotsTxtFileValue = Request.Form["cbx_RobotsTxtFile"] == "on";
            model.WebConfigFileValue = Request.Form["cbx_WebConfigFile"] == "on";

            model.StartBackup();
        }

        protected void btn_StartUpload_Click(object sender, EventArgs e)
        {
            model.BackupPathUploadValue = Request.Files["upd_BackupPath"];
            model.UseBackupPathValue = Request.Form["cbx_UseBackupPath"] == "on";
            model.BackupPathTextValue = Request.Form["txt_BackupPath"];

            model.StartUpload();
        }
    }
}