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
    public partial class AdminAddContent : System.Web.UI.Page
    {
        public AdminAddContentModel model = new AdminAddContentModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddContent"]))
                btn_AddContent_Click();

            if (!string.IsNullOrEmpty(Request.Form["btn_DraftContent"]))
                btn_DraftContent_Click(sender, e);

            if (!string.IsNullOrEmpty(Request.Form["btn_SaveContent"]))
                btn_SaveContent_Click(sender, e);


            if (!string.IsNullOrEmpty(Request.QueryString["content_id"]))
                if (Request.QueryString["content_id"].ToString().IsNumber())
                {
                    model.ContentIdValue = Request.QueryString["content_id"].ToString();

                    model.UseFillContent = true;

                    if (!string.IsNullOrEmpty(Request.QueryString["is_edit"]))
                        if (Request.QueryString["is_edit"].ToString() == "true")
                            model.IsEdit = true;
                }

            if (!string.IsNullOrEmpty(Request.QueryString["content_type"]))
                model.ContentTypeOptionListSelectedValue = Request.QueryString["content_type"].ToString();


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddContent_Click()
        {
            model.ContentFreeCommentsValue = Request.Form["cbx_ContentFreeComments"] == "on";
            model.ContentAlwaysOnTopValue = Request.Form["cbx_ContentAlwaysOnTop"] == "on";
            model.UseDelayPublishValue = Request.Form["cbx_UseDelayPublish"] == "on";
            model.ContentPublicAccessShowValue = Request.Form["cbx_ContentPublicAccessShow"] == "on";
            model.ContentTitleValue = Request.Form["txt_ContentTitle"];
            model.ContentTextValue = Request.Unvalidated.Form["txt_ContentText"];
            model.ContentStatusOptionListSelectedValue = Request.Form["ddlst_ContentStatus"];
            model.CategoryOptionListSelectedValue = Request.Form["ddlst_Category"];
            model.ContentTypeOptionListSelectedValue = Request.Form["ddlst_ContentType"];
            model.MetaKeywordsValue = Request.Form["txt_MetaKeywords"];
            model.ContentSourceValue = Request.Form["txt_ContentSource"];
            model.ContentPasswordValue = Request.Form["txt_ContentPassword"];
            model.DatePublishValue = Request.Form["txt_DatePublish"];
            model.TimePublishValue = Request.Form["txt_TimePublish"];
            model.ContentIconOptionListSelectedValue = Request.Form["ddlst_ContentIcon"];
            model.ContentAvatarValue = Request.Form["hdn_ContentAvatar"];
            model.ContentIdValue = Request.Form["hdn_ContentId"];
            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ContentAccessShow$"))
                {
                    ListItem ContentAccessShow = new ListItem();

                    ContentAccessShow.Value = Request.Form[name];
                    ContentAccessShow.Selected = true;

                    model.ContentAccessShowListItem.Add(ContentAccessShow);
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


            model.AddContent("active");

            model.SuccessView("add");
        }

        protected void btn_DraftContent_Click(object sender, EventArgs e)
        {
            model.ContentFreeCommentsValue = Request.Form["cbx_ContentFreeComments"] == "on";
            model.ContentAlwaysOnTopValue = Request.Form["cbx_ContentAlwaysOnTop"] == "on";
            model.UseDelayPublishValue = Request.Form["cbx_UseDelayPublish"] == "on";
            model.ContentPublicAccessShowValue = Request.Form["cbx_ContentPublicAccessShow"] == "on";
            model.ContentTitleValue = Request.Form["txt_ContentTitle"];
            model.ContentTextValue = Request.Unvalidated.Form["txt_ContentText"];
            model.ContentStatusOptionListSelectedValue = Request.Form["ddlst_ContentStatus"];
            model.CategoryOptionListSelectedValue = Request.Form["ddlst_Category"];
            model.ContentTypeOptionListSelectedValue = Request.Form["ddlst_ContentType"];
            model.MetaKeywordsValue = Request.Form["txt_MetaKeywords"];
            model.ContentSourceValue = Request.Form["txt_ContentSource"];
            model.ContentPasswordValue = Request.Form["txt_ContentPassword"];
            model.DatePublishValue = Request.Form["txt_DatePublish"];
            model.TimePublishValue = Request.Form["txt_TimePublish"];
            model.ContentIconOptionListSelectedValue = Request.Form["ddlst_ContentIcon"];
            model.ContentAvatarValue = Request.Form["hdn_ContentAvatar"];
            model.ContentIdValue = Request.Form["hdn_ContentId"];
            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ContentAccessShow$"))
                {
                    ListItem ContentAccessShow = new ListItem();

                    ContentAccessShow.Value = Request.Form[name];
                    ContentAccessShow.Selected = true;

                    model.ContentAccessShowListItem.Add(ContentAccessShow);
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


            model.AddContent("draft");

            model.SuccessView("add");
        }

        protected void btn_SaveContent_Click(object sender, EventArgs e)
        {
            model.ContentFreeCommentsValue = Request.Form["cbx_ContentFreeComments"] == "on";
            model.ContentAlwaysOnTopValue = Request.Form["cbx_ContentAlwaysOnTop"] == "on";
            model.UseDelayPublishValue = Request.Form["cbx_UseDelayPublish"] == "on";
            model.ContentPublicAccessShowValue = Request.Form["cbx_ContentPublicAccessShow"] == "on";
            model.ContentTitleValue = Request.Form["txt_ContentTitle"];
            model.ContentTextValue = Request.Unvalidated.Form["txt_ContentText"];
            model.ContentStatusOptionListSelectedValue = Request.Form["ddlst_ContentStatus"];
            model.CategoryOptionListSelectedValue = Request.Form["ddlst_Category"];
            model.ContentTypeOptionListSelectedValue = Request.Form["ddlst_ContentType"];
            model.MetaKeywordsValue = Request.Form["txt_MetaKeywords"];
            model.ContentSourceValue = Request.Form["txt_ContentSource"];
            model.ContentPasswordValue = Request.Form["txt_ContentPassword"];
            model.DatePublishValue = Request.Form["txt_DatePublish"];
            model.TimePublishValue = Request.Form["txt_TimePublish"];
            model.ContentIconOptionListSelectedValue = Request.Form["ddlst_ContentIcon"];
            model.ContentAvatarValue = Request.Form["hdn_ContentAvatar"];
            model.ContentIdValue = Request.Form["hdn_ContentId"];
            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ContentAccessShow$"))
                {
                    ListItem ContentAccessShow = new ListItem();

                    ContentAccessShow.Value = Request.Form[name];
                    ContentAccessShow.Selected = true;

                    model.ContentAccessShowListItem.Add(ContentAccessShow);
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


            model.SaveContent();

            model.SuccessView("edit");
        }
    }
}