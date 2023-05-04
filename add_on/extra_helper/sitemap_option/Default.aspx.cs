using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ExtraHelperSitemapOption : System.Web.UI.Page
    {
        public ExtraHelperSitemapOptionModel model = new ExtraHelperSitemapOptionModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveSitemapOption"]))
                btn_SaveSitemapOption_Click(sender, e);


            model.SetValue();
        }

        protected void btn_SaveSitemapOption_Click(object sender, EventArgs e)
        {
            model.ActiveLanguageValue = Request.Form["cbx_ActiveLanguage"] == "on";
            model.ActiveSiteValue = Request.Form["cbx_ActiveSite"] == "on";
            model.ActivePageValue = Request.Form["cbx_ActivePage"] == "on";
            model.ActiveContentTypeValue = Request.Form["cbx_ActiveContentType"] == "on";
            model.ActiveCategoryValue = Request.Form["cbx_ActiveCategory"] == "on";
            model.ActiveLinkValue = Request.Form["cbx_ActiveLink"] == "on";
            model.SaveSitemapOption();
        }
    }
}