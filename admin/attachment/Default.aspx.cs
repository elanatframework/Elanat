using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

namespace elanat
{
    public partial class AdminAttachment : System.Web.UI.Page
    {
        public AdminAttachmentModel model = new AdminAttachmentModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddAttachment"]))
                btn_AddAttachment_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddAttachment_Click(object sender, EventArgs e)
        {
            model.AttachmentPathUploadValue = Request.Files["upd_AttachmentPath"];
            model.UseAttachmentPathValue = Request.Form["cbx_UseAttachmentPath"] == "on";
            model.AttachmentPathTextValue = Request.Form["txt_AttachmentPath"];
            model.AttachmentActiveValue = Request.Form["cbx_AttachmentActive"] == "on";
            model.AttachmentPublicAccessShowValue = Request.Form["cbx_AttachmentPublicAccessShow"] == "on";
            model.AttachmentPathTextValue = Request.Form["txt_AttachmentPath"];
            model.AttachmentNameValue = Request.Form["txt_AttachmentName"];
            model.AttachmentPasswordValue = Request.Form["txt_AttachmentPassword"];
            model.AttachmentAboutValue = Request.Form["txt_AttachmentAbout"];
            model.AttachmentContentValue = Request.Form["txt_AttachmentContent"];
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


            model.AddAttachment();
        }
    }
}