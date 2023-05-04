using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;

namespace elanat
{
    public partial class AdminItem : System.Web.UI.Page
    {
        public AdminItemModel model = new AdminItemModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["btn_AddItem"]))
                btn_AddItem_Click(sender, e);


            model.SetValue(Request.QueryString);


            // Set Required Field Validation
            model.SetImportantField();
        }

        protected void btn_AddItem_Click(object sender, EventArgs e)
        {
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


            // Evaluate Field Check
            model.EvaluateField(Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.RedirectToResponseFormPage();
            }


            model.AddItem();
        }
    }
}