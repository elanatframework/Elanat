using CodeBehind;
using System.Xml;

namespace Elanat
{
    public partial class ActionShowEditorTemplateListModel : CodeBehindModel
    {
        public void SetValue()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(StaticObject.ServerMapPath(StaticObject.SitePath + "template/admin/" + StaticObject.GetCurrentAdminTemplatePhysicalPath()));
            string ListItemTemplate = doc.SelectSingleNode("template_root/box_load/editor_template/list_item").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());
            string TmpListItemTemplate;
            string SumListItemTemplate = "";

            string EditorTemplateCategorySeparateTemplate = doc.SelectSingleNode("template_root/box_load/editor_template/category_separate").InnerTextAfterSetNodeVariant(StaticObject.GetCurrentAdminGlobalLanguage());

            DataBaseSocket db = new DataBaseSocket();
            DataBaseDataReader dbdr = new DataBaseDataReader();
			dbdr.dr = db.GetProcedure("get_editor_template_list");

            string EditorTemplateCategorySeparate = "";
            string LastEditorTemplateCategory = "";

            if (dbdr.dr != null && dbdr.dr.HasRows)
                while (dbdr.dr.Read())
                {
                    if (!dbdr.dr["editor_template_active"].ToString().TrueFalseToBoolean())
                        continue;

                    if (dbdr.dr["editor_template_category"].ToString() != LastEditorTemplateCategory)
                        EditorTemplateCategorySeparate = EditorTemplateCategorySeparateTemplate.Replace("$_asp editor_template_category;", dbdr.dr["editor_template_category"].ToString());
                    else
                        EditorTemplateCategorySeparate = "";

                    LastEditorTemplateCategory = dbdr.dr["editor_template_category"].ToString();

                    TmpListItemTemplate = ListItemTemplate;
                    TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp editor_template_id;", dbdr.dr["editor_template_id"].ToString());
                    TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp editor_template_name;", dbdr.dr["editor_template_name"].ToString());
                    TmpListItemTemplate = TmpListItemTemplate.Replace("$_asp editor_template_directory_path;", dbdr.dr["editor_template_directory_path"].ToString());
                    SumListItemTemplate += EditorTemplateCategorySeparate + TmpListItemTemplate;
                }

            db.Close();

            Write(SumListItemTemplate);
        }
    }
}