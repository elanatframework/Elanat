using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionAddContactResponse : System.Web.UI.Page
    {
        public ActionAddContactResponseModel model = new ActionAddContactResponseModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddContactResponse"]))
                btn_AddContactResponse_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_ContactId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["contact_id"]))
                    return;

                if (!Request.QueryString["contact_id"].ToString().IsNumber())
                    return;

                model.ContactIdValue = Request.QueryString["contact_id"].ToString();
            }


            model.SetValue();
        }

        protected void btn_AddContactResponse_Click(object sender, EventArgs e)
        {
            model.ContactIdValue = Request.Form["hdn_ContactId"];
            model.ContactResponseValue = Request.Form["txt_ContactResponse"];


            model.AddContactResponse();

            model.SuccessView();
        }
    }
}