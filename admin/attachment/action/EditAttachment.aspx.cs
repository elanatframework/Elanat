using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditAttachment : System.Web.UI.Page
    {
        public ActionEditAttachmentModel model = new ActionEditAttachmentModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveAttachment"]))
                btn_SaveAttachment_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_AttachmentId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["attachment_id"]))
                    return;

                if (!Request.QueryString["attachment_id"].ToString().IsNumber())
                    return;

                model.AttachmentIdValue = Request.QueryString["attachment_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveAttachment_Click(object sender, EventArgs e)
        {
            model.IsFirstStart = false;

            model.AttachmentActiveValue = Request.Form["cbx_AttachmentActive"] == "on";
            model.AttachmentPublicAccessShowValue = Request.Form["cbx_AttachmentPublicAccessShow"] == "on";
            model.AttachmentNameValue = Request.Form["txt_AttachmentName"];
            model.AttachmentPasswordValue = Request.Form["txt_AttachmentPassword"];
            model.AttachmentAboutValue = Request.Form["txt_AttachmentAbout"];
            model.AttachmentContentValue = Request.Form["txt_AttachmentContent"];
            model.AttachmentIdValue = Request.Form["hdn_AttachmentId"];
            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_AttachmentAccessShow$"))
                {
                    ListItem AttachmentAccessShow = new ListItem();

                    AttachmentAccessShow.Value = Request.Form[name];
                    AttachmentAccessShow.Selected = true;

                    model.AttachmentAccessShowListItem.Add(AttachmentAccessShow);
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


            model.SaveAttachment();

            model.SuccessView();
        }
    }
}