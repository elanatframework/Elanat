using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionHandheldLanguageVariant : System.Web.UI.Page
    {
        public ActionHandheldLanguageVariantModel model = new ActionHandheldLanguageVariantModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["handheld_language_variant_value"]))
            {
                Response.Write("false");
                return;
            }

            string HandheldLanguageVariantValue = Request.QueryString["handheld_language_variant_value"];


            Response.Write(model.ViewHandheldLanguageVariant(HandheldLanguageVariantValue));
        }
    }
}