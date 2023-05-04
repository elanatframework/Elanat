﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public class AdminItemModel
    {
        public string ItemLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string AddItemLanguage { get; set; }
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
        public string RefreshLanguage { get; set; }

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

        public void SetValue(NameValueCollection QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/item/");
            AddLanguage = aol.GetAddOnsLanguage("add");
            ItemPublicAccessShowLanguage = aol.GetAddOnsLanguage("item_public_access_show");
            ItemUseBoxLanguage = aol.GetAddOnsLanguage("item_use_box");
            ItemUseLanguageLanguage = aol.GetAddOnsLanguage("item_use_language");
            ItemUseModuleLanguage = aol.GetAddOnsLanguage("item_use_module");
            ItemUsePluginLanguage = aol.GetAddOnsLanguage("item_use_plugin");
            ItemUseReplacePartLanguage = aol.GetAddOnsLanguage("item_use_replace_part");
            ItemUseFetchLanguage = aol.GetAddOnsLanguage("item_use_fetch");
            ItemUseItemLanguage = aol.GetAddOnsLanguage("item_use_item");
            ItemUseElanatLanguage = aol.GetAddOnsLanguage("item_use_elanat");
            AddItemLanguage = aol.GetAddOnsLanguage("add_item");
            ItemAccessShowLanguage = aol.GetAddOnsLanguage("item_access_show");
            ItemLanguage = aol.GetAddOnsLanguage("item");
            ItemMenuLanguage = aol.GetAddOnsLanguage("item_menu");
            ItemNameLanguage = aol.GetAddOnsLanguage("item_name");
            ItemCacheDurationLanguage = aol.GetAddOnsLanguage("item_cache_duration");
            ItemSortIndexLanguage = aol.GetAddOnsLanguage("item_sort_index");
            ItemValueLanguage = aol.GetAddOnsLanguage("item_value");
            ItemActiveLanguage = aol.GetAddOnsLanguage("item_active");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Current Value
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


            ItemCacheDurationValue = "0";
            ItemSortIndexValue = "0";


            // Set Item Page List
            ActionGetItemListModel lm = new ActionGetItemListModel();
            lm.SetValue(HttpContext.Current.Request.QueryString);
            ContentValue = lm.ListValue + ContentValue;
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


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/item/");

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
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/item/");

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

        public void AddItem()
        {
            // Add Data To Database
            DataUse.Item dui = new DataUse.Item();

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

            // Add Item
            dui.AddWithFillReturnDr();

            // Add Menu Item
            dui.AddMenuItem(dui.ItemId, ItemMenuListItem);

            // Set Item Access Show
            dui.SetItemAccessShow(dui.ItemId, ItemAccessShowListItem);


            try { dui.ReturnDb.Close(); } catch (Exception) { }


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_item", dui.ItemName);


            ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("item_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/item/"), "success", false, StaticObject.AdminPath + "/item/action/ItemNewRow.aspx?item_id=" + dui.ItemId, "div_TableBox");
        }
    }
}