using CodeBehind;

namespace Elanat
{
    public partial class ActionEditFileModel : CodeBehindModel
    {
        public string EditFileLanguage { get; set; }
        public string FileNameLanguage { get; set; }
        public string FileTextLanguage { get; set; }
        public string SaveFileLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public string OldFilePathValue { get; set; }
        public string OldFileNameValue { get; set; }
        public string FileTypeValue { get; set; }
        public string MimeTypeValue { get; set; }

        public string FileNameValue { get; set; }
        public string FileTextValue { get; set; }

        public string FileNameAttribute { get; set; }
        public string FileTextAttribute { get; set; }

        public string FileNameCssClass { get; set; }
        public string FileTextCssClass { get; set; }
        public string FileTextPanelCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/");
            EditFileLanguage = aol.GetAddOnsLanguage("edit_file");
            FileNameLanguage = aol.GetAddOnsLanguage("file_name");
            FileTextLanguage = aol.GetAddOnsLanguage("file_text");
            SaveFileLanguage = aol.GetAddOnsLanguage("save_file");


            if (IsFirstStart)
            {
                if (QueryString.GetValue("file_type") != "text")
                    FileTextPanelCssClass = FileTextPanelCssClass.AddHtmlClass("el_hidden");

                FileNameValue = QueryString.GetValue("file_name");

                OldFilePathValue = QueryString.GetValue("file_path");
                OldFileNameValue = QueryString.GetValue("file_name");
                FileTypeValue = QueryString.GetValue("file_type");

                // Get Mime Type
                FileAndDirectory fad = new FileAndDirectory();
                MimeTypeValue = fad.GetMimeType(QueryString.GetValue("file_path"));
            }
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_FileName", "");
            InputRequest.Add("txt_FileText", "");
            InputRequest.Add("hdn_FilePath", OldFilePathValue);
            InputRequest.Add("hdn_FileName", OldFileNameValue);
            InputRequest.Add("hdn_FileType", FileTypeValue);
            InputRequest.Add("hdn_MimeType", MimeTypeValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/file_manager/", "edit_file");

            FileNameAttribute += vc.ImportantInputAttribute.GetValue("txt_FileName");
            FileTextAttribute += vc.ImportantInputAttribute.GetValue("txt_FileText");

            FileNameCssClass = FileNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FileName"));
            FileTextCssClass = FileTextCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_FileText"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit_file", StaticObject.AdminPath + "/file_manager/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveFile()
        {
            string OldFilePath = OldFilePathValue;
            string OldFileName = OldFileNameValue;
            string NewFileName = FileNameValue;
            string NewFilePath = OldFilePath.Substring(0, OldFilePath.Length - OldFileName.Length - 1) + "/" + NewFileName;

            File.Move(StaticObject.ServerMapPath(OldFilePath), StaticObject.ServerMapPath(NewFilePath));


            if (FileTypeValue == "text")
                File.WriteAllText(StaticObject.ServerMapPath(NewFilePath), FileTextValue);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("edit_file", StaticObject.ServerMapPath(OldFilePath) + "|" + StaticObject.ServerMapPath(NewFilePath));
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/file_manager/action/edit_file/action/SuccessMessage.aspx", true);
        }
    }
}