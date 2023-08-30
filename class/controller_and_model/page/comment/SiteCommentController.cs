using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class SiteCommentController : CodeBehindController
    {
        public SiteCommentModel model = new SiteCommentModel();

        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["btn_SendComment"]))
            {
                btn_SendComment_Click(context);
                return;
            }

            if (string.IsNullOrEmpty(model.ContentIdValue))
            {
                if (string.IsNullOrEmpty(context.Request.Query["content_id"]))
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                if (!context.Request.Query["content_id"].ToString().IsNumber())
                {
                    IgnoreViewAndModel = true;
                    return;
                }

                model.ContentIdValue = context.Request.Query["content_id"].ToString();
            }

            if (string.IsNullOrEmpty(model.ParentCommentValue))
                if (string.IsNullOrEmpty(context.Request.Query["comment_id"]))
                    model.ParentCommentValue = "0";
                else
                    if (!context.Request.Query["comment_id"].ToString().IsNumber())
                    {
                        IgnoreViewAndModel = true;
                        return;
                    }
                    else
                        model.ParentCommentValue = context.Request.Query["comment_id"].ToString();


            if (string.IsNullOrEmpty(context.Request.Form["ddlst_Type"]))
                if (!string.IsNullOrEmpty(context.Request.Query["comment_type"]))
                    model.TypeOptionListSelectedValue = context.Request.Query["comment_type"].ToString();


            model.SetValue();


            // Set Required Field Validation
            model.SetImportantField();

            View(model);
        }

        protected void btn_SendComment_Click(HttpContext context)
        {
            // Set Option Value
            XmlDocument CommentOptionDocument = new XmlDocument();
            CommentOptionDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/comment_option/option/comment_option.xml"));
            XmlNode node = CommentOptionDocument.SelectSingleNode("comment_option_root");


            model.ContentIdValue = context.Request.Form["hdn_ContentId"];
            model.ParentCommentValue = context.Request.Form["hdn_ParentComment"];

            if (node["file"].Attributes["active"].Value == "true")
            {
                model.UseUploadPathValue = context.Request.Form["cbx_UseUploadPath"] == "on";
                model.UploadPathTextValue = context.Request.Form["txt_UploadPath"];
                model.UploadPathUploadValue = context.Request.Form.Files["upd_UploadPath"];
            }

            if (!string.IsNullOrEmpty(context.Request.Form["txt_Text"]) && node["text"].Attributes["active"].Value == "true")
                model.TextValue = context.Request.Form["txt_Text"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_Title"]) && node["title"].Attributes["active"].Value == "true")
                model.TitleValue = context.Request.Form["txt_Title"];

            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_BirthdayYear"]) && node["birthday"].Attributes["active"].Value == "true")
            {
                model.BirthdayYearOptionListSelectedValue = context.Request.Form["ddlst_BirthdayYear"];
                model.BirthdayMountOptionListSelectedValue = context.Request.Form["ddlst_BirthdayMount"];
                model.BirthdayDayOptionListSelectedValue = context.Request.Form["ddlst_BirthdayDay"];
            }
            else
            {
                model.BirthdayYearOptionListSelectedValue = "0000";
                model.BirthdayMountOptionListSelectedValue = "00";
                model.BirthdayDayOptionListSelectedValue = "00";
            }

            if (!string.IsNullOrEmpty(context.Request.Form["txt_Email"]) && node["email"].Attributes["active"].Value == "true")
                model.EmailValue = context.Request.Form["txt_Email"];

            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_Type"]) && node["type"].Attributes["active"].Value == "true")
                model.TypeOptionListSelectedValue = context.Request.Form["ddlst_Type"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_About"]) && node["about"].Attributes["active"].Value == "true")
                model.AboutValue = context.Request.Form["txt_About"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_Address"]) && node["address"].Attributes["active"].Value == "true")
                model.AddressValue = context.Request.Form["txt_Address"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_City"]) && node["city"].Attributes["active"].Value == "true")
                model.CityValue = context.Request.Form["txt_City"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_Country"]) && node["country"].Attributes["active"].Value == "true")
                model.CountryValue = context.Request.Form["txt_Country"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_MobileNumber"]) && node["mobile_number"].Attributes["active"].Value == "true")
                model.MobileNumberValue = context.Request.Form["txt_MobileNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_PhoneNumber"]) && node["phone_number"].Attributes["active"].Value == "true")
                model.PhoneNumberValue = context.Request.Form["txt_PhoneNumber"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_PostalCode"]) && node["postal_code"].Attributes["active"].Value == "true")
                model.PostalCodeValue = context.Request.Form["txt_PostalCode"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_PublicEmail"]) && node["public_email"].Attributes["active"].Value == "true")
                model.PublicEmailValue = context.Request.Form["txt_PublicEmail"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_RealName"]) && node["name"].Attributes["active"].Value == "true")
                model.RealNameValue = context.Request.Form["txt_RealName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_RealLastName"]) && node["last_name"].Attributes["active"].Value == "true")
                model.RealLastNameValue = context.Request.Form["txt_RealLastName"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_StateOrProvince"]) && node["state_or_province"].Attributes["active"].Value == "true")
                model.StateOrProvinceValue = context.Request.Form["txt_StateOrProvince"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_Website"]) && node["website"].Attributes["active"].Value == "true")
                model.WebsiteValue = context.Request.Form["txt_Website"];

            if (!string.IsNullOrEmpty(context.Request.Form["txt_ZipCode"]) && node["zip_code"].Attributes["active"].Value == "true")
                model.ZipCodeValue = context.Request.Form["txt_ZipCode"];

            if (!string.IsNullOrEmpty(context.Request.Form["rdbtn_Gender"]) && node["gender"].Attributes["active"].Value == "true")
            {
                model.GenderMaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderMale";
                model.GenderFemaleValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderFemale";
                model.GenderUnknownValue = context.Request.Form["rdbtn_Gender"] == "rdbtn_GenderUnknown";
            }
            else
                model.GenderUnknownValue = true;

            model.CaptchaTextValue = context.Request.Form["txt_Captcha"];


            // Evaluate Field Check
            model.EvaluateField(context.Request.Form);
            if (model.FindEvaluateError)
            {
                ResponseForm rf = new ResponseForm(StaticObject.GetCurrentSiteGlobalLanguage());

                foreach (string EvaluateError in model.EvaluateErrorList)
                    rf.AddLocalMessage(EvaluateError, "problem");

                rf.AddReturnFunction("el_SetWarningField('" + model.WarningFieldClassList.SplitText("$") + "', '" + model.WarningFieldClassList.SplitValue("$") + "')");

                rf.RedirectToResponseFormPage();

                IgnoreViewAndModel = true;

                return;
            }


            if (ElanatConfig.GetNode("active/add_comment").Attributes["active"].Value != "true")
            {
                model.AddCommentInactiveView();

                View(model);

                return;
            }

            if (!model.CaptchaTextValue.MatchByCaptcha())
            {
                model.CaptchaIncorrectErrorView();

                View(model);

                return;
            }


            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            DataUse.Comment duc = new DataUse.Comment();

            // Add Comment Reply To Own Content Access Check
            if (model.ParentCommentValue != "0")
            {
                DataUse.Content Duc = new DataUse.Content();

                if (!Duc.IsUserContent(ccoc.UserId, model.ContentIdValue))
                {
                    if (StaticObject.RoleReplyCommentOnlyOwnContentCheck())
                    {
                        model.RoleAccessReplyErrorView();

                        View(model);

                        return;
                    }
                }
            }

            // Add Comment Reply Access Check
            if (model.ParentCommentValue != "0")
            {
                if (!StaticObject.RoleReplyCommentAllContentCheck())
                {
                    model.RoleAccessReplyErrorView();

                    View(model);

                    return;
                }
            }

            // Check Content Comment Send
            if ((model.ParentCommentValue != "0") ? !duc.GetContentVerifyCommentsByCommentId(model.ParentCommentValue) : !duc.GetContentVerifyCommentsByContentId(model.ContentIdValue))
            {
                model.AddCommentInContentInactiveErrorView();

                View(model);

                return;
            }


            model.SendComment();


            model.SuccessView();

            View(model);
        }
    }
}