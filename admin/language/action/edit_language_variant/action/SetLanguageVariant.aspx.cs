using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionSetLanguageVariant : System.Web.UI.Page
    {
        public ActionSetLanguageVariantModel model = new ActionSetLanguageVariantModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["language_character"]))
                return;

            model.LanguageCharacterValue = Request.QueryString["language_character"].ToString();


            model.SetValue();
        }
    }
}