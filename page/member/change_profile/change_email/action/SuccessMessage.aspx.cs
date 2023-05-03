﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionMemberChangeEmailSuccessMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalClass.AlertAddOnsLanguageVariant("email_was_change", StaticObject.GetCurrentSiteGlobalLanguage(), "success", StaticObject.SitePath + "page/member/change_profile/change_email/");

            string LinkTemplate = Template.GetSiteTemplate("link/common");

            string TmpLinkTemplate = LinkTemplate;

            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", Language.GetLanguage("return_to_main_page", StaticObject.GetCurrentSiteGlobalLanguage()));
            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", Language.GetLanguage("return_to_main_page", StaticObject.GetCurrentSiteGlobalLanguage()));
            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", StaticObject.SitePath);

            GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentSiteGlobalLanguage(), "help");
        }
    }
}