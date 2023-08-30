using CodeBehind;

namespace Elanat
{
    public partial class ActionLockLoginModel : CodeBehindModel
    {
        public string LockLoginActiveInactiveLanguage { get; set; }

        public string ContentValue { get; set; }

        public void SetValue()
        {
            if (StaticObject.LockLogin)
            {
                StaticObject.LockLogin = false;
                ElanatConfig.SetElanatConfig("false", "security/lock_login_for_first_login", 0, "active");
                string LockLoginInActiveTemplate = Template.GetSiteTemplate("page/lock_login_inactive", true);
                ContentValue = Language.GetLanguageFromContent(LockLoginInActiveTemplate, StaticObject.GetCurrentSiteGlobalLanguage());
                LockLoginActiveInactiveLanguage = Language.GetHandheldLanguage("lock_login_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage());
            }
            else
            {
                DataUse.Patch dup = new DataUse.Patch();
                string LockLoginPatchId = dup.GetPatchIdByPatchName("lock_login");
                dup.FillCurrentPatch(LockLoginPatchId);

                if (!dup.PatchActive.ZeroOneToBoolean())
                {
                    string LockLoginDisableTemplate = Template.GetSiteTemplate("page/lock_login_disable", true);
                    ContentValue = Language.GetLanguageFromContent(LockLoginDisableTemplate, StaticObject.GetCurrentSiteGlobalLanguage());
                    LockLoginActiveInactiveLanguage = Language.GetHandheldLanguage("lock_login_patch_is_inactive", StaticObject.GetCurrentSiteGlobalLanguage());

                    return;
                }


                StaticObject.LockLogin = true;
                ElanatConfig.SetElanatConfig("true", "security/lock_login_for_first_login", 0, "active");
                string LockLoginActiveTemplate = Template.GetSiteTemplate("page/lock_login_active", true);
                ContentValue = Language.GetLanguageFromContent(LockLoginActiveTemplate, StaticObject.GetCurrentSiteGlobalLanguage());
                LockLoginActiveInactiveLanguage = Language.GetHandheldLanguage("lock_login_is_active", StaticObject.GetCurrentSiteGlobalLanguage());
            }
        }
    }
}