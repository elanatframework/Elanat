using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionInactiveRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["role_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["role_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            List<string> RoleIdList = ccoc.GetRoleIdList();
            if (RoleIdList.Count == 1 && string.Join("", RoleIdList.ToArray()) == Request.QueryString["role_id"].ToString())
            {
                Response.Write("false");
                return;
            }

            DataUse.Role dur = new DataUse.Role();
            dur.Inactive(Request.QueryString["role_id"].ToString());
            Response.Write("true");


            // Refill Value
            StaticObject.SetRoleValue();


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("inactive_role", Request.QueryString["role_id"].ToString());
        }
    }
}