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
    public partial class ActionEditGroup : System.Web.UI.Page
    {
        public ActionEditGroupModel model = new ActionEditGroupModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveGroup"]))
                btn_SaveGroup_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_GroupId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["group_id"]))
                    return;

                if (!Request.QueryString["group_id"].ToString().IsNumber())
                    return;

                model.GroupIdValue = Request.QueryString["group_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveGroup_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.GroupNameValue = Request.Form["txt_GroupName"];
            model.GroupActiveValue = Request.Form["cbx_GroupActive"] == "on";
            model.GroupIdValue = Request.Form["hdn_GroupId"];

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_GroupRole$"))
                {
                    ListItem GroupRole = new ListItem();

                    GroupRole.Value = Request.Form[name];
                    GroupRole.Selected = true;

                    model.GroupRoleListItem.Add(GroupRole);
                }


            DataUse.Group dug = new DataUse.Group();

            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_group", "group_name", model.GroupNameValue, dug.GetGroupName(model.GroupIdValue)))
            {
                model.GroupNameCssClass = model.GroupNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnErrorView();

                return;
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


            model.SaveGroup();

            model.SuccessView();
        }
    }
}