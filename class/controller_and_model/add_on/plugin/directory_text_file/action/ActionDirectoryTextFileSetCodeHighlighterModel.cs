using CodeBehind;

namespace Elanat
{
    public partial class ActionDirectoryTextFileSetCodeHighlighterModel : CodeBehindModel
    {
        public string TextFilePathValue { get; set; }

        public void SetValue()
        {
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