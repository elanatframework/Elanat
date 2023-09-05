using CodeBehind;
using SetCodeBehind;
using System.Reflection.Metadata;
using System.Xml;

namespace Elanat
{
    public partial class AdminPatchModel : CodeBehindModel
    {
        public string PatchLanguage { get; set; }
        public string AddLanguage { get; set; }
        public string RefreshLanguage { get; set; }
        public string AddPatchLanguage { get; set; }
        public string PatchPathLanguage { get; set; }
        public string UsePatchPathLanguage { get; set; }
        public string PatchActiveLanguage { get; set; }

        public bool UsePatchPathValue { get; set; } = false;
        public bool PatchActiveValue { get; set; } = false;
        public IFormFile PatchPathUploadValue { get; set; }
        public string PatchPathTextValue { get; set; }
        public string ContentValue { get; set; }

        public void SetValue(List<ListItem> QueryString)
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/patch/");
            PatchLanguage = aol.GetAddOnsLanguage("patch");
            PatchPathLanguage = aol.GetAddOnsLanguage("patch_path");
            AddPatchLanguage = aol.GetAddOnsLanguage("add_patch");
            UsePatchPathLanguage = aol.GetAddOnsLanguage("use_patch_path");
            PatchActiveLanguage = aol.GetAddOnsLanguage("patch_active");
            AddLanguage = aol.GetAddOnsLanguage("add");
            RefreshLanguage = Language.GetLanguage("refresh", StaticObject.GetCurrentAdminGlobalLanguage());


            // Set Site Style Page List
            ActionGetPatchListModel lm = new ActionGetPatchListModel();
            lm.SetValue(QueryString);
            ContentValue = lm.ListValue + ContentValue;
        }

        public void AddPatch()
        {
            string PatchDirectoryPath = "";
            string PatchFilePhysicalName = "";
            string DirectoryName = "";

            // If Use Patch Path
            if (UsePatchPathValue)
            {
                if (string.IsNullOrEmpty(PatchPathTextValue))
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_patch_path_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/patch/"), "problem");

                    return;
                }

                HttpClient webClient = new HttpClient();

                PatchFilePhysicalName = Path.GetFileName(PatchPathTextValue);

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(PatchFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                webClient.DownloadFile(PatchPathTextValue, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + PatchFilePhysicalName));
            }
            else
            {
                if (!PatchPathUploadValue.HtmlInputHasFile())
                {
                    ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("please_fill_patch_upload_field_because_this_is_necessary", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/patch/"), "problem");

                    return;
                }

                PatchFilePhysicalName = PatchPathUploadValue.FileName;

                DirectoryName = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), Path.GetFileNameWithoutExtension(PatchFilePhysicalName));

                Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/") + "/" + DirectoryName);
                PatchPathUploadValue.SaveAs(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + PatchFilePhysicalName));
            }

            // Check Patch File Size
            double FileSize = new FileInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + PatchFilePhysicalName)).Length;
            string MaxOfFileSizeUpload = ElanatConfig.GetNode("file_and_directory/maximum_size_for_patch").Attributes["value"].Value;

            if (FileSize > int.Parse(MaxOfFileSizeUpload))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetLanguage("file_size_must_be_less_than_asp", StaticObject.GetCurrentAdminGlobalLanguage()).Replace("$_asp max_of_file_size_upload;", long.Parse(MaxOfFileSizeUpload).ToBitSizeTuning()), "problem");
            }

            XmlDocument CatalogDocument = new XmlDocument();

            // Extract Zip File
            ZipFileClass zfc = new ZipFileClass();
            zfc.UnZip(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/" + PatchFilePhysicalName), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

            if (!Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/patch")))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("zip_file_is_corrupt", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/patch/"), "warning");

                return;
            }

            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/patch/catalog.xml"));
            XmlNode TmpPatchCatalog = CatalogDocument.SelectSingleNode("/patch_catalog_root");


            // Unique Value To Column Check
            DataUse.Common common = new DataUse.Common();
            if (common.ExistValueToColumnCheck("el_patch", "patch_name", TmpPatchCatalog["patch_name"].Attributes["value"].Value))
            {
                // Delete Physical File
                Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);

                ResponseForm.WriteLocalAlone(Language.GetAddOnsLanguage("patch_name_is_duplicate", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/patch/"), "problem");

                return;
            }


            PatchDirectoryPath = TmpPatchCatalog["patch_directory_path"].Attributes["value"].Value;
            PatchDirectoryPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/patch/"), PatchDirectoryPath);

            bool HasDll = false;

            ResponseForm rf = new ResponseForm(StaticObject.GetCurrentAdminGlobalLanguage());

            if (PatchDirectoryPath != TmpPatchCatalog["patch_directory_path"].Attributes["value"].Value)
                rf.AddLocalMessage(Language.GetLanguage("directory_path_was_changed_because_is_already_exist", StaticObject.GetCurrentAdminGlobalLanguage()), "problem");

            // Move All Patch File In "patch" Directory To Patch
            Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/patch/"), StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/patch/" + PatchDirectoryPath));

            // If "root" Directory Exist
            if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/")))
            {
                if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/")))
                    if (StaticObject.AdminDirectoryPath != "admin")
                        Directory.Move(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/admin/"), StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/" + StaticObject.AdminDirectoryPath + "/"));

                if (Directory.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/bin/")))
                    HasDll = true;

                /// <Action> Create Uninstall List
                DirectoryInfo directory = new DirectoryInfo(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"));

                XmlDocument UninstallDocument = new XmlDocument();
                UninstallDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/elanat_system_data/empty_patern/uninstall/uninstall.xml"));

                XmlNode FilePathList = UninstallDocument.SelectSingleNode("uninstall_root/file_path_list");
                                
                foreach (FileInfo file in directory.GetFiles("*.*", SearchOption.AllDirectories))
                {
                    XmlElement FilePathElement = UninstallDocument.CreateElement("file_path");
                    FilePathElement.InnerText = file.FullName.Replace(StaticObject.ServerMapPath((StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/").Replace("/","\\")), @"\");
                    FilePathList.AppendChild(FilePathElement);
                }

                UninstallDocument.Save(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/patch/" + PatchDirectoryPath + "/uninstall.xml"));


                /// <Action> Move All File In "root" Directory To Site Path
                FileAndDirectory.DirectoryCopy(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName + "/root/"), StaticObject.ServerMapPath(StaticObject.SitePath + ""), true);
            }


            // Delete Physical File
            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DirectoryName), true);


            // Add Data To Database
            DataUse.Patch dup = new DataUse.Patch();

            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/patch/" + (PatchDirectoryPath) + "/catalog.xml"));
            XmlNode PatchCatalog = CatalogDocument.SelectSingleNode("patch_catalog_root");

            dup.PatchName = PatchCatalog["patch_name"].Attributes["value"].Value;
            dup.PatchCategory = PatchCatalog["patch_category"].Attributes["value"].Value.SpaceToUnderline();
            dup.PatchDirectoryPath = PatchDirectoryPath;
            dup.PatchActive = PatchActiveValue.BooleanToZeroOne();

            // Add Patch
            dup.AddWithFillReturnDr();


            try { dup.ReturnDb.Close(); } catch (Exception) { }


            // Recompile
            if (HasDll)
            {
                CodeBehindCompiler.Initialization();
                CodeBehindCompiler.CompileAspx();
            }
            
            // Run Install Page
            if (dup.PatchActive.ZeroOneToBoolean() && !string.IsNullOrEmpty(PatchCatalog["patch_install_path"].Attributes["value"].Value))
                PageLoader.LoadPath(StaticObject.SitePath + "add_on/patch/" + dup.PatchDirectoryPath + "/" + PatchCatalog["patch_install_path"].Attributes["value"].Value, false);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("add_patch", dup.PatchName);


            rf.AddLocalMessage(Language.GetAddOnsLanguage("patch_was_add", StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/patch/"), "success");
            rf.AddPageLoad(StaticObject.AdminPath + "/patch/action/PatchNewRow.aspx?patch_id=" + dup.PatchId, "div_TableBox");
            rf.RedirectToResponseFormPage();
        }
    }
}