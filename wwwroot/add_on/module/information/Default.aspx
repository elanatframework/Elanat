<%@ Page Controller="Elanat.ModuleInformationController" Model="Elanat.ModuleInformationModel" %>
            <div class="el_part_row">
                <div id="div_InformationTitle" class="el_title" onclick="el_HidePart(this); el_SetIframeAutoHeight()">
                    <%=model.InformationLanguage%>
                    <div class="el_dash"></div>
                </div>
                <div class="el_item">
                    <div>

                        <%=model.FootPrintValue%>

                        <%=model.VisitValue%>

                        <%=model.UserValue%>

                        <%=model.ContactValue%>

                        <%=model.CommentValue%>

                        <%=model.ContentValue%>

                        <%=model.ActiveContentValue%>

                        <%=model.InactiveContentValue%>

                    </div>

                    <div>

                        <%=model.TrashContentValue%>

                        <%=model.DraftContentValue%>

                        <%=model.DelayContentValue%>

                        <%=model.AdminNoteContentValue%>

                        <%=model.AttachmentValue%>

                        <%=model.LogErrorValue%>

                        <%=model.UploadSizeValue%>

                        <%=model.TmpSizeValue%>

                    </div>
           
                </div>
            </div>