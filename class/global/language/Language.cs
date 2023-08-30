using System.Xml;

namespace Elanat
{
    public class Language
    {
        /// <param name="Word">Example: hello_world</param>
        public static string GetLanguage(string Word, string GlobalLanguage)
        {
            if (string.IsNullOrEmpty(Word))
                return null;

            if (Word.Contains(' '))
                return null;

            XmlNode node = StaticObject.CurrentLanguageDocument(GlobalLanguage).SelectSingleNode("language_root/lang_" + Word[0] + "/" + Word);

            if (node != null)
                return node.InnerText;
            else
                return Word + StaticObject.NullLanguageSuffix;
        }

        /// <param name="Word">Example: hello_world. If Not Found Replace World With "$_tmp_lang " + Word + ";"</param>
        public static string GetBreakLanguage(string Word, string GlobalLanguage)
        {
            if (string.IsNullOrEmpty(Word))
                return null;

            if (Word.Contains(' '))
                return null;

            XmlNode node = StaticObject.CurrentLanguageDocument(GlobalLanguage).SelectSingleNode("language_root/lang_" + Word[0] + "/" + Word);

            if (node != null)
                return node.InnerText;
            else
                return "$_tmp_lang " + Word + ";";
        }

        /// <param name="Word">Example: hello_world. If Not Found Replace World With "$_tmp_lang " + Word + ";"</param>
        public static string GetBreakAddOnsLanguage(string Word, string GlobalLanguage, string Path = null)
        {
            if (string.IsNullOrEmpty(Word))
                return null;

            if (Word.Contains(' '))
                return null;

            XmlDocument doc = new XmlDocument();

            if (!File.Exists(StaticObject.ServerMapPath(Path + "language/" + GlobalLanguage + "/" + GlobalLanguage + ".xml")))
            { 
                if (StaticObject.UseVariantDebug)
                    new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("language_asp_is_not_existed", GlobalLanguage).Replace("$_asp language_global_name;", GlobalLanguage), GlobalLanguage, "problem"));

                return "";
            }

            doc.Load(StaticObject.ServerMapPath(Path + "language/" + GlobalLanguage + "/" + GlobalLanguage + ".xml"));
            XmlNode node = doc.SelectSingleNode("add_ons_language_root/add_ons_language/" + Word);

            if (node != null)
                return node.InnerText;
            else
                return "$_tmp_lang " + Word + ";";
        }

        /// <param name="Content">Example: Before Text $_lang hello_world; After Text</param>
        public static string GetLanguageFromContent(string Content, string GlobalLanguage, bool BreakLanguage = false) 
        {
            string lang = "";
            while (Content.Contains("$_lang "))
            {
                lang = Content.Split(new string[] { "$_lang " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                Content = Content.Replace("$_lang " + lang + ";", (BreakLanguage) ? GetBreakLanguage(lang, GlobalLanguage) : GetLanguage(lang, GlobalLanguage));
            }

            if (BreakLanguage)
                Content.Replace("$_tmp_lang ", "$_lang ");

            return Content;
        }

        /// <param name="Word">Example: hello_world</param>
        public static string GetAddOnsLanguage(string Word, string GlobalLanguage, string Path = null)
        {
            if (string.IsNullOrEmpty(Word))
                return null;

            if (Word.Contains(' '))
                return null;

            XmlDocument doc = new XmlDocument();

            if (File.Exists(StaticObject.ServerMapPath(Path + "language/" + GlobalLanguage + "/" + GlobalLanguage + ".xml")))
                doc.Load(StaticObject.ServerMapPath(Path + "language/" + GlobalLanguage + "/" + GlobalLanguage + ".xml"));
            else
            {
                if(StaticObject.UseVariantDebug)
                    new HttpContextAccessor().HttpContext.Response.WriteAsync(GlobalClass.Alert(Language.GetLanguage("language_asp_is_not_existed", GlobalLanguage).Replace("$_asp language_global_name;", GlobalLanguage), GlobalLanguage, "problem"));

                doc.Load(StaticObject.ServerMapPath(Path + "language/en/en.xml"));
            }

            XmlNode node = doc.SelectSingleNode("add_ons_language_root/add_ons_language/" + Word);

            if (node != null)
                return node.InnerText;
            else
                return Word + StaticObject.NullLanguageSuffix;
        }

        /// <param name="Content">Example: Before Text $_lang hello_world; After Text</param>
        public static string GetAddOnsLanguageFromContent(string Content, string GlobalLanguage, string Path = null, bool BreakLanguage = false)
        {
            string lang = "";
            while (Content.Contains("$_lang "))
            {
                lang = Content.Split(new string[] { "$_lang " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                Content = Content.Replace("$_lang " + lang + ";", (BreakLanguage) ? GetBreakAddOnsLanguage(lang, GlobalLanguage, Path) : GetAddOnsLanguage(lang, GlobalLanguage, Path));
            }

            if (BreakLanguage)
                Content.Replace("$_tmp_lang ", "$_lang ");

            return Content;
        }

        /// <param name="Word">Example: hello_world</param>
        public static string GetHandheldLanguage(string Word, string GlobalLanguage)
        {
            if (string.IsNullOrEmpty(Word))
                return null;

            if (Word.Contains(' '))
                return null;

            XmlNode node = StaticObject.CurrentHandheldLanguageDocument(GlobalLanguage).SelectSingleNode("language_root/lang_" + Word[0] + "/" + Word);

            if (node != null)
                return node.InnerText;
            else
                return Word + StaticObject.NullLanguageSuffix;
        }

        /// <param name="Word">Example: hello_world</param>
        public static string GetHandheldLanguageWithoutNullLanguageSuffix(string Word, string GlobalLanguage)
        {
            if (string.IsNullOrEmpty(Word))
                return null;

            if (Word.Contains(' '))
                return Word;

            if (!Word.IsUlString())
                return Word;

            XmlNode node = StaticObject.CurrentHandheldLanguageDocument(GlobalLanguage).SelectSingleNode("language_root/lang_" + Word[0] + "/" + Word);

            if (node != null)
                return node.InnerText;
            else
                return Word;
        }

        /// <param name="Word">Example: lang_h/hello_world</param>
        public static string GetPathLanguage(string Word, string GlobalLanguage, string Path = null)
        {
            if (string.IsNullOrEmpty(Word))
                return null;

            if (Word.Contains(' '))
                return null;

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(Path + "/language/" + GlobalLanguage + "/" + GlobalLanguage + ".xml"));
            XmlNode node = doc.SelectSingleNode("add_ons_language_root/add_ons_language/" + Word);

            if (node != null)
                return node.InnerText;
            else
                return Word + StaticObject.NullLanguageSuffix;
        }

        /// <param name="Word">Example: lang_h/hello_world</param>
        public static string GetLanguageWithTagName(string TagName,string GlobalLanguage)
        {
            try
            {
                XmlNode node = StaticObject.CurrentLanguageDocument(GlobalLanguage).SelectSingleNode("language_root/" + TagName);

                return node.InnerText;
            }
            catch(Exception ex)
            {
                Security.SetLogError(ex, GlobalLanguage);
                return TagName + StaticObject.NullLanguageSuffix;
            }
        }

        public static string GetLanguageWithTagId(int TagId, string GlobalLanguage)
        {
            try
            {
                XmlNodeList node = StaticObject.CurrentLanguageDocument(GlobalLanguage).SelectSingleNode("language_root/").ChildNodes;

                return node[TagId].InnerText;
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex, GlobalLanguage);
                return TagId + StaticObject.NullLanguageSuffix;
            }
        }

        public static XmlNodeList GetHandheldLanguageVariantNodeList(string LanguageCharacter, string GlobalLanguage)
        {
            try
            {
                XmlNodeList NodeList = StaticObject.CurrentHandheldLanguageDocument(GlobalLanguage).SelectSingleNode("language_root/lang_" + LanguageCharacter).ChildNodes;

                return NodeList;
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex, GlobalLanguage);
                return null;
            }
        }

        public static XmlNodeList GetLanguageVariantNodeList(string LanguageCharacter, string GlobalLanguage)
        {
            try
            {
                XmlNodeList NodeList = StaticObject.CurrentLanguageDocument(GlobalLanguage).SelectSingleNode("language_root/lang_" + LanguageCharacter).ChildNodes;

                return NodeList;
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex, GlobalLanguage);
                return null;
            }
        }

        public static string GetCurrentHandheldLanguageValue(string LanguageVariant, string GlobalLanguage)
        {
            try
            {
                char FirstCharacter = LanguageVariant[0];

                XmlNode Node = StaticObject.CurrentHandheldLanguageDocument(GlobalLanguage).SelectSingleNode("language_root/lang_" + FirstCharacter + "/" + LanguageVariant);

                return Node.InnerText;
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex, GlobalLanguage);
                return null;
            }
        }

        public static string GetCurrentLanguageValue(string LanguageVariant, string GlobalLanguage)
        {
            try
            {
                char FirstCharacter = LanguageVariant[0];

                XmlNode Node = StaticObject.CurrentLanguageDocument(GlobalLanguage).SelectSingleNode("language_root/lang_" + FirstCharacter + "/" + LanguageVariant);

                return Node.InnerText;
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex, GlobalLanguage);
                return null;
            }
        }

        public static void EditHandheldLanguageVariant(string LanguageVariant, string LanguageValue, string GlobalLanguage)
        {
            try
            {
                char FirstCharacter = LanguageVariant[0];

                string XmlPath = StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + GlobalLanguage + "/handheld.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(XmlPath);

                doc.SelectSingleNode("language_root/lang_" + FirstCharacter + "/" + LanguageVariant).InnerText = LanguageValue;

                doc.Save(XmlPath);
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex, GlobalLanguage);
            }
        }

        public static void EditLanguageVariant(string LanguageVariant, string LanguageValue, string GlobalLanguage)
        {
            try
            {
                char FirstCharacter = LanguageVariant[0];

                string XmlPath = StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + GlobalLanguage + "/" + GlobalLanguage + ".xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(XmlPath);

                doc.SelectSingleNode("language_root/lang_" + FirstCharacter + "/" + LanguageVariant).InnerText = LanguageValue;

                doc.Save(XmlPath);
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex, GlobalLanguage);
            }
        }

        public static void DeleteHandheldLanguageVariant(string LanguageVariant, string GlobalLanguage)
        {
            try
            {
                char FirstCharacter = LanguageVariant[0];

                string XmlPath = StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + GlobalLanguage + "/handheld.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(XmlPath);

                XmlNode CurrentNode = doc.SelectSingleNode("language_root/lang_" + FirstCharacter + "/" + LanguageVariant);

                doc.SelectSingleNode("language_root/lang_" + FirstCharacter).RemoveChild(CurrentNode);

                doc.Save(XmlPath);
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex, GlobalLanguage);
            }
        }

        public static void DeleteLanguageVariant(string LanguageVariant, string GlobalLanguage)
        {
            try
            {
                char FirstCharacter = LanguageVariant[0];

                string XmlPath = StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + GlobalLanguage + "/" + GlobalLanguage + ".xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(XmlPath);

                XmlNode CurrentNode = doc.SelectSingleNode("language_root/lang_" + FirstCharacter + "/" + LanguageVariant);

                doc.SelectSingleNode("language_root/lang_" + FirstCharacter).RemoveChild(CurrentNode);

                doc.Save(XmlPath);
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex, GlobalLanguage);
            }
        }

        public static void AddHandheldLanguageVariant(string LanguageVariant, string LanguageValue, string GlobalLanguage)
        {
            try
            {
                char FirstCharacter = LanguageVariant[0];

                string XmlPath = StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + GlobalLanguage + "/handheld.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(XmlPath);

                XmlElement LanguageElement = doc.CreateElement(LanguageVariant);
                LanguageElement.InnerText = LanguageValue;

                doc.SelectSingleNode("language_root/lang_" + FirstCharacter).AppendChild(LanguageElement);

                doc.Save(XmlPath);
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex, GlobalLanguage);
            }
        }

        public static void AddLanguageVariant(string LanguageVariant, string LanguageValue, string GlobalLanguage)
        {
            try
            {
                char FirstCharacter = LanguageVariant[0];

                string XmlPath = StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + GlobalLanguage + "/" + GlobalLanguage + ".xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(XmlPath);

                XmlElement LanguageElement = doc.CreateElement(LanguageVariant);
                LanguageElement.InnerText = LanguageValue;

                doc.SelectSingleNode("language_root/lang_" + FirstCharacter).AppendChild(LanguageElement);

                doc.Save(XmlPath);
            }
            catch (Exception ex)
            {
                Security.SetLogError(ex, GlobalLanguage);
            }
        }
    }
}