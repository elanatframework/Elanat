using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetFileDirectoryListModel : CodeBehindModel
    {
        public string ListValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string ClientLanguageVariantTemplate = doc.SelectSingleNode("template_root/table/file_manager/client_language_variant").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string HeaderTemplate = doc.SelectSingleNode("template_root/table/file_manager/header/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage(), true);
            string HeaderListItemTemplate = doc.SelectSingleNode("template_root/table/file_manager/header/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowBoxTemplate = doc.SelectSingleNode("template_root/table/file_manager/row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowListItemTemplate = doc.SelectSingleNode("template_root/table/file_manager/row/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/");
            HeaderTemplate = aol.GetAddOnsLanguageFromContent(HeaderTemplate, true);

            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_delete;", Language.GetLanguage("are_you_sure_want_to_delete", StaticObject.GetCurrentAdminGlobalLanguage()));
            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_paste;", aol.GetAddOnsLanguage("are_you_sure_want_to_paste"));
            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_cut;", aol.GetAddOnsLanguage("are_you_sure_want_to_cut"));
            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_copy;", aol.GetAddOnsLanguage("are_you_sure_want_to_copy"));
            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_un_zip;", aol.GetAddOnsLanguage("are_you_sure_want_to_un_zip"));
            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang are_you_sure_want_to_zip;", aol.GetAddOnsLanguage("are_you_sure_want_to_zip"));
            ClientLanguageVariantTemplate = ClientLanguageVariantTemplate.Replace("$_lang use_overwrite_extract_existing_file;", aol.GetAddOnsLanguage("use_overwrite_extract_existing_file"));


            // Set Current Path
            string CurrentPhysicalPath = (!string.IsNullOrEmpty(QueryString.GetValue("directory"))) ? StaticObject.ServerMapPath(QueryString.GetValue("directory")) : StaticObject.ServerMapPath(StaticObject.SitePath + "");
            string CurrentPath = (!string.IsNullOrEmpty(QueryString.GetValue("directory"))) ? QueryString.GetValue("directory") : "";

            HeaderTemplate = HeaderTemplate.Replace("$_asp current_path;", CurrentPath);

            HeaderListItemTemplate = HeaderListItemTemplate.Replace("$_asp current_path;", CurrentPath);


            string SumHeaderTemplateItem = "";
            List<string> ItemList = GlobalClass.GetItemViewList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/file_manager/" + "App_Data/item_view/item_view.xml"));


            foreach (string Text in ItemList)
                SumHeaderTemplateItem += HeaderListItemTemplate.Replace("$_asp column_name;", Text).Replace("$_asp item;", aol.GetAddOnsLanguage(Text));

            if (!string.IsNullOrEmpty(QueryString.GetValue("search")))
                SumHeaderTemplateItem = SumHeaderTemplateItem.Replace("$_searched_item;", QueryString.GetValue("search"));

            HeaderTemplate = HeaderTemplate.Replace("$_asp item;", SumHeaderTemplateItem);


            bool UseSearch = false;
            string SearchValue = "";

            if (!string.IsNullOrEmpty(QueryString.GetValue("search")))
            {
                UseSearch = true;
                SearchValue = QueryString.GetValue("search");
            }

            // Get Serched List
            bool UseNameSearch = false;
            bool UsePathSearch = false;
            bool UseTypeSearch = false;
            bool UseSizeSearch = false;
            bool UseIsReadOnlySearch = false;
            bool UseLastAccessTimeSearch = false;

            if (!string.IsNullOrEmpty(QueryString.GetValue("search")))
            {
                List<string> SearchedItemList = GlobalClass.GetSearchedItemList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/file_manager/" + "App_Data/item_view/item_view.xml"));

                foreach (string column in SearchedItemList)
                {
                    switch (column)
                    {
                        case "text": UseNameSearch = true; break;
                        case "path": UsePathSearch = true; break;
                        case "type": UseTypeSearch = true; break;
                        case "size": UseSizeSearch = true; break;
                        case "is_read_only": UseIsReadOnlySearch = true; break;
                        case "last_access_time": UseLastAccessTimeSearch = true; break;
                    }
                }
            }

            // Set Sort
            DirectoryInfo dirInfo = new DirectoryInfo(CurrentPhysicalPath);
            DirectoryInfo[] dirget = null;
            FileInfo[] fileInfo = null;
            if (!string.IsNullOrEmpty(QueryString.GetValue("column_name")))
            {
                string ColumnName = QueryString.GetValue("column_name");

                bool IsDescSort = false;
                if (!string.IsNullOrEmpty(QueryString.GetValue("is_desc")))
                    IsDescSort = (QueryString.GetValue("is_desc") == "true");

                switch (ColumnName)
                {
                    case "name":
                        {
                            if (IsDescSort)
                            {
                                dirget = new DirectoryInfo(CurrentPhysicalPath).GetDirectories().OrderByDescending(p => p.Name).ToArray();
                                fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderByDescending(p => p.Name).ToArray();
                            }
                            else
                            {
                                dirget = new DirectoryInfo(CurrentPhysicalPath).GetDirectories().OrderBy(p => p.Name).ToArray();
                                fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderBy(p => p.Name).ToArray();
                            }
                        }
                        break;

                    case "path":
                        {
                            if (IsDescSort)
                            {
                                dirget = new DirectoryInfo(CurrentPhysicalPath).GetDirectories().OrderByDescending(p => p.FullName).ToArray();
                                fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderByDescending(p => p.FullName).ToArray();
                            }
                            else
                            {
                                dirget = new DirectoryInfo(CurrentPhysicalPath).GetDirectories().OrderBy(p => p.FullName).ToArray();
                                fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderBy(p => p.FullName).ToArray();
                            }
                        }
                        break;

                    case "type":
                        {
                            if (IsDescSort)
                            {
                                dirget = new DirectoryInfo(CurrentPhysicalPath).GetDirectories();
                                fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderByDescending(p => FileAndDirectory.GetFileType(p.Name)).ToArray();
                            }
                            else
                            {
                                dirget = new DirectoryInfo(CurrentPhysicalPath).GetDirectories();
                                fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderBy(p => FileAndDirectory.GetFileType(p.Name)).ToArray();
                            }
                        }
                        break;

                    case "size":
                        {
                            if (IsDescSort)
                            {
                                dirget = new DirectoryInfo(CurrentPhysicalPath).GetDirectories();
                                fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderByDescending(p => p.Length).ToArray();
                            }
                            else
                            {
                                dirget = new DirectoryInfo(CurrentPhysicalPath).GetDirectories();
                                fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderBy(p => p.Length).ToArray();
                            }
                        }
                        break;

                    case "last_access_time":
                        {
                            if (IsDescSort)
                            {
                                dirget = new DirectoryInfo(CurrentPhysicalPath).GetDirectories().OrderByDescending(p => p.LastAccessTime).ToArray();
                                fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderByDescending(p => p.LastAccessTime).ToArray();
                            }
                            else
                            {
                                dirget = new DirectoryInfo(CurrentPhysicalPath).GetDirectories().OrderBy(p => p.LastAccessTime).ToArray();
                                fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderBy(p => p.LastAccessTime).ToArray();
                            }
                        }
                        break;

                    case "is_read_only":
                        {
                            if (IsDescSort)
                            {
                                dirget = new DirectoryInfo(CurrentPhysicalPath).GetDirectories().OrderByDescending(p => p.Attributes.HasFlag(FileAttributes.ReadOnly)).ToArray();
                                fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderByDescending(p => p.IsReadOnly).ToArray();
                            }
                            else
                            {
                                dirget = new DirectoryInfo(CurrentPhysicalPath).GetDirectories().OrderBy(p => p.Attributes.HasFlag(FileAttributes.ReadOnly)).ToArray();
                                fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).OrderBy(p => p.IsReadOnly).ToArray();
                            }
                        }
                        break;
                }
            }
            else
            {
                dirget = new DirectoryInfo(CurrentPhysicalPath).GetDirectories();
                fileInfo = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            }


            FileAndDirectory fad = new FileAndDirectory();

            string SumRowBoxTemplate = "";

            foreach (DirectoryInfo dir in dirget)
            {
                bool FindSimilarity = false;

                // Set Search
                if (UseSearch)
                {
                    if (UseNameSearch && dir.Name.Contains(SearchValue))
                        FindSimilarity = true;

                    if (UsePathSearch && fad.GetRootPath(dir.FullName).Contains(SearchValue))
                        FindSimilarity = true;

                    if (UseTypeSearch && "directory".Contains(SearchValue))
                        FindSimilarity = true;

                    if (UseLastAccessTimeSearch && dir.LastAccessTime.ToString().Contains(SearchValue))
                        FindSimilarity = true;

                    if (UseIsReadOnlySearch && dir.Attributes.HasFlag(FileAttributes.ReadOnly).ToString().Contains(SearchValue))
                        FindSimilarity = true;

                    string IsReadOnly = (dir.Attributes.HasFlag(FileAttributes.ReadOnly)) ? Language.GetLanguage("true", StaticObject.GetCurrentAdminGlobalLanguage()) : Language.GetLanguage("false", StaticObject.GetCurrentAdminGlobalLanguage());

                    if (UseIsReadOnlySearch && IsReadOnly.Contains(SearchValue))
                        FindSimilarity = true;

                    if (!FindSimilarity)
                        continue;
                }


                string SumRowListItemTemplate = "";
                string TmpRowBoxTemplate = RowBoxTemplate;

                XmlNode ItemNode = doc.SelectSingleNode("template_root/table/file_manager/item");

                foreach (string Text in ItemList)
                {
                    string TextValue = "";
                    switch (Text)
                    {
                        case "name": TextValue = dir.Name; break;
                        case "path": TextValue = fad.GetRootPath(dir.FullName); break;
                        case "type": TextValue = "directory"; break;
                        case "size": TextValue = ""; break;
                        case "last_access_time": TextValue = dir.LastAccessTime.ToString(); break;
                        case "is_read_only": TextValue = (dir.Attributes.HasFlag(FileAttributes.ReadOnly)) ? Language.GetLanguage("true", StaticObject.GetCurrentAdminGlobalLanguage()) : Language.GetLanguage("false", StaticObject.GetCurrentAdminGlobalLanguage()); break;
                    }

                    string ItemBoxTemplate = ItemNode[Text].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

                    string TmpItemBoxTemplate = ItemBoxTemplate.Replace("$_asp " + Text + ";", TextValue);

                    // If Exist More Column For Replace
                    if (ItemNode[Text].Attributes["more_column"] != null)
                    {
                        char[] DelimiterChars = { ',' };
                        string[] MoreColumnList = ItemNode[Text].Attributes["more_column"].InnerText.Split(DelimiterChars);

                        foreach (string Column in MoreColumnList)
                        {
                            string ColumnValue = "";
                            switch (Column)
                            {
                                case "name": ColumnValue = dir.Name; break;
                                case "path": ColumnValue = fad.GetRootPath(dir.FullName); break;
                                case "type": ColumnValue = "directory"; break;
                                case "size": ColumnValue = ""; break;
                                case "last_access_time": ColumnValue = dir.LastAccessTime.ToString(); break;
                                case "is_read_only": ColumnValue = (dir.Attributes.HasFlag(FileAttributes.ReadOnly)) ? Language.GetLanguage("true", StaticObject.GetCurrentAdminGlobalLanguage()) : Language.GetLanguage("false", StaticObject.GetCurrentAdminGlobalLanguage()); break;
                            }

                            TmpItemBoxTemplate = TmpItemBoxTemplate.Replace("$_asp " + Column + ";", ColumnValue);
                        }
                    }

                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp file_extension_name;", "dir");
                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp path;", fad.GetRootPath(dir.FullName));
                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp type;", "directory");
                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp name;", dir.Name);

                    SumRowListItemTemplate += RowListItemTemplate.Replace("$_asp item;", TmpItemBoxTemplate);
                }

                SumRowBoxTemplate += TmpRowBoxTemplate.Replace("$_asp item;", SumRowListItemTemplate);
            }

            foreach (FileInfo file in fileInfo)
            {
                bool FindSimilarity = false;

                // Set Search
                if (UseSearch)
                {
                    if (UseNameSearch && file.Name.Contains(SearchValue))
                        FindSimilarity = true;

                    if (UsePathSearch && fad.GetRootPath(file.FullName).Contains(SearchValue))
                        FindSimilarity = true;

                    if (UseTypeSearch && FileAndDirectory.GetFileType(file.Name).Contains(SearchValue))
                        FindSimilarity = true;

                    if (UseSizeSearch && file.Length.ToBitSizeTuning().Contains(SearchValue))
                        FindSimilarity = true;

                    if (UseLastAccessTimeSearch && file.LastAccessTime.ToString().Contains(SearchValue))
                        FindSimilarity = true;

                    if (UseIsReadOnlySearch && file.IsReadOnly.ToString().Contains(SearchValue))
                        FindSimilarity = true;

                    string IsReadOnly = (file.IsReadOnly) ? Language.GetLanguage("true", StaticObject.GetCurrentAdminGlobalLanguage()) : Language.GetLanguage("false", StaticObject.GetCurrentAdminGlobalLanguage());

                    if (UseIsReadOnlySearch && IsReadOnly.Contains(SearchValue))
                        FindSimilarity = true;

                    if (!FindSimilarity)
                        continue;
                }


                string SumRowListItemTemplate = "";
                string TmpRowBoxTemplate = RowBoxTemplate;

                XmlNode ItemNode = doc.SelectSingleNode("template_root/table/file_manager/item");

                foreach (string Text in ItemList)
                {
                    string TextValue = "";
                    switch (Text)
                    {
                        case "name": TextValue = file.Name; break;
                        case "path": TextValue = fad.GetRootPath(file.FullName); break;
                        case "type": TextValue = FileAndDirectory.GetFileType(file.Name); break;
                        case "size": TextValue = file.Length.ToBitSizeTuning(); break;
                        case "last_access_time": TextValue = file.LastAccessTime.ToString(); break;
                        case "is_read_only": TextValue = (file.IsReadOnly) ? Language.GetLanguage("true", StaticObject.GetCurrentAdminGlobalLanguage()) : Language.GetLanguage("false", StaticObject.GetCurrentAdminGlobalLanguage()); break;
                    }

                    string ItemBoxTemplate = ItemNode[Text].InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

                    string TmpItemBoxTemplate = ItemBoxTemplate.Replace("$_asp " + Text + ";", TextValue);

                    // If Exist More Column For Replace
                    if (ItemNode[Text].Attributes["more_column"] != null)
                    {
                        char[] DelimiterChars = { ',' };
                        string[] MoreColumnList = ItemNode[Text].Attributes["more_column"].InnerText.Split(DelimiterChars);

                        foreach (string Column in MoreColumnList)
                        {
                            string ColumnValue = "";
                            switch (Column)
                            {
                                case "name": ColumnValue = file.Name; break;
                                case "path": ColumnValue = fad.GetRootPath(file.FullName); break;
                                case "type": ColumnValue = FileAndDirectory.GetFileType(file.Name); break;
                                case "size": ColumnValue = (file.Length.ToBitSizeTuning()); break;
                                case "last_access_time": ColumnValue = file.LastAccessTime.ToString(); break;
                                case "is_read_only": ColumnValue = (file.IsReadOnly) ? Language.GetLanguage("true", StaticObject.GetCurrentAdminGlobalLanguage()) : Language.GetLanguage("false", StaticObject.GetCurrentAdminGlobalLanguage()); break;
                            }

                            TmpItemBoxTemplate = TmpItemBoxTemplate.Replace("$_asp " + Column + ";", ColumnValue);
                        }
                    }

                    string FileExtension = (FileAndDirectory.IsPublicExtension(file.Name)) ? Path.GetExtension(file.Name).Remove(0, 1) : "blank";

                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp file_extension_name;", FileExtension);
                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp path;", fad.GetRootPath(file.FullName));
                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp type;", FileAndDirectory.GetFileType(file.Name));
                    TmpRowBoxTemplate = TmpRowBoxTemplate.Replace("$_asp name;", file.Name);

                    SumRowListItemTemplate += RowListItemTemplate.Replace("$_asp item;", TmpItemBoxTemplate);
                }

                SumRowBoxTemplate += TmpRowBoxTemplate.Replace("$_asp item;", SumRowListItemTemplate);
            }

            ListValue = ClientLanguageVariantTemplate + HeaderTemplate + SumRowBoxTemplate;
        }
    }
}