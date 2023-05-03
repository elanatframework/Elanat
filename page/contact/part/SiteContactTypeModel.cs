using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace elanat
{
    public class SiteContactTypeModel
    {
        public string TypeLanguage { get; set; }

        public string TypeOptionListValue { get; set; }
        public string TypeOptionListSelectedValue { get; set; }

        public string TypeAttribute { get; set; }

        public string TypeCssClass { get; set; }

        public void SetValue()
        {
            // Set Language
            TypeLanguage = Language.GetAddOnsLanguage("type", StaticObject.GetCurrentSiteGlobalLanguage(), StaticObject.SitePath + "page/contact/");


            ListClass lc = new ListClass();

            // Set Type Item
            lc.FillContactTypeListItem(StaticObject.GetCurrentSiteGlobalLanguage());
            TypeOptionListValue += lc.ContactTypeListItem.HtmlInputToOptionTag(TypeOptionListSelectedValue);

            if (!string.IsNullOrEmpty(TypeOptionListSelectedValue))
                TypeOptionListValue = TypeOptionListValue.HtmlInputSetSelectValue(TypeOptionListSelectedValue);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("ddlst_Type", TypeOptionListValue);

            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.SitePath + "page/contact/");

            TypeAttribute += vc.ImportantInputAttribute["ddlst_Type"];

            TypeAttribute = TypeAttribute.AddHtmlClass(vc.ImportantInputClass["ddlst_Type"]);
        }
    }
}