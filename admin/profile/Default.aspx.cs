using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace elanat
{
    public partial class AdminProfile : System.Web.UI.Page
    {
        public AdminProfileModel model = new AdminProfileModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_DeleteFootPrint"]))
                btn_DeleteFootPrint_Click(sender, e);


            model.SetValue();
        }

        protected void btn_DeleteFootPrint_Click(object sender, EventArgs e)
        {
            // Delete Access Check
            Access ac = new Access();
            if (!ac.DeleteOwnComponentAccess("foot_print"))
            {
                model.DeleteFootPrintAccessErrorView();

                return;
            }


            model.DeleteFootPrint();

            model.SuccessView();
        }
    }
}