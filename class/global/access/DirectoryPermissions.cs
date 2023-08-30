using System.Security.AccessControl;
using System.Security.Principal;

namespace Elanat
{
    public class DirectoryPermissions
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
        public bool ChangePermissions { get; private set; }
        private bool ChangePermissionsIsDeny = false;
        private bool ChangePermissionsIsAllow = false;
        public bool CreateDirectories { get; private set; }
        private bool CreateDirectoriesIsDeny = false;
        private bool CreateDirectoriesIsAllow = false;
        public bool CreateFiles { get; private set; }
        private bool CreateFilesIsDeny = false;
        private bool CreateFilesIsAllow = false;
        public bool Delete { get; private set; }
        private bool DeleteIsDeny = false;
        private bool DeleteIsAllow = false;
        public bool DeleteSubdirectoriesAndFiles { get; private set; }
        private bool DeleteSubdirectoriesAndFilesIsDeny = false;
        private bool DeleteSubdirectoriesAndFilesIsAllow = false;
        public bool ListDirectory { get; private set; }
        private bool ListDirectoryIsDeny = false;
        private bool ListDirectoryIsAllow = false;
        public bool Modify { get; private set; }
        private bool ModifyIsDeny = false;
        private bool ModifyIsAllow = false;
        public bool ReadAttributes { get; private set; }
        private bool ReadAttributesIsDeny = false;
        private bool ReadAttributesIsAllow = false;
        public bool ReadExtendedAttributes { get; private set; }
        private bool ReadExtendedAttributesIsDeny = false;
        private bool ReadExtendedAttributesIsAllow = false;
        public bool ReadPermissions { get; private set; }
        private bool ReadPermissionsIsDeny = false;
        private bool ReadPermissionsIsAllow = false;
        public bool TakeOwnership { get; private set; }
        private bool TakeOwnershipIsDeny = false;
        private bool TakeOwnershipIsAllow = false;
        public bool Traverse { get; private set; }
        private bool TraverseIsDeny = false;
        private bool TraverseIsAllow = false;
        public bool WriteAttributes { get; private set; }
        private bool WriteAttributesIsDeny = false;
        private bool WriteAttributesIsAllow = false;
        public bool WriteExtendedAttributes { get; private set; }
        private bool WriteExtendedAttributesIsDeny = false;
        private bool WriteExtendedAttributesIsAllow = false;

        public void FillDirectoryPermissions(string Path)
        {
            DirectoryInfo info = new DirectoryInfo(Path);
            DirectorySecurity security = info.GetAccessControl();

            foreach (FileSystemAccessRule fsar in security.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier)))
            {
                System.Security.AccessControl.FileSystemAccessRule rule = (System.Security.AccessControl.FileSystemAccessRule)fsar;
                
                if (AccessControlType.Deny.Equals(rule.AccessControlType))
                {
                    if (((int)FileSystemRights.FullControl & (int)rule.FileSystemRights) == (int)FileSystemRights.FullControl)
                        FullControlIsDeny = true;
                    if (((int)FileSystemRights.Read & (int)rule.FileSystemRights) == (int)FileSystemRights.Read)
                        ReadIsDeny = true;
                    if (((int)FileSystemRights.Write & (int)rule.FileSystemRights) == (int)FileSystemRights.Write)
                        WriteIsDeny = true;
                    if (((int)FileSystemRights.ChangePermissions & (int)rule.FileSystemRights) == (int)FileSystemRights.ChangePermissions)
                        ChangePermissionsIsDeny = true;
                    if (((int)FileSystemRights.CreateDirectories & (int)rule.FileSystemRights) == (int)FileSystemRights.CreateDirectories)
                        CreateDirectoriesIsDeny = true;
                    if (((int)FileSystemRights.CreateFiles & (int)rule.FileSystemRights) == (int)FileSystemRights.CreateFiles)
                        CreateFilesIsDeny = true;
                    if (((int)FileSystemRights.Delete & (int)rule.FileSystemRights) == (int)FileSystemRights.Delete)
                        DeleteIsDeny = true;
                    if (((int)FileSystemRights.DeleteSubdirectoriesAndFiles & (int)rule.FileSystemRights) == (int)FileSystemRights.DeleteSubdirectoriesAndFiles)
                        DeleteSubdirectoriesAndFilesIsDeny = true;
                    if (((int)FileSystemRights.ListDirectory & (int)rule.FileSystemRights) == (int)FileSystemRights.ListDirectory)
                        ListDirectoryIsDeny = true;
                    if (((int)FileSystemRights.Modify & (int)rule.FileSystemRights) == (int)FileSystemRights.Modify)
                        ModifyIsDeny = true;
                    if (((int)FileSystemRights.ReadAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadAttributes)
                        ReadAttributesIsDeny = true;
                    if (((int)FileSystemRights.ReadExtendedAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadExtendedAttributes)
                        ReadExtendedAttributesIsDeny = true;
                    if (((int)FileSystemRights.ReadPermissions & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadPermissions)
                        ReadPermissionsIsDeny = true;
                    if (((int)FileSystemRights.TakeOwnership & (int)rule.FileSystemRights) == (int)FileSystemRights.TakeOwnership)
                        TakeOwnershipIsDeny = true;
                    if (((int)FileSystemRights.Traverse & (int)rule.FileSystemRights) == (int)FileSystemRights.Traverse)
                        TraverseIsDeny = true;
                    if (((int)FileSystemRights.WriteAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.WriteAttributes)
                        WriteAttributesIsDeny = true;
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
                    if (((int)FileSystemRights.ChangePermissions & (int)rule.FileSystemRights) == (int)FileSystemRights.ChangePermissions)
                        ChangePermissionsIsAllow = true;
                    if (((int)FileSystemRights.CreateDirectories & (int)rule.FileSystemRights) == (int)FileSystemRights.CreateDirectories)
                        CreateDirectoriesIsAllow = true;
                    if (((int)FileSystemRights.CreateFiles & (int)rule.FileSystemRights) == (int)FileSystemRights.CreateFiles)
                        CreateFilesIsAllow = true;
                    if (((int)FileSystemRights.Delete & (int)rule.FileSystemRights) == (int)FileSystemRights.Delete)
                        DeleteIsAllow = true;
                    if (((int)FileSystemRights.DeleteSubdirectoriesAndFiles & (int)rule.FileSystemRights) == (int)FileSystemRights.DeleteSubdirectoriesAndFiles)
                        DeleteSubdirectoriesAndFilesIsAllow = true;
                    if (((int)FileSystemRights.ListDirectory & (int)rule.FileSystemRights) == (int)FileSystemRights.ListDirectory)
                        ListDirectoryIsAllow = true;
                    if (((int)FileSystemRights.Modify & (int)rule.FileSystemRights) == (int)FileSystemRights.Modify)
                        ModifyIsAllow = true;
                    if (((int)FileSystemRights.ReadAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadAttributes)
                        ReadAttributesIsAllow = true;
                    if (((int)FileSystemRights.ReadExtendedAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadExtendedAttributes)
                        ReadExtendedAttributesIsAllow = true;
                    if (((int)FileSystemRights.ReadPermissions & (int)rule.FileSystemRights) == (int)FileSystemRights.ReadPermissions)
                        ReadPermissionsIsAllow = true;
                    if (((int)FileSystemRights.TakeOwnership & (int)rule.FileSystemRights) == (int)FileSystemRights.TakeOwnership)
                        TakeOwnershipIsAllow = true;
                    if (((int)FileSystemRights.Traverse & (int)rule.FileSystemRights) == (int)FileSystemRights.Traverse)
                        TraverseIsAllow = true;
                    if (((int)FileSystemRights.WriteAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.WriteAttributes)
                        WriteAttributesIsAllow = true;
                    if (((int)FileSystemRights.WriteExtendedAttributes & (int)rule.FileSystemRights) == (int)FileSystemRights.WriteExtendedAttributes)
                        WriteExtendedAttributesIsAllow = true;
                }
            }

            FullControl = !FullControlIsDeny && FullControlIsAllow;
            Read = !ReadIsDeny && ReadIsAllow;
            Write = !WriteIsDeny && WriteIsAllow;
            ChangePermissions = !ChangePermissionsIsDeny && ChangePermissionsIsAllow;
            CreateDirectories = !CreateDirectoriesIsDeny && CreateDirectoriesIsAllow;
            CreateFiles = !CreateFilesIsDeny && CreateFilesIsAllow;
            Delete = !DeleteIsDeny && DeleteIsAllow;
            DeleteSubdirectoriesAndFiles = !DeleteSubdirectoriesAndFilesIsDeny && DeleteSubdirectoriesAndFilesIsAllow;
            ListDirectory = !ListDirectoryIsDeny && ListDirectoryIsAllow;
            Modify = !ModifyIsDeny && ModifyIsAllow;
            ReadAttributes = !ReadAttributesIsDeny && ReadAttributesIsAllow;
            ReadExtendedAttributes = !ReadExtendedAttributesIsDeny && ReadExtendedAttributesIsAllow;
            ReadPermissions = !ReadPermissionsIsDeny && ReadPermissionsIsAllow;
            TakeOwnership = !TakeOwnershipIsDeny && TakeOwnershipIsAllow;
            Traverse = !TraverseIsDeny && TraverseIsAllow;
            WriteAttributes = !WriteAttributesIsDeny && WriteAttributesIsAllow;
            WriteExtendedAttributes = !WriteExtendedAttributesIsDeny && WriteExtendedAttributesIsAllow;
        }

        public void SetDirectoryPermissions(string Path, bool FullControl, bool Read, bool Write, bool ChangePermissions, bool CreateDirectories, bool CreateFiles, bool Delete, bool DeleteSubdirectoriesAndFiles, bool ListDirectory, bool Modify, bool ReadAttributes, bool ReadExtendedAttributes, bool ReadPermissions, bool TakeOwnership, bool Traverse, bool WriteAttributes, bool WriteExtendedAttributes)
        {
            DirectoryInfo info = new DirectoryInfo(Path);
            DirectorySecurity security = info.GetAccessControl();

            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Read, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Write, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ChangePermissions, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.CreateDirectories, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.CreateFiles, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Delete, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.DeleteSubdirectoriesAndFiles, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ListDirectory, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Modify, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadAttributes, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadExtendedAttributes, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadPermissions, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.TakeOwnership, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Traverse, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.WriteAttributes, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));
            security.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.WriteExtendedAttributes, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Deny));

            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (FullControl) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Read, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (Read) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Write, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (Write) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ChangePermissions, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (ChangePermissions) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.CreateDirectories, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (CreateDirectories) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.CreateFiles, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (CreateFiles) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Delete, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (Delete) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.DeleteSubdirectoriesAndFiles, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (DeleteSubdirectoriesAndFiles) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ListDirectory, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (ListDirectory) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Modify, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (Modify) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadAttributes, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (ReadAttributes) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadExtendedAttributes, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (ReadExtendedAttributes) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.ReadPermissions, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (ReadPermissions) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.TakeOwnership, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (TakeOwnership) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.Traverse, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (Traverse) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.WriteAttributes, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (WriteAttributes) ? AccessControlType.Allow : AccessControlType.Deny));
            security.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.WriteExtendedAttributes, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, (WriteExtendedAttributes) ? AccessControlType.Allow : AccessControlType.Deny));

            info.SetAccessControl(security);
        }
    }
}