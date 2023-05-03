<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Default.aspx.cs" Inherits="elanat.Scripts._default" validateRequest="false" %><!DOCTYPE html>
<html xmlns="http:/www.w3.org/1999/xhtml" dir="<%=CurrentLanguageDirection%>">

	<head>
	
		<title><%=CurrentTitle%></title>
		
		<!-- Start Client Variant -->
		<%=ClientVariant%>
		<!-- End Client Variant -->
		
		<!-- Start Static Head -->
		<%=CurrentStaticHead%>
		<!-- End Static Head -->
		
		<!-- Start Dynamic Head -->
		<%=CurrentDynamicHead%>
		<!-- End Dynamic Head -->

	</head>
	
	<body onload="el_PageLoad()">
		<!-- Start Header Bar -->
		<div class="el_header_bar_part">
		    <div id="header_bar">
		        <div id="div_header_bar_left" class="el_header_bar_left">
			        <%=HeaderBarLeftLocation%>
		        </div>
		        <div id="div_header_bar_right" class="el_header_bar_right">
			        <%=HeaderBarRightLocation%>
		        </div>
		    </div>
		    <div id="div_HeaderBarBox" class="el_header_bar_box el_hidden">
			    <%=HeaderBarBoxLocation%>
		    </div>
		</div>
		<!-- End Header Bar -->
		
		<!-- Start Header -->
		<div class="el_header_part">
		    <div id="header" class="el_header">
			
			    <!-- Start Header 1 -->
			    <div class="el_header_1">
				    <ul>
					    <%=Header1Location%>
				    </ul>
			    </div>
			    <!-- End Header 1 -->
			
			    <!-- Start Header 2 -->
			    <div class="el_header_2 el_inner_right">
				    <ul>
					    <%=Header2Location%>
				    </ul>
			    </div>
			    <!-- End Header 2 -->
		
			    <!-- Start Header Menu -->
				    <div class="el_header_menu">
					    <%=HeaderMenuLocation%>
				    </div>
			    <!-- End Header Menu -->
		    </div>
		</div>
		<!-- End Header -->
		
		<!-- Start Menu -->
		<div class="el_menu_part">
			<div id="div_Menu" class="el_menu">
			<div id="div_CloseMenu" onclick="el_CloseMenuResponsive()"></div>
			<div id="div_ShowMenu" onclick="el_ShowMenuResponsive()"></div>
				<%=MenuLocation%>
			</div>
		</div>
		<!-- End Menu -->
		
		<!-- Start Main -->
		<div class="el_main_part">
			<div id="div_MainLocation" class="el_main<%=ExistContentValue%><%=ExistLeftMenuValue%><%=ExistRightMenuValue%>">
      
                <!-- Start After Header -->
				<div class="el_after_header">
					<%=AfterHeaderLocation%>
				</div>
                <!-- End After Header -->
				
				<!-- Start Left Menu -->
				<div id="div_LeftLocation" class="el_left_menu">
					<%=LeftMenuLocation%>
				</div>
				<!-- End Left Menu -->
			
				<!-- Start Content -->
				<div id="div_ContentLocation" class="el_content">

					<div id="pnl_Presentation" class="el_presentation_panel">
						<div id="div_PageLoad">
							<%=CurrentPageContent%>
						</div>
					</div>

				</div>
				<!-- End Content -->

                <!-- Start Right Menu -->
				<div id="div_RightLocation" class="el_right_menu">
					<%=RightMenuLocation%>
				</div>
                <!-- End Right Menu -->
				
                <!-- Start Before Footer -->
				<div class="el_before_footer">
					<%=BeforeFooterLocation%>
				</div>
                <!-- End Before Footer -->
			</div>
		</div>
		<!-- End Main -->
		
		<!-- Start Footer -->
		<div class="el_footer_part">
		    <div class="el_footer">
			    <div class="el_top">
				    <div class="el_right">
					
				    </div>
				    <div class="el_left">

				    </div>
			    </div>
			    <div class="el_bottom">
				    <div class="el_top">
					    <div class="el_footer_menu_box">
						    <div class="el_footer_menu">
							    <%=FooterMenuLocation%>
						    </div>
					    </div>
				    </div>
				    <!-- Start Footer 1 -->
				    <div class="el_footer_1">
					    <ul class="el_footer_1_menu_box">
                            <div class="el_flex">
						        <%=Footer1Location%>
                            </div>
					    </ul>
				    </div>
				    <!-- End Footer 1 -->
				
				    <!-- Start Footer 2 -->
				    <div class="el_footer_2">
					    <ul class="el_footer_2_menu_box">
                            <div class="el_flex">
						        <%=Footer2Location%>
                            </div>
					    </ul>
				    </div>
				    <!-- End Footer 2 -->

			    </div>
		    </div>
		</div>
		<!-- End Footer -->
		
		<!-- Start Footer Bar -->
		<div class="el_footer_bar_part">
		    <div id="div_FooterBar">
          <!-- Start Footer Bar Left -->
			    <div id="div_FooterBarLeft" class="el_footer_bar_left">
				    <%=FooterBarLeftLocation%>
			    </div>
          <!-- End Footer Bar Left -->
          <!-- Start Footer Bar Right -->
			    <div id="div_FooterBarRight" class="el_footer_bar_right">
				    <%=FooterBarRightLocation%>
			    </div>
          <!-- End Footer Bar Right -->
		    </div>
        <!-- Start Footer Bar Box -->
		    <div id="div_FooterBarBox" class="el_footer_bar_box">
			    <%=FooterBarBoxLocation%>
		    </div>
        <!-- End Footer Bar Box -->
		</div>
		<!-- End Footer Bar -->

		<div class="el_hidden">
			<%=CurrentLoadTag%>
		</div>
	</body>
	
</html>