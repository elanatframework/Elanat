using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionActiveCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["category_id"]))
            {
                Response.Write("false");
                return;
            }

            if (!Request.QueryString["category_id"].ToString().IsNumber())
            {
                Response.Write("false");
                return;
            }

            DataUse.Category duc = new DataUse.Category();
            duc.Active(Request.QueryString["category_id"].ToString());


            // Re Create Category Map 
            ListClass li = new ListClass();
            li.FillSiteGlobalNameListItem();

            CategoryMap cm = new CategoryMap();

            foreach (ListItem item in li.SiteGlobalNameListItem)
                cm.CreateCategoryMap(item.Text, item.Value);


            Response.Write("true");
				
				
			// Add Reference
			ReferenceClass rc = new ReferenceClass();
			rc.StartEvent("active_category", Request.QueryString["category_id"].ToString());
        }
    }
}