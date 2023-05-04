using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditEditorTemplate : System.Web.UI.Page
    {
        public ActionEditEditorTemplateModel model = new ActionEditEditorTemplateModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveEditorTemplate"]))
                btn_SaveEditorTemplate_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_EditorTemplateId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["editor_template_id"]))
                    return;

                if (!Request.QueryString["editor_template_id"].ToString().IsNumber())
                    return;

                model.EditorTemplateIdValue = Request.QueryString["editor_template_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveEditorTemplate_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.EditorTemplatePathUploadValue = Request.Files["upd_EditorTemplatePath"];
            model.UseEditorTemplatePathValue = Request.Form["cbx_UseEditorTemplatePath"] == "on";
            model.EditorTemplatePathTextValue = Request.Form["txt_EditorTemplatePath"];
            model.EditorTemplateCategoryValue = Request.Form["txt_EditorTemplateCategory"];
            model.EditorTemplateActiveValue = Request.Form["cbx_EditorTemplateActive"] == "on";
            model.EditorTemplateUseLanguageValue = Request.Form["cbx_EditorTemplateUseLanguage"] == "on";
            model.EditorTemplateUseModuleValue = Request.Form["cbx_EditorTemplateUsModule"] == "on";
            model.EditorTemplateUsePluginValue = Request.Form["cbx_EditorTemplateUsePlugin"] == "on";
            model.EditorTemplateUseReplacePartValue = Request.Form["cbx_EditorTemplateUseReplacePart"] == "on";
            model.EditorTemplateUseFetchValue = Request.Form["cbx_EditorTemplateUseFetch"] == "on";
            model.EditorTemplateUseItemValue = Request.Form["cbx_EditorTemplateUseItem"] == "on";
            model.EditorTemplateUseElanatValue = Request.Form["cbx_EditorTemplateUseElanat"] == "on";
            model.EditorTemplateCacheDurationValue = Request.Form["txt_EditorTemplateCacheDuration"];
            model.EditorTemplateCacheParametersValue = Request.Form["txt_EditorTemplateCacheParameters"];
            model.EditorTemplateSortIndexValue = Request.Form["txt_EditorTemplateSortIndex"];
            model.EditorTemplatePublicAccessShowValue = Request.Form["cbx_EditorTemplatePublicAccessShow"] == "on";
            model.EditorTemplateIdValue = Request.Form["hdn_EditorTemplateId"];

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_EditorTemplateAccessShow$"))
                {
                    ListItem EditorTemplateAccessShow = new ListItem();

                    EditorTemplateAccessShow.Value = Request.Form[name];
                    EditorTemplateAccessShow.Selected = true;

                    model.EditorTemplateAccessShowListItem.Add(EditorTemplateAccessShow);
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


            model.SaveEditorTemplate();

            model.SuccessView();
        }
    }
}