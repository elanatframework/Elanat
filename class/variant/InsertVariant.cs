using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace elanat
{
	public class InsertVariant
    {
        /// <summary>
        /// Do Not Use This Method, Replace Method Has Better Performance Instead This Method.
        /// </summary>
        public string Insert(string Text, NameValueCollection NameValue, string GlobalLanguage)
        {
            string TmpText = "";
            int i = 0;
            int TextLength = Text.Length;
            string TmpVariant = "";

            while (i < TextLength)
            {
                if (Text[i] == '$' && (i + 1) < TextLength)
                {
                    if (Text[i + 1] == '_')
                    {
                        TmpVariant = "";

                        while (true)
                        {
                            if (i >= TextLength)
                            {
                                if (StaticObject.UseVariantDebug)
                                    GlobalClass.Alert(Language.GetLanguage("do_not_find_semicolon_in_asp_variant", GlobalLanguage).Replace("$_asp variant;", TmpVariant), GlobalLanguage, "problem");

                                break;
                            }

                            if (Text[i] != ';')
                            {
                                TmpVariant += Text[i];
                                i++;
                            }
                            else
                            {
                                TmpVariant += Text[i];

                                if (!string.IsNullOrEmpty(NameValue[TmpVariant]))
                                    TmpText += NameValue[TmpVariant];
                                else
                                    if (StaticObject.UseVariantDebug)
                                        GlobalClass.Alert(Language.GetLanguage("variant_asp_is_not_existed", GlobalLanguage).Replace("$_asp variant;", TmpVariant), GlobalLanguage, "problem");

                                break;
                            }
                        }
                    }
                    else
                        TmpText += Text[i];
                }
                else
                    TmpText += Text[i];

                i++;
            }

            return TmpText;
        }
    }
}