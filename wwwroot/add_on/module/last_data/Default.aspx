<%@ Page Controller="Elanat.ModuleLastDataController" Model="Elanat.ModuleLastDataModel" %>
            <div class="el_part_row">
                <div id="div_LastDataTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.LastDataLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <div class="el_column_left">

                        <%=model.LastContacValue%>

                        <%=model.LastCommentValue%>

                        <%=model.LastAttachmentValue%>

                        <%=model.LastActiveUsersValue%>

                    </div>

                    <div class="el_column_right">

                        <%=model.LastContentValue%>

                        <%=model.LastFootPrintValue%>

                        <%=model.LastUserSignUpValue%>

                    </div>

                </div>
            </div>

			<script>
			    var ContentLanguageVariant = new Object();
			    ContentLanguageVariant.Active = "<%=model.AreYouSureWantToActiveLanguage%>";
			    ContentLanguageVariant.Restore = "<%=model.AreYouSureWantToRestoreLanguage%>";
			    ContentLanguageVariant.InActive = "<%=model.AreYouSureWantToInctiveLanguage%>";
			    ContentLanguageVariant.Delete = "<%=model.AreYouSureWantToDeleteLanguage%>";

			    var ContactLanguageVariant = new Object();
			    ContactLanguageVariant.Active = "<%=model.AreYouSureWantToActiveLanguage%>";
			    ContactLanguageVariant.InActive = "<%=model.AreYouSureWantToInctiveLanguage%>";
			    ContactLanguageVariant.Delete = "<%=model.AreYouSureWantToDeleteLanguage%>";

			    var CommentLanguageVariant = new Object();
			    CommentLanguageVariant.Active = "<%=model.AreYouSureWantToActiveLanguage%>";
			    CommentLanguageVariant.InActive = "<%=model.AreYouSureWantToInctiveLanguage%>";
			    CommentLanguageVariant.Delete = "<%=model.AreYouSureWantToDeleteLanguage%>";

			    var UserLanguageVariant = new Object();
			    UserLanguageVariant.Active = "<%=model.AreYouSureWantToActiveLanguage%>";
			    UserLanguageVariant.InActive = "<%=model.AreYouSureWantToInctiveLanguage%>";
			    UserLanguageVariant.Delete = "<%=model.AreYouSureWantToDeleteLanguage%>";

			    var AttachmentLanguageVariant = new Object();
			    AttachmentLanguageVariant.Active = "<%=model.AreYouSureWantToActiveLanguage%>";
			    AttachmentLanguageVariant.InActive = "<%=model.AreYouSureWantToInctiveLanguage%>";
			    AttachmentLanguageVariant.Delete = "<%=model.AreYouSureWantToDeleteLanguage%>>";
			</script>