using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionEditItem : System.Web.UI.Page
    {
        public ActionEditItemModel model = new ActionEditItemModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_SaveItem"]))
                btn_SaveItem_Click(sender, e);

            if (string.IsNullOrEmpty(Request.Form["hdn_ItemId"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["item_id"]))
                    return;

                if (!Request.QueryString["item_id"].ToString().IsNumber())
                    return;

                model.ItemIdValue = Request.QueryString["item_id"].ToString();
            }


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_SaveItem_Click(object sender, EventArgs e)
        {
			model.IsFirstStart = false;
			
            model.ItemNameValue = Request.Form["txt_ItemName"];
            model.ItemValueValue = Request.Form["txt_ItemValue"];
            model.ItemActiveValue = Request.Form["cbx_ItemActive"] == "on";
            model.ItemUseBoxValue = Request.Form["cbx_ItemUseBox"] == "on";
            model.ItemUseLanguageValue = Request.Form["cbx_ItemUseLanguage"] == "on";
            model.ItemUsePluginValue = Request.Form["cbx_ItemUsePlugin"] == "on";
            model.ItemUseModuleValue = Request.Form["cbx_ItemUseModule"] == "on";
            model.ItemUseReplacePartValue = Request.Form["cbx_ItemUseReplacePart"] == "on";
            model.ItemUseFetchValue = Request.Form["cbx_ItemUseFetch"] == "on";
            model.ItemUseItemValue = Request.Form["cbx_ItemUseItem"] == "on";
            model.ItemUseElanatValue = Request.Form["cbx_ItemUseElanat"] == "on";
            model.ItemCacheDurationValue = Request.Form["txt_ItemCacheDuration"];
            model.ItemSortIndexValue = Request.Form["txt_ItemSortIndex"];
            model.ItemPublicAccessShowValue = Request.Form["cbx_ItemPublicAccessShow"] == "on";
            model.ItemIdValue = Request.Form["hdn_ItemId"];

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ItemMenu$"))
                {
                    ListItem ItemMenu = new ListItem();

                    ItemMenu.Value = Request.Form[name];
                    ItemMenu.Selected = true;

                    model.ItemMenuListItem.Add(ItemMenu);
                }

            foreach (string name in Request.Form)
                if (name.Contains("cbxlst_ItemAccessShow$"))
                {
                    ListItem ItemAccessShow = new ListItem();

                    ItemAccessShow.Value = Request.Form[name];
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
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.SaveItem();

            model.SuccessView();
        }
    }
}