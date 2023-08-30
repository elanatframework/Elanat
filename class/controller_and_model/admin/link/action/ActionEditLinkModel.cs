using CodeBehind;

namespace Elanat
{
    public partial class ActionEditLinkModel : CodeBehindModel
    {
        public string EditLinkLanguage { get; set; }
        public string LinkHrefLanguage { get; set; }
        public string LinkRelLanguage { get; set; }
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
        public string LinkRelValue { get; set; }
        public string LinkSortIndexValue { get; set; }

        public string LinkValueAttribute { get; set; }
        public string LinkTitleAttribute { get; set; }
        public string LinkHrefAttribute { get; set; }
        public string LinkRelAttribute { get; set; }
        public string LinkSortIndexAttribute { get; set; }
        public string LinkProtocolAttribute { get; set; }
        public string LinkTargetAttribute { get; set; }

        public string LinkValueCssClass { get; set; }
        public string LinkTitleCssClass { get; set; }
        public string LinkHrefCssClass { get; set; }
        public string LinkRelCssClass { get; set; }
        public string LinkSortIndexCssClass { get; set; }
        public string LinkProtocolCssClass { get; set; }
        public string LinkTargetCssClass { get; set; }

        public List<ListItem> LinkMenuListItem = new List<ListItem>();
        public string LinkMenuListValue { get; set; }
        public string LinkMenuTemplateValue { get; set; }

        public string LinkMenuAttribute { get; set; }
        public string LinkMenuCssClass { get; set; }

        public string ContentValue { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
        public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/link/");
            LinkHrefLanguage = aol.GetAddOnsLanguage("link_href");
            LinkRelLanguage = aol.GetAddOnsLanguage("link_rel");
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
                LinkRelValue = dul.LinkRel;
                LinkValueValue = dul.LinkValue;
                LinkTitleValue = dul.LinkTitle;
                LinkSortIndexValue = dul.LinkSortIndex;
                LinkActiveValue = dul.LinkActive.ZeroOneToBoolean();
                LinkProtocolOptionListSelectedValue = dul.LinkProtocol;
                LinkTargetOptionListSelectedValue = dul.LinkTarget;
            }

            // Set Menu
            ListClass.Menu lcm = new ListClass.Menu();
            lcm.FillMenuListItem(StaticObject.GetCurrentSiteSiteId());
            HtmlCheckBoxList HtmlCheckBoxListMenu = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/link/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage(), "cbxlst_LinkMenu");
            HtmlCheckBoxListMenu.AddRange(lcm.MenuListItem);
            LinkMenuTemplateValue = HtmlCheckBoxListMenu.GetValue();
            LinkMenuListValue = HtmlCheckBoxListMenu.GetList();
            LinkMenuTemplateValue = LinkMenuTemplateValue.Replace("$_asp attribute;", LinkMenuAttribute);
            LinkMenuTemplateValue = LinkMenuTemplateValue.Replace("$_asp css_class;", LinkMenuCssClass);
            LinkMenuTemplateValue = LinkMenuTemplateValue.HtmlInputSetCheckBoxListValue(LinkMenuListItem);

            ListClass.Link lcl = new ListClass.Link();

            // Set Link Protocol
            lcl.FillLinkProtocolListItem();
            LinkProtocolOptionListValue += lcl.LinkProtocolListItem.HtmlInputToOptionTag(LinkProtocolOptionListSelectedValue);

            // Set Link Target
            lcl.FillLinkTargetListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            LinkTargetOptionListValue += lcl.LinkTargetListItem.HtmlInputToOptionTag(LinkTargetOptionListSelectedValue);

            // Set Link Menu Selected Value
            lcl.FillLinkMenuListItem(LinkIdValue);
            LinkMenuTemplateValue = LinkMenuTemplateValue.HtmlInputSetCheckBoxListValue(lcl.LinkMenuListItem);
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_LinkValue", "");
            InputRequest.Add("txt_LinkTitle", "");
            InputRequest.Add("txt_LinkHref", "");
            InputRequest.Add("txt_LinkRel", "");
            InputRequest.Add("ddlst_LinkProtocol", LinkProtocolOptionListValue);
            InputRequest.Add("ddlst_LinkTarget", LinkTargetOptionListValue);
            InputRequest.Add("txt_LinkSortIndex", "");
            InputRequest.Add("cbxlst_LinkMenu", LinkMenuListValue);
            InputRequest.Add("hdn_LinkId", LinkIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/link/");

            LinkValueAttribute += vc.ImportantInputAttribute.GetValue("txt_LinkValue");
            LinkTitleAttribute += vc.ImportantInputAttribute.GetValue("txt_LinkTitle");
            LinkHrefAttribute += vc.ImportantInputAttribute.GetValue("txt_LinkHref");
            LinkRelAttribute += vc.ImportantInputAttribute.GetValue("txt_LinkRel");
            LinkProtocolAttribute += vc.ImportantInputAttribute.GetValue("ddlst_LinkProtocol");
            LinkTargetAttribute += vc.ImportantInputAttribute.GetValue("ddlst_LinkTarget");
            LinkSortIndexAttribute += vc.ImportantInputAttribute.GetValue("txt_LinkSortIndex");
            LinkMenuAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_LinkMenu");

            LinkValueCssClass = LinkValueCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_LinkValue"));
            LinkTitleCssClass = LinkTitleCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_LinkTitle"));
            LinkHrefCssClass = LinkHrefCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_LinkHref"));
            LinkRelCssClass = LinkRelCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_LinkRel"));
            LinkProtocolCssClass = LinkProtocolCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_LinkProtocol"));
            LinkTargetCssClass = LinkTargetCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("ddlst_LinkTarget"));
            LinkSortIndexCssClass = LinkSortIndexCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_LinkSortIndex"));
            LinkMenuCssClass = LinkMenuCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_LinkMenu"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/link/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
            }
        }

        public void SaveLink()
        {
            // Change Database Data
            DataUse.Link dul = new DataUse.Link();

            dul.LinkId = LinkIdValue;
            dul.LinkHref = LinkHrefValue;
            dul.LinkRel = LinkRelValue;
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
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/link/action/SuccessMessage.aspx");
        }
    }
}