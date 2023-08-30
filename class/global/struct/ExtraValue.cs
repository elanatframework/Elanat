using System.Xml;

namespace Elanat
{
    public class ExtraValue
    {
        public ExtraValue()
        {
            Reset();
        }
        public string FilePhysicalName { get; set; }
        public string SiteGlobalName { get; set; }
        public string SiteName { get; set; }
        public string SiteTitle { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string TagName { get; set; }
        public string ContentId { get; set; }
        public string ContentTitle { get; set; }
        public string PageId { get; set; }
        public string PageTitle { get; set; }
        public string PageGlobalName { get; set; }
        public string PageName { get; set; }

        public List<string> ParrentCategory;
        public void AddParrentCategory(string CategoryName)
        {
            ParrentCategory.Add(CategoryName);
        }

        public void Reset()
        {
            FilePhysicalName = null;
            SiteGlobalName = null;
            SiteName = null;
            SiteTitle = null;
            ParrentCategory = new List<string>();
            CategoryName = null;
            TagName = null; ;
            ContentId = null;
            ContentTitle = null;
            PageId = null;
            PageTitle = null;
            PageGlobalName = null;
            PageName = null; ;
        }

        private string GetRandomText(string Count)
        {
            StringClass sc = new StringClass();
            string RandomText = sc.GetCleanRandomText(int.Parse(Count));

            return RandomText;
        }

        private string GetRandomNumber(string Count)
        {
            Random rd = new Random();
            string RandomNumber = "";

            RandomNumber = rd.Next(10 ^ int.Parse(Count)).ToString();

            return RandomNumber;
        }

        public string GetBackupFileAndDirectoryValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/file/file_and_directory_backup");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "date": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetDate(VariableFormat)); break;
                        case "time": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetTime(VariableFormat)); break;
                        case "random_text": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomText(VariableFormat)); break;
                        case "random_number": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomNumber(VariableFormat)); break;
                        case "user_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserId); break;
                        case "user_site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserSiteName); break;
                        case "user_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserName); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetBackupDataBaseValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/file/database_backup");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "date": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetDate(VariableFormat)); break;
                        case "time": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetTime(VariableFormat)); break;
                        case "random_text": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomText(VariableFormat)); break;
                        case "random_number": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomNumber(VariableFormat)); break;
                        case "user_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserId); break;
                        case "user_site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserSiteName); break;
                        case "user_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserName); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetAttachmentFileValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/file/attachment");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "date": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetDate(VariableFormat)); break;
                        case "time": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetTime(VariableFormat)); break;
                        case "random_text": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomText(VariableFormat)); break;
                        case "random_number": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomNumber(VariableFormat)); break;
                        case "user_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserId); break;
                        case "user_site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserSiteName); break;
                        case "user_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserName); break;
                        case "file_physical_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", FilePhysicalName); break;
                        case "file_physical_name_without_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetFileNameWithoutExtension(FilePhysicalName)); break;
                        case "file_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetExtension(FilePhysicalName)); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetUploadFileValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/file/upload");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "date": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetDate(VariableFormat)); break;
                        case "time": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetTime(VariableFormat)); break;
                        case "random_text": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomText(VariableFormat)); break;
                        case "random_number": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomNumber(VariableFormat)); break;
                        case "user_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserId); break;
                        case "user_site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserSiteName); break;
                        case "user_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserName); break;
                        case "file_physical_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", FilePhysicalName); break;
                        case "file_physical_name_without_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetFileNameWithoutExtension(FilePhysicalName)); break;
                        case "file_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetExtension(FilePhysicalName)); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetContactUploadFileValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/file/contact_upload");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "date": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetDate(VariableFormat)); break;
                        case "time": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetTime(VariableFormat)); break;
                        case "random_text": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomText(VariableFormat)); break;
                        case "random_number": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomNumber(VariableFormat)); break;
                        case "user_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserId); break;
                        case "user_site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserSiteName); break;
                        case "user_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserName); break;
                        case "file_physical_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", FilePhysicalName); break;
                        case "file_physical_name_without_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetFileNameWithoutExtension(FilePhysicalName)); break;
                        case "file_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetExtension(FilePhysicalName)); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetCommentUploadFileValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/file/comment_upload");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "date": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetDate(VariableFormat)); break;
                        case "time": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetTime(VariableFormat)); break;
                        case "random_text": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomText(VariableFormat)); break;
                        case "random_number": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomNumber(VariableFormat)); break;
                        case "user_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserId); break;
                        case "user_site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserSiteName); break;
                        case "user_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserName); break;
                        case "file_physical_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", FilePhysicalName); break;
                        case "file_physical_name_without_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetFileNameWithoutExtension(FilePhysicalName)); break;
                        case "file_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetExtension(FilePhysicalName)); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetAttachmentDirectoryValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/directory/attachment");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "date": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetDate(VariableFormat)); break;
                        case "time": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetTime(VariableFormat)); break;
                        case "random_text": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomText(VariableFormat)); break;
                        case "random_number": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomNumber(VariableFormat)); break;
                        case "user_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserId); break;
                        case "user_site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserSiteName); break;
                        case "user_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserName); break;
                        case "file_physical_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", FilePhysicalName); break;
                        case "file_physical_name_without_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetFileNameWithoutExtension(FilePhysicalName)); break;
                        case "file_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetExtension(FilePhysicalName)); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetUploadDirectoryValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/directory/upload");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "date": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetDate(VariableFormat)); break;
                        case "time": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetTime(VariableFormat)); break;
                        case "random_text": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomText(VariableFormat)); break;
                        case "random_number": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomNumber(VariableFormat)); break;
                        case "user_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserId); break;
                        case "user_site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserSiteName); break;
                        case "user_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserName); break;
                        case "file_physical_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", FilePhysicalName); break;
                        case "file_physical_name_without_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetFileNameWithoutExtension(FilePhysicalName)); break;
                        case "file_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetExtension(FilePhysicalName)); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetContactUploadDirectoryValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/directory/contact_upload");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "date": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetDate(VariableFormat)); break;
                        case "time": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetTime(VariableFormat)); break;
                        case "random_text": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomText(VariableFormat)); break;
                        case "random_number": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomNumber(VariableFormat)); break;
                        case "user_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserId); break;
                        case "user_site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserSiteName); break;
                        case "user_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserName); break;
                        case "file_physical_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", FilePhysicalName); break;
                        case "file_physical_name_without_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetFileNameWithoutExtension(FilePhysicalName)); break;
                        case "file_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetExtension(FilePhysicalName)); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetCommentUploadDirectoryValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/directory/comment_upload");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "date": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetDate(VariableFormat)); break;
                        case "time": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetTime(VariableFormat)); break;
                        case "random_text": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomText(VariableFormat)); break;
                        case "random_number": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", GetRandomNumber(VariableFormat)); break;
                        case "user_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserId); break;
                        case "user_site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserSiteName); break;
                        case "user_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserName); break;
                        case "file_physical_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", FilePhysicalName); break;
                        case "file_physical_name_without_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetFileNameWithoutExtension(FilePhysicalName)); break;
                        case "file_extension": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Path.GetExtension(FilePhysicalName)); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetCategoryUrlValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/url/category");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "site_global_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteGlobalName); break;
                        case "site_global_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteGlobalName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteName); break;
                        case "site_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "category_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", CategoryId); break;
                        case "parent_category": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", string.Join(VariableFormat, ParrentCategory.ToArray()) + ((ParrentCategory.Count > 0) ? VariableFormat : "")); break;
                        case "category_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", CategoryName); break;
                        case "category_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(CategoryName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "parent_local_category":
                            {
                                int i = 0;
                                while (i < ParrentCategory.Count)
                                {
                                    ParrentCategory[i] = Language.GetHandheldLanguage(ParrentCategory[i], StaticObject.GetCurrentSiteGlobalLanguage());
                                    i++;
                                }

                                TextStruct = TextStruct.Replace("$_asp " + Variable + ";", string.Join(VariableFormat, ParrentCategory.ToArray()) + ((ParrentCategory.Count > 0) ? VariableFormat : "")); 
                            }
                            break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetCategoryTitleValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/title/category");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "site_global_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteGlobalName); break;
                        case "site_global_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteGlobalName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteName); break;
                        case "site_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "category_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", CategoryId); break;
                        case "parent_category": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", string.Join(VariableFormat, ParrentCategory.ToArray()) + ((ParrentCategory.Count > 0) ? VariableFormat : "")); break;
                        case "category_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", CategoryName); break;
                        case "category_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(CategoryName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "parent_local_category":
                            {
                                int i = 0;
                                while (i < ParrentCategory.Count)
                                {
                                    ParrentCategory[i] = Language.GetHandheldLanguage(ParrentCategory[i], StaticObject.GetCurrentSiteGlobalLanguage());
                                    i++;
                                }

                                TextStruct = TextStruct.Replace("$_asp " + Variable + ";", string.Join(VariableFormat, ParrentCategory.ToArray()) + ((ParrentCategory.Count > 0) ? VariableFormat : ""));
                            }
                            break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetTagUrlValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/url/tag");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "site_global_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteGlobalName); break;
                        case "site_global_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteGlobalName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "tag_name_with_underline": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", TagName.Replace(" ", "_")); break;
                        case "tag_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", TagName); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetTagTitleValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/title/tag");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "site_global_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteGlobalName); break;
                        case "site_global_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteGlobalName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "tag_name_with_underline": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", TagName.Replace(" ", "_")); break;
                        case "tag_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", TagName); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetContentUrlValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/url/content");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "site_global_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteGlobalName); break;
                        case "site_global_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteGlobalName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteName); break;
                        case "site_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "content_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ContentId); break;
                        case "content_title": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ContentTitle); break;
                        case "content_local_title": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguageWithoutNullLanguageSuffix(ContentTitle, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "date": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetDate(VariableFormat)); break;
                        case "time": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetTime(VariableFormat)); break;
                        case "category_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", CategoryId); break;
                        case "parent_category": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", string.Join(VariableFormat, ParrentCategory.ToArray()) + ((ParrentCategory.Count > 0) ? VariableFormat : "")); break;
                        case "category_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", CategoryName); break;
                        case "category_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(CategoryName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "user_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserId); break;
                        case "user_site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserSiteName); break;
                        case "user_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserName); break;
                        case "parent_local_category":
                            {
                                int i = 0;
                                while (i < ParrentCategory.Count)
                                {
                                    ParrentCategory[i] = Language.GetHandheldLanguage(ParrentCategory[i], StaticObject.GetCurrentSiteGlobalLanguage());
                                    i++;
                                }

                                TextStruct = TextStruct.Replace("$_asp " + Variable + ";", string.Join(VariableFormat, ParrentCategory.ToArray()) + ((ParrentCategory.Count > 0) ? VariableFormat : ""));
                            }
                            break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetContentTitleValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/title/content");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    CurrentClientObjectClass ccoc = new CurrentClientObjectClass();

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "site_global_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteGlobalName); break;
                        case "site_global_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteGlobalName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteName); break;
                        case "site_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "content_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ContentId); break;
                        case "content_title": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ContentTitle); break;
                        case "content_local_title": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguageWithoutNullLanguageSuffix(ContentTitle, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "date": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetDate(VariableFormat)); break;
                        case "time": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", DateAndTime.GetTime(VariableFormat)); break;
                        case "category_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", CategoryId); break;
                        case "parent_category": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", string.Join(VariableFormat, ParrentCategory.ToArray()) + ((ParrentCategory.Count > 0) ? VariableFormat : "")); break;
                        case "category_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", CategoryName); break;
                        case "category_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(CategoryName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "user_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserId); break;
                        case "user_site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserSiteName); break;
                        case "user_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", ccoc.UserName); break;
                        case "parent_local_category":
                            {
                                int i = 0;
                                while (i < ParrentCategory.Count)
                                {
                                    ParrentCategory[i] = Language.GetHandheldLanguage(ParrentCategory[i], StaticObject.GetCurrentSiteGlobalLanguage());
                                    i++;
                                }

                                TextStruct = TextStruct.Replace("$_asp " + Variable + ";", string.Join(VariableFormat, ParrentCategory.ToArray()) + ((ParrentCategory.Count > 0) ? VariableFormat : ""));
                            }
                            break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetPageUrlValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/url/page");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "site_global_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteGlobalName); break;
                        case "site_global_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteGlobalName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteName); break;
                        case "site_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "page_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", PageId); break;
                        case "page_global_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", PageGlobalName); break;
                        case "page_global_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(PageGlobalName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "page_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", PageName); break;
                        case "page_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(PageName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "page_title": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", PageTitle); break;
                        case "page_local_title": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguageWithoutNullLanguageSuffix(PageTitle, StaticObject.GetCurrentSiteGlobalLanguage())); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }

        public string GetPageTitleValue()
        {
            XmlNode node = StaticObject.StructDocument.SelectSingleNode("struct_root/extra_value/title/page");

            string TextStruct = node.InnerText;

            while (TextStruct.Contains("$_asp "))
            {
                string Variable = TextStruct.Split(new string[] { "$_asp " }, StringSplitOptions.None)[1].Split(';')[0].Trim();
                {
                    string TmpVariable = Variable;

                    string VariableFormat = "";

                    if (Variable.Contains("{"))
                    {
                        VariableFormat = Variable.Split(new string[] { "{" }, StringSplitOptions.None)[1].Split('}')[0].Trim();
                        int ValueIndex = Variable.IndexOf("{");

                        TmpVariable = Variable.Remove(ValueIndex);
                    }

                    switch (TmpVariable)
                    {
                        case "site_path": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", StaticObject.SitePath); break;
                        case "site_global_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteGlobalName); break;
                        case "site_global_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteGlobalName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "site_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", SiteName); break;
                        case "site_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(SiteName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "page_id": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", PageId); break;
                        case "page_global_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", PageGlobalName); break;
                        case "page_global_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(PageGlobalName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "page_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", PageName); break;
                        case "page_local_name": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguage(PageName, StaticObject.GetCurrentSiteGlobalLanguage())); break;
                        case "page_title": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", PageTitle); break;
                        case "page_local_title": TextStruct = TextStruct.Replace("$_asp " + Variable + ";", Language.GetHandheldLanguageWithoutNullLanguageSuffix(PageTitle, StaticObject.GetCurrentSiteGlobalLanguage())); break;

                        default: TextStruct = TextStruct.Replace("$_asp " + Variable + ";", null); break;
                    }
                }
            }

            return TextStruct;
        }
    }
}