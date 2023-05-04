using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ActionEditFileModel
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
		public bool FindEvaluateError = false;

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/");
            EditFileLanguage = aol.GetAddOnsLanguage("edit_file");
            FileNameLanguage = aol.GetAddOnsLanguage("file_name");
            FileTextLanguage = aol.GetAddOnsLanguage("file_text");
            SaveFileLanguage = aol.GetAddOnsLanguage("save_file");


            if (IsFirstStart)
            {
                if (QueryString["file_type"].ToString() != "text")
                    FileTextPanelCssClass = FileTextPanelCssClass.AddHtmlClass("el_hidden");

                FileNameValue = HttpContext.Current.Request.QueryString["file_name"].ToString();

                OldFilePathValue = QueryString["file_path"].ToString();
                OldFileNameValue = QueryString["file_name"].ToString();
                FileTypeValue = QueryString["file_type"].ToString();

                // Get Mime Type
                FileAndDirectory fad = new FileAndDirectory();
                MimeTypeValue = fad.GetMimeType(QueryString["file_path"].ToString());
            }
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_FileName", "");
            InputRequest.Add("txt_FileText", "");
            InputRequest.Add("hdn_FilePath", OldFilePathValue);
            InputRequest.Add("hdn_FileName", OldFileNameValue);
            InputRequest.Add("hdn_FileType", FileTypeValue);
            InputRequest.Add("hdn_MimeType", MimeTypeValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/file_manager/", "edit_file");

            FileNameAttribute += vc.ImportantInputAttribute["txt_FileName"];
            FileTextAttribute += vc.ImportantInputAttribute["txt_FileText"];

            FileNameCssClass = FileNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_FileName"]);
            FileTextCssClass = FileTextCssClass.AddHtmlClass(vc.ImportantInputClass["txt_FileText"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit_file", StaticObject.AdminPath + "/file_manager/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //FileNameCssClass = FileNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_FileName"]);
                //FileTextCssClass = FileTextCssClass.AddHtmlClass(vc.WarningFieldClass["txt_FileText"]);
            }
        }

        public void SaveFile()
        {
            string OldFilePath = OldFilePathValue;
            string OldFileName = OldFileNameValue;
            string NewFileName = FileNameValue;
            string NewFilePath = OldFilePath.Substring(0, OldFilePath.Length - OldFileName.Length - 1) + "/" + NewFileName;

            System.IO.File.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + OldFilePath), HttpContext.Current.Server.MapPath(StaticObject.SitePath + NewFilePath));


            if (FileTypeValue == "text")
                System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath(NewFilePath), FileTextValue);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("edit_file", HttpContext.Current.Server.MapPath("~" + OldFilePath) + "|" + HttpContext.Current.Server.MapPath("~" + NewFilePath));
        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/file_manager/action/edit_file/action/SuccessMessage.aspx", true);
        }
    }
}