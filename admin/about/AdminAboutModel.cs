using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class AdminAboutModel
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
                    GlobalClass.AlertAddOnsLanguageVariant("failed_to_load_news", StaticObject.GetCurrentAdminGlobalLanguage(), "problem", StaticObject.AdminPath + "/about/");
                    Security.SetLogError(ex);
                }


            if (string.IsNullOrEmpty(UpdateCssClass))
                UpdateCssClass = "el_hidden";
        }

        public void Update()
        {
            string ElanatSystemPath = ElanatConfig.GetNode("elanat/site_address").InnerText;
            string ElanatSystemVersion = ElanatConfig.GetNode("elanat/version").Attributes["value"].Value;

            string DotNetVersion = Environment.Version.ToString();
            string WebServerName = HttpContext.Current.Request.ServerVariables["SERVER_SOFTWARE"];

            bool BreakSupportCheck = BreakSupportCheckValue;

            XmlDocument doc = new XmlDocument();
            doc.Load(ElanatSystemPath + "/service/update/update_version_list.xml");
            XmlNodeList VersionList = doc.SelectSingleNode("update_version_root/update_version_list").ChildNodes;


            foreach (XmlNode version in VersionList)
            {
                if (float.Parse("." + ElanatSystemVersion.Replace(".", "")) >= float.Parse("." + version.Attributes["value"].Value.Replace(".", "")))
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

                bool WebServerNameExist = false;
                foreach (XmlNode iis in version["iis_version_support"].ChildNodes)
                {
                    if (iis.InnerText == WebServerName)
                    {
                        WebServerNameExist = true;
                        break;
                    }
                }

                if (DotNetVersionExist && WebServerNameExist)
                    goto Update;
                else
                {
                    if (DotNetVersionExist)
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("dot_net_version_is_not_support_new_update", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/about/"), "warning");

                    if (WebServerNameExist)
                        ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("iis_version_is_not_support_new_update", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/about/"), "warning");
                }



                Update:
                // Download Last Version
                System.Net.WebClient webClient = new System.Net.WebClient();

                string DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/"), version.Attributes["value"].Value);

                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName));

                webClient.DownloadFile(ElanatSystemPath + "/service/last_version/" + version.Attributes["value"].Value + ".zip", HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + version.Attributes["value"].Value + ".zip"));


                // Extract Zip File
                ZipFileSocket zfs = new ZipFileSocket();
                zfs.UnZip(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + version.Attributes["value"].Value + ".zip"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


                // If "root" Directory Exist
                if (Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/")))
                {
                    if (Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/")))
                        if (StaticObject.AdminDirectoryPath != "admin")
                            Directory.Move(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/" + StaticObject.AdminDirectoryPath + "/"));


                    /// <Action> Move All File In "root" Directory To Site Path
                    FileAndDirectory.DirectoryCopy(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), HttpContext.Current.Server.MapPath(StaticObject.SitePath), true, true);
                }


                File.Copy(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/update/Install.aspx"), HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/about/action/update_install/" + version.Attributes["value"].Value + ".aspx"));

                PageLoader.LoadWithServer(StaticObject.AdminPath + "about/action/update_install/" + version.Attributes["value"].Value + ".aspx");


                // Delete Physical File
                Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ElanatConfig.SetElanatConfig(version.Attributes["value"].Value, "elanat/version", 0, "value");


                // Set Keep Login
                Security sc = new Security();
                sc.SetKeepLogin(StaticObject.AdminPath, Language.GetLanguage("add_on_bin_files_has_bin_set_to_bin_directory", StaticObject.GetCurrentSiteGlobalLanguage()));


                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());
                rf.AddLocalMessage(Language.GetAddOnsLanguage("elanat_was_update", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/about/"), "success");
                rf.AddLocalMessage(version.Attributes["value"].Value, "help");
                rf.AddReturnFunction("el_KeppLoginAjaxInstall('" + version.Attributes["value"].Value + "')");


                // Add Reference
                ReferenceClass rc = new ReferenceClass();
                rc.StartEvent("update", version.Attributes["value"].Value);

                rf.RedirectToResponseFormPage();
            }

            CheckNewUpdate();
        }

        public void CheckNewUpdate()
        {
            string ElanatSystemPath = ElanatConfig.GetNode("elanat/site_address").InnerText;
            string ElanatSystemVersion = ElanatConfig.GetNode("elanat/version").Attributes["value"].Value;

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            string ElanatLastVesrsion = PageLoader.LoadForeignPage(ElanatSystemPath + "/service/last_version/");
            if (ElanatLastVesrsion == ElanatSystemVersion)
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
