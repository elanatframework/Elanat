using System.Text;

namespace Elanat
{
	public class StringClass
	{
        public static string UpperFirstCharacter(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return Text;

            return Text.First().ToString().ToUpper() + Text.Substring(1);
        }

        public static string RemoveHtmlTags(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return Text;

            return System.Text.RegularExpressions.Regex.Replace(RemoveLegalCharacters(Text), @"<[^>]*>", String.Empty);
        }

        public static string RemoveScriptTags(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return Text;

            return System.Text.RegularExpressions.Regex.Replace(Text, @"<script[^>]*>[\s\S]*?</script>", String.Empty);
        }

        public string StringReverse(string Text)
        {
            char[] charArray = Text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string RemoveLegalCharacters(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return Text;

            Text = Text.Replace("&amp;", "&");
            Text = Text.Replace("&quot;", "\"");
            Text = Text.Replace("&apos;", "'");
            Text = Text.Replace("&lt;", "<");
            Text = Text.Replace("&gt;", ">");

            return Text;
        }

        public static string RemoveIllegalCharacters(string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return Text;

            Text = Text.Replace("&", "&amp;");
            Text = Text.Replace("\"", "&quot;");
            Text = Text.Replace("'", "&apos;");
            Text = Text.Replace("<", "&lt;");
            Text = Text.Replace(">", "&gt;");

            return Text;
        }

        public static int GetNumberOfStringFromText(string Text, string Str)
        {
            int TextLenghtBefore = Text.Length;
            int StrLenght = Str.Length;
            Text = Text.Replace(Str, null);
            int TextLenghtAfter = Text.Length;
            return (TextLenghtBefore - TextLenghtAfter) / StrLenght;
        }

        public static int GetNumberOfCharInString(string str, string chr)
        {
            int i = 0;
            int j = 0;
            int k =
            chr.Length;
            while (i < str.Length)
            {
                if (str.Substring(i, k) == chr)
                    j++;
                i++;
            }
            return j;
        }

        public static List<string> ExtractFromString(string Text, string Between)
        {
            // example: between = "," text = a,b,c → list[0] = a - list[1] = b - list[2] = c
            List<string> Matched = new List<string>();
            Text += Between;
            int i = 0, j = Text.Length;//more than 1 character
            string s = null, newtext = null;
            while (i < j)
            {
                s = Text.Substring(i, 1);
                if (s != Between)
                    newtext += s;
                else
                {
                    Matched.Add(newtext);
                    newtext = null;
                }
                i++;
            }
            return Matched;
        }

        public static string ExtractFromList(List<string> List, string Between)
        {
            string ExtractText = "";
            foreach (string Text in List)
                ExtractText = Text + Between;
            return ExtractText;
        }

        public static string PersianNumberFont(string EnFont)
        {
            return EnFont.Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹").Replace("0", "۰");
        }

        public string GetCleanRandomText(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random rand = new Random();
            char ch;
            int StartAsciiCode = 65;
            for (int i = 0; i < size; i++)
            {
                StartAsciiCode = (rand.Next(0, 2) == 1) ? 65 : 97;

                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rand.NextDouble() + StartAsciiCode)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public long ConvertIpToNumber(string Ip)
        {
            string TmpIp = Ip;
            TmpIp = TmpIp.Replace(".", "");

            return int.Parse(TmpIp);
        }

        public bool IsUlString(string text)
        {
            if(string.IsNullOrEmpty(text))
                return true;

            if (text.Contains(' '))
                return false;

            if (text.Contains(@"\"))
                return false;

            if (text.Contains("/"))
                return false;

            if (text.Contains(":"))
                return false;

            if (text.Contains("*"))
                return false;

            if (text.Contains("?"))
                return false;

            if (text.Contains("\""))
                return false;

            if (text.Contains("<"))
                return false;

            if (text.Contains(">"))
                return false;

            if (text.Contains("|"))
                return false;

            if (text[0].ToString().IsNumber())
                return false;

            return true;
        }

        public string GetPathParameterValue(string PathValue, string ParameterName)
        {
            if (string.IsNullOrEmpty(PathValue))
                return "";

            if (string.IsNullOrEmpty(ParameterName))
                return "";

            if (PathValue[0] == '?')
                PathValue.Remove(0, 1);

            string[] PathValueArray = PathValue.Split('&');

            foreach (string Parameter in PathValueArray)
            {
                if (ParameterName == Parameter.GetTextBeforeValue("="))
                    return Parameter.GetTextAfterValue("=");
            }

            return "";
        }
    }
}