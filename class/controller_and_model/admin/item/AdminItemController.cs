using CodeBehind;

namespace Elanat
{
    public partial class AdminItemController : CodeBehindController
    {
        public AdminItemModel model = new AdminItemModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_AddItem"]))
            {
                btn_AddItem_Click(context);
                return;
            }


            model.SetValue(context.Request.QueryString.ToListItems());


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_AddItem_Click(HttpContext context)
        {
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


            model.AddItem();

            View(model);
        }
    }
}