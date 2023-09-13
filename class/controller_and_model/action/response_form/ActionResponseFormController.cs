using CodeBehind;

namespace Elanat
{
    public partial class ActionResponseFormController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            string GlobalLanguage = context.Request.Query["global_language"].ToString();
            string AlertTemplate = Template.GetGlobalTemplate("part/alert", GlobalLanguage);

            // Write Message
            int i = 1;
            while (!string.IsNullOrEmpty(context.Request.Query["message" + i.ToString()]))
            {
                string Message = context.Request.Query["message" + i.ToString()].ToString();
                string Priority = context.Request.Query["priority" + i.ToString()].ToString();

                string TmpAlertTemplate = AlertTemplate;
                TmpAlertTemplate = TmpAlertTemplate.Replace("$_asp alert_text;", Language.GetLanguage(Message, GlobalLanguage));
                TmpAlertTemplate = TmpAlertTemplate.Replace("$_asp priority;", Priority);

                Write(TmpAlertTemplate);

                i++;
            }

            // Write Local Message
            i = 1;
            while (!string.IsNullOrEmpty(context.Request.Query["local_message" + i.ToString()]))
            {
                string Message = context.Request.Query["local_message" + i.ToString()].ToString();
                string Priority = context.Request.Query["local_priority" + i.ToString()].ToString();

                string TmpAlertTemplate = AlertTemplate;
                TmpAlertTemplate = TmpAlertTemplate.Replace("$_asp alert_text;", Message);
                TmpAlertTemplate = TmpAlertTemplate.Replace("$_asp priority;", Priority);

                Write(TmpAlertTemplate);

                i++;
            }

            // Write Page Load Path
            i = 1;
            while (!string.IsNullOrEmpty(context.Request.Query["page_load_path" + i.ToString()]))
            {
                string PageLoadPath = context.Request.Query["page_load_path" + i.ToString()].ToString().Replace("$_asp amp;", "&");
                string PageLoadTagId = context.Request.Query["page_load_tag_id" + i.ToString()].ToString();
                
                string PageLoadAfterSubmitTemplate = StaticObject.StructDocument.SelectSingleNode("struct_root/page_load_after_submit").InnerText;


                // Prevent Loop
                if (PageLoadPath.Contains("response_form"))
                {
                    i++;
                    continue;
                }


                // Check Load Access
                if (context.Session.GetString("el_use_response_form_load_page_" + PageLoadPath) == null)
                {
                    i++;
                    continue;
                }

                context.Session.Remove("el_use_response_form_load_page_" + PageLoadPath);


                string PageContext = PageLoader.LoadPath(PageLoadPath);

                PageLoadAfterSubmitTemplate = PageLoadAfterSubmitTemplate.Replace("$_asp context;", PageContext);
                PageLoadAfterSubmitTemplate = PageLoadAfterSubmitTemplate.Replace("$_asp tag_id;", PageLoadTagId);

                Write(PageLoadAfterSubmitTemplate);

                i++;
            }

            // Write Return Function
            i = 1;
            while (!string.IsNullOrEmpty(context.Request.Query["return_function" + i.ToString()]))
            {
                string ReturnFunction = context.Request.Query["return_function" + i.ToString()].ToString();

                string ReturnFunctionAfterSubmitTemplate = StaticObject.StructDocument.SelectSingleNode("struct_root/return_function_after_submit").InnerText;

                ReturnFunctionAfterSubmitTemplate = ReturnFunctionAfterSubmitTemplate.Replace("$_asp return_function;", ReturnFunction);

                Write(ReturnFunctionAfterSubmitTemplate);

                i++;
            }
        }
    }
}