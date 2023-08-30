using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class PluginDirectoryTextFileModel : CodeBehindModel
    {
        public string DirectoryTextFileLanguage { get; set; }
        public string FileListLanguage { get; set; }
        public string SaveFileLanguage { get; set; }
        public string ReturnLanguage { get; set; }
        public string FileNameLanguage { get; set; }
        public string FilePathLanguage { get; set; }
        public string FileSizeLanguage { get; set; }
        public string LastAccessLanguage { get; set; }
        public string LastModifyLanguage { get; set; }

        public string ShowFileListModeClass { get; set; } = "el_hidden";
        public string EditFileModeClass { get; set; } = "el_hidden";

        public string DirectoryTextFileValue { get; set; }
        public string FileTextValue { get; set; }
        public string MimeTypeValue { get; set; }
        public string DirectoryPathValue { get; set; }
        public string FilePathValue { get; set; }
        public string FileNameValue { get; set; }
        public string FileSizeValue { get; set; }
        public string LastAccessValue { get; set; }
        public string LastModifyValue { get; set; }


        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.SitePath + "add_on/plugin/directory_text_file/");
            FileListLanguage = aol.GetAddOnsLanguage("file_list");
            DirectoryTextFileLanguage = aol.GetAddOnsLanguage("directory_text_file");
            SaveFileLanguage = aol.GetAddOnsLanguage("save_file");
            ReturnLanguage = aol.GetAddOnsLanguage("return");


            if (!string.IsNullOrEmpty(QueryString.GetValue("file_path")))
            {
                FilePathValue = QueryString.GetValue("file_path");
                DirectoryPathValue = QueryString.GetValue("current_add_on_path");


                //  Data Stream Path Access
                Security sc = new Security();
                sc.DataStreamPathAccess(FilePathValue);


                FileNameLanguage = aol.GetAddOnsLanguage("file_name");
                FilePathLanguage = aol.GetAddOnsLanguage("file_path");
                FileSizeLanguage = aol.GetAddOnsLanguage("file_size");
                LastAccessLanguage = aol.GetAddOnsLanguage("last_access");
                LastModifyLanguage = aol.GetAddOnsLanguage("last_modify");


                FileInfo file = new FileInfo(StaticObject.ServerMapPath(FilePathValue));

                FileNameValue = file.Name;
                FileSizeValue = file.Length.ToBitSizeTuning();
                LastAccessValue = file.LastAccessTime.ToString();
                LastModifyValue = file.LastWriteTime.ToString();

                // Get Mime Type
                FileAndDirectory fad = new FileAndDirectory();
                MimeTypeValue = fad.GetMimeType(FilePathValue);

                EditFileModeClass = EditFileModeClass.DeleteHtmlClass("el_hidden");
            }

            if (string.IsNullOrEmpty(QueryString.GetValue("directory_path")))
                return;

            DirectoryPathValue = QueryString.GetValue("directory_path");

            ShowFileListModeClass = ShowFileListModeClass.DeleteHtmlClass("el_hidden");

            DirectoryInfo DirInfo = new DirectoryInfo(StaticObject.ServerMapPath(DirectoryPathValue));

            List<string> TextFileTypeList = FileAndDirectory.GetTextFileType(true);
            var Directories = DirInfo.GetFiles("*", SearchOption.AllDirectories).Where(f => TextFileTypeList.Contains(f.Extension.ToLower())).ToArray();

            string LabelListTemplate = Template.GetAdminTemplate("part/label_list/onclick_mode");
            string SumLabelListTemplate = "";
            string TmpLabelListTemplate = "";

            LabelListTemplate = LabelListTemplate.Replace("$_asp class_name;", "el_file_edit_list");

            foreach (FileInfo file in Directories)
            {
                TmpLabelListTemplate = LabelListTemplate;
                TmpLabelListTemplate = TmpLabelListTemplate.Replace("$_asp id;", file.Name);

                string FilePath = file.FullName;
                FilePath = FilePath.Replace(@"\", "/");
                string DirectoryFullPath = StaticObject.ServerMapPath(DirectoryPathValue);
                FilePath = FilePath.Remove(0, DirectoryFullPath.Length);

                TmpLabelListTemplate = TmpLabelListTemplate.Replace("$_asp value;", FilePath);

                TmpLabelListTemplate = TmpLabelListTemplate.Replace("$_asp function;", "el_OpenTextFile('" + FilePath + "')");

                SumLabelListTemplate += TmpLabelListTemplate;
            }

            DirectoryTextFileValue = SumLabelListTemplate;
        }

        public void SaveFile()
        {
            //  Data Stream Path Access
            Security sc = new Security();
            sc.DataStreamPathAccess(FilePathValue);


            if (Path.GetExtension(FilePathValue) == ".xml")
            {
                XmlDocument doc = new XmlDocument();
                doc.InnerXml = FileTextValue.Trim();
                doc.Save(StaticObject.ServerMapPath(FilePathValue));
            }
            else
            {
                string[] FileText = FileTextValue.Trim().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                File.WriteAllLines(StaticObject.ServerMapPath(FilePathValue), FileText);
            }

            // Get Mime Type
            FileAndDirectory fad = new FileAndDirectory();
            MimeTypeValue = fad.GetMimeType(FilePathValue);

            EditFileModeClass = EditFileModeClass.DeleteHtmlClass("el_hidden");


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("edit_file", FilePathValue);
        }

        public void Return()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect("?directory_path=" + DirectoryPathValue);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.SitePath + "add_on/plugin/directory_text_file/action/SuccessMessage.aspx", true);
        }
    }
}