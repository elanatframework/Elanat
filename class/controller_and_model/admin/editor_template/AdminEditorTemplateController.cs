using CodeBehind;

namespace Elanat
{
    public partial class AdminEditorTemplateController : CodeBehindController
    {
        public AdminEditorTemplateModel model = new AdminEditorTemplateModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddEditorTemplate"]))
            {
                btn_AddEditorTemplate_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddEditorTemplate_Click(HttpContext context)
        {
            model.EditorTemplatePathUploadValue = context.Request.Form.Files["upd_EditorTemplatePath"];
            model.UseEditorTemplatePathValue = context.Request.Form["cbx_UseEditorTemplatePath"] == "on";
            model.EditorTemplatePathTextValue = context.Request.Form["txt_EditorTemplatePath"];
            model.PriorityForEditorTemplateValue = context.Request.Form["cbx_PriorityForEditorTemplate"] == "on";
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


            model.AddEditorTemplate();

            View(model);
        }
    }
}