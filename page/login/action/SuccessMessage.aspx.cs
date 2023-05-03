using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionSiteLoginSuccessMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/login/");

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

            // Set Alert Template
            string AdminDirectoryPath = StaticObject.AdminPath;
            string LinkTemplate = Template.GetSiteTemplate("link/common");
            string TmpLinkTemplate = "";

            string SietLogoTemplate = Template.GetGlobalTemplate("part/site_logo", StaticObject.GetCurrentSiteGlobalLanguage());
            Response.Write(SietLogoTemplate);

            if (!string.IsNullOrEmpty(Request.QueryString["el_return_url"]))
            {
                TmpLinkTemplate = LinkTemplate;

                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", aol.GetAddOnsLanguage("previous_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", aol.GetAddOnsLanguage("previous_page"));
                TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", StaticObject.SitePath + Request.QueryString["el_return_url"].ToString());

                GlobalClass.Alert(aol.GetAddOnsLanguage("signed_successfully_click_in_the_below_link_to_return_to_the_previous_page"), StaticObject.GetCurrentSiteGlobalLanguage(), "success");
                GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage());


                if (ccoc.RoleDominantType == "admin")
                {
                    TmpLinkTemplate = LinkTemplate;

                    TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", aol.GetAddOnsLanguage("admin_page"));
                    TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", aol.GetAddOnsLanguage("admin_page"));
                    TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", AdminDirectoryPath);

                    GlobalClass.Alert(aol.GetAddOnsLanguage("or_click_in_the_below_link_to_go_to_the_admin_page"), StaticObject.GetCurrentSiteGlobalLanguage(), "success");
                    GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage());
                }
            }
            else
            {
                if (ccoc.RoleDominantType != "admin")
                {
                    TmpLinkTemplate = LinkTemplate;

                    TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", aol.GetAddOnsLanguage("main_page"));
                    TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", aol.GetAddOnsLanguage("main_page"));
                    TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", StaticObject.SitePath);

                    GlobalClass.Alert(aol.GetAddOnsLanguage("signed_successfully_click_in_the_below_link_to_go_to_the_main_page"), StaticObject.GetCurrentSiteGlobalLanguage(), "success");
                    GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage());
                }
                else
                {
                    TmpLinkTemplate = LinkTemplate;

                    TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", aol.GetAddOnsLanguage("main_page"));
                    TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", aol.GetAddOnsLanguage("main_page"));
                    TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", StaticObject.SitePath);

                    GlobalClass.Alert(aol.GetAddOnsLanguage("signed_successfully_click_in_the_below_link_to_go_to_the_main_page"), StaticObject.GetCurrentSiteGlobalLanguage(), "success");
                    GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage());


                    TmpLinkTemplate = LinkTemplate;

                    TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", aol.GetAddOnsLanguage("admin_page"));
                    TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", aol.GetAddOnsLanguage("admin_page"));
                    TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", AdminDirectoryPath);

                    GlobalClass.Alert(aol.GetAddOnsLanguage("or_click_in_the_below_link_to_go_to_the_admin_page"), StaticObject.GetCurrentSiteGlobalLanguage(), "success");
                    GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage());
                }
            }
        }
    }
}