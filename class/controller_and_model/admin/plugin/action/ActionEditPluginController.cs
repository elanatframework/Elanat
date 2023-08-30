using CodeBehind;

namespace Elanat
{
    public partial class ActionEditPluginController : CodeBehindController
    {
        public ActionEditPluginModel model = new ActionEditPluginModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SavePlugin"]))
            {
                btn_SavePlugin_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_PluginId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["plugin_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["plugin_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.PluginIdValue = context.Request.Query["plugin_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SavePlugin_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.PluginCategoryValue = context.Request.Form["txt_PluginCategory"];
            model.PluginLoadTypeOptionListSelectedValue = context.Request.Form["ddlst_PluginLoadType"];
            model.PluginActiveValue = context.Request.Form["cbx_PluginActive"] == "on";
            model.PluginUseLanguageValue = context.Request.Form["cbx_PluginUseLanguage"] == "on";
            model.PluginUseModuleValue = context.Request.Form["cbx_PluginUseModule"] == "on";
            model.PluginUsePluginValue = context.Request.Form["cbx_PluginUsePlugin"] == "on";
            model.PluginUseReplacePartValue = context.Request.Form["cbx_PluginUseReplacePart"] == "on";
            model.PluginUseFetchValue = context.Request.Form["cbx_PluginUseFetch"] == "on";
            model.PluginUseItemValue = context.Request.Form["cbx_PluginUseItem"] == "on";
            model.PluginUseElanatValue = context.Request.Form["cbx_PluginUseElanat"] == "on";
            model.PluginCacheDurationValue = context.Request.Form["txt_PluginCacheDuration"];
            model.PluginCacheParametersValue = context.Request.Form["txt_PluginCacheParameters"];
            model.PluginSortIndexValue = context.Request.Form["txt_PluginSortIndex"];
            model.PluginPublicAccessShowValue = context.Request.Form["cbx_PluginPublicAccessShow"] == "on";
            model.PluginPublicAccessAddValue = context.Request.Form["cbx_PluginPublicAccessAdd"] == "on";
            model.PluginPublicAccessDeleteOwnValue = context.Request.Form["cbx_PluginPublicAccessDeleteOwn"] == "on";
            model.PluginPublicAccessEditOwnValue = context.Request.Form["cbx_PluginPublicAccessEditOwn"] == "on";
            model.PluginPublicAccessDeleteAllValue = context.Request.Form["cbx_PluginPublicAccessDeleteAll"] == "on";
            model.PluginPublicAccessEditAllValue = context.Request.Form["cbx_PluginPublicAccessEditAll"] == "on";
            model.PluginIdValue = context.Request.Form["hdn_PluginId"];

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_PluginMenu$"))
                {
                    ListItem PluginMenu = new ListItem();

                    PluginMenu.Value = context.Request.Form[name];
                    PluginMenu.Selected = true;

                    model.PluginMenuListItem.Add(PluginMenu);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_PluginAccessShow$"))
                {
                    ListItem PluginAccessShow = new ListItem();

                    PluginAccessShow.Value = context.Request.Form[name];
                    PluginAccessShow.Selected = true;

                    model.PluginAccessShowListItem.Add(PluginAccessShow);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_PluginAccessAdd$"))
                {
                    ListItem PluginAccessAdd = new ListItem();

                    PluginAccessAdd.Value = context.Request.Form[name];
                    PluginAccessAdd.Selected = true;

                    model.PluginAccessAddListItem.Add(PluginAccessAdd);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_PluginAccessDeleteOwn$"))
                {
                    ListItem PluginAccessDeleteOwn = new ListItem();

                    PluginAccessDeleteOwn.Value = context.Request.Form[name];
                    PluginAccessDeleteOwn.Selected = true;

                    model.PluginAccessDeleteOwnListItem.Add(PluginAccessDeleteOwn);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_PluginAccessEditOwn$"))
                {
                    ListItem PluginAccessEditOwn = new ListItem();

                    PluginAccessEditOwn.Value = context.Request.Form[name];
                    PluginAccessEditOwn.Selected = true;

                    model.PluginAccessEditOwnListItem.Add(PluginAccessEditOwn);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_PluginAccessDeleteAll$"))
                {
                    ListItem PluginAccessDeleteAll = new ListItem();

                    PluginAccessDeleteAll.Value = context.Request.Form[name];
                    PluginAccessDeleteAll.Selected = true;

                    model.PluginAccessDeleteAllListItem.Add(PluginAccessDeleteAll);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_PluginAccessEditAll$"))
                {
                    ListItem PluginAccessEditAll = new ListItem();

                    PluginAccessEditAll.Value = context.Request.Form[name];
                    PluginAccessEditAll.Selected = true;

                    model.PluginAccessEditAllListItem.Add(PluginAccessEditAll);
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


            model.SavePlugin(context);

            model.SuccessView();

            View(model);
        }
    }
}