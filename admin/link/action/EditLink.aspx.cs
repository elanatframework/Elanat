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
    public partial class ActionEditLink : System.Web.UI.Page
    {
        public ActionEditLinkModel model = new ActionEditLinkModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveLink"]))
                btn_SaveLink_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_linkId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["link_id"]))
                    return;

                if (!Request.QueryString["link_id"].ToString().IsNumber())
                    return;

                model.LinkIdValue = Request.QueryString["link_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveLink_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.LinkActiveValue = Request.Form["cbx_LinkActive"] == "on";
            model.LinkValueValue = Request.Form["txt_LinkValue"];
            model.LinkTitleValue = Request.Form["txt_LinkTitle"];
            model.LinkHrefValue = Request.Form["txt_LinkHref"];
            model.LinkRelValue = Request.Form["txt_LinkRel"];
            model.LinkProtocolOptionListSelectedValue = Request.Form["ddlst_LinkProtocol"];
            model.LinkTargetOptionListSelectedValue = Request.Form["ddlst_LinkTarget"];
            model.LinkSortIndexValue = Request.Form["txt_LinkSortIndex"];
            model.LinkIdValue = Request.Form["hdn_LinkId"];

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


            model.SaveLink();

            model.SuccessView();
        }
    }
}