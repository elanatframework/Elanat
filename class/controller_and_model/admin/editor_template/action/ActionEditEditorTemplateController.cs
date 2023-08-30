using CodeBehind;

namespace Elanat
{
    public partial class ActionEditEditorTemplateController : CodeBehindController
    {
        public ActionEditEditorTemplateModel model = new ActionEditEditorTemplateModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveEditorTemplate"]))
            {
                btn_SaveEditorTemplate_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_EditorTemplateId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["editor_template_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["editor_template_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.EditorTemplateIdValue = context.Request.Query["editor_template_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveEditorTemplate_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.EditorTemplatePathUploadValue = context.Request.Form.Files["upd_EditorTemplatePath"];
            model.UseEditorTemplatePathValue = context.Request.Form["cbx_UseEditorTemplatePath"] == "on";
            model.EditorTemplatePathTextValue = context.Request.Form["txt_EditorTemplatePath"];
            model.EditorTemplateCategoryValue = context.Request.Form["txt_EditorTemplateCategory"];
            model.EditorTemplateActiveValue = context.Request.Form["cbx_EditorTemplateActive"] == "on";
            model.EditorTemplateUseLanguageValue = context.Request.Form["cbx_EditorTemplateUseLanguage"] == "on";
            model.EditorTemplateUseModuleValue = context.Request.Form["cbx_EditorTemplateUsModule"] == "on";
            model.EditorTemplateUsePluginValue = context.Request.Form["cbx_EditorTemplateUsePlugin"] == "on";
            model.EditorTemplateUseReplacePartValue = context.Request.Form["cbx_EditorTemplateUseReplacePart"] == "on";
            model.EditorTemplateUseFetchValue = context.Request.Form["cbx_EditorTemplateUseFetch"] == "on";
            model.EditorTemplateUseItemValue = context.Request.Form["cbx_EditorTemplateUseItem"] == "on";
            model.EditorTemplateUseElanatValue = context.Request.Form["cbx_EditorTemplateUseElanat"] == "on";
            model.EditorTemplateCacheDurationValue = context.Request.Form["txt_EditorTemplateCacheDuration"];
            model.EditorTemplateCacheParametersValue = context.Request.Form["txt_EditorTemplateCacheParameters"];
            model.EditorTemplateSortIndexValue = context.Request.Form["txt_EditorTemplateSortIndex"];
            model.EditorTemplatePublicAccessShowValue = context.Request.Form["cbx_EditorTemplatePublicAccessShow"] == "on";
            model.EditorTemplateIdValue = context.Request.Form["hdn_EditorTemplateId"];

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_EditorTemplateAccessShow$"))
                {
                    ListItem EditorTemplateAccessShow = new ListItem();

                    EditorTemplateAccessShow.Value = context.Request.Form[name];
                    EditorTemplateAccessShow.Selected = true;

                    model.EditorTemplateAccessShowListItem.Add(EditorTemplateAccessShow);
                }


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            model.SaveEditorTemplate();

            model.SuccessView();

            View(model);
        }
    }
}