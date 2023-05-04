using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class ActionEditItemModel
    {
        public string EditItemLanguage { get; set; }
        public string SaveItemLanguage { get; set; }
        public string ItemNameLanguage { get; set; }
        public string ItemUseBoxLanguage { get; set; }
        public string ItemValueLanguage { get; set; }
        public string ItemActiveLanguage { get; set; }
        public string ItemUseLanguageLanguage { get; set; }
        public string ItemUsePluginLanguage { get; set; }
        public string ItemUseModuleLanguage { get; set; }
        public string ItemUseReplacePartLanguage { get; set; }
        public string ItemUseFetchLanguage { get; set; }
        public string ItemUseItemLanguage { get; set; }
        public string ItemUseElanatLanguage { get; set; }
        public string ItemCacheDurationLanguage { get; set; }
        public string ItemMenuLanguage { get; set; }
        public string ItemSortIndexLanguage { get; set; }
        public string ItemAccessShowLanguage { get; set; }
        public string ItemPublicAccessShowLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public string ItemIdValue { get; set; }

        public bool ItemActiveValue { get; set; } = false;
        public bool ItemUseBoxValue { get; set; } = false;
        public bool ItemUseLanguageValue { get; set; } = false;
        public bool ItemUsePluginValue { get; set; } = false;
        public bool ItemUseModuleValue { get; set; } = false;
        public bool ItemUseReplacePartValue { get; set; } = false;
        public bool ItemUseFetchValue { get; set; } = false;
        public bool ItemUseItemValue { get; set; } = false;
        public bool ItemUseElanatValue { get; set; } = false;
        public bool ItemPublicAccessShowValue { get; set; } = false;

        public string ItemNameValue { get; set; }
        public string ItemValueValue { get; set; }
        public string ItemCacheDurationValue { get; set; }
        public string ItemSortIndexValue { get; set; }

        public string ItemNameAttribute { get; set; }
        public string ItemValueAttribute { get; set; }
        public string ItemCacheDurationAttribute { get; set; }
        public string ItemSortIndexAttribute { get; set; }

        public string ItemNameCssClass { get; set; }
        public string ItemValueCssClass { get; set; }
        public string ItemCacheDurationCssClass { get; set; }
        public string ItemSortIndexCssClass { get; set; }

        public ListItemCollection ItemMenuListItem = new ListItemCollection();
        public string ItemMenuListValue { get; set; }
        public string ItemMenuTemplateValue { get; set; }
        public ListItemCollection ItemAccessShowListItem = new ListItemCollection();
        public string ItemAccessShowListValue { get; set; }
        public string ItemAccessShowTemplateValue { get; set; }

        public string ItemMenuAttribute { get; set; }
        public string ItemMenuCssClass { get; set; }
        public string ItemAccessShowAttribute { get; set; }
        public string ItemAccessShowCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/item/");
            ItemMenuLanguage = aol.GetAddOnsLanguage("item_menu");
            ItemValueLanguage = aol.GetAddOnsLanguage("item_value");
            EditItemLanguage = aol.GetAddOnsLanguage("edit_item");
            ItemCacheDurationLanguage = aol.GetAddOnsLanguage("item_cache_duration");
            ItemSortIndexLanguage = aol.GetAddOnsLanguage("item_sort_index");
            ItemAccessShowLanguage = aol.GetAddOnsLanguage("item_access_show");
            ItemNameLanguage = aol.GetAddOnsLanguage("item_name");
            ItemPublicAccessShowLanguage = aol.GetAddOnsLanguage("item_public_access_show");
            ItemUseBoxLanguage = aol.GetAddOnsLanguage("item_use_box");
            ItemUseLanguageLanguage = aol.GetAddOnsLanguage("item_use_language");
            ItemUseModuleLanguage = aol.GetAddOnsLanguage("item_use_module");
            ItemUsePluginLanguage = aol.GetAddOnsLanguage("item_use_plugin");
            ItemUseReplacePartLanguage = aol.GetAddOnsLanguage("item_use_replace_part");
            ItemUseFetchLanguage = aol.GetAddOnsLanguage("item_use_fetch");
            ItemUseItemLanguage = aol.GetAddOnsLanguage("item_use_item");
            ItemUseElanatLanguage = aol.GetAddOnsLanguage("item_use_elanat");
            ItemActiveLanguage = aol.GetAddOnsLanguage("item_active");
            SaveItemLanguage = aol.GetAddOnsLanguage("save_item");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.Item dui = new DataUse.Item();
                dui.FillCurrentItem(ItemIdValue);

                ItemNameValue = dui.ItemName;
                ItemValueValue = dui.ItemValue;
                ItemCacheDurationValue = dui.ItemCacheDuration;
                ItemSortIndexValue = dui.ItemSortIndex;
                ItemPublicAccessShowValue = dui.ItemPublicAccessShow.ZeroOneToBoolean();
                ItemUseBoxValue = dui.ItemUseBox.ZeroOneToBoolean();
                ItemUseLanguageValue = dui.ItemUseLanguage.ZeroOneToBoolean();
                ItemUseModuleValue = dui.ItemUseModule.ZeroOneToBoolean();
                ItemUsePluginValue = dui.ItemUsePlugin.ZeroOneToBoolean();
                ItemUseReplacePartValue = dui.ItemUseReplacePart.ZeroOneToBoolean();
                ItemUseFetchValue = dui.ItemUseFetch.ZeroOneToBoolean();
                ItemUseItemValue = dui.ItemUseItem.ZeroOneToBoolean();
                ItemUseElanatValue = dui.ItemUseElanat.ZeroOneToBoolean();
                ItemActiveValue = dui.ItemActive.ZeroOneToBoolean();
            }

            ListClass lc = new ListClass();

            // Set Menu
            lc.FillMenuListItem(StaticObject.GetCurrentSiteSiteId());
            HtmlCheckBoxList HtmlCheckBoxListMenu = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/item/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ItemMenu");
            HtmlCheckBoxListMenu.AddRange(lc.MenuListItem);
            ItemMenuTemplateValue = HtmlCheckBoxListMenu.GetValue();
            ItemMenuListValue = HtmlCheckBoxListMenu.GetList();
            ItemMenuTemplateValue = ItemMenuTemplateValue.Replace("$_asp attribute;", ItemMenuAttribute);
            ItemMenuTemplateValue = ItemMenuTemplateValue.Replace("$_asp css_class;", ItemMenuCssClass);
            ItemMenuTemplateValue = ItemMenuTemplateValue.HtmlInputSetCheckBoxListValue(ItemMenuListItem);

            // Set User Role
            lc.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());

            // Item Access Show
            HtmlCheckBoxList HtmlCheckBoxListAccessShow = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/item/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_ItemAccessShow");
            HtmlCheckBoxListAccessShow.AddRange(lc.UserRoleListItem);
            ItemAccessShowTemplateValue = HtmlCheckBoxListAccessShow.GetValue();
            ItemAccessShowListValue = HtmlCheckBoxListAccessShow.GetList();
            ItemAccessShowTemplateValue = ItemAccessShowTemplateValue.Replace("$_asp attribute;", ItemAccessShowAttribute);
            ItemAccessShowTemplateValue = ItemAccessShowTemplateValue.Replace("$_asp css_class;", ItemAccessShowCssClass);
            ItemAccessShowTemplateValue = ItemAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(ItemAccessShowListItem);

            // Set Item Menu Selected Value
            lc.FillItemMenuListItem(ItemIdValue);
            ItemMenuTemplateValue = ItemMenuTemplateValue.HtmlInputSetCheckBoxListValue(lc.ItemMenuListItem);

            // Set Item Access Show Selected Value
            lc.FillItemAccessShowListItem(ItemIdValue);
            ItemAccessShowTemplateValue = ItemAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(lc.ItemAccessShowListItem);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_ItemName", "");
            InputRequest.Add("txt_ItemValue", "");
            InputRequest.Add("txt_ItemCategory", "");
            InputRequest.Add("txt_ItemCacheDuration", "");
            InputRequest.Add("txt_ItemSortIndex", "");
            InputRequest.Add("cbxlst_ItemMenu", ItemMenuListValue);
            InputRequest.Add("cbxlst_ItemAccessShow", ItemAccessShowListValue);
            InputRequest.Add("hdn_ItemId", ItemIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/item/", "edit");

            ItemNameAttribute += vc.ImportantInputAttribute["txt_ItemName"];
            ItemValueAttribute += vc.ImportantInputAttribute["txt_ItemValue"];
            ItemCacheDurationAttribute += vc.ImportantInputAttribute["txt_ItemCacheDuration"];
            ItemSortIndexAttribute += vc.ImportantInputAttribute["txt_ItemSortIndex"];
            ItemMenuAttribute += vc.ImportantInputAttribute["cbxlst_ItemMenu"];
            ItemAccessShowAttribute += vc.ImportantInputAttribute["cbxlst_ItemAccessShow"];

            ItemNameCssClass = ItemNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ItemName"]);
            ItemValueCssClass = ItemValueCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ItemValue"]);
            ItemCacheDurationCssClass = ItemCacheDurationCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ItemCacheDuration"]);
            ItemSortIndexCssClass = ItemSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass["txt_ItemSortIndex"]);
            ItemMenuCssClass = ItemMenuCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_ItemMenu"]);
            ItemAccessShowCssClass = ItemAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_ItemAccessShow"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "edit", StaticObject.AdminPath + "/item/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //ItemNameCssClass = ItemNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ItemName"]);
                //ItemValueCssClass = ItemValueCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ItemValue"]);
                //ItemCacheDurationCssClass = ItemCacheDurationCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ItemCacheDuration"]);
                //ItemSortIndexCssClass = ItemSortIndexCssClass.AddHtmlClass(vc.WarningFieldClass["txt_ItemSortIndex"]);
                //ItemMenuCssClass = ItemMenuCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_ItemMenu"]);
                //ItemAccessShowCssClass = ItemAccessShowCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_ItemAccessShow"]);
            }
        }

        public void SaveItem()
        {
            // Change Database Data
            DataUse.Item dui = new DataUse.Item();

            dui.ItemId = ItemIdValue;
            dui.ItemName = ItemNameValue;
            dui.ItemValue = ItemValueValue;
            dui.ItemCacheDuration = ItemCacheDurationValue;
            dui.ItemSortIndex = ItemSortIndexValue;
            dui.ItemPublicAccessShow = ItemPublicAccessShowValue.BooleanToZeroOne();
            dui.ItemUseBox = ItemUseBoxValue.BooleanToZeroOne();
            dui.ItemUseLanguage = ItemUseLanguageValue.BooleanToZeroOne();
            dui.ItemUseModule = ItemUseModuleValue.BooleanToZeroOne();
            dui.ItemUsePlugin = ItemUsePluginValue.BooleanToZeroOne();
            dui.ItemUseReplacePart = ItemUseReplacePartValue.BooleanToZeroOne();
            dui.ItemUseFetch = ItemUseFetchValue.BooleanToZeroOne();
            dui.ItemUseItem = ItemUseItemValue.BooleanToZeroOne();
            dui.ItemUseElanat = ItemUseElanatValue.BooleanToZeroOne();
            dui.ItemActive = ItemActiveValue.BooleanToZeroOne();

            // Edit Item
            dui.Edit();

            // Delete Menu Item
            dui.DeleteMenuItem(dui.ItemId);

            // Add Menu Item
            dui.AddMenuItem(dui.ItemId, ItemMenuListItem);

            // Delete Item Access Show
            dui.DeleteItemAccessShow(dui.ItemId);

            // Set Item Access Show
            dui.SetItemAccessShow(dui.ItemId, ItemAccessShowListItem);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_item", dui.ItemName);
        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/item/action/SuccessMessage.aspx");
        }

        public void ExistValueToColumnErrorView()
        {
            ResponseForm.WriteLocalAlone(Language.GetLanguage("please_set_new_value_to_asp_field_because_this_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp field_name;", Language.GetAddOnsLanguage("item_name", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/item/")), "problem");
        }
    }
}