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
    public class ActionEditAttachmentModel
    {
        public string AttachmentLanguage { get; set; }
        public string AttachmentNameLanguage { get; set; }
        public string AttachmentActiveLanguage { get; set; }
        public string AttachmentAboutLanguage { get; set; }
        public string AttachmentPasswordLanguage { get; set; }
        public string AttachmentContentLanguage { get; set; }
        public string AttachmentAccessShowLanguage { get; set; }
        public string AttachmentPublicAccessShowLanguage { get; set; }
        public string EditAttachmentLanguage { get; set; }
        public string SaveAttachmentLanguage { get; set; }

        public bool IsFirstStart { get; set; } = true;
        public string AttachmentIdValue { get; set; }

        public bool AttachmentActiveValue { get; set; } = false;
        public bool AttachmentPublicAccessShowValue { get; set; } = false;

        public string AttachmentNameValue { get; set; }
        public string AttachmentAboutValue { get; set; }
        public string AttachmentContentValue { get; set; }
        public string AttachmentPasswordValue { get; set; }

        public string AttachmentNameAttribute { get; set; }
        public string AttachmentAboutAttribute { get; set; }
        public string AttachmentContentAttribute { get; set; }
        public string AttachmentPasswordAttribute { get; set; }

        public string AttachmentNameCssClass { get; set; }
        public string AttachmentAboutCssClass { get; set; }
        public string AttachmentContentCssClass { get; set; }
        public string AttachmentPasswordCssClass { get; set; }

        public ListItemCollection AttachmentAccessShowListItem = new ListItemCollection();
        public string AttachmentAccessShowListValue { get; set; }
        public string AttachmentAccessShowTemplateValue { get; set; }

        public string AttachmentAccessShowAttribute { get; set; }
        public string AttachmentAccessShowCssClass { get; set; }

        public List<string> EvaluateErrorList;
		public bool FindEvaluateError = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/attachment/");
            SaveAttachmentLanguage = aol.GetAddOnsLanguage("save_attachment");
            EditAttachmentLanguage = aol.GetAddOnsLanguage("edit_attachment");
            AttachmentAboutLanguage = aol.GetAddOnsLanguage("attachment_about");
            AttachmentContentLanguage = aol.GetAddOnsLanguage("attachment_content");
            AttachmentNameLanguage = aol.GetAddOnsLanguage("attachment_name");
            AttachmentPasswordLanguage = aol.GetAddOnsLanguage("attachment_password");
            AttachmentAccessShowLanguage = aol.GetAddOnsLanguage("attachment_access_show");
            AttachmentPublicAccessShowLanguage = aol.GetAddOnsLanguage("attachment_public_access_show");
            AttachmentActiveLanguage = aol.GetAddOnsLanguage("attachment_active");


            // Set Current Value
            if (IsFirstStart)
            {
                DataUse.Attachment dua = new DataUse.Attachment();
                dua.FillCurrentAttachment(AttachmentIdValue);

                AttachmentNameValue = dua.AttachmentName;
                AttachmentAboutValue = dua.AttachmentAbout;
                AttachmentPasswordValue = dua.AttachmentPassword;
                AttachmentActiveValue = dua.AttachmentActive.ZeroOneToBoolean();
                AttachmentPublicAccessShowValue = dua.AttachmentPublicAccessShow.ZeroOneToBoolean();
            }

            ListClass lc = new ListClass();

            // Set User Role
            lc.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            HtmlCheckBoxList hcbl = new HtmlCheckBoxList(HttpContext.Current.Server.MapPath(StaticObject.AdminPath + "/attachment/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage());
            hcbl.AddRange(lc.UserRoleListItem);
            AttachmentAccessShowTemplateValue = hcbl.GetValue();
            AttachmentAccessShowListValue = hcbl.GetList();
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.Replace("$_asp attribute;", AttachmentAccessShowAttribute);
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.Replace("$_asp css_class;", AttachmentAccessShowCssClass);
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(AttachmentAccessShowListItem);

            // Set Attachment Access Show Selected Value
            lc.FillAttachmentAccessShowListItem(AttachmentIdValue);
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(lc.AttachmentAccessShowListItem);

            // Set Attachment Content Value
            lc.FillAttachmentContentListItem(AttachmentIdValue);
            foreach (ListItem item in lc.AttachmentContentListItem)
                AttachmentContentValue += item.Text + Environment.NewLine;
            if (lc.AttachmentContentListItem.Length > 0)
                AttachmentContentValue = AttachmentContentValue.Remove(AttachmentContentValue.Length - 2, 1);
        }

        public void SetImportantField()
        {
            NameValueCollection InputRequest = new NameValueCollection();

            InputRequest.Add("txt_AttachmentName", "");
            InputRequest.Add("txt_AttachmentPassword", "");
            InputRequest.Add("txt_AttachmentAbout", "");
            InputRequest.Add("txt_AttachmentContent", "");
            InputRequest.Add("cbxlst_AttachmentAccessShow", AttachmentAccessShowListValue);
            InputRequest.Add("hdn_AttachmentId", AttachmentIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/attachment/");

            AttachmentNameAttribute += vc.ImportantInputAttribute["txt_AttachmentName"];
            AttachmentPasswordAttribute += vc.ImportantInputAttribute["txt_AttachmentPassword"];
            AttachmentAboutAttribute += vc.ImportantInputAttribute["txt_AttachmentAbout"];
            AttachmentContentAttribute += vc.ImportantInputAttribute["txt_AttachmentContent"];
            AttachmentAccessShowAttribute += vc.ImportantInputAttribute["cbxlst_AttachmentAccessShow"];

            AttachmentNameCssClass = AttachmentNameCssClass.AddHtmlClass(vc.ImportantInputClass["txt_AttachmentName"]);
            AttachmentPasswordCssClass = AttachmentPasswordCssClass.AddHtmlClass(vc.ImportantInputClass["txt_AttachmentPassword"]);
            AttachmentAboutCssClass = AttachmentAboutCssClass.AddHtmlClass(vc.ImportantInputClass["txt_AttachmentAbout"]);
            AttachmentContentCssClass = AttachmentContentCssClass.AddHtmlClass(vc.ImportantInputClass["txt_AttachmentContent"]);
            AttachmentAccessShowCssClass = AttachmentAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass["cbxlst_AttachmentAccessShow"]);
        }

        public void EvaluateField(NameValueCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/attachment/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;

                // Decision Making After Migrating To New Platform
                //foreach (string EvaluateError in vc.EvaluateErrorList)
                //    GlobalClass.Alert(EvaluateError, StaticObject.GetCurrentAdminGlobalLanguage(), "problem");

                //AttachmentNameCssClass = AttachmentNameCssClass.AddHtmlClass(vc.WarningFieldClass["txt_AttachmentName"]);
                //AttachmentPasswordCssClass = AttachmentPasswordCssClass.AddHtmlClass(vc.WarningFieldClass["txt_AttachmentPassword"]);
                //AttachmentAboutCssClass = AttachmentAboutCssClass.AddHtmlClass(vc.WarningFieldClass["txt_AttachmentAbout"]);
                //AttachmentContentCssClass = AttachmentContentCssClass.AddHtmlClass(vc.WarningFieldClass["txt_AttachmentContent"]);
                //AttachmentAccessShowCssClass = AttachmentAccessShowCssClass.AddHtmlClass(vc.WarningFieldClass["cbxlst_AttachmentAccessShow"]);
            }
        }

        public void SaveAttachment()
        {
            // Change Database Data
            DataUse.Attachment dua = new DataUse.Attachment();

            dua.AttachmentId = AttachmentIdValue;
            dua.AttachmentName = AttachmentNameValue;
            dua.AttachmentAbout = AttachmentAboutValue;
            dua.AttachmentPassword = AttachmentPasswordValue;
            dua.AttachmentActive = AttachmentActiveValue.BooleanToZeroOne();
            dua.AttachmentPublicAccessShow = AttachmentPublicAccessShowValue.BooleanToZeroOne();

            // Edit Attachment
            dua.Edit();

            // Delete Attachment Access Show
            dua.DeleteAttachmentAccessShow(dua.AttachmentId);

            // Set Attachment Access Show
            dua.SetAttachmentAccessShow(dua.AttachmentId, AttachmentAccessShowListItem);

            // Delete Attachment Content
            dua.DeleteAttachmentContent(dua.AttachmentId);

            // Add Attachment Content
            string[] AttachmentContentIdList = AttachmentContentValue.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            dua.AddAttachmentContent(dua.AttachmentId, AttachmentContentIdList);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_attachment", dua.AttachmentName);
        }

        public void SuccessView()
        {
            HttpContext.Current.Response.Redirect(StaticObject.AdminPath + "/attachment/action/SuccessMessage.aspx");
        }
    }
}