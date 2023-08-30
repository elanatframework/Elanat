using Microsoft.Extensions.Primitives;
using static System.Net.Mime.MediaTypeNames;

namespace Elanat
{
    public class ListItem
    {
        public ListItem()
        {
        
        } 
        
        public ListItem(string Text, string Value)
        {
            this.Text = Text;
            this.Value = Value;
        }
        
        public ListItem(string Text, string Value, bool Selected)
        {
            this.Text = Text;
            this.Value = Value;
            this.Selected = Selected;
        }
        public string Text { get; set; }
        public string Value { get; set; }
        public bool Selected = false;
    }
}
