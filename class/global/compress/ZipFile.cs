using System.IO.Compression;

namespace Elanat
{
    public class ZipFileClass
    {
        public void CreateZip(string FileDirectoryPath, string ZipPath)
        {
            string ZipPathPhysicalName = Path.GetFileName(ZipPath);
            string ZipPathDirectoryPath = Path.GetDirectoryName(ZipPath);

            ZipPathPhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(ZipPathPhysicalName, ZipPathDirectoryPath);

            ZipFile.CreateFromDirectory(FileDirectoryPath, ZipPathDirectoryPath + "/" + ZipPathPhysicalName, CompressionLevel.Optimal, false, System.Text.Encoding.UTF8);
        }

        public void CreateZip(string[] FileDirectoryPath, string ZipPath)
        {
            string DestinationPath = "zip_file";
            DestinationPath = FileAndDirectory.GetNewDirectoryNameIfDirectoryExist(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/"), DestinationPath);

            Directory.CreateDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DestinationPath + "/"));

            foreach (string fdp in FileDirectoryPath)
            {
                string DirectoryName = (Directory.Exists(fdp)) ? new DirectoryInfo(fdp).Name : "";

                if (Directory.Exists(fdp))
                    FileAndDirectory.DirectoryCopy(fdp, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DestinationPath + "/" + DirectoryName + "/"), true, true);
                else if (File.Exists(fdp))
                    File.Copy(fdp, StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DestinationPath + "/" + Path.GetFileName(fdp)), true);
            }

            string ZipPathPhysicalName = Path.GetFileName(ZipPath);
            string ZipPathDirectoryPath = Path.GetDirectoryName(ZipPath);

            ZipPathPhysicalName = FileAndDirectory.GetNewFileNameIfFileNameExist(ZipPathDirectoryPath, ZipPathPhysicalName);

            ZipFile.CreateFromDirectory(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DestinationPath + "/"), ZipPathDirectoryPath + "/" + ZipPathPhysicalName, CompressionLevel.Optimal, false, System.Text.Encoding.UTF8);

            Directory.Delete(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/tmp/" + DestinationPath + "/"), true);
        }

        public void UnZip(string ZipPath, string UnZipPath, bool UseOverwriteExtractExistingFile = false)
        {
            ZipFile.ExtractToDirectory(ZipPath, UnZipPath, UseOverwriteExtractExistingFile);
        }
    }
}