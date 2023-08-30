using System.Xml;

namespace Elanat.ListClass
{
    public class Link
    {
        // Get Link Target List Item
        public List<ListItem> LinkTargetListItem = new List<ListItem>();
        public void FillLinkTargetListItem(string GlobalLanguage)
        {
            LinkTargetListItem.Add(Language.GetLanguage("blank", GlobalLanguage), "_blank");
            LinkTargetListItem.Add(Language.GetLanguage("parent", GlobalLanguage), "parent");
            LinkTargetListItem.Add(Language.GetLanguage("self", GlobalLanguage), "self");
            LinkTargetListItem.Add(Language.GetLanguage("_top", GlobalLanguage), "_top");
        }

        // Get Link Protocol List Item
        public List<ListItem> LinkProtocolListItem = new List<ListItem>();
        public void FillLinkProtocolListItem()
        {
            List<string> LinkProtocolList = GetLinkProtocolList();

            foreach (string Protocol in LinkProtocolList)
                LinkProtocolListItem.Add(Protocol, Protocol);
        }
        public static List<string> GetLinkProtocolList()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "App_Data/link_protocol/link_protocol.xml"));
            XmlNodeList NodeList = doc.SelectNodes("link_protocol_root/link_protocol_list/protocol");
            List<string> list = new List<string>();
            foreach (XmlNode node in NodeList)
                list.Add(node.InnerText);

            return list;
        }

        // Get Link Menu List Item
        public List<ListItem> LinkMenuListItem = new List<ListItem>();
        public void FillLinkMenuListItem(string LinkId)
        {
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
            dbdr.dr = db.GetProcedure("get_link_menu", "@link_id", LinkId);

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    ListItem TmpListItem = new ListItem();
                    TmpListItem.Text = dbdr.dr["link_id"].ToString();
                    TmpListItem.Value = dbdr.dr["menu_id"].ToString();
                    TmpListItem.Selected = true;

                    LinkMenuListItem.Add(TmpListItem);
                }

            db.Close();
        }
    }
}