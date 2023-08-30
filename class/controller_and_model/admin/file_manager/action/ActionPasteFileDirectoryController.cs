using CodeBehind;
using Microsoft.AspNetCore.Http;

namespace Elanat
{
    public partial class ActionPasteFileDirectoryController : CodeBehindController
    {
        public void PageLoad(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.Query["directory_path"]))
            {
                if (context.Session.GetString("el_file_manager:file_directory_copy_list") == null)
                {
                    Write("false");
                    return;
                }

                if (context.Session.GetString("el_file_manager:switch_copy_cut") == null)
                {
                    Write("false");
                    return;
                }

                string[] FileDirectoryPathArray = context.Session.GetString("el_file_manager:file_directory_copy_list").Split('$');

                int i = 0;
                foreach (string FileDirectoryPath in FileDirectoryPathArray)
                {
                    FileDirectoryPathArray[i] = StaticObject.ServerMapPath(StaticObject.SitePath + FileDirectoryPath);
                    i++;
                }

                string DirectoryPath = StaticObject.ServerMapPath(StaticObject.SitePath + context.Request.Query["directory_path"].ToString());

                switch (context.Session.GetString("el_file_manager:switch_copy_cut"))
                {
                    case "cut":
                        {
                            foreach (string FileDirectoryPath in FileDirectoryPathArray)
                            {
                                if (Directory.Exists(FileDirectoryPath))
                                {
                                    string DirectoryName = new DirectoryInfo(FileDirectoryPath).Name;
                                    DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(DirectoryPath, DirectoryName);
                                    Directory.Move(FileDirectoryPath, DirectoryPath + "/" + DirectoryName);
                                }
                                else
                                {
                                    string FileName = Path.GetFileName(FileDirectoryPath);
                                    FileName = FileAndDirectory.GetNewFileNameIfFileNameExist(DirectoryPath, FileName);
                                    File.Move(FileDirectoryPath, DirectoryPath + "/" + FileName);
                                }
                            }
                        }; break;
                    case "copy":
                        {
                            foreach (string FileDirectoryPath in FileDirectoryPathArray)
                            {
                                if (Directory.Exists(FileDirectoryPath))
                                {
                                    string DirectoryName = new DirectoryInfo(FileDirectoryPath).Name;
                                    DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(DirectoryPath, DirectoryName);
                                    FileAndDirectory.DirectoryCopy(FileDirectoryPath, DirectoryPath + "/" + DirectoryName, true);
                                }
                                else
                                {
                                    string FileName = Path.GetFileName(FileDirectoryPath);
                                    FileName = FileAndDirectory.GetNewFileNameIfFileNameExist(DirectoryPath, FileName);
                                    File.Copy(FileDirectoryPath, DirectoryPath + "/" + FileName);
                                }
                            }
                        };break;
                }


                // Delete File Directory Session
                context.Session.SetString("el_file_manager:file_directory_copy_list", null);
                context.Session.SetString("el_file_manager:switch_copy_cut", null);


                // Add Reference
                ReferenceClass rc = new ReferenceClass();
                rc.StartEvent("paste_file_directory", context.Request.Query["directory_path"].ToString());


                Write("true");
            }
            else
                Write("false");
        }
    }
}