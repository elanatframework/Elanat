using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class AdminConfigurationModel : CodeBehindModel
    {
        public string ContentLanguage { get; set; }
        public string ConfigurationLanguage { get; set; }
        public string SaveConfigLanguage { get; set; }
        public string ShowAdminStaticHeadLanguage { get; set; }
        public string ShowAdminDynamicHeadLanguage { get; set; }
        public string ShowAfterLoadPathRefrenceLanguage { get; set; }
        public string ShowAuthorizedExtensionLanguage { get; set; }
        public string ShowBeforeLoadPathRefrenceLanguage { get; set; }
        public string ShowConfigLanguage { get; set; }
        public string ShowContentIconLanguage { get; set; }
        public string ShowDefaultPageLanguage { get; set; }
        public string ShowDynamicExtensionLanguage { get; set; }
        public string ShowEventReferenceLanguage { get; set; }
        public string ShowSystemLanguage { get; set; }
        public string ShowTypeLanguage { get; set; }
        public string ShowFileExtensionsLanguage { get; set; }
        public string ShowClientFileExtensionsLanguage { get; set; }
        public string ShowPageLocationLanguage { get; set; }
        public string ShowReplacePartLanguage { get; set; }
        public string ShowSiteStaticHeadLanguage { get; set; }
        public string ShowSiteDynamicHeadLanguage { get; set; }
        public string ShowWebConfigLanguage { get; set; }
        public string ShowGlobalTemplateLanguage { get; set; }
        public string ShowAdminGlobalTemplateLanguage { get; set; }
        public string ShowAdminGlobalLocationLanguage { get; set; }
        public string ShowSiteGlobalTemplateLanguage { get; set; }
        public string ShowSiteGlobalLocationLanguage { get; set; }
        public string ShowGlobalStyleLanguage { get; set; }
        public string ShowAdminGlobalStyleLanguage { get; set; }
        public string ShowSiteGlobalStyleLanguage { get; set; }
        public string ShowGlobalScriptLanguage { get; set; }
        public string ShowAdminScriptLanguage { get; set; }
        public string ShowAdminPageLoadLanguage { get; set; }
        public string ShowSiteScriptLanguage { get; set; }
        public string ShowSitePageLoadLanguage { get; set; }
        public string ShowForeignKeyLanguage { get; set; }
        public string ShowStructLanguage { get; set; }
        public string ShowRobotsLanguage { get; set; }
        public string ShowLinkProtocolLanguage { get; set; }
        public string ShowScheduledTasksLanguage { get; set; }
        public string ShowSecurityLanguage { get; set; }
        public string ShowCalendarLanguage { get; set; }
        public string ShowBoxLanguage { get; set; }
        public string ShowCaptchaLanguage { get; set; }
        public string ShowFileViewerLanguage { get; set; }
        public string ShowWysiwygLanguage { get; set; }
        public string ShowRoleBitColumnAccessLanguage { get; set; }
        public string ShowStartUpLanguage { get; set; }
        public string ShowUrlRedirectLanguage { get; set; }
        public string ShowUrlRewriteLanguage { get; set; }
        public string ConfigurationSelectedLanguage { get; set; }

        public string ConfigValue { get; set; }

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/configuration/");
            ConfigurationLanguage = aol.GetAddOnsLanguage("configuration");
            SaveConfigLanguage = aol.GetAddOnsLanguage("save_config");
            ShowAdminStaticHeadLanguage = aol.GetAddOnsLanguage("admin_static_head");
            ShowAdminDynamicHeadLanguage = aol.GetAddOnsLanguage("admin_dynamic_head");
            ShowAfterLoadPathRefrenceLanguage = aol.GetAddOnsLanguage("after_load_path_reference");
            ShowAuthorizedExtensionLanguage = aol.GetAddOnsLanguage("authorized_extension");
            ShowBeforeLoadPathRefrenceLanguage = aol.GetAddOnsLanguage("before_load_path_reference");
            ShowConfigLanguage = aol.GetAddOnsLanguage("config");
            ShowContentIconLanguage = aol.GetAddOnsLanguage("content_icon");
            ShowDefaultPageLanguage = aol.GetAddOnsLanguage("default_page");
            ShowDynamicExtensionLanguage = aol.GetAddOnsLanguage("dynamic_extension");
            ShowEventReferenceLanguage = aol.GetAddOnsLanguage("event_reference");
            ShowSystemLanguage = aol.GetAddOnsLanguage("system");
            ShowTypeLanguage = aol.GetAddOnsLanguage("type");
            ShowFileExtensionsLanguage = aol.GetAddOnsLanguage("file_extensions");
            ShowClientFileExtensionsLanguage = aol.GetAddOnsLanguage("client_file_extensions");
            ShowPageLocationLanguage = aol.GetAddOnsLanguage("page_location");
            ShowReplacePartLanguage = aol.GetAddOnsLanguage("replace_part");
            ShowSiteStaticHeadLanguage = aol.GetAddOnsLanguage("site_static_head");
            ShowSiteDynamicHeadLanguage = aol.GetAddOnsLanguage("site_dynamic_head");
            ShowWebConfigLanguage = aol.GetAddOnsLanguage("web_config");
            ShowGlobalTemplateLanguage = aol.GetAddOnsLanguage("global_template");
            ShowAdminGlobalTemplateLanguage = aol.GetAddOnsLanguage("admin_global_template");
            ShowAdminGlobalLocationLanguage = aol.GetAddOnsLanguage("admin_global_location");
            ShowSiteGlobalTemplateLanguage = aol.GetAddOnsLanguage("site_global_template");
            ShowSiteGlobalLocationLanguage = aol.GetAddOnsLanguage("site_global_location");
            ShowGlobalStyleLanguage = aol.GetAddOnsLanguage("global_style");
            ShowAdminGlobalStyleLanguage = aol.GetAddOnsLanguage("admin_global_style");
            ShowSiteGlobalStyleLanguage = aol.GetAddOnsLanguage("site_global_style");
            ShowGlobalScriptLanguage = aol.GetAddOnsLanguage("global_script");
            ShowAdminScriptLanguage = aol.GetAddOnsLanguage("admin_script");
            ShowAdminPageLoadLanguage = aol.GetAddOnsLanguage("admin_page_load");
            ShowSiteScriptLanguage = aol.GetAddOnsLanguage("site_script");
            ShowSitePageLoadLanguage = aol.GetAddOnsLanguage("site_page_load");
            ShowForeignKeyLanguage = aol.GetAddOnsLanguage("foreign_key");
            ShowStructLanguage = aol.GetAddOnsLanguage("struct");
            ShowRobotsLanguage = aol.GetAddOnsLanguage("robots");
            ShowLinkProtocolLanguage = aol.GetAddOnsLanguage("link_protocol");
            ShowScheduledTasksLanguage = aol.GetAddOnsLanguage("scheduled_tasks");
            ShowSecurityLanguage = aol.GetAddOnsLanguage("security");
            ShowCalendarLanguage = aol.GetAddOnsLanguage("calendar");
            ShowBoxLanguage = aol.GetAddOnsLanguage("box");
            ShowCaptchaLanguage = aol.GetAddOnsLanguage("captcha");
            ShowFileViewerLanguage = aol.GetAddOnsLanguage("file_viewer");
            ShowWysiwygLanguage = aol.GetAddOnsLanguage("wysiwyg");
            ShowRoleBitColumnAccessLanguage = aol.GetAddOnsLanguage("role_bit_column_access");
            ShowStartUpLanguage = aol.GetAddOnsLanguage("start_up");
            ShowUrlRedirectLanguage = aol.GetAddOnsLanguage("url_redirect");
            ShowUrlRewriteLanguage = aol.GetAddOnsLanguage("url_rewrite");
        }

        public void SaveConfig()
        {
            string CurrentConfigurationPath = StaticObject.GetSession("el_current_configuration_path");

            if (Path.GetExtension(CurrentConfigurationPath) == ".xml")
            {
                XmlDocument doc = new XmlDocument();
                doc.InnerXml = ConfigValue;
                doc.Save(StaticObject.ServerMapPath(CurrentConfigurationPath));
            }
            else if(CurrentConfigurationPath == (StaticObject.SitePath + "../Web.config"))
            {
                XmlDocument doc = new XmlDocument();
                doc.InnerXml = ConfigValue;
                doc.Save(StaticObject.ServerMapPath(CurrentConfigurationPath));
            }
            else
            {
                string[] ConfigText = ConfigValue.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                File.WriteAllLines(StaticObject.ServerMapPath(CurrentConfigurationPath), ConfigText);
            }


            // Set Static Object
            StaticObject.ApplicationStart();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_config", CurrentConfigurationPath);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("config_was_save", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/configuration/"), "success");
        }
    }
}