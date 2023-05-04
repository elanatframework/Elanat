using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionGetExtraHelper : System.Web.UI.Page
    {
        public ActionGetExtraHelperModel model = new ActionGetExtraHelperModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["extra_helper_id"]))
                return;

            if (!Request.QueryString["extra_helper_id"].IsNumber())
                return;

            string ExtraHelperId = Request.QueryString["extra_helper_id"].ToString();


            // Extra Helper Access Check
            DataUse.ExtraHelper dueh = new DataUse.ExtraHelper();

            if (!dueh.GetExtraHelperAccessShowCheck(ExtraHelperId))
            {
                HttpContext.Current.Response.Redirect(StaticObject.SitePath + "page/error/401");
                return;
            }

            model.SetValue(ExtraHelperId, Request.QueryString);
        }
    }
}