using CodeBehind;

namespace Elanat
{
    public partial class ActionEditDirectoryModel : CodeBehindModel
    {
        public string EditDirectoryLanguage { get; set; }
        public string DirectoryNameLanguage { get; set; }
        public string SaveDirectoryLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public string DirectoryPathValue { get; set; }
        public string OldDirectoryNameValue { get; set; }

        public string DirectoryNameValue { get; set; }

        public string DirectoryNameAttribute { get; set; }

        public string DirectoryNameCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/");
            EditDirectoryLanguage = aol.GetAddOnsLanguage("edit_directory");
            DirectoryNameLanguage = aol.GetAddOnsLanguage("directory_name");
            SaveDirectoryLanguage = aol.GetAddOnsLanguage("save_directory");


            if (IsFirstStart)
            {
                OldDirectoryNameValue = QueryString.GetValue("directory_name");
                DirectoryPathValue = QueryString.GetValue("directory_path");
                DirectoryNameValue = QueryString.GetValue("directory_name");
            }
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_DirectoryName", "");
            InputRequest.Add("hdn_DirectoryPath", DirectoryPathValue);
            InputRequest.Add("hdn_DirectoryName", OldDirectoryNameValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/file_manager/", "edit_directory");

            DirectoryNameAttribute += vc.ImportantInputAttribute.GetValue("txt_DirectoryName");

            DirectoryNameCssClass = DirectoryNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_DirectoryName"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit_directory", StaticObject.AdminPath + "/file_manager/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveDirectory()
        {
            string OldDirectoryPath = DirectoryPathValue;
            string OldDirectoryName = OldDirectoryNameValue;
            string NewDirectoryName = DirectoryNameValue;
            string NewDirectoryPath = OldDirectoryPath.Substring(0, OldDirectoryPath.Length - OldDirectoryName.Length - 1) + "/" + NewDirectoryName;

            Directory.Move(StaticObject.ServerMapPath(OldDirectoryPath), StaticObject.ServerMapPath(NewDirectoryPath));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("edit_directory", StaticObject.ServerMapPath(StaticObject.SitePath + OldDirectoryPath) + "|" + StaticObject.ServerMapPath(StaticObject.SitePath + NewDirectoryPath));
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/file_manager/action/edit_directory/action/SuccessMessage.aspx", true);
        }
    }
}