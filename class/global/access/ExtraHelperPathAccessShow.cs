namespace Elanat
{
    public class ExtraHelperPathAccessShow
    {
        public string CurrentExtraHelperId { get; private set; }

        public string GetExtraHelperIdByExtraHelperDirectoryPath(string ExtraHelperDirectoryPath)
        {
            DataUse.ExtraHelper duc = new DataUse.ExtraHelper();
            string ExtraHelperId = duc.GetExtraHelperIdByExtraHelperDirectoryPath(ExtraHelperDirectoryPath);

            return ExtraHelperId;
        }

        public string GetExtraHelperDirectoryPathFromPath(string Path)
        {
            FileAndDirectory fad = new FileAndDirectory();

            string ExtraHelperDirectoryPath = fad.GetCleanDirectoryPathFromPath(Path);

            string[] ExtraHelperDirectoryPathArray = ExtraHelperDirectoryPath.Split('/');

            int ExtraHelperDirectoryPathArrayLength = ExtraHelperDirectoryPathArray.Length;

            for (int i = 0; i < ExtraHelperDirectoryPathArrayLength; i++)
            {
                ExtraHelperDirectoryPath = string.Join("/", ExtraHelperDirectoryPathArray);

                if (File.Exists(StaticObject.ServerMapPath(StaticObject.SitePath + "add_on/extra_helper/" + string.Join("/", ExtraHelperDirectoryPathArray) + "/catalog.xml")))
                    return ExtraHelperDirectoryPath;

                // Delete Last Item From Array
                ExtraHelperDirectoryPathArray = ExtraHelperDirectoryPathArray.Take(ExtraHelperDirectoryPathArray.Count() - 1).ToArray();
            }

            return "";
        }

        public bool PathAccessToExtraHelper(string Path)
        {
            string ExtraHelperDirectoryPath = GetExtraHelperDirectoryPathFromPath(Path);
            
            if (string.IsNullOrEmpty(ExtraHelperDirectoryPath))
                return false;

            string ExtraHelperId = GetExtraHelperIdByExtraHelperDirectoryPath(ExtraHelperDirectoryPath);

            CurrentExtraHelperId = ExtraHelperId;

            if (string.IsNullOrEmpty(ExtraHelperId))
                return false;

            DataUse.ExtraHelper dueh = new DataUse.ExtraHelper();

            return dueh.GetExtraHelperAccessShowCheck(ExtraHelperId);
        }
    }
}