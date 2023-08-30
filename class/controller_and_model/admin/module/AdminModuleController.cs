using CodeBehind;

namespace Elanat
{
    public partial class AdminModuleController : CodeBehindController
    {
        public AdminModuleModel model = new AdminModuleModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddModule"]))
            {
                btn_AddModule_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddModule_Click(HttpContext context)
        {
            model.ModulePathUploadValue = context.Request.Form.Files["upd_ModulePath"];
            model.UseModulePathValue = context.Request.Form["cbx_UseModulePath"] == "on";
            model.ModulePathTextValue = context.Request.Form["txt_ModulePath"];
            model.PriorityForModuleValue = context.Request.Form["cbx_PriorityForModule"] == "on";
            model.ModuleCategoryValue = context.Request.Form["txt_ModuleCategory"];
            model.ModuleLoadTypeOptionListSelectedValue = context.Request.Form["ddlst_ModuleLoadType"];
            model.ModuleActiveValue = context.Request.Form["cbx_ModuleActive"] == "on";
            model.ModuleUseLanguageValue = context.Request.Form["cbx_ModuleUseLanguage"] == "on";
            model.ModuleUseModuleValue = context.Request.Form["cbx_ModuleUseModule"] == "on";
            model.ModuleUsePluginValue = context.Request.Form["cbx_ModuleUsePlugin"] == "on";
            model.ModuleUseReplacePartValue = context.Request.Form["cbx_ModuleUseReplacePart"] == "on";
            model.ModuleUseFetchValue = context.Request.Form["cbx_ModuleUseFetch"] == "on";
            model.ModuleUseItemValue = context.Request.Form["cbx_ModuleUseItem"] == "on";
            model.ModuleUseElanatValue = context.Request.Form["cbx_ModuleUseElanat"] == "on";
            model.ModuleCacheDurationValue = context.Request.Form["txt_ModuleCacheDuration"];
            model.ModuleCacheParametersValue = context.Request.Form["txt_ModuleCacheParameters"];
            model.ModuleSortIndexValue = context.Request.Form["txt_ModuleSortIndex"];
            model.ModulePublicAccessShowValue = context.Request.Form["cbx_ModulePublicAccessShow"] == "on";
            model.ModulePublicAccessAddValue = context.Request.Form["cbx_ModulePublicAccessAdd"] == "on";
            model.ModulePublicAccessDeleteOwnValue = context.Request.Form["cbx_ModulePublicAccessDeleteOwn"] == "on";
            model.ModulePublicAccessEditOwnValue = context.Request.Form["cbx_ModulePublicAccessEditOwn"] == "on";
            model.ModulePublicAccessDeleteAllValue = context.Request.Form["cbx_ModulePublicAccessDeleteAll"] == "on";
            model.ModulePublicAccessEditAllValue = context.Request.Form["cbx_ModulePublicAccessEditAll"] == "on";

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ModuleMenu$"))
                {
                    ListItem ModuleMenu = new ListItem();

                    ModuleMenu.Value = context.Request.Form[name];
                    ModuleMenu.Selected = true;

                    model.ModuleMenuListItem.Add(ModuleMenu);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ModuleAccessShow$"))
                {
                    ListItem ModuleAccessShow = new ListItem();

                    ModuleAccessShow.Value = context.Request.Form[name];
                    ModuleAccessShow.Selected = true;

                    model.ModuleAccessShowListItem.Add(ModuleAccessShow);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ModuleAccessAdd$"))
                {
                    ListItem ModuleAccessAdd = new ListItem();

                    ModuleAccessAdd.Value = context.Request.Form[name];
                    ModuleAccessAdd.Selected = true;

                    model.ModuleAccessAddListItem.Add(ModuleAccessAdd);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ModuleAccessDeleteOwn$"))
                {
                    ListItem ModuleAccessDeleteOwn = new ListItem();

                    ModuleAccessDeleteOwn.Value = context.Request.Form[name];
                    ModuleAccessDeleteOwn.Selected = true;

                    model.ModuleAccessDeleteOwnListItem.Add(ModuleAccessDeleteOwn);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ModuleAccessEditOwn$"))
                {
                    ListItem ModuleAccessEditOwn = new ListItem();

                    ModuleAccessEditOwn.Value = context.Request.Form[name];
                    ModuleAccessEditOwn.Selected = true;

                    model.ModuleAccessEditOwnListItem.Add(ModuleAccessEditOwn);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ModuleAccessDeleteAll$"))
                {
                    ListItem ModuleAccessDeleteAll = new ListItem();

                    ModuleAccessDeleteAll.Value = context.Request.Form[name];
                    ModuleAccessDeleteAll.Selected = true;

                    model.ModuleAccessDeleteAllListItem.Add(ModuleAccessDeleteAll);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ModuleAccessEditAll$"))
                {
                    ListItem ModuleAccessEditAll = new ListItem();

                    ModuleAccessEditAll.Value = context.Request.Form[name];
                    ModuleAccessEditAll.Selected = true;

                    model.ModuleAccessEditAllListItem.Add(ModuleAccessEditAll);
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


            model.AddModule(context);

            View(model);
        }
    }
}