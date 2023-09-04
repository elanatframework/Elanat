using CodeBehind;
using SetCodeBehind;
using System.Diagnostics;
using System.Xml;

namespace Elanat
{
    public partial class AdminAboutModel : CodeBehindModel
    {
        public string AboutLanguage { get; set; }
        public string AboutElanatLanguage { get; set; }
        public string VersionLanguage { get; set; }
        public string LicenceLanguage { get; set; }
        public string ElanatSiteLanguage { get; set; }
        public string CheckNewUpdateLanguage { get; set; }

        public string AboutElanatLanguageValue { get; set; }
        public string VersionValue { get; set; }
        public string LicenceValue { get; set; }
        public string ElanatSiteValue { get; set; }
        public string ElanatNewsValue { get; set; }

        public string UpdateCssClass { get; set; }

        public bool BreakSupportCheckValue { get; set; } = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/about/");
            AboutLanguage = aol.GetAddOnsLanguage("about");
            AboutElanatLanguage = aol.GetAddOnsLanguage("about_elanat");
            VersionLanguage = aol.GetAddOnsLanguage("version");
            LicenceLanguage = aol.GetAddOnsLanguage("licenses");
            ElanatSiteLanguage = aol.GetAddOnsLanguage("elanat_site");
            CheckNewUpdateLanguage = aol.GetAddOnsLanguage("check_new_update");

            AboutElanatLanguageValue = aol.GetAddOnsLanguage("__about_elanat");


            // Set Template
            string SiteTemplate = Template.GetAdminGlobalTemplate("part/site_address");

            SiteTemplate = SiteTemplate.Replace("$_asp site_address;", ElanatConfig.GetNode("elanat/site_address").InnerText);
            SiteTemplate = SiteTemplate.Replace("$_lang site;", aol.GetAddOnsLanguage("site"));

            ElanatSiteValue = SiteTemplate;

            LicenceValue = ElanatConfig.GetNode("elanat/licenses").Attributes["value"].Value;
            VersionValue = ElanatConfig.GetNode("elanat/version").Attributes["value"].Value;

            string NewsAddress = ElanatConfig.GetNode("elanat/news_address").InnerText;

            if (ElanatConfig.GetNode("elanat/news_address").Attributes["active"].Value == "true")
                try
                {
                    ElanatNewsValue = PageLoader.LoadForeignPage(NewsAddress);
                }
                catch (Exception ex)
                {
                    Write(GlobalClass.AlertAddOnsLanguageVariant("failed_to_load_news", StaticObject.GetCurrentAdminGlobalLanguage(), "problem", StaticObject.AdminPath + "/about/"));
                    Security.SetLogError(ex);
                }


            if (string.IsNullOrEmpty(UpdateCssClass))
                UpdateCssClass = "el_hidden";
        }

        public void Update(HttpContext context)
        {
            string ElanatSystemPath = ElanatConfig.GetNode("elanat/site_address").InnerText;
            string ElanatSystemVersion = ElanatConfig.GetNode("elanat/version").Attributes["value"].Value;

            string DotNetVersion = Environment.Version.ToString();

            bool BreakSupportCheck = BreakSupportCheckValue;

            XmlDocument doc = new XmlDocument();
            doc.Load(ElanatSystemPath + "/service/update/update_version_list.xml");
            XmlNodeList VersionList = doc.SelectSingleNode("update_version_root/update_version_list").ChildNodes;


            foreach (XmlNode version in VersionList)
            {
                if (int.Parse(ElanatSystemVersion.Replace(".", "")) >= int.Parse(version.Attributes["value"].Value.Replace(".", "")))
                    continue;

                if (BreakSupportCheck)
                    goto Update;

                bool DotNetVersionExist = false;
                foreach (XmlNode DotNet in version["dot_net_version_support"].ChildNodes)
                {
                    if (DotNet.InnerText == DotNetVersion)
                    {
                        DotNetVersionExist = true;
                        break;
                    }
                }

                if (DotNetVersionExist)
                    goto Update;
                else
                {
                    if (DotNetVersionExist)
                    {
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("dot_net_version_is_not_support_new_update", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/about/"), "warning");

                        return;
                    }
                }



                Update:
                // Download Last Version
                HttpClient webClient = new HttpClient();

                string DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), version.Attributes["value"].Value);

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));

                webClient.DownloadFile(ElanatSystemPath + "/service/last_version/" + version.Attributes["value"].Value + ".zip", StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + version.Attributes["value"].Value + ".zip"));


                // Extract Zip File
                ZipFileClass zfc = new ZipFileClass();
                zfc.UnZip(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + version.Attributes["value"].Value + ".zip"), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


                // If "root" Directory Exist
                if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/")))
                {
                    if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/")))
                        if (StaticObject.AdminDirectoryPath != "admin")
                            Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/"), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/" + StaticObject.AdminDirectoryPath + "/"));


                    if (File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/bin/Elanat.dll")))
                        File.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/bin/Elanat.dll"), AppContext.BaseDirectory + "/ElanatUpdate.dll", true);


                    /// <Action> Move All File In "root" Directory To Site Path
                    FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), StaticObject.ServerMapPath(StaticObject.SitePath), true, true);
                }


                File.Copy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/update/Install.aspx"), StaticObject.ServerMapPath(StaticObject.AdminPath + "/about/action/update_install/" + version.Attributes["value"].Value + ".aspx"), true);


                // Recompile
                CodeBehindCompiler.Initialization();
                CodeBehindCompiler.CompileAspx();


                PageLoader.LoadWithServer(StaticObject.AdminPath + "/about/action/update_install/" + version.Attributes["value"].Value + ".aspx");


                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


                // Set Keep Login
                Security sc = new Security();
                sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("add_on_bin_files_has_bin_set_to_bin_directory", StaticObject.GetCurrentSiteGlobalLanguage()));


                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());
                rf.AddLocalMessage(Language.GetAddOnsLanguage("elanat_was_update", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/about/"), "success");
                rf.AddLocalMessage(version.Attributes["value"].Value, "help");

                if (File.Exists(AppContext.BaseDirectory + "/ElanatUpdate.dll"))
                {
                    File.Move(AppContext.BaseDirectory + "/Elanat.dll", AppContext.BaseDirectory + "/ElanatPreviousVersion.dll", true);

                    File.Move(AppContext.BaseDirectory + "/ElanatUpdate.dll", AppContext.BaseDirectory + "/Elanat.dll", true);


                    // Set Reload Elanat
                    rf.AddReturnFunction("el_StartReloadElanat()");
                }

                rf.AddReturnFunction("el_KeppLoginAjax()");

                // Add Reference
                ReferenceClass rc = new ReferenceClass();
                rc.StartEvent("update", version.Attributes["value"].Value);

                rf.RedirectToResponseFormPage();
                return;
            }

            CheckNewUpdate();
        }

        public void CheckNewUpdate()
        {
            string ElanatSystemPath = ElanatConfig.GetNode("elanat/site_address").InnerText;
            string ElanatSystemVersion = ElanatConfig.GetNode("elanat/version").Attributes["value"].Value;

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            string ElanatLastVesrsion = PageLoader.LoadForeignPage(ElanatSystemPath + "/service/last_version/");
            if (int.Parse(ElanatSystemVersion.Replace(".", "")) >= int.Parse(ElanatLastVesrsion.Replace(".", "")))
                rf.AddLocalMessage(Language.GetAddOnsLanguage("is_up_to_date", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/about/").Replace("$_asp elanat_system_version;", ElanatLastVesrsion), "success");
            else
            {
                rf.AddLocalMessage(Language.GetAddOnsLanguage("update_is_available", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/about/").Replace("$_asp elanat_system_version;", ElanatLastVesrsion), "success");
                rf.AddPageLoad(StaticObject.AdminPath + "/about/action/NewUpdate.aspx", "div_Update");
                rf.AddReturnFunction("el_RemoveTag('btn_CheckNewUpdate')");
            }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("check_new_update", DateAndTime.GetDate("yyyy/MM/dd HH:mm:ss"));

            rf.RedirectToResponseFormPage();
        }
    }
}