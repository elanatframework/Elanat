using CodeBehind;

namespace Elanat
{
    public partial class AdminBackupController : CodeBehindController
    {
        public AdminBackupModel model = new AdminBackupModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_StartBackup"]))
            {
                btn_StartBackup_Click(context);
                return;
            }

            if (!string.IsNullOrEmpty(context.Request.Form["btn_StartUpload"]))
            {
                btn_StartUpload_Click(context);
                return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_StartBackup_Click(HttpContext context)
        {
            model.DataBaseValue = context.Request.Form["cbx_DataBase"] == "on";
            model.AllFileAndDirectoryValue = context.Request.Form["cbx_AllFileAndDirectory"] == "on";
            model.ActionDirectoryValue = context.Request.Form["cbx_ActionDirectory"] == "on";
            model.AdminDirectoryValue = context.Request.Form["cbx_AdminDirectory"] == "on";
            model.AddOnDirectoryValue = context.Request.Form["cbx_AddOnDirectory"] == "on";
            model.AppDataDirectoryValue = context.Request.Form["cbx_AppDataDirectory"] == "on";
            model.BinDirectoryValue = context.Request.Form["cbx_BinDirectory"] == "on";
            model.ClientDirectoryValue = context.Request.Form["cbx_ClientDirectory"] == "on";
            model.IncludeDirectoryValue = context.Request.Form["cbx_IncludeDirectory"] == "on";
            model.LanguageDirectoryValue = context.Request.Form["cbx_LanguageDirectory"] == "on";
            model.MemberDirectoryValue = context.Request.Form["cbx_MemberDirectory"] == "on";
            model.PageDirectoryValue = context.Request.Form["cbx_PageDirectory"] == "on";
            model.TemplateDirectoryValue = context.Request.Form["cbx_TemplateDirectory"] == "on";
            model.UploadDirectoryValue = context.Request.Form["cbx_UploadDirectory"] == "on";
            model.RobotsTxtFileValue = context.Request.Form["cbx_RobotsTxtFile"] == "on";

            model.StartBackup();

            View(model);
        }

        protected void btn_StartUpload_Click(HttpContext context)
        {
            model.BackupPathUploadValue = context.Request.Form.Files["upd_BackupPath"];
            model.UseBackupPathValue = context.Request.Form["cbx_UseBackupPath"] == "on";
            model.BackupPathTextValue = context.Request.Form["txt_BackupPath"];

            model.StartUpload();

            View(model);
        }
    }
}