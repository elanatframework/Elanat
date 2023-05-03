using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

namespace elanat
{
    public class SetDatabaseModel
    {
        public string ElanatLanguage { get; set; }
        public string SetConnectionStringLanguage { get; set; }
        public string ConnectionStringLanguage { get; set; }
        public string PasswordLanguage { get; set; }
        public string UserIdLanguage { get; set; }
        public string DatabaseNameLanguage { get; set; }
        public string ServerNameLanguage { get; set; }
        public string SetDatabaseConnectionLanguage { get; set; }
        public string YouShouldSetSqlServerDatabaseConnectionValuesBeforeInstallingLanguage { get; set; }
        public string SetElanatDatabaseLanguage { get; set; }
        public string LanguageLanguage { get; set; }
        public string EnglishLanguage { get; set; }
        public string PersianLanguage { get; set; }

        public string LanguageOptionListValue { get; set; }
        public string LanguageOptionListSelectedValue { get; set; } = "en";

        public string SetElanatDatabaseTemplateValue { get; set; }
        public string LanguageDirectionValue { get; set; } = "ltr";

        public string ServerNameValue { get; set; }
        public string DataBaseNameValue { get; set; }
        public string UserIdValue { get; set; }
        public string PasswordValue { get; set; }
        public string ConnectionStringValue { get; set; }

        public void SetValue()
        {
            // Set Current Value
            XmlDocument LanguageDocument = new XmlDocument();
            LanguageDocument.Load(HttpContext.Current.Server.MapPath("language/" + LanguageOptionListSelectedValue + "/" + LanguageOptionListSelectedValue + ".xml"));

            XmlNode LanguageNode = LanguageDocument.SelectSingleNode("add_ons_language_root/add_ons_language");

            XmlDocument TemplateDocument = new XmlDocument();
            TemplateDocument.Load(HttpContext.Current.Server.MapPath("template/template.xml"));

            XmlNode TemplateNode = TemplateDocument.SelectSingleNode("template_root/part");

            // Set Language
            ElanatLanguage = LanguageNode["elanat"].InnerText;
            SetConnectionStringLanguage = LanguageNode["set_connection_string"].InnerText;
            ConnectionStringLanguage = LanguageNode["connection_string"].InnerText;
            PasswordLanguage = LanguageNode["password"].InnerText;
            UserIdLanguage = LanguageNode["user_id"].InnerText;
            DatabaseNameLanguage = LanguageNode["database_name"].InnerText;
            ServerNameLanguage = LanguageNode["server_name"].InnerText;
            SetDatabaseConnectionLanguage = LanguageNode["set_database_connection"].InnerText;
            YouShouldSetSqlServerDatabaseConnectionValuesBeforeInstallingLanguage = LanguageNode["you_should_set_sql_server_database_connection_values_before_installing"].InnerText;
            SetElanatDatabaseLanguage = LanguageNode["set_elanat_database"].InnerText;
            LanguageLanguage = LanguageNode["language"].InnerText;
            EnglishLanguage = LanguageNode["english"].InnerText;
            PersianLanguage = LanguageNode["persian"].InnerText;

            LanguageDirectionValue = (LanguageOptionListSelectedValue == "en") ? "ltr" : "rtl";
            SetElanatDatabaseTemplateValue = LanguageNode["set_asp_database"].InnerText.Replace("$_asp elanat;", TemplateNode["elanat_green_text"].InnerText.Replace("$_lang elanat;", LanguageNode["elanat"].InnerText.ToUpperFirstChar()));


            LanguageOptionListValue = LanguageOptionListValue.HtmlInputAddOptionTag(LanguageNode["english"].InnerText + " (en)", "en");
            LanguageOptionListValue = LanguageOptionListValue.HtmlInputAddOptionTag(LanguageNode["persian"].InnerText + " (fa)", "fa");
            LanguageOptionListValue = LanguageOptionListValue.HtmlInputSetSelectValue(LanguageOptionListSelectedValue);
        }

        public void SetConnectionString(object sender, EventArgs e)
        {
            // Set Connection String
            var Lines = System.IO.File.ReadAllLines(HttpContext.Current.Server.MapPath("../App_Data/elanat_system_data/code/code.ini"));
            CodeSocket code = new CodeSocket();
            Lines[2] = "connection_string=" + code.Coder(ConnectionStringValue);
            System.IO.File.WriteAllLines(HttpContext.Current.Server.MapPath("../App_Data/elanat_system_data/code/code.ini"), Lines);
            
            Global g = new Global();
            g.Application_Start(sender, e);


            SuccessView(LanguageOptionListSelectedValue);
        }

        // Repeated In InstallModel Class
        public void SetFirstTimeValue(object sender, EventArgs e)
        {
            // Set Site Birthday
            ElanatConfig.SetElanatConfig(DateAndTime.GetDate("yyyy/MM/dd"), "date_and_time/site_birthday");
            ElanatConfig.SetElanatConfig(DataBaseNameValue, "security/database_name", "value");

            // Set Random String To Code Ini File
            StringClass sc = new StringClass();
            Security.SetCodeIni("lock_login_password_value", sc.GetCleanRandomText(32));
            Security.SetCodeIni("system_access_code", sc.GetCleanRandomText(32));


            ElanatConfig.GetNode("/security/database_name").Attributes["value"].Value = DataBaseNameValue;


            Global g = new Global();
            g.Application_Start(sender, e);
        }

        public bool ConnectToDataBaseCheck()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionStringValue);
                var cmd = new SqlCommand("select 1", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    con.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        public bool SetSqlScriptCheck()
        {
            var Lines = System.IO.File.OpenText(HttpContext.Current.Server.MapPath("App_Data/database_script/database_script.sql"));
            string SqlScript = Lines.ReadToEnd();
            Lines.Close();

            SqlScript = SqlScript.Replace("$_asp database_name;", DataBaseNameValue);

            SqlConnection con = new SqlConnection(ConnectionStringValue);
            try
            {
                con.Open();
                con.ChangeDatabase(DataBaseNameValue);

                IEnumerable<string> SqlScripCommands = Regex.Split(SqlScript, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                foreach (string Command in SqlScripCommands)
                {
                    if (!string.IsNullOrWhiteSpace(Command.Trim()))
                    {
                        using (var TmpCommand = new SqlCommand(Command, con))
                        {
                            TmpCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception) { }

            con.Close();


            SqlConnection con2 = new SqlConnection(ConnectionStringValue);
            con2.Open();
            var cmd = new SqlCommand("select * from el_component", con2);
            SqlDataReader dr = cmd.ExecuteReader();

            bool AttachIsSuccess = dr.HasRows;
            con2.Close();

            return AttachIsSuccess;
        }

        public void SuccessView(string Language)
        {
            HttpContext.Current.Response.Redirect(StaticObject.SitePath + "install/action/SuccessDatabaseMessage.aspx?language=" + Language, false);
        }
    }
}