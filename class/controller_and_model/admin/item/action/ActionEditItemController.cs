using CodeBehind;

namespace Elanat
{
    public partial class ActionEditItemController : CodeBehindController
    {
        public ActionEditItemModel model = new ActionEditItemModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SaveItem"]))
            {
                btn_SaveItem_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(context.Request.Form["hdn_ItemId"]))
            {
                if (string.IsNullOrEmpty(context.Request.Query["item_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["item_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.ItemIdValue = context.Request.Query["item_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SaveItem_Click(HttpContext context)
        {
			model.IsFirstStart = false;
			
            model.ItemNameValue = context.Request.Form["txt_ItemName"];
            model.ItemValueValue = context.Request.Form["txt_ItemValue"];
            model.ItemActiveValue = context.Request.Form["cbx_ItemActive"] == "on";
            model.ItemUseBoxValue = context.Request.Form["cbx_ItemUseBox"] == "on";
            model.ItemUseLanguageValue = context.Request.Form["cbx_ItemUseLanguage"] == "on";
            model.ItemUsePluginValue = context.Request.Form["cbx_ItemUsePlugin"] == "on";
            model.ItemUseModuleValue = context.Request.Form["cbx_ItemUseModule"] == "on";
            model.ItemUseReplacePartValue = context.Request.Form["cbx_ItemUseReplacePart"] == "on";
            model.ItemUseFetchValue = context.Request.Form["cbx_ItemUseFetch"] == "on";
            model.ItemUseItemValue = context.Request.Form["cbx_ItemUseItem"] == "on";
            model.ItemUseElanatValue = context.Request.Form["cbx_ItemUseElanat"] == "on";
            model.ItemCacheDurationValue = context.Request.Form["txt_ItemCacheDuration"];
            model.ItemSortIndexValue = context.Request.Form["txt_ItemSortIndex"];
            model.ItemPublicAccessShowValue = context.Request.Form["cbx_ItemPublicAccessShow"] == "on";
            model.ItemIdValue = context.Request.Form["hdn_ItemId"];

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ItemMenu$"))
                {
                    ListItem ItemMenu = new ListItem();

                    ItemMenu.Value = context.Request.Form[name];
                    ItemMenu.Selected = true;

                    model.ItemMenuListItem.Add(ItemMenu);
                }

            foreach (string name in context.Request.Form.Keys)
                if (name.Contains("cbxlst_ItemAccessShow$"))
                {
                    ListItem ItemAccessShow = new ListItem();

                    ItemAccessShow.Value = context.Request.Form[name];
                    ItemAccessShow.Selected = true;

                    model.ItemAccessShowListItem.Add(ItemAccessShow);
                }


            DataUse.Item dui = new DataUse.Item();

            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_item", "item_name", model.ItemNameValue, dui.GetItemName(model.ItemIdValue)))
            {
                model.ItemNameCssClass = model.ItemNameCssClass.AddHtmlClass("el_warning_field");

                model.ExistValueToColumnErrorView();

                return;
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


            model.SaveItem();

            model.SuccessView();

            View(model);
        }
    }
}