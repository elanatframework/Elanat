using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace elanat
{
    public partial class SetDatabase : System.Web.UI.Page
    {
        public SetDatabaseModel model = new SetDatabaseModel();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["ddlst_Language"]))
                model.LanguageOptionListSelectedValue = Request.Form["ddlst_Language"];

            if (!string.IsNullOrEmpty(Request.Form["btn_SetConnectionString"]))
                btn_SetConnectionString_Click(sender, e);


            model.SetValue();
        }

        protected void btn_SetConnectionString_Click(object sender, EventArgs e)
        {
            model.ConnectionStringValue = Request.Form["txt_ConnectionString"];
            model.ServerNameValue = Request.Form["txt_ServerName"];
            model.DataBaseNameValue = Request.Form["txt_DatabaseName"];
            model.UserIdValue = Request.Form["txt_UserId"];
            model.PasswordValue = Request.Form["txt_Password"];
            model.LanguageOptionListSelectedValue = Request.Form["ddlst_Language"];

            if (model.ConnectToDataBaseCheck() && model.SetSqlScriptCheck())
            {
                model.SetConnectionString(sender, e);

                model.SetFirstTimeValue(sender, e);


                // Reset Application
                HttpRuntime.UnloadAppDomain();


                return;
            }


            // Set Current Value
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(HttpContext.Current.Server.MapPath("template/template.xml"));

            XmlNode TemplateNode = TemplateDocument.SelectSingleNode("template_root/part");

            XmlDocument LanguageDocument = new XmlDocument();
            LanguageDocument.Load(HttpContext.Current.Server.MapPath("language/" + model.LanguageOptionListSelectedValue + "/" + model.LanguageOptionListSelectedValue + ".xml"));

            XmlNode LanguageNode = LanguageDocument.SelectSingleNode("add_ons_language_root/add_ons_language");          

            if (model.ConnectToDataBaseCheck() && !model.SetSqlScriptCheck())
                Response.Write(TemplateNode["error_text"].InnerText.Replace("$_asp text;", LanguageNode["connection_attach_successfully_but_when_database_was_fill_error_occurred"].InnerText));

            if (!model.ConnectToDataBaseCheck())
                Response.Write(TemplateNode["error_text"].InnerText.Replace("$_asp text;", LanguageNode["connection_string_can_not_attach_to_database"].InnerText));
        }
    }
}