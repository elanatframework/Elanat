using System.Xml;

namespace Elanat
{
    public class ClientVariantClass
    {
        public string GetSiteViewStyle(string SiteStyleId, string ViewId)
        {
            string ViewStyleBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_view_style/box").InnerText;
            string ViewStyleInternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_view_style/internal_box").InnerText;
            string ViewStyleExternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_view_style/external_box").InnerText;

            if (StaticObject.CreateExternalLinkForSiteViewStyle)
            {
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp site_path;", StaticObject.SitePath);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp site_style_id;", SiteStyleId);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp view_id;", ViewId);

                return ViewStyleExternalBoxStruct;
            }
            else
                return ViewStyleInternalBoxStruct.Replace("$_asp item;", GetSiteViewStyleWithBox(SiteStyleId, ViewId));
        }

        public string GetSiteViewStyleWithBox(string SiteStyleId, string ViewId)
        {
            string ViewStyleBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_view_style/box").InnerText;
            string ViewStyleListItemStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_view_style/list_item").InnerText;
            string TmpViewStyleListItemStruct = "";
            string SumViewStyleListItemStruct = "";

            DataUse.SiteStyle duss = new DataUse.SiteStyle();
            string StyleDirectoryPath = duss.GetStyleDirectoryPath(SiteStyleId);

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/site/" + StyleDirectoryPath + "/catalog.xml"));

            XmlNode node = doc.SelectSingleNode("site_style_catalog_root/site_view_style");
            string VariantValue = "";

            // Get View
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_view", "@view_id", ViewId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            string FontSize = (dbdr.dr["view_font_size"].ToString() == "99") ? "unset" : dbdr.dr["view_font_size"].ToString();
            string BackgroundColor = (dbdr.dr["view_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_background_color"].ToString();
            string CommonLightBackgroundColor = (dbdr.dr["view_common_light_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_common_light_background_color"].ToString();
            string CommonLightTextColor = (dbdr.dr["view_common_light_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_common_light_text_color"].ToString();
            string CommonMiddleBackgroundColor = (dbdr.dr["view_common_middle_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_common_middle_background_color"].ToString();
            string CommonMiddleTextColor = (dbdr.dr["view_common_middle_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_common_middle_text_color"].ToString();
            string CommonDarkBackgroundColor = (dbdr.dr["view_common_dark_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_common_dark_background_color"].ToString();
            string CommonDarkTextColor = (dbdr.dr["view_common_dark_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_common_dark_text_color"].ToString();
            string NaturalLightBackgroundColor = (dbdr.dr["view_natural_light_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_natural_light_background_color"].ToString();
            string NaturalLightTextColor = (dbdr.dr["view_natural_light_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_natural_light_text_color"].ToString();
            string NaturalMiddleBackgroundColor = (dbdr.dr["view_natural_middle_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_natural_middle_background_color"].ToString();
            string NaturalMiddleTextColor = (dbdr.dr["view_natural_middle_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_natural_middle_text_color"].ToString();
            string NaturalDarkBackgroundColor = (dbdr.dr["view_natural_dark_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_natural_dark_background_color"].ToString();
            string NaturalDarkTextColor = (dbdr.dr["view_natural_dark_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_natural_dark_text_color"].ToString();

            db.Close();

            // Set Background Color
            if (!string.IsNullOrEmpty(node["background_color"].InnerText))
            {
                VariantValue = node["background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", BackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Font Size
            if (!string.IsNullOrEmpty(node["font_size"].InnerText))
            {
                VariantValue = node["font_size"].InnerText;
                VariantValue = VariantValue.Replace("$_asp font_size;", FontSize);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Light Background Color
            if (!string.IsNullOrEmpty(node["common_light_background_color"].InnerText))
            {
                VariantValue = node["common_light_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", CommonLightBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Light Text Color
            if (!string.IsNullOrEmpty(node["common_light_text_color"].InnerText))
            {
                VariantValue = node["common_light_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", CommonLightTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Middle Background Color
            if (!string.IsNullOrEmpty(node["common_middle_background_color"].InnerText))
            {
                VariantValue = node["common_middle_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", CommonMiddleBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Middle Text Color
            if (!string.IsNullOrEmpty(node["common_middle_text_color"].InnerText))
            {
                VariantValue = node["common_middle_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", CommonMiddleTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Dark Background Color
            if (!string.IsNullOrEmpty(node["common_dark_background_color"].InnerText))
            {
                VariantValue = node["common_dark_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", CommonDarkBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Dark Text Color
            if (!string.IsNullOrEmpty(node["common_dark_text_color"].InnerText))
            {
                VariantValue = node["common_dark_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", CommonDarkTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Light Background Color
            if (!string.IsNullOrEmpty(node["natural_light_background_color"].InnerText))
            {
                VariantValue = node["natural_light_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", NaturalLightBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Light Text Color
            if (!string.IsNullOrEmpty(node["natural_light_text_color"].InnerText))
            {
                VariantValue = node["natural_light_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", NaturalLightTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Middle Background Color
            if (!string.IsNullOrEmpty(node["natural_middle_background_color"].InnerText))
            {
                VariantValue = node["natural_middle_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", NaturalMiddleBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Middle Text Color
            if (!string.IsNullOrEmpty(node["natural_middle_text_color"].InnerText))
            {
                VariantValue = node["natural_middle_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", NaturalMiddleTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Dark Background Color
            if (!string.IsNullOrEmpty(node["natural_dark_background_color"].InnerText))
            {
                VariantValue = node["natural_dark_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", NaturalDarkBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Dark Text Color
            if (!string.IsNullOrEmpty(node["natural_dark_text_color"].InnerText))
            {
                VariantValue = node["natural_dark_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", NaturalDarkTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }


            return ViewStyleBoxStruct.Replace("$_asp item;", SumViewStyleListItemStruct);
        }

        public string GetAdminViewStyle(string AdminStyleId, string ViewId)
        {
            string ViewStyleBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_view_style/box").InnerText;
            string ViewStyleInternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_view_style/internal_box").InnerText;
            string ViewStyleExternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_view_style/external_box").InnerText;

            if (StaticObject.CreateExternalLinkForAdminViewStyle)
            {
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp site_path;", StaticObject.SitePath);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp admin_style_id;", AdminStyleId);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp view_id;", ViewId);

                return ViewStyleExternalBoxStruct;
            }
            else
                return ViewStyleInternalBoxStruct.Replace("$_asp item;", GetAdminViewStyleWithBox(AdminStyleId, ViewId));
        }

        public string GetAdminViewStyleWithBox(string AdminStyleId, string ViewId)
        {
            string ViewStyleBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_view_style/box").InnerText;
            string ViewStyleListItemStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_view_style/list_item").InnerText;
            string TmpViewStyleListItemStruct = "";
            string SumViewStyleListItemStruct = "";

            DataUse.AdminStyle duss = new DataUse.AdminStyle();
            string StyleDirectoryPath = duss.GetStyleDirectoryPath(AdminStyleId);

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/admin/" + StyleDirectoryPath + "/catalog.xml"));

            XmlNode node = doc.SelectSingleNode("admin_style_catalog_root/admin_view_style");
            string VariantValue = "";

            // Get View
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_current_view", "@view_id", ViewId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            string FontSize = (dbdr.dr["view_font_size"].ToString() == "99") ? "unset" : dbdr.dr["view_font_size"].ToString();
            string BackgroundColor = (dbdr.dr["view_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_background_color"].ToString();
            string CommonLightBackgroundColor = (dbdr.dr["view_common_light_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_common_light_background_color"].ToString();
            string CommonLightTextColor = (dbdr.dr["view_common_light_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_common_light_text_color"].ToString();
            string CommonMiddleBackgroundColor = (dbdr.dr["view_common_middle_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_common_middle_background_color"].ToString();
            string CommonMiddleTextColor = (dbdr.dr["view_common_middle_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_common_middle_text_color"].ToString();
            string CommonDarkBackgroundColor = (dbdr.dr["view_common_dark_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_common_dark_background_color"].ToString();
            string CommonDarkTextColor = (dbdr.dr["view_common_dark_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_common_dark_text_color"].ToString();
            string NaturalLightBackgroundColor = (dbdr.dr["view_natural_light_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_natural_light_background_color"].ToString();
            string NaturalLightTextColor = (dbdr.dr["view_natural_light_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_natural_light_text_color"].ToString();
            string NaturalMiddleBackgroundColor = (dbdr.dr["view_natural_middle_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_natural_middle_background_color"].ToString();
            string NaturalMiddleTextColor = (dbdr.dr["view_natural_middle_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_natural_middle_text_color"].ToString();
            string NaturalDarkBackgroundColor = (dbdr.dr["view_natural_dark_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_natural_dark_background_color"].ToString();
            string NaturalDarkTextColor = (dbdr.dr["view_natural_dark_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["view_natural_dark_text_color"].ToString();

            db.Close();

            // Set Background Color
            if (!string.IsNullOrEmpty(node["background_color"].InnerText))
            {
                VariantValue = node["background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", BackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Font Size
            if (!string.IsNullOrEmpty(node["font_size"].InnerText))
            {
                VariantValue = node["font_size"].InnerText;
                VariantValue = VariantValue.Replace("$_asp font_size;", FontSize);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Light Background Color
            if (!string.IsNullOrEmpty(node["common_light_background_color"].InnerText))
            {
                VariantValue = node["common_light_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", CommonLightBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Light Text Color
            if (!string.IsNullOrEmpty(node["common_light_text_color"].InnerText))
            {
                VariantValue = node["common_light_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", CommonLightTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Middle Background Color
            if (!string.IsNullOrEmpty(node["common_middle_background_color"].InnerText))
            {
                VariantValue = node["common_middle_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", CommonMiddleBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Middle Text Color
            if (!string.IsNullOrEmpty(node["common_middle_text_color"].InnerText))
            {
                VariantValue = node["common_middle_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", CommonMiddleTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Dark Background Color
            if (!string.IsNullOrEmpty(node["common_dark_background_color"].InnerText))
            {
                VariantValue = node["common_dark_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", CommonDarkBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Dark Text Color
            if (!string.IsNullOrEmpty(node["common_dark_text_color"].InnerText))
            {
                VariantValue = node["common_dark_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", CommonDarkTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Light Background Color
            if (!string.IsNullOrEmpty(node["natural_light_background_color"].InnerText))
            {
                VariantValue = node["natural_light_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", NaturalLightBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Light Text Color
            if (!string.IsNullOrEmpty(node["natural_light_text_color"].InnerText))
            {
                VariantValue = node["natural_light_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", NaturalLightTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Middle Background Color
            if (!string.IsNullOrEmpty(node["natural_middle_background_color"].InnerText))
            {
                VariantValue = node["natural_middle_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", NaturalMiddleBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Middle Text Color
            if (!string.IsNullOrEmpty(node["natural_middle_text_color"].InnerText))
            {
                VariantValue = node["natural_middle_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", NaturalMiddleTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Dark Background Color
            if (!string.IsNullOrEmpty(node["natural_dark_background_color"].InnerText))
            {
                VariantValue = node["natural_dark_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", NaturalDarkBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Dark Text Color
            if (!string.IsNullOrEmpty(node["natural_dark_text_color"].InnerText))
            {
                VariantValue = node["natural_dark_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", NaturalDarkTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }


            return ViewStyleBoxStruct.Replace("$_asp item;", SumViewStyleListItemStruct);
        }

        public string GetCurrentViewStyle(string SiteStyleId, string BackgroundColor, string FontSize, string CommonLightBackgroundColor, string CommonLightTextColor, string CommonMiddleBackgroundColor, string CommonMiddleTextColor, string CommonDarkBackgroundColor, string CommonDarkTextColor, string NaturalLightBackgroundColor, string NaturalLightTextColor, string NaturalMiddleBackgroundColor, string NaturalMiddleTextColor, string NaturalDarkBackgroundColor, string NaturalDarkTextColor)
        {
            if (FontSize == "99")
                FontSize = "unset";

            if (BackgroundColor == "       ")
                BackgroundColor = "unset";

            if (CommonLightBackgroundColor == "       ")
                CommonLightBackgroundColor = "unset";

            if (CommonLightTextColor == "       ")
                CommonLightTextColor = "unset";

            if (CommonMiddleBackgroundColor == "       ")
                CommonMiddleBackgroundColor = "unset";

            if (CommonMiddleTextColor == "       ")
                CommonMiddleTextColor = "unset";

            if (CommonDarkBackgroundColor == "       ")
                CommonDarkBackgroundColor = "unset";

            if (CommonDarkTextColor == "       ")
                CommonDarkTextColor = "unset";

            if (NaturalLightBackgroundColor == "       ")
                NaturalLightBackgroundColor = "unset";

            if (NaturalLightTextColor == "       ")
                NaturalLightTextColor = "unset";

            if (NaturalLightTextColor == "       ")
                NaturalLightTextColor = "unset";

            if (NaturalMiddleBackgroundColor == "       ")
                NaturalMiddleBackgroundColor = "unset";

            if (NaturalMiddleTextColor == "       ")
                NaturalMiddleTextColor = "unset";

            if (NaturalDarkBackgroundColor == "       ")
                NaturalDarkBackgroundColor = "unset";

            if (NaturalDarkTextColor == "       ")
                NaturalDarkTextColor = "unset";


            string ViewStyleBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/current_view_style/box").InnerText;
            string ViewStyleInternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/current_view_style/internal_box").InnerText;
            string ViewStyleExternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/current_view_style/external_box").InnerText;

            if (StaticObject.CreateExternalLinkForCurrentViewStyle)
            {
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp site_path;", StaticObject.SitePath);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp site_style_id;", SiteStyleId);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp background_color;", BackgroundColor);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp font_size;", FontSize);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp common_light_background_color;", CommonLightBackgroundColor);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp common_light_text_color;", CommonLightTextColor);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp common_middle_background_color;", CommonMiddleBackgroundColor);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp common_middle_text_color;", CommonMiddleTextColor);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp common_dark_background_color;", CommonDarkBackgroundColor);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp common_dark_text_color;", CommonDarkTextColor);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp natural_light_background_color;", NaturalLightBackgroundColor);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp natural_light_text_color;", NaturalLightTextColor);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp natural_middle_background_color;", NaturalMiddleBackgroundColor);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp natural_middle_text_color;", NaturalMiddleTextColor);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp natural_dark_background_color;", NaturalDarkBackgroundColor);
                ViewStyleExternalBoxStruct = ViewStyleExternalBoxStruct.Replace("$_asp natural_dark_text_color;", NaturalDarkTextColor);

                return ViewStyleExternalBoxStruct;
            }
            else
                return ViewStyleInternalBoxStruct.Replace("$_asp item;", GetCurrentViewStyleWithBox(SiteStyleId, BackgroundColor, FontSize, CommonLightBackgroundColor, CommonLightTextColor, CommonMiddleBackgroundColor, CommonMiddleTextColor, CommonDarkBackgroundColor, CommonDarkTextColor, NaturalLightBackgroundColor, NaturalLightTextColor, NaturalMiddleBackgroundColor, NaturalMiddleTextColor, NaturalDarkBackgroundColor, NaturalDarkTextColor));
        }

        public string GetCurrentViewStyleWithBox(string SiteStyleId, string BackgroundColor, string FontSize, string CommonLightBackgroundColor, string CommonLightTextColor, string CommonMiddleBackgroundColor, string CommonMiddleTextColor, string CommonDarkBackgroundColor, string CommonDarkTextColor, string NaturalLightBackgroundColor, string NaturalLightTextColor, string NaturalMiddleBackgroundColor, string NaturalMiddleTextColor, string NaturalDarkBackgroundColor, string NaturalDarkTextColor)
        {
            if (FontSize == "99")
                FontSize = "unset";

            if (BackgroundColor == "       ")
                BackgroundColor = "unset";

            if (CommonLightBackgroundColor == "       ")
                CommonLightBackgroundColor = "unset";

            if (CommonLightTextColor == "       ")
                CommonLightTextColor = "unset";

            if (CommonMiddleBackgroundColor == "       ")
                CommonMiddleBackgroundColor = "unset";

            if (CommonMiddleTextColor == "       ")
                CommonMiddleTextColor = "unset";

            if (CommonDarkBackgroundColor == "       ")
                CommonDarkBackgroundColor = "unset";

            if (CommonDarkTextColor == "       ")
                CommonDarkTextColor = "unset";

            if (NaturalLightBackgroundColor == "       ")
                NaturalLightBackgroundColor = "unset";

            if (NaturalLightTextColor == "       ")
                NaturalLightTextColor = "unset";

            if (NaturalLightTextColor == "       ")
                NaturalLightTextColor = "unset";

            if (NaturalMiddleBackgroundColor == "       ")
                NaturalMiddleBackgroundColor = "unset";

            if (NaturalMiddleTextColor == "       ")
                NaturalMiddleTextColor = "unset";

            if (NaturalDarkBackgroundColor == "       ")
                NaturalDarkBackgroundColor = "unset";

            if (NaturalDarkTextColor == "       ")
                NaturalDarkTextColor = "unset";


            string ViewStyleBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/current_view_style/box").InnerText;
            string ViewStyleListItemStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/current_view_style/list_item").InnerText;
            string TmpViewStyleListItemStruct = "";
            string SumViewStyleListItemStruct = "";

            DataUse.SiteStyle duss = new DataUse.SiteStyle();
            string StyleDirectoryPath = duss.GetStyleDirectoryPath(SiteStyleId);

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/site/" + StyleDirectoryPath + "/catalog.xml"));

            XmlNode node = doc.SelectSingleNode("site_style_catalog_root/current_view_style");
            string VariantValue = "";


            // Set Background Color
            if (!string.IsNullOrEmpty(node["background_color"].InnerText))
            {
                VariantValue = node["background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", BackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Font Size
            if (!string.IsNullOrEmpty(node["font_size"].InnerText))
            {
                VariantValue = node["font_size"].InnerText;
                VariantValue = VariantValue.Replace("$_asp font_size;", FontSize);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Light Background Color
            if (!string.IsNullOrEmpty(node["common_light_background_color"].InnerText))
            {
                VariantValue = node["common_light_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", CommonLightBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Light Text Color
            if (!string.IsNullOrEmpty(node["common_light_text_color"].InnerText))
            {
                VariantValue = node["common_light_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", CommonLightTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Middle Background Color
            if (!string.IsNullOrEmpty(node["common_middle_background_color"].InnerText))
            {
                VariantValue = node["common_middle_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", CommonMiddleBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Middle Text Color
            if (!string.IsNullOrEmpty(node["common_middle_text_color"].InnerText))
            {
                VariantValue = node["common_middle_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", CommonMiddleTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Dark Background Color
            if (!string.IsNullOrEmpty(node["common_dark_background_color"].InnerText))
            {
                VariantValue = node["common_dark_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", CommonDarkBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Common Dark Text Color
            if (!string.IsNullOrEmpty(node["common_dark_text_color"].InnerText))
            {
                VariantValue = node["common_dark_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", CommonDarkTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Light Background Color
            if (!string.IsNullOrEmpty(node["natural_light_background_color"].InnerText))
            {
                VariantValue = node["natural_light_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", NaturalLightBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Light Text Color
            if (!string.IsNullOrEmpty(node["natural_light_text_color"].InnerText))
            {
                VariantValue = node["natural_light_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", NaturalLightTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Middle Background Color
            if (!string.IsNullOrEmpty(node["natural_middle_background_color"].InnerText))
            {
                VariantValue = node["natural_middle_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", NaturalMiddleBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Middle Text Color
            if (!string.IsNullOrEmpty(node["natural_middle_text_color"].InnerText))
            {
                VariantValue = node["natural_middle_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", NaturalMiddleTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Dark Background Color
            if (!string.IsNullOrEmpty(node["natural_dark_background_color"].InnerText))
            {
                VariantValue = node["natural_dark_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", NaturalDarkBackgroundColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }

            // Set Natural Dark Text Color
            if (!string.IsNullOrEmpty(node["natural_dark_text_color"].InnerText))
            {
                VariantValue = node["natural_dark_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", NaturalDarkTextColor);
                TmpViewStyleListItemStruct = ViewStyleListItemStruct;
                TmpViewStyleListItemStruct = TmpViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumViewStyleListItemStruct += TmpViewStyleListItemStruct;
            }


            return ViewStyleBoxStruct.Replace("$_asp item;", SumViewStyleListItemStruct);
        }

        public string GetSiteClientVariant()
        {
            if (!StaticObject.UseSiteClientVariant)
                return "";

            string ClientVariantBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_client_variant/box").InnerText;
            string ClientVariantInternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_client_variant/internal_box").InnerText;
            string ClientVariantExternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_client_variant/external_box").InnerText;

            if (StaticObject.CreateExternalLinkForSiteClientVariant)
                return ClientVariantExternalBoxStruct.Replace("$_asp site_path;",StaticObject.SitePath);
            else
                return ClientVariantInternalBoxStruct.Replace("$_asp item;", GetSiteClientVariantWithBox());
        }

        public string GetUserViewStyle(string SiteStyleId, string UserId)
        {
            if (!StaticObject.UseViewStyle)
                return "";

            string UserViewStyleBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/user_view_style/box").InnerText;
            string UserViewStyleInternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/user_view_style/internal_box").InnerText;
            string UserViewStyleExternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/user_view_style/external_box").InnerText;

            if (StaticObject.CreateExternalLinkForUserViewStyle)
            {
                UserViewStyleExternalBoxStruct = UserViewStyleExternalBoxStruct.Replace("$_asp site_path;", StaticObject.SitePath);
                UserViewStyleExternalBoxStruct = UserViewStyleExternalBoxStruct.Replace("$_asp site_style_id;", SiteStyleId);
                UserViewStyleExternalBoxStruct = UserViewStyleExternalBoxStruct.Replace("$_asp user_id;", UserId);

                return UserViewStyleExternalBoxStruct;
            }
            else
                return UserViewStyleInternalBoxStruct.Replace("$_asp item;", GetUserViewStyleWithBox(SiteStyleId, UserId));
        }

        public string GetUserViewStyleWithBox(string SiteStyleId, string UserId)
        {
            string UserViewStyleBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/user_view_style/box").InnerText;
            string UserViewStyleListItemStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/user_view_style/list_item").InnerText;
            string TmpUserViewStyleListItemStruct = "";
            string SumUserViewStyleListItemStruct = "";

            DataUse.SiteStyle duss = new DataUse.SiteStyle();
            string StyleDirectoryPath = duss.GetStyleDirectoryPath(SiteStyleId);

            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "client/style/site/" + StyleDirectoryPath + "/catalog.xml"));

            XmlNode node = doc.SelectSingleNode("site_style_catalog_root/site_view_style");
            string VariantValue = "";

            // Get View
            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_user_view", "@user_id", UserId);

            if (dbdr.dr == null || !dbdr.dr.HasRows)
            {
                db.Close();
                return null;
            }

            dbdr.dr.Read();

            string FontSize = (dbdr.dr["user_font_size"].ToString() == "99") ? "unset" : dbdr.dr["user_font_size"].ToString();
            string BackgroundColor = (dbdr.dr["user_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["user_background_color"].ToString();
            string CommonLightBackgroundColor = (dbdr.dr["user_common_light_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["user_common_light_background_color"].ToString();
            string CommonLightTextColor = (dbdr.dr["user_common_light_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["user_common_light_text_color"].ToString();
            string CommonMiddleBackgroundColor = (dbdr.dr["user_common_middle_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["user_common_middle_background_color"].ToString();
            string CommonMiddleTextColor = (dbdr.dr["user_common_middle_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["user_common_middle_text_color"].ToString();
            string CommonDarkBackgroundColor = (dbdr.dr["user_common_dark_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["user_common_dark_background_color"].ToString();
            string CommonDarkTextColor = (dbdr.dr["user_common_dark_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["user_common_dark_text_color"].ToString();
            string NaturalLightBackgroundColor = (dbdr.dr["user_natural_light_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["user_natural_light_background_color"].ToString();
            string NaturalLightTextColor = (dbdr.dr["user_natural_light_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["user_natural_light_text_color"].ToString();
            string NaturalMiddleBackgroundColor = (dbdr.dr["user_natural_middle_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["user_natural_middle_background_color"].ToString();
            string NaturalMiddleTextColor = (dbdr.dr["user_natural_middle_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["user_natural_middle_text_color"].ToString();
            string NaturalDarkBackgroundColor = (dbdr.dr["user_natural_dark_background_color"].ToString() == "       ") ? "unset" : dbdr.dr["user_natural_dark_background_color"].ToString();
            string NaturalDarkTextColor = (dbdr.dr["user_natural_dark_text_color"].ToString() == "       ") ? "unset" : dbdr.dr["user_natural_dark_text_color"].ToString();

            db.Close();

            // Set Background Color
            if (!string.IsNullOrEmpty(node["user_background_color"].InnerText))
            {
                VariantValue = node["background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", BackgroundColor);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }

            // Set Font Size
            if (!string.IsNullOrEmpty(node["user_font_size"].InnerText))
            {
                VariantValue = node["font_size"].InnerText;
                VariantValue = VariantValue.Replace("$_asp font_size;", FontSize);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }

            // Set Common Light Background Color
            if (!string.IsNullOrEmpty(node["user_common_light_background_color"].InnerText))
            {
                VariantValue = node["common_light_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", CommonLightBackgroundColor);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }

            // Set Common Light Text Color
            if (!string.IsNullOrEmpty(node["user_common_light_text_color"].InnerText))
            {
                VariantValue = node["common_light_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", CommonLightTextColor);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }

            // Set Common Middle Background Color
            if (!string.IsNullOrEmpty(node["user_common_middle_background_color"].InnerText))
            {
                VariantValue = node["common_middle_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", CommonMiddleBackgroundColor);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }

            // Set Common Middle Text Color
            if (!string.IsNullOrEmpty(node["user_common_middle_text_color"].InnerText))
            {
                VariantValue = node["common_middle_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", CommonMiddleTextColor);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }

            // Set Common Dark Background Color
            if (!string.IsNullOrEmpty(node["user_common_dark_background_color"].InnerText))
            {
                VariantValue = node["common_dark_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", CommonDarkBackgroundColor);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }

            // Set Common Dark Text Color
            if (!string.IsNullOrEmpty(node["user_common_dark_text_color"].InnerText))
            {
                VariantValue = node["common_dark_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", CommonDarkTextColor);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }

            // Set Natural Light Background Color
            if (!string.IsNullOrEmpty(node["user_natural_light_background_color"].InnerText))
            {
                VariantValue = node["natural_light_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", NaturalLightBackgroundColor);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }

            // Set Natural Light Text Color
            if (!string.IsNullOrEmpty(node["user_natural_light_text_color"].InnerText))
            {
                VariantValue = node["natural_light_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", NaturalLightTextColor);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }

            // Set Natural Middle Background Color
            if (!string.IsNullOrEmpty(node["user_natural_middle_background_color"].InnerText))
            {
                VariantValue = node["natural_middle_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", NaturalMiddleBackgroundColor);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }

            // Set Natural Middle Text Color
            if (!string.IsNullOrEmpty(node["user_natural_middle_text_color"].InnerText))
            {
                VariantValue = node["natural_middle_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", NaturalMiddleTextColor);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }

            // Set Natural Dark Background Color
            if (!string.IsNullOrEmpty(node["user_natural_dark_background_color"].InnerText))
            {
                VariantValue = node["natural_dark_background_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp background_color;", NaturalDarkBackgroundColor);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }

            // Set Natural Dark Text Color
            if (!string.IsNullOrEmpty(node["user_natural_dark_text_color"].InnerText))
            {
                VariantValue = node["natural_dark_text_color"].InnerText;
                VariantValue = VariantValue.Replace("$_asp text_color;", NaturalDarkTextColor);
                TmpUserViewStyleListItemStruct = UserViewStyleListItemStruct;
                TmpUserViewStyleListItemStruct = TmpUserViewStyleListItemStruct.Replace("$_asp variant_value;", VariantValue);
                SumUserViewStyleListItemStruct += TmpUserViewStyleListItemStruct;
            }


            return UserViewStyleBoxStruct.Replace("$_asp item;", SumUserViewStyleListItemStruct);
        }


        public string GetSiteClientVariantWithBox()
        {
            string ClientVariantBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_client_variant/box").InnerText;
            string ClientVariantListItemStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_client_variant/list_item").InnerText;
            string TmpClientVariantListItemStruct = "";
            string SumClientVariantListItemStruct = "";

            XmlNode node = StaticObject.ConfigDocument.SelectSingleNode("elanat_root/properties");
            string VariantValue = "";

            // Set Site Path
            VariantValue = node["site_path"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "SitePath");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Site Auto Resize
            VariantValue = (node["use_site_auto_resize"].Attributes["active"].Value == "true")? "true" : "false";
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "UseSiteAutoResize");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", VariantValue);
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Default Site
            VariantValue = node["default_site"].Attributes["value"].Value;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "DefaultSite");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Default Page
            VariantValue = node["default_page"].Attributes["value"].Value;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "DefaultPage");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Use Cookie Message Alert
            VariantValue = node["show_use_cookie_message_alert"].Attributes["active"].Value;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "ShowUseCookieMessageAlert");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", VariantValue);
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            node = StaticObject.ConfigDocument.SelectSingleNode("elanat_root/date_and_time");

            // Set Date Format
            VariantValue = node["date_format"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "DateFormat");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Time Format
            VariantValue = node["time_format"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "TimeFormat");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Time Zone
            VariantValue = node["time_zone"].Attributes["value"].Value;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "TimeZone");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            node = StaticObject.ConfigDocument.SelectSingleNode("elanat_root/default_include_path");

            // Set Box Path
            VariantValue = node["box_path"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "BoxPath");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Open Box Function Name
            VariantValue = GetOpenBoxFunctionName(node["box_path"].InnerText);
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "OpenBoxFunctionName");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Close Box Function Name
            VariantValue = GetCloseBoxFunctionName(node["box_path"].InnerText);
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CloseBoxFunctionName");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Captcha Path
            VariantValue = node["captcha_path"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CaptchaPath");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Calendar Path
            VariantValue = node["calendar_path"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CalendarPath");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set File Viewer Path
            VariantValue = node["file_viewer_path"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "FileViewerPath");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Wysiwyg Path
            VariantValue = node["wysiwyg_path"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "WysiwygPath");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Wysiwyg Insert Content Function Name 
            VariantValue = GetInsertContentToWysiwygFunctionName(node["wysiwyg_path"].InnerText);
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "InsertContentToWysiwygFunctionName");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Date
            VariantValue = DateAndTime.GetDate();
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentDate");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Time
            VariantValue = DateAndTime.GetTime();
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentTime");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Year
            VariantValue = DateAndTime.GetDate("yyyy");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentYear");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Month
            VariantValue = DateAndTime.GetDate("MM");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentMonth");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Day
            VariantValue = DateAndTime.GetDate("dd");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentDay");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Hour
            VariantValue = DateAndTime.GetTime("hh");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentHour");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Minute
            VariantValue = DateAndTime.GetTime("mm");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentMinute");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Second
            VariantValue = DateAndTime.GetTime("ss");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentSecond");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Ajax Page Load
            VariantValue = Struct.GetNode("page_load/ajax_quick_load").InnerText.Replace(Environment.NewLine, "").Replace("\"", "&quot;");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "AjaxPageLoad");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Iframe Page Load
            VariantValue = Struct.GetNode("page_load/iframe_quick_load").InnerText.Replace(Environment.NewLine,"").Replace("\"", "&quot;");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "IframePageLoad");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Alert
            VariantValue = Template.GetXmlNodeFromGlobalTemplate("part/alert").InnerText.Replace(Environment.NewLine, "").Replace("\"", "&quot;");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "Alert");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            node = StaticObject.ConfigDocument.SelectSingleNode("elanat_root/security");

            // Set Cookies Life Time
            VariantValue = node["cookie_life_time"].Attributes["value"].Value;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CookiesLifeTime");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            return ClientVariantBoxStruct.Replace("$_asp item;", SumClientVariantListItemStruct);
        }

        public string GetAdminClientVariant()
        {
            if (!StaticObject.UseAdminClientVariant)
                return "";

            string ClientVariantBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_client_variant/box").InnerText;
            string ClientVariantInternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_client_variant/internal_box").InnerText;
            string ClientVariantExternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_client_variant/external_box").InnerText;

            if (StaticObject.CreateExternalLinkForAdminClientVariant)
                return ClientVariantExternalBoxStruct.Replace("$_asp site_path;", StaticObject.SitePath);
            else
                return ClientVariantInternalBoxStruct.Replace("$_asp item;", GetAdminClientVariantWithBox());
        }

        public string GetAdminClientVariantWithBox()
        {
            string ClientVariantBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_client_variant/box").InnerText;
            string ClientVariantListItemStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_client_variant/list_item").InnerText;
            string TmpClientVariantListItemStruct = "";
            string SumClientVariantListItemStruct = "";

            XmlNode node = StaticObject.ConfigDocument.SelectSingleNode("elanat_root/properties");
            string VariantValue = "";

            // Set Site Path
            VariantValue = node["site_path"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "SitePath");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;


            // Set Admin Directory Path
            CurrentClientObjectClass ccoc = new CurrentClientObjectClass();
            if (ccoc.RoleDominantType == "admin")
                VariantValue = StaticObject.AdminPath;
            else
                VariantValue = "";

            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "AdminDirectoryPath");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Default Site
            VariantValue = node["default_site"].Attributes["value"].Value;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "DefaultSite");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Default System
            VariantValue = node["default_system"].Attributes["value"].Value;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "DefaultSystem");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Default Component
            VariantValue = node["default_component"].Attributes["value"].Value;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "DefaultComponent");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Use Cookie Message Alert
            VariantValue = node["show_use_cookie_message_alert"].Attributes["active"].Value;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "ShowUseCookieMessageAlert");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", VariantValue);
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Server Refresh
            VariantValue = node["server_refresh"].Attributes["active"].Value;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "ServerRefresh");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", VariantValue);
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            node = StaticObject.ConfigDocument.SelectSingleNode("elanat_root/date_and_time");

            // Set Date Format
            VariantValue = node["date_format"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "DateFormat");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Time Format
            VariantValue = node["time_format"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "TimeFormat");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Time Zone
            VariantValue = node["time_zone"].Attributes["value"].Value;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "TimeZone");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            node = StaticObject.ConfigDocument.SelectSingleNode("elanat_root/default_include_path");

            // Set Box Path
            VariantValue = node["box_path"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "BoxPath");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Open Box Function Name
            VariantValue = GetOpenBoxFunctionName(node["box_path"].InnerText);
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "OpenBoxFunctionName");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Close Box Function Name
            VariantValue = GetCloseBoxFunctionName(node["box_path"].InnerText);
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CloseBoxFunctionName");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Captcha Path
            VariantValue = node["captcha_path"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CaptchaPath");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Calendar Path
            VariantValue = node["calendar_path"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CalendarPath");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set File Viewer Path
            VariantValue = node["file_viewer_path"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "FileViewerPath");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Wysiwyg Path
            VariantValue = node["wysiwyg_path"].InnerText;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "WysiwygPath");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Wysiwyg Insert Content Function Name 
            VariantValue = GetInsertContentToWysiwygFunctionName(node["wysiwyg_path"].InnerText);
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "InsertContentToWysiwygFunctionName");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Date
            VariantValue = DateAndTime.GetDate();
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentDate");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Time
            VariantValue = DateAndTime.GetTime();
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentTime");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Year
            VariantValue = DateAndTime.GetDate("yyyy");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentYear");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Month
            VariantValue = DateAndTime.GetDate("MM");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentMonth");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Day
            VariantValue = DateAndTime.GetDate("dd");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentDay");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Hour
            VariantValue = DateAndTime.GetTime("hh");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentHour");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Minute
            VariantValue = DateAndTime.GetTime("mm");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentMinute");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Current Second
            VariantValue = DateAndTime.GetTime("ss");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CurrentSecond");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Ajax Page Load
            VariantValue = Struct.GetNode("page_load/ajax_quick_load").InnerText.Replace(Environment.NewLine, "").Replace("\"", "&quot;");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "AjaxPageLoad");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Iframe Page Load
            VariantValue = Struct.GetNode("page_load/iframe_quick_load").InnerText.Replace(Environment.NewLine, "").Replace("\"", "&quot;");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "IframePageLoad");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            // Set Alert
            VariantValue = Template.GetXmlNodeFromGlobalTemplate("part/alert").InnerText.Replace(Environment.NewLine, "").Replace("\"", "&quot;");
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "Alert");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            node = StaticObject.ConfigDocument.SelectSingleNode("elanat_root/security");

            // Set Cookie Life Time
            VariantValue = node["cookie_life_time"].Attributes["value"].Value;
            TmpClientVariantListItemStruct = ClientVariantListItemStruct;
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_name;", "CookiesLifeTime");
            TmpClientVariantListItemStruct = TmpClientVariantListItemStruct.Replace("$_asp variant_value;", "\"" + VariantValue + "\"");
            SumClientVariantListItemStruct += TmpClientVariantListItemStruct;

            return ClientVariantBoxStruct.Replace("$_asp item;", SumClientVariantListItemStruct);
        }

        public string GetSiteClientLanguageVariant(string LanguageGlobalName)
        {
            if (!StaticObject.UseSiteClientLanguageVariant)
                return "";

            string SiteClientLanguageVariantBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_client_language_variant/box").InnerText;
            string SiteClientLanguageVariantInternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_client_language_variant/internal_box").InnerText;
            string SiteClientLanguageVariantExternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_client_language_variant/external_box").InnerText;

            if (StaticObject.CreateExternalLinkForSiteClientLanguageVariant)
                return SiteClientLanguageVariantExternalBoxStruct.Replace("$_asp site_path;", StaticObject.SitePath).Replace("$_asp language_global_name;", LanguageGlobalName);
            else
                return SiteClientLanguageVariantInternalBoxStruct.Replace("$_asp item;", GetSiteClientLanguageVariantWithBox(LanguageGlobalName));
        }

        public string GetSiteClientLanguageVariantWithBox(string LanguageGlobalName)
        {
            string SiteClientLanguageVariantBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_client_language_variant/box").InnerText;
            string SiteClientLanguageVariantListItemStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/site_client_language_variant/list_item").InnerText;
            string TmpSiteClientLanguageVariantListItemStruct = "";
            string SumSiteClientLanguageVariantListItemStruct = "";


            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + LanguageGlobalName + "/client_variant/site/" + LanguageGlobalName + ".xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("language_root/language_list").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                TmpSiteClientLanguageVariantListItemStruct = SiteClientLanguageVariantListItemStruct;
                TmpSiteClientLanguageVariantListItemStruct = TmpSiteClientLanguageVariantListItemStruct.Replace("$_asp variant_name;", node.Attributes["name"].Value);
                TmpSiteClientLanguageVariantListItemStruct = TmpSiteClientLanguageVariantListItemStruct.Replace("$_asp variant_value;", "\"" + node.InnerText + "\"");
                SumSiteClientLanguageVariantListItemStruct += TmpSiteClientLanguageVariantListItemStruct;
            }

            return SiteClientLanguageVariantBoxStruct.Replace("$_asp item;", SumSiteClientLanguageVariantListItemStruct);
        }

        public string GetAdminClientLanguageVariant(string LanguageGlobalName)
        {
            if (!StaticObject.UseAdminClientLanguageVariant)
                return "";

            string AdminClientLanguageVariantBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_client_language_variant/box").InnerText;
            string AdminClientLanguageVariantInternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_client_language_variant/internal_box").InnerText;
            string AdminClientLanguageVariantExternalBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_client_language_variant/external_box").InnerText;

            if (StaticObject.CreateExternalLinkForAdminClientLanguageVariant)
                return AdminClientLanguageVariantExternalBoxStruct.Replace("$_asp site_path;", StaticObject.SitePath).Replace("$_asp language_global_name;", LanguageGlobalName);
            else
                return AdminClientLanguageVariantInternalBoxStruct.Replace("$_asp item;", GetAdminClientLanguageVariantWithBox(LanguageGlobalName));
        }

        public string GetAdminClientLanguageVariantWithBox(string LanguageGlobalName)
        {
            string AdminClientLanguageVariantBoxStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_client_language_variant/box").InnerText;
            string AdminClientLanguageVariantListItemStruct = StaticObject.StructDocument.SelectSingleNode("struct_root/admin_client_language_variant/list_item").InnerText;
            string TmpAdminClientLanguageVariantListItemStruct = "";
            string SumAdminClientLanguageVariantListItemStruct = "";


            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "language/" + LanguageGlobalName + "/client_variant/admin/" + LanguageGlobalName + ".xml"));
            XmlNodeList NodeList = doc.SelectSingleNode("language_root/language_list").ChildNodes;

            foreach (XmlNode node in NodeList)
            {
                TmpAdminClientLanguageVariantListItemStruct = AdminClientLanguageVariantListItemStruct;
                TmpAdminClientLanguageVariantListItemStruct = TmpAdminClientLanguageVariantListItemStruct.Replace("$_asp variant_name;", node.Attributes["name"].Value);
                TmpAdminClientLanguageVariantListItemStruct = TmpAdminClientLanguageVariantListItemStruct.Replace("$_asp variant_value;", "\"" + node.InnerText + "\"");
                SumAdminClientLanguageVariantListItemStruct += TmpAdminClientLanguageVariantListItemStruct;
            }

            return AdminClientLanguageVariantBoxStruct.Replace("$_asp item;", SumAdminClientLanguageVariantListItemStruct);
        }

        public string GetOpenBoxFunctionName(string BoxPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "include/box/" + BoxPath + "/catalog.xml"));
            string OpenBoxFunctionName = doc.SelectSingleNode("box_catalog_root/open_box_function_name").InnerText;
            return OpenBoxFunctionName;
        }

        public string GetCloseBoxFunctionName(string BoxPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "include/box/" + BoxPath + "/catalog.xml"));
            string CloseBoxFunctionName = doc.SelectSingleNode("box_catalog_root/close_box_function_name").InnerText;
            return CloseBoxFunctionName;
        }

        public string GetInsertContentToWysiwygFunctionName(string WysiwygPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "include/wysiwyg/" + WysiwygPath + "/catalog.xml"));
            string InsertContentToWysiwygFunctionName = doc.SelectSingleNode("wysiwyg_catalog_root/wysiwyg_insert_content_function_name").InnerText;
            return InsertContentToWysiwygFunctionName;
        }
    }
}