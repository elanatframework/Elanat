using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionModuleMenuQueryString : System.Web.UI.Page
    {
        public ActionModuleMenuQueryStringModel model = new ActionModuleMenuQueryStringModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["menu_value"]))
            {
                Response.Write("false");
                return;
            }

            if (string.IsNullOrEmpty(Request.QueryString["menu_name"]))
            {
                Response.Write("false");
                return;
            }

            string MenuValue = Request.QueryString["menu_value"];
            string MenuName = Request.QueryString["menu_name"];


            Response.Write(model.ViewModuleMenuQueryString(MenuName, MenuValue));
        }
    }
}