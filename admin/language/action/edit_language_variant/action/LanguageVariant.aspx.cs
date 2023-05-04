using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionLanguageVariant : System.Web.UI.Page
    {
        public ActionLanguageVariantModel model = new ActionLanguageVariantModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["language_variant_value"]))
            {
                Response.Write("false");
                return;
            }

            string LanguageVariantValue = Request.QueryString["language_variant_value"];


            Response.Write(model.ViewLanguageVariant(LanguageVariantValue));
        }
    }
}