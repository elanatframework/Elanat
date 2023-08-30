using CodeBehind;

namespace Elanat
{
    public partial class ActionEditAttachmentModel : CodeBehindModel
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

        public List<ListItem> AttachmentAccessShowListItem = new List<ListItem>();
        public string AttachmentAccessShowListValue { get; set; }
        public string AttachmentAccessShowTemplateValue { get; set; }

        public string AttachmentAccessShowAttribute { get; set; }
        public string AttachmentAccessShowCssClass { get; set; }

        public List<string> EvaluateErrorList;
        public List<ListItem> WarningFieldClassList = new List<ListItem>();
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

            // Set User Role
            ListClass.User lcu = new ListClass.User();
            lcu.FillUserRoleListItem(StaticObject.GetCurrentAdminGlobalLanguage());
            HtmlCheckBoxList hcbl = new HtmlCheckBoxList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/attachment/template/check_box_list.xml"), StaticObject.GetCurrentAdminGlobalLanguage());
            hcbl.AddRange(lcu.UserRoleListItem);
            AttachmentAccessShowTemplateValue = hcbl.GetValue();
            AttachmentAccessShowListValue = hcbl.GetList();
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.Replace("$_asp attribute;", AttachmentAccessShowAttribute);
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.Replace("$_asp css_class;", AttachmentAccessShowCssClass);
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(AttachmentAccessShowListItem);

            ListClass.Attachment lca = new ListClass.Attachment();

            // Set Attachment Access Show Selected Value
            lca.FillAttachmentAccessShowListItem(AttachmentIdValue);
            AttachmentAccessShowTemplateValue = AttachmentAccessShowTemplateValue.HtmlInputSetCheckBoxListValue(lca.AttachmentAccessShowListItem);

            // Set Attachment Content Value
            lca.FillAttachmentContentListItem(AttachmentIdValue);
            for (int i = 0; i < lca.AttachmentContentListItem.Count; i++)
            {
                string NewLine = ((i + 1) == lca.AttachmentContentListItem.Count) ? "" : Environment.NewLine;
                AttachmentContentValue += lca.AttachmentContentListItem[i].Text + NewLine;
            }
        }

        public void SetImportantField()
        {
            List<ListItem> InputRequest = new List<ListItem>();

            InputRequest.Add("txt_AttachmentName", "");
            InputRequest.Add("txt_AttachmentPassword", "");
            InputRequest.Add("txt_AttachmentAbout", "");
            InputRequest.Add("txt_AttachmentContent", "");
            InputRequest.Add("cbxlst_AttachmentAccessShow", AttachmentAccessShowListValue);
            InputRequest.Add("hdn_AttachmentId", AttachmentIdValue);


            ValidationClass vc = new ValidationClass();
            vc.SetImportantField(InputRequest, true, StaticObject.AdminPath + "/attachment/");

            AttachmentNameAttribute += vc.ImportantInputAttribute.GetValue("txt_AttachmentName");
            AttachmentPasswordAttribute += vc.ImportantInputAttribute.GetValue("txt_AttachmentPassword");
            AttachmentAboutAttribute += vc.ImportantInputAttribute.GetValue("txt_AttachmentAbout");
            AttachmentContentAttribute += vc.ImportantInputAttribute.GetValue("txt_AttachmentContent");
            AttachmentAccessShowAttribute += vc.ImportantInputAttribute.GetValue("cbxlst_AttachmentAccessShow");

            AttachmentNameCssClass = AttachmentNameCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_AttachmentName"));
            AttachmentPasswordCssClass = AttachmentPasswordCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_AttachmentPassword"));
            AttachmentAboutCssClass = AttachmentAboutCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_AttachmentAbout"));
            AttachmentContentCssClass = AttachmentContentCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("txt_AttachmentContent"));
            AttachmentAccessShowCssClass = AttachmentAccessShowCssClass.AddHtmlClass(vc.ImportantInputClass.GetValue("cbxlst_AttachmentAccessShow"));
        }

        public void EvaluateField(IFormCollection FormData)
        {
            ValidationClass vc = new ValidationClass();
            vc.EvaluateField(FormData, StaticObject.GetCurrentAdminGlobalLanguage(), true, "", StaticObject.AdminPath + "/attachment/");

            EvaluateErrorList = vc.EvaluateErrorList;

            if (!vc.TrueContinue)
            {
                FindEvaluateError = true;
                WarningFieldClassList = vc.WarningFieldClass;
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
            string[] AttachmentContentIdList = AttachmentContentValue.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            dua.AddAttachmentContent(dua.AttachmentId, AttachmentContentIdList);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_edit_attachment", dua.AttachmentName);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/attachment/action/SuccessMessage.aspx");
        }
    }
}