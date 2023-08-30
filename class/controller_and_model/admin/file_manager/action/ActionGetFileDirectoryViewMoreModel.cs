using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionGetFileDirectoryViewMoreModel : CodeBehindModel
    {
        public string GetViewMore(string FileDirectoryPath)
        {
            string ViewMore = Template.GetAdminTemplate("box_load/view_more/box");
            string ViewMoreItem = Template.GetAdminTemplate("box_load/view_more/list_item");
            string SumViewMoreItem = "";
            string TmpViewMoreItem = "";

            List<string> ViewMoreList = GlobalClass.GetItemViewMoreList(StaticObject.AdminPath + "/file_manager/");
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/");

            foreach (string Text in ViewMoreList)
            {
                string TextValue = "";
                FileAndDirectory fad = new FileAndDirectory();

                if (Directory.Exists(FileDirectoryPath))
                {
                    DirectoryInfo dir = new DirectoryInfo(FileDirectoryPath);

                    switch (Text)
                    {
                        case "name": TextValue = dir.Name; break;
                        case "path": TextValue = fad.GetRootPath(dir.FullName); break;
                        case "type": TextValue = Language.GetLanguage("directory", StaticObject.GetCurrentAdminGlobalLanguage()); break;
                        case "size": TextValue = ""; break;
                        case "last_access_time": TextValue = dir.LastAccessTime.ToString(); break;
                        case "is_read_only": TextValue = (dir.Attributes.HasFlag(FileAttributes.ReadOnly)) ? Language.GetLanguage("true", StaticObject.GetCurrentAdminGlobalLanguage()) : Language.GetLanguage("false", StaticObject.GetCurrentAdminGlobalLanguage()); break;
                    }
                }
                else
                {
                    FileInfo file = new FileInfo(FileDirectoryPath);

                    switch (Text)
                    {
                        case "name": TextValue = file.Name; break;
                        case "path": TextValue = fad.GetRootPath(file.FullName); break;
                        case "type": TextValue = FileAndDirectory.GetFileType(file.Name); break;
                        case "size": TextValue = file.Length.ToBitSizeTuning(); break;
                        case "last_access_time": TextValue = file.LastAccessTime.ToString(); break;
                        case "is_read_only": TextValue = (file.IsReadOnly) ? Language.GetLanguage("true", StaticObject.GetCurrentAdminGlobalLanguage()) : Language.GetLanguage("false", StaticObject.GetCurrentAdminGlobalLanguage()); break;
                    }
                }

                TmpViewMoreItem = ViewMoreItem;
                TmpViewMoreItem = TmpViewMoreItem.Replace("$_asp item_title;", aol.GetAddOnsLanguage(Text));
                TmpViewMoreItem = TmpViewMoreItem.Replace("$_asp item_value;", TextValue);
                SumViewMoreItem += TmpViewMoreItem;
            }

            return ViewMore.Replace("$_asp item;", SumViewMoreItem);
        }
    }
}