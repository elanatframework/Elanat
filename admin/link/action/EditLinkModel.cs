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
    public class ActionEditLinkModel
    {
        public string EditLinkLanguage { get; set; }
        public string LinkHrefLanguage { get; set; }
        public string LinkMenuLanguage { get; set; }
        public string LinkValueLanguage { get; set; }
        public string LinkTitleLanguage { get; set; }
        public string LinkTargetLanguage { get; set; }
        public string SaveLinkLanguage { get; set; }
        public string LinkProtocolLanguage { get; set; }
        public string LinkSortIndexLanguage { get; set; }
        public string LinkActiveLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public string LinkIdValue { get; set; }

        public bool LinkActiveValue { get; set; } = false;

        public string LinkProtocolOptionListValue { get; set; }
        public string LinkProtocolOptionListSelectedValue { get; set; }
        public string LinkTargetOptionListValue { get; set; }
        public string LinkTargetOptionListSelectedValue { get; set; }

        public string LinkValueValue { get; set; }
        public string LinkTitleValue { get; set; }
        public string LinkHrefValue { get; set; }
        public string LinkSortIndexValue { get; set; }

        public string LinkValueAttribute { get; set; }
        public string LinkTitleAttribute { get; set; }
        public string LinkHrefAttribute { get; set; }
        public string LinkSortIndexAttribute { get; set; }
        public string LinkProtocolAttribute { get; set; }
        public string LinkTargetAttribute { get; set; }

        public string LinkValueCssClass { get; set; }
        public string LinkTitleCssClass { get; set; }
        public string LinkHrefCssClass { get; set; }
        public string LinkSortIndexCssClass { get; set; }
        public string LinkProtocolCssClass { get; set; }
        public string LinkTargetCssClass { get; set; }

        public ListItemCollection LinkMenuListItem = new ListItemCollection();
        public string LinkMenuListValue { get; set; }
        public string LinkMenuTemplateValue { get; set; }

        public string LinkMenuAttribute { get; set; }
        public string LinkMenuCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/link/");
            LinkHrefLanguage = aol.GetAddOnsLanguage("link_href");
            LinkMenuLanguage = aol.GetAddOnsLanguage("link_menu");
            LinkValueLanguage = aol.GetAddOnsLanguage("link_value");
            LinkTitleLanguage = aol.GetAddOnsLanguage("link_title");
            LinkTargetLanguage = aol.GetAddOnsLanguage("target");
            SaveLinkLanguage = aol.GetAddOnsLanguage("save_link");
            EditLinkLanguage = aol.GetAddOnsLanguage("edit_link");
            LinkProtocolLanguage = aol.GetAddOnsLanguage("link_protocol");
            LinkSortIndexLanguage = aol.GetAddOnsLanguage("link_sort_index");
            LinkActiveLanguage = aol.GetAddOnsLanguage("link_active");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.Link dul = new DataUse.Link();
                dul.FillCurrentLink(LinkIdValue);

                LinkHrefValue = dul.LinkHref;
                LinkValueValue = dul.LinkValue;
                LinkTitleValue = dul.LinkTitle;
                LinkSortIndexValue = dul.LinkSortIndex;
                LinkActiveValue = dul.LinkActive.ZeroOneToBoolean();
                LinkProtocolOptionListSelectedValue = dul.LinkProtocol;
                LinkTargetOptionListSelectedValue = dul.LinkTarget;
            }

            ListClass lc = new ListClass();

            // Set Menu
            lc.FillMenuListItem(StaticObject.GetCurrentSiteSiteId());
            HtmlCheckBoxList HtmlCheckBoxListMenu = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/link/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_LinkMenu");
            HtmlCheckBoxListMenu.AddRange(lc.MenuListItem);
            LinkMenuTemplateValue = HtmlCheckBoxListMenu.GetValue();
            LinkMenuListValue = HtmlCheckBoxListMenu.GetList();
            LinkMenuTemplateValue = LinkMenuTemplateValue.Replace("$_asp attribute;", LinkMenuAttribute);
            LinkMenuTemplateValue = LinkMenuTemplateValue.Replace("$_asp css_class;", LinkMenuCssClass);
            LinkMenuTemplateValue = LinkMenuTemplateValue.HtmlInputSetCheckBoxListValue(LinkMenuListItem);

            // Set Link Protocol
            lc.FillLinkProtocolListItem();
            LinkProtocolOptionListValue += lc.LinkProtocolListItem.HtmlInputToOptionTag(LinkProtocolOptionListSelectedValue);

            // Set Link Target
            lc.FillLinkTargetListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            LinkTargetOptionListValue += lc.LinkTargetListItem.HtmlInputToOptionTag(LinkTargetOptionListSelectedValue);

            // Set Link Menu Selected Value
            lc.FillLinkMenuListItem(LinkIdValue);
            LinkMenuTemplateValue = LinkMenuTemplateValue.HtmlInputSetCheckBoxListValue(lc.LinkMenuListItem);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_LinkValue", "");
            InputRequest.Add("txt_LinkTitle", "");
            InputRequest.Add("txt_LinkHref", "");
            InputRequest.Add("ddlst_LinkProtocol", LinkProtocolOptionListValue);
            InputRequest.Add("ddlst_LinkTarget", LinkTargetOptionListValue);
            InputRequest.Add("txt_LinkSortIndex", "");
            InputRequest.Add("cbxlst_LinkMenu", LinkMenuListValue);
            InputRequest.Add("hdn_LinkId", LinkIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/link/");

            LinkValueAttribute += vc.ImportantInputAttribute["txt_LinkValue"];
            LinkTitleAttribute += vc.ImportantInputAttribute["txt_LinkTitle"];
            LinkHrefAttribute += vc.ImportantInputAttribute["txt_LinkHref"];
            LinkProtocolAttribute += vc.ImportantInputAttribute["ddlst_LinkProtocol"];
            LinkTargetAttribute += vc.ImportantInputAttribute["ddlst_LinkTarget"];
            LinkSortIndexAttribute += vc.ImportantInputAttribute["txt_LinkSortIndex"];
            LinkMenuAttribute += vc.ImportantInputAttribute["cbxlst_LinkMenu"];

            LinkValueCssClass = LinkValueCssClass.AddHtmlClass(vc.ImportantInputClass["txt_LinkValue"]);
            LinkTitleCssClass = LinkTitleCssClass.AddHtmlClass(vc.ImportantInputClass["txt_LinkTitle"]);
            LinkHrefCssClass = LinkHrefCssClass.AddHtmlClass(vc.ImportantInputClass["txt_LinkHref"]);
            LinkProtocolCssClass = LinkProtocolCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_LinkProtocol"]);
            LinkTargetCssClass = LinkTargetCssClass.AddHtmlClass(vc.ImportantInputClass["ddlst_LinkTarget"]);
            LinkSortIndexCssClass = LinkSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass["txt_LinkSortIndex"]);
            LinkMenuCssClass = LinkMenuCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_LinkMenu"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/link/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //LinkValueCssClass = LinkValueCssClass.AddHtmlClass(vc.WarningFieldClass["txt_LinkValue"]);
                //LinkTitleCssClass = LinkTitleCssClass.AddHtmlClass(vc.WarningFieldClass["txt_LinkTitle"]);
                //LinkHrefCssClass = LinkHrefCssClass.AddHtmlClass(vc.WarningFieldClass["txt_LinkHref"]);
                //LinkProtocolCssClass = LinkProtocolCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_LinkProtocol"]);
                //LinkTargetCssClass = LinkTargetCssClass.AddHtmlClass(vc.WarningFieldClass["ddlst_LinkTarget"]);
                //LinkSortIndexCssClass = LinkSortIndexCssClass.AddHtmlClass(vc.WarningFieldClass["txt_LinkSortIndex"]);
                //LinkMenuCssClass = LinkMenuCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_LinkMenu"]);
            }
        }

        public void SaveLink()
        {
            // Change Database Data
            DataUse.Link dul = new DataUse.Link();

            dul.LinkId = LinkIdValue;
            dul.LinkHref = LinkHrefValue;
            dul.LinkProtocol = LinkProtocolOptionListSelectedValue;
            dul.LinkSortIndex = LinkSortIndexValue;
            dul.LinkTarget = LinkTargetOptionListSelectedValue;
            dul.LinkTitle = LinkTitleValue;
            dul.LinkValue = LinkValueValue;
            dul.LinkActive = LinkActiveValue.BooleanToZeroOne();

            // Edit Link
            dul.Edit();

            // Delete Menu Link
            dul.DeleteMenuLink(dul.LinkId);

            // Add Menu Link
            dul.AddMenuLink(dul.LinkId, LinkMenuListItem);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_link", dul.LinkValue);

        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/link/action/SuccessMessage.aspx");
        }
    }
}