using CodeBehind;

namespace Elanat
{
    public partial class AdminComponentController : CodeBehindController
    {
        public AdminComponentModel model = new AdminComponentModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddComponent"]))
            {
                btn_AddComponent_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddComponent_Click(HttpContext context)
        {
            model.ComponentPathUploadValue = context.Request.Form.Files["upd_ComponentPath"];
            model.UseComponentPathValue = context.Request.Form["cbx_UseComponentPath"] == "on";
            model.ComponentPathTextValue = context.Request.Form["txt_ComponentPath"];
            model.PriorityForComponentValue = context.Request.Form["cbx_PriorityForComponent"] == "on";
            model.ComponentCategoryValue = context.Request.Form["txt_ComponentCategory"];
            model.ComponentLoadTypeOptionListSelectedValue = context.Request.Form["ddlst_ComponentLoadType"];
            model.ComponentActiveValue = context.Request.Form["cbx_ComponentActive"] == "on";
            model.ComponentUseLanguageValue = context.Request.Form["cbx_ComponentUseLanguage"] == "on";
            model.ComponentUseModuleValue = context.Request.Form["cbx_ComponentUseModule"] == "on";
            model.ComponentUsePluginValue = context.Request.Form["cbx_ComponentUsePlugin"] == "on";
            model.ComponentUseReplacePartValue = context.Request.Form["cbx_ComponentUseReplacePart"] == "on";
            model.ComponentUseFetchValue = context.Request.Form["cbx_ComponentUseFetch"] == "on";
            model.ComponentUseItemValue = context.Request.Form["cbx_ComponentUseItem"] == "on";
            model.ComponentUseElanatValue = context.Request.Form["cbx_ComponentUseElanat"] == "on";
            model.ComponentCacheDurationValue = context.Request.Form["txt_ComponentCacheDuration"];
            model.ComponentCacheParametersValue = context.Request.Form["txt_ComponentCacheParameters"];
            model.ComponentSortIndexValue = context.Request.Form["txt_ComponentSortIndex"];
            model.ComponentPublicAccessShowValue = context.Request.Form["cbx_ComponentPublicAccessShow"] == "on";
            model.ComponentPublicAccessAddValue = context.Request.Form["cbx_ComponentPublicAccessAdd"] == "on";
            model.ComponentPublicAccessDeleteOwnValue = context.Request.Form["cbx_ComponentPublicAccessDeleteOwn"] == "on";
            model.ComponentPublicAccessEditOwnValue = context.Request.Form["cbx_ComponentPublicAccessEditOwn"] == "on";
            model.ComponentPublicAccessDeleteAllValue = context.Request.Form["cbx_ComponentPublicAccessDeleteAll"] == "on";
            model.ComponentPublicAccessEditAllValue = context.Request.Form["cbx_ComponentPublicAccessEditAll"] == "on";

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ComponentAccessShow$"))
                {
                    ListItem ComponentAccessShow = new ListItem();

                    ComponentAccessShow.Value = context.Request.Form[name];
                    ComponentAccessShow.Selected = true;

                    model.ComponentAccessShowListItem.Add(ComponentAccessShow);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ComponentAccessAdd$"))
                {
                    ListItem ComponentAccessAdd = new ListItem();

                    ComponentAccessAdd.Value = context.Request.Form[name];
                    ComponentAccessAdd.Selected = true;

                    model.ComponentAccessAddListItem.Add(ComponentAccessAdd);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ComponentAccessDeleteOwn$"))
                {
                    ListItem ComponentAccessDeleteOwn = new ListItem();

                    ComponentAccessDeleteOwn.Value = context.Request.Form[name];
                    ComponentAccessDeleteOwn.Selected = true;

                    model.ComponentAccessDeleteOwnListItem.Add(ComponentAccessDeleteOwn);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ComponentAccessEditOwn$"))
                {
                    ListItem ComponentAccessEditOwn = new ListItem();

                    ComponentAccessEditOwn.Value = context.Request.Form[name];
                    ComponentAccessEditOwn.Selected = true;

                    model.ComponentAccessEditOwnListItem.Add(ComponentAccessEditOwn);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ComponentAccessDeleteAll$"))
                {
                    ListItem ComponentAccessDeleteAll = new ListItem();

                    ComponentAccessDeleteAll.Value = context.Request.Form[name];
                    ComponentAccessDeleteAll.Selected = true;

                    model.ComponentAccessDeleteAllListItem.Add(ComponentAccessDeleteAll);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ComponentAccessEditAll$"))
                {
                    ListItem ComponentAccessEditAll = new ListItem();

                    ComponentAccessEditAll.Value = context.Request.Form[name];
                    ComponentAccessEditAll.Selected = true;

                    model.ComponentAccessEditAllListItem.Add(ComponentAccessEditAll);
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


            model.AddComponent();

            View(model);
        }
    }
}