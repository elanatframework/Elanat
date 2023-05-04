using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO.Compression;
using System.IO;

namespace elanat
{
    public partial class AdminEditorTemplate : System.Web.UI.Page
    {
        public AdminEditorTemplateModel model = new AdminEditorTemplateModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddEditorTemplate"]))
                btn_AddEditorTemplate_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddEditorTemplate_Click(object sender, EventArgs e)
        {
            model.EditorTemplatePathUploadValue = Request.Files["upd_EditorTemplatePath"];
            model.UseEditorTemplatePathValue = Request.Form["cbx_UseEditorTemplatePath"] == "on";
            model.EditorTemplatePathTextValue = Request.Form["txt_EditorTemplatePath"];
            model.PriorityForEditorTemplateValue = Request.Form["cbx_PriorityForEditorTemplate"] == "on";
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


            model.AddEditorTemplate();
        }
    }
}