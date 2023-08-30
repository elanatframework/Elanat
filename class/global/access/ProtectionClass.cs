using System.Text.RegularExpressions;
using System.Xml;

namespace Elanat
{
	public class ProtectionClass
    {
        public bool IsProtected(string ColumnKeyValue, string Path = "")
        {
            if (!File.Exists(StaticObject.ServerMapPath(Path + "App_Data/protection_list/protection.xml")))
                return false;


            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(Path + "App_Data/protection_list/protection.xml"));

            XmlNodeList NodeList = doc.SelectNodes("protection_root/protection_list/protection");
            XmlNode ProtectedAttribute = doc.SelectSingleNode("protection_root/protection_list");

            string TableName = ProtectedAttribute.Attributes["table_name"].Value;
            string ColumnKeyName = ProtectedAttribute.Attributes["column_key_name"].Value;


            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_row_by_key_value", new List<string>() { "@table_name", "@column_key_name", "@column_key_value" }, new List<string>() { TableName, ColumnKeyName, ColumnKeyValue });

            if (!dbdr.dr.HasRows)
            {
                db.Close();
                return false;
            }

            dbdr.dr.Read();


            string ColumnName = "";
            string ColumnValue = "";

            foreach (XmlNode node in NodeList)
            {
                ColumnName = node.Attributes["column_name"].Value;
                ColumnValue = node.Attributes["column_value"].Value;

                if (dbdr.dr[ColumnName].ToString() == ColumnValue)
                {
                    db.Close();
                    return true;
                }
            }

            db.Close();
            return false;
        }

        public bool PathIsProtected(string FileAndDirectoryPath, string Path = "")
        {
            if (!File.Exists(StaticObject.ServerMapPath(Path + "App_Data/protection_list/protection.xml")))
                return false;


            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(Path + "App_Data/protection_list/protection.xml"));

            XmlNodeList NodeList = doc.SelectNodes("protection_root/protection_list/protection");
            XmlNode ProtectedAttribute = doc.SelectSingleNode("protection_root/protection_list");

            string ProtectionType = "";
            string ProtectionPath = "";

            foreach (XmlNode node in NodeList)
            {
                ProtectionType = node.Attributes["match_type"].Value;
                ProtectionPath = node.Attributes["path"].Value;

                switch (ProtectionType)
                {
                    case "exist":
                        {
                            if (FileAndDirectoryPath.Contains(ProtectionPath))
                                return true;
                        }
                        break;

                    case "start_by":
                        {
                            if (FileAndDirectoryPath.TextStartMathByValueCheck(ProtectionPath))
                                return true;
                        }
                        break;

                    case "end_by":
                        {
                            if (FileAndDirectoryPath.TextEndMathByValueCheck(ProtectionPath))
                                return true;
                        }
                        break;

                    case "regex":
                        {
                            Regex re = new Regex(ProtectionPath, RegexOptions.IgnoreCase);

                            if (re.IsMatch(FileAndDirectoryPath))
                                return true;
                        }
                        break;
                }
            }

            return false;
        }
    }
}