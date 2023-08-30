using CodeBehind;

namespace Elanat
{
    public partial class ActionChangeFilePermissionsModel : CodeBehindModel
    {
        public string ChangeFilePermissionsLanguage { get; set; }
        public string EditFilePermissionsLanguage { get; set; }
        public string FileNameLanguage { get; set; }
        public string SaveFilePermissionsLanguage { get; set; }
        public string FullControlLanguage { get; set; }
        public string ReadLanguage { get; set; }
        public string WriteLanguage { get; set; }
        public string AppendDataLanguage { get; set; }
        public string ChangePermissionsLanguage { get; set; }
        public string DeleteLanguage { get; set; }
        public string ExecuteFileLanguage { get; set; }
        public string ModifyLanguage { get; set; }
        public string ReadAndExecuteLanguage { get; set; }
        public string ReadAttributesLanguage { get; set; }
        public string ReadDataLanguage { get; set; }
        public string ReadExtendedAttributesLanguage { get; set; }
        public string ReadPermissionsLanguage { get; set; }
        public string TakeOwnershipLanguage { get; set; }
        public string WriteAttributesLanguage { get; set; }
        public string WriteDataLanguage { get; set; }
        public string WriteExtendedAttributesLanguage { get; set; }

        public string FileNameValue { get; set; }
        public string FilePathValue { get; set; }

        public bool FullControlValue { get; set; } = false;
        public bool ReadValue { get; set; } = false;
        public bool WriteValue { get; set; } = false;
        public bool AppendDataValue { get; set; } = false;
        public bool ChangePermissionsValue { get; set; } = false;
        public bool DeleteValue { get; set; } = false;
        public bool ExecuteFileValue { get; set; } = false;
        public bool ModifyValue { get; set; } = false;
        public bool ReadAndExecuteValue { get; set; } = false;
        public bool ReadAttributesValue { get; set; } = false;
        public bool ReadDataValue { get; set; } = false;
        public bool ReadExtendedAttributesValue { get; set; } = false;
        public bool ReadPermissionsValue { get; set; } = false;
        public bool TakeOwnershipValue { get; set; } = false;
        public bool WriteAttributesValue { get; set; } = false;
        public bool WriteDataValue { get; set; } = false;
        public bool WriteExtendedAttributesValue { get; set; } = false;

        public void SetValue()
        {
            // Set Language
            AddOnsLanguage aol = new AddOnsLanguage(StaticObject.GetCurrentAdminGlobalLanguage(), StaticObject.AdminPath + "/file_manager/");
            ChangeFilePermissionsLanguage = aol.GetAddOnsLanguage("change_file_permissions");
            EditFilePermissionsLanguage = aol.GetAddOnsLanguage("edit_file_permissions");
            SaveFilePermissionsLanguage = aol.GetAddOnsLanguage("save_file_permissions");
            FileNameLanguage = aol.GetAddOnsLanguage("file_name");
            FullControlLanguage = aol.GetAddOnsLanguage("full_control");
            ReadLanguage = aol.GetAddOnsLanguage("read");
            WriteLanguage = aol.GetAddOnsLanguage("write");
            AppendDataLanguage = aol.GetAddOnsLanguage("append_data");
            ChangePermissionsLanguage = aol.GetAddOnsLanguage("change_permissions");
            DeleteLanguage = aol.GetAddOnsLanguage("delete");
            ExecuteFileLanguage = aol.GetAddOnsLanguage("execute_file");
            ModifyLanguage = aol.GetAddOnsLanguage("modify");
            ReadAndExecuteLanguage = aol.GetAddOnsLanguage("read_and_execute");
            ReadAttributesLanguage = aol.GetAddOnsLanguage("read_attributes");
            ReadDataLanguage = aol.GetAddOnsLanguage("read_data");
            ReadExtendedAttributesLanguage = aol.GetAddOnsLanguage("read_extended_attributes");
            ReadPermissionsLanguage = aol.GetAddOnsLanguage("read_permissions");
            TakeOwnershipLanguage = aol.GetAddOnsLanguage("take_ownership");
            WriteAttributesLanguage = aol.GetAddOnsLanguage("write_attributes");
            WriteDataLanguage = aol.GetAddOnsLanguage("write_data");
            WriteExtendedAttributesLanguage = aol.GetAddOnsLanguage("write_extended_attributes");


            // Set Current Value
            FilePermissions permissions = new FilePermissions();
            permissions.FillFilePermissions(StaticObject.ServerMapPath(StaticObject.SitePath + FilePathValue));

            FullControlValue = permissions.FullControl;
            ReadValue = permissions.Read;
            WriteValue = permissions.Write;
            AppendDataValue = permissions.AppendData;
            ChangePermissionsValue = permissions.ChangePermissions;
            DeleteValue = permissions.Delete;
            ExecuteFileValue = permissions.ExecuteFile;
            ModifyValue = permissions.Modify;
            ReadAndExecuteValue = permissions.ReadAndExecute;
            ReadAttributesValue = permissions.ReadAttributes;
            ReadDataValue = permissions.ReadData;
            ReadExtendedAttributesValue = permissions.ReadExtendedAttributes;
            ReadPermissionsValue = permissions.ReadPermissions;
            TakeOwnershipValue = permissions.TakeOwnership;
            WriteAttributesValue = permissions.WriteAttributes;
            WriteDataValue = permissions.WriteData;
            WriteExtendedAttributesValue = permissions.WriteExtendedAttributes;
        }

        public void SaveFilePermissions()
        {
            // Change Permissions
            string FileName = FileNameValue;
            bool FullControl = FullControlValue;
            bool Read = ReadValue;
            bool Write = WriteValue;
            bool AppendData = AppendDataValue;
            bool ChangePermissions = ChangePermissionsValue;
            bool Delete = DeleteValue;
            bool ExecuteFile = ExecuteFileValue;
            bool Modify = ModifyValue;
            bool ReadAndExecute = ReadAndExecuteValue;
            bool ReadAttributes = ReadAttributesValue;
            bool ReadData = ReadDataValue;
            bool ReadExtendedAttributes = ReadExtendedAttributesValue;
            bool ReadPermissions = ReadPermissionsValue;
            bool TakeOwnership = TakeOwnershipValue;
            bool WriteAttributes = WriteAttributesValue;
            bool WriteData = WriteDataValue;
            bool WriteExtendedAttributes = WriteExtendedAttributesValue;

            // Set File Permissions
            FilePermissions permissions = new FilePermissions();
            permissions.SetFilePermissions(StaticObject.ServerMapPath(StaticObject.SitePath + FilePathValue), FullControl, Read, Write, AppendData, ChangePermissions, Delete, ExecuteFile, Modify, ReadAndExecute, ReadAttributes, ReadData, ReadExtendedAttributes, ReadPermissions, TakeOwnership, WriteAttributes, WriteData, WriteExtendedAttributes);


            // Add Reference
            ReferenceClass rc = new ReferenceClass();
            rc.StartEvent("save_file_permissions", FileName);
        }

        public void SuccessView()
        {
            new HttpContextAccessor().HttpContext.Response.Redirect(StaticObject.AdminPath + "/file_manager/action/change_file_permissions/action/SuccessMessage.aspx", true);
        }
    }
}