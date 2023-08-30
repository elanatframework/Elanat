using System.Security.AccessControl;
using System.Security.Principal;

namespace Elanat
{
    public class FilePermissions
    {
        public bool FullControl { get; private set; }
        private bool FullControlIsDeny = false;
        private bool FullControlIsAllow = false;
        public bool Read { get; private set; }
        private bool ReadIsDeny = false;
        private bool ReadIsAllow = false;
        public bool Write { get; private set; }
        private bool WriteIsDeny = false;
        private bool WriteIsAllow = false;
        public bool AppendData { get; private set; }
        private bool AppendDataIsDeny = false;
        private bool AppendDataIsAllow = false;
        public bool ChangePermissions { get; private set; }
        private bool ChangePermissionsIsDeny = false;
        private bool ChangePermissionsIsAllow = false;
        public bool Delete { get; private set; }
        private bool DeleteIsDeny = false;
        private bool DeleteIsAllow = false;
        public bool ExecuteFile { get; private set; }
        private bool ExecuteFileIsDeny = false;
        private bool ExecuteFileIsAllow = false;
        public bool Modify { get; private set; }
        private bool ModifyIsDeny = false;
        private bool ModifyIsAllow = false;
        public bool ReadAndExecute { get; private set; }
        private bool ReadAndExecuteIsDeny = false;
        private bool ReadAndExecuteIsAllow = false;
        public bool ReadAttributes { get; private set; }
        private bool ReadAttributesIsDeny = false;
        private bool ReadAttributesIsAllow = false;
        public bool ReadData { get; private set; }
        private bool ReadDataIsDeny = false;
        private bool ReadDataIsAllow = false;
        public bool ReadExtendedAttributes { get; private set; }
        private bool ReadExtendedAttributesIsDeny = false;
        private bool ReadExtendedAttributesIsAllow = false;
        public bool ReadPermissions { get; private set; }
        private bool ReadPermissionsIsDeny = false;
        private bool ReadPermissionsIsAllow = false;
        public bool TakeOwnership { get; private set; }
        private bool TakeOwnershipIsDeny = false;
        private bool TakeOwnershipIsAllow = false;
        public bool WriteAttributes { get; private set; }
        private bool WriteAttributesIsDeny = false;
        private bool WriteAttributesIsAllow = false;
        public bool WriteData { get; private set; }
        private bool WriteDataIsDeny = false;
        private bool WriteDataIsAllow = false;
        public bool WriteExtendedAttributes { get; private set; }
        private bool WriteExtendedAttributesIsDeny = false;
        private bool WriteExtendedAttributesIsAllow = false;

        public void FillFilePermissions(string Path)
        {
            FileInfo info = new FileInfo(Path);
            FileSecurity security = info.GetAccessControl();

            foreach (FileSystemAccessRule fsar in security.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier)))
            {
                System.Security.AccessControl.FileSystemAccessRule rule = (System.Security.AccessControl.FileSystemAccessRule)fsar;

                if (System.Security.AccessControl.AccessControlType.Deny.Equals(rule.AccessControlType))
                {
                    if (((int)FileSystemRights.FullControl & (int)rule.FileSystemRights) == (int)FileSystemRights.FullControl)
                        FullControlIsDeny = true;
                    if (((int)FileSystemRights.Read & (int)rule.FileSystemRights) == (int)FileSystemRights.Read)
                        ReadIsDeny = true;
                    if (((int)FileSystemRights.Write & (int)rule.FileSystemRights) == (int)FileSystemRights.Write)
                        WriteIsDeny = true;
                    if (((int)FileSystemRights.AppendData & (int)rule.FileSystemRights) == (int)FileSystemRights.AppendData)
                        AppendDataIsDeny = true;
                    if (((int)FileSystemRights.ChangePermissions & (int)rule.FileSystemRights) == (int)FileSystemRights.ChangePermissions)
                        ChangePermissionsIsDeny = true;
                    if (((int)FileSystemRights.Delete & (int)rule.FileSystemRights) == (int)FileSystemRights.Delete)
                        DeleteIsDeny = true;
                    if (((int)FileSystemRights.ExecuteFile & (int)rule.FileSystemRights) == (int)FileSystemRights.ExecuteFile)
                        ExecuteFileIsDeny = true;
                    if (((int)FileSystemRights.Modify & (int)rule.FileSystemRights) == (int)FileSystemRights.Modify)
                        ModifyIsDeny = true;
                    if (((int)FileSystemRights.ReadAndExecute & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadAndExecute)
                        ReadAndExecuteIsDeny = true;
                    if (((int)FileSystemRights.ReadAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadAttributes)
                        ReadAttributesIsDeny = true;
                    if (((int)FileSystemRights.ReadData & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadData)
                        ReadDataIsDeny = true;
                    if (((int)FileSystemRights.ReadExtendedAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadExtendedAttributes)
                        ReadExtendedAttributesIsDeny = true;
                    if (((int)FileSystemRights.ReadPermissions & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadPermissions)
                        ReadPermissionsIsDeny = true;
                    if (((int)FileSystemRights.TakeOwnership & (int)rule.FileSystemRights) == (int)FileSystemRights.TakeOwnership)
                        TakeOwnershipIsDeny = true;
                    if (((int)FileSystemRights.WriteAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.WriteAttributes)
                        WriteAttributesIsDeny = true;
                    if (((int)FileSystemRights.WriteData & (int)rule.FileSystemRights) == (int)FileSystemRights.WriteData)
                        WriteDataIsDeny = true;
                    if (((int)FileSystemRights.WriteExtendedAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.WriteExtendedAttributes)
                        WriteExtendedAttributesIsDeny = true;
                }
                else if (System.Security.AccessControl.AccessControlType.Allow.Equals(rule.AccessControlType))
                {
                    if (((int)FileSystemRights.FullControl & (int)rule.FileSystemRights) == (int)FileSystemRights.FullControl)
                        FullControlIsAllow = true;
                    if (((int)FileSystemRights.Read & (int)rule.FileSystemRights) == (int)FileSystemRights.Read)
                        ReadIsAllow = true;
                    if (((int)FileSystemRights.Write & (int)rule.FileSystemRights) == (int)FileSystemRights.Write)
                        WriteIsAllow = true;
                    if (((int)FileSystemRights.AppendData & (int)rule.FileSystemRights) == (int)FileSystemRights.AppendData)
                        AppendDataIsAllow = true;
                    if (((int)FileSystemRights.ChangePermissions & (int)rule.FileSystemRights) == (int)FileSystemRights.ChangePermissions)
                        ChangePermissionsIsAllow = true;
                    if (((int)FileSystemRights.Delete & (int)rule.FileSystemRights) == (int)FileSystemRights.Delete)
                        DeleteIsAllow = true;
                    if (((int)FileSystemRights.ExecuteFile & (int)rule.FileSystemRights) == (int)FileSystemRights.ExecuteFile)
                        ExecuteFileIsAllow = true;
                    if (((int)FileSystemRights.Modify & (int)rule.FileSystemRights) == (int)FileSystemRights.Modify)
                        ModifyIsAllow = true;
                    if (((int)FileSystemRights.ReadAndExecute & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadAndExecute)
                        ReadAndExecuteIsAllow = true;
                    if (((int)FileSystemRights.ReadAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadAttributes)
                        ReadAttributesIsAllow = true;
                    if (((int)FileSystemRights.ReadData & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadData)
                        ReadDataIsAllow = true;
                    if (((int)FileSystemRights.ReadExtendedAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadExtendedAttributes)
                        ReadExtendedAttributesIsAllow = true;
                    if (((int)FileSystemRights.ReadPermissions & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadPermissions)
                        ReadPermissionsIsAllow = true;
                    if (((int)FileSystemRights.TakeOwnership & (int)rule.FileSystemRights) == (int)FileSystemRights.TakeOwnership)
                        TakeOwnershipIsAllow = true;
                    if (((int)FileSystemRights.WriteAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.WriteAttributes)
                        WriteAttributesIsAllow = true;
                    if (((int)FileSystemRights.WriteData & (int)rule.FileSystemRights) == (int)FileSystemRights.WriteData)
                        WriteDataIsAllow = true;
                    if (((int)FileSystemRights.WriteExtendedAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.WriteExtendedAttributes)
                        WriteExtendedAttributesIsAllow = true;
                }
            }

            FullControl = !FullControlIsDeny && FullControlIsAllow;
            Read = !ReadIsDeny && ReadIsAllow;
            Write = !WriteIsDeny && WriteIsAllow;
            AppendData = !AppendDataIsDeny && AppendDataIsAllow;
            ChangePermissions = !ChangePermissionsIsDeny && ChangePermissionsIsAllow;
            Delete = !DeleteIsDeny && DeleteIsAllow;
            ExecuteFile = !ExecuteFileIsDeny && ExecuteFileIsAllow;
            Modify = !ModifyIsDeny && ModifyIsAllow;
            ReadAndExecute = !ReadAndExecuteIsDeny && ReadAndExecuteIsAllow;
            ReadAttributes = !ReadAttributesIsDeny && ReadAttributesIsAllow;
            ReadData = !ReadDataIsDeny && ReadDataIsAllow;
            ReadExtendedAttributes = !ReadExtendedAttributesIsDeny && ReadExtendedAttributesIsAllow;
            ReadPermissions = !ReadPermissionsIsDeny && ReadPermissionsIsAllow;
            TakeOwnership = !TakeOwnershipIsDeny && TakeOwnershipIsAllow;
            WriteAttributes = !WriteAttributesIsDeny && WriteAttributesIsAllow;
            WriteData = !WriteDataIsDeny && WriteDataIsAllow;
            WriteExtendedAttributes = !WriteExtendedAttributesIsDeny && WriteExtendedAttributesIsAllow;
        }

        public void SetFilePermissions(string Path, bool FullControl, bool Read, bool Write, bool AppendData, bool ChangePermissions, bool Delete, bool ExecuteFile, bool Modify, bool ReadAndExecute, bool ReadAttributes, bool ReadData, bool ReadExtendedAttributes, bool ReadPermissions, bool TakeOwnership, bool WriteAttributes, bool WriteData, bool WriteExtendedAttributes)
        {
            FileInfo info = new FileInfo(Path);
            FileSecurity security = info.GetAccessControl();

            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Read, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Write, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.AppendData, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ChangePermissions, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Delete, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ExecuteFile, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Modify, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadAndExecute, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadAttributes, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadData, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadExtendedAttributes, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadPermissions, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.TakeOwnership, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.WriteAttributes, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.WriteData, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.WriteExtendedAttributes, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));

            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (FullControl) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Read,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (Read) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Write,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (Write) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.AppendData,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (AppendData) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ChangePermissions,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (ChangePermissions) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Delete,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (Delete) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ExecuteFile,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (ExecuteFile) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Modify,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (Modify) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadAndExecute,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (ReadAndExecute) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadAttributes,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (ReadAttributes) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadData,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (ReadData) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadExtendedAttributes,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (ReadExtendedAttributes) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadPermissions,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (ReadPermissions) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.TakeOwnership,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (TakeOwnership) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.WriteAttributes,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (WriteAttributes) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.WriteData,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (WriteData) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.WriteExtendedAttributes,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, (WriteExtendedAttributes) ? AccessControlType.Allow : AccessControlType.Deny));

            info.SetAccessControl(security);
        }
    }
}