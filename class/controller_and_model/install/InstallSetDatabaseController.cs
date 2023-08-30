using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class InstallSetDatabaseController : CodeBehindController
    {
        public InstallSetDatabaseModel model = new InstallSetDatabaseModel();
        
        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Form["ddlst_Language"]))
                model.LanguageOptionListSelectedValue = context.Request.Form["ddlst_Language"];


            if (!string.IsNullOrEmpty(context.Request.Form["btn_SetConnectionString"]))
            {
                btn_SetConnectionString_Click(context);

                if (IgnoreViewAndModel)
                    return;
            }


            model.SetValue();

            View(model);
        }

        protected void btn_SetConnectionString_Click(HttpContext context)
        {
            model.ConnectionStringValue = context.Request.Form["txt_ConnectionString"];
            model.ServerNameValue = context.Request.Form["txt_ServerName"];
            model.DataBaseNameValue = context.Request.Form["txt_DatabaseName"];
            model.UserIdValue = context.Request.Form["txt_UserId"];
            model.PasswordValue = context.Request.Form["txt_Password"];
            model.LanguageOptionListSelectedValue = context.Request.Form["ddlst_Language"];

            if (model.ConnectToDataBaseCheck() && model.SetSqlScriptCheck())
            {
                model.SetConnectionString(context);

                model.SetFirstTimeValue();

                IgnoreViewAndModel = true;

                return;
            }


            // Set Current Value
            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(StaticObject.ServerMapPath(StaticObject.WebMapPath() + "/template/template.xml"));

            XmlNode TemplateNode = TemplateDocument.SelectSingleNode("template_root/part");

            XmlDocument LanguageDocument = new XmlDocument();
            LanguageDocument.Load(StaticObject.ServerMapPath(StaticObject.WebMapPath() + "/language/" + model.LanguageOptionListSelectedValue + "/" + model.LanguageOptionListSelectedValue + ".xml"));

            XmlNode LanguageNode = LanguageDocument.SelectSingleNode("add_ons_language_root/add_ons_language");          

            if (model.ConnectToDataBaseCheck() && !model.SetSqlScriptCheck())
                Write(TemplateNode["error_text"].InnerText.Replace("$_asp text;", LanguageNode["connection_attach_successfully_but_when_database_was_fill_error_occurred"].InnerText));

            if (!model.ConnectToDataBaseCheck())
                Write(TemplateNode["error_text"].InnerText.Replace("$_asp text;", LanguageNode["connection_string_can_not_attach_to_database"].InnerText));
        }
    }
}