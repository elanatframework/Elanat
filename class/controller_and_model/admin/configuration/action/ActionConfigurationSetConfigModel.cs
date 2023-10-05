using CodeBehind;

namespace Elanat
{
    public partial class ActionConfigurationSetConfigModel : CodeBehindModel
    {
        public string ConfigurationSelectedLanguage { get; set; }

        public string ConfigNameValue { get; set; }
        public string ConfigValue { get; set; }

        public void SetValue(HttpContext context)
        {
            SetConfigurationText(context, ConfigNameValue);
        }

        public void SetConfigurationText(HttpContext context, string ConfigurationName)
        {
            string ConfigurationPath = "";

            switch (ConfigurationName)
            {
                case "config": ConfigurationPath = StaticObject.SitePath + "App_Data/config/config.xml"; break;
                case "after_load_path_reference": ConfigurationPath = StaticObject.SitePath + "App_Data/after_load_path_reference_list/after_load_path_reference.xml"; break;
                case "authorized_extension": ConfigurationPath = StaticObject.SitePath + "App_Data/authorized_extension_list/authorized_extension.xml"; break;
                case "before_load_path_reference": ConfigurationPath = StaticObject.SitePath + "App_Data/before_load_path_reference_list/before_load_path_reference.xml"; break;
                case "content_icon": ConfigurationPath = StaticObject.SitePath + "App_Data/icon_list/icon.xml"; break;
                case "default_page": ConfigurationPath = StaticObject.SitePath + "App_Data/default_page_list/default_page.xml"; break;
                case "dynamic_extension": ConfigurationPath = StaticObject.SitePath + "App_Data/dynamic_extension_list/dynamic_extension.xml"; break;
                case "event_reference": ConfigurationPath = StaticObject.SitePath + "App_Data/event_reference_list/event_reference.xml"; break;
                case "system": ConfigurationPath = StaticObject.SitePath + "App_Data/system_list/system.xml"; break;
                case "type": ConfigurationPath = StaticObject.SitePath + "App_Data/type_list/type.xml"; break;
                case "file_extensions": ConfigurationPath = StaticObject.SitePath + "App_Data/file_extensions_list/file_extensions.xml"; break;
                case "client_file_extensions": ConfigurationPath = StaticObject.SitePath + "client/file_type_list/file_type.xml"; break;
                case "page_location": ConfigurationPath = StaticObject.SitePath + "App_Data/page_location_list/page_location.xml"; break;
                case "replace_part": ConfigurationPath = StaticObject.SitePath + "App_Data/replace_part/replace_part.xml"; break;
                case "site_static_head": ConfigurationPath = StaticObject.SitePath + "App_Data/head_list/site/static_head.xml"; break;
                case "site_dynamic_head": ConfigurationPath = StaticObject.SitePath + "App_Data/head_list/site/dynamic_head.xml"; break;
                case "admin_static_head": ConfigurationPath = StaticObject.SitePath + "App_Data/head_list/admin/static_head.xml"; break;
                case "admin_dynamic_head": ConfigurationPath = StaticObject.SitePath + "App_Data/head_list/admin/dynamic_head.xml"; break;
                case "web_config": ConfigurationPath = StaticObject.SitePath + "../Web.config"; break;
                case "global_template": ConfigurationPath = StaticObject.SitePath + "template/global.xml"; break;
                case "admin_global_template": ConfigurationPath = StaticObject.SitePath + "template/admin_global.xml"; break;
                case "admin_global_location": ConfigurationPath = StaticObject.SitePath + "template/admin_global_location.xml"; break;
                case "site_global_template": ConfigurationPath = StaticObject.SitePath + "template/site_global.xml"; break;
                case "site_global_location": ConfigurationPath = StaticObject.SitePath + "template/site_global_location.xml"; break;
                case "global_style": ConfigurationPath = StaticObject.SitePath + "client/style/global.css"; break;
                case "admin_global_style": ConfigurationPath = StaticObject.SitePath + "client/style/admin_global.css"; break;
                case "site_global_style": ConfigurationPath = StaticObject.SitePath + "client/style/site_global.css"; break;
                case "struct": ConfigurationPath = StaticObject.SitePath + "App_Data/struct/struct.xml"; break;
                case "global_script": ConfigurationPath = StaticObject.SitePath + "client/script/global.js"; break;
                case "site_script": ConfigurationPath = StaticObject.SitePath + "client/script/site/site.js"; break;
                case "admin_script": ConfigurationPath = StaticObject.SitePath + "client/script/admin/admin.js"; break;
                case "admin_page_load": ConfigurationPath = StaticObject.SitePath + "client/script/page_load/admin/page_load.js"; break;
                case "site_page_load": ConfigurationPath = StaticObject.SitePath + "client/script/page_load/site/page_load.js"; break;
                case "foreign_key": ConfigurationPath = StaticObject.SitePath + "App_Data/foreign_key/foreign_key.xml"; break;
                case "robots": ConfigurationPath = StaticObject.SitePath + "robots.txt"; break;
                case "link_protocol": ConfigurationPath = StaticObject.SitePath + "App_Data/link_protocol/link_protocol.xml"; break;
                case "scheduled_tasks": ConfigurationPath = StaticObject.SitePath + "App_Data/scheduled_tasks_list/scheduled_tasks.xml"; break;
                case "security": ConfigurationPath = StaticObject.SitePath + "App_Data/security/security.xml"; break;
                case "calendar": ConfigurationPath = StaticObject.SitePath + "App_Data/calendar_list/calendar.xml"; break;
                case "box": ConfigurationPath = StaticObject.SitePath + "App_Data/box_list/box.xml"; break;
                case "captcha": ConfigurationPath = StaticObject.SitePath + "App_Data/captcha_list/captcha.xml"; break;
                case "file_viewer": ConfigurationPath = StaticObject.SitePath + "App_Data/file_viewer_list/file_viewer.xml"; break;
                case "wysiwyg": ConfigurationPath = StaticObject.SitePath + "App_Data/wysiwyg_list/wysiwyg.xml"; break;
                case "role_bit_column_access": ConfigurationPath = StaticObject.SitePath + "App_Data/role_bit_column_access_list/role_bit_column_access.xml"; break;
                case "start_up": ConfigurationPath = StaticObject.SitePath + "App_Data/start_up_list/start_up.xml"; break;
                case "url_redirect": ConfigurationPath = StaticObject.SitePath + "App_Data/url_redirect_list/url_redirect.xml"; break;
                case "url_rewrite": ConfigurationPath = StaticObject.SitePath + "App_Data/url_rewrite_list/url_rewrite.xml"; break;

                default: return;
            }


            string[] Lines = File.ReadAllLines(StaticObject.ServerMapPath(ConfigurationPath));

            int LinesLength = Lines.Length;
            foreach (string line in Lines)
            {
                ConfigValue += line;
                if (LinesLength != 1)
                    ConfigValue += Environment.NewLine;

                LinesLength--;
            }

            ConfigurationSelectedLanguage = Language.GetAddOnsLanguage(ConfigurationName, StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/configuration/");
            context.Session.SetString("el_current_configuration_path", ConfigurationPath);

            Write(ConfigValue);
        }
    }
}