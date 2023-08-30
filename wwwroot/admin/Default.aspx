<%@ Page Controller="Elanat.AdminController" Model="Elanat.AdminModel"%><!DOCTYPE html>
<html xmlns="http:/www.w3.org/1999/xhtml" dir="<%=model.CurrentLanguageDirection%>">

	<head>
	
		<title><%=model.CurrentTitle%></title>
		
		<!-- Start Client Variant -->
		<%=model.ClientVariant%>
		<!-- End Client Variant -->
		
		<!-- Start Static Head -->
		<%=model.CurrentStaticHead%>
		<!-- End Static Head -->

		<!-- Start Dynamic Head -->
		<%=model.CurrentDynamicHead%>
		<!-- End Dynamic Head -->

	</head>
	
	<body class="el_admin_main" onload="el_PageLoad()">
        <!-- Start Header Bar -->
		<div class="el_header_bar_part">
            <div id="div_HeaderBar" class="el_header_bar">
                <!-- Start Header Bar Left -->
		        <div id="div_HeaderBarLeft" class="el_header_bar_left">
			        <%=model.HeaderBarLeftLocation%>
		        </div>
                <!-- End Header Bar Left -->
                <!-- Start Header Bar Right -->
		        <div id="div_HeaderBarRight" class="el_header_bar_right">
			        <%=model.HeaderBarRightLocation%>
		        </div>
            <!-- End Header Bar Right -->
		    </div>
            <!-- Start Header Bar Box -->
		    <div id="div_HeaderBarBox" class="el_header_bar_box el_hidden">
			    <%=model.HeaderBarBoxLocation%>
		    </div>
            <!-- End Header Bar Box -->
		</div>
		<!-- End Header Bar -->
		
		<!-- Start Header -->
		<div class="el_header_part">
			<div id="div_Header" class="el_header">

                <!-- Start Header 1 -->
                <div class="el_header_1">
	                <%=model.Header1Location%>
                </div>
                <!-- End Header 1 -->

                <!-- Start Header 2 -->
                <div class="el_header_2">
	                <%=model.Header2Location%>
                </div>
                <!-- End Header 2 -->

                <!-- Start Header Menu -->
	            <div class="el_header_menu">
		            <%=model.HeaderMenuLocation%>
	            </div>
                <!-- End Header Menu -->
            </div>
		</div>
		<!-- End Header -->
		
		<!-- Start Menu -->
		<div class="el_menu_part">
            <div class="el_menu">
                <%=model.MenuLocation%>
            </div>
		</div>
		<!-- End Menu -->
		
		<!-- Start Main -->
		<div class="el_main_part">
			<div id="div_MainLocation" class="el_main">
                <!-- Start After Header -->
				<div class="after_header">
					<%=model.AfterHeaderLocation%>
				</div>
                <!-- End After Header -->
        
                <!-- Start Left Menu -->
				<div id="div_LeftLocation" class="el_left_menu el_hide">
                    <div id="div_CloseMenu" onclick="el_CloseLeftMenu()"></div>
					<%=model.LeftMenuLocation%>
				</div>
                <!-- End Left Menu -->

				<!-- Start Content -->
				<div id="div_ContentLocation" class="el_content">

				    <div id="div_PageLoad">
					    <div id="div_Main" class="el_main">
						    <%=model.CurrentComponentContent%>
					    </div>
				    </div>

				</div>
				<!-- End Content -->

                <!-- Start Right Menu -->
				<div id="div_RightLocation" class="el_right_menu el_hide">
                    <div id="div_CloseMenu" onclick="el_CloseRightMenu()"></div>
					<%=model.RightMenuLocation%>
				</div>
				<!-- End Right Menu -->
        
                <!-- Start Before Footer -->
				<div class="before_footer">
					<%=model.BeforeFooterLocation%>
				</div>
                <!-- End Before Footer -->
			</div>
		</div>
		<!-- End Main -->
		
		<!-- Start Footer -->
		<div class="el_footer_part">
		    <div class="el_footer">
                <!-- Start Footer Menu -->
				<div class="el_menu_bottom">
			        <%=model.FooterMenuLocation%>
				</div>
                <!-- End Footer Menu -->

				<!-- Start Footer 1 -->
				<div class="el_footer_1">
					<%=model.Footer1Location%>
				</div>
				<!-- End Footer 1 -->
				
				<!-- Start Footer 2 -->
				<div class="el_footer_2">
					<%=model.Footer2Location%>
				</div>
				<!-- End Footer 2 -->
		    </div>
		</div>
		<!-- End Footer -->
		
		<!-- Start Footer Bar -->
		<div class="el_footer_bar_part">
            <div id="div_FooterBar">
                <!-- Start Footer Bar Left -->
                <div id="div_FooterBarLeft">
                    <%=model.FooterBarLeftLocation%>
                </div>
                <!-- End Footer Bar Left -->
                <!-- Start Footer Bar Right -->
                <div id="div_FooterBarRight">
                    <%=model.FooterBarRightLocation%>
                </div>
                <!-- End Footer Bar Right -->
            </div>
            <!-- Start Footer Bar Box -->
            <div id="div_FooterBarBox" class="el_footer_bar_box">
                <%=model.FooterBarBoxLocation%>
            </div>
            <!-- End Footer Bar Box -->
		</div>
		<!-- End Footer Bar -->
		<div class="el_hidden">
			<%=model.CurrentLoadTag%>
		</div>
	</body>
	
</html>