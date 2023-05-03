using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace elanat
{
    public class ReCompileIssues
    {
        public List<string> BinFileName = new List<string>();
        public void PreparingAddOnBinDll(string AddOnTmpDirectoryName)
        {
            // If "root/bin/" Directory Exist
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + AddOnTmpDirectoryName + "/root/bin/")))
                return;

            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + AddOnTmpDirectoryName + "/root/App_Data/elanat_system_data/tmp_bin/"));

            DirectoryInfo directory = new DirectoryInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + AddOnTmpDirectoryName + "/root/bin/"));

            foreach (FileInfo file in directory.GetFiles("*.*", SearchOption.AllDirectories))
            {
                BinFileName.Add(file.Name);

                if (!File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin/" + file.Name)))
                    file.MoveTo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + AddOnTmpDirectoryName + "/root/App_Data/elanat_system_data/tmp_bin/" + file.Name));
                else
                    Security.SetLogError("file exist error", "when preparing add_on bin dll, " + file.Name + " already exists.");
            }

            Directory.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/tmp/" + AddOnTmpDirectoryName + "/root/bin/"), true);
        }

        public string AddOnInstallPath = "";
        public bool ExistBinBefore = false;
        public void SetTmpBinToBinDirectory()
        {
            // Create Start Up For Run AddOns Install
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/start_up_list/start_up.xml"));

            XmlElement StartUpElement = doc.CreateElement("start_up");
            StartUpElement.SetAttribute("name", "start_add_on_install");
            StartUpElement.SetAttribute("path", "/action/system_access/start_up/start_add_on_install/Default.aspx");
            StartUpElement.SetAttribute("active", "true");

            doc.SelectSingleNode("start_up_root/start_up_list").AppendChild(StartUpElement);

            doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/start_up_list/start_up.xml"));

            StaticObject.SetStartUpDocument();


            DirectoryInfo directory = new DirectoryInfo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin/"));

            foreach (FileInfo file in directory.GetFiles("*.*", SearchOption.AllDirectories))
                if (!File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "bin/" + file.Name)))
                    file.MoveTo(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "bin/" + file.Name));
                else
                {
                    Security.SetLogError("file exist error", "when move tmp_bin directory to bin directory, " + file.Name + " already exists.");
                    ExistBinBefore = true;
                }
        }

        /// <param name="AddOnType">component, module, plugin, patch, fetch, page, extra_helper, editor_template</param>
        public void AddTmpBinAddOnToTmpBinFileList(string BinFileName, string AddOnName, string AddOnType, string AddOnPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin_file_list/tmp_bin_file.xml"));

            XmlElement TmpBinFileElement = doc.CreateElement("tmp_bin_file");
            TmpBinFileElement.SetAttribute("file_name", BinFileName);
            TmpBinFileElement.SetAttribute("add_on_name", AddOnName);
            TmpBinFileElement.SetAttribute("add_on_type", AddOnType);
            TmpBinFileElement.SetAttribute("add_on_path", AddOnPath);

            doc.SelectSingleNode("tmp_bin_file_root/tmp_bin_file_list").AppendChild(TmpBinFileElement);

            doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin_file_list/tmp_bin_file.xml"));
        }

        // Overload
        /// <param name="AddOnType">component, module, plugin, patch, fetch, page, extra_helper, editor_template</param>
        public void AddTmpBinAddOnToTmpBinFileList(List<string> BinFileNameList, string AddOnName, string AddOnType, string AddOnPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin_file_list/tmp_bin_file.xml"));

            foreach (string BinFileName in BinFileNameList)
            {
                XmlElement TmpBinFileElement = doc.CreateElement("tmp_bin_file");
                TmpBinFileElement.SetAttribute("file_name", BinFileName);
                TmpBinFileElement.SetAttribute("add_on_name", AddOnName);
                TmpBinFileElement.SetAttribute("add_on_type", AddOnType);
                TmpBinFileElement.SetAttribute("add_on_path", AddOnPath);

                doc.SelectSingleNode("tmp_bin_file_root/tmp_bin_file_list").AppendChild(TmpBinFileElement);
            }

            doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin_file_list/tmp_bin_file.xml"));
        }

        public void StartAddOnInstall(bool SetHasInstall = true)
        {
            RunTmpBinListAddOnInstall(false, SetHasInstall);


            // Delete Run AddOns Install Element In Start Up
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/start_up_list/start_up.xml"));

            if (doc.SelectSingleNode("start_up_root/start_up_list/start_up[@name='start_add_on_install']") == null)
                return;


            XmlNode StartUpNode = doc.SelectSingleNode("start_up_root/start_up_list/start_up[@name='start_add_on_install']");

            doc.SelectSingleNode("start_up_root/start_up_list").RemoveChild(StartUpNode);

            doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/start_up_list/start_up.xml"));

            StaticObject.SetStartUpDocument();
        }

        public void RunTmpBinListAddOnInstall(bool DeleteAllTmpBinFileElement = false, bool SetHasInstall = false)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin_file_list/tmp_bin_file.xml"));

            XmlNodeList NodeList = doc.SelectNodes("tmp_bin_file_root/tmp_bin_file_list/tmp_bin_file");
            List<string> AddCheckList = new List<string>();

            foreach (XmlNode node in NodeList)
            {
                if (AddCheckList.Contains(node.Attributes["add_on_name"].Value))
                    continue;

                string CatalogElementPrefix = node.Attributes["add_on_type"].Value;
                string AddOnPath = "";
                switch (node.Attributes["add_on_type"].Value)
                {
                    case "component": AddOnPath = StaticObject.AdminPath + "/"; break;
                    case "page": AddOnPath = StaticObject.SitePath + "page/"; break;
                    default: AddOnPath = StaticObject.SitePath + "add_on/" + node.Attributes["add_on_type"].Value + "/"; break;
                }
                string CatalogPath = AddOnPath + node.Attributes["add_on_path"].Value + "/catalog.xml";

                if (!File.Exists(HttpContext.Current.Server.MapPath(CatalogPath)))
                    continue;

                XmlDocument AddOnCatalog = new XmlDocument();
                AddOnCatalog.Load(HttpContext.Current.Server.MapPath(CatalogPath));


                bool HasInstall = false;
                if (node.Attributes["has_install"] != null)
                    if (node.Attributes["has_install"].Value == "true")
                        HasInstall = true;


                // Run Install Page
                if (!HasInstall)
                {
                    if (node.Attributes["add_on_type"].Value != "page" && node.Attributes["add_on_type"].Value != "fetch")
                        if (!string.IsNullOrEmpty(AddOnCatalog.SelectNodes(node.Attributes["add_on_type"].Value + "_catalog_root/" + CatalogElementPrefix + "_install_path")[0].Attributes["value"].Value))
                            PageLoader.LoadWithServer(AddOnPath + node.Attributes["add_on_path"].Value + "/" + AddOnCatalog.SelectNodes(node.Attributes["add_on_type"].Value + "_catalog_root/" + CatalogElementPrefix + "_install_path")[0].Attributes["value"].Value);


                    if (SetHasInstall)
                    {
                        XmlAttribute attr = doc.CreateAttribute("has_install");
                        attr.Value = "true";
                        doc.SelectSingleNode("tmp_bin_file_root/tmp_bin_file_list/tmp_bin_file[@add_on_type='" + node.Attributes["add_on_type"].Value + "'][@add_on_path='" + node.Attributes["add_on_path"].Value + "']").Attributes.Append(attr);
                        doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin_file_list/tmp_bin_file.xml"));
                    }
                }

                AddCheckList.Add(node.Attributes["add_on_name"].Value);

                if (DeleteAllTmpBinFileElement)
                {
                    doc.SelectSingleNode("tmp_bin_file_root/tmp_bin_file_list").RemoveAll();
                    doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin_file_list/tmp_bin_file.xml"));
                }
            }
        }

        /// <param name="AddOnType">component, module, plugin, patch, page, extra_helper, editor_template</param>
        public bool ExistAddOnToTmpBinList(string AddOnType, string AddOnDirectoryPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin_file_list/tmp_bin_file.xml"));

            return (doc.SelectSingleNode("tmp_bin_file_root/tmp_bin_file_list/tmp_bin_file[@add_on_type='" + AddOnType + "'][@add_on_path='" + AddOnDirectoryPath + "']") != null);
        }

        /// <param name="AddOnType">component, module, plugin, patch, page, extra_helper, editor_template</param>
        public void SetAddOnDeletedToTmpBinList(string AddOnType, string AddOnDirectoryPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin_file_list/tmp_bin_file.xml"));

            XmlAttribute attr = doc.CreateAttribute("add_on_deleted");
            attr.Value = "true";

            doc.SelectSingleNode("tmp_bin_file_root/tmp_bin_file_list/tmp_bin_file[@add_on_type='" + AddOnType + "'][@add_on_path='" + AddOnDirectoryPath + "']").Attributes.SetNamedItem(attr);

            doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin_file_list/tmp_bin_file.xml"));
        }

        public void DeleteDeletedAddOnDirectory(bool DeleteTmpBinFileElement = false, bool DeleteBinFile = false)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin_file_list/tmp_bin_file.xml"));

            XmlNodeList NodeList = doc.SelectNodes("tmp_bin_file_root/tmp_bin_file_list/tmp_bin_file");

            foreach (XmlNode node in NodeList)
            {
                if (node.Attributes["add_on_deleted"] == null)
                    continue;

                string CatalogElementPrefix = node.Attributes["add_on_type"].Value;
                string AddOnPath = "";
                switch (CatalogElementPrefix)
                {
                    case "component": AddOnPath = StaticObject.AdminPath + "/"; break;
                    case "page": AddOnPath = StaticObject.SitePath + "page/"; break;
                    default: AddOnPath = StaticObject.SitePath + "add_on/" + CatalogElementPrefix + "/"; break;
                }
                string CatalogPath = AddOnPath + node.Attributes["add_on_path"].Value + "/catalog.xml";

                if (!File.Exists(HttpContext.Current.Server.MapPath(CatalogPath)))
                    continue;


                List<string> ParentDirectoryList = node.Attributes["add_on_path"].Value.Split('/').ToList();
                bool IsLastDirectory = true;

                while (ParentDirectoryList.Count >= 1)
                {
                    string TmpPath = string.Join("/", ParentDirectoryList.ToArray());

                    if (string.IsNullOrEmpty(TmpPath.Replace("/", "").Replace(@"\", "")))
                        break;

                    System.IO.Directory.Delete(HttpContext.Current.Server.MapPath(AddOnPath + TmpPath + "/"), IsLastDirectory);
                    ParentDirectoryList.RemoveAt(ParentDirectoryList.Count - 1);

                    IsLastDirectory = false;
                }


                if (DeleteBinFile)
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin/" + node.Attributes["file_name"].Value)))
                        File.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin/" + node.Attributes["file_name"].Value));

                    if (File.Exists(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "bin/" + node.Attributes["file_name"].Value)))
                        File.Delete(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "bin/" + node.Attributes["file_name"].Value));
                }

                if (DeleteTmpBinFileElement)
                    doc.SelectSingleNode("tmp_bin_file_root/tmp_bin_file_list").RemoveChild(node);
            }

            if (DeleteTmpBinFileElement)
                doc.Save(HttpContext.Current.Server.MapPath(StaticObject.SitePath + "App_Data/elanat_system_data/tmp_bin_file_list/tmp_bin_file.xml"));
        }
    }
}