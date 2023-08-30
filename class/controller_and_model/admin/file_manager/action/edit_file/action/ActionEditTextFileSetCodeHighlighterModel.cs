using CodeBehind;

namespace Elanat
{
    public partial class ActionEditTextFileSetCodeHighlighterModel : CodeBehindModel
    {
        public string TextFilePathValue { get; set; }

        public void SetValue()
        {
            //  Data Stream Path Access
            Security sc = new Security();
            sc.DataStreamPathAccess(TextFilePathValue);

            SetConfigurationText();
        }

        public void SetConfigurationText()
        {
            string[] Lines = File.ReadAllLines(StaticObject.ServerMapPath(TextFilePathValue));
            string TextFileValue = "";

            int LinesLength = Lines.Length;
            foreach (string line in Lines)
            {
                TextFileValue += line;
                if (LinesLength != 1)
                    TextFileValue += Environment.NewLine;

                LinesLength--;
            }

            Write(TextFileValue);
        }
    }
}