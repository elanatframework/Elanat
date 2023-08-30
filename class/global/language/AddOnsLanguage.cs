using System.Xml;

namespace Elanat
{
    public class AddOnsLanguage
    {
        XmlDocument doc = new XmlDocument();

        public AddOnsLanguage(string GlobalLanguage, string Path = null)
        {
            if (File.Exists(StaticObject.ServerMapPath(Path + "language/" + GlobalLanguage + "/" + GlobalLanguage + ".xml")))
                doc.Load(StaticObject.ServerMapPath(Path + "language/" + GlobalLanguage + "/" + GlobalLanguage + ".xml"));
            else
            {
                if (StaticObject.UseVariantDebug)
                    new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("language_asp_is_not_existed", GlobalLanguage).Replace("$_asp language_global_name;", GlobalLanguage), GlobalLanguage, "problem"));

                doc.Load(StaticObject.ServerMapPath(Path + "language/en/en.xml"));
            }
        }

        /// <param name="Word">Example: hello_world</param>
        public string GetAddOnsLanguage(string Word)
        {
            if (string.IsNullOrEmpty(Word))
                return null;


            XmlNode node = doc.SelectSingleNode("add_ons_language_root/add_ons_language/" + Word);

            if (node != null)
                return node.InnerText;
            else
                return Word + StaticObject.NullLanguageSuffix;
        }

        /// <param name="Content">Example: Before Text $_lang hello_world; After Text</param>
        public string GetAddOnsLanguageFromContent(string Content, bool BreakLanguage = false)
        {
            string lang = "";
            while (Content.Contains("$_lang "))
            {
                lang = Content.Split(new string[] { "$_lang " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                Content = Content.Replace("$_lang " + lang + ";", (BreakLanguage) ? GetBreakAddOnsLanguage(lang) : GetAddOnsLanguage(lang));
            }

            if (BreakLanguage)
                Content.Replace("$_tmp_lang ", "$_lang ");

            return Content;
        }

        /// <param name="Word">Example: hello_world. If Not Found Replace World With "$_tmp_lang " + Word + ";"</param>
        public string GetBreakAddOnsLanguage(string Word)
        {
            if (string.IsNullOrEmpty(Word))
                return null;


            XmlNode node = doc.SelectSingleNode("add_ons_language_root/add_ons_language/" + Word);

            if (node != null)
                return node.InnerText;
            else
                return "$_tmp_lang " + Word + ";";
        }
    }
}