using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionContentAvatarNewDirectory : System.Web.UI.Page
    {
        public ActionContentAvatarNewDirectoryModel model = new ActionContentAvatarNewDirectoryModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["directory_name"]))
                return;

            model.DirectoryNameValue = Request.QueryString["directory_name"].ToString();


            model.SetValue();
        }
    }
}