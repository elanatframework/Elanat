using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeDirectoryPermissionsModel : CodeBehindModel
    {
        public string ChangeDirectoryPermissionsLanguage { get; set; }
        public string EditDirectoryPermissionsLanguage { get; set; }
        public string DirectoryNameLanguage { get; set; }
        public string SaveDirectoryPermissionsLanguage { get; set; }
        public string FullControlLanguage { get; set; }
        public string ReadLanguage { get; set; }
        public string WriteLanguage { get; set; }
        public string CreateDirectoriesLanguage { get; set; }
        public string CreateFilesLanguage { get; set; }
        public string ChangePermissionsLanguage { get; set; }
        public string DeleteLanguage { get; set; }
        public string DeleteSubdirectoriesAndFilesLanguage { get; set; }
        public string ListDirectoryLanguage { get; set; }
        public string ModifyLanguage { get; set; }
        public string ReadAttributesLanguage { get; set; }
        public string ReadExtendedAttributesLanguage { get; set; }
        public string ReadPermissionsLanguage { get; set; }
        public string TakeOwnershipLanguage { get; set; }
        public string TraverseLanguage { get; set; }
        public string WriteAttributesLanguage { get; set; }
        public string WriteExtendedAttributesLanguage { get; set; }

        public string DirectoryNameValue { get; set; }
        public string DirectoryPathValue { get; set; }

        public bool FullControlValue { get; set; } = false;
        public bool ReadValue { get; set; } = false;
        public bool WriteValue { get; set; } = false;
        public bool CreateDirectoriesValue { get; set; } = false;
        public bool CreateFilesValue { get; set; } = false;
        public bool ChangePermissionsValue { get; set; } = false;
        public bool DeleteValue { get; set; } = false;
        public bool DeleteSubdirectoriesAndFilesValue { get; set; } = false;
        public bool ListDirectoryValue { get; set; } = false;
        public bool ModifyValue { get; set; } = false;
        public bool ReadAttributesValue { get; set; } = false;
        public bool ReadExtendedAttributesValue { get; set; } = false;
        public bool ReadPermissionsValue { get; set; } = false;
        public bool TakeOwnershipValue { get; set; } = false;
        public bool TraverseValue { get; set; } = false;
        public bool WriteAttributesValue { get; set; } = false;
        public bool WriteExtendedAttributesValue { get; set; } = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/");
            ChangeDirectoryPermissionsLanguage = aol.GetAddOnsLanguage("change_directory_permissions");
            EditDirectoryPermissionsLanguage = aol.GetAddOnsLanguage("edit_directory_permissions");
            SaveDirectoryPermissionsLanguage = aol.GetAddOnsLanguage("save_directory_permissions");
            DirectoryNameLanguage = aol.GetAddOnsLanguage("directory_name");
            FullControlLanguage = aol.GetAddOnsLanguage("full_control");
            ReadLanguage = aol.GetAddOnsLanguage("read");
            WriteLanguage = aol.GetAddOnsLanguage("write");
            CreateDirectoriesLanguage = aol.GetAddOnsLanguage("create_directories");
            CreateFilesLanguage = aol.GetAddOnsLanguage("create_files");
            ChangePermissionsLanguage = aol.GetAddOnsLanguage("change_permissions");
            DeleteLanguage = aol.GetAddOnsLanguage("delete");
            DeleteSubdirectoriesAndFilesLanguage = aol.GetAddOnsLanguage("delete_sub_directories_and_files");
            ListDirectoryLanguage = aol.GetAddOnsLanguage("list_directory");
            ModifyLanguage = aol.GetAddOnsLanguage("modify");
            ReadAttributesLanguage = aol.GetAddOnsLanguage("read_attributes");
            ReadExtendedAttributesLanguage = aol.GetAddOnsLanguage("read_extended_attributes");
            ReadPermissionsLanguage = aol.GetAddOnsLanguage("read_permissions");
            TakeOwnershipLanguage = aol.GetAddOnsLanguage("take_ownership");
            TraverseLanguage = aol.GetAddOnsLanguage("traverse");
            WriteAttributesLanguage = aol.GetAddOnsLanguage("write_attributes");
            WriteExtendedAttributesLanguage = aol.GetAddOnsLanguage("write_extended_attributes");


            // Set Current Value
            DirectoryPermissions permissions = new DirectoryPermissions();
            permissions.FillDirectoryPermissions(StaticObject.ServerMapPath(StaticObject.SitePath + DirectoryPathValue));

            FullControlValue = permissions.FullControl;
            ReadValue = permissions.Read;
            WriteValue = permissions.Write;
            CreateDirectoriesValue = permissions.CreateDirectories;
            CreateFilesValue = permissions.CreateFiles;
            ChangePermissionsValue = permissions.ChangePermissions;
            DeleteValue = permissions.Delete;
            DeleteSubdirectoriesAndFilesValue = permissions.DeleteSubdirectoriesAndFiles;
            ListDirectoryValue = permissions.ListDirectory;
            ModifyValue = permissions.Modify;
            ReadAttributesValue = permissions.ReadAttributes;
            ReadExtendedAttributesValue = permissions.ReadExtendedAttributes;
            ReadPermissionsValue = permissions.ReadPermissions;
            TakeOwnershipValue = permissions.TakeOwnership;
            TraverseValue = permissions.Traverse;
            WriteAttributesValue = permissions.WriteAttributes;
            WriteExtendedAttributesValue = permissions.WriteExtendedAttributes;
        }

        public void SaveDirectoryPermissions()
        {
            // Change Permissions
            string DirectoryName = DirectoryNameValue;
            bool FullControl = FullControlValue;
            bool Read = ReadValue;
            bool Write = WriteValue;
            bool CreateDirectories = CreateDirectoriesValue;
            bool CreateFiles = CreateFilesValue;
            bool ChangePermissions = ChangePermissionsValue;
            bool Delete = DeleteValue;
            bool DeleteSubdirectoriesAndFiles = DeleteSubdirectoriesAndFilesValue;
            bool ListDirectory = ListDirectoryValue;
            bool Modify = ModifyValue;
            bool ReadAttributes = ReadAttributesValue;
            bool ReadExtendedAttributes = ReadExtendedAttributesValue;
            bool ReadPermissions = ReadPermissionsValue;
            bool TakeOwnership = TakeOwnershipValue;
            bool Traverse = TraverseValue;
            bool WriteAttributes = WriteAttributesValue;
            bool WriteExtendedAttributes = WriteExtendedAttributesValue;

            // Set Directory Permissions
            DirectoryPermissions permissions = new DirectoryPermissions();
            permissions.SetDirectoryPermissions(StaticObject.ServerMapPath(StaticObject.SitePath + DirectoryPathValue), FullControl, Read, Write, ChangePermissions, CreateDirectories, CreateFiles, Delete, DeleteSubdirectoriesAndFiles, ListDirectory, Modify, ReadAttributes, ReadExtendedAttributes, ReadPermissions, TakeOwnership, Traverse, WriteAttributes, WriteExtendedAttributes);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_directory_permissions", DirectoryName);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/file_manager/action/change_directory_permissions/action/SuccessMessage.aspx", true);
        }
    }
}