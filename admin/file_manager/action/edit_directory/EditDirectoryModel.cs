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
    public class ActionEditDirectoryModel
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
		public bool FindEvaluateError = false;

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/");
            EditDirectoryLanguage = aol.GetAddOnsLanguage("edit_directory");
            DirectoryNameLanguage = aol.GetAddOnsLanguage("directory_name");
            SaveDirectoryLanguage = aol.GetAddOnsLanguage("save_directory");


            if (IsFirstStart)
            {
                OldDirectoryNameValue = QueryString["directory_name"].ToString();
                DirectoryPathValue = QueryString["directory_path"].ToString();
                DirectoryNameValue = QueryString["directory_name"].ToString();
            }
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_DirectoryName", "");
            InputRequest.Add("hdn_DirectoryPath", DirectoryPathValue);
            InputRequest.Add("hdn_DirectoryName", OldDirectoryNameValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/file_manager/", "edit_directory");

            DirectoryNameAttribute += vc.ImportantInputAttribute["txt_DirectoryName"];

            DirectoryNameCssClass = DirectoryNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_DirectoryName"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit_directory", StaticObject.AdminPath + "/file_manager/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //DirectoryNameCssClass = DirectoryNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_DirectoryName"]);
            }
        }

        public void SaveDirectory()
        {
            string OldDirectoryPath = DirectoryPathValue;
            string OldDirectoryName = OldDirectoryNameValue;
            string NewDirectoryName = DirectoryNameValue;
            string NewDirectoryPath = OldDirectoryPath.Substring(0, OldDirectoryPath.Length - OldDirectoryName.Length - 1) + "/" + NewDirectoryName;

            System.IO.Directory.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + OldDirectoryPath), HttpContext.Current.Server.MapPath("~" + NewDirectoryPath));


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("edit_directory", HttpContext.Current.Server.MapPath(StaticObject.SitePath + OldDirectoryPath) + "|" + HttpContext.Current.Server.MapPath(StaticObject.SitePath + NewDirectoryPath));
        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/file_manager/action/edit_directory/action/SuccessMessage.aspx", true);
        }
    }
}