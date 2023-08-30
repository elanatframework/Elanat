using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Elanat
{
    public class HashData
    {
        char CollisionSeparator = '&';

        public int InsertRow(string RowName)
        {
            // Set Default 0 To Insert Collision Index
            InsertCollisionIndex = 0;

            // Get Table Attribute Key From catalog.xml File
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "database/" + DataBaseName + "/" + TableName + "/catalog.xml"));
            string TableAttributeKey = CatalogDocument.SelectSingleNode("/attribute_list_root/attribute").Attributes["key"].Value;

            // Open And Read name.txt File
            var Lines = File.ReadAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "database/" + DataBaseName + "/" + TableName + "/" + TableAttributeKey + ".ini"));

            // Create Hash Code From Name Value
            string HashCode = GetFirst4CharacterFromMd5Hash2(RowName);

            // Get Decimal Line Number From Hash Code
            int Line = int.Parse(HashCode, System.Globalization.NumberStyles.HexNumber);

            // If Collision Occurred
            InsertIsCollision = !string.IsNullOrEmpty(Lines[Line]);

            if (InsertIsCollision)
            {
                string TmpLine = Lines[Line];
                TmpLine = TmpLine.Remove(5, 1);
                TmpLine = TmpLine.Insert(5, "+");
                TmpLine += CollisionSeparator + RowName;

                Lines[Line] = TmpLine;

                InsertCollisionIndex = GetCollisionIndexCount(TmpLine);
            }
            else
                Lines[Line] = HashCode + "= " + RowName;

            // Save name.txt File
            File.WriteAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "database/" + DataBaseName + "/" + TableName + "/" + TableAttributeKey + ".ini"), Lines);

            return Line;
        }
        public bool InsertIsCollision { get; private set; }
        public int InsertCollisionIndex { get; private set; }
        public string DataBaseName { get; set; }
        public string TableName { get; set; }

        public int FindRow(string RowName)
        {
            // Set Default 0 To Find Collision Index
            FindCollisionIndex = 0;

            // Get Table Attribute Key From catalog.xml File
            XmlDocument CatalogDocument = new XmlDocument();
            CatalogDocument.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "database/" + DataBaseName + "/" + TableName + "/catalog.xml"));
            string TableAttributeKey = CatalogDocument.SelectSingleNode("/attribute_list_root/attribute").Attributes["key"].Value;

            // Open And Read name.txt File
            var Lines = File.ReadAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "database/" + DataBaseName + "/" + TableName + "/" + TableAttributeKey + ".ini"));

            // Create Hash Code From Name Value
            string HashCode = GetFirst4CharacterFromMd5Hash2(RowName);

            // Get Decimal Line Number From Hash Code
            int Line = int.Parse(HashCode, System.Globalization.NumberStyles.HexNumber);

            // If Line Is Empty Return -1
            if (string.IsNullOrEmpty(Lines[Line]))
                return -1;

            // If Collision Occurred
            FindIsCollision = Lines[Line].Substring(5, 1) == "+";

            if (FindIsCollision)
            {
                string TmpLine = Lines[Line].Remove(0, 6);

                char[] DelimiterChars = { CollisionSeparator };
                string[] NameList = TmpLine.Split(DelimiterChars);

                foreach (string Text in NameList)
                {
                    if (Text == RowName)
                        return Line;

                    FindCollisionIndex++;
                }

                // If Name Isn't Exist
                return -1;
            }
            else
                return (Lines[Line].Remove(0, 6) == RowName) ? Line : -1;
        }
        public bool FindIsCollision { get; private set; }
        public int FindCollisionIndex { get; private set; }

        public int GetCollisionIndexCount(string Text)
        {
            Text = Text.Remove(0, 6);

            int i = 0;

            foreach (char c in Text)
                if (c == CollisionSeparator)
                    i++;

            return i;
        }

        public string SelectRowValue(string DataBaseName, string TableName, string Attribute, int LineNumber, int CollisionIndex = 0)
        {
            // Open And Read attribute_name.ini File
            var Lines = File.ReadAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "database/" + DataBaseName + "/" + TableName + "/" + Attribute + ".ini"));

            if (string.IsNullOrEmpty(Lines[LineNumber]))
                return null;

            string TmpLine = Lines[LineNumber].Remove(0, 6);

            char[] DelimiterChars = { CollisionSeparator };
            string[] NameList = TmpLine.Split(DelimiterChars);

            return NameList[CollisionIndex];
        }

        public void InsertRowValue(string DataBaseName, string TableName, string Attribute, string value, int LineNumber)
        {
            // Open And Read attribute_name.ini File
            var Lines = File.ReadAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "database/" + DataBaseName + "/" + TableName + "/" + Attribute + ".ini"));

            if (string.IsNullOrEmpty(Lines[LineNumber]))
                Lines[LineNumber] = LineNumber.ToString("X") + "= " + value;
            else
            {
                Lines[LineNumber] = Lines[LineNumber].Remove(5, 1).Insert(5, "+");

                Lines[LineNumber] += CollisionSeparator + value;
            }

            File.WriteAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "database/" + DataBaseName + "/" + TableName + "/" + Attribute + ".ini"), Lines);
        }

        public void DeleteRowValue(string DataBaseName, string TableName, string Attribute, int LineNumber, int CollisionIndex = 0)
        {
            // Open And Read attribute_name.ini File
            var Lines = File.ReadAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "database/" + DataBaseName + "/" + TableName + "/" + Attribute + ".ini"));

            if (LineNumber < 0)
                return;

            if (string.IsNullOrEmpty(Lines[LineNumber]))
                return;

            string TmpLine = Lines[LineNumber].Remove(0, 6);
            string IniHashValue = Lines[LineNumber].Substring(0, 6);

            char[] DelimiterChars = { CollisionSeparator };
            string[] NameList = TmpLine.Split(DelimiterChars);

            NameList[CollisionIndex] = null;
            string NameListSlice = "";

            if (NameList.Length > 2)
            {
                foreach (string text in NameList)
                    NameListSlice += text + CollisionSeparator;

                Lines[LineNumber] = IniHashValue + NameListSlice;
            }

            if (NameList.Length == 2)
            {
                Lines[LineNumber] = IniHashValue.Remove(5, 1) + " " + NameListSlice;
            }

            if (NameList.Length < 2)
            {
                Lines[LineNumber] = "";
            }


            else
                Lines[LineNumber] = IniHashValue.Remove(5, 1) + " " + NameListSlice;

            File.WriteAllLines(StaticObject.ServerMapPath(StaticObject.SitePath + "database/" + DataBaseName + "/" + TableName + "/" + Attribute + ".ini"), Lines);
        }

        public string GetFirst4CharacterFromMd5Hash2(string Text)
        {
            // This Method Return Range 0000 to FFFF

            // Get Md5 Hash From Input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] TextBytes = System.Text.Encoding.ASCII.GetBytes(Text);
            byte[] hash = md5.ComputeHash(TextBytes);

            // Convert First 4 Character Byte Array To Hex String
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 2; i++)
                sb.Append(hash[i].ToString("X2"));

            return sb.ToString();
        }
    }
}