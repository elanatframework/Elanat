using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;

namespace elanat
{
    public partial class AdminLink : System.Web.UI.Page
    {
        public AdminLinkModel model = new AdminLinkModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddLink"]))
                btn_AddLink_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddLink_Click(object sender, EventArgs e)
        {
            model.LinkActiveValue = Request.Form["cbx_LinkActive"] == "on";
            model.LinkValueValue = Request.Form["txt_LinkValue"];
            model.LinkTitleValue = Request.Form["txt_LinkTitle"];
            model.LinkHrefValue = Request.Form["txt_LinkHref"];
            model.LinkProtocolOptionListSelectedValue = Request.Form["ddlst_LinkProtocol"];
            model.LinkTargetOptionListSelectedValue = Request.Form["ddlst_LinkTarget"];
            model.LinkSortIndexValue = Request.Form["txt_LinkSortIndex"];

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_LinkMenu$"))
                {
                    ListItem LinkMenu = new ListItem();

                    LinkMenu.Value = Request.Form[name];
                    LinkMenu.Selected = true;

                    model.LinkMenuListItem.Add(LinkMenu);
                }


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.AddLink();
        }
    }
}