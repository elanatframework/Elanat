using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Xml;

namespace elanat
{
	public class FileAndDirectory
	{
        /// <param name="Path">Full Physical Path</param>
        public static string GetNewFileNameIfFileNameExist(string Path, string FileName)
        {
            FileName = FileName.Replace(" ", "-");
            if (System.IO.File.Exists(Path + "/" + FileName))
            {
                string FileType = System.IO.Path.GetExtension(Path + "/" + FileName);
                int i = 2;

                string FirstFileName = FileName.Replace(FileType, null) + "_";
                while (System.IO.File.Exists(Path + "/" + FileName))
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
            if (System.IO.Directory.Exists(Path + DirectoryName))
            {
                int i = 2;
                string FirstDirectoryName = DirectoryName + "_";
                while (System.IO.Directory.Exists(Path + DirectoryName))
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
            if (!System.IO.File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + Path + "/uninstall.xml")))
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + Path + "/uninstall.xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("uninstall_root/file_path_list").ChildNodes;

            foreach (XmlNode Node in NodeList)
            {
                try
                {
                    File.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + Node.InnerText));
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
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/upload_file_list/upload_file.xml"));

            XmlElement FileElement = doc.CreateElement("file");
            FileElement.InnerText = Path + FileName;

            doc.SelectSingleNode("upload_file_root/upload_file_list").AppendChild(FileElement);

            doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/upload_file_list/upload_file.xml"));
        }

        /// <param name="Path">Logical Path</param>
        public string GetRootPath(string Path)
        {
            int MapPathLength = HttpContext.Current.Server.MapPath("/").ToString().Length;

            Path = Path.Remove(0, MapPathLength);
            Path = Path.Replace(@"\","/");
            Path = "/" + Path;

            return Path;
        }

        public static bool IsImageExtension(string Extension)
        {
            switch(Extension)
            {
                case ".jpg": return true;
                case ".jpeg": return true;
                case ".png": return true;
                case ".gif": return true;
                case ".JPG": return true;
                case ".JPEG": return true;
                case ".PNG": return true;
                case ".GIF": return true;
            }

            return false;
        }

        public string GetMimeType(string fileName)
        {
            string MimeType = "application/unknown";
            string Extension = System.IO.Path.GetExtension(fileName).ToLower();

            switch (Extension)
            {
                case ".js": return "text/javascript";
                case ".aspx": return "text/html";
                case ".cpp": return "text/html";
                case ".dll": return "text/html";
                case ".dnc": return "text/html";
                case ".php": return "text/html";
                case ".njs": return "text/html";
                case ".pl": return "text/html";
                case ".py": return "text/html";
                case ".rb": return "text/html";
                case ".jsp": return "text/html";
            }

            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(Extension);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                MimeType = regKey.GetValue("Content Type").ToString();
            return MimeType;
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

                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + Path.GetTextBeforeValue("?")) + "/" + DefaultPageName))
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
            
            //System.IO.Path.GetExtension
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
            System.IO.DirectoryInfo di = new DirectoryInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "upload/"));

            XmlDocument UploadFileListDocument = new XmlDocument();
            UploadFileListDocument.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/upload_file_list/upload_file.xml"));

            // Delete Old File List
            UploadFileListDocument.SelectSingleNode("upload_file_root/upload_file_list").RemoveAll();

            foreach (FileInfo file in di.GetFiles())
            {
                XmlElement FileElement = UploadFileListDocument.CreateElement("file");
                FileElement.InnerText = file.Name;

                UploadFileListDocument.SelectSingleNode("upload_file_root/upload_file_list").AppendChild(FileElement);
            }

            UploadFileListDocument.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/upload_file_list/upload_file.xml"));
        }

        /// <param name="Path">Full Physical Path</param>
        public void DeleteAllFileAndSubDirectoryInDirectory(string Path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(Path);

            foreach (FileInfo file in di.GetFiles())
                file.Delete();

            foreach (DirectoryInfo dir in di.GetDirectories())
                dir.Delete(true);
        }

        /// <param name="Path">Full Physical Path</param>
        public void DeleteAllFileInDirectory(string Path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(Path);

            foreach (FileInfo file in di.GetFiles())
                file.Delete();
        }

        /// <param name="Path">Full Physical Path</param>
        public void DeleteAllSubDirectoryInDirectory(string Path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(Path);

            foreach (DirectoryInfo dir in di.GetDirectories())
                dir.Delete(true);
        }

        public string GetFileETag(string FileName, DateTime ModifyDate)
        {
            string FileString;
            Encoder StringEncoder;
            int ByteCount;
            Byte[] stringBytes;

            FileString = FileName + ModifyDate.ToString();

            StringEncoder = Encoding.UTF8.GetEncoder();
            ByteCount = StringEncoder.GetByteCount(FileString.ToCharArray(), 0, FileString.Length, true);
            stringBytes = new Byte[ByteCount];

            StringEncoder.GetBytes(FileString.ToCharArray(), 0, FileString.Length, stringBytes, 0, true);

            MD5 Enc = MD5CryptoServiceProvider.Create();

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
            string FileExtension = System.IO.Path.GetExtension(FilePath);

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
            var bitmap = System.Drawing.Bitmap.FromFile(FromPath);
            bitmap.Save(ToPath, System.Drawing.Imaging.ImageFormat.Png);
        }

        public static void CreateThumbnailImage(string ImagePath, string OutputImagePath)
        {

            System.Drawing.Image img = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(ImagePath));

            float Width = float.Parse(ElanatConfig.GetNode("file_and_directory/thumbnail_image_width").Attributes["value"].Value);
            float Height = float.Parse(ElanatConfig.GetNode("file_and_directory/thumbnail_image_height").Attributes["value"].Value);
            float WidthRatio = (float)img.Width / Width;
            float HeightRatio = (float)img.Height / Height;
            float Ratio = HeightRatio > WidthRatio ? HeightRatio : WidthRatio;

            int newWidth = Convert.ToInt32(Math.Floor((float)img.Width / Ratio));
            int newHeight = Convert.ToInt32(Math.Floor((float)img.Height / Ratio));
            System.Drawing.Image Thumbnail = img.GetThumbnailImage(newWidth, newHeight, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailImageAbortCallback), IntPtr.Zero);

            Thumbnail.Save(HttpContext.Current.Server.MapPath(OutputImagePath));
            img.Dispose();
        }

        public static bool ThumbnailImageAbortCallback()
        {
            return true;
        }
    }
}