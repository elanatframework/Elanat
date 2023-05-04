using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionSetHandheldLanguageVariant : System.Web.UI.Page
    {
        public ActionSetHandheldLanguageVariantModel model = new ActionSetHandheldLanguageVariantModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["handheld_language_character"]))
                return;

            model.HandheldLanguageCharacterValue = Request.QueryString["handheld_language_character"].ToString();


            model.SetValue();
        }
    }
}