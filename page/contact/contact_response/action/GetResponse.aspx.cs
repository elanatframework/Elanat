using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionSiteGetResponse : System.Web.UI.Page
    {
        public ActionSiteGetResponseModel model = new ActionSiteGetResponseModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["el_contact_response_text"] != null)
                model.SetValue();
        }
    }
}