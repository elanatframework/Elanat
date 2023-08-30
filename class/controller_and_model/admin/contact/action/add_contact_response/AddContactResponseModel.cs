using CodeBehind;

namespace Elanat
{
    public partial class ActionAddContactResponseModel : CodeBehindModel
    {
        public string ContactResponseLanguage { get; set; }
        public string ContactTitleLanguage { get; set; }
        public string ContactTextLanguage { get; set; }
        public string AddContactResponseLanguage { get; set; }

        public string ContactIdValue { get; set; }
        public string ContactTitleValue { get; set; }
        public string ContactTextValue { get; set; }
        public string ContactResponseValue { get; set; }

        public void SetValue()
        {
            // SetLanguage
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/contact/");
            AddContactResponseLanguage = aol.GetAddOnsLanguage("add_contact_response");
            ContactTitleLanguage = aol.GetAddOnsLanguage("contact_title");
            ContactTextLanguage = aol.GetAddOnsLanguage("contact_text");
            ContactResponseLanguage = aol.GetAddOnsLanguage("contact_response");

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_contact", "@contact_id", ContactIdValue);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return;
            }

            dbdr.dr.Read();

            ContactTitleValue = dbdr.dr["contact_title"].ToString();
            ContactTextValue = dbdr.dr["contact_text"].ToString();
            ContactResponseValue = dbdr.dr["contact_response_text"].ToString();

            db.Close();
        }

        public void AddContactResponse( )
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("add_contact_response", new List<string>() { "@contact_id", "@contact_response_text" }, new List<string>() { ContactIdValue, ContactResponseValue });

            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_contact_response", ContactIdValue);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/contact/action/add_contact_response/action/SuccessMessage.aspx", true);
        }
    }
}