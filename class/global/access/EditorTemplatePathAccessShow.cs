namespace Elanat
{
    public class EditorTemplatePathAccessShow
    {
        public string CurrentEditorTemplateId { get; private set; }

        public string GetEditorTemplateIdByEditorTemplateDirectoryPath(string EditorTemplateDirectoryPath)
        {
            DataUse.EditorTemplate duc = new DataUse.EditorTemplate();
            string EditorTemplateId = duc.GetEditorTemplateIdByEditorTemplateDirectoryPath(EditorTemplateDirectoryPath);

            return EditorTemplateId;
        }

        public string GetEditorTemplateDirectoryPathFromPath(string Path)
        {
            FileAndDirectory fad = new FileAndDirectory();

            string EditorTemplateDirectoryPath = "";
            EditorTemplateDirectoryPath = fad.GetCleanDirectoryPathFromPath(Path);

            string[] EditorTemplateDirectoryPathArray = EditorTemplateDirectoryPath.Split('/');

            int EditorTemplateDirectoryPathArrayLength = EditorTemplateDirectoryPathArray.Length;

            for (int i = 0; i < EditorTemplateDirectoryPathArrayLength; i++)
            {
                EditorTemplateDirectoryPath = string.Join("/", EditorTemplateDirectoryPathArray);

                if (File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/editor_template/" + string.Join("/", EditorTemplateDirectoryPathArray) + "/catalog.xml")))
                    return EditorTemplateDirectoryPath;

                // Delete Last Item From Array
                EditorTemplateDirectoryPathArray = EditorTemplateDirectoryPathArray.Take(EditorTemplateDirectoryPathArray.Count() - 1).ToArray();
            }

            return "";
        }

        public bool PathAccessToEditorTemplate(string Path)
        {
            string EditorTemplateDirectoryPath = GetEditorTemplateDirectoryPathFromPath(Path);

            if (string.IsNullOrEmpty(EditorTemplateDirectoryPath))
                return false;

            string EditorTemplateId = GetEditorTemplateIdByEditorTemplateDirectoryPath(EditorTemplateDirectoryPath);

            CurrentEditorTemplateId = EditorTemplateId;

            if (string.IsNullOrEmpty(EditorTemplateId))
                return false;

            DataUse.EditorTemplate duet = new DataUse.EditorTemplate();

            return duet.GetEditorTemplateAccessShowCheck(EditorTemplateId);
        }
    }
}