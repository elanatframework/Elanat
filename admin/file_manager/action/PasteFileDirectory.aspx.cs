using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace elanat
{
    public partial class ActionPasteFileDirectory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["directory_path"]))
            {
                if (Session["el_file_manager:file_directory_copy_list"] == null)
                {
                    Response.Write("false");
                    return;
                }

                if (Session["el_file_manager:switch_copy_cut"] == null)
                {
                    Response.Write("false");
                    return;
                }

                string[] FileDirectoryPathArray = Session["el_file_manager:file_directory_copy_list"].ToString().Split('$');

                int i = 0;
                foreach (string FileDirectoryPath in FileDirectoryPathArray)
                {
                    FileDirectoryPathArray[i] = HttpContext.Current.Server.MapPath(StaticObject.SitePath + FileDirectoryPath);
                    i++;
                }

                string DirectoryPath = HttpContext.Current.Server.MapPath(StaticObject.SitePath + Request.QueryString["directory_path"].ToString());

                switch (Session["el_file_manager:switch_copy_cut"].ToString())
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
                                    string FileName = System.IO.Path.GetFileName(FileDirectoryPath);
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
                                    string FileName = System.IO.Path.GetFileName(FileDirectoryPath);
                                    FileName = FileAndDirectory.GetNewFileNameIfFileNameExist(DirectoryPath, FileName);
                                    File.Copy(FileDirectoryPath, DirectoryPath + "/" + FileName);
                                }
                            }
                        };break;
                }


                // Delete File Directory Session
                Session["el_file_manager:file_directory_copy_list"] = null;
                Session["el_file_manager:switch_copy_cut"] = null;


                // Add Reference
                ReferenceClass rc = new ReferenceClass();
                rc.StartEvent("paste_file_directory", Request.QueryString["directory_path"].ToString());


                Response.Write("true");
            }
            else
                Response.Write("false");
        }
    }
}