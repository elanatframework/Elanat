using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionFileDirectoryNewRowModel : CodeBehindModel
    {
        public string FileDirectoryPathValue { get; set; }

        public void SetValue()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string RowBoxTemplate = doc.SelectSingleNode("template_root/table/file_manager/new_row/box").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string RowListItemTemplate = doc.SelectSingleNode("template_root/table/file_manager/new_row/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string SumRowBoxTemplate = "";
            string SumRowListItemTemplate = "";
            string TmpRowBoxTemplate = RowBoxTemplate;

            List<string> ItemList = GlobalClass.GetItemViewList(StaticObject.ServerMapPath(StaticObject.AdminPath + "/file_manager/" + "App_Data/item_view/item_view.xml"));

            XmlNode ItemNode = doc.SelectSingleNode("template_root/table/file_manager/item");

            FileAndDirectory fad = new FileAndDirectory();

            if (Directory.Exists(FileDirectoryPathValue))
            {
                DirectoryInfo dir = new DirectoryInfo(FileDirectoryPathValue);

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

            if (File.Exists(FileDirectoryPathValue))
            {
                FileInfo file = new FileInfo(FileDirectoryPathValue);

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

            Write(SumRowBoxTemplate);
        }
    }
}