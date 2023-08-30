using System.Net;

namespace Elanat
{
    public class InnerModuleClass
	{
        public static string PageNumbers(int RowCount, string CurrentPath = "", int CurrentPage = 0, int RowPerTable = 10, string NameString = "?page=", bool UseAjax = false, string PostbackSectionId = "")
        {
            CurrentPath = WebUtility.HtmlDecode(CurrentPath);
            NameString = WebUtility.HtmlDecode(NameString);

            if (!UseAjax)
            UseAjax = ElanatConfig.GetNode("properties/content_page_number").Attributes["use_ajax"].Value.TrueFalseToBoolean();

            string QueryString = "";

            if (!string.IsNullOrEmpty(CurrentPath))
            {
                if (CurrentPath[0] == '?' || CurrentPath[0] == '&')
                {
                    if (NameString[0] == '?')
                    {
                        QueryString = "?" + CurrentPath.Substring(1, CurrentPath.Length - 1);
                        NameString = '&' + NameString.Substring(1, NameString.Length - 1);                        
                    }
                    
                    CurrentPath = "";
                }

                if (CurrentPath.Contains("?"))
                {
                    if (NameString[0] == '?')
                    {
                        QueryString = "?" + CurrentPath.GetTextAfterValue("?");
                        NameString = '&' + NameString.Substring(1, NameString.Length - 1);
                    }

                    CurrentPath = CurrentPath.GetTextBeforeValue("?");
                }
            }

            string LoadStruct = (UseAjax) ? "href='#' onclick=\"el_LoadPageWithAjax('" + CurrentPath + QueryString + "$_asp page_value;" +  "', false, '" + PostbackSectionId + "')\"" : "href='" + CurrentPath + QueryString + "$_asp page_value;" + "'";
            
            RowPerTable = StaticObject.NumberOfRowPerTable;

            string PageNumberBox = "";
            string PageNumber = "";
            string Previous = "";
            string Next = "";
            decimal count = (decimal)RowCount;
            int first = 1;
            int last = Convert.ToInt32(Math.Ceiling(count / RowPerTable));

            Previous = (CurrentPage == 1) ? "<a href=''>&lt;</a>" : "<a " + LoadStruct.Replace("$_asp page_value;", NameString + (CurrentPage - 1).ToString()) + ">&lt;</a>";

            Next = (CurrentPage == last) ? "<a href=''>&gt;</a>" : "<a " + LoadStruct.Replace("$_asp page_value;", NameString + (CurrentPage + 1).ToString()) + ">&gt;</a>";

            if (RowCount == 0)
                return "";

            if (last == 1)
                return "";

            if (CurrentPage <= 0)
            {
                CurrentPage = 0;

                Previous = (CurrentPage == 1) ? "<a href=''>&lt;</a>" : "<a " + LoadStruct.Replace("$_asp page_value;", NameString + 1) + ">&lt;</a>";

                Next = (CurrentPage == last) ? "<a href=''>&gt;</a>" : "<a " + LoadStruct.Replace("$_asp page_value;", NameString + last) + ">&gt;</a>";

                PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 1) + ">" + 1 + "</a></li>";
                PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 2) + ">" + 2 + "</a></li>";

                if (last == 3)
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 3) + ">" + 3 + "</a></li>";

                if (last == 4)
                {
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 3) + ">" + 3 + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 4) + ">" + 4 + "</a></li>";
                }

                if (last == 5)
                {
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 3) + ">" + 3 + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 4) + ">" + 4 + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 5) + ">" + 5 + "</a></li>";
                }

                if (last > 5)
                {
                    PageNumber += "<li>...</li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + (last - 1)) + ">" + (last - 1) + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + last) + ">" + last + "</a></li>";
                }

                goto Finish;
            }

            if (last <= 5)
            {
                while (first <= last)
                {
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + first) + ">" + first + "</a></li>";
                    first++;
                }

                goto Finish;
            }

            if (last > 5)
            {
                if (CurrentPage == 1)
                {
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 1) + ">" + 1 + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 2) + ">" + 2 + "</a></li>";

                    PageNumber += "<li>...</li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + last) + ">" + last + "</a></li>";

                    goto Finish;
                }

                if (CurrentPage == 2)
                {
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 1) + ">" + 1 + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 2) + ">" + 2 + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 3) + ">" + 3 + "</a></li>";

                    PageNumber += "<li>...</li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + last) + ">" + last + "</a></li>";

                    goto Finish;
                }

                if (CurrentPage == 3)
                {
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 1) + ">" + 1 + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 2) + ">" + 2 + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 3) + ">" + 3 + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 4) + ">" + 4 + "</a></li>";

                    PageNumber += "<li>...</li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + last) + ">" + last + "</a></li>";

                    goto Finish;
                }

                if (CurrentPage == last)
                {
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 1) + ">" + 1 + "</a></li>";
                    PageNumber += "<li>...</li>";

                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + (last - 1)) + ">" + (last - 1) + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + last) + ">" + last + "</a></li>";

                    goto Finish;
                }

                if (CurrentPage == (last - 1))
                {
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 1) + ">" + 1 + "</a></li>";
                    PageNumber += "<li>...</li>";


                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + (last - 2)) + ">" + (last - 2) + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + (last - 1)) + ">" + (last - 1) + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + last) + ">" + last + "</a></li>";

                    goto Finish;
                }

                if (CurrentPage == (last - 2))
                {
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 1) + ">" + 1 + "</a></li>";
                    PageNumber += "<li>...</li>";

                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + (last - 3)) + ">" + (last - 3) + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + (last - 2)) + ">" + (last - 2) + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + (last - 1)) + ">" + (last - 1) + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + last) + ">" + last + "</a></li>";

                    goto Finish;
                }

                if (CurrentPage > 3)
                {
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + 1) + ">" + 1 + "</a></li>";
                    PageNumber += "<li>...</li>";

                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + (CurrentPage - 1)) + ">" + (CurrentPage - 1) + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + CurrentPage) + ">" + CurrentPage + "</a></li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + (CurrentPage + 1)) + ">" + (CurrentPage + 1) + "</a></li>";

                    PageNumber += "<li>...</li>";
                    PageNumber += "<li><a " + LoadStruct.Replace("$_asp page_value;", NameString + last) + ">" + last + "</a></li>";

                    goto Finish;
                }
            }

            Finish:
            PageNumberBox = "<div id='div_PageNumber'>" + Previous + "<ul>" + PageNumber + "</ul>" + Next + "</div>";

            return PageNumberBox.Replace("<a " + LoadStruct.Replace("$_asp page_value;", NameString + CurrentPage) + ">", "<a class='el_current_page'>");
        }
    }
}