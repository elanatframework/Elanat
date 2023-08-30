namespace Elanat
{
    public class PageValueTransfer
    {
        public void Delete()
        {
            StaticObject.SetSession("el_value_transfer:head", null);
            StaticObject.SetSession("el_value_transfer:load_tag", null);
        }

        // Head
        public string Head
        {
            get { return (!string.IsNullOrEmpty(StaticObject.GetSession("el_value_transfer:head"))) ? StaticObject.GetSession("el_value_transfer:head") : null; }
            set { StaticObject.SetSession("el_value_transfer:head", value); }
        }

        // Load Tag
        public string LoadTag
        {
            get { return (!string.IsNullOrEmpty(StaticObject.GetSession("el_value_transfer:load_tag"))) ? StaticObject.GetSession("el_value_transfer:load_tag") : null; }
            set { StaticObject.SetSession("el_value_transfer:load_tag", value); }
        }
    }
}