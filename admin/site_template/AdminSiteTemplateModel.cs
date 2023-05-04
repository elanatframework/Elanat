using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class AdminSiteTemplateModel
    {
        public string SiteTemplateLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string RefreshLanguage { get; set; }
        public string AddSiteTemplateLanguage { get; set; }
        public string SiteTemplatePathLanguage { get; set; }
        public string UseSiteTemplatePathLanguage { get; set; }
        public string SiteTemplateActiveLanguage { get; set; }

        public bool UseSiteTemplatePathValue { get; set; } = false;
        public bool SiteTemplateActiveValue { get; set; } = false;
        public HttpPostedFile SiteTemplatePathUploadValue { get; set; }
        public string SiteTemplatePathTextValue { get; set; }
        public string ContentValue { get; set; }

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/");
            SiteTemplateLanguage = aol.GetAddOnsLanguage("site_template");
            SiteTemplatePathLanguage = aol.GetAddOnsLanguage("site_template_path");
            AddSiteTemplateLanguage = aol.GetAddOnsLanguage("add_site_template");
            SiteTemplateActiveLanguage = aol.GetAddOnsLanguage("site_template_active");
            UseSiteTemplatePathLanguage = aol.GetAddOnsLanguage("use_site_template_path");
            AddLanguage = aol.GetAddOnsLanguage("add");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Site Template Page List
            ActionGetSiteTemplateListModel lm = new ActionGetSiteTemplateListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void AddSiteTemplate()
        {
            string SiteTemplateFilePhysicalName = "";
            string FileExtension = "";
            string DirectoryName = "";

            // If Use Site Template Path
            if (UseSiteTemplatePathValue)
            {
                if (string.IsNullOrEmpty(SiteTemplatePathTextValue))
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_site_template_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "problem");

                System.Net.WebClient webClient = new System.Net.WebClient();

                SiteTemplateFilePhysicalName = Path.GetFileName(SiteTemplatePathTextValue);

                FileExtension = Path.GetExtension(SiteTemplateFilePhysicalName);

                if (FileExtension != ".zip")
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "problem");

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(SiteTemplateFilePhysicalName));

                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                webClient.DownloadFile(SiteTemplatePathTextValue, HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + SiteTemplateFilePhysicalName));
            }
            else
            {
                if (!SiteTemplatePathUploadValue.HtmlInputHasFile())
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_site_template_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "problem");

                SiteTemplateFilePhysicalName = SiteTemplatePathUploadValue.FileName;

                FileExtension = Path.GetExtension(SiteTemplateFilePhysicalName);

                if (FileExtension != ".zip")
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("you_should_upload_zip_extension", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "problem");

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(SiteTemplateFilePhysicalName));

                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));
                SiteTemplatePathUploadValue.SaveAs(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + SiteTemplateFilePhysicalName));
            }

            // Check Site Template File Size
            double FileSize = new FileInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + SiteTemplateFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_site_template").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");
            }

            // Extract Zip File
            ZipFileSocket zfs = new ZipFileSocket();
            zfs.UnZip(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + SiteTemplateFilePhysicalName), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            if (!Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/site_template")))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "warning");
            }

            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/site_template/catalog.xml"));

            XmlNode SiteTemplateCatalog = CatalogDocument.SelectSingleNode("/site_template_catalog_root");


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_site_template", "site_template_name", SiteTemplateCatalog["site_template_name"].Attributes["value"].Value))
            {
                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("site_template_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "problem");
            }


            string SiteTemplateDirectoryPath = SiteTemplateCatalog["site_template_directory_path"].Attributes["value"].Value;
            SiteTemplateDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/site/"), SiteTemplateDirectoryPath);

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            if (SiteTemplateDirectoryPath != SiteTemplateCatalog["site_template_directory_path"].Attributes["value"].Value)
                rf.AddLocalMessage(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");

            // Move All Site Template File In "site_template" Directory To Site Template
            Directory.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/site_template/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/site/" + SiteTemplateDirectoryPath));

            // If "root" Directory Exist
            if (Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/")))
            {
                if (Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/")))
                    if (StaticObject.AdminDirectoryPath != "admin")
                        Directory.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/" + StaticObject.AdminDirectoryPath + "/"));


                /// <Action> Create Uninstall List
                DirectoryInfo directory = new DirectoryInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"));

                XmlDocument EmptyPaternDocument = new XmlDocument();
                EmptyPaternDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/uninstall/uninstall.xml"));

                XmlNode FilePathList = EmptyPaternDocument.SelectSingleNode("uninstall_root/file_path_list");
                                
                foreach (FileInfo file in directory.GetFiles("*.*", SearchOption.AllDirectories))
                {
                    XmlElement FilePathElement = EmptyPaternDocument.CreateElement("file_path");
                    FilePathElement.InnerText = file.FullName.Replace(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), @"\");
                    FilePathList.AppendChild(FilePathElement);
                }

                EmptyPaternDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "template/site/" + SiteTemplateDirectoryPath + "/uninstall.xml"));

                /// <Action> Move All File In "root" Directory To Site Path
                FileAndDirectory.DirectoryCopy(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + ""), true);
            }

            /// <Action> Delete Physical File
            Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Add Data To Database
            DataUse.SiteTemplate dust = new DataUse.SiteTemplate();

            dust.SiteTemplateName = SiteTemplateCatalog["site_template_name"].Attributes["value"].Value;
            dust.SiteTemplatePhysicalName = SiteTemplateCatalog["site_template_physical_name"].Attributes["value"].Value;
            dust.SiteTemplateDirectoryPath = SiteTemplateDirectoryPath;
            dust.SiteTemplateLoadTag = SiteTemplateCatalog["site_template_load_tag"].InnerText.Replace("$_asp site_path;", StaticObject.SitePath);
            dust.SiteTemplateStaticHead = SiteTemplateCatalog["site_template_static_head"].InnerText.Replace("$_asp site_path;", StaticObject.SitePath);
            dust.SiteTemplateActive = SiteTemplateActiveValue.BooleanToZeroOne();

            // Add Site Template
            dust.AddWithFillReturnDr();


            try { dust.ReturnDb.Close(); } catch (Exception) { }


            // Refill Value
            StaticObject.SetSiteTemplate();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_site_template", dust.SiteTemplateName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("site_template_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/site_template/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/site_template/action/SiteTemplateNewRow.aspx?site_template_id=" + dust.SiteTemplateId, "div_TableBox");
            rf.RedirectToResponseFormPage();
        }
    }
}