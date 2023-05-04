using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionViewModuleOption : System.Web.UI.Page
    {
        public ActionViewModuleOptionModel model = new ActionViewModuleOptionModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["module_id"]))
            {
                Response.Write("false");
                return;
            }

            string ModuleId = Request.QueryString["module_id"];


            if (!Request.QueryString["module_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }


            Response.Write(model.ViewModuleOption(ModuleId));
        }
    }
}