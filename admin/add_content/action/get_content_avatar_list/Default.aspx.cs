using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ActionGetContentAvatarList : System.Web.UI.Page
    {
        public ActionGetContentAvatarListModel model = new ActionGetContentAvatarListModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            string CurrentPath = "";

            if (!string.IsNullOrEmpty(Request.QueryString["path"]))
                CurrentPath = Request.QueryString["path"].ToString();

            model.PathValue = CurrentPath;


            model.SetValue();
        }
    }
}