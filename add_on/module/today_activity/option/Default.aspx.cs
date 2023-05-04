using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class ModuleTodayActivityOption : System.Web.UI.Page
    {
        public ModuleTodayActivityOptionModel model = new ModuleTodayActivityOptionModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveTodayActivityOption"]))
                btn_SaveTodayActivityOption_Click(sender, e);


            model.SetValue();
        }

        protected void btn_SaveTodayActivityOption_Click(object sender, EventArgs e)
        {
            model.ActiveFootPrintValue = Request.Form["cbx_ActiveFootPrint"] == "on";
            model.ActiveVisitValue = Request.Form["cbx_ActiveVisit"] == "on";
            model.ActiveNewUserValue = Request.Form["cbx_ActiveNewUser"] == "on";
            model.ActiveContactValue = Request.Form["cbx_ActiveContact"] == "on";
            model.ActiveCommentValue = Request.Form["cbx_ActiveComment"] == "on";
            model.ActiveContentValue = Request.Form["cbx_ActiveContent"] == "on";
            model.ActiveActiveContentValue = Request.Form["cbx_ActiveActiveContent"] == "on";
            model.ActiveInactiveContentValue = Request.Form["cbx_ActiveInactiveContent"] == "on";
            model.SaveTodayActivityOption();
        }
    }
}