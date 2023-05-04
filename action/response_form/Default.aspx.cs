using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionResponseForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string GlobalLanguage = Request.QueryString["global_language"].ToString();
            string AlertTemplate = Template.GetGlobalTemplate("part/alert", GlobalLanguage);

            // Write Message
            int i = 1;
            while (!string.IsNullOrEmpty(Request.QueryString["message" + i.ToString()]))
            {
                string Message = Request.QueryString["message" + i.ToString()].ToString();
                string Priority = Request.QueryString["priority" + i.ToString()].ToString();

                string TmpAlertTemplate = AlertTemplate;
                TmpAlertTemplate = TmpAlertTemplate.Replace("$_asp alert_text;", Language.GetLanguage(Message, GlobalLanguage));
                TmpAlertTemplate = TmpAlertTemplate.Replace("$_asp priority;", Priority);

                System.Web.HttpContext.Current.Response.Write(TmpAlertTemplate);

                i++;
            }

            // Write Local Message
            i = 1;
            while (!string.IsNullOrEmpty(Request.QueryString["local_message" + i.ToString()]))
            {
                string Message = Request.QueryString["local_message" + i.ToString()].ToString();
                string Priority = Request.QueryString["local_priority" + i.ToString()].ToString();

                string TmpAlertTemplate = AlertTemplate;
                TmpAlertTemplate = TmpAlertTemplate.Replace("$_asp alert_text;", Message);
                TmpAlertTemplate = TmpAlertTemplate.Replace("$_asp priority;", Priority);

                System.Web.HttpContext.Current.Response.Write(TmpAlertTemplate);

                i++;
            }

            // Write Page Load Path
            i = 1;
            while (!string.IsNullOrEmpty(Request.QueryString["page_load_path" + i.ToString()]))
            {
                string PageLoadPath = Request.QueryString["page_load_path" + i.ToString()].ToString().Replace("$_asp amp;", "&");
                string PageLoadTagId = Request.QueryString["page_load_tag_id" + i.ToString()].ToString();
                
                string PageLoadAfterSubmitTemplate = StaticObject.StructDocument.SelectSingleNode("struct_root/page_load_after_submit").InnerText;
                string PageContext = PageLoader.LoadWithServer(StaticObject.SitePath + PageLoadPath);

                StringClass sc = new StringClass();

                PageLoadAfterSubmitTemplate = PageLoadAfterSubmitTemplate.Replace("$_asp context;", PageContext);
                PageLoadAfterSubmitTemplate = PageLoadAfterSubmitTemplate.Replace("$_asp tag_id;", PageLoadTagId);

                System.Web.HttpContext.Current.Response.Write(PageLoadAfterSubmitTemplate);

                i++;
            }

            // Write Return Function
            i = 1;
            while (!string.IsNullOrEmpty(Request.QueryString["return_function" + i.ToString()]))
            {
                string ReturnFunction = Request.QueryString["return_function" + i.ToString()].ToString();

                string ReturnFunctionAfterSubmitTemplate = StaticObject.StructDocument.SelectSingleNode("struct_root/return_function_after_submit").InnerText;

                ReturnFunctionAfterSubmitTemplate = ReturnFunctionAfterSubmitTemplate.Replace("$_asp return_function;", ReturnFunction);

                System.Web.HttpContext.Current.Response.Write(ReturnFunctionAfterSubmitTemplate);

                i++;
            }


            if (!string.IsNullOrEmpty(Request.QueryString["use_tmp_bin_alert"]))
                if (Request.QueryString["use_tmp_bin_alert"].ToString() == "true")
                    SetTmpBinAlert();
        }

        public void SetTmpBinAlert()
        {
            GlobalClass.AlertLanguageVariant("add_on_file_try_to_add_file_to_bin_directory_but_framework_did_not_allow", StaticObject.GetCurrentAdminGlobalLanguage(), "help");
            GlobalClass.AlertLanguageVariant("if_you_try_to_add_a_file_to_bin_directory_framework_need_to_restart", StaticObject.GetCurrentAdminGlobalLanguage(), "help");
            GlobalClass.AlertLanguageVariant("for_do_it_you_can_click_in_the_below_link_to_restart_framework", StaticObject.GetCurrentAdminGlobalLanguage(), "help");

            string LinkTemplate = Template.GetSiteTemplate("link/common");
            string TmpLinkTemplate = "";

            TmpLinkTemplate = LinkTemplate;

            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_text;", Language.GetLanguage("restart_framework", StaticObject.GetCurrentAdminGlobalLanguage()));
            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path_alt;", Language.GetLanguage("restart_framework", StaticObject.GetCurrentAdminGlobalLanguage()));
            TmpLinkTemplate = TmpLinkTemplate.Replace("$_asp path;", StaticObject.AdminPath + "/refresh/action/MoveTmpBinDirectory.aspx");

            GlobalClass.Alert(TmpLinkTemplate, StaticObject.GetCurrentAdminGlobalLanguage());
        }
    }
}