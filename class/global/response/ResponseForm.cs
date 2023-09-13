namespace Elanat
{
	public class ResponseForm
    {
        private List<string> MessageList = new List<string>();
        private List<string> PriorityList = new List<string>();
        private List<string> LocalMessageList = new List<string>();
        private List<string> LocalPriorityList = new List<string>();
        private List<string> PageLoadPathList = new List<string>();
        private List<string> PageLoadTagIdList = new List<string>();
        private List<string> ReturnFunctionList = new List<string>();
        private string GlobalLanguage = "";
        private bool UseRetrieved = false;

        public ResponseForm(string Language, bool IsRetrieved = false)
        {
            GlobalLanguage = Language;
            UseRetrieved = IsRetrieved;
        }

        /// <param name="Message">The Message Parameter That Be Translated</param>
        public void AddMessage(string Message, string Priority = "none")
        {
            MessageList.Add(Message);
            PriorityList.Add(Priority);
        }

        /// <param name="Message">Every Text In Message Parameter Show Without Translated</param>
        public void AddLocalMessage(string Message, string Priority = "none")
        {
            LocalMessageList.Add(Message);
            LocalPriorityList.Add(Priority);
        }

        public void AddPageLoad(string PageLoadPath, string PageLoadTagId)
        {
            PageLoadPathList.Add(PageLoadPath);
            PageLoadTagIdList.Add(PageLoadTagId);
        }

        public void AddReturnFunction(string FunctionName)
        {
            ReturnFunctionList.Add(FunctionName);
        }

        public void RedirectToResponseFormPage()
        {

            string MessagesQuery = "";
            string PrioritysQuery = "";
            string PageLoadPathQuery = "";
            string PageLoadTagIdQuery = "";
            string ReturnFunctionQuery = "";

            // Set Message
            int i = 1;
            foreach (string Message in MessageList)
            {
                MessagesQuery += "&message" + i.ToString() + "=" + MessageList[i - 1];
                PrioritysQuery += "&priority" + i.ToString() + "=" + PriorityList[i - 1];

                i++;
            }

            // Set Local Message
            i = 1;
            foreach (string Message in LocalMessageList)
            {
                MessagesQuery += "&local_message" + i.ToString() + "=" + LocalMessageList[i - 1];
                PrioritysQuery += "&local_priority" + i.ToString() + "=" + LocalPriorityList[i - 1];

                i++;
            }

            // Set Page Load Path
            i = 1;
            foreach (string PageLoadPath in PageLoadPathList)
            {
                // Set Load Access
                new HttpContextAccessor().HttpContext.Session.SetString("el_use_response_form_load_page_" + PageLoadPathList[i - 1], "_");

                PageLoadPathQuery += "&page_load_path" + i.ToString() + "=" + PageLoadPathList[i - 1].Replace("&", "$_asp amp;");
                PageLoadTagIdQuery += "&page_load_tag_id" + i.ToString() + "=" + PageLoadTagIdList[i - 1];

                i++;
            }

            // Set Return Function
            i = 1;
            foreach (string ReturnFunction in ReturnFunctionList)
            {
                ReturnFunctionQuery += "&return_function" + i.ToString() + "=" + ReturnFunctionList[i - 1];

                i++;
            }

            string UseRetrievedValue = (UseRetrieved) ? "&use_retrieved=true" : "&use_retrieved=false";


            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath + "action/response_form/Default.aspx?global_language=" + GlobalLanguage + MessagesQuery + PrioritysQuery + PageLoadPathQuery + PageLoadTagIdQuery + ReturnFunctionQuery + UseRetrievedValue, true);
        }

        /// <param name="Message">The Message Parameter That Be Translated</param>
        public static void WriteAlone(string Message, string Priority, string Language, bool IsRetrieved = false, string PageLoadPathQuery = "", string PageLoadTagIdQuery = "", string ReturnFunction = "")
        {
            // Set Load Access
            if (!string.IsNullOrEmpty(PageLoadPathQuery))
                new HttpContextAccessor().HttpContext.Session.SetString("el_use_response_form_load_page_" + PageLoadPathQuery, "_");

            string UseRetrievedValue = (IsRetrieved) ? "&use_retrieved=true" : "&use_retrieved=false";

            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath + "action/response_form/Default.aspx?global_language=" + Language + "&message1=" + Message + "&priority1=" + Priority + "&page_load_path1=" + PageLoadPathQuery.Replace("&", "$_asp amp;") + "&page_load_tag_id1=" + PageLoadTagIdQuery + "&return_function1=" + ReturnFunction + UseRetrievedValue, true);
        }

        /// <param name="Message">Every Text In Message Parameter Show Without Translated</param>
        public static void WriteLocalAlone(string Message, string Priority, bool IsRetrieved = false, string PageLoadPathQuery = "", string PageLoadTagIdQuery = "", string ReturnFunction = "")
        {
            // Set Load Access
            if (!string.IsNullOrEmpty(PageLoadPathQuery))
                new HttpContextAccessor().HttpContext.Session.SetString("el_use_response_form_load_page_" + PageLoadPathQuery, "_");

            string UseRetrievedValue = (IsRetrieved) ? "&use_retrieved=true" : "&use_retrieved=false";

            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath + "action/response_form/Default.aspx?global_language=en&local_message1=" + Message + "&local_priority1=" + Priority + "&page_load_path1=" + PageLoadPathQuery.Replace("&", "$_asp amp;") + "&page_load_tag_id1=" + PageLoadTagIdQuery + "&return_function1=" + ReturnFunction + UseRetrievedValue, true, false);
        }
    }
}