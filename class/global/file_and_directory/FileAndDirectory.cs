using Microsoft.AspNetCore.StaticFiles;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Elanat
{
	public class FileAndDirectory
	{
        /// <param name="Path">Full Physical Path</param>
        public static string GetNewFileNameIfFileNameExist(string Path, string FileName)
        {
            FileName = FileName.Replace(" ", "-");
            if (File.Exists(Path + "/" + FileName))
            {
                string FileType = System.IO.Path.GetExtension(Path + "/" + FileName);
                int i = 2;

                string FirstFileName = FileName.Replace(FileType, null) + "_";
                while (File.Exists(Path + "/" + FileName))
                {
                    FileName = FirstFileName + i.ToString() + FileType;
                    i = i + 1;
                }
            }

            return FileName; 
        }

        /// <param name="Path">Full Physical Path</param>
        public static string GetNewDirectoryNameIfDirectoryExist(string Path, string DirectoryName)
        {
            DirectoryName = DirectoryName.Replace(" ", "-");
            if (Directory.Exists(Path + DirectoryName))
            {
                int i = 2;
                string FirstDirectoryName = DirectoryName + "_";
                while (Directory.Exists(Path + DirectoryName))
                {
                    DirectoryName = FirstDirectoryName + i.ToString();
                    i = i + 1;
                }
            }

            return DirectoryName;
        }

        public static void DirectoryCopy(string SourceDirName, string DestDirName, bool CopySubDirs, bool OwerWrite = false)
        {
            DirectoryInfo dir = new DirectoryInfo(SourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!Directory.Exists(DestDirName))
            {
                Directory.CreateDirectory(DestDirName);
            }

            // Create All Directories, Include Empty Directories
            foreach (DirectoryInfo subdir in dirs)
            {
                if (!Directory.Exists(DestDirName + "/" + subdir.Name))
                    Directory.CreateDirectory(DestDirName + "/" + subdir.Name);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string TmpPath = Path.Combine(DestDirName, file.Name);
                file.CopyTo(TmpPath, OwerWrite);
            }

            if (CopySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string TmpPath = Path.Combine(DestDirName, subdir.Name);

                    // Set Recursive
                    DirectoryCopy(subdir.FullName, TmpPath, CopySubDirs, OwerWrite);
                }
            }
        }

        /// <param name="Path">Logical Path</param>
        public void DeleteFileFromUninstallXmlFileList(string Path)
        {
            if (!File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + Path + "/uninstall.xml")))
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + Path + "/uninstall.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("uninstall_root/file_path_list").ChildNodes;

            foreach (XmlNode Node in NodeList)
            {
                try
                {
                    File.Delete(StaticObject.ServerMapPath(Node.InnerText));
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        public static string GetFileType(string FileName)
        {
            string Extension = Path.GetExtension(FileName).Remove(0, 1);

            XmlNodeList NodeList = StaticObject.FileExtensionDocument.SelectNodes("//file_extension[@extension='" + Extension + "']");

            if (NodeList.Count > 0)
                return NodeList.Item(0).Attributes["type"].Value;
            return "";
        }

        public static string GetFileDescription(string FileName)
        {
            string Extension = Path.GetExtension(FileName).Remove(0, 1);

            XmlNodeList NodeList = StaticObject.FileExtensionDocument.SelectNodes("//file_extension[@extension='" + Extension + "']");

            if (NodeList.Count > 0)
                return NodeList.Item(0).Attributes["description"].Value;
            return "";
        }

        public static bool IsPublicExtension(string FileName)
        {
            if (!FileName.Contains("."))
                return false;

            string Extension = Path.GetExtension(FileName).Remove(0, 1);

            XmlNodeList NodeList = StaticObject.FileExtensionDocument.SelectNodes("//file_extension[@extension='" + Extension + "']");

            if (NodeList.Count > 0)
                return true;

            return false;
        }

        public static List<string> GetTextFileType(bool WhithDot = false)
        {
            string Dot = (WhithDot)? "." : "" ;

            List<string> list = new List<string>();

            XmlNodeList NodeList = StaticObject.FileExtensionDocument.SelectNodes("//file_extension[@type='text']");

            foreach (XmlNode node in NodeList)
                list.Add(Dot + node.Attributes["extension"].Value);

            return list;
        }

        /// <param name="Path">Full Physical Path</param>
        public long GetDirectoryFileSize(string Path,bool OnlyOwnFile = true)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Path);
            FileInfo[] fileInfo;

            fileInfo = (OnlyOwnFile) ? dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly) : dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
            
            long DirectoryFileSize = 0;

            foreach (FileInfo file in fileInfo)
                DirectoryFileSize += file.Length;

            return DirectoryFileSize;
        }

        /// <param name="Path">Full Physical Path</param>
        public long GetDirectoryFilesCount(string Path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Path);
            FileInfo[] fileInfo;

            fileInfo = dirInfo.GetFiles("*.log", SearchOption.TopDirectoryOnly);

            return fileInfo.Length;
        }

        /// <param name="Path">Logical Path</param>
        public void SetFileUploadPathToUploadFileList(string Path, string FileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/upload_file_list/upload_file.xml"));

            XmlElement FileElement = doc.CreateElement("file");
            FileElement.InnerText = Path + FileName;

            doc.SelectSingleNode("upload_file_root/upload_file_list").AppendChild(FileElement);

            doc.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/upload_file_list/upload_file.xml"));
        }

        /// <param name="Path">Logical Path</param>
        public string GetRootPath(string Path)
        {
            int MapPathLength = StaticObject.ServerMapPath("/").ToString().Length;

            Path = Path.Remove(0, MapPathLength);
            Path = Path.Replace(@"\","/");
            Path = "/" + Path;

            return Path;
        }

        public static bool IsImageExtension(string Extension)
        {
            switch(Extension.ToLower())
            {
                case ".jpg": return true;
                case ".jpeg": return true;
                case ".png": return true;
                case ".gif": return true;
                case ".webp": return true;
                case ".bmp": return true;
            }

            return false;
        }

        public string GetMimeType(string fileName)
        {
            string MimeType = "application/unknown";
            string Extension = Path.GetExtension(fileName).ToLower();

            switch (Extension)
            {
                case ".js": return "text/javascript";
                case ".aspx": return "text/html";
                case ".dll": return "text/html";
            }


            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out MimeType))
                MimeType = "application/octet-stream";

            return MimeType;
        }

        public bool FileLoadedInBrowser(string Extension)
        {
            Extension = Extension.Remove(0, 1);

            XmlNodeList NodeList = StaticObject.FileExtensionDocument.SelectNodes("//file_extension[@extension='" + Extension + "']");

            if (NodeList.Count > 0)
                if (NodeList[0].Attributes["view"] != null)
                    if (NodeList[0].Attributes["view"].Value.TrueFalseToBoolean())
                        return true;

            return false;
        }

        public string GetFirstDirectory(string Path)
        {
            if (Path.Length == 0)
                return "";

            Path = Path.Replace('\\', '/');
            Path = Path.GetTextBeforeValue("?");

            string FirstDirectory = "";

            while (Path[0] == '/')
            {
                Path = Path.Remove(0, 1);

                if (Path.Length < 1)
                    break;
            }

            FirstDirectory = Path.GetTextBeforeValue("/");

            if (FirstDirectory.Contains('.'))
                return "";

            return FirstDirectory;
        }

        public string GetSecondDirectory(string Path)
        {
            if (Path.Length == 0)
                return "";

            Path = Path.Replace('\\', '/');
            Path = Path.GetTextBeforeValue("?");

            string SecondDirectory = "";

            while (Path[0] == '/')
            {
                Path = Path.Remove(0, 1);

                if (Path.Length < 1)
                    break;
            }

            while (Path.Contains("//"))
                Path = Path.Replace("//" , "/");


            string AfterFirstDirectory = "";
            if (Path.GetTextAfterValue("/") != Path)
                AfterFirstDirectory = Path.GetTextAfterValue("/");
            
            if (AfterFirstDirectory.Contains('/'))
                SecondDirectory = AfterFirstDirectory.GetTextBeforeValue("/");
            else
                if (!AfterFirstDirectory.Contains('.'))
                    SecondDirectory = AfterFirstDirectory;

            if (Path.GetTextBeforeValue("/").Contains('.'))
                SecondDirectory = "";

            if (SecondDirectory.Contains('.'))
                SecondDirectory = "";

            return SecondDirectory;
        }

        public string GetThirdDirectory(string Path)
        {
            string ThirdDirectory = "";

            string AfterSecondDirectory = GetAfterSecondDirectory(Path);

            ThirdDirectory = GetFirstDirectory(AfterSecondDirectory);

            return ThirdDirectory;
        }

        public string GetAfterFirstDirectory(string Path)
        {
            if (Path.Length == 0)
                return "";

            Path = Path.Replace('\\', '/');
            Path = Path.GetTextBeforeValue("?");

            string AfterFirstDirectory = "";

            while (Path[0] == '/')
            {
                Path = Path.Remove(0, 1);

                if (Path.Length < 1)
                    break;
            }

            while (Path.Contains("//"))
                Path = Path.Replace("//", "/");

            AfterFirstDirectory = Path.GetTextAfterValue("/");

            if (Path.GetTextBeforeValue("/").Contains('.'))
                return "";

            if (!Path.Contains('/'))
                return "";

            return AfterFirstDirectory;
        }

        public string GetAfterSecondDirectory(string Path)
        {
            string AfterSecondDirectory = "";

            string AfterFirstDirectory = GetAfterFirstDirectory(Path);

            AfterSecondDirectory = GetAfterFirstDirectory(AfterFirstDirectory);

            return AfterSecondDirectory;
        }

        public string GetAfterThirdDirectory(string Path)
        {
            string AfterThirdDirectory = "";

            string AfterFirstDirectory = GetAfterFirstDirectory(Path);

            string AfterSecondDirectory = GetAfterFirstDirectory(AfterFirstDirectory);

            AfterThirdDirectory = GetAfterFirstDirectory(AfterSecondDirectory);

            return AfterThirdDirectory;
        }

        public string GetFileName(string Path)
        {
            string FileName = System.IO.Path.GetFileName(Path);

            if (string.IsNullOrEmpty(FileName))
                return "";

            if (FileName[0] == '.')
                return "";

            if (FileName[FileName.Length - 1] == '.')
                return "";

            if (!FileName.Contains('.'))
                return "";

            return FileName;
        }

        public string GetCleanDirectoryPathFromPath(string Path)
        {
            if (Path.Length == 0)
                return "";

            Path = System.IO.Path.GetDirectoryName(Path);

            Path = Path.Replace(@"\", "/");

            Path = Path.Replace("//", "/");

            Path = Path.GetTextBeforeValue("?");

            if (Path.Length == 0)
                return ""; 
            
            while (Path[0] == '/')
            {
                Path = Path.Remove(0, 1);

                if (Path.Length < 1)
                    break;
            }

            if (Path[Path.Length - 1] == '/')
                Path = Path.Remove(Path.Length - 2, 1);

            return Path;
        }

        /// <param name="Path">Logical Path</param>
        public string GetDefaultPage(string Path)
        {
            XmlNodeList DefaultPageList = StaticObject.DefaultPageNodeList;

            foreach (XmlNode node in DefaultPageList)
            {
                string DefaultPageName = node.Attributes["name"].Value.ToString();

                if (File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + Path.GetTextBeforeValue("?")) + "/" + DefaultPageName))
                    return DefaultPageName;
            }

            return "";
        }

        public string ScriptExtensioPackagePath;
        public string ScriptExtensioRunPathCommand;
        public void FillScriptExtensionInfo(string Extension)
        {
            if (string.IsNullOrEmpty(Extension))
                return;

            if (Extension[0] == '.')
                Extension = Extension.Remove(0, 1);

            XmlNodeList ScriptExtensionList = StaticObject.ScriptExtensionNodeList;
            
            //Path.GetExtension
            foreach (XmlNode node in ScriptExtensionList)
            {
                string ScriptExtension = node.Attributes["extension"].Value.ToString();

                if (ScriptExtension == Extension)
                {
                    ScriptExtensioPackagePath = node.Attributes["package_path"].Value.ToString();
                    ScriptExtensioRunPathCommand = node.Attributes["run_path_command"].Value.ToString();

                    break;
                }
            }
        }

        public void ReCreateUploadFileLis()
        {
            DirectoryInfo di = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "upload/"));

            XmlDocument UploadFileListDocument = new XmlDocument();
            UploadFileListDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/upload_file_list/upload_file.xml"));

            // Delete Old File List
            UploadFileListDocument.SelectSingleNode("upload_file_root/upload_file_list").RemoveAll();

            foreach (FileInfo file in di.GetFiles())
            {
                XmlElement FileElement = UploadFileListDocument.CreateElement("file");
                FileElement.InnerText = file.Name;

                UploadFileListDocument.SelectSingleNode("upload_file_root/upload_file_list").AppendChild(FileElement);
            }

            UploadFileListDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/upload_file_list/upload_file.xml"));
        }

        /// <param name="Path">Full Physical Path</param>
        public void DeleteAllFileAndSubDirectoryInDirectory(string Path)
        {
            DirectoryInfo di = new DirectoryInfo(Path);

            foreach (FileInfo file in di.GetFiles())
                file.Delete();

            foreach (DirectoryInfo dir in di.GetDirectories())
                dir.Delete(true);
        }

        /// <param name="Path">Full Physical Path</param>
        public void DeleteAllFileInDirectory(string Path)
        {
            DirectoryInfo di = new DirectoryInfo(Path);

            foreach (FileInfo file in di.GetFiles())
                file.Delete();
        }

        /// <param name="Path">Full Physical Path</param>
        public void DeleteAllSubDirectoryInDirectory(string Path)
        {
            DirectoryInfo di = new DirectoryInfo(Path);

            foreach (DirectoryInfo dir in di.GetDirectories())
                dir.Delete(true);
        }

        public string GetFileETag(string FileName, DateTime ModifyDate)
        {
            string FileString;
            Encoder StringEncoder;
            int ByteCount;
            byte[] stringBytes;

            FileString = FileName + ModifyDate.ToString();

            StringEncoder = Encoding.UTF8.GetEncoder();
            ByteCount = StringEncoder.GetByteCount(FileString.ToCharArray(), 0, FileString.Length, true);
            stringBytes = new byte[ByteCount];

            StringEncoder.GetBytes(FileString.ToCharArray(), 0, FileString.Length, stringBytes, 0, true);

            MD5 Enc = MD5.Create();

            return "\"" + BitConverter.ToString(Enc.ComputeHash(stringBytes)).Replace("-", string.Empty) + "\"";
        }

        public bool IsFileModified(string FileName, DateTime ModifyDate, string ETag, HttpRequest Request)
        {
            bool FileDateModified = true;
            DateTime ModifiedSince;
            TimeSpan ModifyDiff;
            bool ETagChanged;

            string ifModifiedSince = Request.Headers["If-Modified-Since"];
            if (!string.IsNullOrEmpty(ifModifiedSince) && ifModifiedSince.Length > 0 && DateTime.TryParse(ifModifiedSince, out ModifiedSince))
            {
                FileDateModified = false;
                if (ModifyDate > ModifiedSince)
                {
                    ModifyDiff = ModifyDate - ModifiedSince;
                    FileDateModified = ModifyDiff > TimeSpan.FromSeconds(1);
                }
            }

            ETagChanged = false;
            string ifNoneMatch = Request.Headers["If-None-Match"];
            if (!string.IsNullOrEmpty(ifNoneMatch) && ifNoneMatch.Length > 0)
            {
                ETagChanged = ifNoneMatch != ETag;
            }

            return ETagChanged || FileDateModified;
        }

        public bool FileIsDynamic(string FilePath)
        {
            string FileExtension = Path.GetExtension(FilePath);

            if (string.IsNullOrEmpty(FileExtension))
                return true;

            FileExtension = FileExtension.Remove(0, 1);

            XmlNodeList DynamicExtensionList = StaticObject.DynamicExtensionNodeList;

            foreach (XmlNode node in DynamicExtensionList)
            {
                string Extension = node.Attributes["extension"].Value.ToString();

                if (FileExtension == Extension)
                    return true;
            }

            return false;
        }

        /// <param name="FromPath">Full Physical Path</param>
        /// <param name="ToPath">Full Physical Path</param>
        public void ConvertImageToPngFormat(string FromPath, string ToPath)
        {
            using (var image = Image.Load<Rgba64>(FromPath))
            {
                image.SaveAsPng(ToPath);
            }
        }

        public static void CreateThumbnailImage(string ImagePath, string OutputImagePath)
        {
            using (var image = Image.Load<Rgba64>(StaticObject.ServerMapPath(ImagePath)))
            {
                int Width = ElanatConfig.GetNode("file_and_directory/thumbnail_image_width").Attributes["value"].Value.ToNumber();
                int Height = ElanatConfig.GetNode("file_and_directory/thumbnail_image_height").Attributes["value"].Value.ToNumber();

                float WidthRatio = (float)image.Width / Width;
                float HeightRatio = (float)image.Height / Height;
                float Ratio = HeightRatio > WidthRatio ? HeightRatio : WidthRatio;

                int newWidth = Convert.ToInt32(Math.Floor((float)image.Width / Ratio));
                int newHeight = Convert.ToInt32(Math.Floor((float)image.Height / Ratio));

                image.Mutate(x => x.Resize(newWidth, newHeight));
                image.Save(StaticObject.ServerMapPath(OutputImagePath));
            }
        }

        public static bool ThumbnailImageAbortCallback()
        {
            return true;
        }
    }
}