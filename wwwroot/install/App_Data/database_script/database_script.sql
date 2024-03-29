USE [$_asp database_name;]
GO
/****** Object:  Table [el_admin_style]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_admin_style](
	[admin_style_id] [int] IDENTITY(1,1) NOT NULL,
	[admin_style_name] [nvarchar](50) NOT NULL,
	[admin_style_directory_path] [nvarchar](800) NOT NULL,
	[admin_style_physical_name] [nvarchar](255) NOT NULL,
	[admin_style_template] [nvarchar](50) NULL,
	[admin_style_load_tag] [nvarchar](max) NULL,
	[admin_style_static_head] [nvarchar](max) NULL,
	[admin_style_active] [bit] NOT NULL,
 CONSTRAINT [PK_el_admin_style] PRIMARY KEY CLUSTERED 
(
	[admin_style_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [el_admin_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_admin_template](
	[admin_template_id] [int] IDENTITY(1,1) NOT NULL,
	[admin_template_name] [nvarchar](50) NOT NULL,
	[admin_template_directory_path] [nvarchar](800) NOT NULL,
	[admin_template_physical_name] [nvarchar](255) NOT NULL,
	[admin_template_load_tag] [nvarchar](max) NULL,
	[admin_template_static_head] [nvarchar](max) NULL,
	[admin_template_active] [bit] NOT NULL,
 CONSTRAINT [PK_el_admin_template] PRIMARY KEY CLUSTERED 
(
	[admin_template_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [el_attachment]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_attachment](
	[attachment_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[attachment_directory_path] [nvarchar](800) NOT NULL,
	[attachment_physical_name] [nvarchar](255) NOT NULL,
	[attachment_name] [nvarchar](50) NOT NULL,
	[attachment_about] [nvarchar](400) NULL,
	[attachment_size] [varchar](13) NOT NULL,
	[attachment_password] [nvarchar](50) NULL,
	[attachment_number_of_visit] [int] NOT NULL,
	[attachment_active] [bit] NOT NULL,
	[attachment_public_access_show] [bit] NOT NULL,
 CONSTRAINT [PK_el_attachment] PRIMARY KEY CLUSTERED 
(
	[attachment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_attachment_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_attachment_access_show](
	[attachment_access_show_id] [int] IDENTITY(1,1) NOT NULL,
	[attachment_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_el_attachment_access_use] PRIMARY KEY CLUSTERED 
(
	[attachment_access_show_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_category]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[site_id] [int] NOT NULL,
	[category_name] [nvarchar](50) NOT NULL,
	[require_approval] [bit] NOT NULL,
	[parent_category] [int] NOT NULL,
	[site_style_id] [int] NULL,
	[site_template_id] [int] NULL,
	[category_active] [bit] NOT NULL,
	[category_public_access_show] [bit] NOT NULL,
 CONSTRAINT [PK_el_category] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_category_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_category_access_show](
	[category_access_show_id] [int] IDENTITY(1,1) NOT NULL,
	[category_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_el_category_access_show] PRIMARY KEY CLUSTERED 
(
	[category_access_show_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_comment]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_comment](
	[comment_id] [int] IDENTITY(1,1) NOT NULL,
	[content_id] [int] NOT NULL,
	[user_id] [int] NULL,
	[parent_comment] [int] NOT NULL,
	[comment_guest_name] [nvarchar](50) NULL,
	[comment_guest_real_name] [nvarchar](50) NULL,
	[comment_guest_real_last_name] [nvarchar](50) NULL,
	[comment_guest_email] [nvarchar](254) NULL,
	[comment_title] [nvarchar](200) NULL,
	[comment_text] [nvarchar](800) NULL,
	[comment_date_send] [char](10) NOT NULL,
	[comment_time_send] [char](8) NOT NULL,
	[comment_active] [bit] NULL,
	[comment_ip_address] [varchar](39) NULL,
	[comment_file_directory_path] [nvarchar](800) NULL,
	[comment_file_physical_name] [nvarchar](255) NULL,
	[comment_type] [varchar](50) NULL,
	[comment_guest_phone_number] [varchar](50) NULL,
	[comment_guest_address] [nvarchar](200) NULL,
	[comment_guest_postal_code] [varchar](50) NULL,
	[comment_guest_about] [varchar](200) NULL,
	[comment_guest_birthday] [char](10) NULL,
	[comment_guest_gender] [bit] NULL,
	[comment_guest_public_email] [nvarchar](254) NULL,
	[comment_guest_mobile_number] [varchar](50) NULL,
	[comment_guest_zip_code] [varchar](10) NULL,
	[comment_guest_country] [nvarchar](50) NULL,
	[comment_guest_state_or_province] [nvarchar](50) NULL,
	[comment_guest_city] [nvarchar](50) NULL,
	[comment_guest_website] [nvarchar](255) NULL,
 CONSTRAINT [PK_el_comments] PRIMARY KEY CLUSTERED 
(
	[comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_component]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_component](
	[component_id] [int] IDENTITY(1,1) NOT NULL,
	[component_name] [nvarchar](50) NOT NULL,
	[component_active] [bit] NOT NULL,
	[component_directory_path] [nvarchar](800) NOT NULL,
	[component_physical_name] [nvarchar](255) NOT NULL,
	[component_load_type] [varchar](10) NOT NULL,
	[component_use_language] [bit] NOT NULL,
	[component_use_module] [bit] NOT NULL,
	[component_use_plugin] [bit] NOT NULL,
	[component_use_replace_part] [bit] NOT NULL,
	[component_use_fetch] [bit] NOT NULL,
	[component_use_item] [bit] NOT NULL,
	[component_use_elanat] [bit] NOT NULL,
	[component_cache_duration] [int] NOT NULL,
	[component_cache_parameters] [nvarchar](200) NULL,
	[component_public_access_add] [bit] NOT NULL,
	[component_public_access_edit_own] [bit] NOT NULL,
	[component_public_access_delete_own] [bit] NOT NULL,
	[component_public_access_edit_all] [bit] NOT NULL,
	[component_public_access_delete_all] [bit] NOT NULL,
	[component_public_access_show] [bit] NOT NULL,
	[component_sort_index] [int] NOT NULL,
	[component_category] [nvarchar](50) NULL,
 CONSTRAINT [PK_el_component] PRIMARY KEY CLUSTERED 
(
	[component_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_component_role_access]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_component_role_access](
	[component_role_access_id] [int] IDENTITY(1,1) NOT NULL,
	[component_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
	[component_add] [bit] NOT NULL,
	[component_edit_own] [bit] NOT NULL,
	[component_delete_own] [bit] NOT NULL,
	[component_edit_all] [bit] NOT NULL,
	[component_delete_all] [bit] NOT NULL,
	[component_show] [bit] NOT NULL,
 CONSTRAINT [PK_el_component_role_access] PRIMARY KEY CLUSTERED 
(
	[component_role_access_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_contact]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_contact](
	[contact_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[contact_guest_name] [nvarchar](50) NULL,
	[contact_guest_real_name] [nvarchar](50) NULL,
	[contact_guest_real_last_name] [nvarchar](50) NULL,
	[contact_guest_email] [nvarchar](254) NULL,
	[contact_title] [nvarchar](200) NULL,
	[contact_text] [nvarchar](800) NULL,
	[contact_date_send] [char](10) NOT NULL,
	[contact_time_send] [char](8) NOT NULL,
	[contact_ip_address] [varchar](39) NULL,
	[contact_file_directory_path] [nvarchar](800) NULL,
	[contact_file_physical_name] [nvarchar](255) NULL,
	[contact_type] [varchar](50) NULL,
	[contact_guest_phone_number] [varchar](50) NULL,
	[contact_guest_address] [nvarchar](200) NULL,
	[contact_guest_postal_code] [varchar](50) NULL,
	[contact_guest_about] [nvarchar](200) NULL,
	[contact_guest_birthday] [char](10) NULL,
	[contact_guest_gender] [bit] NULL,
	[contact_guest_public_email] [nvarchar](254) NULL,
	[contact_guest_mobile_number] [varchar](50) NULL,
	[contact_guest_zip_code] [varchar](10) NULL,
	[contact_guest_country] [nvarchar](50) NULL,
	[contact_guest_state_or_province] [nvarchar](50) NULL,
	[contact_guest_city] [nvarchar](50) NULL,
	[contact_guest_website] [nvarchar](100) NULL,
	[contact_response_code] [char](32) NULL,
	[contact_response_text] [nvarchar](400) NULL,
 CONSTRAINT [PK_el_contact] PRIMARY KEY CLUSTERED 
(
	[contact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_content]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_content](
	[content_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	[content_title] [nvarchar](200) NOT NULL,
	[content_text] [nvarchar](max) NOT NULL,
	[content_date_create] [char](10) NOT NULL,
	[content_time_create] [char](8) NOT NULL,
	[content_always_on_top] [bit] NOT NULL,
	[content_status] [varchar](20) NOT NULL,
	[content_type] [varchar](20) NOT NULL,
	[content_verify_comments] [bit] NOT NULL,
	[content_password] [nvarchar](50) NULL,
	[content_visit] [int] NOT NULL,
	[content_public_access_show] [bit] NOT NULL,
 CONSTRAINT [PK_el_content] PRIMARY KEY CLUSTERED 
(
	[content_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [el_content_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_content_access_show](
	[content_access_show_id] [int] IDENTITY(1,1) NOT NULL,
	[content_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_el_content_access_show] PRIMARY KEY CLUSTERED 
(
	[content_access_show_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_content_attachment]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_content_attachment](
	[content_attachment_id] [int] IDENTITY(1,1) NOT NULL,
	[content_id] [int] NOT NULL,
	[attachment_id] [int] NOT NULL,
 CONSTRAINT [PK_el_content_attachment] PRIMARY KEY CLUSTERED 
(
	[content_attachment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_content_avatar]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_content_avatar](
	[content_avatar_id] [int] IDENTITY(1,1) NOT NULL,
	[content_id] [int] NOT NULL,
	[content_avatar_physical_name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_el_avatar] PRIMARY KEY CLUSTERED 
(
	[content_avatar_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_content_icon]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_content_icon](
	[content_icon_id] [int] IDENTITY(1,1) NOT NULL,
	[content_id] [int] NOT NULL,
	[content_icon_physical_name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_el_icon] PRIMARY KEY CLUSTERED 
(
	[content_icon_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_content_keywords]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_content_keywords](
	[content_keywords_id] [int] IDENTITY(1,1) NOT NULL,
	[content_id] [int] NOT NULL,
	[content_keywords_text] [nvarchar](200) NULL,
 CONSTRAINT [PK_el_keywords] PRIMARY KEY CLUSTERED 
(
	[content_keywords_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_content_rating]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_content_rating](
	[content_rating_id] [int] IDENTITY(1,1) NOT NULL,
	[content_id] [int] NOT NULL,
	[content_rating_number_of_voted] [int] NOT NULL,
	[content_rating_rating] [int] NOT NULL,
 CONSTRAINT [PK_el_rating] PRIMARY KEY CLUSTERED 
(
	[content_rating_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_content_reply]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_content_reply](
	[content_reply_id] [int] IDENTITY(1,1) NOT NULL,
	[content_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[content_reply_guest_name] [nvarchar](50) NULL,
	[content_reply_guest_real_name] [nvarchar](50) NULL,
	[content_reply_guest_real_last_name] [nvarchar](50) NULL,
	[content_reply_guest_email] [nvarchar](254) NULL,
	[content_reply_text] [nvarchar](800) NULL,
	[content_reply_date_send] [char](10) NOT NULL,
	[content_reply_time_send] [char](8) NOT NULL,
	[content_reply_ip_address] [varchar](39) NULL,
	[content_reply_type] [varchar](50) NULL,
	[content_reply_active] [bit] NULL,
	[content_reply_guest_phone_number] [varchar](50) NULL,
	[content_reply_guest_address] [nvarchar](200) NULL,
	[content_reply_guest_postal_code] [varchar](50) NULL,
	[content_reply_guest_about] [varchar](200) NULL,
	[content_reply_guest_birthday] [char](10) NULL,
	[content_reply_guest_gender] [bit] NULL,
	[content_reply_guest_public_email] [nvarchar](254) NULL,
	[content_reply_guest_mobile_number] [varchar](50) NULL,
	[content_reply_guest_zip_code] [varchar](10) NULL,
	[content_reply_guest_country] [nvarchar](50) NULL,
	[content_reply_guest_state_or_province] [nvarchar](50) NULL,
	[content_reply_guest_city] [nvarchar](50) NULL,
	[content_reply_guest_website] [nvarchar](255) NULL,
 CONSTRAINT [PK_el_content_replay] PRIMARY KEY CLUSTERED 
(
	[content_reply_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_content_source]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_content_source](
	[content_source_id] [int] IDENTITY(1,1) NOT NULL,
	[content_id] [int] NOT NULL,
	[content_source_text] [nvarchar](400) NULL,
 CONSTRAINT [PK_el_source] PRIMARY KEY CLUSTERED 
(
	[content_source_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_editor_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_editor_template](
	[editor_template_id] [int] IDENTITY(1,1) NOT NULL,
	[editor_template_name] [nvarchar](50) NOT NULL,
	[editor_template_directory_path] [nvarchar](800) NOT NULL,
	[editor_template_physical_name] [nvarchar](255) NOT NULL,
	[editor_template_use_language] [bit] NOT NULL,
	[editor_template_use_module] [bit] NOT NULL,
	[editor_template_use_plugin] [bit] NOT NULL,
	[editor_template_use_replace_part] [bit] NOT NULL,
	[editor_template_use_fetch] [bit] NOT NULL,
	[editor_template_use_item] [bit] NOT NULL,
	[editor_template_use_elanat] [bit] NOT NULL,
	[editor_template_cache_duration] [int] NOT NULL,
	[editor_template_cache_parameters] [nvarchar](200) NULL,
	[editor_template_active] [bit] NOT NULL,
	[editor_template_public_access_show] [bit] NOT NULL,
	[editor_template_sort_index] [int] NOT NULL,
	[editor_template_category] [nvarchar](50) NULL,
 CONSTRAINT [PK_el_editor_template] PRIMARY KEY CLUSTERED 
(
	[editor_template_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_editor_template_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_editor_template_access_show](
	[editor_template_access_show_id] [int] IDENTITY(1,1) NOT NULL,
	[editor_template_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_el_editor_template_access_show] PRIMARY KEY CLUSTERED 
(
	[editor_template_access_show_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_extra_helper]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_extra_helper](
	[extra_helper_id] [int] IDENTITY(1,1) NOT NULL,
	[extra_helper_name] [nvarchar](50) NOT NULL,
	[extra_helper_directory_path] [nvarchar](800) NOT NULL,
	[extra_helper_physical_name] [nvarchar](255) NOT NULL,
	[extra_helper_use_language] [bit] NOT NULL,
	[extra_helper_use_module] [bit] NOT NULL,
	[extra_helper_use_plugin] [bit] NOT NULL,
	[extra_helper_use_replace_part] [bit] NOT NULL,
	[extra_helper_use_fetch] [bit] NOT NULL,
	[extra_helper_use_item] [bit] NOT NULL,
	[extra_helper_use_elanat] [bit] NOT NULL,
	[extra_helper_cache_duration] [int] NOT NULL,
	[extra_helper_cache_parameters] [nvarchar](200) NULL,
	[extra_helper_active] [bit] NOT NULL,
	[extra_helper_public_access_show] [bit] NOT NULL,
	[extra_helper_sort_index] [int] NOT NULL,
	[extra_helper_category] [nvarchar](50) NULL,
 CONSTRAINT [PK_el_extra_helper] PRIMARY KEY CLUSTERED 
(
	[extra_helper_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_extra_helper_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_extra_helper_access_show](
	[extra_helper_access_show_id] [int] IDENTITY(1,1) NOT NULL,
	[extra_helper_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_el_extra_helper_access_show] PRIMARY KEY CLUSTERED 
(
	[extra_helper_access_show_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_fetch]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_fetch](
	[fetch_id] [int] IDENTITY(1,1) NOT NULL,
	[fetch_name] [nvarchar](50) NOT NULL,
	[fetch_cache_duration] [int] NOT NULL,
	[fetch_sort_index] [int] NOT NULL,
	[fetch_active] [bit] NOT NULL,
	[fetch_public_access_show] [bit] NOT NULL,
	[fetch_category] [nvarchar](50) NULL,
 CONSTRAINT [PK_el_fetch] PRIMARY KEY CLUSTERED 
(
	[fetch_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_fetch_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_fetch_access_show](
	[fetch_access_show_id] [int] IDENTITY(1,1) NOT NULL,
	[fetch_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_el_fetch_access_show] PRIMARY KEY CLUSTERED 
(
	[fetch_access_show_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_foot_print]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_foot_print](
	[foot_print_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[foot_print_event] [varchar](50) NOT NULL,
	[foot_print_value] [varchar](400) NOT NULL,
	[foot_print_path] [nvarchar](400) NOT NULL,
	[foot_print_date_action] [char](10) NOT NULL,
	[foot_print_time_action] [char](8) NOT NULL,
	[foot_print_ip_address] [varchar](39) NULL,
 CONSTRAINT [PK_el_user_foot_print] PRIMARY KEY CLUSTERED 
(
	[foot_print_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_group]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_group](
	[group_id] [int] IDENTITY(1,1) NOT NULL,
	[group_name] [nvarchar](50) NOT NULL,
	[group_active] [bit] NOT NULL,
 CONSTRAINT [PK_el_group] PRIMARY KEY CLUSTERED 
(
	[group_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_group_role]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_group_role](
	[group_role_id] [int] IDENTITY(1,1) NOT NULL,
	[group_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_el_group_role] PRIMARY KEY CLUSTERED 
(
	[group_role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_item]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_item](
	[item_id] [int] IDENTITY(1,1) NOT NULL,
	[item_name] [nvarchar](50) NOT NULL,
	[item_value] [nvarchar](max) NOT NULL,
	[item_use_language] [bit] NOT NULL,
	[item_use_box] [bit] NOT NULL,
	[item_use_elanat] [bit] NOT NULL,
	[item_use_module] [bit] NOT NULL,
	[item_use_plugin] [bit] NOT NULL,
	[item_use_fetch] [bit] NOT NULL,
	[item_use_item] [bit] NOT NULL,
	[item_use_replace_part] [bit] NOT NULL,
	[item_cache_duration] [int] NULL,
	[item_sort_index] [int] NOT NULL,
	[item_active] [bit] NOT NULL,
	[item_public_access_show] [bit] NOT NULL,
 CONSTRAINT [PK_el_link] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [el_item_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_item_access_show](
	[item_access_show_id] [int] IDENTITY(1,1) NOT NULL,
	[item_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_el_item_access_show] PRIMARY KEY CLUSTERED 
(
	[item_access_show_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_language]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_language](
	[language_id] [int] IDENTITY(1,1) NOT NULL,
	[language_name] [nvarchar](50) NOT NULL,
	[language_global_name] [varchar](50) NOT NULL,
	[language_is_right_to_left] [bit] NOT NULL,
	[language_show_link_in_site] [bit] NOT NULL,
	[language_active] [bit] NOT NULL,
	[site_id] [int] NOT NULL,
 CONSTRAINT [PK_el_language] PRIMARY KEY CLUSTERED 
(
	[language_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_link]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_link](
	[link_id] [int] IDENTITY(1,1) NOT NULL,
	[link_value] [nvarchar](400) NOT NULL,
	[link_title] [nvarchar](400) NULL,
	[link_href] [nvarchar](400) NOT NULL,
	[link_rel] [nvarchar](50) NOT NULL,
	[link_target] [varchar](7) NOT NULL,
	[link_sort_index] [int] NOT NULL,
	[link_active] [bit] NOT NULL,
	[link_protocol] [varchar](50) NULL,
 CONSTRAINT [PK_el_link_1] PRIMARY KEY CLUSTERED 
(
	[link_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_menu]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_menu](
	[menu_id] [int] IDENTITY(1,1) NOT NULL,
	[site_id] [int] NOT NULL,
	[menu_name] [nvarchar](50) NOT NULL,
	[menu_location] [varchar](30) NOT NULL,
	[menu_sort_index] [int] NOT NULL,
	[menu_use_box] [bit] NOT NULL,
	[menu_active] [bit] NOT NULL,
	[menu_public_access_show] [bit] NOT NULL,
 CONSTRAINT [PK_el_menu] PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_menu_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_menu_access_show](
	[menu_access_show_id] [int] IDENTITY(1,1) NOT NULL,
	[menu_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_el_menu_acceess_show] PRIMARY KEY CLUSTERED 
(
	[menu_access_show_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_menu_fetch]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_menu_fetch](
	[menu_fetch_id] [int] IDENTITY(1,1) NOT NULL,
	[menu_id] [int] NOT NULL,
	[fetch_id] [int] NOT NULL,
 CONSTRAINT [PK_el_menu_fetch] PRIMARY KEY CLUSTERED 
(
	[menu_fetch_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_menu_item]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_menu_item](
	[menu_item_id] [int] IDENTITY(1,1) NOT NULL,
	[menu_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
 CONSTRAINT [PK_el_menu_item] PRIMARY KEY CLUSTERED 
(
	[menu_item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_menu_link]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_menu_link](
	[menu_link_id] [int] IDENTITY(1,1) NOT NULL,
	[menu_id] [int] NOT NULL,
	[link_id] [int] NOT NULL,
 CONSTRAINT [PK_el_menu_link] PRIMARY KEY CLUSTERED 
(
	[menu_link_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_menu_module]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_menu_module](
	[menu_module_id] [int] IDENTITY(1,1) NOT NULL,
	[menu_id] [int] NOT NULL,
	[module_id] [int] NOT NULL,
	[menu_module_query_string] [nvarchar](400) NULL,
 CONSTRAINT [PK_el_menu_module] PRIMARY KEY CLUSTERED 
(
	[menu_module_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_menu_plugin]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_menu_plugin](
	[menu_plugin_id] [int] IDENTITY(1,1) NOT NULL,
	[menu_id] [int] NOT NULL,
	[plugin_id] [int] NOT NULL,
	[menu_plugin_query_string] [nvarchar](400) NULL,
 CONSTRAINT [PK_el_menu_plugin] PRIMARY KEY CLUSTERED 
(
	[menu_plugin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_module]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_module](
	[module_id] [int] IDENTITY(1,1) NOT NULL,
	[module_name] [nvarchar](50) NOT NULL,
	[module_active] [bit] NOT NULL,
	[module_directory_path] [nvarchar](800) NOT NULL,
	[module_physical_name] [nvarchar](255) NOT NULL,
	[module_load_type] [varchar](10) NOT NULL,
	[module_use_language] [bit] NOT NULL,
	[module_use_module] [bit] NOT NULL,
	[module_use_plugin] [bit] NOT NULL,
	[module_use_replace_part] [bit] NOT NULL,
	[module_use_fetch] [bit] NOT NULL,
	[module_use_item] [bit] NOT NULL,
	[module_use_elanat] [bit] NOT NULL,
	[module_cache_duration] [int] NOT NULL,
	[module_cache_parameters] [nvarchar](200) NULL,
	[module_public_access_add] [bit] NOT NULL,
	[module_public_access_edit_own] [bit] NOT NULL,
	[module_public_access_delete_own] [bit] NOT NULL,
	[module_public_access_edit_all] [bit] NOT NULL,
	[module_public_access_delete_all] [bit] NOT NULL,
	[module_public_access_show] [bit] NOT NULL,
	[module_sort_index] [int] NOT NULL,
	[module_category] [nvarchar](50) NULL,
 CONSTRAINT [PK_el_module] PRIMARY KEY CLUSTERED 
(
	[module_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_module_role_access]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_module_role_access](
	[module_role_access_id] [int] IDENTITY(1,1) NOT NULL,
	[module_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
	[module_add] [bit] NOT NULL,
	[module_edit_own] [bit] NOT NULL,
	[module_delete_own] [bit] NOT NULL,
	[module_edit_all] [bit] NOT NULL,
	[module_delete_all] [bit] NOT NULL,
	[module_show] [bit] NOT NULL,
 CONSTRAINT [PK_el_module_role_access] PRIMARY KEY CLUSTERED 
(
	[module_role_access_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_page]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_page](
	[page_id] [int] IDENTITY(1,1) NOT NULL,
	[page_global_name] [nvarchar](50) NOT NULL,
	[page_name] [nvarchar](50) NOT NULL,
	[user_id] [int] NOT NULL,
	[page_public_site] [bit] NOT NULL,
	[page_title] [nvarchar](400) NULL,
	[page_date_create] [char](10) NOT NULL,
	[page_time_create] [char](8) NOT NULL,
	[page_active] [bit] NOT NULL,
	[page_directory_path] [nvarchar](800) NOT NULL,
	[page_physical_name] [nvarchar](255) NOT NULL,
	[page_use_language] [bit] NOT NULL,
	[page_use_module] [bit] NOT NULL,
	[page_use_plugin] [bit] NOT NULL,
	[page_use_replace_part] [bit] NOT NULL,
	[page_use_fetch] [bit] NOT NULL,
	[page_use_item] [bit] NOT NULL,
	[page_use_elanat] [bit] NOT NULL,
	[page_use_load_tag] [bit] NOT NULL,
	[page_use_static_head] [bit] NOT NULL,
	[page_show_link_in_site] [bit] NOT NULL,
	[page_load_type] [varchar](10) NOT NULL,
	[page_load_tag] [nvarchar](max) NULL,
	[page_static_head] [nvarchar](max) NULL,
	[site_style_id] [int] NOT NULL,
	[site_template_id] [int] NOT NULL,
	[page_load_alone] [bit] NOT NULL,
	[page_cache_duration] [int] NOT NULL,
	[page_cache_parameters] [nvarchar](200) NULL,
	[page_use_classification_meta] [bit] NOT NULL,
	[page_use_copyright_meta] [bit] NOT NULL,
	[page_use_language_meta] [bit] NOT NULL,
	[page_use_robots_meta] [bit] NOT NULL,
	[page_use_application_name_meta] [bit] NOT NULL,
	[page_use_generator_meta] [bit] NOT NULL,
	[page_use_javascript_inactive_refresh_meta] [bit] NOT NULL,
	[page_use_description_meta] [bit] NOT NULL,
	[page_use_revisit_after_meta] [bit] NOT NULL,
	[page_use_rights_meta] [bit] NOT NULL,
	[page_use_keywords_meta] [bit] NOT NULL,
	[page_use_author_meta] [bit] NOT NULL,
	[page_description_meta] [nvarchar](400) NULL,
	[page_revisit_after_meta] [nvarchar](50) NULL,
	[page_rights_meta] [nvarchar](400) NULL,
	[page_keywords_meta] [nvarchar](400) NULL,
	[page_robots_meta] [varchar](20) NULL,
	[page_copyright_meta] [nvarchar](400) NULL,
	[page_classification_meta] [nvarchar](400) NULL,
	[page_visit] [int] NOT NULL,
	[page_use_html] [bit] NOT NULL,
	[page_public_access_show] [bit] NOT NULL,
	[page_query_string] [nvarchar](400) NULL,
	[page_category] [nvarchar](50) NULL,
 CONSTRAINT [PK_el_page] PRIMARY KEY CLUSTERED 
(
	[page_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [el_page_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_page_access_show](
	[page_access_show_id] [int] IDENTITY(1,1) NOT NULL,
	[page_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_el_page_access_show_id] PRIMARY KEY CLUSTERED 
(
	[page_access_show_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_patch]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_patch](
	[patch_id] [int] IDENTITY(1,1) NOT NULL,
	[patch_name] [nvarchar](50) NOT NULL,
	[patch_directory_path] [nvarchar](800) NOT NULL,
	[patch_active] [bit] NOT NULL,
	[patch_category] [nvarchar](50) NULL,
 CONSTRAINT [PK_el_patch] PRIMARY KEY CLUSTERED 
(
	[patch_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_plugin]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_plugin](
	[plugin_id] [int] IDENTITY(1,1) NOT NULL,
	[plugin_name] [nvarchar](50) NOT NULL,
	[plugin_active] [bit] NOT NULL,
	[plugin_directory_path] [nvarchar](800) NOT NULL,
	[plugin_physical_name] [nvarchar](255) NOT NULL,
	[plugin_load_type] [varchar](10) NOT NULL,
	[plugin_use_language] [bit] NOT NULL,
	[plugin_use_module] [bit] NOT NULL,
	[plugin_use_plugin] [bit] NOT NULL,
	[plugin_use_replace_part] [bit] NOT NULL,
	[plugin_use_fetch] [bit] NOT NULL,
	[plugin_use_item] [bit] NOT NULL,
	[plugin_use_elanat] [bit] NOT NULL,
	[plugin_cache_duration] [int] NOT NULL,
	[plugin_cache_parameters] [nvarchar](200) NULL,
	[plugin_public_access_add] [bit] NOT NULL,
	[plugin_public_access_edit_own] [bit] NOT NULL,
	[plugin_public_access_delete_own] [bit] NOT NULL,
	[plugin_public_access_edit_all] [bit] NOT NULL,
	[plugin_public_access_delete_all] [bit] NOT NULL,
	[plugin_public_access_show] [bit] NOT NULL,
	[plugin_sort_index] [int] NOT NULL,
	[plugin_category] [nvarchar](50) NULL,
 CONSTRAINT [PK_el_plugin] PRIMARY KEY CLUSTERED 
(
	[plugin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_plugin_role_access]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_plugin_role_access](
	[plugin_role_access_id] [int] IDENTITY(1,1) NOT NULL,
	[plugin_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
	[plugin_add] [bit] NOT NULL,
	[plugin_edit_own] [bit] NOT NULL,
	[plugin_delete_own] [bit] NOT NULL,
	[plugin_edit_all] [bit] NOT NULL,
	[plugin_delete_all] [bit] NOT NULL,
	[plugin_show] [bit] NOT NULL,
 CONSTRAINT [PK_el_plugin_role_access] PRIMARY KEY CLUSTERED 
(
	[plugin_role_access_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_robot_detection_ip_block]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_robot_detection_ip_block](
	[robot_detection_ip_block_id] [int] IDENTITY(1,1) NOT NULL,
	[robot_detection_ip_block_ip_address] [varchar](39) NULL,
	[robot_detection_ip_block_date_block] [char](10) NOT NULL,
	[robot_detection_ip_block_time_block] [char](8) NOT NULL,
 CONSTRAINT [PK_el_robot_detection_ip_block] PRIMARY KEY CLUSTERED 
(
	[robot_detection_ip_block_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_role]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](50) NOT NULL,
	[role_type] [varchar](6) NOT NULL,
	[role_active] [bit] NOT NULL,
	[role_add_always_on_top_content] [bit] NOT NULL,
	[role_add_free_comment_content] [bit] NOT NULL,
	[role_submit_visit] [bit] NOT NULL,
	[role_submit_foot_print] [bit] NOT NULL,
	[role_approval_comment_only_own_content] [bit] NOT NULL,
	[role_edit_comment_only_own_content] [bit] NOT NULL,
	[role_delete_comment_only_own_content] [bit] NOT NULL,
	[role_reply_comment_only_own_content] [bit] NOT NULL,
	[role_reply_comment_all_content] [bit] NOT NULL,
	[role_upload_file] [bit] NOT NULL,
	[role_add_content_without_approval] [bit] NOT NULL,
	[role_write_html] [bit] NULL,
	[role_write_script] [bit] NULL,
	[role_web_config_configuration] [bit] NULL,
	[role_config_configuration] [bit] NULL,
	[role_authorized_extension_configuration] [bit] NULL,
	[role_content_icon_configuration] [bit] NULL,
	[role_type_configuration] [bit] NULL,
	[role_file_extensions_configuration] [bit] NULL,
	[role_page_location_configuration] [bit] NULL,
	[role_replace_part_configuration] [bit] NULL,
	[role_site_static_head_configuration] [bit] NULL,
	[role_site_dynamic_head_configuration] [bit] NULL,
	[role_admin_static_head_configuration] [bit] NULL,
	[role_admin_dynamic_head_configuration] [bit] NULL,
	[role_global_template_configuration] [bit] NULL,
	[role_global_style_configuration] [bit] NULL,
	[role_global_script_configuration] [bit] NULL,
	[role_site_script_configuration] [bit] NULL,
	[role_admin_script_configuration] [bit] NULL,
	[role_foreign_key_configuration] [bit] NULL,
	[role_struct_configuration] [bit] NULL,
	[role_robots_configuration] [bit] NULL,
	[role_link_protocol_configuration] [bit] NULL,
	[role_scheduled_tasks_configuration] [bit] NULL,
	[role_security_configuration] [bit] NULL,
	[role_calendar_configuration] [bit] NULL,
	[role_box_configuration] [bit] NULL,
	[role_captcha_configuration] [bit] NULL,
	[role_file_viewer_configuration] [bit] NULL,
	[role_wysiwyg_configuration] [bit] NULL,
	[role_role_bit_column_access_configuration] [bit] NULL,
	[role_start_up_configuration] [bit] NULL,
	[role_after_load_path_reference_configuration] [bit] NULL,
	[role_before_load_path_reference_configuration] [bit] NULL,
	[role_default_page_configuration] [bit] NULL,
	[role_dynamic_extension_configuration] [bit] NULL,
	[role_event_reference_configuration] [bit] NULL,
	[role_system_configuration] [bit] NULL,
	[role_client_file_extensions_configuration] [bit] NULL,
	[role_admin_page_load_configuration] [bit] NULL,
	[role_site_page_load_configuration] [bit] NULL,
	[role_admin_global_style_configuration] [bit] NULL,
	[role_site_global_style_configuration] [bit] NULL,
	[role_admin_global_template_configuration] [bit] NULL,
	[role_site_global_template_configuration] [bit] NULL,
	[role_admin_global_location_configuration] [bit] NULL,
	[role_site_global_location_configuration] [bit] NULL,
	[role_url_redirect_configuration] [bit] NULL,
	[role_url_rewrite_configuration] [bit] NULL,
 CONSTRAINT [PK_el_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_site]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_site](
	[site_id] [int] IDENTITY(1,1) NOT NULL,
	[language_id] [int] NULL,
	[site_title] [nvarchar](400) NULL,
	[site_name] [nvarchar](50) NOT NULL,
	[site_global_name] [varchar](50) NOT NULL,
	[site_visit] [int] NOT NULL,
	[page_id] [int] NOT NULL,
	[site_slogan_name] [nvarchar](50) NULL,
	[site_date_create] [char](10) NOT NULL,
	[site_time_create] [char](8) NOT NULL,
	[site_site_activities] [nvarchar](max) NULL,
	[site_address] [nvarchar](max) NULL,
	[site_phone_number] [varchar](50) NULL,
	[site_email] [nvarchar](254) NULL,
	[site_other_info] [nvarchar](max) NULL,
	[admin_style_id] [int] NULL,
	[admin_template_id] [int] NULL,
	[site_style_id] [int] NULL,
	[site_template_id] [int] NULL,
	[site_active] [bit] NOT NULL,
	[site_static_head] [nvarchar](max) NULL,
	[site_use_description_meta] [bit] NOT NULL,
	[site_use_revisit_after_meta] [bit] NOT NULL,
	[site_use_rights_meta] [bit] NOT NULL,
	[site_use_keywords_meta] [bit] NOT NULL,
	[site_use_classification_meta] [bit] NOT NULL,
	[site_description_meta] [nvarchar](400) NULL,
	[site_revisit_after_meta] [nvarchar](50) NULL,
	[site_rights_meta] [nvarchar](400) NULL,
	[site_classification_meta] [nvarchar](400) NULL,
	[site_keywords_meta] [nvarchar](400) NULL,
	[site_show_link_in_site] [bit] NOT NULL,
	[site_calendar] [varchar](50) NULL,
	[site_first_day_of_week] [int] NULL,
	[site_time_zone] [float] NULL,
	[site_date_format] [nvarchar](50) NULL,
	[site_time_format] [nvarchar](50) NULL,
	[site_public_access_show] [bit] NOT NULL,
 CONSTRAINT [PK_el_site] PRIMARY KEY CLUSTERED 
(
	[site_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [el_site_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_site_access_show](
	[site_access_show_id] [int] IDENTITY(1,1) NOT NULL,
	[site_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_el_language_access_use] PRIMARY KEY CLUSTERED 
(
	[site_access_show_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_site_page]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_site_page](
	[site_page_id] [int] IDENTITY(1,1) NOT NULL,
	[site_id] [int] NOT NULL,
	[page_id] [int] NOT NULL,
 CONSTRAINT [PK_el_site_page] PRIMARY KEY CLUSTERED 
(
	[site_page_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_site_style]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_site_style](
	[site_style_id] [int] IDENTITY(1,1) NOT NULL,
	[site_style_name] [nvarchar](50) NOT NULL,
	[site_style_directory_path] [nvarchar](800) NOT NULL,
	[site_style_physical_name] [nvarchar](255) NOT NULL,
	[site_style_template] [nvarchar](50) NULL,
	[site_style_load_tag] [nvarchar](max) NULL,
	[site_style_static_head] [nvarchar](max) NULL,
	[site_style_active] [bit] NOT NULL,
 CONSTRAINT [PK_el_site_style] PRIMARY KEY CLUSTERED 
(
	[site_style_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [el_site_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_site_template](
	[site_template_id] [int] IDENTITY(1,1) NOT NULL,
	[site_template_name] [nvarchar](50) NOT NULL,
	[site_template_directory_path] [nvarchar](800) NOT NULL,
	[site_template_physical_name] [nvarchar](255) NOT NULL,
	[site_template_load_tag] [nvarchar](max) NULL,
	[site_template_static_head] [nvarchar](max) NULL,
	[site_template_active] [bit] NOT NULL,
 CONSTRAINT [PK_el_site_template] PRIMARY KEY CLUSTERED 
(
	[site_template_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [el_user]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](50) NOT NULL,
	[group_id] [int] NOT NULL,
	[user_site_name] [nvarchar](50) NOT NULL,
	[user_real_name] [nvarchar](50) NULL,
	[user_real_last_name] [nvarchar](50) NULL,
	[user_password] [char](32) NOT NULL,
	[user_date_create] [char](10) NOT NULL,
	[user_last_login] [char](19) NULL,
	[user_active] [bit] NOT NULL,
	[user_email] [nvarchar](254) NULL,
	[user_phone_number] [varchar](50) NULL,
	[user_address] [nvarchar](200) NULL,
	[user_postal_code] [varchar](50) NULL,
	[user_about] [varchar](200) NULL,
	[user_birthday] [char](10) NOT NULL,
	[user_gender] [bit] NULL,
	[user_number_of_upload] [int] NOT NULL,
	[user_size_of_upload] [varchar](13) NOT NULL,
	[user_public_email] [nvarchar](254) NULL,
	[user_mobile_number] [varchar](50) NULL,
	[user_zip_code] [varchar](10) NULL,
	[user_email_is_confirm] [bit] NOT NULL,
	[user_other_info] [nvarchar](max) NULL,
	[site_style_id] [int] NULL,
	[site_template_id] [int] NULL,
	[admin_style_id] [int] NULL,
	[admin_template_id] [int] NULL,
	[user_country] [nvarchar](50) NULL,
	[user_state_or_province] [nvarchar](50) NULL,
	[user_city] [nvarchar](50) NULL,
	[user_website] [nvarchar](255) NULL,
	[site_language_id] [int] NULL,
	[admin_language_id] [int] NULL,
	[user_calendar] [varchar](50) NULL,
	[user_first_day_of_week] [int] NULL,
	[user_time_zone] [float] NULL,
	[user_date_format] [nvarchar](50) NULL,
	[user_time_format] [nvarchar](50) NULL,
	[user_day_difference] [int] NULL,
	[user_time_hours_difference] [int] NULL,
	[user_time_minutes_difference] [int] NULL,
	[user_common_light_background_color] [varchar](50) NULL,
	[user_common_light_text_color] [varchar](50) NULL,
	[user_common_middle_background_color] [varchar](50) NULL,
	[user_common_middle_text_color] [varchar](50) NULL,
	[user_common_dark_background_color] [varchar](50) NULL,
	[user_common_dark_text_color] [varchar](50) NULL,
	[user_natural_light_background_color] [varchar](50) NULL,
	[user_natural_light_text_color] [varchar](50) NULL,
	[user_natural_middle_background_color] [varchar](50) NULL,
	[user_natural_middle_text_color] [varchar](50) NULL,
	[user_natural_dark_background_color] [varchar](50) NULL,
	[user_natural_dark_text_color] [varchar](50) NULL,
	[user_background_color] [varchar](50) NULL,
	[user_font_size] [int] NULL,
	[user_user_info_background_color] [varchar](50) NULL,
	[user_user_info_font_color] [varchar](50) NULL,
	[user_show_user_avatar_in_user_info] [bit] NOT NULL,
	[user_show_user_online_in_user_info] [bit] NOT NULL,
	[user_show_user_email_in_user_info] [bit] NOT NULL,
	[user_show_user_birthday_in_user_info] [bit] NOT NULL,
	[user_show_user_gender_in_user_info] [bit] NOT NULL,
	[user_show_user_phone_number_in_user_info] [bit] NOT NULL,
	[user_show_user_mobile_number_in_user_info] [bit] NOT NULL,
	[user_show_user_country_in_user_info] [bit] NOT NULL,
	[user_show_user_state_or_province_in_user_info] [bit] NOT NULL,
	[user_show_user_city_in_user_info] [bit] NOT NULL,
	[user_show_user_zip_code_in_user_info] [bit] NOT NULL,
	[user_show_user_postal_code_in_user_info] [bit] NOT NULL,
	[user_show_user_address_in_user_info] [bit] NOT NULL,
	[user_show_user_website_in_user_info] [bit] NOT NULL,
	[user_show_user_last_login_in_user_info] [bit] NOT NULL,
 CONSTRAINT [PK_el_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [el_view]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_view](
	[view_id] [int] IDENTITY(1,1) NOT NULL,
	[view_name] [nvarchar](50) NOT NULL,
	[view_match_type] [varchar](10) NOT NULL,
	[view_include_header_bar_part] [bit] NOT NULL,
	[view_show_header_bar_left] [bit] NOT NULL,
	[view_show_header_bar_right] [bit] NOT NULL,
	[view_show_header_bar_box] [bit] NOT NULL,
	[view_fill_header_bar_left] [bit] NOT NULL,
	[view_fill_header_bar_right] [bit] NOT NULL,
	[view_fill_header_bar_box] [bit] NOT NULL,
	[view_include_header_part] [bit] NOT NULL,
	[view_show_header_menu] [bit] NOT NULL,
	[view_show_header1] [bit] NOT NULL,
	[view_show_header2] [bit] NOT NULL,
	[view_fill_header_menu] [bit] NOT NULL,
	[view_fill_header1] [bit] NOT NULL,
	[view_fill_header2] [bit] NOT NULL,
	[view_include_menu_part] [bit] NOT NULL,
	[view_show_menu] [bit] NOT NULL,
	[view_fill_menu] [bit] NOT NULL,
	[view_include_main_part] [bit] NOT NULL,
	[view_show_after_header] [bit] NOT NULL,
	[view_show_before_content] [bit] NOT NULL,
	[view_show_after_content] [bit] NOT NULL,
	[view_show_right_menu] [bit] NOT NULL,
	[view_show_left_menu] [bit] NOT NULL,
	[view_show_before_footer] [bit] NOT NULL,
	[view_fill_after_header] [bit] NOT NULL,
	[view_fill_before_content] [bit] NOT NULL,
	[view_fill_after_content] [bit] NOT NULL,
	[view_fill_right_menu] [bit] NOT NULL,
	[view_fill_left_menu] [bit] NOT NULL,
	[view_fill_before_footer] [bit] NOT NULL,
	[view_include_footer_part] [bit] NOT NULL,
	[view_show_footer_menu] [bit] NOT NULL,
	[view_show_footer1] [bit] NOT NULL,
	[view_show_footer2] [bit] NOT NULL,
	[view_fill_footer_menu] [bit] NOT NULL,
	[view_fill_footer1] [bit] NOT NULL,
	[view_fill_footer2] [bit] NOT NULL,
	[view_include_footer_bar_part] [bit] NOT NULL,
	[view_show_footer_bar_left] [bit] NOT NULL,
	[view_show_footer_bar_right] [bit] NOT NULL,
	[view_show_footer_bar_box] [bit] NOT NULL,
	[view_fill_footer_bar_left] [bit] NOT NULL,
	[view_fill_footer_bar_right] [bit] NOT NULL,
	[view_fill_footer_bar_box] [bit] NOT NULL,
	[view_common_light_background_color] [varchar](50) NULL,
	[view_common_light_text_color] [varchar](50) NULL,
	[view_common_middle_background_color] [varchar](50) NULL,
	[view_common_middle_text_color] [varchar](50) NULL,
	[view_common_dark_background_color] [varchar](50) NULL,
	[view_common_dark_text_color] [varchar](50) NULL,
	[view_natural_light_background_color] [varchar](50) NULL,
	[view_natural_light_text_color] [varchar](50) NULL,
	[view_natural_middle_background_color] [varchar](50) NULL,
	[view_natural_middle_text_color] [varchar](50) NULL,
	[view_natural_dark_background_color] [varchar](50) NULL,
	[view_natural_dark_text_color] [varchar](50) NULL,
	[view_background_color] [varchar](50) NULL,
	[view_font_size] [int] NULL,
	[view_static_head] [nvarchar](max) NULL,
	[site_style_id] [int] NOT NULL,
	[site_template_id] [int] NOT NULL,
	[view_active] [bit] NOT NULL,
 CONSTRAINT [PK_el_view] PRIMARY KEY CLUSTERED 
(
	[view_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [el_view_query_string]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_view_query_string](
	[view_query_string_id] [int] IDENTITY(1,1) NOT NULL,
	[view_id] [int] NOT NULL,
	[view_query_string] [nvarchar](400) NOT NULL,
 CONSTRAINT [PK_el_view_query_string] PRIMARY KEY CLUSTERED 
(
	[view_query_string_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [el_visit_statistics]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [el_visit_statistics](
	[visit_statistics_id] [int] IDENTITY(1,1) NOT NULL,
	[visit_statistics_date_visit] [char](10) NOT NULL,
	[visit_statistics_visit] [int] NOT NULL,
 CONSTRAINT [PK_el_visit_statistics] PRIMARY KEY CLUSTERED 
(
	[visit_statistics_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [el_admin_style] ON 

INSERT [el_admin_style] ([admin_style_id], [admin_style_name], [admin_style_directory_path], [admin_style_physical_name], [admin_style_template], [admin_style_load_tag], [admin_style_static_head], [admin_style_active]) VALUES (1, N'work_frame_gray', N'work_frame_gray', N'work_frame_gray.css', N'work_frame', NULL, NULL, 1)
SET IDENTITY_INSERT [el_admin_style] OFF
GO
SET IDENTITY_INSERT [el_admin_template] ON 

INSERT [el_admin_template] ([admin_template_id], [admin_template_name], [admin_template_directory_path], [admin_template_physical_name], [admin_template_load_tag], [admin_template_static_head], [admin_template_active]) VALUES (1, N'work_frame', N'work_frame', N'work_frame.xml', NULL, NULL, 1)
SET IDENTITY_INSERT [el_admin_template] OFF
GO
SET IDENTITY_INSERT [el_category] ON 

INSERT [el_category] ([category_id], [site_id], [category_name], [require_approval], [parent_category], [site_style_id], [site_template_id], [category_active], [category_public_access_show]) VALUES (1, 1, N'news', 0, 0, 0, 0, 1, 1)
INSERT [el_category] ([category_id], [site_id], [category_name], [require_approval], [parent_category], [site_style_id], [site_template_id], [category_active], [category_public_access_show]) VALUES (2, 1, N'document', 0, 0, 0, 0, 1, 1)
INSERT [el_category] ([category_id], [site_id], [category_name], [require_approval], [parent_category], [site_style_id], [site_template_id], [category_active], [category_public_access_show]) VALUES (3, 1, N'video', 0, 0, 0, 0, 1, 1)
SET IDENTITY_INSERT [el_category] OFF
GO
SET IDENTITY_INSERT [el_component] ON 

INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (1, N'about', 1, N'about', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'home')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (2, N'add_content', 1, N'add_content', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'content_id,is_edit', 0, 0, 0, 0, 0, 0, 0, N'content')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (3, N'approval_comment', 1, N'approval_comment', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'home')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (4, N'approval_content', 1, N'approval_content', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'home')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (5, N'attachment', 1, N'attachment', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'file_and_directory')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (6, N'backup', 1, N'backup', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'tools')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (7, N'category', 1, N'category', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'content')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (8, N'comment', 1, N'comment', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'content')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (9, N'component', 1, N'component', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'add_ons')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (10, N'configuration', 1, N'configuration', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'tools')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (11, N'contact', 1, N'contact', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'home')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (12, N'content', 1, N'content', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'content')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (13, N'dashboard', 1, N'dashboard', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'home')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (14, N'editor_template', 1, N'editor_template', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'add_ons')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (15, N'extra_helper', 1, N'extra_helper', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'add_ons')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (16, N'file_manager', 1, N'file_manager', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'directory,search,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'file_and_directory')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (17, N'foot_print', 1, N'foot_print', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'users')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (18, N'item', 1, N'item', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'content')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (19, N'language', 1, N'language', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'tools')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (20, N'link', 1, N'link', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'content')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (21, N'menu', 1, N'menu', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'content')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (22, N'module', 1, N'module', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'add_ons')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (23, N'options', 1, N'options', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'tools')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (24, N'page', 1, N'page', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'content')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (25, N'plugin', 1, N'plugin', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'add_ons')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (26, N'profile', 1, N'profile', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'users')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (27, N'properties', 1, N'properties', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'tools')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (28, N'recycle_bin', 1, N'recycle_bin', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'home')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (29, N'refresh', 1, N'refresh', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'home')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (30, N'content_reply', 1, N'content_reply', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'content')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (31, N'role', 1, N'role', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'users')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (32, N'site', 1, N'site', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'tools')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (33, N'statistics', 1, N'statistics', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'home')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (34, N'admin_style', 1, N'admin_style', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'appearance')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (35, N'site_style', 1, N'site_style', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'appearance')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (36, N'admin_template', 1, N'admin_template', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'appearance')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (37, N'site_template', 1, N'site_template', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'appearance')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (38, N'user', 1, N'user', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'users')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (39, N'view', 1, N'view', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'appearance')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (40, N'fetch', 1, N'fetch', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'add_ons')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (41, N'patch', 1, N'patch', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'add_ons')
INSERT [el_component] ([component_id], [component_name], [component_active], [component_directory_path], [component_physical_name], [component_load_type], [component_use_language], [component_use_module], [component_use_plugin], [component_use_replace_part], [component_use_fetch], [component_use_item], [component_use_elanat], [component_cache_duration], [component_cache_parameters], [component_public_access_add], [component_public_access_edit_own], [component_public_access_delete_own], [component_public_access_edit_all], [component_public_access_delete_all], [component_public_access_show], [component_sort_index], [component_category]) VALUES (42, N'group', 1, N'group', N'Default.aspx', N'iframe', 0, 0, 0, 0, 0, 0, 0, 0, N'search,page,column_name,is_desc', 0, 0, 0, 0, 0, 0, 0, N'users')
SET IDENTITY_INSERT [el_component] OFF
GO
SET IDENTITY_INSERT [el_component_role_access] ON 

INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (1, 6, 5, 1, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (2, 6, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (3, 9, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (4, 10, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (5, 16, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (6, 17, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (7, 17, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (8, 19, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (9, 23, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (10, 25, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (11, 27, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (12, 29, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (13, 31, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (14, 32, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (15, 32, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (16, 33, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (17, 33, 7, 0, 0, 0, 1, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (18, 34, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (19, 35, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (20, 36, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (21, 38, 5, 1, 1, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (22, 38, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (23, 39, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (24, 22, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (25, 41, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (26, 40, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (27, 2, 2, 1, 1, 1, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (28, 2, 3, 0, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (29, 2, 5, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (30, 2, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (31, 3, 2, 0, 1, 1, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (32, 3, 3, 0, 1, 1, 1, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (33, 3, 5, 0, 1, 1, 1, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (34, 3, 7, 0, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (35, 4, 3, 0, 0, 0, 1, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (36, 4, 5, 0, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (37, 4, 7, 0, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (38, 5, 2, 1, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (39, 5, 3, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (40, 5, 5, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (41, 5, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (42, 8, 2, 1, 1, 1, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (43, 8, 3, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (44, 8, 5, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (45, 8, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (46, 11, 2, 1, 1, 1, 0, 0, 0)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (47, 11, 3, 1, 1, 1, 1, 0, 0)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (48, 11, 5, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (49, 11, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (50, 12, 2, 1, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (51, 12, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (52, 12, 5, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (53, 12, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (54, 13, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (55, 13, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (56, 13, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (57, 13, 7, 0, 0, 0, 1, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (58, 14, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (59, 14, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (60, 14, 5, 1, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (61, 14, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (62, 15, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (63, 15, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (64, 15, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (65, 15, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (66, 18, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (67, 18, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (68, 18, 5, 1, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (69, 18, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (70, 20, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (71, 20, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (72, 20, 5, 1, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (73, 20, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (74, 21, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (75, 21, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (76, 21, 5, 1, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (77, 21, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (78, 24, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (79, 24, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (80, 24, 5, 1, 1, 1, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (81, 24, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (82, 26, 2, 0, 0, 0, 1, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (83, 26, 3, 0, 0, 0, 1, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (84, 26, 5, 0, 0, 0, 1, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (85, 26, 7, 0, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (86, 28, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (87, 28, 3, 0, 0, 0, 1, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (88, 28, 5, 0, 1, 1, 1, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (89, 28, 7, 0, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (90, 30, 2, 1, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (91, 30, 3, 1, 1, 1, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (92, 30, 5, 1, 1, 1, 1, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (93, 30, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (94, 37, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (95, 42, 7, 1, 0, 0, 1, 1, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (96, 7, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (97, 7, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (98, 7, 5, 1, 1, 1, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (99, 7, 7, 1, 1, 1, 1, 1, 1)
GO
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (100, 1, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (101, 1, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (102, 1, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_component_role_access] ([component_role_access_id], [component_id], [role_id], [component_add], [component_edit_own], [component_delete_own], [component_edit_all], [component_delete_all], [component_show]) VALUES (103, 1, 7, 1, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [el_component_role_access] OFF
GO
SET IDENTITY_INSERT [el_content] ON 

INSERT [el_content] ([content_id], [user_id], [category_id], [content_title], [content_text], [content_date_create], [content_time_create], [content_always_on_top], [content_status], [content_type], [content_verify_comments], [content_password], [content_visit], [content_public_access_show]) VALUES (1, 1, 1, N'First Content Example', N'<p>This is your first content in main page. you can login to admin panel and edit or delete this content<br /><br />click on <a href="/page/login/">login</a>, to going in login page.</p>', N'2023/08/31', N'00:00:00', 0, N'active', N'post', 1, N'', 0, 1)
SET IDENTITY_INSERT [el_content] OFF
GO
SET IDENTITY_INSERT [el_content_rating] ON 

INSERT [el_content_rating] ([content_rating_id], [content_id], [content_rating_number_of_voted], [content_rating_rating]) VALUES (1, 1, 0, 0)
SET IDENTITY_INSERT [el_content_rating] OFF
GO
SET IDENTITY_INSERT [el_editor_template] ON 

INSERT [el_editor_template] ([editor_template_id], [editor_template_name], [editor_template_directory_path], [editor_template_physical_name], [editor_template_use_language], [editor_template_use_module], [editor_template_use_plugin], [editor_template_use_replace_part], [editor_template_use_fetch], [editor_template_use_item], [editor_template_use_elanat], [editor_template_cache_duration], [editor_template_cache_parameters], [editor_template_active], [editor_template_public_access_show], [editor_template_sort_index], [editor_template_category]) VALUES (1, N'plus14', N'plus14', N'plus14.html', 1, 0, 0, 0, 0, 0, 0, 0, NULL, 1, 1, 0, N'image')
INSERT [el_editor_template] ([editor_template_id], [editor_template_name], [editor_template_directory_path], [editor_template_physical_name], [editor_template_use_language], [editor_template_use_module], [editor_template_use_plugin], [editor_template_use_replace_part], [editor_template_use_fetch], [editor_template_use_item], [editor_template_use_elanat], [editor_template_cache_duration], [editor_template_cache_parameters], [editor_template_active], [editor_template_public_access_show], [editor_template_sort_index], [editor_template_category]) VALUES (2, N'image_preview', N'image_preview', N'image_preview.html', 1, 0, 0, 0, 0, 0, 0, 0, NULL, 1, 1, 0, N'image')
SET IDENTITY_INSERT [el_editor_template] OFF
GO
SET IDENTITY_INSERT [el_extra_helper] ON 

INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (1, N'inner_xml_to_html', N'inner_xml_to_html', N'index.html', 1, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 4, N'home')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (2, N'html_to_inner_xml', N'html_to_inner_xml', N'index.html', 1, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 4, N'home')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (3, N'admin_note', N'admin_note', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'page', 1, 0, 2, N'')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (4, N'show_logs_list', N'show_logs_list', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 1, N'')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (5, N'show_extra_helper_list', N'show_extra_helper_list', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 0, N'')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (6, N'show_admin_component_access_view', N'show_admin_component_access_view', N'index.html', 0, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 3, N'')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (7, N'upload_file', N'upload_file', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 0, N'content')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (8, N'content_avatar', N'content_avatar', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'path', 1, 0, 0, N'content')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (9, N'site_logo', N'site_logo', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 0, N'content')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (10, N'rss_option', N'rss_option', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 4, N'home')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (11, N'search_option', N'search_option', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 4, N'home')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (12, N'xml_sitemap_option', N'xml_sitemap_option', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 4, N'home')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (13, N'sitemap_option', N'sitemap_option', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 4, N'home')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (14, N'comment_option', N'comment_option', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 0, N'content')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (15, N'content_reply_option', N'content_reply_option', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 0, N'content')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (16, N'contact_option', N'contact_option', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 4, N'home')
INSERT [el_extra_helper] ([extra_helper_id], [extra_helper_name], [extra_helper_directory_path], [extra_helper_physical_name], [extra_helper_use_language], [extra_helper_use_module], [extra_helper_use_plugin], [extra_helper_use_replace_part], [extra_helper_use_fetch], [extra_helper_use_item], [extra_helper_use_elanat], [extra_helper_cache_duration], [extra_helper_cache_parameters], [extra_helper_active], [extra_helper_public_access_show], [extra_helper_sort_index], [extra_helper_category]) VALUES (17, N'sign_up_option', N'sign_up_option', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, N'', 1, 0, 0, N'users')
SET IDENTITY_INSERT [el_extra_helper] OFF
GO
SET IDENTITY_INSERT [el_extra_helper_access_show] ON 

INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (1, 1, 2)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (2, 1, 3)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (3, 1, 5)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (4, 1, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (5, 2, 2)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (6, 2, 3)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (7, 2, 5)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (8, 2, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (9, 3, 2)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (10, 3, 3)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (11, 3, 5)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (12, 3, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (13, 4, 2)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (14, 4, 3)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (15, 4, 5)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (16, 4, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (17, 5, 2)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (18, 5, 3)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (19, 5, 5)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (20, 5, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (21, 7, 2)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (22, 7, 3)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (23, 7, 5)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (24, 7, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (25, 8, 2)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (26, 8, 3)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (27, 8, 5)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (28, 8, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (29, 10, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (30, 11, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (31, 13, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (32, 14, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (33, 15, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (34, 16, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (35, 17, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (36, 9, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (37, 12, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (38, 6, 7)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (39, 6, 5)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (40, 6, 3)
INSERT [el_extra_helper_access_show] ([extra_helper_access_show_id], [extra_helper_id], [role_id]) VALUES (41, 6, 2)
SET IDENTITY_INSERT [el_extra_helper_access_show] OFF
GO
SET IDENTITY_INSERT [el_group] ON 

INSERT [el_group] ([group_id], [group_name], [group_active]) VALUES (1, N'guest', 1)
INSERT [el_group] ([group_id], [group_name], [group_active]) VALUES (2, N'manager', 1)
INSERT [el_group] ([group_id], [group_name], [group_active]) VALUES (3, N'confirming', 1)
INSERT [el_group] ([group_id], [group_name], [group_active]) VALUES (4, N'administrator', 1)
INSERT [el_group] ([group_id], [group_name], [group_active]) VALUES (5, N'member', 1)
SET IDENTITY_INSERT [el_group] OFF
GO
SET IDENTITY_INSERT [el_group_role] ON 

INSERT [el_group_role] ([group_role_id], [group_id], [role_id]) VALUES (1, 1, 1)
INSERT [el_group_role] ([group_role_id], [group_id], [role_id]) VALUES (2, 2, 2)
INSERT [el_group_role] ([group_role_id], [group_id], [role_id]) VALUES (3, 2, 3)
INSERT [el_group_role] ([group_role_id], [group_id], [role_id]) VALUES (4, 2, 4)
INSERT [el_group_role] ([group_role_id], [group_id], [role_id]) VALUES (5, 2, 5)
INSERT [el_group_role] ([group_role_id], [group_id], [role_id]) VALUES (6, 2, 6)
INSERT [el_group_role] ([group_role_id], [group_id], [role_id]) VALUES (7, 4, 6)
INSERT [el_group_role] ([group_role_id], [group_id], [role_id]) VALUES (8, 4, 7)
INSERT [el_group_role] ([group_role_id], [group_id], [role_id]) VALUES (9, 5, 8)
INSERT [el_group_role] ([group_role_id], [group_id], [role_id]) VALUES (10, 3, 8)
INSERT [el_group_role] ([group_role_id], [group_id], [role_id]) VALUES (11, 3, 6)
SET IDENTITY_INSERT [el_group_role] OFF
GO
SET IDENTITY_INSERT [el_item] ON 

INSERT [el_item] ([item_id], [item_name], [item_value], [item_use_language], [item_use_box], [item_use_elanat], [item_use_module], [item_use_plugin], [item_use_fetch], [item_use_item], [item_use_replace_part], [item_cache_duration], [item_sort_index], [item_active], [item_public_access_show]) VALUES (1, N'admin_panel', N'<a href="$_elanat ::system admin_directory_path;/" class="el_admin_link_in_site">$_lang admin_panel;</a>', 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0)
INSERT [el_item] ([item_id], [item_name], [item_value], [item_use_language], [item_use_box], [item_use_elanat], [item_use_module], [item_use_plugin], [item_use_fetch], [item_use_item], [item_use_replace_part], [item_cache_duration], [item_sort_index], [item_active], [item_public_access_show]) VALUES (2, N'user_info_logout', N'<div class="el_user_box">
	<a href="$_elanat ::system site_path;page/logout/" title="$_lang logout;">
		<div class="el_logout"></div>
	</a>
	<a href="$_elanat ::system site_path;page_content/user_info/" title="$_lang user_info;">
		<img class="el_avatar" src="$_elanat ::system site_path;client/image/user_avatar/$_elanat ::user user_id;.png">
	</a>
</div>', 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0)
INSERT [el_item] ([item_id], [item_name], [item_value], [item_use_language], [item_use_box], [item_use_elanat], [item_use_module], [item_use_plugin], [item_use_fetch], [item_use_item], [item_use_replace_part], [item_cache_duration], [item_sort_index], [item_active], [item_public_access_show]) VALUES (3, N'login', N'<a href="$_elanat ::system site_path;page/login/" class="el_admin_link_in_site">$_lang login;</a>', 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0)
INSERT [el_item] ([item_id], [item_name], [item_value], [item_use_language], [item_use_box], [item_use_elanat], [item_use_module], [item_use_plugin], [item_use_fetch], [item_use_item], [item_use_replace_part], [item_cache_duration], [item_sort_index], [item_active], [item_public_access_show]) VALUES (4, N'sign_up', N'<a href="$_elanat ::system site_path;page_content/sign_up/" class="el_admin_link_in_site">$_lang sign_up;</a>', 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0)
INSERT [el_item] ([item_id], [item_name], [item_value], [item_use_language], [item_use_box], [item_use_elanat], [item_use_module], [item_use_plugin], [item_use_fetch], [item_use_item], [item_use_replace_part], [item_cache_duration], [item_sort_index], [item_active], [item_public_access_show]) VALUES (5, N'copyright', N'$_lang _elanat_coprright;', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1)
SET IDENTITY_INSERT [el_item] OFF
GO
SET IDENTITY_INSERT [el_item_access_show] ON 

INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (1, 5, 8)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (2, 5, 7)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (3, 5, 6)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (4, 5, 4)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (5, 5, 2)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (6, 1, 7)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (7, 1, 6)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (8, 1, 5)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (9, 1, 4)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (10, 1, 3)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (11, 1, 2)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (12, 3, 1)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (13, 2, 8)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (14, 2, 7)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (15, 2, 6)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (16, 2, 5)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (17, 2, 4)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (18, 2, 3)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (19, 2, 2)
INSERT [el_item_access_show] ([item_access_show_id], [item_id], [role_id]) VALUES (20, 4, 1)
SET IDENTITY_INSERT [el_item_access_show] OFF
GO
SET IDENTITY_INSERT [el_language] ON 

INSERT [el_language] ([language_id], [language_name], [language_global_name], [language_is_right_to_left], [language_show_link_in_site], [language_active], [site_id]) VALUES (1, N'english', N'en', 0, 1, 1, 0)
INSERT [el_language] ([language_id], [language_name], [language_global_name], [language_is_right_to_left], [language_show_link_in_site], [language_active], [site_id]) VALUES (2, N'persian', N'fa', 1, 1, 0, 0)
SET IDENTITY_INSERT [el_language] OFF
GO
SET IDENTITY_INSERT [el_menu] ON 

INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (1, 1, N'content type', N'right_menu', 0, 1, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (2, 1, N'site path', N'right_menu', 0, 1, 1, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (3, 1, N'language', N'right_menu', 0, 1, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (4, 1, N'page', N'right_menu', 0, 1, 1, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (5, 1, N'member page', N'right_menu', 0, 1, 1, 0)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (6, 1, N'admin panel', N'header_bar_right', 0, 0, 1, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (7, 1, N'login - sign up', N'header_bar_right', 0, 0, 1, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (8, 1, N'site', N'right_menu', 0, 1, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (9, 1, N'calander', N'right_menu', 0, 1, 1, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (10, 1, N'change category', N'right_menu', 0, 1, 1, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (11, 1, N'language extra drop down list', N'header_1', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (12, 1, N'quick search', N'right_menu', 0, 1, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (13, 1, N'footer_1_1', N'footer_1', 0, 1, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (14, 1, N'footer_1_2', N'footer_1', 0, 1, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (15, 1, N'footer_1_3', N'footer_1', 0, 1, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (16, 1, N'footer_1_4', N'footer_1', 0, 1, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (17, 1, N'footer_2_1', N'footer_2', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (18, 1, N'footer_2_2', N'footer_2', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (19, 1, N'footer_2_3', N'footer_2', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (20, 1, N'footer_2_4', N'footer_2', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (21, 1, N'header_1_1', N'header_1', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (22, 1, N'header_1_2', N'header_1', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (23, 1, N'header_1_3', N'header_1', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (24, 1, N'header_1_4', N'header_1', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (25, 1, N'header_2_1', N'header_2', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (26, 1, N'header_2_2', N'header_2', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (27, 1, N'header_2_3', N'header_2', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (28, 1, N'header_2_4', N'header_2', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (29, 1, N'change site', N'right_menu', 0, 1, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (30, 1, N'change language', N'right_menu', 0, 1, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (31, 1, N'search', N'left_menu', 0, 1, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (32, 1, N'clock', N'left_menu', 0, 1, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (33, 1, N'link', N'right_menu', 0, 1, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (34, 1, N'copyright', N'footer_bar_box', 0, 0, 1, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (35, 1, N'after_header', N'after_header', 0, 0, 0, 1)
INSERT [el_menu] ([menu_id], [site_id], [menu_name], [menu_location], [menu_sort_index], [menu_use_box], [menu_active], [menu_public_access_show]) VALUES (36, 1, N'accept_cookie_message', N'header_bar_box', 0, 0, 1, 1)
SET IDENTITY_INSERT [el_menu] OFF
GO
SET IDENTITY_INSERT [el_menu_access_show] ON 

INSERT [el_menu_access_show] ([menu_access_show_id], [menu_id], [role_id]) VALUES (1, 5, 2)
INSERT [el_menu_access_show] ([menu_access_show_id], [menu_id], [role_id]) VALUES (2, 5, 3)
INSERT [el_menu_access_show] ([menu_access_show_id], [menu_id], [role_id]) VALUES (3, 5, 4)
INSERT [el_menu_access_show] ([menu_access_show_id], [menu_id], [role_id]) VALUES (4, 5, 5)
INSERT [el_menu_access_show] ([menu_access_show_id], [menu_id], [role_id]) VALUES (5, 5, 6)
INSERT [el_menu_access_show] ([menu_access_show_id], [menu_id], [role_id]) VALUES (6, 5, 7)
INSERT [el_menu_access_show] ([menu_access_show_id], [menu_id], [role_id]) VALUES (7, 5, 8)
SET IDENTITY_INSERT [el_menu_access_show] OFF
GO
SET IDENTITY_INSERT [el_menu_item] ON 

INSERT [el_menu_item] ([menu_item_id], [menu_id], [item_id]) VALUES (1, 6, 1)
INSERT [el_menu_item] ([menu_item_id], [menu_id], [item_id]) VALUES (2, 6, 2)
INSERT [el_menu_item] ([menu_item_id], [menu_id], [item_id]) VALUES (3, 7, 3)
INSERT [el_menu_item] ([menu_item_id], [menu_id], [item_id]) VALUES (4, 34, 5)
INSERT [el_menu_item] ([menu_item_id], [menu_id], [item_id]) VALUES (5, 7, 4)
SET IDENTITY_INSERT [el_menu_item] OFF
GO
SET IDENTITY_INSERT [el_menu_plugin] ON 

INSERT [el_menu_plugin] ([menu_plugin_id], [menu_id], [plugin_id], [menu_plugin_query_string]) VALUES (1, 1, 11, NULL)
INSERT [el_menu_plugin] ([menu_plugin_id], [menu_id], [plugin_id], [menu_plugin_query_string]) VALUES (2, 3, 30, NULL)
INSERT [el_menu_plugin] ([menu_plugin_id], [menu_id], [plugin_id], [menu_plugin_query_string]) VALUES (3, 4, 10, NULL)
INSERT [el_menu_plugin] ([menu_plugin_id], [menu_id], [plugin_id], [menu_plugin_query_string]) VALUES (4, 5, 9, NULL)
INSERT [el_menu_plugin] ([menu_plugin_id], [menu_id], [plugin_id], [menu_plugin_query_string]) VALUES (5, 8, 8, NULL)
INSERT [el_menu_plugin] ([menu_plugin_id], [menu_id], [plugin_id], [menu_plugin_query_string]) VALUES (6, 9, 7, NULL)
INSERT [el_menu_plugin] ([menu_plugin_id], [menu_id], [plugin_id], [menu_plugin_query_string]) VALUES (7, 10, 6, NULL)
INSERT [el_menu_plugin] ([menu_plugin_id], [menu_id], [plugin_id], [menu_plugin_query_string]) VALUES (8, 11, 5, NULL)
INSERT [el_menu_plugin] ([menu_plugin_id], [menu_id], [plugin_id], [menu_plugin_query_string]) VALUES (9, 12, 4, NULL)
INSERT [el_menu_plugin] ([menu_plugin_id], [menu_id], [plugin_id], [menu_plugin_query_string]) VALUES (10, 29, 1, NULL)
INSERT [el_menu_plugin] ([menu_plugin_id], [menu_id], [plugin_id], [menu_plugin_query_string]) VALUES (11, 30, 3, NULL)
INSERT [el_menu_plugin] ([menu_plugin_id], [menu_id], [plugin_id], [menu_plugin_query_string]) VALUES (12, 36, 20, NULL)
SET IDENTITY_INSERT [el_menu_plugin] OFF
GO
SET IDENTITY_INSERT [el_module] ON 

INSERT [el_module] ([module_id], [module_name], [module_active], [module_directory_path], [module_physical_name], [module_load_type], [module_use_language], [module_use_module], [module_use_plugin], [module_use_replace_part], [module_use_fetch], [module_use_item], [module_use_elanat], [module_cache_duration], [module_cache_parameters], [module_public_access_add], [module_public_access_edit_own], [module_public_access_delete_own], [module_public_access_edit_all], [module_public_access_delete_all], [module_public_access_show], [module_sort_index], [module_category]) VALUES (1, N'today_activity', 1, N'today_activity', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'home')
INSERT [el_module] ([module_id], [module_name], [module_active], [module_directory_path], [module_physical_name], [module_load_type], [module_use_language], [module_use_module], [module_use_plugin], [module_use_replace_part], [module_use_fetch], [module_use_item], [module_use_elanat], [module_cache_duration], [module_cache_parameters], [module_public_access_add], [module_public_access_edit_own], [module_public_access_delete_own], [module_public_access_edit_all], [module_public_access_delete_all], [module_public_access_show], [module_sort_index], [module_category]) VALUES (2, N'information', 1, N'information', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'home')
INSERT [el_module] ([module_id], [module_name], [module_active], [module_directory_path], [module_physical_name], [module_load_type], [module_use_language], [module_use_module], [module_use_plugin], [module_use_replace_part], [module_use_fetch], [module_use_item], [module_use_elanat], [module_cache_duration], [module_cache_parameters], [module_public_access_add], [module_public_access_edit_own], [module_public_access_delete_own], [module_public_access_edit_all], [module_public_access_delete_all], [module_public_access_show], [module_sort_index], [module_category]) VALUES (3, N'last_data', 1, N'last_data', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'home')
SET IDENTITY_INSERT [el_module] OFF
GO
SET IDENTITY_INSERT [el_module_role_access] ON 

INSERT [el_module_role_access] ([module_role_access_id], [module_id], [role_id], [module_add], [module_edit_own], [module_delete_own], [module_edit_all], [module_delete_all], [module_show]) VALUES (1, 2, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_module_role_access] ([module_role_access_id], [module_id], [role_id], [module_add], [module_edit_own], [module_delete_own], [module_edit_all], [module_delete_all], [module_show]) VALUES (2, 2, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_module_role_access] ([module_role_access_id], [module_id], [role_id], [module_add], [module_edit_own], [module_delete_own], [module_edit_all], [module_delete_all], [module_show]) VALUES (3, 2, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_module_role_access] ([module_role_access_id], [module_id], [role_id], [module_add], [module_edit_own], [module_delete_own], [module_edit_all], [module_delete_all], [module_show]) VALUES (4, 2, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_module_role_access] ([module_role_access_id], [module_id], [role_id], [module_add], [module_edit_own], [module_delete_own], [module_edit_all], [module_delete_all], [module_show]) VALUES (5, 3, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_module_role_access] ([module_role_access_id], [module_id], [role_id], [module_add], [module_edit_own], [module_delete_own], [module_edit_all], [module_delete_all], [module_show]) VALUES (6, 3, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_module_role_access] ([module_role_access_id], [module_id], [role_id], [module_add], [module_edit_own], [module_delete_own], [module_edit_all], [module_delete_all], [module_show]) VALUES (7, 3, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_module_role_access] ([module_role_access_id], [module_id], [role_id], [module_add], [module_edit_own], [module_delete_own], [module_edit_all], [module_delete_all], [module_show]) VALUES (8, 3, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_module_role_access] ([module_role_access_id], [module_id], [role_id], [module_add], [module_edit_own], [module_delete_own], [module_edit_all], [module_delete_all], [module_show]) VALUES (9, 1, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_module_role_access] ([module_role_access_id], [module_id], [role_id], [module_add], [module_edit_own], [module_delete_own], [module_edit_all], [module_delete_all], [module_show]) VALUES (10, 1, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_module_role_access] ([module_role_access_id], [module_id], [role_id], [module_add], [module_edit_own], [module_delete_own], [module_edit_all], [module_delete_all], [module_show]) VALUES (11, 1, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_module_role_access] ([module_role_access_id], [module_id], [role_id], [module_add], [module_edit_own], [module_delete_own], [module_edit_all], [module_delete_all], [module_show]) VALUES (12, 1, 7, 1, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [el_module_role_access] OFF
GO
SET IDENTITY_INSERT [el_page] ON 

INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (1, N'main', N'main_page', 1, 1, N'main_page', N'2023/08/31', N'00:00:00', 1, N'main', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, N'server', N'		<script>
			el_SetZoneRating();
		</script>', NULL, 0, 0, 0, 0, N'page,category,site,content_type', 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (2, N'content', N'content', 1, 1, N'content', N'2023/08/31', N'00:00:00', 1, N'content', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, N'server', N'		<script>
			el_SetZoneRating();
		</script>', NULL, 0, 0, 0, 0, N'content_id', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (3, N'contact', N'contact', 1, 1, N'contact', N'2023/08/31', N'00:00:00', 1, N'contact', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, N'server', N'<script>
	el_CreateWysiwyg();
</script>', NULL, 0, 0, 0, 0, N'contact_type', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (4, N'error', N'error', 1, 1, N'error', N'2023/08/31', N'00:00:00', 1, N'error', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, N'value', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (5, N'login', N'login', 1, 1, N'login', N'2023/08/31', N'00:00:00', 1, N'login', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, N'server', NULL, NULL, 0, 0, 1, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (6, N'logout', N'logout', 1, 1, N'logout', N'2023/08/31', N'00:00:00', 1, N'logout', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 1, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (7, N'print', N'print', 1, 1, N'print', N'2023/08/31', N'00:00:00', 1, N'print', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 1, 0, N'content_id', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (8, N'search', N'search', 1, 1, N'search', N'2023/08/31', N'00:00:00', 1, N'search', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, N'server', NULL, NULL, 0, 0, 0, 0, N'type,search,page,from_date,until_date,category', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (9, N'sign_up', N'sign_up', 1, 1, N'sign_up', N'2023/08/31', N'00:00:00', 1, N'sign_up', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (10, N'sitemap', N'sitemap', 1, 1, N'sitemap', N'2023/08/31', N'00:00:00', 1, N'sitemap', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (11, N'rss', N'rss', 1, 1, N'rss', N'2023/08/31', N'00:00:00', 1, N'rss', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (12, N'about', N'about', 1, 1, N'about', N'2023/08/31', N'00:00:00', 1, N'about', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (13, N'forget_password', N'forget_password', 1, 1, N'forget_password', N'2023/08/31', N'00:00:00', 1, N'forget_password', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (14, N'comment', N'comment', 1, 1, N'comment', N'2023/08/31', N'00:00:00', 1, N'comment', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, N'content_id,comment_id,comment_type', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (15, N'content_reply', N'content_reply', 1, 1, N'content_reply', N'2023/08/31', N'00:00:00', 1, N'content_reply', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, N'content_id,content_reply_type', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (16, N'change_date_and_time', N'change_date_and_time', 1, 1, N'change_date_and_time', N'2023/08/31', N'00:00:00', 1, N'member/change_options/change_date_and_time', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, N'member')
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (17, N'change_language', N'change_language', 1, 1, N'change_language', N'2023/08/31', N'00:00:00', 1, N'member/change_options/change_language', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, N'member')
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (18, N'change_template_and_style', N'change_template_and_style', 1, 1, N'change_template_and_style', N'2023/08/31', N'00:00:00', 1, N'member/change_options/change_template_and_style', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, N'member')
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (19, N'change_view', N'change_view', 1, 1, N'change_view', N'2023/08/31', N'00:00:00', 1, N'member/change_options/change_view', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, N'member')
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (20, N'change_profile', N'change_profile', 1, 1, N'change_profile', N'2023/08/31', N'00:00:00', 1, N'member/change_profile', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, N'member')
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (21, N'change_avatar', N'change_avatar', 1, 1, N'change_avatar', N'2023/08/31', N'00:00:00', 1, N'member/change_profile/change_avatar', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, N'member')
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (22, N'change_email', N'change_email', 1, 1, N'change_email', N'2023/08/31', N'00:00:00', 1, N'member/change_profile/change_email', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, N'member')
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (23, N'change_password', N'change_password', 1, 1, N'change_password', N'2023/08/31', N'00:00:00', 1, N'member/change_profile/change_password', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, N'member')
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (24, N'user_comment', N'user_comment', 1, 1, N'user_comment', N'2023/08/31', N'00:00:00', 1, N'member/user_comment', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, N'<script src="$_asp site_path;page/member/user_comment/script/comment.js"></script>', 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, N'member')
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (25, N'user_content', N'user_content', 1, 1, N'user_content', N'2023/08/31', N'00:00:00', 1, N'member/user_content', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, N'<script  src="$_asp site_path;page/member/user_content/script/content.js"></script>', 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, N'member')
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (26, N'user_foot_print', N'user_foot_print', 1, 1, N'user_foot_print', N'2023/08/31', N'00:00:00', 1, N'member/user_foot_print', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, N'<script src="$_asp site_path;page/member/user_foot_print/script/foot_print.js"></script>', 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, N'member')
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (27, N'user_info', N'user_info', 1, 1, N'user_info', N'2023/08/31', N'00:00:00', 1, N'member/user_info', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, N'member')
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (28, N'user_statistics', N'user_statistics', 1, 1, N'user_statistics', N'2023/08/31', N'00:00:00', 1, N'member/user_statistics', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, N'member')
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (29, N'contact_response', N'contact_response', 1, 1, N'contact_response', N'2023/08/31', N'00:00:00', 1, N'contact/contact_response', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (30, N'user_agreement', N'user_agreement', 1, 1, N'user_agreement', N'2023/08/31', N'00:00:00', 1, N'user_agreement', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (31, N'privacy_policy', N'privacy_policy', 1, 1, N'privacy_policy', N'2023/08/31', N'00:00:00', 1, N'privacy_policy', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (32, N'terms_of_service', N'terms_of_service', 1, 1, N'terms_of_service', N'2023/08/31', N'00:00:00', 1, N'terms_of_service', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (33, N'email', N'email', 1, 1, N'email', N'2023/08/31', N'00:00:00', 1, N'email', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'server', NULL, NULL, 0, 0, 0, 0, N'content_id', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (34, N'confirm_email', N'confirm_email', 1, 1, N'confirm_email', N'2023/08/31', N'00:00:00', 1, N'confirm_email', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, N'server', NULL, NULL, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (35, N'robot_detect_captcha', N'robot_detect_captcha', 1, 1, N'robot_detect_captcha', N'2023/08/31', N'00:00:00', 1, N'robot_detect_captcha', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'server', NULL, NULL, 0, 0, 1, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
INSERT [el_page] ([page_id], [page_global_name], [page_name], [user_id], [page_public_site], [page_title], [page_date_create], [page_time_create], [page_active], [page_directory_path], [page_physical_name], [page_use_language], [page_use_module], [page_use_plugin], [page_use_replace_part], [page_use_fetch], [page_use_item], [page_use_elanat], [page_use_load_tag], [page_use_static_head], [page_show_link_in_site], [page_load_type], [page_load_tag], [page_static_head], [site_style_id], [site_template_id], [page_load_alone], [page_cache_duration], [page_cache_parameters], [page_use_classification_meta], [page_use_copyright_meta], [page_use_language_meta], [page_use_robots_meta], [page_use_application_name_meta], [page_use_generator_meta], [page_use_javascript_inactive_refresh_meta], [page_use_description_meta], [page_use_revisit_after_meta], [page_use_rights_meta], [page_use_keywords_meta], [page_use_author_meta], [page_description_meta], [page_revisit_after_meta], [page_rights_meta], [page_keywords_meta], [page_robots_meta], [page_copyright_meta], [page_classification_meta], [page_visit], [page_use_html], [page_public_access_show], [page_query_string], [page_category]) VALUES (36, N'public_user_info', N'public_user_info', 1, 1, N'public_user_info', N'2023/08/31', N'00:00:00', 1, N'public_user_info', N'Default.aspx', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, N'server', NULL, NULL, 0, 0, 0, 0, N'user_id', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 1, NULL, NULL)
SET IDENTITY_INSERT [el_page] OFF
GO
SET IDENTITY_INSERT [el_page_access_show] ON 

INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (1, 28, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (2, 28, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (3, 28, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (4, 28, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (5, 28, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (6, 28, 7)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (7, 28, 8)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (8, 27, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (9, 27, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (10, 27, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (11, 27, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (12, 27, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (13, 27, 7)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (14, 27, 8)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (15, 16, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (16, 16, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (17, 16, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (18, 16, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (19, 16, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (20, 16, 7)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (21, 16, 8)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (22, 17, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (23, 17, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (24, 17, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (25, 17, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (26, 17, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (27, 17, 7)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (28, 17, 8)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (29, 19, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (30, 19, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (31, 19, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (32, 19, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (33, 19, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (34, 19, 7)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (35, 19, 8)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (36, 20, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (37, 20, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (38, 20, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (39, 20, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (40, 20, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (41, 20, 7)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (42, 20, 8)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (43, 21, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (44, 21, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (45, 21, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (46, 21, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (47, 21, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (48, 21, 7)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (49, 21, 8)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (50, 22, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (51, 22, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (52, 22, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (53, 22, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (54, 22, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (55, 22, 7)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (56, 22, 8)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (57, 23, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (58, 23, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (59, 23, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (60, 23, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (61, 23, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (62, 23, 7)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (63, 23, 8)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (64, 18, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (65, 18, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (66, 18, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (67, 18, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (68, 18, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (69, 18, 7)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (70, 18, 8)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (71, 26, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (72, 26, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (73, 26, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (74, 26, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (75, 26, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (76, 26, 7)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (77, 26, 8)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (78, 25, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (79, 25, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (80, 25, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (81, 25, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (82, 25, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (83, 25, 7)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (84, 25, 8)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (85, 24, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (86, 24, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (87, 24, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (88, 24, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (89, 24, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (90, 24, 7)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (91, 24, 8)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (92, 15, 2)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (93, 15, 3)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (94, 15, 4)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (95, 15, 5)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (96, 15, 6)
INSERT [el_page_access_show] ([page_access_show_id], [page_id], [role_id]) VALUES (97, 15, 7)
SET IDENTITY_INSERT [el_page_access_show] OFF
GO
SET IDENTITY_INSERT [el_patch] ON 

INSERT [el_patch] ([patch_id], [patch_name], [patch_directory_path], [patch_active], [patch_category]) VALUES (1, N'lock_login', N'lock_login', 0, NULL)
INSERT [el_patch] ([patch_id], [patch_name], [patch_directory_path], [patch_active], [patch_category]) VALUES (2, N'rss', N'rss', 1, NULL)
INSERT [el_patch] ([patch_id], [patch_name], [patch_directory_path], [patch_active], [patch_category]) VALUES (3, N'sitemap', N'sitemap', 1, NULL)
SET IDENTITY_INSERT [el_patch] OFF
GO
SET IDENTITY_INSERT [el_plugin] ON 

INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (1, N'show_site_ddlst', 1, N'show_site_drop_down_list', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 1, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (2, N'show_admin_user_menu', 1, N'show_admin_user_menu', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (3, N'show_language_ddlst', 1, N'show_language_drop_down_list', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 1, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (4, N'show_quick_search', 1, N'show_quick_search', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 1, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (5, N'show_language_extra_ddlst', 1, N'show_language_extra_drop_down_list', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 1, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (6, N'show_category_ddlst', 1, N'show_category_drop_down_list', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 1, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (7, N'show_calander', 1, N'show_calendar', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 1, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (8, N'show_site', 1, N'show_site', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 1, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (9, N'show_member_page', 1, N'show_member_page', N'Default.aspx', N'ajax', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (10, N'show_page', 1, N'show_page', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 1, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (11, N'show_content_type', 1, N'show_content_type', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 1, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (12, N'show_admin_system_menu', 1, N'show_admin_system_menu', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (13, N'show_admin_component_group', 1, N'show_admin_component_group', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (14, N'show_admin_module_group', 1, N'show_admin_module_group', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (15, N'show_admin_extra_helper_group', 1, N'show_admin_extra_helper_group', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (16, N'show_admin_language_extra_ddlst', 1, N'show_admin_language_drop_down_list', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (17, N'show_admin_site_ddlst', 1, N'show_admin_site_drop_down_list', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (18, N'show_current_site', 1, N'show_current_site', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (19, N'directory_text_file', 1, N'directory_text_file', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [el_plugin] ([plugin_id], [plugin_name], [plugin_active], [plugin_directory_path], [plugin_physical_name], [plugin_load_type], [plugin_use_language], [plugin_use_module], [plugin_use_plugin], [plugin_use_replace_part], [plugin_use_fetch], [plugin_use_item], [plugin_use_elanat], [plugin_cache_duration], [plugin_cache_parameters], [plugin_public_access_add], [plugin_public_access_edit_own], [plugin_public_access_delete_own], [plugin_public_access_edit_all], [plugin_public_access_delete_all], [plugin_public_access_show], [plugin_sort_index], [plugin_category]) VALUES (20, N'show_accept_cookie_message', 1, N'show_accept_cookie_message', N'Default.aspx', N'server', 0, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 1, 0, N'')
SET IDENTITY_INSERT [el_plugin] OFF
GO
SET IDENTITY_INSERT [el_plugin_role_access] ON 

INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (1, 1, 7, 1, 1, 1, 1, 1, 0)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (2, 2, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (3, 2, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (4, 2, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (5, 2, 6, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (6, 2, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (7, 3, 7, 1, 1, 1, 1, 1, 0)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (8, 4, 7, 1, 1, 1, 1, 1, 0)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (9, 5, 7, 1, 1, 1, 1, 1, 0)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (10, 7, 7, 1, 1, 1, 1, 1, 0)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (11, 8, 7, 1, 1, 1, 1, 1, 0)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (12, 10, 7, 1, 1, 1, 1, 1, 0)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (13, 11, 7, 1, 1, 1, 1, 1, 0)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (14, 12, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (15, 12, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (16, 12, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (17, 12, 6, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (18, 12, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (19, 13, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (20, 13, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (21, 13, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (22, 13, 6, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (23, 13, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (24, 14, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (25, 14, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (26, 14, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (27, 14, 6, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (28, 14, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (29, 15, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (30, 15, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (31, 15, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (32, 15, 6, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (33, 15, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (34, 16, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (35, 16, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (36, 16, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (37, 16, 6, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (38, 16, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (39, 17, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (40, 17, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (41, 17, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (42, 17, 6, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (43, 17, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (44, 18, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (45, 18, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (46, 18, 7, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (47, 6, 7, 1, 1, 1, 1, 1, 0)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (48, 9, 6, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (49, 9, 7, 1, 1, 1, 1, 1, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (50, 9, 8, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (51, 9, 2, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (52, 9, 3, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (53, 9, 4, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (54, 9, 5, 0, 0, 0, 0, 0, 1)
INSERT [el_plugin_role_access] ([plugin_role_access_id], [plugin_id], [role_id], [plugin_add], [plugin_edit_own], [plugin_delete_own], [plugin_edit_all], [plugin_delete_all], [plugin_show]) VALUES (55, 19, 7, 1, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [el_plugin_role_access] OFF
GO
SET IDENTITY_INSERT [el_role] ON 

INSERT [el_role] ([role_id], [role_name], [role_type], [role_active], [role_add_always_on_top_content], [role_add_free_comment_content], [role_submit_visit], [role_submit_foot_print], [role_approval_comment_only_own_content], [role_edit_comment_only_own_content], [role_delete_comment_only_own_content], [role_reply_comment_only_own_content], [role_reply_comment_all_content], [role_upload_file], [role_add_content_without_approval], [role_write_html], [role_write_script], [role_web_config_configuration], [role_config_configuration], [role_authorized_extension_configuration], [role_content_icon_configuration], [role_type_configuration], [role_file_extensions_configuration], [role_page_location_configuration], [role_replace_part_configuration], [role_site_static_head_configuration], [role_site_dynamic_head_configuration], [role_admin_static_head_configuration], [role_admin_dynamic_head_configuration], [role_global_template_configuration], [role_global_style_configuration], [role_global_script_configuration], [role_site_script_configuration], [role_admin_script_configuration], [role_foreign_key_configuration], [role_struct_configuration], [role_robots_configuration], [role_link_protocol_configuration], [role_scheduled_tasks_configuration], [role_security_configuration], [role_calendar_configuration], [role_box_configuration], [role_captcha_configuration], [role_file_viewer_configuration], [role_wysiwyg_configuration], [role_role_bit_column_access_configuration], [role_start_up_configuration], [role_after_load_path_reference_configuration], [role_before_load_path_reference_configuration], [role_default_page_configuration], [role_dynamic_extension_configuration], [role_event_reference_configuration], [role_system_configuration], [role_client_file_extensions_configuration], [role_admin_page_load_configuration], [role_site_page_load_configuration], [role_admin_global_style_configuration], [role_site_global_style_configuration], [role_admin_global_template_configuration], [role_site_global_template_configuration], [role_admin_global_location_configuration], [role_site_global_location_configuration], [role_url_redirect_configuration], [role_url_rewrite_configuration]) VALUES (1, N'guest', N'guest', 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [el_role] ([role_id], [role_name], [role_type], [role_active], [role_add_always_on_top_content], [role_add_free_comment_content], [role_submit_visit], [role_submit_foot_print], [role_approval_comment_only_own_content], [role_edit_comment_only_own_content], [role_delete_comment_only_own_content], [role_reply_comment_only_own_content], [role_reply_comment_all_content], [role_upload_file], [role_add_content_without_approval], [role_write_html], [role_write_script], [role_web_config_configuration], [role_config_configuration], [role_authorized_extension_configuration], [role_content_icon_configuration], [role_type_configuration], [role_file_extensions_configuration], [role_page_location_configuration], [role_replace_part_configuration], [role_site_static_head_configuration], [role_site_dynamic_head_configuration], [role_admin_static_head_configuration], [role_admin_dynamic_head_configuration], [role_global_template_configuration], [role_global_style_configuration], [role_global_script_configuration], [role_site_script_configuration], [role_admin_script_configuration], [role_foreign_key_configuration], [role_struct_configuration], [role_robots_configuration], [role_link_protocol_configuration], [role_scheduled_tasks_configuration], [role_security_configuration], [role_calendar_configuration], [role_box_configuration], [role_captcha_configuration], [role_file_viewer_configuration], [role_wysiwyg_configuration], [role_role_bit_column_access_configuration], [role_start_up_configuration], [role_after_load_path_reference_configuration], [role_before_load_path_reference_configuration], [role_default_page_configuration], [role_dynamic_extension_configuration], [role_event_reference_configuration], [role_system_configuration], [role_client_file_extensions_configuration], [role_admin_page_load_configuration], [role_site_page_load_configuration], [role_admin_global_style_configuration], [role_site_global_style_configuration], [role_admin_global_template_configuration], [role_site_global_template_configuration], [role_admin_global_location_configuration], [role_site_global_location_configuration], [role_url_redirect_configuration], [role_url_rewrite_configuration]) VALUES (2, N'author', N'admin', 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [el_role] ([role_id], [role_name], [role_type], [role_active], [role_add_always_on_top_content], [role_add_free_comment_content], [role_submit_visit], [role_submit_foot_print], [role_approval_comment_only_own_content], [role_edit_comment_only_own_content], [role_delete_comment_only_own_content], [role_reply_comment_only_own_content], [role_reply_comment_all_content], [role_upload_file], [role_add_content_without_approval], [role_write_html], [role_write_script], [role_web_config_configuration], [role_config_configuration], [role_authorized_extension_configuration], [role_content_icon_configuration], [role_type_configuration], [role_file_extensions_configuration], [role_page_location_configuration], [role_replace_part_configuration], [role_site_static_head_configuration], [role_site_dynamic_head_configuration], [role_admin_static_head_configuration], [role_admin_dynamic_head_configuration], [role_global_template_configuration], [role_global_style_configuration], [role_global_script_configuration], [role_site_script_configuration], [role_admin_script_configuration], [role_foreign_key_configuration], [role_struct_configuration], [role_robots_configuration], [role_link_protocol_configuration], [role_scheduled_tasks_configuration], [role_security_configuration], [role_calendar_configuration], [role_box_configuration], [role_captcha_configuration], [role_file_viewer_configuration], [role_wysiwyg_configuration], [role_role_bit_column_access_configuration], [role_start_up_configuration], [role_after_load_path_reference_configuration], [role_before_load_path_reference_configuration], [role_default_page_configuration], [role_dynamic_extension_configuration], [role_event_reference_configuration], [role_system_configuration], [role_client_file_extensions_configuration], [role_admin_page_load_configuration], [role_site_page_load_configuration], [role_admin_global_style_configuration], [role_site_global_style_configuration], [role_admin_global_template_configuration], [role_site_global_template_configuration], [role_admin_global_location_configuration], [role_site_global_location_configuration], [role_url_redirect_configuration], [role_url_rewrite_configuration]) VALUES (3, N'editor', N'admin', 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [el_role] ([role_id], [role_name], [role_type], [role_active], [role_add_always_on_top_content], [role_add_free_comment_content], [role_submit_visit], [role_submit_foot_print], [role_approval_comment_only_own_content], [role_edit_comment_only_own_content], [role_delete_comment_only_own_content], [role_reply_comment_only_own_content], [role_reply_comment_all_content], [role_upload_file], [role_add_content_without_approval], [role_write_html], [role_write_script], [role_web_config_configuration], [role_config_configuration], [role_authorized_extension_configuration], [role_content_icon_configuration], [role_type_configuration], [role_file_extensions_configuration], [role_page_location_configuration], [role_replace_part_configuration], [role_site_static_head_configuration], [role_site_dynamic_head_configuration], [role_admin_static_head_configuration], [role_admin_dynamic_head_configuration], [role_global_template_configuration], [role_global_style_configuration], [role_global_script_configuration], [role_site_script_configuration], [role_admin_script_configuration], [role_foreign_key_configuration], [role_struct_configuration], [role_robots_configuration], [role_link_protocol_configuration], [role_scheduled_tasks_configuration], [role_security_configuration], [role_calendar_configuration], [role_box_configuration], [role_captcha_configuration], [role_file_viewer_configuration], [role_wysiwyg_configuration], [role_role_bit_column_access_configuration], [role_start_up_configuration], [role_after_load_path_reference_configuration], [role_before_load_path_reference_configuration], [role_default_page_configuration], [role_dynamic_extension_configuration], [role_event_reference_configuration], [role_system_configuration], [role_client_file_extensions_configuration], [role_admin_page_load_configuration], [role_site_page_load_configuration], [role_admin_global_style_configuration], [role_site_global_style_configuration], [role_admin_global_template_configuration], [role_site_global_template_configuration], [role_admin_global_location_configuration], [role_site_global_location_configuration], [role_url_redirect_configuration], [role_url_rewrite_configuration]) VALUES (4, N'super_users', N'member', 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [el_role] ([role_id], [role_name], [role_type], [role_active], [role_add_always_on_top_content], [role_add_free_comment_content], [role_submit_visit], [role_submit_foot_print], [role_approval_comment_only_own_content], [role_edit_comment_only_own_content], [role_delete_comment_only_own_content], [role_reply_comment_only_own_content], [role_reply_comment_all_content], [role_upload_file], [role_add_content_without_approval], [role_write_html], [role_write_script], [role_web_config_configuration], [role_config_configuration], [role_authorized_extension_configuration], [role_content_icon_configuration], [role_type_configuration], [role_file_extensions_configuration], [role_page_location_configuration], [role_replace_part_configuration], [role_site_static_head_configuration], [role_site_dynamic_head_configuration], [role_admin_static_head_configuration], [role_admin_dynamic_head_configuration], [role_global_template_configuration], [role_global_style_configuration], [role_global_script_configuration], [role_site_script_configuration], [role_admin_script_configuration], [role_foreign_key_configuration], [role_struct_configuration], [role_robots_configuration], [role_link_protocol_configuration], [role_scheduled_tasks_configuration], [role_security_configuration], [role_calendar_configuration], [role_box_configuration], [role_captcha_configuration], [role_file_viewer_configuration], [role_wysiwyg_configuration], [role_role_bit_column_access_configuration], [role_start_up_configuration], [role_after_load_path_reference_configuration], [role_before_load_path_reference_configuration], [role_default_page_configuration], [role_dynamic_extension_configuration], [role_event_reference_configuration], [role_system_configuration], [role_client_file_extensions_configuration], [role_admin_page_load_configuration], [role_site_page_load_configuration], [role_admin_global_style_configuration], [role_site_global_style_configuration], [role_admin_global_template_configuration], [role_site_global_template_configuration], [role_admin_global_location_configuration], [role_site_global_location_configuration], [role_url_redirect_configuration], [role_url_rewrite_configuration]) VALUES (5, N'manager', N'admin', 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [el_role] ([role_id], [role_name], [role_type], [role_active], [role_add_always_on_top_content], [role_add_free_comment_content], [role_submit_visit], [role_submit_foot_print], [role_approval_comment_only_own_content], [role_edit_comment_only_own_content], [role_delete_comment_only_own_content], [role_reply_comment_only_own_content], [role_reply_comment_all_content], [role_upload_file], [role_add_content_without_approval], [role_write_html], [role_write_script], [role_web_config_configuration], [role_config_configuration], [role_authorized_extension_configuration], [role_content_icon_configuration], [role_type_configuration], [role_file_extensions_configuration], [role_page_location_configuration], [role_replace_part_configuration], [role_site_static_head_configuration], [role_site_dynamic_head_configuration], [role_admin_static_head_configuration], [role_admin_dynamic_head_configuration], [role_global_template_configuration], [role_global_style_configuration], [role_global_script_configuration], [role_site_script_configuration], [role_admin_script_configuration], [role_foreign_key_configuration], [role_struct_configuration], [role_robots_configuration], [role_link_protocol_configuration], [role_scheduled_tasks_configuration], [role_security_configuration], [role_calendar_configuration], [role_box_configuration], [role_captcha_configuration], [role_file_viewer_configuration], [role_wysiwyg_configuration], [role_role_bit_column_access_configuration], [role_start_up_configuration], [role_after_load_path_reference_configuration], [role_before_load_path_reference_configuration], [role_default_page_configuration], [role_dynamic_extension_configuration], [role_event_reference_configuration], [role_system_configuration], [role_client_file_extensions_configuration], [role_admin_page_load_configuration], [role_site_page_load_configuration], [role_admin_global_style_configuration], [role_site_global_style_configuration], [role_admin_global_template_configuration], [role_site_global_template_configuration], [role_admin_global_location_configuration], [role_site_global_location_configuration], [role_url_redirect_configuration], [role_url_rewrite_configuration]) VALUES (6, N'confirming', N'member', 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [el_role] ([role_id], [role_name], [role_type], [role_active], [role_add_always_on_top_content], [role_add_free_comment_content], [role_submit_visit], [role_submit_foot_print], [role_approval_comment_only_own_content], [role_edit_comment_only_own_content], [role_delete_comment_only_own_content], [role_reply_comment_only_own_content], [role_reply_comment_all_content], [role_upload_file], [role_add_content_without_approval], [role_write_html], [role_write_script], [role_web_config_configuration], [role_config_configuration], [role_authorized_extension_configuration], [role_content_icon_configuration], [role_type_configuration], [role_file_extensions_configuration], [role_page_location_configuration], [role_replace_part_configuration], [role_site_static_head_configuration], [role_site_dynamic_head_configuration], [role_admin_static_head_configuration], [role_admin_dynamic_head_configuration], [role_global_template_configuration], [role_global_style_configuration], [role_global_script_configuration], [role_site_script_configuration], [role_admin_script_configuration], [role_foreign_key_configuration], [role_struct_configuration], [role_robots_configuration], [role_link_protocol_configuration], [role_scheduled_tasks_configuration], [role_security_configuration], [role_calendar_configuration], [role_box_configuration], [role_captcha_configuration], [role_file_viewer_configuration], [role_wysiwyg_configuration], [role_role_bit_column_access_configuration], [role_start_up_configuration], [role_after_load_path_reference_configuration], [role_before_load_path_reference_configuration], [role_default_page_configuration], [role_dynamic_extension_configuration], [role_event_reference_configuration], [role_system_configuration], [role_client_file_extensions_configuration], [role_admin_page_load_configuration], [role_site_page_load_configuration], [role_admin_global_style_configuration], [role_site_global_style_configuration], [role_admin_global_template_configuration], [role_site_global_template_configuration], [role_admin_global_location_configuration], [role_site_global_location_configuration], [role_url_redirect_configuration], [role_url_rewrite_configuration]) VALUES (7, N'administrator', N'admin', 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
INSERT [el_role] ([role_id], [role_name], [role_type], [role_active], [role_add_always_on_top_content], [role_add_free_comment_content], [role_submit_visit], [role_submit_foot_print], [role_approval_comment_only_own_content], [role_edit_comment_only_own_content], [role_delete_comment_only_own_content], [role_reply_comment_only_own_content], [role_reply_comment_all_content], [role_upload_file], [role_add_content_without_approval], [role_write_html], [role_write_script], [role_web_config_configuration], [role_config_configuration], [role_authorized_extension_configuration], [role_content_icon_configuration], [role_type_configuration], [role_file_extensions_configuration], [role_page_location_configuration], [role_replace_part_configuration], [role_site_static_head_configuration], [role_site_dynamic_head_configuration], [role_admin_static_head_configuration], [role_admin_dynamic_head_configuration], [role_global_template_configuration], [role_global_style_configuration], [role_global_script_configuration], [role_site_script_configuration], [role_admin_script_configuration], [role_foreign_key_configuration], [role_struct_configuration], [role_robots_configuration], [role_link_protocol_configuration], [role_scheduled_tasks_configuration], [role_security_configuration], [role_calendar_configuration], [role_box_configuration], [role_captcha_configuration], [role_file_viewer_configuration], [role_wysiwyg_configuration], [role_role_bit_column_access_configuration], [role_start_up_configuration], [role_after_load_path_reference_configuration], [role_before_load_path_reference_configuration], [role_default_page_configuration], [role_dynamic_extension_configuration], [role_event_reference_configuration], [role_system_configuration], [role_client_file_extensions_configuration], [role_admin_page_load_configuration], [role_site_page_load_configuration], [role_admin_global_style_configuration], [role_site_global_style_configuration], [role_admin_global_template_configuration], [role_site_global_template_configuration], [role_admin_global_location_configuration], [role_site_global_location_configuration], [role_url_redirect_configuration], [role_url_rewrite_configuration]) VALUES (8, N'member', N'member', 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [el_role] OFF
GO
SET IDENTITY_INSERT [el_site] ON 

INSERT [el_site] ([site_id], [language_id], [site_title], [site_name], [site_global_name], [site_visit], [page_id], [site_slogan_name], [site_date_create], [site_time_create], [site_site_activities], [site_address], [site_phone_number], [site_email], [site_other_info], [admin_style_id], [admin_template_id], [site_style_id], [site_template_id], [site_active], [site_static_head], [site_use_description_meta], [site_use_revisit_after_meta], [site_use_rights_meta], [site_use_keywords_meta], [site_use_classification_meta], [site_description_meta], [site_revisit_after_meta], [site_rights_meta], [site_classification_meta], [site_keywords_meta], [site_show_link_in_site], [site_calendar], [site_first_day_of_week], [site_time_zone], [site_date_format], [site_time_format], [site_public_access_show]) VALUES (1, 1, N'Elanat Framework', N'elanat', N'default', 0, 1, N'Free and open-source', N'2023/08/31', N'00:00:00', N'', N'', N'', N'', N'', 0, 0, 0, 0, 1, N'', 0, 0, 0, 0, 0, N'', N'', N'', N'', N'', 0, N'gregorian', 0, 0, N'', N'', 1)
SET IDENTITY_INSERT [el_site] OFF
GO
SET IDENTITY_INSERT [el_site_style] ON 

INSERT [el_site_style] ([site_style_id], [site_style_name], [site_style_directory_path], [site_style_physical_name], [site_style_template], [site_style_load_tag], [site_style_static_head], [site_style_active]) VALUES (1, N'article_green', N'article_green', N'article_green.css', N'article', NULL, NULL, 1)
SET IDENTITY_INSERT [el_site_style] OFF
GO
SET IDENTITY_INSERT [el_site_template] ON 

INSERT [el_site_template] ([site_template_id], [site_template_name], [site_template_directory_path], [site_template_physical_name], [site_template_load_tag], [site_template_static_head], [site_template_active]) VALUES (1, N'article', N'article', N'article.xml', NULL, NULL, 1)
SET IDENTITY_INSERT [el_site_template] OFF
GO
SET IDENTITY_INSERT [el_user] ON 

INSERT [el_user] ([user_id], [user_name], [group_id], [user_site_name], [user_real_name], [user_real_last_name], [user_password], [user_date_create], [user_last_login], [user_active], [user_email], [user_phone_number], [user_address], [user_postal_code], [user_about], [user_birthday], [user_gender], [user_number_of_upload], [user_size_of_upload], [user_public_email], [user_mobile_number], [user_zip_code], [user_email_is_confirm], [user_other_info], [site_style_id], [site_template_id], [admin_style_id], [admin_template_id], [user_country], [user_state_or_province], [user_city], [user_website], [site_language_id], [admin_language_id], [user_calendar], [user_first_day_of_week], [user_time_zone], [user_date_format], [user_time_format], [user_day_difference], [user_time_hours_difference], [user_time_minutes_difference], [user_common_light_background_color], [user_common_light_text_color], [user_common_middle_background_color], [user_common_middle_text_color], [user_common_dark_background_color], [user_common_dark_text_color], [user_natural_light_background_color], [user_natural_light_text_color], [user_natural_middle_background_color], [user_natural_middle_text_color], [user_natural_dark_background_color], [user_natural_dark_text_color], [user_background_color], [user_font_size], [user_user_info_background_color], [user_user_info_font_color], [user_show_user_avatar_in_user_info], [user_show_user_online_in_user_info], [user_show_user_email_in_user_info], [user_show_user_birthday_in_user_info], [user_show_user_gender_in_user_info], [user_show_user_phone_number_in_user_info], [user_show_user_mobile_number_in_user_info], [user_show_user_country_in_user_info], [user_show_user_state_or_province_in_user_info], [user_show_user_city_in_user_info], [user_show_user_zip_code_in_user_info], [user_show_user_postal_code_in_user_info], [user_show_user_address_in_user_info], [user_show_user_website_in_user_info], [user_show_user_last_login_in_user_info]) VALUES (1, N'admin', 4, N'admin', N'', N'', N'40BD001563085FC35165329EA1FF5C5E', N'2023/08/31', N'2023/08/31-00:00:00', 1, N'admin@localhost.local', N'', N'', N'', N'', N'2000/01/01', 0, 0, N'0', N'', N'', N'', 1, N'', 0, 0, 0, 0, N'', N'', N'', N'', 0, 0, N'gregorian', 1, 0, N'yyyy/MM/dd', N'HH:ss', 0, 0, 0, N'       ', N'       ', N'       ', N'       ', N'       ', N'       ', N'       ', N'       ', N'       ', N'       ', N'       ', N'       ', N'       ', 99, N'       ', N'       ', 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [el_user] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_admin_style_admin_style_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_admin_style] ADD  CONSTRAINT [IX_el_admin_style_admin_style_name] UNIQUE NONCLUSTERED 
(
	[admin_style_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_admin_template_admin_template_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_admin_template] ADD  CONSTRAINT [IX_el_admin_template_admin_template_name] UNIQUE NONCLUSTERED 
(
	[admin_template_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_category_category_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_category] ADD  CONSTRAINT [IX_el_category_category_name] UNIQUE NONCLUSTERED 
(
	[category_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_component_component_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_component] ADD  CONSTRAINT [IX_el_component_component_name] UNIQUE NONCLUSTERED 
(
	[component_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_editor_template_editor_template_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_editor_template] ADD  CONSTRAINT [IX_el_editor_template_editor_template_name] UNIQUE NONCLUSTERED 
(
	[editor_template_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_extra_helper_extra_helper_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_extra_helper] ADD  CONSTRAINT [IX_el_extra_helper_extra_helper_name] UNIQUE NONCLUSTERED 
(
	[extra_helper_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_fetch_fetch_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_fetch] ADD  CONSTRAINT [IX_el_fetch_fetch_name] UNIQUE NONCLUSTERED 
(
	[fetch_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_group_group_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_group] ADD  CONSTRAINT [IX_el_group_group_name] UNIQUE NONCLUSTERED 
(
	[group_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_item_item_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_item] ADD  CONSTRAINT [IX_el_item_item_name] UNIQUE NONCLUSTERED 
(
	[item_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_language_language_global_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_language] ADD  CONSTRAINT [IX_el_language_language_global_name] UNIQUE NONCLUSTERED 
(
	[language_global_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_language_language_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_language] ADD  CONSTRAINT [IX_el_language_language_name] UNIQUE NONCLUSTERED 
(
	[language_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_menu_menu_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_menu] ADD  CONSTRAINT [IX_el_menu_menu_name] UNIQUE NONCLUSTERED 
(
	[menu_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_module_module_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_module] ADD  CONSTRAINT [IX_el_module_module_name] UNIQUE NONCLUSTERED 
(
	[module_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_page_page_global_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_page] ADD  CONSTRAINT [IX_el_page_page_global_name] UNIQUE NONCLUSTERED 
(
	[page_global_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_page_page_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_page] ADD  CONSTRAINT [IX_el_page_page_name] UNIQUE NONCLUSTERED 
(
	[page_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_patch_patch_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_patch] ADD  CONSTRAINT [IX_el_patch_patch_name] UNIQUE NONCLUSTERED 
(
	[patch_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_plugin_plugin_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_plugin] ADD  CONSTRAINT [IX_el_plugin_plugin_name] UNIQUE NONCLUSTERED 
(
	[plugin_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_role_role_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_role] ADD  CONSTRAINT [IX_el_role_role_name] UNIQUE NONCLUSTERED 
(
	[role_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_site_site_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_site] ADD  CONSTRAINT [IX_el_site_site_name] UNIQUE NONCLUSTERED 
(
	[site_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_site_style_site_style_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_site_style] ADD  CONSTRAINT [IX_el_site_style_site_style_name] UNIQUE NONCLUSTERED 
(
	[site_style_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_site_template_site_template_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_site_template] ADD  CONSTRAINT [IX_el_site_template_site_template_name] UNIQUE NONCLUSTERED 
(
	[site_template_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_user_user_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_user] ADD  CONSTRAINT [IX_el_user_user_name] UNIQUE NONCLUSTERED 
(
	[user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_user_user_site_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_user] ADD  CONSTRAINT [IX_el_user_user_site_name] UNIQUE NONCLUSTERED 
(
	[user_site_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_view_view_name]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_view] ADD  CONSTRAINT [IX_el_view_view_name] UNIQUE NONCLUSTERED 
(
	[view_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_el_visit_statistics_date_visit]    Script Date: 2023-09-01 6:01:38 PM ******/
ALTER TABLE [el_visit_statistics] ADD  CONSTRAINT [IX_el_visit_statistics_date_visit] UNIQUE NONCLUSTERED 
(
	[visit_statistics_date_visit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [el_admin_style] ADD  CONSTRAINT [DF_el_admin_style_site_style_active]  DEFAULT ((0)) FOR [admin_style_active]
GO
ALTER TABLE [el_admin_template] ADD  CONSTRAINT [DF_el_admin_template_site_template_active]  DEFAULT ((0)) FOR [admin_template_active]
GO
ALTER TABLE [el_attachment] ADD  CONSTRAINT [DF_el_attachment_attachment_size]  DEFAULT ((0)) FOR [attachment_size]
GO
ALTER TABLE [el_attachment] ADD  CONSTRAINT [DF_el_attachment_number_of_visit]  DEFAULT ((0)) FOR [attachment_number_of_visit]
GO
ALTER TABLE [el_attachment] ADD  CONSTRAINT [DF_el_attachment_attachment_active]  DEFAULT ((0)) FOR [attachment_active]
GO
ALTER TABLE [el_attachment] ADD  CONSTRAINT [DF_el_attachment_public_access]  DEFAULT ((0)) FOR [attachment_public_access_show]
GO
ALTER TABLE [el_attachment_access_show] ADD  CONSTRAINT [DF_el_attachment_access_show_attachment_id]  DEFAULT ((0)) FOR [attachment_id]
GO
ALTER TABLE [el_attachment_access_show] ADD  CONSTRAINT [DF_el_attachment_access_show_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_category] ADD  CONSTRAINT [DF_el_category_site_id]  DEFAULT ((0)) FOR [site_id]
GO
ALTER TABLE [el_category] ADD  CONSTRAINT [DF_el_category_require_approval]  DEFAULT ((0)) FOR [require_approval]
GO
ALTER TABLE [el_category] ADD  CONSTRAINT [DF_el_category_sub_category]  DEFAULT ((0)) FOR [parent_category]
GO
ALTER TABLE [el_category] ADD  CONSTRAINT [DF_el_category_site_template_id]  DEFAULT ((0)) FOR [site_template_id]
GO
ALTER TABLE [el_category] ADD  CONSTRAINT [DF_el_category_item_active]  DEFAULT ((0)) FOR [category_active]
GO
ALTER TABLE [el_category] ADD  CONSTRAINT [DF_el_category_public_access]  DEFAULT ((0)) FOR [category_public_access_show]
GO
ALTER TABLE [el_category_access_show] ADD  CONSTRAINT [DF_el_category_access_show_category_id]  DEFAULT ((0)) FOR [category_id]
GO
ALTER TABLE [el_category_access_show] ADD  CONSTRAINT [DF_el_category_access_show_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_comment] ADD  CONSTRAINT [DF_el_comment_content_id]  DEFAULT ((0)) FOR [content_id]
GO
ALTER TABLE [el_comment] ADD  CONSTRAINT [DF_el_comment_user_id]  DEFAULT ((0)) FOR [user_id]
GO
ALTER TABLE [el_comment] ADD  CONSTRAINT [DF_el_comment_parent_comment]  DEFAULT ((0)) FOR [parent_comment]
GO
ALTER TABLE [el_comment] ADD  CONSTRAINT [DF_el_comments_require_approval]  DEFAULT ((0)) FOR [comment_active]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_Table_1_module_active]  DEFAULT ((0)) FOR [component_active]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_page_use_language]  DEFAULT ((0)) FOR [component_use_language]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_page_use_module]  DEFAULT ((0)) FOR [component_use_module]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_page_use_plugin]  DEFAULT ((0)) FOR [component_use_plugin]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_page_use_replace_part]  DEFAULT ((0)) FOR [component_use_replace_part]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_page_use_fetch]  DEFAULT ((0)) FOR [component_use_fetch]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_page_use_item]  DEFAULT ((0)) FOR [component_use_item]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_page_use_elanat]  DEFAULT ((0)) FOR [component_use_elanat]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_page_cache_duration]  DEFAULT ((0)) FOR [component_cache_duration]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_module_public_access_add]  DEFAULT ((0)) FOR [component_public_access_add]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_module_public_access_edit_own]  DEFAULT ((0)) FOR [component_public_access_edit_own]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_module_public_access_delete_own]  DEFAULT ((0)) FOR [component_public_access_delete_own]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_module_public_access_edit_all]  DEFAULT ((0)) FOR [component_public_access_edit_all]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_module_public_access_delete_all]  DEFAULT ((0)) FOR [component_public_access_delete_all]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_Table_1_public_access_show]  DEFAULT ((0)) FOR [component_public_access_show]
GO
ALTER TABLE [el_component] ADD  CONSTRAINT [DF_el_component_plugin_sort_index]  DEFAULT ((0)) FOR [component_sort_index]
GO
ALTER TABLE [el_component_role_access] ADD  CONSTRAINT [DF_el_component_role_access_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_component_role_access] ADD  CONSTRAINT [DF_Table_1_module_add]  DEFAULT ((0)) FOR [component_add]
GO
ALTER TABLE [el_component_role_access] ADD  CONSTRAINT [DF_Table_1_module_edit_own]  DEFAULT ((0)) FOR [component_edit_own]
GO
ALTER TABLE [el_component_role_access] ADD  CONSTRAINT [DF_Table_1_module_delete_own]  DEFAULT ((0)) FOR [component_delete_own]
GO
ALTER TABLE [el_component_role_access] ADD  CONSTRAINT [DF_Table_1_module_edit_all]  DEFAULT ((0)) FOR [component_edit_all]
GO
ALTER TABLE [el_component_role_access] ADD  CONSTRAINT [DF_Table_1_module_delete_all]  DEFAULT ((0)) FOR [component_delete_all]
GO
ALTER TABLE [el_component_role_access] ADD  CONSTRAINT [DF_Table_1_module_view]  DEFAULT ((0)) FOR [component_show]
GO
ALTER TABLE [el_contact] ADD  CONSTRAINT [DF_el_contact_user_id]  DEFAULT ((0)) FOR [user_id]
GO
ALTER TABLE [el_content] ADD  CONSTRAINT [DF_el_content_user_id]  DEFAULT ((0)) FOR [user_id]
GO
ALTER TABLE [el_content] ADD  CONSTRAINT [DF_el_content_category_id]  DEFAULT ((0)) FOR [category_id]
GO
ALTER TABLE [el_content] ADD  CONSTRAINT [DF_el_content_always_on_top]  DEFAULT ((0)) FOR [content_always_on_top]
GO
ALTER TABLE [el_content] ADD  CONSTRAINT [DF_el_content_status]  DEFAULT ('$_lang_draft;') FOR [content_status]
GO
ALTER TABLE [el_content] ADD  CONSTRAINT [DF_el_content_content_type]  DEFAULT ('post') FOR [content_type]
GO
ALTER TABLE [el_content] ADD  CONSTRAINT [DF_Table_1_ww]  DEFAULT ((0)) FOR [content_verify_comments]
GO
ALTER TABLE [el_content] ADD  CONSTRAINT [DF_el_content_content_visit]  DEFAULT ((0)) FOR [content_visit]
GO
ALTER TABLE [el_content] ADD  CONSTRAINT [DF_el_content_public_access]  DEFAULT ((0)) FOR [content_public_access_show]
GO
ALTER TABLE [el_content_access_show] ADD  CONSTRAINT [DF_el_content_access_show_content_id]  DEFAULT ((0)) FOR [content_id]
GO
ALTER TABLE [el_content_access_show] ADD  CONSTRAINT [DF_el_content_access_show_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_content_attachment] ADD  CONSTRAINT [DF_el_content_attachment_content_id]  DEFAULT ((0)) FOR [content_id]
GO
ALTER TABLE [el_content_attachment] ADD  CONSTRAINT [DF_el_content_attachment_attachment_id]  DEFAULT ((0)) FOR [attachment_id]
GO
ALTER TABLE [el_content_avatar] ADD  CONSTRAINT [DF_el_content_avatar_content_id]  DEFAULT ((0)) FOR [content_id]
GO
ALTER TABLE [el_content_icon] ADD  CONSTRAINT [DF_el_content_icon_content_id]  DEFAULT ((0)) FOR [content_id]
GO
ALTER TABLE [el_content_keywords] ADD  CONSTRAINT [DF_el_content_keywords_content_id]  DEFAULT ((0)) FOR [content_id]
GO
ALTER TABLE [el_content_rating] ADD  CONSTRAINT [DF_el_rating_content_id]  DEFAULT ((0)) FOR [content_id]
GO
ALTER TABLE [el_content_rating] ADD  CONSTRAINT [DF_el_rating_rating_number_of_voted]  DEFAULT ((0)) FOR [content_rating_number_of_voted]
GO
ALTER TABLE [el_content_rating] ADD  CONSTRAINT [DF_el_rating_rating_rating]  DEFAULT ((0)) FOR [content_rating_rating]
GO
ALTER TABLE [el_content_reply] ADD  CONSTRAINT [DF_el_content_reply_content_id]  DEFAULT ((0)) FOR [content_id]
GO
ALTER TABLE [el_content_reply] ADD  CONSTRAINT [DF_el_content_reply_user_id]  DEFAULT ((0)) FOR [user_id]
GO
ALTER TABLE [el_content_reply] ADD  CONSTRAINT [DF_el_content_reply_content_reply_active]  DEFAULT ((0)) FOR [content_reply_active]
GO
ALTER TABLE [el_content_source] ADD  CONSTRAINT [DF_el_content_source_content_id]  DEFAULT ((0)) FOR [content_id]
GO
ALTER TABLE [el_editor_template] ADD  CONSTRAINT [DF_el_editor_template_page_use_language]  DEFAULT ((0)) FOR [editor_template_use_language]
GO
ALTER TABLE [el_editor_template] ADD  CONSTRAINT [DF_el_editor_template_page_use_module]  DEFAULT ((0)) FOR [editor_template_use_module]
GO
ALTER TABLE [el_editor_template] ADD  CONSTRAINT [DF_el_editor_template_page_use_plugin]  DEFAULT ((0)) FOR [editor_template_use_plugin]
GO
ALTER TABLE [el_editor_template] ADD  CONSTRAINT [DF_el_editor_template_page_use_replace_part]  DEFAULT ((0)) FOR [editor_template_use_replace_part]
GO
ALTER TABLE [el_editor_template] ADD  CONSTRAINT [DF_el_editor_template_page_use_fetch]  DEFAULT ((0)) FOR [editor_template_use_fetch]
GO
ALTER TABLE [el_editor_template] ADD  CONSTRAINT [DF_el_editor_template_page_use_item]  DEFAULT ((0)) FOR [editor_template_use_item]
GO
ALTER TABLE [el_editor_template] ADD  CONSTRAINT [DF_el_editor_template_page_use_elanat]  DEFAULT ((0)) FOR [editor_template_use_elanat]
GO
ALTER TABLE [el_editor_template] ADD  CONSTRAINT [DF_el_editor_template_page_cache_duration]  DEFAULT ((0)) FOR [editor_template_cache_duration]
GO
ALTER TABLE [el_editor_template] ADD  CONSTRAINT [DF_el_editor_template_editor_template_active]  DEFAULT ((0)) FOR [editor_template_active]
GO
ALTER TABLE [el_editor_template] ADD  CONSTRAINT [DF_el_editor_template_extra_helper_public_access_show]  DEFAULT ((0)) FOR [editor_template_public_access_show]
GO
ALTER TABLE [el_editor_template] ADD  CONSTRAINT [DF_el_editor_template_extra_helper_index]  DEFAULT ((0)) FOR [editor_template_sort_index]
GO
ALTER TABLE [el_editor_template_access_show] ADD  CONSTRAINT [DF_Table_1_item_id_1]  DEFAULT ((0)) FOR [editor_template_id]
GO
ALTER TABLE [el_editor_template_access_show] ADD  CONSTRAINT [DF_el_editor_template_access_show_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_extra_helper] ADD  CONSTRAINT [DF_el_extra_helper_page_use_language]  DEFAULT ((0)) FOR [extra_helper_use_language]
GO
ALTER TABLE [el_extra_helper] ADD  CONSTRAINT [DF_el_extra_helper_page_use_module]  DEFAULT ((0)) FOR [extra_helper_use_module]
GO
ALTER TABLE [el_extra_helper] ADD  CONSTRAINT [DF_el_extra_helper_page_use_plugin]  DEFAULT ((0)) FOR [extra_helper_use_plugin]
GO
ALTER TABLE [el_extra_helper] ADD  CONSTRAINT [DF_el_extra_helper_page_use_replace_part]  DEFAULT ((0)) FOR [extra_helper_use_replace_part]
GO
ALTER TABLE [el_extra_helper] ADD  CONSTRAINT [DF_el_extra_helper_page_use_fetch]  DEFAULT ((0)) FOR [extra_helper_use_fetch]
GO
ALTER TABLE [el_extra_helper] ADD  CONSTRAINT [DF_el_extra_helper_page_use_item]  DEFAULT ((0)) FOR [extra_helper_use_item]
GO
ALTER TABLE [el_extra_helper] ADD  CONSTRAINT [DF_el_extra_helper_page_use_elanat]  DEFAULT ((0)) FOR [extra_helper_use_elanat]
GO
ALTER TABLE [el_extra_helper] ADD  CONSTRAINT [DF_el_extra_helper_page_cache_duration]  DEFAULT ((0)) FOR [extra_helper_cache_duration]
GO
ALTER TABLE [el_extra_helper] ADD  CONSTRAINT [DF_Table_1_editor_template_active]  DEFAULT ((0)) FOR [extra_helper_active]
GO
ALTER TABLE [el_extra_helper] ADD  CONSTRAINT [DF_el_extra_helper_module_public_access_show]  DEFAULT ((0)) FOR [extra_helper_public_access_show]
GO
ALTER TABLE [el_extra_helper] ADD  CONSTRAINT [DF_el_extra_helper_plugin_sort_index]  DEFAULT ((0)) FOR [extra_helper_sort_index]
GO
ALTER TABLE [el_extra_helper_access_show] ADD  CONSTRAINT [DF_Table_1_item_id]  DEFAULT ((0)) FOR [extra_helper_id]
GO
ALTER TABLE [el_extra_helper_access_show] ADD  CONSTRAINT [DF_el_extra_helper_access_show_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_fetch] ADD  CONSTRAINT [DF_el_fetch_fetch_cache_duration]  DEFAULT ((0)) FOR [fetch_cache_duration]
GO
ALTER TABLE [el_fetch] ADD  CONSTRAINT [DF_Table_1_item_sort_index]  DEFAULT ((0)) FOR [fetch_sort_index]
GO
ALTER TABLE [el_fetch] ADD  CONSTRAINT [DF_Table_1_item_active]  DEFAULT ((0)) FOR [fetch_active]
GO
ALTER TABLE [el_fetch] ADD  CONSTRAINT [DF_Table_1_item_public_access_show]  DEFAULT ((0)) FOR [fetch_public_access_show]
GO
ALTER TABLE [el_fetch_access_show] ADD  CONSTRAINT [DF_Table_1_item_id_2]  DEFAULT ((0)) FOR [fetch_id]
GO
ALTER TABLE [el_fetch_access_show] ADD  CONSTRAINT [DF_el_fetch_access_show_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_foot_print] ADD  CONSTRAINT [DF_el_foot_print_user_id]  DEFAULT ((0)) FOR [user_id]
GO
ALTER TABLE [el_group] ADD  CONSTRAINT [DF_Table_1_role_active]  DEFAULT ((1)) FOR [group_active]
GO
ALTER TABLE [el_group_role] ADD  CONSTRAINT [DF_Table_1_menu_id_3]  DEFAULT ((0)) FOR [group_id]
GO
ALTER TABLE [el_group_role] ADD  CONSTRAINT [DF_el_user_role_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_item] ADD  CONSTRAINT [DF_el_item_item_use_language]  DEFAULT ((0)) FOR [item_use_language]
GO
ALTER TABLE [el_item] ADD  CONSTRAINT [DF_el_item_item_use_case]  DEFAULT ((0)) FOR [item_use_box]
GO
ALTER TABLE [el_item] ADD  CONSTRAINT [DF_el_item_item_use_plugin1]  DEFAULT ((0)) FOR [item_use_elanat]
GO
ALTER TABLE [el_item] ADD  CONSTRAINT [DF_el_item_item_use_module]  DEFAULT ((0)) FOR [item_use_module]
GO
ALTER TABLE [el_item] ADD  CONSTRAINT [DF_el_item_item_use_plugin]  DEFAULT ((0)) FOR [item_use_plugin]
GO
ALTER TABLE [el_item] ADD  CONSTRAINT [DF_el_item_item_use_elanat1_1]  DEFAULT ((0)) FOR [item_use_fetch]
GO
ALTER TABLE [el_item] ADD  CONSTRAINT [DF_el_item_item_use_elanat1]  DEFAULT ((0)) FOR [item_use_item]
GO
ALTER TABLE [el_item] ADD  CONSTRAINT [DF_el_item_item_use_replace_part]  DEFAULT ((0)) FOR [item_use_replace_part]
GO
ALTER TABLE [el_item] ADD  CONSTRAINT [DF_el_item_item_cache_duration]  DEFAULT ((0)) FOR [item_cache_duration]
GO
ALTER TABLE [el_item] ADD  CONSTRAINT [DF_el_item_item_sort_number]  DEFAULT ((0)) FOR [item_sort_index]
GO
ALTER TABLE [el_item] ADD  CONSTRAINT [DF_el_item_link_active]  DEFAULT ((0)) FOR [item_active]
GO
ALTER TABLE [el_item] ADD  CONSTRAINT [DF_el_item_menu_public_access_show]  DEFAULT ((0)) FOR [item_public_access_show]
GO
ALTER TABLE [el_item_access_show] ADD  CONSTRAINT [DF_Table_1_menu_id_1]  DEFAULT ((0)) FOR [item_id]
GO
ALTER TABLE [el_item_access_show] ADD  CONSTRAINT [DF_el_item_access_show_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_language] ADD  CONSTRAINT [DF_el_language_language_is_left_to_right]  DEFAULT ((0)) FOR [language_is_right_to_left]
GO
ALTER TABLE [el_language] ADD  CONSTRAINT [DF_el_language_language_active1]  DEFAULT ((0)) FOR [language_show_link_in_site]
GO
ALTER TABLE [el_language] ADD  CONSTRAINT [DF_el_language_active]  DEFAULT ((0)) FOR [language_active]
GO
ALTER TABLE [el_language] ADD  CONSTRAINT [DF_el_language_site_id]  DEFAULT ((0)) FOR [site_id]
GO
ALTER TABLE [el_link] ADD  CONSTRAINT [DF_Table_1_item_target]  DEFAULT ('_blank') FOR [link_target]
GO
ALTER TABLE [el_link] ADD  CONSTRAINT [DF_el_link_item_sort_number]  DEFAULT ((0)) FOR [link_sort_index]
GO
ALTER TABLE [el_link] ADD  CONSTRAINT [DF_el_link_link_active]  DEFAULT ((0)) FOR [link_active]
GO
ALTER TABLE [el_menu] ADD  CONSTRAINT [DF_el_menu_site_id]  DEFAULT ((0)) FOR [site_id]
GO
ALTER TABLE [el_menu] ADD  CONSTRAINT [DF_el_menu_item_sort_number]  DEFAULT ((0)) FOR [menu_sort_index]
GO
ALTER TABLE [el_menu] ADD  CONSTRAINT [DF_el_menu_menu_use_box]  DEFAULT ((0)) FOR [menu_use_box]
GO
ALTER TABLE [el_menu] ADD  CONSTRAINT [DF_el_menu_link_active]  DEFAULT ((0)) FOR [menu_active]
GO
ALTER TABLE [el_menu] ADD  CONSTRAINT [DF_el_menu_public_access]  DEFAULT ((0)) FOR [menu_public_access_show]
GO
ALTER TABLE [el_menu_access_show] ADD  CONSTRAINT [DF_el_menu_acceess_show_menu_id]  DEFAULT ((0)) FOR [menu_id]
GO
ALTER TABLE [el_menu_access_show] ADD  CONSTRAINT [DF_el_menu_acceess_show_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_menu_fetch] ADD  CONSTRAINT [DF_el_menu_fetch_menu_id]  DEFAULT ((0)) FOR [menu_id]
GO
ALTER TABLE [el_menu_fetch] ADD  CONSTRAINT [DF_Table_1_link_id]  DEFAULT ((0)) FOR [fetch_id]
GO
ALTER TABLE [el_menu_item] ADD  CONSTRAINT [DF_el_menu_item_menu_id]  DEFAULT ((0)) FOR [menu_id]
GO
ALTER TABLE [el_menu_item] ADD  CONSTRAINT [DF_el_menu_item_item_id]  DEFAULT ((0)) FOR [item_id]
GO
ALTER TABLE [el_menu_link] ADD  CONSTRAINT [DF_el_menu_link_menu_id]  DEFAULT ((0)) FOR [menu_id]
GO
ALTER TABLE [el_menu_link] ADD  CONSTRAINT [DF_el_menu_link_link_id]  DEFAULT ((0)) FOR [link_id]
GO
ALTER TABLE [el_menu_module] ADD  CONSTRAINT [DF_el_menu_module_menu_id]  DEFAULT ((0)) FOR [menu_id]
GO
ALTER TABLE [el_menu_module] ADD  CONSTRAINT [DF_el_menu_module_module_id]  DEFAULT ((0)) FOR [module_id]
GO
ALTER TABLE [el_menu_plugin] ADD  CONSTRAINT [DF_el_menu_plugin_menu_id]  DEFAULT ((0)) FOR [menu_id]
GO
ALTER TABLE [el_menu_plugin] ADD  CONSTRAINT [DF_el_menu_plugin_plugin_id]  DEFAULT ((0)) FOR [plugin_id]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_Table_1_plugin_active]  DEFAULT ((0)) FOR [module_active]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_page_use_language]  DEFAULT ((0)) FOR [module_use_language]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_page_use_module]  DEFAULT ((0)) FOR [module_use_module]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_page_use_plugin]  DEFAULT ((0)) FOR [module_use_plugin]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_page_use_replace_part]  DEFAULT ((0)) FOR [module_use_replace_part]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_page_use_fetch]  DEFAULT ((0)) FOR [module_use_fetch]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_page_use_item]  DEFAULT ((0)) FOR [module_use_item]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_page_use_elanat]  DEFAULT ((0)) FOR [module_use_elanat]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_page_cache_duration]  DEFAULT ((0)) FOR [module_cache_duration]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_module_public_access_edit_own1_1]  DEFAULT ((0)) FOR [module_public_access_add]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_module_public_access_delete_own1]  DEFAULT ((0)) FOR [module_public_access_edit_own]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_module_public_access_show1]  DEFAULT ((0)) FOR [module_public_access_delete_own]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_module_public_access_edit_own1]  DEFAULT ((0)) FOR [module_public_access_edit_all]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_module_public_access_delete_own1_1]  DEFAULT ((0)) FOR [module_public_access_delete_all]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_public_access]  DEFAULT ((0)) FOR [module_public_access_show]
GO
ALTER TABLE [el_module] ADD  CONSTRAINT [DF_el_module_module_sort_index]  DEFAULT ((0)) FOR [module_sort_index]
GO
ALTER TABLE [el_module_role_access] ADD  CONSTRAINT [DF_el_module_role_access_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_module_role_access] ADD  CONSTRAINT [DF_Table_1_plugin_add]  DEFAULT ((0)) FOR [module_add]
GO
ALTER TABLE [el_module_role_access] ADD  CONSTRAINT [DF_el_module_role_access_plugin_edit_own]  DEFAULT ((0)) FOR [module_edit_own]
GO
ALTER TABLE [el_module_role_access] ADD  CONSTRAINT [DF_el_module_role_access_plugin_delete_own]  DEFAULT ((0)) FOR [module_delete_own]
GO
ALTER TABLE [el_module_role_access] ADD  CONSTRAINT [DF_el_module_role_access_plugin_edit_all]  DEFAULT ((0)) FOR [module_edit_all]
GO
ALTER TABLE [el_module_role_access] ADD  CONSTRAINT [DF_el_module_role_access_plugin_delete_all]  DEFAULT ((0)) FOR [module_delete_all]
GO
ALTER TABLE [el_module_role_access] ADD  CONSTRAINT [DF_Table_1_plugin_view]  DEFAULT ((0)) FOR [module_show]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_user_id]  DEFAULT ((0)) FOR [user_id]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_site_id]  DEFAULT ((0)) FOR [page_public_site]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_active]  DEFAULT ((0)) FOR [page_active]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_item_use_language]  DEFAULT ((0)) FOR [page_use_language]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_item_use_module]  DEFAULT ((0)) FOR [page_use_module]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_item_use_plugin]  DEFAULT ((0)) FOR [page_use_plugin]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_item_use_replace_part]  DEFAULT ((0)) FOR [page_use_replace_part]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_replace_part3]  DEFAULT ((0)) FOR [page_use_fetch]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_replace_part2]  DEFAULT ((0)) FOR [page_use_item]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_replace_part1]  DEFAULT ((0)) FOR [page_use_elanat]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_static_head1]  DEFAULT ((0)) FOR [page_use_load_tag]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_static_head]  DEFAULT ((0)) FOR [page_use_static_head]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_show_link_in_site]  DEFAULT ((0)) FOR [page_show_link_in_site]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_site_style_id]  DEFAULT ((0)) FOR [site_style_id]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_site_template_id]  DEFAULT ((0)) FOR [site_template_id]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_cache_duration]  DEFAULT ((0)) FOR [page_cache_duration]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_description_meta7]  DEFAULT ((0)) FOR [page_use_classification_meta]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_description_meta6]  DEFAULT ((0)) FOR [page_use_copyright_meta]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_description_meta5]  DEFAULT ((0)) FOR [page_use_language_meta]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_description_meta4]  DEFAULT ((0)) FOR [page_use_robots_meta]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_description_meta3]  DEFAULT ((0)) FOR [page_use_application_name_meta]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_description_meta2]  DEFAULT ((0)) FOR [page_use_generator_meta]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_description_meta1]  DEFAULT ((0)) FOR [page_use_javascript_inactive_refresh_meta]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_description_meta]  DEFAULT ((0)) FOR [page_use_description_meta]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_revisit_after_meta]  DEFAULT ((0)) FOR [page_use_revisit_after_meta]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_rights_meta]  DEFAULT ((0)) FOR [page_use_rights_meta]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_keywords_meta]  DEFAULT ((0)) FOR [page_use_keywords_meta]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_use_author_meta]  DEFAULT ((0)) FOR [page_use_author_meta]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_page_visit]  DEFAULT ((0)) FOR [page_visit]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_use_html]  DEFAULT ((0)) FOR [page_use_html]
GO
ALTER TABLE [el_page] ADD  CONSTRAINT [DF_el_page_public_access_show]  DEFAULT ((0)) FOR [page_public_access_show]
GO
ALTER TABLE [el_page_access_show] ADD  CONSTRAINT [DF_Table_1_menu_id]  DEFAULT ((0)) FOR [page_id]
GO
ALTER TABLE [el_page_access_show] ADD  CONSTRAINT [DF_el_page_access_show_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_add_ons_active]  DEFAULT ((0)) FOR [plugin_active]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_page_use_language]  DEFAULT ((0)) FOR [plugin_use_language]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_page_use_module]  DEFAULT ((0)) FOR [plugin_use_module]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_page_use_plugin]  DEFAULT ((0)) FOR [plugin_use_plugin]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_page_use_replace_part]  DEFAULT ((0)) FOR [plugin_use_replace_part]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_page_use_fetch]  DEFAULT ((0)) FOR [plugin_use_fetch]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_page_use_item]  DEFAULT ((0)) FOR [plugin_use_item]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_page_use_elanat]  DEFAULT ((0)) FOR [plugin_use_elanat]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_page_cache_duration]  DEFAULT ((0)) FOR [plugin_cache_duration]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_module_public_access_add]  DEFAULT ((0)) FOR [plugin_public_access_add]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_module_public_access_edit_own]  DEFAULT ((0)) FOR [plugin_public_access_edit_own]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_module_public_access_delete_own]  DEFAULT ((0)) FOR [plugin_public_access_delete_own]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_module_public_access_edit_all]  DEFAULT ((0)) FOR [plugin_public_access_edit_all]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_module_public_access_delete_all]  DEFAULT ((0)) FOR [plugin_public_access_delete_all]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_public_access_show]  DEFAULT ((0)) FOR [plugin_public_access_show]
GO
ALTER TABLE [el_plugin] ADD  CONSTRAINT [DF_el_plugin_plugin_sort_index]  DEFAULT ((0)) FOR [plugin_sort_index]
GO
ALTER TABLE [el_plugin_role_access] ADD  CONSTRAINT [DF_el_plugin_role_access_plugin_id]  DEFAULT ((0)) FOR [plugin_id]
GO
ALTER TABLE [el_plugin_role_access] ADD  CONSTRAINT [DF_el_plugin_role_access_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_plugin_role_access] ADD  CONSTRAINT [DF_el_plugin_role_access_plugin_edit1]  DEFAULT ((0)) FOR [plugin_add]
GO
ALTER TABLE [el_plugin_role_access] ADD  CONSTRAINT [DF_el_plugin_access_delete_plugin_edit]  DEFAULT ((0)) FOR [plugin_edit_own]
GO
ALTER TABLE [el_plugin_role_access] ADD  CONSTRAINT [DF_el_plugin_access_delete_plugin_delete]  DEFAULT ((0)) FOR [plugin_delete_own]
GO
ALTER TABLE [el_plugin_role_access] ADD  CONSTRAINT [DF_el_plugin_role_access_plugin_edit_own1]  DEFAULT ((0)) FOR [plugin_edit_all]
GO
ALTER TABLE [el_plugin_role_access] ADD  CONSTRAINT [DF_el_plugin_role_access_plugin_delete_own1]  DEFAULT ((0)) FOR [plugin_delete_all]
GO
ALTER TABLE [el_plugin_role_access] ADD  CONSTRAINT [DF_el_plugin_access_delete_plugin_view]  DEFAULT ((0)) FOR [plugin_show]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_type]  DEFAULT ('member') FOR [role_type]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_active]  DEFAULT ((1)) FOR [role_active]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_add_always_on_top_content]  DEFAULT ((0)) FOR [role_add_always_on_top_content]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_add_always_on_top_content1]  DEFAULT ((0)) FOR [role_add_free_comment_content]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_submit_visit]  DEFAULT ((0)) FOR [role_submit_visit]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_submit_foot_print]  DEFAULT ((0)) FOR [role_submit_foot_print]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_approval_users_post_own_content]  DEFAULT ((0)) FOR [role_approval_comment_only_own_content]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_edit_comment_own_content]  DEFAULT ((0)) FOR [role_edit_comment_only_own_content]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_approval_comment_own_content1]  DEFAULT ((0)) FOR [role_delete_comment_only_own_content]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_replay_comment_own_content]  DEFAULT ((0)) FOR [role_reply_comment_only_own_content]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_replay_comment_own_post1_1]  DEFAULT ((0)) FOR [role_reply_comment_all_content]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_upload_file]  DEFAULT ((0)) FOR [role_upload_file]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_add_content_without_approval]  DEFAULT ((0)) FOR [role_add_content_without_approval]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_write_html]  DEFAULT ((0)) FOR [role_write_html]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_write_html1]  DEFAULT ((0)) FOR [role_write_script]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration1]  DEFAULT ((0)) FOR [role_web_config_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration33]  DEFAULT ((0)) FOR [role_config_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration32]  DEFAULT ((0)) FOR [role_authorized_extension_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration29]  DEFAULT ((0)) FOR [role_content_icon_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration28]  DEFAULT ((0)) FOR [role_type_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration27]  DEFAULT ((0)) FOR [role_file_extensions_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration26]  DEFAULT ((0)) FOR [role_page_location_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration25]  DEFAULT ((0)) FOR [role_replace_part_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration24]  DEFAULT ((0)) FOR [role_site_static_head_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration23]  DEFAULT ((0)) FOR [role_site_dynamic_head_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration22]  DEFAULT ((0)) FOR [role_admin_static_head_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration21]  DEFAULT ((0)) FOR [role_admin_dynamic_head_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration18]  DEFAULT ((0)) FOR [role_global_template_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration17]  DEFAULT ((0)) FOR [role_global_style_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration16]  DEFAULT ((0)) FOR [role_global_script_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration15]  DEFAULT ((0)) FOR [role_site_script_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration14]  DEFAULT ((0)) FOR [role_admin_script_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration13]  DEFAULT ((0)) FOR [role_foreign_key_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration12]  DEFAULT ((0)) FOR [role_struct_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration10]  DEFAULT ((0)) FOR [role_robots_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration9]  DEFAULT ((0)) FOR [role_link_protocol_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration8]  DEFAULT ((0)) FOR [role_scheduled_tasks_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration7]  DEFAULT ((0)) FOR [role_security_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration5]  DEFAULT ((0)) FOR [role_calendar_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration]  DEFAULT ((0)) FOR [role_box_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration4]  DEFAULT ((0)) FOR [role_captcha_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration3]  DEFAULT ((0)) FOR [role_file_viewer_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration12_1]  DEFAULT ((0)) FOR [role_wysiwyg_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration11_2]  DEFAULT ((0)) FOR [role_role_bit_column_access_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_box_configuration1_1]  DEFAULT ((0)) FOR [role_start_up_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_start_up_configuration1]  DEFAULT ((0)) FOR [role_after_load_path_reference_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_start_up_configuration12]  DEFAULT ((0)) FOR [role_before_load_path_reference_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_start_up_configuration11]  DEFAULT ((0)) FOR [role_default_page_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_default_page_configuration1]  DEFAULT ((0)) FOR [role_dynamic_extension_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_start_up_configuration10]  DEFAULT ((0)) FOR [role_event_reference_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_start_up_configuration9]  DEFAULT ((0)) FOR [role_system_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_start_up_configuration8]  DEFAULT ((0)) FOR [role_client_file_extensions_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_start_up_configuration7]  DEFAULT ((0)) FOR [role_admin_page_load_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_start_up_configuration6]  DEFAULT ((0)) FOR [role_site_page_load_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_start_up_configuration5]  DEFAULT ((0)) FOR [role_admin_global_style_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_start_up_configuration4]  DEFAULT ((0)) FOR [role_site_global_style_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_start_up_configuration3]  DEFAULT ((0)) FOR [role_admin_global_template_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_role_start_up_configuration2]  DEFAULT ((0)) FOR [role_site_global_template_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_site_global_template2]  DEFAULT ((0)) FOR [role_admin_global_location_configuration]
GO
ALTER TABLE [el_role] ADD  CONSTRAINT [DF_el_role_site_global_template1]  DEFAULT ((0)) FOR [role_site_global_location_configuration]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_language_id]  DEFAULT ((0)) FOR [language_id]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_site_visit]  DEFAULT ((0)) FOR [site_visit]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_site_default_page_global_name]  DEFAULT ((0)) FOR [page_id]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_admin_style_id]  DEFAULT ((0)) FOR [admin_style_id]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_admin_template_id]  DEFAULT ((0)) FOR [admin_template_id]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_site_style_id]  DEFAULT ((0)) FOR [site_style_id]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_site_template_id]  DEFAULT ((0)) FOR [site_template_id]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_site_active]  DEFAULT ((0)) FOR [site_active]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_page_use_description_meta]  DEFAULT ((0)) FOR [site_use_description_meta]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_page_use_revisit_after_meta]  DEFAULT ((0)) FOR [site_use_revisit_after_meta]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_page_use_rights_meta]  DEFAULT ((0)) FOR [site_use_rights_meta]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_page_use_keywords_meta]  DEFAULT ((0)) FOR [site_use_keywords_meta]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_site_classification_meta1]  DEFAULT ((0)) FOR [site_use_classification_meta]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_site_show_link_in_site]  DEFAULT ((0)) FOR [site_show_link_in_site]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_user_first_day_of_weak]  DEFAULT ((0)) FOR [site_first_day_of_week]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_user_time_zone]  DEFAULT ((0)) FOR [site_time_zone]
GO
ALTER TABLE [el_site] ADD  CONSTRAINT [DF_el_site_public_access_show]  DEFAULT ((0)) FOR [site_public_access_show]
GO
ALTER TABLE [el_site_access_show] ADD  CONSTRAINT [DF_el_language_access_show_language_id]  DEFAULT ((0)) FOR [site_id]
GO
ALTER TABLE [el_site_access_show] ADD  CONSTRAINT [DF_el_language_access_show_role_id]  DEFAULT ((0)) FOR [role_id]
GO
ALTER TABLE [el_site_page] ADD  CONSTRAINT [DF_Table_1_menu_id_2]  DEFAULT ((0)) FOR [site_id]
GO
ALTER TABLE [el_site_page] ADD  CONSTRAINT [DF_Table_1_module_id]  DEFAULT ((0)) FOR [page_id]
GO
ALTER TABLE [el_site_style] ADD  CONSTRAINT [DF_el_site_style_page_active]  DEFAULT ((0)) FOR [site_style_active]
GO
ALTER TABLE [el_site_template] ADD  CONSTRAINT [DF_el_site_template_site_style_active]  DEFAULT ((0)) FOR [site_template_active]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_active]  DEFAULT ((0)) FOR [user_active]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_number_of_upload]  DEFAULT ((0)) FOR [user_number_of_upload]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_size_of_upload]  DEFAULT ((0)) FOR [user_size_of_upload]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_email_confirm]  DEFAULT ((0)) FOR [user_email_is_confirm]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_site_style_id]  DEFAULT ((0)) FOR [site_style_id]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_site_template_id]  DEFAULT ((0)) FOR [site_template_id]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_site_style_id1]  DEFAULT ((0)) FOR [admin_style_id]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_site_template_id1]  DEFAULT ((0)) FOR [admin_template_id]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_site_language1]  DEFAULT ((0)) FOR [site_language_id]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_site_language]  DEFAULT ((0)) FOR [admin_language_id]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_first_day_of_weak]  DEFAULT ((0)) FOR [user_first_day_of_week]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_time_zone]  DEFAULT ((0)) FOR [user_time_zone]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_date_diference]  DEFAULT ((0)) FOR [user_day_difference]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_date_diference1]  DEFAULT ((0)) FOR [user_time_hours_difference]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_time_hours_diference1]  DEFAULT ((0)) FOR [user_time_minutes_difference]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info]  DEFAULT ((0)) FOR [user_show_user_avatar_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info12]  DEFAULT ((0)) FOR [user_show_user_online_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info11]  DEFAULT ((0)) FOR [user_show_user_email_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info10]  DEFAULT ((0)) FOR [user_show_user_birthday_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info9]  DEFAULT ((0)) FOR [user_show_user_gender_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info8]  DEFAULT ((0)) FOR [user_show_user_phone_number_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info7]  DEFAULT ((0)) FOR [user_show_user_mobile_number_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info6]  DEFAULT ((0)) FOR [user_show_user_country_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info5]  DEFAULT ((0)) FOR [user_show_user_state_or_province_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info4]  DEFAULT ((0)) FOR [user_show_user_city_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info3]  DEFAULT ((0)) FOR [user_show_user_zip_code_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info2]  DEFAULT ((0)) FOR [user_show_user_postal_code_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info15]  DEFAULT ((0)) FOR [user_show_user_address_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info14]  DEFAULT ((0)) FOR [user_show_user_website_in_user_info]
GO
ALTER TABLE [el_user] ADD  CONSTRAINT [DF_el_user_user_show_user_avatar_in_user_info13]  DEFAULT ((0)) FOR [user_show_user_last_login_in_user_info]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_include_header_bar_part]  DEFAULT ((0)) FOR [view_include_header_bar_part]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_header_bar_left_location]  DEFAULT ((0)) FOR [view_show_header_bar_left]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_header_bar_right_location]  DEFAULT ((0)) FOR [view_show_header_bar_right]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_header_bar_box_location]  DEFAULT ((0)) FOR [view_show_header_bar_box]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_header_bar_left_location]  DEFAULT ((0)) FOR [view_fill_header_bar_left]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_header_bar_right_location]  DEFAULT ((0)) FOR [view_fill_header_bar_right]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_header_bar_box_location]  DEFAULT ((0)) FOR [view_fill_header_bar_box]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_include_header_part]  DEFAULT ((0)) FOR [view_include_header_part]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_header_menu_location]  DEFAULT ((0)) FOR [view_show_header_menu]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_header_1_location]  DEFAULT ((0)) FOR [view_show_header1]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_header_2_location]  DEFAULT ((0)) FOR [view_show_header2]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_header_menu_location]  DEFAULT ((0)) FOR [view_fill_header_menu]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_header_1_location]  DEFAULT ((0)) FOR [view_fill_header1]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_header_2_location]  DEFAULT ((0)) FOR [view_fill_header2]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_include_menu_part]  DEFAULT ((0)) FOR [view_include_menu_part]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_menu_location]  DEFAULT ((0)) FOR [view_show_menu]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_menu_location]  DEFAULT ((0)) FOR [view_fill_menu]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_include_main_part]  DEFAULT ((0)) FOR [view_include_main_part]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_after_header_location]  DEFAULT ((0)) FOR [view_show_after_header]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_before_content_location]  DEFAULT ((0)) FOR [view_show_before_content]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_after_content_location]  DEFAULT ((0)) FOR [view_show_after_content]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_right_menu_location]  DEFAULT ((0)) FOR [view_show_right_menu]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_left_menu_location]  DEFAULT ((0)) FOR [view_show_left_menu]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_before_footer_location]  DEFAULT ((0)) FOR [view_show_before_footer]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_after_header_location]  DEFAULT ((0)) FOR [view_fill_after_header]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_before_content_location]  DEFAULT ((0)) FOR [view_fill_before_content]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_after_content_location]  DEFAULT ((0)) FOR [view_fill_after_content]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_right_menu_location]  DEFAULT ((0)) FOR [view_fill_right_menu]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_left_menu_location]  DEFAULT ((0)) FOR [view_fill_left_menu]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_viewn_fill_before_footer_location]  DEFAULT ((0)) FOR [view_fill_before_footer]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_include_footer_part]  DEFAULT ((0)) FOR [view_include_footer_part]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_footer_menu_location]  DEFAULT ((0)) FOR [view_show_footer_menu]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_footer_1_location]  DEFAULT ((0)) FOR [view_show_footer1]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_footer_2_location]  DEFAULT ((0)) FOR [view_show_footer2]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_footer_menu_location]  DEFAULT ((0)) FOR [view_fill_footer_menu]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_footer_1_location]  DEFAULT ((0)) FOR [view_fill_footer1]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_footer_2_location]  DEFAULT ((0)) FOR [view_fill_footer2]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_include_footer_bar_part]  DEFAULT ((0)) FOR [view_include_footer_bar_part]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_footer_bar_left_location]  DEFAULT ((0)) FOR [view_show_footer_bar_left]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_footer_bar_right_location]  DEFAULT ((0)) FOR [view_show_footer_bar_right]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_show_footer_bar_box_location]  DEFAULT ((0)) FOR [view_show_footer_bar_box]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_footer_bar_left_location]  DEFAULT ((0)) FOR [view_fill_footer_bar_left]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_footer_bar_right_location]  DEFAULT ((0)) FOR [view_fill_footer_bar_right]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_fill_footer_bar_box_location]  DEFAULT ((0)) FOR [view_fill_footer_bar_box]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_site_style_id]  DEFAULT ((0)) FOR [site_style_id]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_site_style_template]  DEFAULT ((0)) FOR [site_template_id]
GO
ALTER TABLE [el_view] ADD  CONSTRAINT [DF_el_view_view_active]  DEFAULT ((0)) FOR [view_active]
GO
ALTER TABLE [el_visit_statistics] ADD  CONSTRAINT [DF_el_visit_statistics_number_of_visit]  DEFAULT ((0)) FOR [visit_statistics_visit]
GO
/****** Object:  StoredProcedure [access_group_to_show_menu]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [access_group_to_show_menu](@menu_id int, @group_id int) as
begin 

IF EXISTS(select el_menu_access_show.menu_access_show_id from el_menu_access_show 
	left join el_role on el_role.role_id = el_menu_access_show.role_id
	join el_group_role on el_group_role.role_id = el_menu_access_show.role_id
	where el_menu_access_show.menu_id = @menu_id
	and el_group_role.group_id = @group_id
	and el_role.role_active = 1) 
	select 1
else
	select 0

end
GO
/****** Object:  StoredProcedure [access_role_to_show_menu]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [access_role_to_show_menu](@menu_id int, @role_id int) as
begin 

IF EXISTS(select el_menu_access_show.menu_access_show_id from el_menu_access_show
left join el_role on el_role.role_id = el_menu_access_show.role_id
where el_menu_access_show.menu_id = @menu_id
and el_menu_access_show.role_id = @role_id
and el_role.role_active = 1) 
	select 1
else
	select 0

end
GO
/****** Object:  StoredProcedure [active_admin_style]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_admin_style](@admin_style_id int) as
begin 

update el_admin_style set admin_style_active = 1
where el_admin_style.admin_style_id = @admin_style_id

end
GO
/****** Object:  StoredProcedure [active_admin_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_admin_template](@admin_template_id int) as
begin 

update el_admin_template set admin_template_active = 1
where el_admin_template.admin_template_id = @admin_template_id

end
GO
/****** Object:  StoredProcedure [active_attachment]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_attachment](@attachment_id int) as
begin
 
update el_attachment set attachment_active = 1 where el_attachment.attachment_id = @attachment_id

end
GO
/****** Object:  StoredProcedure [active_category]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_category](@category_id int) as
begin
 
update el_category set category_active = 1 where el_category.category_id = @category_id

end
GO
/****** Object:  StoredProcedure [active_component]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_component](@component_id int) as
begin
 
update el_component set component_active = 1 where el_component.component_id = @component_id

end
GO
/****** Object:  StoredProcedure [active_content_reply]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_content_reply](@content_reply_id int) as
begin
 
update el_content_reply set content_reply_active = 1 where el_content_reply.content_reply_id = @content_reply_id

end
GO
/****** Object:  StoredProcedure [active_delay_content]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_delay_content](@current_date char(10),@current_time char(8)) as
begin

update el_content set content_status = 'active'
where el_content.content_status = 'delay'
and el_content.content_date_create <= @current_date
and el_content.content_time_create <= @current_time

end
GO
/****** Object:  StoredProcedure [active_editor_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_editor_template](@editor_template_id int) as
begin
 
update el_editor_template set editor_template_active = 1 where el_editor_template.editor_template_id = @editor_template_id

end
GO
/****** Object:  StoredProcedure [active_extra_helper]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_extra_helper](@extra_helper_id int) as
begin
 
update el_extra_helper set extra_helper_active = 1 where el_extra_helper.extra_helper_id = @extra_helper_id

end
GO
/****** Object:  StoredProcedure [active_fetch]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_fetch](@fetch_id int) as
begin
 
update el_fetch set fetch_active = 1 where el_fetch.fetch_id = @fetch_id

end
GO
/****** Object:  StoredProcedure [active_group]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [active_group](@group_id int) as
begin
 
update el_group set group_active = 1 where el_group.group_id = @group_id

end
GO
/****** Object:  StoredProcedure [active_item]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_item](@item_id int) as
begin
 
update el_item set item_active = 1 where el_item.item_id = @item_id

end
GO
/****** Object:  StoredProcedure [active_language]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_language](@language_id int) as
begin
 
update el_language set language_active = 1 where el_language.language_id = @language_id

end
GO
/****** Object:  StoredProcedure [active_link]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_link](@link_id int) as
begin
 
update el_link set link_active = 1 where el_link.link_id = @link_id

end
GO
/****** Object:  StoredProcedure [active_menu]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_menu](@menu_id int) as
begin
 
update el_menu set menu_active = 1 where el_menu.menu_id = @menu_id

end
GO
/****** Object:  StoredProcedure [active_module]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_module](@module_id int) as
begin

update el_module set module_active = 1 where el_module.module_id = @module_id

end
GO
/****** Object:  StoredProcedure [active_page]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_page](@page_id int) as
begin

update el_page set page_active = 1 where el_page.page_id = @page_id

end
GO
/****** Object:  StoredProcedure [active_patch]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [active_patch](@patch_id int) as
begin

update el_patch set patch_active = 1 where el_patch.patch_id = @patch_id

end
GO
/****** Object:  StoredProcedure [active_plugin]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_plugin](@plugin_id int) as
begin

update el_plugin set plugin_active = 1 where el_plugin.plugin_id = @plugin_id

end
GO
/****** Object:  StoredProcedure [active_role]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_role](@role_id int) as
begin

update el_role set role_active = 1 where el_role.role_id = @role_id

end
GO
/****** Object:  StoredProcedure [active_site]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_site](@site_id int) as
begin

update el_site set site_active = 1 where el_site.site_id = @site_id

end
GO
/****** Object:  StoredProcedure [active_site_style]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_site_style](@site_style_id int) as
begin 

update el_site_style set site_style_active = 1
where el_site_style.site_style_id = @site_style_id

end
GO
/****** Object:  StoredProcedure [active_site_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_site_template](@site_template_id int) as
begin 

update el_site_template set site_template_active = 1
where el_site_template.site_template_id = @site_template_id

end
GO
/****** Object:  StoredProcedure [active_user]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_user](@user_id int) as
begin

update el_user set user_active = 1 where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [active_user_email_confirm]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_user_email_confirm](@user_id int) as
begin

update el_user set el_user.user_email_is_confirm = 1 
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [active_view]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [active_view](@view_id int) as
begin 

update el_view set view_active = 1 
where el_view.view_id = @view_id

end
GO
/****** Object:  StoredProcedure [add_admin_style]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_admin_style](@admin_style_name nvarchar(50), @admin_style_directory_path nvarchar(800), @admin_style_physical_name nvarchar(255), @admin_style_template nvarchar(50), @admin_style_load_tag nvarchar(MAX), @admin_style_static_head nvarchar(MAX), @admin_style_active bit) as
begin 

insert into el_admin_style (admin_style_name , admin_style_directory_path, admin_style_physical_name, admin_style_template, admin_style_load_tag, admin_style_static_head, admin_style_active)
values (@admin_style_name , @admin_style_directory_path, @admin_style_physical_name, @admin_style_template, @admin_style_load_tag, @admin_style_static_head, @admin_style_active)
declare @last_admin_style_id int = SCOPE_IDENTITY();
exec get_current_admin_style @last_admin_style_id

end
GO
/****** Object:  StoredProcedure [add_admin_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_admin_template](@admin_template_name nvarchar(50), @admin_template_directory_path nvarchar(800), @admin_template_physical_name nvarchar(255), @admin_template_load_tag nvarchar(MAX), @admin_template_static_head nvarchar(MAX), @admin_template_active bit) as
begin 

insert into el_admin_template (admin_template_name , admin_template_directory_path, admin_template_physical_name, admin_template_load_tag, admin_template_static_head, admin_template_active)
values (@admin_template_name , @admin_template_directory_path, @admin_template_physical_name, @admin_template_load_tag, @admin_template_static_head, @admin_template_active)
declare @last_admin_template_id int = SCOPE_IDENTITY();
exec get_current_admin_template @last_admin_template_id

end
GO
/****** Object:  StoredProcedure [add_attachment]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_attachment](@attachment_name nvarchar(50), @user_id int,@attachment_directory_path nvarchar(800), @attachment_physical_name nvarchar(255), @attachment_about nvarchar(400), @attachment_size varchar(13), @attachment_password nvarchar(50), @attachment_number_of_visit int, @attachment_active bit, @attachment_public_access_show bit) as
begin 

insert into el_attachment (attachment_name, user_id, attachment_directory_path, attachment_physical_name, attachment_about, attachment_size, attachment_password, attachment_number_of_visit, attachment_active, attachment_public_access_show)
values (@attachment_name, @user_id, @attachment_directory_path, @attachment_physical_name, @attachment_about, @attachment_size, @attachment_password, @attachment_number_of_visit, @attachment_active, @attachment_public_access_show)

declare @last_attachment_id int = SCOPE_IDENTITY();
exec get_current_attachment @last_attachment_id

end
GO
/****** Object:  StoredProcedure [add_attachment_content]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_attachment_content](@attachment_id int, @content_id int) as
begin
 
insert into el_content_attachment (attachment_id, content_id)
values (@attachment_id,@content_id)

end
GO
/****** Object:  StoredProcedure [add_category]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_category](@site_id int, @category_name nvarchar(50), @require_approval bit, @parent_category int, @site_style_id int, @site_template_id int, @category_active bit, @category_public_access_show bit) as
begin
 
insert into el_category (site_id, category_name, require_approval, parent_category, site_style_id, site_template_id, category_active, category_public_access_show)
values (@site_id, @category_name, @require_approval, @parent_category, @site_style_id, @site_template_id, @category_active, @category_public_access_show)
declare @last_category_id int = SCOPE_IDENTITY();
exec get_current_category @last_category_id

end
GO
/****** Object:  StoredProcedure [add_category_group]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_category_group](@site_id int, @category_group_name nvarchar(50), @category_id int) as
begin

insert into el_category_group(site_id, category_group_name, category_id)
values (@site_id, @category_group_name, @category_id)

end
GO
/****** Object:  StoredProcedure [add_comment]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_comment](@content_id int, @user_id int, @parent_comment int, @comment_guest_name nvarchar(50), @comment_guest_real_name nvarchar(50), @comment_guest_real_last_name nvarchar(50), @comment_guest_email nvarchar(254), @comment_title nvarchar(200), @comment_text nvarchar(800), @comment_date_send char(10), @comment_time_send char(8), @comment_active bit, @comment_ip_address varchar(39), @comment_file_directory_path nvarchar(800), @comment_file_physical_name nvarchar(255), @comment_type varchar(50), @comment_guest_phone_number varchar(50), @comment_guest_address nvarchar(200), @comment_guest_postal_code varchar(50), @comment_guest_about varchar(200), @comment_guest_birthday char(10), @comment_guest_gender bit, @comment_guest_public_email nvarchar(254), @comment_guest_mobile_number varchar(50), @comment_guest_zip_code varchar(10), @comment_guest_country nvarchar(50), @comment_guest_state_or_province nvarchar(50), @comment_guest_city nvarchar(50), @comment_guest_website nvarchar(255)) as
begin
 
insert into el_comment (content_id, user_id, parent_comment, comment_guest_name, comment_guest_real_name, comment_guest_real_last_name, comment_guest_email, comment_title, comment_text, comment_date_send, comment_time_send, comment_active, comment_ip_address, comment_file_directory_path, comment_file_physical_name, comment_type, comment_guest_phone_number, comment_guest_address, comment_guest_postal_code, comment_guest_about, comment_guest_birthday, comment_guest_gender, comment_guest_public_email, comment_guest_mobile_number, comment_guest_zip_code, comment_guest_country, comment_guest_state_or_province, comment_guest_city, comment_guest_website) 
values (@content_id, @user_id, @parent_comment, @comment_guest_name, @comment_guest_real_name, @comment_guest_real_last_name, @comment_guest_email, @comment_title, @comment_text, @comment_date_send, @comment_time_send, @comment_active, @comment_ip_address, @comment_file_directory_path, @comment_file_physical_name, @comment_type, @comment_guest_phone_number, @comment_guest_address, @comment_guest_postal_code, @comment_guest_about, @comment_guest_birthday, @comment_guest_gender, @comment_guest_public_email, @comment_guest_mobile_number, @comment_guest_zip_code, @comment_guest_country, @comment_guest_state_or_province, @comment_guest_city, @comment_guest_website)
declare @last_comment_id int = SCOPE_IDENTITY();
exec get_current_comment @last_comment_id

end 
GO
/****** Object:  StoredProcedure [add_component]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_component](@component_name nvarchar(50), @component_directory_path nvarchar(800), @component_physical_name nvarchar(255), @component_load_type varchar(10), @component_use_language bit, @component_use_module bit, @component_use_plugin bit, @component_use_replace_part bit, @component_use_fetch bit, @component_use_item bit, @component_use_elanat bit, @component_cache_duration int, @component_cache_parameters nvarchar(200), @component_public_access_add bit, @component_public_access_edit_own bit, @component_public_access_delete_own bit, @component_public_access_edit_all bit, @component_public_access_delete_all bit, @component_public_access_show bit, @component_sort_index int, @component_category nvarchar(50), @component_active bit) as
begin

insert into el_component (component_name, component_directory_path, component_physical_name, component_load_type, component_use_language, component_use_module, component_use_plugin, component_use_replace_part, component_use_fetch, component_use_item, component_use_elanat, component_cache_duration, component_cache_parameters, component_public_access_add, component_public_access_edit_own, component_public_access_delete_own, component_public_access_edit_all, component_public_access_delete_all, component_public_access_show, component_sort_index, component_category, component_active)
values (@component_name, @component_directory_path, @component_physical_name, @component_load_type, @component_use_language, @component_use_module, @component_use_plugin, @component_use_replace_part, @component_use_fetch, @component_use_item, @component_use_elanat, @component_cache_duration, @component_cache_parameters, @component_public_access_add, @component_public_access_edit_own, @component_public_access_delete_own, @component_public_access_edit_all, @component_public_access_delete_all, @component_public_access_show, @component_sort_index, @component_category, @component_active)
declare @last_component_id int = SCOPE_IDENTITY();
exec get_current_component @last_component_id
 
end
GO
/****** Object:  StoredProcedure [add_contact]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_contact](@user_id int, @contact_guest_name nvarchar(50), @contact_guest_real_name nvarchar(50), @contact_guest_real_last_name nvarchar(50), @contact_guest_email nvarchar(254), @contact_title nvarchar(200), @contact_text nvarchar(800), @contact_date_send char(10), @contact_time_send char(8), @contact_ip_address varchar(39), @contact_file_directory_path nvarchar(800), @contact_file_physical_name nvarchar(255), @contact_type varchar(50), @contact_guest_phone_number varchar(50), @contact_guest_address nvarchar(200), @contact_guest_postal_code varchar(50), @contact_guest_about varchar(200), @contact_guest_birthday char(10), @contact_guest_gender bit, @contact_guest_public_email nvarchar(254), @contact_guest_mobile_number varchar(50), @contact_guest_zip_code varchar(10), @contact_guest_country nvarchar(50), @contact_guest_state_or_province nvarchar(50), @contact_guest_city nvarchar(50), @contact_guest_website nvarchar(255), @contact_response_code nvarchar(400)) as
begin
 
insert into el_contact (user_id, contact_guest_name, contact_guest_real_name, contact_guest_real_last_name, contact_guest_email, contact_title, contact_text, contact_date_send, contact_time_send, contact_ip_address, contact_file_directory_path, contact_file_physical_name, contact_type, contact_guest_phone_number, contact_guest_address, contact_guest_postal_code, contact_guest_about, contact_guest_birthday, contact_guest_gender, contact_guest_public_email, contact_guest_mobile_number, contact_guest_zip_code, contact_guest_country, contact_guest_state_or_province, contact_guest_city, contact_guest_website, contact_response_code) 
values (@user_id, @contact_guest_name, @contact_guest_real_name, @contact_guest_real_last_name, @contact_guest_email, @contact_title, @contact_text, @contact_date_send, @contact_time_send, @contact_ip_address, @contact_file_directory_path, @contact_file_physical_name, @contact_type, @contact_guest_phone_number, @contact_guest_address, @contact_guest_postal_code, @contact_guest_about, @contact_guest_birthday, @contact_guest_gender, @contact_guest_public_email, @contact_guest_mobile_number, @contact_guest_zip_code, @contact_guest_country, @contact_guest_state_or_province, @contact_guest_city, @contact_guest_website, @contact_response_code)
declare @last_contact_id int = SCOPE_IDENTITY();
exec get_current_contact @last_contact_id

end 
GO
/****** Object:  StoredProcedure [add_contact_response]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_contact_response](@contact_id int, @contact_response_text nvarchar(400)) as
begin

update el_contact set contact_response_text = @contact_response_text
where el_contact.contact_id = @contact_id

end
GO
/****** Object:  StoredProcedure [add_contact_response_code]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_contact_response_code](@contact_id int, @contact_response_code char(32)) as
begin

update el_contact set
contact_response_code = @contact_response_code
where contact_id = @contact_id

end
GO
/****** Object:  StoredProcedure [add_contact_with_response_code]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_contact_with_response_code](@user_id int = null,@guest_name nvarchar(50) = null,@guest_last_name nvarchar(50) = null,@guest_phone_number varchar(50) = null,@guest_address nvarchar(200) = null,@guest_postal_code varchar(50) = null,@guest_zip_code varchar(10) = null,@guest_about nvarchar(200) = null,@guest_birthday char(10) = null,@guest_gender bit,@guest_site nvarchar(100) = null,@guest_country nvarchar(50) = null,@guest_state_or_province nvarchar(50) = null,@guest_city nvarchar(50) = null,@guest_mobile_number varchar(50) = null,@guest_public_email nvarchar(254) = null,@email nvarchar(400) = null,@type nvarchar(50) = null,@title nvarchar(100) = null,@text nvarchar(400) = null,@date_send char(10),@time_send char(8),@ip_address varchar(39) = null,@file_physical_name nvarchar(400) = null, @response_code varchar(32)) as
begin 

insert into el_contact (user_id,contact_guest_name,contact_guest_real_last_name,contact_guest_phone_number,contact_guest_address,contact_guest_postal_code,contact_guest_zip_code,contact_guest_about,contact_guest_birthday,contact_guest_gender,contact_guest_website,contact_guest_country,contact_guest_state_or_province,contact_guest_city,contact_guest_mobile_number,contact_guest_public_email,contact_guest_email,contact_type,contact_title,contact_text,contact_date_send,contact_time_send,contact_ip_address,contact_file_physical_name, contact_response_code) 
values (@user_id,@guest_name,@guest_last_name,@guest_phone_number,@guest_address,@guest_postal_code,@guest_zip_code,@guest_about,@guest_birthday,@guest_gender,@guest_site,@guest_country,@guest_state_or_province,@guest_city,@guest_mobile_number,@guest_public_email,@email,@type,@title,@text,@date_send,@time_send,@ip_address,@file_physical_name, @response_code)

declare @last_contact_id int = SCOPE_IDENTITY();
exec get_current_contact @last_contact_id

end 
GO
/****** Object:  StoredProcedure [add_content]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_content](@user_id int, @category_id int, @content_title nvarchar(200), @content_text nvarchar(MAX), @content_date_create char(10), @content_time_create char(8), @content_always_on_top bit, @content_status varchar(20), @content_type varchar(20), @content_verify_comments bit, @content_password nvarchar(50), @content_visit int, @content_public_access_show bit) as
begin
 
insert into el_content (user_id, category_id, content_title, content_text, content_date_create, content_time_create, content_always_on_top, content_status, content_type, content_verify_comments, content_password, content_visit, content_public_access_show)
values (@user_id, @category_id, @content_title, @content_text, @content_date_create, @content_time_create, @content_always_on_top, @content_status, @content_type, @content_verify_comments, @content_password, @content_visit, @content_public_access_show)
declare @last_content_id int = SCOPE_IDENTITY();
exec get_current_content @last_content_id

end
GO
/****** Object:  StoredProcedure [add_content_avatar]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_content_avatar](@content_id int, @content_avatar_physical_name nvarchar(255)) as
begin

insert into el_content_avatar (content_id,content_avatar_physical_name)
values (@content_id,@content_avatar_physical_name)

end
GO
/****** Object:  StoredProcedure [add_content_icon]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_content_icon](@content_id int, @content_icon_physical_name nvarchar(255)) as
begin

insert into el_content_icon (content_id,content_icon_physical_name)
values (@content_id,@content_icon_physical_name)

end
GO
/****** Object:  StoredProcedure [add_content_keywords]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_content_keywords](@content_id int, @content_keywords_text nvarchar(200)) as
begin
 
insert into el_content_keywords (content_id,content_keywords_text)
values (@content_id,@content_keywords_text)

end
GO
/****** Object:  StoredProcedure [add_content_rating]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_content_rating](@content_id int) as
begin

insert into el_content_rating (el_content_rating.content_id) values (@content_id)

end
GO
/****** Object:  StoredProcedure [add_content_reply]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_content_reply](@content_id int, @user_id int, @content_reply_guest_name nvarchar(50), @content_reply_guest_real_name nvarchar(50), @content_reply_guest_real_last_name nvarchar(50), @content_reply_guest_email nvarchar(254), @content_reply_text nvarchar(800), @content_reply_date_send char(10), @content_reply_time_send char(8), @content_reply_active bit, @content_reply_ip_address varchar(39), @content_reply_type varchar(50), @content_reply_guest_phone_number varchar(50), @content_reply_guest_address nvarchar(200), @content_reply_guest_postal_code varchar(50), @content_reply_guest_about varchar(200), @content_reply_guest_birthday char(10), @content_reply_guest_gender bit, @content_reply_guest_public_email nvarchar(254), @content_reply_guest_mobile_number varchar(50), @content_reply_guest_zip_code varchar(10), @content_reply_guest_country nvarchar(50), @content_reply_guest_state_or_province nvarchar(50), @content_reply_guest_city nvarchar(50), @content_reply_guest_website nvarchar(255)) as
begin

insert into el_content_reply (content_id, user_id, content_reply_guest_name, content_reply_guest_real_name, content_reply_guest_real_last_name, content_reply_guest_email, content_reply_text, content_reply_date_send, content_reply_time_send, content_reply_active, content_reply_ip_address, content_reply_type, content_reply_guest_phone_number, content_reply_guest_address, content_reply_guest_postal_code, content_reply_guest_about, content_reply_guest_birthday, content_reply_guest_gender, content_reply_guest_public_email, content_reply_guest_mobile_number, content_reply_guest_zip_code, content_reply_guest_country, content_reply_guest_state_or_province, content_reply_guest_city, content_reply_guest_website) 
values (@content_id, @user_id, @content_reply_guest_name, @content_reply_guest_real_name, @content_reply_guest_real_last_name, @content_reply_guest_email, @content_reply_text, @content_reply_date_send, @content_reply_time_send, @content_reply_active, @content_reply_ip_address, @content_reply_type, @content_reply_guest_phone_number, @content_reply_guest_address, @content_reply_guest_postal_code, @content_reply_guest_about, @content_reply_guest_birthday, @content_reply_guest_gender, @content_reply_guest_public_email, @content_reply_guest_mobile_number, @content_reply_guest_zip_code, @content_reply_guest_country, @content_reply_guest_state_or_province, @content_reply_guest_city, @content_reply_guest_website)
declare @last_content_reply_id int = SCOPE_IDENTITY();
exec get_current_content_reply @last_content_reply_id

end 
GO
/****** Object:  StoredProcedure [add_content_source]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_content_source](@content_id int, @content_source_text nvarchar(400)) as
begin
 
insert into el_content_source (content_id,content_source_text)
values (@content_id,@content_source_text)

end
GO
/****** Object:  StoredProcedure [add_editor_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_editor_template](@editor_template_name nvarchar(50), @editor_template_directory_path nvarchar(800), @editor_template_physical_name nvarchar(255), @editor_template_use_language bit, @editor_template_use_module bit, @editor_template_use_plugin bit, @editor_template_use_replace_part bit, @editor_template_use_fetch bit, @editor_template_use_item bit, @editor_template_use_elanat bit, @editor_template_cache_duration int, @editor_template_cache_parameters nvarchar(200), @editor_template_public_access_show bit, @editor_template_sort_index int, @editor_template_category nvarchar(50), @editor_template_active bit) as
begin

insert into el_editor_template (editor_template_name, editor_template_directory_path, editor_template_physical_name, editor_template_use_language, editor_template_use_module, editor_template_use_plugin, editor_template_use_replace_part, editor_template_use_fetch, editor_template_use_item, editor_template_use_elanat, editor_template_cache_duration, editor_template_cache_parameters, editor_template_public_access_show, editor_template_sort_index, editor_template_category, editor_template_active)
values (@editor_template_name, @editor_template_directory_path, @editor_template_physical_name, @editor_template_use_language, @editor_template_use_module, @editor_template_use_plugin, @editor_template_use_replace_part, @editor_template_use_fetch, @editor_template_use_item, @editor_template_use_elanat, @editor_template_cache_duration, @editor_template_cache_parameters, @editor_template_public_access_show, @editor_template_sort_index, @editor_template_category, @editor_template_active)
declare @last_editor_template_id int = SCOPE_IDENTITY();
exec get_current_editor_template @last_editor_template_id
 
end
GO
/****** Object:  StoredProcedure [add_extra_helper]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_extra_helper](@extra_helper_name nvarchar(50), @extra_helper_directory_path nvarchar(800), @extra_helper_physical_name nvarchar(255), @extra_helper_use_language bit, @extra_helper_use_module bit, @extra_helper_use_plugin bit, @extra_helper_use_replace_part bit, @extra_helper_use_fetch bit, @extra_helper_use_item bit, @extra_helper_use_elanat bit, @extra_helper_cache_duration int, @extra_helper_cache_parameters nvarchar(200), @extra_helper_public_access_show bit, @extra_helper_sort_index int, @extra_helper_category nvarchar(50), @extra_helper_active bit) as
begin

insert into el_extra_helper (extra_helper_name, extra_helper_directory_path, extra_helper_physical_name, extra_helper_use_language, extra_helper_use_module, extra_helper_use_plugin, extra_helper_use_replace_part, extra_helper_use_fetch, extra_helper_use_item, extra_helper_use_elanat, extra_helper_cache_duration, extra_helper_cache_parameters, extra_helper_public_access_show, extra_helper_sort_index, extra_helper_category, extra_helper_active)
values (@extra_helper_name, @extra_helper_directory_path, @extra_helper_physical_name, @extra_helper_use_language, @extra_helper_use_module, @extra_helper_use_plugin, @extra_helper_use_replace_part, @extra_helper_use_fetch, @extra_helper_use_item, @extra_helper_use_elanat, @extra_helper_cache_duration, @extra_helper_cache_parameters, @extra_helper_public_access_show, @extra_helper_sort_index, @extra_helper_category, @extra_helper_active)
declare @last_extra_helper_id int = SCOPE_IDENTITY();
exec get_current_extra_helper @last_extra_helper_id
 
end
GO
/****** Object:  StoredProcedure [add_fetch]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_fetch](@fetch_name nvarchar(50), @fetch_category nvarchar(50), @fetch_cache_duration int, @fetch_sort_index int, @fetch_active bit, @fetch_public_access_show bit) as
begin
 
insert into el_fetch (fetch_name, fetch_category, fetch_cache_duration, fetch_sort_index, fetch_active, fetch_public_access_show)
values (@fetch_name, @fetch_category, @fetch_cache_duration, @fetch_sort_index, @fetch_active, @fetch_public_access_show)
declare @last_fetch_id int = SCOPE_IDENTITY();
exec get_current_fetch @last_fetch_id

end
GO
/****** Object:  StoredProcedure [add_foot_print]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_foot_print](@user_id int, @event varchar(30), @value varchar(400), @path nvarchar(400), @date char(10), @time char(8), @ip_address varchar(39)) as
begin

insert into el_foot_print(user_id,foot_print_event,foot_print_value,foot_print_path,foot_print_date_action,foot_print_time_action,foot_print_ip_address)
values (@user_id, @event, @value, @path, @date, @time, @ip_address)

end
GO
/****** Object:  StoredProcedure [add_group]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [add_group](@group_name nvarchar(50), @group_active bit) as
begin
 
insert into el_group (group_name, group_active)
values (@group_name, @group_active)
declare @last_group_id int = SCOPE_IDENTITY();
exec get_current_group @last_group_id

end
GO
/****** Object:  StoredProcedure [add_item]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_item](@item_name nvarchar(50),@item_value nvarchar(max), @item_cache_duration int, @item_sort_index int,@item_public_access_show bit,@item_use_box bit,@item_use_language bit,@item_use_module bit,@item_use_plugin bit,@item_use_replace_part bit,@item_use_fetch bit,@item_use_item bit,@item_use_elanat bit, @item_active bit) as
begin
 
insert into el_item (item_name, item_value, item_cache_duration, item_sort_index, item_public_access_show, item_use_box, item_use_language, item_use_module, item_use_plugin, item_use_replace_part,item_use_fetch,item_use_item,item_use_elanat, item_active)
values (@item_name, @item_value, @item_cache_duration, @item_sort_index, @item_public_access_show, @item_use_box, @item_use_language, @item_use_module, @item_use_plugin, @item_use_replace_part, @item_use_fetch, @item_use_item, @item_use_elanat, @item_active)
declare @last_item_id int = SCOPE_IDENTITY();
exec get_current_item @last_item_id

end
GO
/****** Object:  StoredProcedure [add_language]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_language](@language_name nvarchar(50), @language_global_name varchar(50), @language_is_right_to_left bit, @language_show_link_in_site bit, @language_active bit, @site_id int) as
begin 

insert into el_language (language_name, language_global_name, language_is_right_to_left, language_show_link_in_site, language_active, site_id)
values (@language_name, @language_global_name, @language_is_right_to_left, @language_show_link_in_site, @language_active, @site_id)
declare @last_language_id int = SCOPE_IDENTITY();
exec get_current_language @last_language_id

end
GO
/****** Object:  StoredProcedure [add_link]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_link](@link_href nvarchar(400),@link_protocol varchar(50),@link_sort_index int,@link_target varchar(7),@link_title nvarchar(400),@link_rel nvarchar(50),@link_value nvarchar(400),@link_active bit) as
begin
 
insert into el_link (link_href,link_protocol,link_sort_index,link_target,link_title,link_rel,link_value, link_active)
values (@link_href,@link_protocol,@link_sort_index,@link_target,@link_title,@link_rel,@link_value, @link_active)
declare @last_link_id int = SCOPE_IDENTITY();
exec get_current_link @last_link_id

end
GO
/****** Object:  StoredProcedure [add_menu]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_menu](@site_id int,@menu_name nvarchar(50),@menu_location varchar(30),@menu_sort_index int,@menu_use_box bit,@menu_public_access_show bit,@menu_active bit) as
begin
 
insert into el_menu (site_id, menu_name, menu_location, menu_sort_index, menu_use_box, menu_public_access_show, menu_active)
values (@site_id, @menu_name, @menu_location, @menu_sort_index, @menu_use_box, @menu_public_access_show, @menu_active)
declare @last_menu_id int = SCOPE_IDENTITY();
exec get_current_menu @last_menu_id

end
GO
/****** Object:  StoredProcedure [add_menu_fetch]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_menu_fetch](@menu_id int, @fetch_id int) as
begin

insert into el_menu_fetch (menu_id, fetch_id)
values (@menu_id,@fetch_id)

end
GO
/****** Object:  StoredProcedure [add_menu_item]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_menu_item](@menu_id int, @item_id int) as
begin

insert into el_menu_item (menu_id, item_id)
values (@menu_id,@item_id)

end
GO
/****** Object:  StoredProcedure [add_menu_link]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_menu_link](@menu_id int, @link_id int) as
begin

insert into el_menu_link (menu_id, link_id)
values (@menu_id,@link_id)

end
GO
/****** Object:  StoredProcedure [add_menu_module]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_menu_module](@module_id int, @menu_id int, @menu_module_query_string nvarchar(400)) as
begin
 
insert into el_menu_module (module_id, menu_id, menu_module_query_string)
values (@module_id, @menu_id, @menu_module_query_string)

end
GO
/****** Object:  StoredProcedure [add_menu_plugin]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_menu_plugin](@plugin_id int, @menu_id int, @menu_plugin_query_string nvarchar(400)) as
begin
 
insert into el_menu_plugin (plugin_id, menu_id, menu_plugin_query_string)
values (@plugin_id, @menu_id, @menu_plugin_query_string)

end
GO
/****** Object:  StoredProcedure [add_module]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_module](@module_name nvarchar(50), @module_directory_path nvarchar(800), @module_physical_name nvarchar(255), @module_load_type varchar(10), @module_use_language bit, @module_use_module bit, @module_use_plugin bit, @module_use_replace_part bit, @module_use_fetch bit, @module_use_item bit, @module_use_elanat bit, @module_cache_duration int, @module_cache_parameters nvarchar(200), @module_public_access_add bit, @module_public_access_edit_own bit, @module_public_access_delete_own bit, @module_public_access_edit_all bit, @module_public_access_delete_all bit, @module_public_access_show bit, @module_sort_index int, @module_category nvarchar(50), @module_active bit) as
begin

insert into el_module (module_name, module_directory_path, module_physical_name, module_load_type, module_use_language, module_use_module, module_use_plugin, module_use_replace_part, module_use_fetch, module_use_item, module_use_elanat, module_cache_duration,  module_cache_parameters, module_public_access_add, module_public_access_edit_own, module_public_access_delete_own, module_public_access_edit_all, module_public_access_delete_all, module_public_access_show, module_sort_index, module_category, module_active)
values (@module_name, @module_directory_path, @module_physical_name, @module_load_type, @module_use_language, @module_use_module, @module_use_plugin, @module_use_replace_part, @module_use_fetch, @module_use_item, @module_use_elanat, @module_cache_duration, @module_cache_parameters, @module_public_access_add, @module_public_access_edit_own, @module_public_access_delete_own, @module_public_access_edit_all, @module_public_access_delete_all, @module_public_access_show, @module_sort_index, @module_category, @module_active)
declare @last_module_id int = SCOPE_IDENTITY();
exec get_current_module @last_module_id
 
end
GO
/****** Object:  StoredProcedure [add_page]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_page](@page_global_name nvarchar(50), @page_name nvarchar(50), @user_id int, @page_public_site bit, @page_title nvarchar(400), @page_date_create char(10), @page_time_create char(8), @page_active bit, @page_directory_path nvarchar(800), @page_physical_name nvarchar(255), @page_use_language bit, @page_use_module bit, @page_use_plugin bit, @page_use_replace_part bit, @page_use_fetch bit, @page_use_item bit, @page_use_elanat bit, @page_use_load_tag bit, @page_use_static_head bit, @page_show_link_in_site bit, @page_load_type varchar(10), @page_load_tag nvarchar(MAX), @page_static_head nvarchar(MAX), @site_style_id int, @site_template_id int, @page_load_alone bit, @page_cache_duration int, @page_cache_parameters nvarchar(200), @page_use_classification_meta bit, @page_use_copyright_meta bit, @page_use_language_meta bit, @page_use_robots_meta bit, @page_use_application_name_meta bit, @page_use_generator_meta bit, @page_use_javascript_inactive_refresh_meta bit, @page_use_description_meta bit, @page_use_revisit_after_meta bit, @page_use_rights_meta bit, @page_use_keywords_meta bit, @page_use_author_meta bit, @page_description_meta nvarchar(400), @page_revisit_after_meta varchar(50), @page_rights_meta nvarchar(400), @page_keywords_meta nvarchar(400), @page_robots_meta varchar(20), @page_copyright_meta nvarchar(400), @page_classification_meta nvarchar(400), @page_visit int, @page_use_html bit, @page_public_access_show bit, @page_query_string nvarchar(400), @page_category nvarchar(50)) as
begin

insert into el_page (page_global_name, page_name, user_id, page_public_site, page_title, page_date_create, page_time_create, page_active, page_directory_path, page_physical_name, page_use_language, page_use_module, page_use_plugin, page_use_replace_part, page_use_fetch, page_use_item, page_use_elanat, page_use_load_tag, page_use_static_head, page_show_link_in_site, page_load_type, page_load_tag, page_static_head, site_style_id, site_template_id, page_load_alone, page_cache_duration, page_cache_parameters, page_use_classification_meta, page_use_copyright_meta, page_use_language_meta, page_use_robots_meta, page_use_application_name_meta, page_use_generator_meta, page_use_javascript_inactive_refresh_meta, page_use_description_meta, page_use_revisit_after_meta, page_use_rights_meta, page_use_keywords_meta, page_use_author_meta, page_description_meta, page_revisit_after_meta, page_rights_meta, page_keywords_meta, page_robots_meta, page_copyright_meta, page_classification_meta, page_visit, page_use_html, page_public_access_show, page_query_string, page_category)
values (@page_global_name, @page_name, @user_id, @page_public_site, @page_title, @page_date_create, @page_time_create, @page_active, @page_directory_path, @page_physical_name, @page_use_language, @page_use_module, @page_use_plugin, @page_use_replace_part, @page_use_fetch, @page_use_item, @page_use_elanat, @page_use_load_tag, @page_use_static_head, @page_show_link_in_site, @page_load_type, @page_load_tag, @page_static_head, @site_style_id, @site_template_id, @page_load_alone, @page_cache_duration, @page_cache_parameters, @page_use_classification_meta, @page_use_copyright_meta, @page_use_language_meta, @page_use_robots_meta, @page_use_application_name_meta, @page_use_generator_meta, @page_use_javascript_inactive_refresh_meta, @page_use_description_meta, @page_use_revisit_after_meta, @page_use_rights_meta, @page_use_keywords_meta, @page_use_author_meta, @page_description_meta, @page_revisit_after_meta, @page_rights_meta, @page_keywords_meta, @page_robots_meta, @page_copyright_meta, @page_classification_meta, @page_visit, @page_use_html, @page_public_access_show, @page_query_string, @page_category)

declare @last_page_id int = SCOPE_IDENTITY();
exec get_current_page @last_page_id

end
GO
/****** Object:  StoredProcedure [add_patch]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [add_patch](@patch_name nvarchar(50), @patch_directory_path nvarchar(800), @patch_category nvarchar(50), @patch_active bit) as
begin

insert into el_patch (patch_name, patch_directory_path, patch_category, patch_active)
values (@patch_name, @patch_directory_path, @patch_category, @patch_active)
declare @last_patch_id int = SCOPE_IDENTITY();
exec get_current_patch @last_patch_id
 
end
GO
/****** Object:  StoredProcedure [add_plugin]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_plugin](@plugin_name nvarchar(50), @plugin_directory_path nvarchar(800), @plugin_physical_name nvarchar(255), @plugin_load_type varchar(10), @plugin_use_language bit, @plugin_use_module bit, @plugin_use_plugin bit, @plugin_use_replace_part bit, @plugin_use_fetch bit, @plugin_use_item bit, @plugin_use_elanat bit, @plugin_cache_duration int, @plugin_cache_parameters nvarchar(200), @plugin_public_access_add bit, @plugin_public_access_edit_own bit, @plugin_public_access_delete_own bit, @plugin_public_access_edit_all bit, @plugin_public_access_delete_all bit, @plugin_public_access_show bit, @plugin_sort_index int, @plugin_category nvarchar(50), @plugin_active bit) as
begin

insert into el_plugin (plugin_name, plugin_directory_path, plugin_physical_name, plugin_load_type, plugin_use_language, plugin_use_module, plugin_use_plugin, plugin_use_replace_part, plugin_use_fetch, plugin_use_item, plugin_use_elanat, plugin_cache_duration, plugin_cache_parameters, plugin_public_access_add, plugin_public_access_edit_own, plugin_public_access_delete_own, plugin_public_access_edit_all, plugin_public_access_delete_all, plugin_public_access_show, plugin_sort_index, plugin_category, plugin_active)
values (@plugin_name, @plugin_directory_path, @plugin_physical_name, @plugin_load_type, @plugin_use_language, @plugin_use_module, @plugin_use_plugin, @plugin_use_replace_part, @plugin_use_fetch, @plugin_use_item, @plugin_use_elanat, @plugin_cache_duration, @plugin_cache_parameters, @plugin_public_access_add, @plugin_public_access_edit_own, @plugin_public_access_delete_own, @plugin_public_access_edit_all, @plugin_public_access_delete_all, @plugin_public_access_show, @plugin_sort_index, @plugin_category, @plugin_active)
declare @last_plugin_id int = SCOPE_IDENTITY();
exec get_current_plugin @last_plugin_id
 
end
GO
/****** Object:  StoredProcedure [add_robot_ip_block]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [add_robot_ip_block](@user_ip varchar(39), @date_block char(10) ,@time_block char(8)) as
begin
 
insert into el_robot_detection_ip_block (robot_detection_ip_block_ip_address, robot_detection_ip_block_date_block, robot_detection_ip_block_time_block)
values (@user_ip, @date_block, @time_block)

end
GO
/****** Object:  StoredProcedure [add_role]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_role](@column_name nvarchar(max), @column_value nvarchar(max)) as
begin 

exec ('
insert into el_role (' + @column_name + ')
values (' + @column_value + ')
declare @last_role_id int = SCOPE_IDENTITY();
exec get_current_role @last_role_id
')

end
GO
/****** Object:  StoredProcedure [add_role_group]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [add_role_group](@role_id int, @group_id int) as
begin

insert into el_group_role (role_id, group_id)
values (@role_id,@group_id)

end
GO
/****** Object:  StoredProcedure [add_site]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_site](@site_global_name nvarchar(50), @site_name nvarchar(50), @site_slogan_name nvarchar(50), @language_id int, @page_id int, @site_title nvarchar(400), @site_date_create char(10), @site_time_create char(8), @site_active bit, @site_show_link_in_site bit, @site_style_id int, @site_template_id int, @admin_style_id int, @admin_template_id int, @site_static_head nvarchar(MAX), @site_calendar varchar(50), @site_first_day_of_week int, @site_date_format nvarchar(50), @site_time_format nvarchar(50), @site_time_zone float, @site_site_activities nvarchar(MAX), @site_address nvarchar(MAX), @site_phone_number varchar(50), @site_email nvarchar(254), @site_other_info nvarchar(MAX), @site_use_description_meta bit, @site_use_revisit_after_meta bit, @site_use_rights_meta bit, @site_use_keywords_meta bit, @site_use_classification_meta bit, @site_description_meta nvarchar(400), @site_revisit_after_meta varchar(50), @site_rights_meta nvarchar(400), @site_keywords_meta nvarchar(400), @site_classification_meta nvarchar(400), @site_visit int, @site_public_access_show bit) as
begin

insert into el_site (language_id, site_title, site_name, site_global_name, site_visit, page_id, site_slogan_name, site_date_create, site_time_create, site_site_activities, site_address, site_phone_number, site_email, site_other_info, site_style_id, site_template_id, admin_style_id, admin_template_id, site_active, site_static_head, site_use_description_meta, site_use_revisit_after_meta, site_use_rights_meta, site_use_keywords_meta, site_use_classification_meta, site_description_meta, site_revisit_after_meta, site_rights_meta, site_classification_meta, site_keywords_meta, site_show_link_in_site, site_calendar, site_first_day_of_week, site_time_zone, site_date_format, site_time_format, site_public_access_show)
values (@language_id, @site_title, @site_name, @site_global_name, @site_visit, @page_id, @site_slogan_name, @site_date_create, @site_time_create, @site_site_activities, @site_address, @site_phone_number, @site_email, @site_other_info, @site_style_id, @site_template_id, @admin_style_id, @admin_template_id, @site_active, @site_static_head, @site_use_description_meta, @site_use_revisit_after_meta, @site_use_rights_meta, @site_use_keywords_meta, @site_use_classification_meta, @site_description_meta, @site_revisit_after_meta, @site_rights_meta, @site_classification_meta, @site_keywords_meta, @site_show_link_in_site, @site_calendar, @site_first_day_of_week, @site_time_zone, @site_date_format, @site_time_format, @site_public_access_show)

declare @last_site_id int = SCOPE_IDENTITY();
exec get_current_site @last_site_id

end
GO
/****** Object:  StoredProcedure [add_site_style]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_site_style](@site_style_name nvarchar(50), @site_style_directory_path nvarchar(800), @site_style_physical_name nvarchar(255), @site_style_template nvarchar(50), @site_style_load_tag nvarchar(MAX), @site_style_static_head nvarchar(MAX), @site_style_active bit) as
begin 

insert into el_site_style (site_style_name , site_style_directory_path, site_style_physical_name, site_style_template, site_style_load_tag, site_style_static_head, site_style_active)
values (@site_style_name , @site_style_directory_path, @site_style_physical_name, @site_style_template, @site_style_load_tag, @site_style_static_head, @site_style_active)
declare @last_site_style_id int = SCOPE_IDENTITY();
exec get_current_site_style @last_site_style_id

end
GO
/****** Object:  StoredProcedure [add_site_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_site_template](@site_template_name nvarchar(50), @site_template_directory_path nvarchar(800), @site_template_physical_name nvarchar(255), @site_template_load_tag nvarchar(MAX), @site_template_static_head nvarchar(MAX), @site_template_active bit) as
begin 

insert into el_site_template (site_template_name , site_template_directory_path, site_template_physical_name, site_template_load_tag, site_template_static_head, site_template_active)
values (@site_template_name , @site_template_directory_path, @site_template_physical_name, @site_template_load_tag, @site_template_static_head, @site_template_active)
declare @last_site_template_id int = SCOPE_IDENTITY();
exec get_current_site_template @last_site_template_id

end
GO
/****** Object:  StoredProcedure [add_user]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_user](@user_name nvarchar(50), @group_id int, @user_site_name nvarchar(50), @user_real_name nvarchar(50), @user_real_last_name nvarchar(50), @user_password char(32), @user_date_create char(10), @user_active bit, @user_email nvarchar(254), @user_phone_number varchar(50), @user_address nvarchar(200), @user_postal_code varchar(50), @user_about varchar(200), @user_birthday char(10), @user_gender bit, @user_public_email nvarchar(254), @user_mobile_number varchar(50), @user_zip_code varchar(10), @user_email_is_confirm bit, @user_other_info nvarchar(MAX), @user_country nvarchar(50), @user_state_or_province nvarchar(50), @user_city nvarchar(50), @user_website nvarchar(255)) as
begin 

insert into el_user 
(user_name, group_id, user_site_name, user_real_name, user_real_last_name, user_password, user_date_create, user_active, user_email, user_phone_number, user_address, user_postal_code, user_about, user_birthday, user_gender, user_public_email, user_mobile_number, user_zip_code, user_email_is_confirm, user_other_info, user_country, user_state_or_province, user_city, user_website, user_last_login)
values
(@user_name, @group_id, @user_site_name, @user_real_name, @user_real_last_name, @user_password, @user_date_create, @user_active, @user_email, @user_phone_number, @user_address, @user_postal_code, @user_about, @user_birthday, @user_gender, @user_public_email, @user_mobile_number, @user_zip_code, @user_email_is_confirm, @user_other_info, @user_country, @user_state_or_province, @user_city, @user_website, '2000/01/01-00:00:00')

declare @last_user_id int = SCOPE_IDENTITY();
exec get_current_user @last_user_id

end
GO
/****** Object:  StoredProcedure [add_view]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_view](@view_name nvarchar(50), @view_include_header_bar_part bit, @view_show_header_bar_left bit, @view_show_header_bar_right bit, @view_show_header_bar_box bit, @view_fill_header_bar_left bit, @view_fill_header_bar_right bit, @view_fill_header_bar_box bit, @view_include_header_part bit, @view_show_header_menu bit, @view_show_header1 bit, @view_show_header2 bit, @view_fill_header_menu bit, @view_fill_header1 bit, @view_fill_header2 bit, @view_include_menu_part bit, @view_show_menu bit, @view_fill_menu bit, @view_include_main_part bit, @view_show_after_header bit, @view_show_before_content bit, @view_show_after_content bit, @view_show_right_menu bit, @view_show_left_menu bit, @view_show_before_footer bit, @view_fill_after_header bit, @view_fill_before_content bit, @view_fill_after_content bit, @view_fill_right_menu bit, @view_fill_left_menu bit, @view_fill_before_footer bit, @view_include_footer_part bit, @view_show_footer_menu bit, @view_show_footer1 bit, @view_show_footer2 bit, @view_fill_footer_menu bit, @view_fill_footer1 bit, @view_fill_footer2 bit, @view_include_footer_bar_part bit, @view_show_footer_bar_left bit, @view_show_footer_bar_right bit, @view_show_footer_bar_box bit, @view_fill_footer_bar_left bit, @view_fill_footer_bar_right bit, @view_fill_footer_bar_box bit, @view_common_light_background_color char(7), @view_common_light_text_color char(7), @view_common_middle_background_color char(7), @view_common_middle_text_color char(7), @view_common_dark_background_color char(7), @view_common_dark_text_color char(7), @view_natural_light_background_color char(7), @view_natural_light_text_color char(7), @view_natural_middle_background_color char(7), @view_natural_middle_text_color char(7), @view_natural_dark_background_color char(7), @view_natural_dark_text_color char(7), @view_background_color char(7), @view_font_size int, @view_static_head nvarchar(MAX), @site_style_id int, @site_template_id int, @view_match_type varchar(10), @view_active bit) as
begin 

insert into el_view (view_name, view_include_header_bar_part, view_show_header_bar_left, view_show_header_bar_right, view_show_header_bar_box, view_fill_header_bar_left, view_fill_header_bar_right, view_fill_header_bar_box, view_include_header_part, view_show_header_menu, view_show_header1, view_show_header2, view_fill_header_menu, view_fill_header1, view_fill_header2, view_include_menu_part, view_show_menu, view_fill_menu, view_include_main_part, view_show_after_header, view_show_before_content, view_show_after_content, view_show_right_menu, view_show_left_menu, view_show_before_footer, view_fill_after_header, view_fill_before_content, view_fill_after_content, view_fill_right_menu, view_fill_left_menu, view_fill_before_footer, view_include_footer_part, view_show_footer_menu, view_show_footer1, view_show_footer2, view_fill_footer_menu, view_fill_footer1, view_fill_footer2, view_include_footer_bar_part, view_show_footer_bar_left, view_show_footer_bar_right, view_show_footer_bar_box, view_fill_footer_bar_left, view_fill_footer_bar_right, view_fill_footer_bar_box, view_common_light_background_color, view_common_light_text_color, view_common_middle_background_color, view_common_middle_text_color, view_common_dark_background_color, view_common_dark_text_color, view_natural_light_background_color, view_natural_light_text_color, view_natural_middle_background_color, view_natural_middle_text_color, view_natural_dark_background_color, view_natural_dark_text_color, view_background_color, view_font_size, view_static_head, site_style_id, site_template_id, view_match_type, view_active)
values (@view_name, @view_include_header_bar_part, @view_show_header_bar_left, @view_show_header_bar_right, @view_show_header_bar_box, @view_fill_header_bar_left, @view_fill_header_bar_right, @view_fill_header_bar_box, @view_include_header_part, @view_show_header_menu, @view_show_header1, @view_show_header2, @view_fill_header_menu, @view_fill_header1, @view_fill_header2, @view_include_menu_part, @view_show_menu, @view_fill_menu, @view_include_main_part, @view_show_after_header, @view_show_before_content, @view_show_after_content, @view_show_right_menu, @view_show_left_menu, @view_show_before_footer, @view_fill_after_header, @view_fill_before_content, @view_fill_after_content, @view_fill_right_menu, @view_fill_left_menu, @view_fill_before_footer, @view_include_footer_part, @view_show_footer_menu, @view_show_footer1, @view_show_footer2, @view_fill_footer_menu, @view_fill_footer1, @view_fill_footer2, @view_include_footer_bar_part, @view_show_footer_bar_left, @view_show_footer_bar_right, @view_show_footer_bar_box, @view_fill_footer_bar_left, @view_fill_footer_bar_right, @view_fill_footer_bar_box, @view_common_light_background_color, @view_common_light_text_color, @view_common_middle_background_color, @view_common_middle_text_color, @view_common_dark_background_color, @view_common_dark_text_color, @view_natural_light_background_color, @view_natural_light_text_color, @view_natural_middle_background_color, @view_natural_middle_text_color, @view_natural_dark_background_color, @view_natural_dark_text_color, @view_background_color, @view_font_size, @view_static_head, @site_style_id, @site_template_id, @view_match_type, @view_active)
declare @last_view_id int = SCOPE_IDENTITY();
exec get_current_view @last_view_id

end
GO
/****** Object:  StoredProcedure [add_view_query_string]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [add_view_query_string](@view_id int, @view_query_string nvarchar(400)) as
begin
 
insert into el_view_query_string (view_id,view_query_string)
values (@view_id,@view_query_string)

end
GO
/****** Object:  StoredProcedure [approval_comment]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [approval_comment](@comment_id int) as
begin

update el_comment set comment_active = 1 where el_comment.comment_id = @comment_id

end
GO
/****** Object:  StoredProcedure [approval_content]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [approval_content](@content_id int) as
begin

update el_content set content_status = 'active'  where el_content.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [attachment_access_show_check]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [attachment_access_show_check](@attachment_id int, @role_id int) as
begin

if ((select el_attachment.attachment_public_access_show from el_attachment
	where el_attachment.attachment_id = @attachment_id) = 1)
	begin
		select 1 as attachment_access_show
	end
else if exists(select * from el_attachment_access_show
	left join el_role on el_role.role_id = el_attachment_access_show.role_id
	where el_attachment_access_show.attachment_id = @attachment_id
	and el_attachment_access_show.role_id = @role_id
	and el_role.role_active = 1)
	begin
		select 1 as attachment_access_show
	end
else
	begin
		select 0 as attachment_access_show
	end

end
GO
/****** Object:  StoredProcedure [attachment_access_show_check_by_group_id]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [attachment_access_show_check_by_group_id](@attachment_id int, @group_id int) as
begin

if ((select el_attachment.attachment_public_access_show from el_attachment
	where el_attachment.attachment_id = @attachment_id) = 1)
	begin
		select 1 as attachment_access_show
	end
else if exists(select * from el_attachment_access_show
	left join el_role on el_role.role_id = el_attachment_access_show.role_id
	join el_group_role on el_group_role.role_id = el_attachment_access_show.role_id
	where el_attachment_access_show.attachment_id = @attachment_id
	and el_group_role.group_id = @group_id
	and el_role.role_active = 1)
	begin
		select 1 as attachment_access_show
	end
else
	begin
		select 0 as attachment_access_show
	end
end
GO
/****** Object:  StoredProcedure [attachment_is_active]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [attachment_is_active](@attachment_id int) as
begin

select attachment_active from el_attachment
where attachment_id = @attachment_id

end
GO
/****** Object:  StoredProcedure [category_access_show_check]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [category_access_show_check](@category_id int, @role_id int) as
begin

if ((select el_category.category_public_access_show from el_category
	where el_category.category_id = @category_id) = 1)
	begin
		select 1 as category_access_show
	end
else if exists(select * from el_category_access_show
	left join el_role on el_role.role_id = el_category_access_show.role_id
	where el_category_access_show.category_id = @category_id
	and el_category_access_show.role_id = @role_id
	and el_role.role_active = 1)
	begin
		select 1 as category_access_show
	end
else
	begin
		select 0 as category_access_show
	end
	
	select el_category.parent_category from el_category where el_category.category_id = @category_id

end
GO
/****** Object:  StoredProcedure [category_access_show_check_by_group_id]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [category_access_show_check_by_group_id](@category_id int, @group_id int) as
begin

if ((select el_category.category_public_access_show from el_category
	where el_category.category_id = @category_id) = 1)
	begin
		select 1 as category_access_show
	end
else if exists(select * from el_category_access_show
	left join el_role on el_role.role_id = el_category_access_show.role_id
	join el_group_role on el_group_role.role_id = el_category_access_show.role_id
	where el_category_access_show.category_id = @category_id
	and el_group_role.group_id = @group_id
	and el_role.role_active = 1)
	begin
		select 1 as category_access_show
	end
else
	begin
		select 0 as category_access_show
	end
	
	select el_category.parent_category from el_category where el_category.category_id = @category_id

end
GO
/****** Object:  StoredProcedure [change_user_date_and_time]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [change_user_date_and_time](@user_id int,@user_calendar varchar(50), @user_first_day_of_week int, @user_date_format nvarchar(50), @user_time_format nvarchar(50), @user_day_difference int, @user_time_hours_difference int, @user_time_minutes_difference int, @user_time_zone float) as
begin

update el_user set

user_calendar = @user_calendar,
user_first_day_of_week = @user_first_day_of_week,
user_date_format = @user_date_format,
user_time_format = @user_time_format,
user_day_difference = @user_day_difference,
user_time_hours_difference = @user_time_hours_difference,
user_time_minutes_difference = @user_time_minutes_difference,
user_time_zone = @user_time_zone

 
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [change_user_email]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [change_user_email](@user_id int,@email nvarchar(254)) as
begin

update el_user set user_email = @email 
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [change_user_group]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [change_user_group](@user_id int, @group_id int) as
begin

update el_user set group_id = @group_id
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [change_user_language]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [change_user_language](@user_id int,@site_language_id int,@admin_language_id int) as
begin

update el_user set site_language_id = @site_language_id, admin_language_id = @admin_language_id
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [change_user_password]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [change_user_password](@user_id int,@password char(32)) as
begin

update el_user set user_password = @password 
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [change_user_template_and_style]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [change_user_template_and_style](@user_id int,@site_style_id int,@site_template_id int,@admin_style_id int,@admin_template_id int) as
begin

update el_user set

site_style_id = @site_style_id,
site_template_id = @site_template_id,
admin_style_id = @admin_style_id,
admin_template_id = @admin_template_id

where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [change_user_view]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [change_user_view](@user_id int, @user_background_color char(7), @user_font_size int, @user_common_light_background_color char(7), @user_common_light_text_color char(7), @user_common_middle_background_color char(7), @user_common_middle_text_color char(7), @user_common_dark_background_color char(7), @user_common_dark_text_color char(7), @user_natural_light_background_color char(7), @user_natural_light_text_color char(7), @user_natural_middle_background_color char(7), @user_natural_middle_text_color char(7), @user_natural_dark_background_color char(7), @user_natural_dark_text_color char(7),@user_user_info_background_color char(7), @user_user_info_font_color char(7), @user_show_user_avatar_in_user_info bit, @user_show_user_online_in_user_info bit, @user_show_user_email_in_user_info bit, @user_show_user_birthday_in_user_info bit, @user_show_user_gender_in_user_info bit, @user_show_user_phone_number_in_user_info bit, @user_show_user_mobile_number_in_user_info bit, @user_show_user_country_in_user_info bit, @user_show_user_state_or_province_in_user_info bit, @user_show_user_city_in_user_info bit, @user_show_user_zip_code_in_user_info bit, @user_show_user_postal_code_in_user_info bit, @user_show_user_address_in_user_info bit, @user_show_user_website_in_user_info bit, @user_show_user_last_login_in_user_info bit) as
begin

update el_user set

user_background_color = @user_background_color,
user_font_size = @user_font_size,
user_common_light_background_color = @user_common_light_background_color,
user_common_light_text_color = @user_common_light_text_color,
user_common_middle_background_color = @user_common_middle_background_color,
user_common_middle_text_color = @user_common_middle_text_color,
user_common_dark_background_color = @user_common_dark_background_color,
user_common_dark_text_color = @user_common_dark_text_color,
user_natural_light_background_color = @user_natural_light_background_color,
user_natural_light_text_color = @user_natural_light_text_color,
user_natural_middle_background_color = @user_natural_middle_background_color,
user_natural_middle_text_color = @user_natural_middle_text_color,
user_natural_dark_background_color = @user_natural_dark_background_color,
user_natural_dark_text_color = @user_natural_dark_text_color,
user_user_info_background_color = @user_user_info_background_color,
user_user_info_font_color = @user_user_info_font_color,
user_show_user_avatar_in_user_info = @user_show_user_avatar_in_user_info,
user_show_user_online_in_user_info = @user_show_user_online_in_user_info,
user_show_user_email_in_user_info = @user_show_user_email_in_user_info,
user_show_user_birthday_in_user_info = @user_show_user_birthday_in_user_info,
user_show_user_gender_in_user_info = @user_show_user_gender_in_user_info,
user_show_user_phone_number_in_user_info = @user_show_user_phone_number_in_user_info,
user_show_user_mobile_number_in_user_info = @user_show_user_mobile_number_in_user_info,
user_show_user_country_in_user_info = @user_show_user_country_in_user_info,
user_show_user_state_or_province_in_user_info = @user_show_user_state_or_province_in_user_info,
user_show_user_city_in_user_info = @user_show_user_city_in_user_info,
user_show_user_zip_code_in_user_info = @user_show_user_zip_code_in_user_info,
user_show_user_postal_code_in_user_info = @user_show_user_postal_code_in_user_info,
user_show_user_address_in_user_info = @user_show_user_address_in_user_info,
user_show_user_website_in_user_info = @user_show_user_website_in_user_info,
user_show_user_last_login_in_user_info = @user_show_user_last_login_in_user_info
 
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [check_component_access_by_component_name]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [check_component_access_by_component_name](@component_name nvarchar(50), @group_id int) as
begin

declare @component_id int = (select el_component.component_id from el_component where el_component.component_name = @component_name)

select
cast(sum(cast(el_component_role_access.component_add as int)) as bit) as component_add,
cast(sum(cast(el_component_role_access.component_edit_own as int)) as bit) as component_edit_own,
cast(sum(cast(el_component_role_access.component_delete_own as int)) as bit) as component_delete_own,
cast(sum(cast(el_component_role_access.component_edit_all as int)) as bit) as component_edit_all,
cast(sum(cast(el_component_role_access.component_delete_all as int)) as bit) as component_delete_all,
cast(sum(cast(el_component_role_access.component_show as int)) as bit) as component_show 

from el_component
left join el_component_role_access on el_component.component_id = el_component_role_access.component_id
left join el_role on el_role.role_id = el_component_role_access.role_id
join el_group_role on el_group_role.role_id = el_component_role_access.role_id
where el_group_role.group_id = @group_id
and el_component.component_id = @component_id
and el_role.role_active = 1

end
GO
/****** Object:  StoredProcedure [check_module_access_by_module_name]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [check_module_access_by_module_name](@module_name nvarchar(50), @group_id int) as
begin

declare @module_id int = (select el_module.module_id from el_module where el_module.module_name = @module_name)

select
cast(sum(cast(el_module_role_access.module_add as int)) as bit) as module_add,
cast(sum(cast(el_module_role_access.module_edit_own as int)) as bit) as module_edit_own,
cast(sum(cast(el_module_role_access.module_delete_own as int)) as bit) as module_delete_own,
cast(sum(cast(el_module_role_access.module_edit_all as int)) as bit) as module_edit_all,
cast(sum(cast(el_module_role_access.module_delete_all as int)) as bit) as module_delete_all,
cast(sum(cast(el_module_role_access.module_show as int)) as bit) as module_show 

from el_module
left join el_module_role_access on el_module.module_id = el_module_role_access.module_id
left join el_role on el_role.role_id = el_module_role_access.role_id
join el_group_role on el_group_role.role_id = el_module_role_access.role_id
where el_group_role.group_id = @group_id
and el_module.module_id = @module_id
and el_role.role_active = 1

end
GO
/****** Object:  StoredProcedure [check_plugin_access_by_plugin_name]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [check_plugin_access_by_plugin_name](@plugin_name nvarchar(50), @group_id int) as
begin

declare @plugin_id int = (select el_plugin.plugin_id from el_plugin where el_plugin.plugin_name = @plugin_name)

select
cast(sum(cast(el_plugin_role_access.plugin_add as int)) as bit) as plugin_add,
cast(sum(cast(el_plugin_role_access.plugin_edit_own as int)) as bit) as plugin_edit_own,
cast(sum(cast(el_plugin_role_access.plugin_delete_own as int)) as bit) as plugin_delete_own,
cast(sum(cast(el_plugin_role_access.plugin_edit_all as int)) as bit) as plugin_edit_all,
cast(sum(cast(el_plugin_role_access.plugin_delete_all as int)) as bit) as plugin_delete_all,
cast(sum(cast(el_plugin_role_access.plugin_show as int)) as bit) as plugin_show 

from el_plugin
left join el_plugin_role_access on el_plugin.plugin_id = el_plugin_role_access.plugin_id
left join el_role on el_role.role_id = el_plugin_role_access.role_id
join el_group_role on el_group_role.role_id = el_plugin_role_access.role_id
where el_group_role.group_id = @group_id
and el_plugin.plugin_id = @plugin_id
and el_role.role_active = 1

end
GO
/****** Object:  StoredProcedure [check_user_comment_sent_without_approval_by_group_id]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [check_user_comment_sent_without_approval_by_group_id](@group_id int) as
begin 

select 
cast(count(el_role.role_add_free_comment_content) as bit) as role_add_free_comment_content from el_role
join el_group_role on el_group_role.role_id = el_role.role_id
where el_group_role.group_id = @group_id
and el_role.role_active = 1

end
GO
/****** Object:  StoredProcedure [check_user_comment_sent_without_approval_by_role_id]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [check_user_comment_sent_without_approval_by_role_id](@role_id int) as
begin 

select el_role.role_add_free_comment_content from el_role
where el_role.role_id = @role_id
and el_role.role_active = 1

end
GO
/****** Object:  StoredProcedure [content_access_show_check]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [content_access_show_check](@content_id int, @role_id int) as
begin

if ((select el_content.content_public_access_show from el_content
	where el_content.content_id = @content_id) = 1)
	begin
		select 1 as content_access_show
	end
else if exists(select * from el_content_access_show
	where el_content_access_show.content_id = @content_id
	and el_content_access_show.role_id = @role_id)
	begin
		select 1 as content_access_show
	end
else
	begin
		select 0 as content_access_show
	end

end
GO
/****** Object:  StoredProcedure [content_access_show_check_by_group_id]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [content_access_show_check_by_group_id](@content_id int, @group_id int) as
begin

if ((select el_content.content_public_access_show from el_content
	where el_content.content_id = @content_id) = 1)
	begin
		select 1 as content_access_show
	end
else if exists(select * from el_content_access_show
	join el_group_role on el_group_role.role_id = el_content_access_show.role_id
	where el_content_access_show.content_id = @content_id
	and el_group_role.group_id = @group_id)
	begin
		select 1 as content_access_show
	end
else
	begin
		select 0 as content_access_show
	end

end
GO
/****** Object:  StoredProcedure [content_to_trash]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [content_to_trash](@content_id int) as
begin

update el_content set content_status = 'trash'  where el_content.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [date_visit_statistics_exist_check]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [date_visit_statistics_exist_check](@date_visit char(10),@IsTrue BIT OUTPUT) as
begin

if (select el_visit_statistics.visit_statistics_date_visit from el_visit_statistics where el_visit_statistics.visit_statistics_date_visit = @date_visit) > 0
begin
    SET @IsTrue = 0x1
end
    SET @IsTrue = 0x0
    
end
GO
/****** Object:  StoredProcedure [decrease_user_upload]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [decrease_user_upload](@user_id int, @file_size varchar(13)) as
begin

declare @tmp_size_of_upload bigint = convert(bigint, (select el_user.user_size_of_upload from el_user))
declare @tmp_file_size bigint = convert(bigint, @file_size)
declare @new_size_of_upload bigint = @tmp_size_of_upload - @tmp_file_size

update el_user set
user_size_of_upload = convert(varchar(13), @new_size_of_upload),
user_number_of_upload = user_number_of_upload - 1
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [delete_admin_style]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_admin_style](@admin_style_id int) as
begin

delete from el_admin_style where el_admin_style.admin_style_id = @admin_style_id

end
GO
/****** Object:  StoredProcedure [delete_admin_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_admin_template](@admin_template_id int) as
begin

delete from el_admin_template where el_admin_template.admin_template_id = @admin_template_id

end
GO
/****** Object:  StoredProcedure [delete_all_foot_print]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_all_foot_print] as
begin

delete from el_foot_print

end
GO
/****** Object:  StoredProcedure [delete_attachment]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_attachment](@attachment_id int) as
begin

delete from el_attachment  where el_attachment.attachment_id = @attachment_id
exec delete_attachment_access_show @attachment_id

end
GO
/****** Object:  StoredProcedure [delete_attachment_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_attachment_access_show](@attachment_id int) as
begin
 
delete from el_attachment_access_show
where attachment_id = @attachment_id

end
GO
/****** Object:  StoredProcedure [delete_attachment_content]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_attachment_content](@attachment_id int) as
begin
 
delete from el_content_attachment
where attachment_id = @attachment_id

end
GO
/****** Object:  StoredProcedure [delete_category]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_category](@category_id int) as
begin

delete from el_category where el_category.category_id = @category_id
exec delete_category_access_show @category_id

end
GO
/****** Object:  StoredProcedure [delete_category_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_category_access_show](@category_id int) as
begin
 
delete from el_category_access_show
where category_id = @category_id

end
GO
/****** Object:  StoredProcedure [delete_comment]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_comment](@comment_id int) as
begin

delete from el_comment where el_comment.comment_id = @comment_id

end
GO
/****** Object:  StoredProcedure [delete_component]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_component](@component_id int) as
begin

delete from el_component  where el_component.component_id = @component_id
exec delete_component_role_access @component_id

end
GO
/****** Object:  StoredProcedure [delete_component_role_access]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_component_role_access](@component_id int) as
begin
 
delete from el_component_role_access
where component_id = @component_id

end
GO
/****** Object:  StoredProcedure [delete_contact]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_contact](@contact_id int) as
begin

delete from el_contact where el_contact.contact_id = @contact_id

end
GO
/****** Object:  StoredProcedure [delete_content]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_content](@content_id int) as
begin

delete from el_content where el_content.content_id = @content_id
exec delete_content_access_show @content_id
exec delete_content_avatar @content_id
exec delete_content_icon @content_id
exec delete_content_keywords @content_id
exec delete_content_rating @content_id
exec delete_content_reply @content_id
exec delete_content_source @content_id

end
GO
/****** Object:  StoredProcedure [delete_content_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_content_access_show](@content_id int) as
begin
 
delete from el_content_access_show
where content_id = @content_id

end
GO
/****** Object:  StoredProcedure [delete_content_avatar]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_content_avatar](@content_id int) as
begin
 
delete from el_content_avatar
where content_id = @content_id

end
GO
/****** Object:  StoredProcedure [delete_content_icon]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_content_icon](@content_id int) as
begin
 
delete from el_content_icon
where content_id = @content_id

end
GO
/****** Object:  StoredProcedure [delete_content_keywords]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_content_keywords](@content_id int) as
begin
 
delete from el_content_keywords
where content_id = @content_id

end
GO
/****** Object:  StoredProcedure [delete_content_rating]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [delete_content_rating](@content_id int) as
begin
 
delete from el_content_rating
where content_id = @content_id

end
GO
/****** Object:  StoredProcedure [delete_content_reply]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_content_reply](@content_reply_id int) as
begin

delete from el_content_reply where el_content_reply.content_reply_id = @content_reply_id

end
GO
/****** Object:  StoredProcedure [delete_content_source]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_content_source](@content_id int) as
begin
 
delete from el_content_source
where content_id = @content_id

end
GO
/****** Object:  StoredProcedure [delete_editor_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_editor_template](@editor_template_id int) as
begin

delete from el_editor_template where el_editor_template.editor_template_id = @editor_template_id
exec delete_editor_template_access_show @editor_template_id

end
GO
/****** Object:  StoredProcedure [delete_editor_template_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_editor_template_access_show](@editor_template_id int) as
begin
 
delete from el_editor_template_access_show
where editor_template_id = @editor_template_id

end
GO
/****** Object:  StoredProcedure [delete_extra_helper]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_extra_helper](@extra_helper_id int) as
begin

delete from el_extra_helper where el_extra_helper.extra_helper_id = @extra_helper_id
exec delete_extra_helper_access_show @extra_helper_id

end
GO
/****** Object:  StoredProcedure [delete_extra_helper_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_extra_helper_access_show](@extra_helper_id int) as
begin
 
delete from el_extra_helper_access_show
where extra_helper_id = @extra_helper_id

end
GO
/****** Object:  StoredProcedure [delete_fetch]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_fetch](@fetch_id int) as
begin

delete from el_fetch where el_fetch.fetch_id = @fetch_id
exec delete_fetch_access_show @fetch_id

end
GO
/****** Object:  StoredProcedure [delete_fetch_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_fetch_access_show](@fetch_id int) as
begin
 
delete from el_fetch_access_show
where fetch_id = @fetch_id

end
GO
/****** Object:  StoredProcedure [delete_foot_print]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_foot_print](@foot_print_id int) as
begin

delete from el_foot_print
where el_foot_print.foot_print_id = @foot_print_id

end
GO
/****** Object:  StoredProcedure [delete_group]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [delete_group](@group_id int) as
begin

delete from el_group where el_group.group_id = @group_id

end
GO
/****** Object:  StoredProcedure [delete_group_foot_print]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [delete_group_foot_print](@group_id int) as
begin
 
delete el_foot_print from el_foot_print
left join el_user on el_user.user_id = el_foot_print.user_id
where el_user.group_id = @group_id

end
GO
/****** Object:  StoredProcedure [delete_item]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_item](@item_id int) as
begin

delete from el_item where el_item.item_id = @item_id
exec delete_item_access_show @item_id

end
GO
/****** Object:  StoredProcedure [delete_item_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_item_access_show](@item_id int) as
begin
 
delete from el_item_access_show
where item_id = @item_id

end
GO
/****** Object:  StoredProcedure [delete_language]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_language](@language_id int) as
begin

delete from el_language where el_language.language_id = @language_id

end
GO
/****** Object:  StoredProcedure [delete_link]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_link](@link_id int) as
begin

delete from el_link where el_link.link_id = @link_id

end
GO
/****** Object:  StoredProcedure [delete_menu]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_menu](@menu_id int) as
begin

delete from el_menu where el_menu.menu_id = @menu_id
exec delete_menu_access_show @menu_id
exec delete_menu_fetch @menu_id
exec delete_menu_item @menu_id
exec delete_menu_link @menu_id
exec delete_menu_module @menu_id
exec delete_menu_plugin @menu_id

end
GO
/****** Object:  StoredProcedure [delete_menu_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_menu_access_show](@menu_id int) as
begin
 
delete from el_menu_access_show
where menu_id = @menu_id

end
GO
/****** Object:  StoredProcedure [delete_menu_fetch]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_menu_fetch](@fetch_id int) as
begin

delete from el_menu_fetch
where fetch_id = @fetch_id

end
GO
/****** Object:  StoredProcedure [delete_menu_item]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_menu_item](@item_id int) as
begin

delete from el_menu_item
where item_id = @item_id

end
GO
/****** Object:  StoredProcedure [delete_menu_link]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_menu_link](@link_id int) as
begin

delete from el_menu_link
where link_id = @link_id

end
GO
/****** Object:  StoredProcedure [delete_menu_module]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_menu_module](@module_id int) as
begin

delete from el_menu_module
where module_id = @module_id

end
GO
/****** Object:  StoredProcedure [delete_menu_plugin]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_menu_plugin](@plugin_id int) as
begin

delete from el_menu_plugin
where plugin_id = @plugin_id

end
GO
/****** Object:  StoredProcedure [delete_module]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_module](@module_id int) as
begin

delete from el_module  where el_module.module_id = @module_id
exec delete_module_role_access @module_id

end
GO
/****** Object:  StoredProcedure [delete_module_role_access]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_module_role_access](@module_id int) as
begin

delete from el_module_role_access
where module_id = @module_id

end
GO
/****** Object:  StoredProcedure [delete_page]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_page](@page_id int) as
begin

delete from el_page  where el_page.page_id = @page_id
exec delete_page_access_show @page_id

end
GO
/****** Object:  StoredProcedure [delete_page_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_page_access_show](@page_id int) as
begin

delete from el_page_access_show
where page_id = @page_id

end
GO
/****** Object:  StoredProcedure [delete_page_site]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_page_site](@page_id int) as
begin

delete from el_site_page
where page_id = @page_id

end
GO
/****** Object:  StoredProcedure [delete_patch]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [delete_patch](@patch_id int) as
begin

delete from el_patch  where el_patch.patch_id = @patch_id

end
GO
/****** Object:  StoredProcedure [delete_plugin]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_plugin](@plugin_id int) as
begin

delete from el_plugin  where el_plugin.plugin_id = @plugin_id
exec delete_plugin_role_access @plugin_id

end
GO
/****** Object:  StoredProcedure [delete_plugin_role_access]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_plugin_role_access](@plugin_id int) as
begin

delete from el_plugin_role_access
where plugin_id = @plugin_id

end
GO
/****** Object:  StoredProcedure [delete_robot_blocked_ip]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [delete_robot_blocked_ip](@current_date char(10),@current_time char(8)) as
begin

delete from el_robot_detection_ip_block
where el_robot_detection_ip_block.robot_detection_ip_block_date_block <= @current_date
and el_robot_detection_ip_block.robot_detection_ip_block_time_block <= @current_time

end
GO
/****** Object:  StoredProcedure [delete_role]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_role](@role_id int) as
begin

delete from el_role where el_role.role_id = @role_id and el_role.role_name <> 'guest'

end
GO
/****** Object:  StoredProcedure [delete_role_group]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [delete_role_group](@group_id int) as
begin
 
delete from el_group_role
where group_id = @group_id

end
GO
/****** Object:  StoredProcedure [delete_site]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_site](@site_id int) as
begin

delete from el_site where el_site.site_id = @site_id
exec delete_site_access_show @site_id

end
GO
/****** Object:  StoredProcedure [delete_site_access_show]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_site_access_show](@site_id int) as
begin

delete from el_site_access_show
where site_id = @site_id

end
GO
/****** Object:  StoredProcedure [delete_site_style]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_site_style](@site_style_id int) as
begin

delete from el_site_style where el_site_style.site_style_id = @site_style_id

end
GO
/****** Object:  StoredProcedure [delete_site_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_site_template](@site_template_id int) as
begin

delete from el_site_template where el_site_template.site_template_id = @site_template_id

end
GO
/****** Object:  StoredProcedure [delete_user]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_user](@user_id int) as
begin

delete from el_user where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [delete_user_foot_print]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_user_foot_print](@user_id int) as
begin

delete from el_foot_print
where el_foot_print.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [delete_view]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_view](@view_id int) as
begin

delete from el_view where el_view.view_id = @view_id
exec delete_view_query_string @view_id

end
GO
/****** Object:  StoredProcedure [delete_view_query_string]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [delete_view_query_string](@view_id int) as
begin

delete from el_view_query_string
where view_id = @view_id

end
GO
/****** Object:  StoredProcedure [edit_admin_style]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_admin_style](@admin_style_id int, @admin_style_name nvarchar(50), @admin_style_directory_path nvarchar(800), @admin_style_physical_name nvarchar(255), @admin_style_template nvarchar(50), @admin_style_load_tag nvarchar(MAX), @admin_style_static_head nvarchar(MAX), @admin_style_active bit) as
begin

update el_admin_style set
admin_style_name = @admin_style_name,
admin_style_directory_path = @admin_style_directory_path,
admin_style_physical_name = @admin_style_physical_name,
admin_style_template = @admin_style_template,
admin_style_load_tag = @admin_style_load_tag,
admin_style_static_head = @admin_style_static_head,
admin_style_active = @admin_style_active
where admin_style_id = @admin_style_id

end
GO
/****** Object:  StoredProcedure [edit_admin_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_admin_template](@admin_template_id int, @admin_template_name nvarchar(50), @admin_template_directory_path nvarchar(800), @admin_template_physical_name nvarchar(255), @admin_template_load_tag nvarchar(MAX), @admin_template_static_head nvarchar(MAX), @admin_template_active bit) as
begin

update el_admin_template set
admin_template_name = @admin_template_name,
admin_template_directory_path = @admin_template_directory_path,
admin_template_physical_name = @admin_template_physical_name,
admin_template_load_tag = @admin_template_load_tag,
admin_template_static_head = @admin_template_static_head,
admin_template_active = @admin_template_active
where admin_template_id = @admin_template_id

end
GO
/****** Object:  StoredProcedure [edit_admin_user_profile]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [edit_admin_user_profile](@user_id int, @user_name nvarchar(50), @user_site_name nvarchar(50), @user_real_name nvarchar(50), @user_real_last_name nvarchar(50), @user_phone_number varchar(50), @user_address nvarchar(200), @user_postal_code varchar(50), @user_about varchar(200), @user_birthday char(10), @user_gender bit, @user_public_email nvarchar(254), @user_mobile_number varchar(50), @user_zip_code varchar(10), @user_other_info nvarchar(MAX), @user_country nvarchar(50), @user_state_or_province nvarchar(50), @user_city nvarchar(50), @user_website nvarchar(255)) as
begin

update el_user set
user_name = @user_name,
user_site_name = @user_site_name,
user_real_name = @user_real_name,
user_real_last_name = @user_real_last_name,
user_phone_number = @user_phone_number,
user_address = @user_address,
user_postal_code = @user_postal_code,
user_about = @user_about,
user_birthday = @user_birthday,
user_gender = @user_gender,
user_public_email = @user_public_email,
user_mobile_number = @user_mobile_number,
user_zip_code = @user_zip_code,
user_other_info = @user_other_info,
user_country = @user_country,
user_state_or_province = @user_state_or_province,
user_city = @user_city,
user_website = @user_website
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [edit_attachment]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_attachment](@attachment_id int, @attachment_name nvarchar(50), @attachment_about nvarchar(400), @attachment_password nvarchar(50), @attachment_active bit, @attachment_public_access_show bit) as
begin

update el_attachment set
attachment_name = @attachment_name,
attachment_about = @attachment_about,
attachment_password = @attachment_password,
attachment_active = @attachment_active,
attachment_public_access_show = @attachment_public_access_show
where el_attachment.attachment_id = @attachment_id

end
GO
/****** Object:  StoredProcedure [edit_category]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_category](@category_id int, @site_id int,@category_name nvarchar(50),@require_approval bit, @parent_category int, @site_style_id int, @site_template_id int, @category_public_access_show bit,@category_active bit) as
begin

update el_category set
site_id = @site_id,
category_name = @category_name,
require_approval = @require_approval,
parent_category = @parent_category,
site_style_id = @site_style_id,
site_template_id = @site_template_id,
category_public_access_show = @category_public_access_show,
category_active = @category_active
where category_id = @category_id

end
GO
/****** Object:  StoredProcedure [edit_comment]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_comment](@comment_id int, @content_id int, @user_id int, @parent_comment int, @comment_guest_name nvarchar(50), @comment_guest_real_name nvarchar(50), @comment_guest_real_last_name nvarchar(50), @comment_guest_email nvarchar(254), @comment_title nvarchar(200), @comment_text nvarchar(800), @comment_date_send char(10), @comment_time_send char(8), @comment_active bit, @comment_ip_address varchar(39), @comment_file_directory_path nvarchar(800), @comment_file_physical_name nvarchar(255), @comment_type varchar(50), @comment_guest_phone_number varchar(50), @comment_guest_address nvarchar(200), @comment_guest_postal_code varchar(50), @comment_guest_about varchar(200), @comment_guest_birthday char(10), @comment_guest_gender bit, @comment_guest_public_email nvarchar(254), @comment_guest_mobile_number varchar(50), @comment_guest_zip_code varchar(10), @comment_guest_country nvarchar(50), @comment_guest_state_or_province nvarchar(50), @comment_guest_city nvarchar(50), @comment_guest_website nvarchar(255)) as
begin

update el_comment set
content_id = @content_id,
user_id = coalesce(nullif(user_id,''), @user_id),
parent_comment = @parent_comment,
comment_guest_name = @comment_guest_name,
comment_guest_real_name = @comment_guest_real_name,
comment_guest_real_last_name = @comment_guest_real_last_name,
comment_guest_email = @comment_guest_email,
comment_title = @comment_title,
comment_text = @comment_text,
comment_date_send = @comment_date_send,
comment_time_send = @comment_time_send,
comment_active = @comment_active,
comment_ip_address = @comment_ip_address,
comment_file_directory_path = @comment_file_directory_path,
comment_file_physical_name = @comment_file_physical_name,
comment_type = @comment_type,
comment_guest_phone_number = @comment_guest_phone_number,
comment_guest_address = @comment_guest_address,
comment_guest_postal_code = @comment_guest_postal_code,
comment_guest_about = @comment_guest_about,
comment_guest_birthday = @comment_guest_birthday,
comment_guest_gender = @comment_guest_gender,
comment_guest_public_email = @comment_guest_public_email,
comment_guest_mobile_number = @comment_guest_mobile_number,
comment_guest_zip_code = @comment_guest_zip_code,
comment_guest_country = @comment_guest_country,
comment_guest_state_or_province = @comment_guest_state_or_province,
comment_guest_city = @comment_guest_city,
comment_guest_website = @comment_guest_website
where comment_id = @comment_id

end
GO
/****** Object:  StoredProcedure [edit_component]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_component](@component_id int, @component_load_type varchar(10), @component_use_language bit, @component_use_module bit, @component_use_plugin bit, @component_use_replace_part bit, @component_use_fetch bit, @component_use_item bit, @component_use_elanat bit, @component_cache_duration int, @component_cache_parameters nvarchar(200), @component_public_access_add bit, @component_public_access_edit_own bit, @component_public_access_delete_own bit, @component_public_access_edit_all bit, @component_public_access_delete_all bit, @component_public_access_show bit, @component_sort_index int, @component_category nvarchar(50), @component_active bit) as
begin

update el_component set
component_active = @component_active,
component_load_type = @component_load_type,
component_use_language = @component_use_language,
component_use_module = @component_use_module,
component_use_plugin = @component_use_plugin,
component_use_replace_part = @component_use_replace_part,
component_use_fetch = @component_use_fetch,
component_use_item = @component_use_item,
component_use_elanat = @component_use_elanat,
component_cache_duration = @component_cache_duration,
component_cache_parameters = @component_cache_parameters,
component_public_access_add = @component_public_access_add,
component_public_access_edit_own = @component_public_access_edit_own,
component_public_access_delete_own = @component_public_access_delete_own,
component_public_access_edit_all = @component_public_access_edit_all,
component_public_access_delete_all = @component_public_access_delete_all,
component_public_access_show = @component_public_access_show,
component_sort_index = @component_sort_index,
component_category = @component_category
where component_id = @component_id

end
GO
/****** Object:  StoredProcedure [edit_contact]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_contact](@contact_id int, @user_id int, @contact_guest_name nvarchar(50), @contact_guest_real_name nvarchar(50), @contact_guest_real_last_name nvarchar(50), @contact_guest_email nvarchar(254), @contact_title nvarchar(200), @contact_text nvarchar(800), @contact_date_send char(10), @contact_time_send char(8), @contact_ip_address varchar(39), @contact_file_directory_path nvarchar(800), @contact_file_physical_name nvarchar(255), @contact_type varchar(50), @contact_guest_phone_number varchar(50), @contact_guest_address nvarchar(200), @contact_guest_postal_code varchar(50), @contact_guest_about varchar(200), @contact_guest_birthday char(10), @contact_guest_gender bit, @contact_guest_public_email nvarchar(254), @contact_guest_mobile_number varchar(50), @contact_guest_zip_code varchar(10), @contact_guest_country nvarchar(50), @contact_guest_state_or_province nvarchar(50), @contact_guest_city nvarchar(50), @contact_guest_website nvarchar(255)) as
begin

update el_contact set
user_id = coalesce(nullif(user_id,''), @user_id),
contact_guest_name = @contact_guest_name,
contact_guest_real_name = @contact_guest_real_name,
contact_guest_real_last_name = @contact_guest_real_last_name,
contact_guest_email = @contact_guest_email,
contact_title = @contact_title,
contact_text = @contact_text,
contact_date_send = @contact_date_send,
contact_time_send = @contact_time_send,
contact_ip_address = @contact_ip_address,
contact_file_directory_path = @contact_file_directory_path,
contact_file_physical_name = @contact_file_physical_name,
contact_type = @contact_type,
contact_guest_phone_number = @contact_guest_phone_number,
contact_guest_address = @contact_guest_address,
contact_guest_postal_code = @contact_guest_postal_code,
contact_guest_about = @contact_guest_about,
contact_guest_birthday = @contact_guest_birthday,
contact_guest_gender = @contact_guest_gender,
contact_guest_public_email = @contact_guest_public_email,
contact_guest_mobile_number = @contact_guest_mobile_number,
contact_guest_zip_code = @contact_guest_zip_code,
contact_guest_country = @contact_guest_country,
contact_guest_state_or_province = @contact_guest_state_or_province,
contact_guest_city = @contact_guest_city,
contact_guest_website = @contact_guest_website
where contact_id = @contact_id

end
GO
/****** Object:  StoredProcedure [edit_content]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_content](@content_id int, @user_id int, @category_id int, @content_title nvarchar(200), @content_text nvarchar(MAX), @content_date_create char(10), @content_time_create char(8), @content_always_on_top bit, @content_status varchar(20), @content_type varchar(20), @content_verify_comments bit, @content_password nvarchar(50), @content_visit int, @content_public_access_show bit) as
begin

update el_content set
user_id = coalesce(nullif(user_id,''), @user_id),
category_id = @category_id,
content_title = @content_title,
content_text = @content_text,
content_date_create = @content_date_create,
content_time_create = @content_time_create,
content_always_on_top = @content_always_on_top,
content_status = @content_status,
content_type = @content_type,
content_verify_comments = @content_verify_comments,
content_password = @content_password,
content_visit = coalesce(nullif(content_visit,''), @content_visit),
content_public_access_show = @content_public_access_show
where content_id = @content_id

end
GO
/****** Object:  StoredProcedure [edit_content_reply]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_content_reply](@content_reply_id int, @content_id int, @user_id int, @content_reply_guest_name nvarchar(50), @content_reply_guest_real_name nvarchar(50), @content_reply_guest_real_last_name nvarchar(50), @content_reply_guest_email nvarchar(254), @content_reply_text nvarchar(800), @content_reply_date_send char(10), @content_reply_time_send char(8), @content_reply_active bit, @content_reply_ip_address varchar(39), @content_reply_type varchar(50), @content_reply_guest_phone_number varchar(50), @content_reply_guest_address nvarchar(200), @content_reply_guest_postal_code varchar(50), @content_reply_guest_about varchar(200), @content_reply_guest_birthday char(10), @content_reply_guest_gender bit, @content_reply_guest_public_email nvarchar(254), @content_reply_guest_mobile_number varchar(50), @content_reply_guest_zip_code varchar(10), @content_reply_guest_country nvarchar(50), @content_reply_guest_state_or_province nvarchar(50), @content_reply_guest_city nvarchar(50), @content_reply_guest_website nvarchar(255)) as
begin

update el_content_reply set
content_id = @content_id,
user_id = coalesce(nullif(user_id,''), @user_id),
content_reply_guest_name = @content_reply_guest_name,
content_reply_guest_real_name = @content_reply_guest_real_name,
content_reply_guest_real_last_name = @content_reply_guest_real_last_name,
content_reply_guest_email = @content_reply_guest_email,
content_reply_text = @content_reply_text,
content_reply_date_send = @content_reply_date_send,
content_reply_time_send = @content_reply_time_send,
content_reply_active = @content_reply_active,
content_reply_ip_address = @content_reply_ip_address,
content_reply_type = @content_reply_type,
content_reply_guest_phone_number = @content_reply_guest_phone_number,
content_reply_guest_address = @content_reply_guest_address,
content_reply_guest_postal_code = @content_reply_guest_postal_code,
content_reply_guest_about = @content_reply_guest_about,
content_reply_guest_birthday = @content_reply_guest_birthday,
content_reply_guest_gender = @content_reply_guest_gender,
content_reply_guest_public_email = @content_reply_guest_public_email,
content_reply_guest_mobile_number = @content_reply_guest_mobile_number,
content_reply_guest_zip_code = @content_reply_guest_zip_code,
content_reply_guest_country = @content_reply_guest_country,
content_reply_guest_state_or_province = @content_reply_guest_state_or_province,
content_reply_guest_city = @content_reply_guest_city,
content_reply_guest_website = @content_reply_guest_website
where content_reply_id = @content_reply_id

end
GO
/****** Object:  StoredProcedure [edit_editor_template]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_editor_template](@editor_template_id int, @editor_template_use_language bit, @editor_template_use_module bit, @editor_template_use_plugin bit, @editor_template_use_replace_part bit, @editor_template_use_fetch bit, @editor_template_use_item bit, @editor_template_use_elanat bit, @editor_template_cache_duration int, @editor_template_cache_parameters nvarchar(200), @editor_template_public_access_show bit, @editor_template_sort_index int, @editor_template_category nvarchar(50), @editor_template_active bit) as
begin

update el_editor_template set
editor_template_use_language = @editor_template_use_language,
editor_template_use_module = @editor_template_use_module,
editor_template_use_plugin = @editor_template_use_plugin,
editor_template_use_replace_part = @editor_template_use_replace_part,
editor_template_use_fetch = @editor_template_use_fetch,
editor_template_use_item = @editor_template_use_item,
editor_template_use_elanat = @editor_template_use_elanat,
editor_template_cache_duration = @editor_template_cache_duration,
editor_template_cache_parameters = @editor_template_cache_parameters,
editor_template_active = @editor_template_active,
editor_template_public_access_show = @editor_template_public_access_show,
editor_template_sort_index = @editor_template_sort_index,
editor_template_category = @editor_template_category
where editor_template_id = @editor_template_id

end
GO
/****** Object:  StoredProcedure [edit_extra_helper]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_extra_helper](@extra_helper_id int, @extra_helper_use_language bit, @extra_helper_use_module bit, @extra_helper_use_plugin bit, @extra_helper_use_replace_part bit, @extra_helper_use_fetch bit, @extra_helper_use_item bit, @extra_helper_use_elanat bit, @extra_helper_cache_duration int, @extra_helper_cache_parameters nvarchar(200), @extra_helper_public_access_show bit, @extra_helper_sort_index int, @extra_helper_category nvarchar(50), @extra_helper_active bit) as
begin

update el_extra_helper set
extra_helper_use_language = @extra_helper_use_language,
extra_helper_use_module = @extra_helper_use_module,
extra_helper_use_plugin = @extra_helper_use_plugin,
extra_helper_use_replace_part = @extra_helper_use_replace_part,
extra_helper_use_fetch = @extra_helper_use_fetch,
extra_helper_use_item = @extra_helper_use_item,
extra_helper_use_elanat = @extra_helper_use_elanat,
extra_helper_cache_duration = @extra_helper_cache_duration,
extra_helper_cache_parameters = @extra_helper_cache_parameters,
extra_helper_active = @extra_helper_active,
extra_helper_public_access_show = @extra_helper_public_access_show,
extra_helper_sort_index = @extra_helper_sort_index,
extra_helper_category = @extra_helper_category
where extra_helper_id = @extra_helper_id

end
GO
/****** Object:  StoredProcedure [edit_fetch]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_fetch](@fetch_id int, @fetch_category nvarchar(50), @fetch_cache_duration int, @fetch_sort_index int, @fetch_active bit, @fetch_public_access_show bit) as
begin

update el_fetch set
fetch_category = @fetch_category,
fetch_cache_duration = @fetch_cache_duration,
fetch_sort_index = @fetch_sort_index,
fetch_active = @fetch_active,
fetch_public_access_show = @fetch_public_access_show
where fetch_id = @fetch_id

end
GO
/****** Object:  StoredProcedure [edit_group]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [edit_group](@group_id int, @group_name nvarchar(50), @group_active bit) as
begin

update el_group set
group_name = @group_name,
group_active = @group_active
where group_id = @group_id

end
GO
/****** Object:  StoredProcedure [edit_item]    Script Date: 2023-09-01 6:01:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_item](@item_id int, @item_name nvarchar(50), @item_value nvarchar(MAX), @item_cache_duration int, @item_sort_index int, @item_public_access_show bit, @item_use_box bit, @item_use_language bit, @item_use_module bit, @item_use_plugin bit, @item_use_replace_part bit, @item_use_fetch bit,@item_use_item bit,@item_use_elanat bit, @item_active bit) as
begin

update el_item set
item_name = @item_name,
item_value = @item_value,
item_cache_duration = @item_cache_duration,
item_sort_index = @item_sort_index,
item_public_access_show = @item_public_access_show,
item_use_box = @item_use_box,
item_use_language = @item_use_language,
item_use_module = @item_use_module,
item_use_plugin = @item_use_plugin,
item_use_replace_part = @item_use_replace_part,
item_use_fetch = @item_use_fetch,
item_use_item = @item_use_item,
item_use_elanat = @item_use_elanat,
item_active = @item_active
where item_id = @item_id

end
GO
/****** Object:  StoredProcedure [edit_language]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_language](@language_id int, @language_show_link_in_site bit, @language_active bit, @site_id int) as
begin

update el_language set
language_show_link_in_site = @language_show_link_in_site,
language_active = @language_active,
site_id = @site_id
where language_id = @language_id

end
GO
/****** Object:  StoredProcedure [edit_link]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_link](@link_id int, @link_href nvarchar(400),@link_protocol varchar(50),@link_sort_index int,@link_target varchar(7),@link_title nvarchar(400),@link_rel nvarchar(50),@link_value nvarchar(400), @link_active bit) as
begin

update el_link set
link_href = @link_href,
link_protocol = @link_protocol,
link_sort_index = @link_sort_index,
link_target = @link_target,
link_title = @link_title,
link_rel = @link_rel,
link_value = @link_value,
link_active = @link_active
where link_id = @link_id

end
GO
/****** Object:  StoredProcedure [edit_menu]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_menu](@menu_id int, @site_id int,@menu_name nvarchar(50),@menu_location varchar(30),@menu_sort_index int,@menu_use_box bit,@menu_public_access_show bit,@menu_active bit) as
begin

update el_menu set
site_id = @site_id,
menu_name = @menu_name,
menu_location = @menu_location,
menu_sort_index = @menu_sort_index,
menu_use_box = @menu_use_box,
menu_public_access_show = @menu_public_access_show,
menu_active = @menu_active
where menu_id = @menu_id

end
GO
/****** Object:  StoredProcedure [edit_module]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_module](@module_id int, @module_load_type varchar(10), @module_use_language bit, @module_use_module bit, @module_use_plugin bit, @module_use_replace_part bit, @module_use_fetch bit, @module_use_item bit, @module_use_elanat bit, @module_cache_duration int, @module_cache_parameters nvarchar(200), @module_public_access_add bit, @module_public_access_edit_own bit, @module_public_access_delete_own bit, @module_public_access_edit_all bit, @module_public_access_delete_all bit, @module_public_access_show bit, @module_sort_index int, @module_category nvarchar(50), @module_active bit) as
begin

update el_module set
module_active = @module_active,
module_load_type = @module_load_type,
module_use_language = @module_use_language,
module_use_module = @module_use_module,
module_use_plugin = @module_use_plugin,
module_use_replace_part = @module_use_replace_part,
module_use_fetch = @module_use_fetch,
module_use_item = @module_use_item,
module_use_elanat = @module_use_elanat,
module_cache_duration = @module_cache_duration,
module_cache_parameters = @module_cache_parameters,
module_public_access_add = @module_public_access_add,
module_public_access_edit_own = @module_public_access_edit_own,
module_public_access_delete_own = @module_public_access_delete_own,
module_public_access_edit_all = @module_public_access_edit_all,
module_public_access_delete_all = @module_public_access_delete_all,
module_public_access_show = @module_public_access_show,
module_sort_index = @module_sort_index,
module_category = @module_category
where module_id = @module_id

end
GO
/****** Object:  StoredProcedure [edit_page]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_page](@page_id int, @page_global_name nvarchar(50), @page_name nvarchar(50), @user_id int, @page_public_site bit, @page_title nvarchar(400), @page_date_create char(10), @page_time_create char(8), @page_active bit, @page_directory_path nvarchar(800), @page_physical_name nvarchar(255), @page_use_language bit, @page_use_module bit, @page_use_plugin bit, @page_use_replace_part bit, @page_use_fetch bit, @page_use_item bit, @page_use_elanat bit, @page_use_load_tag bit, @page_use_static_head bit, @page_show_link_in_site bit, @page_load_type varchar(10), @page_load_tag nvarchar(MAX), @page_static_head nvarchar(MAX), @site_style_id int, @site_template_id int, @page_load_alone bit, @page_cache_duration int, @page_cache_parameters nvarchar(200), @page_use_classification_meta bit, @page_use_copyright_meta bit, @page_use_language_meta bit, @page_use_robots_meta bit, @page_use_application_name_meta bit, @page_use_generator_meta bit, @page_use_javascript_inactive_refresh_meta bit, @page_use_description_meta bit, @page_use_revisit_after_meta bit, @page_use_rights_meta bit, @page_use_keywords_meta bit, @page_use_author_meta bit, @page_description_meta nvarchar(400), @page_revisit_after_meta varchar(50), @page_rights_meta nvarchar(400), @page_keywords_meta nvarchar(400), @page_robots_meta varchar(20), @page_copyright_meta nvarchar(400), @page_classification_meta nvarchar(400), @page_visit int, @page_use_html bit, @page_public_access_show bit, @page_query_string nvarchar(400), @page_category nvarchar(50)) as
begin

update el_page set
page_global_name = @page_global_name,
page_name = @page_name,
user_id = coalesce(nullif(user_id,''), @user_id),
page_public_site = @page_public_site,
page_title = @page_title,
page_date_create = coalesce(nullif(page_date_create,''), @page_date_create),
page_time_create = coalesce(nullif(page_time_create,''), @page_time_create),
page_active = @page_active,
page_directory_path = coalesce(nullif(page_directory_path,''), @page_directory_path),
page_physical_name = coalesce(nullif(page_physical_name,''), @page_physical_name),
page_use_language = @page_use_language,
page_use_module = @page_use_module,
page_use_plugin = @page_use_plugin,
page_use_replace_part = @page_use_replace_part,
page_use_fetch = @page_use_fetch,
page_use_item = @page_use_item,
page_use_elanat = @page_use_elanat,
page_use_load_tag = @page_use_load_tag,
page_use_static_head = @page_use_static_head,
page_show_link_in_site = @page_show_link_in_site,
page_load_type = @page_load_type,
page_load_tag = @page_load_tag,
page_static_head = @page_static_head,
site_style_id = @site_style_id,
site_template_id = @site_template_id,
page_load_alone = @page_load_alone,
page_cache_duration = @page_cache_duration,
page_cache_parameters = @page_cache_parameters,
page_use_classification_meta = @page_use_classification_meta,
page_use_copyright_meta = @page_use_copyright_meta,
page_use_language_meta = @page_use_language_meta,
page_use_robots_meta = @page_use_robots_meta,
page_use_application_name_meta = @page_use_application_name_meta,
page_use_generator_meta = @page_use_generator_meta,
page_use_javascript_inactive_refresh_meta = @page_use_javascript_inactive_refresh_meta,
page_use_description_meta = @page_use_description_meta,
page_use_revisit_after_meta = @page_use_revisit_after_meta,
page_use_rights_meta = @page_use_rights_meta,
page_use_keywords_meta = @page_use_keywords_meta,
page_use_author_meta = @page_use_author_meta,
page_description_meta = @page_description_meta,
page_revisit_after_meta = @page_revisit_after_meta,
page_rights_meta = @page_rights_meta,
page_keywords_meta = @page_keywords_meta,
page_robots_meta = @page_robots_meta,
page_copyright_meta = @page_copyright_meta,
page_classification_meta = @page_classification_meta,
page_visit = coalesce(nullif(page_visit,''), @page_visit),
page_use_html = @page_use_html,
page_public_access_show = @page_public_access_show,
page_query_string = @page_query_string,
page_category = @page_category
where page_id = @page_id

end
GO
/****** Object:  StoredProcedure [edit_plugin]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_plugin](@plugin_id int, @plugin_load_type varchar(10), @plugin_use_language bit, @plugin_use_module bit, @plugin_use_plugin bit, @plugin_use_replace_part bit, @plugin_use_fetch bit, @plugin_use_item bit, @plugin_use_elanat bit, @plugin_cache_duration int, @plugin_cache_parameters nvarchar(200), @plugin_public_access_add bit, @plugin_public_access_edit_own bit, @plugin_public_access_delete_own bit, @plugin_public_access_edit_all bit, @plugin_public_access_delete_all bit, @plugin_public_access_show bit, @plugin_sort_index int, @plugin_category nvarchar(50), @plugin_active bit) as
begin

update el_plugin set
plugin_active = @plugin_active,
plugin_load_type = @plugin_load_type,
plugin_use_language = @plugin_use_language,
plugin_use_module = @plugin_use_module,
plugin_use_plugin = @plugin_use_plugin,
plugin_use_replace_part = @plugin_use_replace_part,
plugin_use_fetch = @plugin_use_fetch,
plugin_use_item = @plugin_use_item,
plugin_use_elanat = @plugin_use_elanat,
plugin_cache_duration = @plugin_cache_duration,
plugin_cache_parameters = @plugin_cache_parameters,
plugin_public_access_add = @plugin_public_access_add,
plugin_public_access_edit_own = @plugin_public_access_edit_own,
plugin_public_access_delete_own = @plugin_public_access_delete_own,
plugin_public_access_edit_all = @plugin_public_access_edit_all,
plugin_public_access_delete_all = @plugin_public_access_delete_all,
plugin_public_access_show = @plugin_public_access_show,
plugin_sort_index = @plugin_sort_index,
plugin_category = @plugin_category
where plugin_id = @plugin_id

end
GO
/****** Object:  StoredProcedure [edit_role]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_role](@role_id int, @parameters_name_value nvarchar(max)) as
begin 

exec ('update el_role set ' + @parameters_name_value +' where role_id = ' + @role_id)

end
GO
/****** Object:  StoredProcedure [edit_site]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_site](@site_id int, @site_global_name nvarchar(50), @site_name nvarchar(50), @site_slogan_name nvarchar(50), @language_id int, @page_id int, @site_title nvarchar(400), @site_date_create char(10), @site_time_create char(8), @site_active bit, @site_show_link_in_site bit, @site_style_id int, @site_template_id int, @admin_style_id int, @admin_template_id int, @site_static_head nvarchar(MAX), @site_calendar varchar(50), @site_first_day_of_week int, @site_date_format nvarchar(50), @site_time_format nvarchar(50), @site_time_zone float, @site_site_activities nvarchar(MAX), @site_address nvarchar(MAX), @site_phone_number varchar(50), @site_email nvarchar(254), @site_other_info nvarchar(MAX), @site_use_description_meta bit, @site_use_revisit_after_meta bit, @site_use_rights_meta bit, @site_use_keywords_meta bit, @site_use_classification_meta bit, @site_description_meta nvarchar(400), @site_revisit_after_meta varchar(50), @site_rights_meta nvarchar(400), @site_keywords_meta nvarchar(400), @site_classification_meta nvarchar(400), @site_visit int, @site_public_access_show bit) as
begin

update el_site set

language_id = @language_id,
site_title = @site_title,
site_name = @site_name,
site_global_name = @site_global_name,
site_visit = @site_visit,
page_id = @page_id,
site_slogan_name = @site_slogan_name,
site_date_create = @site_date_create,
site_time_create = @site_time_create,
site_site_activities = @site_site_activities,
site_address = @site_address,
site_phone_number = @site_phone_number,
site_email = @site_email,
site_other_info = @site_other_info,
site_style_id = @site_style_id,
site_template_id = @site_template_id,
admin_style_id = @admin_style_id,
admin_template_id = @admin_template_id,
site_active = @site_active,
site_static_head = @site_static_head,
site_use_description_meta = @site_use_description_meta,
site_use_revisit_after_meta = @site_use_revisit_after_meta,
site_use_rights_meta = @site_use_rights_meta,
site_use_keywords_meta = @site_use_keywords_meta,
site_use_classification_meta = @site_use_classification_meta,
site_description_meta = @site_description_meta,
site_revisit_after_meta = @site_revisit_after_meta,
site_rights_meta = @site_rights_meta,
site_classification_meta = @site_classification_meta,
site_keywords_meta = @site_keywords_meta,
site_show_link_in_site = @site_show_link_in_site,
site_calendar = @site_calendar,
site_first_day_of_week = @site_first_day_of_week,
site_time_zone = @site_time_zone,
site_date_format = @site_date_format,
site_time_format = @site_time_format,
site_public_access_show = @site_public_access_show

where site_id = @site_id

end
GO
/****** Object:  StoredProcedure [edit_site_style]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_site_style](@site_style_id int, @site_style_name nvarchar(50), @site_style_directory_path nvarchar(800), @site_style_physical_name nvarchar(255), @site_style_template nvarchar(50), @site_style_load_tag nvarchar(MAX), @site_style_static_head nvarchar(MAX), @site_style_active bit) as
begin

update el_site_style set
site_style_name = @site_style_name,
site_style_directory_path = @site_style_directory_path,
site_style_physical_name = @site_style_physical_name,
site_style_template = @site_style_template,
site_style_load_tag = @site_style_load_tag,
site_style_static_head = @site_style_static_head,
site_style_active = @site_style_active
where site_style_id = @site_style_id

end
GO
/****** Object:  StoredProcedure [edit_site_template]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_site_template](@site_template_id int, @site_template_name nvarchar(50), @site_template_directory_path nvarchar(800), @site_template_physical_name nvarchar(255), @site_template_load_tag nvarchar(MAX), @site_template_static_head nvarchar(MAX), @site_template_active bit) as
begin

update el_site_template set
site_template_name = @site_template_name,
site_template_directory_path = @site_template_directory_path,
site_template_physical_name = @site_template_physical_name,
site_template_load_tag = @site_template_load_tag,
site_template_static_head = @site_template_static_head,
site_template_active = @site_template_active
where site_template_id = @site_template_id

end
GO
/****** Object:  StoredProcedure [edit_user]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_user](@user_id int, @user_name nvarchar(50), @group_id int, @user_site_name nvarchar(50), @user_real_name nvarchar(50), @user_real_last_name nvarchar(50), @user_password char(32) = null, @user_date_create char(10), @user_active bit, @user_email nvarchar(254), @user_phone_number varchar(50), @user_address nvarchar(200), @user_postal_code varchar(50), @user_about varchar(200), @user_birthday char(10), @user_gender bit, @user_public_email nvarchar(254), @user_mobile_number varchar(50), @user_zip_code varchar(10), @user_email_is_confirm bit, @user_other_info nvarchar(MAX), @user_country nvarchar(50), @user_state_or_province nvarchar(50), @user_city nvarchar(50), @user_website nvarchar(255)) as
begin

declare @tmp_user_password char(32)

set @tmp_user_password = ISNULL(@user_password, (select el_user.user_password from el_user where el_user.user_id = @user_id)) 

update el_user set
el_user.user_name = @user_name,
group_id = @group_id,
user_site_name = @user_site_name,
user_real_name = @user_real_name,
user_real_last_name = @user_real_last_name,
user_password = @tmp_user_password,
user_date_create = @user_date_create,
user_active = @user_active,
user_email = @user_email,
user_phone_number = @user_phone_number,
user_address = @user_address,
user_postal_code = @user_postal_code,
user_about = @user_about,
user_birthday = @user_birthday,
user_gender = @user_gender,
user_public_email = @user_public_email,
user_mobile_number = @user_mobile_number,
user_zip_code = @user_zip_code,
user_email_is_confirm = @user_email_is_confirm,
user_other_info = @user_other_info,
user_country = @user_country,
user_state_or_province = @user_state_or_province,
user_city = @user_city,
user_website = @user_website
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [edit_user_profile]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_user_profile](@user_id int, @user_real_name nvarchar(50), @user_real_last_name nvarchar(50), @user_phone_number varchar(50), @user_address nvarchar(200), @user_postal_code varchar(50), @user_about varchar(200), @user_birthday char(10), @user_gender bit, @user_public_email nvarchar(254), @user_mobile_number varchar(50), @user_zip_code varchar(10), @user_other_info nvarchar(MAX), @user_country nvarchar(50), @user_state_or_province nvarchar(50), @user_city nvarchar(50), @user_website nvarchar(255)) as
begin

update el_user set
user_real_name = @user_real_name,
user_real_last_name = @user_real_last_name,
user_phone_number = @user_phone_number,
user_address = @user_address,
user_postal_code = @user_postal_code,
user_about = @user_about,
user_birthday = @user_birthday,
user_gender = @user_gender,
user_public_email = @user_public_email,
user_mobile_number = @user_mobile_number,
user_zip_code = @user_zip_code,
user_other_info = @user_other_info,
user_country = @user_country,
user_state_or_province = @user_state_or_province,
user_city = @user_city,
user_website = @user_website
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [edit_view]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [edit_view](@view_id int, @view_name nvarchar(50), @view_include_header_bar_part bit, @view_show_header_bar_left bit, @view_show_header_bar_right bit, @view_show_header_bar_box bit, @view_fill_header_bar_left bit, @view_fill_header_bar_right bit, @view_fill_header_bar_box bit, @view_include_header_part bit, @view_show_header_menu bit, @view_show_header1 bit, @view_show_header2 bit, @view_fill_header_menu bit, @view_fill_header1 bit, @view_fill_header2 bit, @view_include_menu_part bit, @view_show_menu bit, @view_fill_menu bit, @view_include_main_part bit, @view_show_after_header bit, @view_show_before_content bit, @view_show_after_content bit, @view_show_right_menu bit, @view_show_left_menu bit, @view_show_before_footer bit, @view_fill_after_header bit, @view_fill_before_content bit, @view_fill_after_content bit, @view_fill_right_menu bit, @view_fill_left_menu bit, @view_fill_before_footer bit, @view_include_footer_part bit, @view_show_footer_menu bit, @view_show_footer1 bit, @view_show_footer2 bit, @view_fill_footer_menu bit, @view_fill_footer1 bit, @view_fill_footer2 bit, @view_include_footer_bar_part bit, @view_show_footer_bar_left bit, @view_show_footer_bar_right bit, @view_show_footer_bar_box bit, @view_fill_footer_bar_left bit, @view_fill_footer_bar_right bit, @view_fill_footer_bar_box bit, @view_common_light_background_color char(7), @view_common_light_text_color char(7), @view_common_middle_background_color char(7), @view_common_middle_text_color char(7), @view_common_dark_background_color char(7), @view_common_dark_text_color char(7), @view_natural_light_background_color char(7), @view_natural_light_text_color char(7), @view_natural_middle_background_color char(7), @view_natural_middle_text_color char(7), @view_natural_dark_background_color char(7), @view_natural_dark_text_color char(7), @view_background_color char(7), @view_font_size int, @view_static_head nvarchar(MAX), @site_style_id int, @site_template_id int, @view_match_type varchar(10), @view_active bit) as
begin

update el_view set
view_name = @view_name,
view_include_header_bar_part = @view_include_header_bar_part,
view_show_header_bar_left = @view_show_header_bar_left,
view_show_header_bar_right = @view_show_header_bar_right,
view_show_header_bar_box = @view_show_header_bar_box,
view_fill_header_bar_left = @view_fill_header_bar_left,
view_fill_header_bar_right = @view_fill_header_bar_right,
view_fill_header_bar_box = @view_fill_header_bar_box,
view_include_header_part = @view_include_header_part,
view_show_header_menu = @view_show_header_menu,
view_show_header1 = @view_show_header1,
view_show_header2 = @view_show_header2,
view_fill_header_menu = @view_fill_header_menu,
view_fill_header1 = @view_fill_header1,
view_fill_header2 = @view_fill_header2,
view_include_menu_part = @view_include_menu_part,
view_show_menu = @view_show_menu,
view_fill_menu = @view_fill_menu,
view_include_main_part = @view_include_main_part,
view_show_after_header = @view_show_after_header,
view_show_before_content = @view_show_before_content,
view_show_after_content = @view_show_after_content,
view_show_right_menu = @view_show_right_menu,
view_show_left_menu = @view_show_left_menu,
view_show_before_footer = @view_show_before_footer,
view_fill_after_header = @view_fill_after_header,
view_fill_before_content = @view_fill_before_content,
view_fill_after_content = @view_fill_after_content,
view_fill_right_menu = @view_fill_right_menu,
view_fill_left_menu = @view_fill_left_menu,
view_fill_before_footer = @view_fill_before_footer,
view_include_footer_part = @view_include_footer_part,
view_show_footer_menu = @view_show_footer_menu,
view_show_footer1 = @view_show_footer1,
view_show_footer2 = @view_show_footer2,
view_fill_footer_menu = @view_fill_footer_menu,
view_fill_footer1 = @view_fill_footer1,
view_fill_footer2 = @view_fill_footer2,
view_include_footer_bar_part = @view_include_footer_bar_part,
view_show_footer_bar_left = @view_show_footer_bar_left,
view_show_footer_bar_right = @view_show_footer_bar_right,
view_show_footer_bar_box = @view_show_footer_bar_box,
view_fill_footer_bar_left = @view_fill_footer_bar_left,
view_fill_footer_bar_right = @view_fill_footer_bar_right,
view_fill_footer_bar_box = @view_fill_footer_bar_box,
view_common_light_background_color = @view_common_light_background_color,
view_common_light_text_color = @view_common_light_text_color,
view_common_middle_background_color = @view_common_middle_background_color,
view_common_middle_text_color = @view_common_middle_text_color,
view_common_dark_background_color = @view_common_dark_background_color,
view_common_dark_text_color = @view_common_dark_text_color,
view_natural_light_background_color = @view_natural_light_background_color,
view_natural_light_text_color = @view_natural_light_text_color,
view_natural_middle_background_color = @view_natural_middle_background_color,
view_natural_middle_text_color = @view_natural_middle_text_color,
view_natural_dark_background_color = @view_natural_dark_background_color,
view_natural_dark_text_color = @view_natural_dark_text_color,
view_background_color = @view_background_color,
view_font_size = @view_font_size,
view_static_head = @view_static_head,
site_style_id = @site_style_id,
site_template_id = @site_template_id,
view_match_type = @view_match_type,
view_active = @view_active
where view_id = @view_id

end
GO
/****** Object:  StoredProcedure [editor_template_access_show_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [editor_template_access_show_check](@editor_template_id int, @role_id int) as
begin

if ((select el_editor_template.editor_template_public_access_show from el_editor_template
	where el_editor_template.editor_template_id = @editor_template_id) = 1)
	begin
		select 1 as editor_template_access_show
	end
else if exists(select * from el_editor_template_access_show
	left join el_role on el_role.role_id = el_editor_template_access_show.role_id
	where el_editor_template_access_show.editor_template_id = @editor_template_id
	and el_editor_template_access_show.role_id = @role_id
	and el_role.role_active = 1)
	begin
		select 1 as editor_template_access_show
	end
else
	begin
		select 0 as editor_template_access_show
	end

end
GO
/****** Object:  StoredProcedure [editor_template_access_show_check_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [editor_template_access_show_check_by_group_id](@editor_template_id int, @group_id int) as
begin

if ((select el_editor_template.editor_template_public_access_show from el_editor_template
	where el_editor_template.editor_template_id = @editor_template_id) = 1)
	begin
		select 1 as editor_template_access_show
	end
else if exists(select * from el_editor_template_access_show
	left join el_role on el_role.role_id = el_editor_template_access_show.role_id
	join el_group_role on el_group_role.role_id = el_editor_template_access_show.role_id
	where el_editor_template_access_show.editor_template_id = @editor_template_id
	and el_group_role.group_id = @group_id
	and el_role.role_active = 1)
	begin
		select 1 as editor_template_access_show
	end
else
	begin
		select 0 as editor_template_access_show
	end

end
GO
/****** Object:  StoredProcedure [exist_user_name_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [exist_user_name_check](@user_name nvarchar(50)) as
begin

select el_user.user_id from el_user
where el_user.user_name = @user_name

end
GO
/****** Object:  StoredProcedure [exist_value_to_column_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [exist_value_to_column_check](@table_name nvarchar(200), @column_name nvarchar(200), @column_value nvarchar(max), @breack_value nvarchar(200)) as
begin

exec('select COUNT(*) as row_count from ' + @table_name + ' where ' + @column_name + ' = ''' + @column_value + '''' + ' and ' + @column_name + ' <> ''' + @breack_value + '''')

end
GO
/****** Object:  StoredProcedure [extra_helper_access_show_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [extra_helper_access_show_check](@extra_helper_id int, @role_id int) as
begin

if ((select el_extra_helper.extra_helper_public_access_show from el_extra_helper
	where el_extra_helper.extra_helper_id = @extra_helper_id) = 1)
	begin
		select 1 as extra_helper_access_show
	end
else if exists(select * from el_extra_helper_access_show
	left join el_role on el_role.role_id = el_extra_helper_access_show.role_id
	where el_extra_helper_access_show.extra_helper_id = @extra_helper_id
	and el_extra_helper_access_show.role_id = @role_id
	and el_role.role_active = 1)
	begin
		select 1 as extra_helper_access_show
	end
else
	begin
		select 0 as extra_helper_access_show
	end

end
GO
/****** Object:  StoredProcedure [extra_helper_access_show_check_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [extra_helper_access_show_check_by_group_id](@extra_helper_id int, @group_id int) as
begin

if ((select el_extra_helper.extra_helper_public_access_show from el_extra_helper
	where el_extra_helper.extra_helper_id = @extra_helper_id) = 1)
	begin
		select 1 as extra_helper_access_show
	end
else if exists(select * from el_extra_helper_access_show
	left join el_role on el_role.role_id = el_extra_helper_access_show.role_id
	join el_group_role on el_group_role.role_id = el_extra_helper_access_show.role_id
	where el_extra_helper_access_show.extra_helper_id = @extra_helper_id
	and el_group_role.group_id = @group_id
	and el_role.role_active = 1)
	begin
		select 1 as extra_helper_access_show
	end
else
	begin
		select 0 as extra_helper_access_show
	end

end
GO
/****** Object:  StoredProcedure [fetch_access_show_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [fetch_access_show_check](@fetch_id int, @role_id int) as
begin

if ((select el_fetch.fetch_public_access_show from el_fetch
	where el_fetch.fetch_id = @fetch_id) = 1)
	begin
		select 1 as fetch_access_show
	end
else if exists(select * from el_fetch_access_show
	left join el_role on el_role.role_id = el_fetch_access_show.role_id
	where el_fetch_access_show.fetch_id = @fetch_id
	and el_fetch_access_show.role_id = @role_id
	and el_role.role_active = 1)
	begin
		select 1 as fetch_access_show
	end
else
	begin
		select 0 as fetch_access_show
	end

end
GO
/****** Object:  StoredProcedure [fetch_access_show_check_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [fetch_access_show_check_by_group_id](@fetch_id int, @group_id int) as
begin

if ((select el_fetch.fetch_public_access_show from el_fetch
	where el_fetch.fetch_id = @fetch_id) = 1)
	begin
		select 1 as fetch_access_show
	end
else if exists(select * from el_fetch_access_show
	left join el_role on el_role.role_id = el_fetch_access_show.role_id
	join el_group_role on el_group_role.role_id = el_fetch_access_show.role_id
	where el_fetch_access_show.fetch_id = @fetch_id
	and el_group_role.group_id = @group_id
	and el_role.role_active = 1)
	begin
		select 1 as fetch_access_show
	end
else
	begin
		select 0 as fetch_access_show
	end

end
GO
/****** Object:  StoredProcedure [fill_content_count_with_always_on_top_content_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [fill_content_count_with_always_on_top_content_count] as
begin

declare @content_count int = (select COUNT(el_content.content_id) as content_count from el_content)
declare @always_on_top_content_count int = (select COUNT(el_content.content_id) as content_count from el_content where el_content.content_always_on_top = 1)
select @content_count as content_count, @always_on_top_content_count as always_on_top_content_count

end
GO
/****** Object:  StoredProcedure [get_active_admin_template_physical_path_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_active_admin_template_physical_path_list] as
begin

select (el_admin_template.admin_template_directory_path + '/' + el_admin_template.admin_template_physical_name) admin_template_physical_path from el_admin_template
where admin_template_active = 1

end
GO
/****** Object:  StoredProcedure [get_active_content_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_active_content_count] as
begin

select COUNT(el_content.content_id) as active_content_count from el_content
where el_content.content_status = 'active'

end
GO
/****** Object:  StoredProcedure [get_active_editor_template_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_active_editor_template_list] as
begin

select el_editor_template.* from el_editor_template
where el_editor_template.editor_template_active = 1
order by el_editor_template.editor_template_category

end
GO
/****** Object:  StoredProcedure [get_active_extra_helper_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_active_extra_helper_list] as
begin

select el_extra_helper.* from el_extra_helper
where el_extra_helper.extra_helper_active = 1
order by extra_helper_category asc, extra_helper_sort_index asc, extra_helper_name asc

end
GO
/****** Object:  StoredProcedure [get_active_language_global_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_active_language_global_name] as
begin

select el_language.language_global_name from el_language
where el_language.language_active = 1

end
GO
/****** Object:  StoredProcedure [get_active_language_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_active_language_list] as
begin

select el_language.language_id,el_language.language_global_name,el_language.language_name  from  el_language
where el_language.language_active = 1

end
GO
/****** Object:  StoredProcedure [get_active_language_name_and_global_name_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [get_active_language_name_and_global_name_list] as
begin

select el_language.language_name,el_language.language_global_name from el_language
where el_language.language_active = 1

end
GO
/****** Object:  StoredProcedure [get_active_role_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_active_role_list] as
begin

select el_role.role_id,el_role.role_name from el_role
where el_role.role_active = 1

end
GO
/****** Object:  StoredProcedure [get_active_site_template_physical_path_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_active_site_template_physical_path_list] as
begin

select (el_site_template.site_template_directory_path + '/' + el_site_template.site_template_physical_name) site_template_physical_path from el_site_template
where site_template_active = 1

end
GO
/****** Object:  StoredProcedure [get_admin_note_content_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_admin_note_content_count] as
begin

select COUNT(el_content.content_id) as admin_note_content_count from el_content
where el_content.content_status = 'admin_note'

end
GO
/****** Object:  StoredProcedure [get_admin_style]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_admin_style](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin 

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_admin_style.*,(el_admin_style.admin_style_directory_path + ' + '''/''' + ' + el_admin_style.admin_style_physical_name) as admin_style_physical_path from el_admin_style
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_admin_style_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_admin_style_count] as
begin

select COUNT(el_admin_style.admin_style_id) as admin_style_count from el_admin_style

end
GO
/****** Object:  StoredProcedure [get_admin_style_directory_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_admin_style_directory_path](@admin_style_id int) as
begin

select admin_style_directory_path from el_admin_style
where admin_style_id = @admin_style_id

end
GO
/****** Object:  StoredProcedure [get_admin_style_id_by_admin_style_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_admin_style_id_by_admin_style_name](@admin_style_name nvarchar(50)) as
begin

select el_admin_style.admin_style_id from el_admin_style
where el_admin_style.admin_style_name = @admin_style_name

end
GO
/****** Object:  StoredProcedure [get_admin_style_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_admin_style_list] as
begin

select el_admin_style.* from el_admin_style

end
GO
/****** Object:  StoredProcedure [get_admin_style_physical_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_admin_style_physical_path](@admin_style_id int) as
begin

select (el_admin_style.admin_style_directory_path + '/' + el_admin_style.admin_style_physical_name) admin_style_physical_path from el_admin_style
where admin_style_id = @admin_style_id

end
GO
/****** Object:  StoredProcedure [get_admin_template]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_admin_template](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin 

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_admin_template.*,(el_admin_template.admin_template_directory_path + ' + '''/''' + ' + el_admin_template.admin_template_physical_name) as admin_template_physical_path from el_admin_template
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_admin_template_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_admin_template_count] as
begin
select COUNT(el_admin_template.admin_template_id) as admin_template_count from el_admin_template
end
GO
/****** Object:  StoredProcedure [get_admin_template_id_by_admin_template_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_admin_template_id_by_admin_template_name](@admin_template_name nvarchar(50)) as
begin

select el_admin_template.admin_template_id from el_admin_template
where el_admin_template.admin_template_name = @admin_template_name

end
GO
/****** Object:  StoredProcedure [get_admin_template_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_admin_template_list] as
begin

select el_admin_template.* from el_admin_template

end
GO
/****** Object:  StoredProcedure [get_admin_template_physical_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_admin_template_physical_path](@admin_template_id int) as
begin

select (el_admin_template.admin_template_directory_path + '/' + el_admin_template.admin_template_physical_name) admin_template_physical_path from el_admin_template
where admin_template_id = @admin_template_id

end
GO
/****** Object:  StoredProcedure [get_all_page_list_by_site_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_all_page_list_by_site_id](@site_id int) as
begin

select el_page.page_id,el_page.page_global_name,el_page.page_name,el_page.page_show_link_in_site  from  el_page
where el_page.page_active = 1
and (el_page.page_public_site = @site_id or el_page.page_public_site = 0)

end
GO
/****** Object:  StoredProcedure [get_attachment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_attachment](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
BEGIN 

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_attachment.*,(el_attachment.attachment_directory_path + ' + '''/''' + ' + el_attachment.attachment_physical_name) as attachment_physical_path from el_attachment
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_attachment_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_attachment_access_show](@attachment_id int) as
begin

select el_attachment_access_show.* from el_attachment_access_show
where el_attachment_access_show.attachment_id = @attachment_id

end
GO
/****** Object:  StoredProcedure [get_attachment_content]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_attachment_content](@attachment_id int) as
begin

select el_content_attachment.* from el_content_attachment 
where el_content_attachment.attachment_id = @attachment_id

end
GO
/****** Object:  StoredProcedure [get_attachment_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_attachment_count] as
begin

select COUNT(el_attachment.attachment_id) as attachment_count from el_attachment

end
GO
/****** Object:  StoredProcedure [get_attachment_id_by_attachment_physical_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_attachment_id_by_attachment_physical_path](@attachment_directory_path nvarchar(800), @attachment_physical_name nvarchar(255)) as
begin

select el_attachment.attachment_id from el_attachment
where el_attachment.attachment_directory_path = @attachment_directory_path
and el_attachment.attachment_physical_name = @attachment_physical_name

end
GO
/****** Object:  StoredProcedure [get_category]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_category] (@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin 

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_category.*,tmp_el_category.category_name as parent_category_name,el_site.site_name,el_site.site_global_name,el_site_style.site_style_name,el_site_template.site_template_name from el_category
left join el_category tmp_el_category on el_category.parent_category = tmp_el_category.category_id
left join el_site on el_category.site_id = el_site.site_id
left join el_site_style on el_category.site_style_id = el_site_style.site_style_id
left join el_site_template on el_category.site_template_id = el_site_template.site_template_id
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_category_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_category_access_show](@category_id int) as
begin

select el_category_access_show.* from el_category_access_show
where el_category_access_show.category_id = @category_id

end
GO
/****** Object:  StoredProcedure [get_category_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_category_count] as
begin

select COUNT(el_category.category_id) as category_count from el_category

end
GO
/****** Object:  StoredProcedure [get_category_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_category_id](@category_name nvarchar(30)) as
begin

select el_category.category_id from el_category where el_category.category_name = @category_name

end
GO
/****** Object:  StoredProcedure [get_category_id_by_category_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_category_id_by_category_name](@category_name nvarchar(50)) as
begin

select el_category.category_id from el_category
where el_category.category_name = @category_name

end
GO
/****** Object:  StoredProcedure [get_category_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_category_list] as
begin

select el_category.category_id,el_category.category_name,el_category.parent_category from el_category  order by  el_category.parent_category asc

end
GO
/****** Object:  StoredProcedure [get_category_list_by_site_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_category_list_by_site_id](@site_id int) as
begin

select el_category.*,(select el_category.category_name from el_category where el_category.category_id= (select el_category.parent_category from el_category where el_category.category_id = 5)) as parent_category_name,el_site.site_name,el_site.site_global_name,el_site_style.site_style_name,el_site_template.site_template_name from el_category
left join el_site on (el_category.site_id = el_site.site_id or el_category.site_id = 0)
left join el_site_style on el_category.site_style_id = el_site_style.site_style_id
left join el_site_template on el_category.site_template_id = el_site_template.site_template_id
where el_category.site_id= @site_id
and el_category.category_active = 1
order by el_category.parent_category asc

end
GO
/****** Object:  StoredProcedure [get_category_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_category_name](@category_id int) as
begin

select el_category.category_name from el_category
where el_category.category_id = @category_id

end
GO
/****** Object:  StoredProcedure [get_comment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_comment](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
BEGIN 

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_comment.*,el_user.user_site_name,el_user.user_email,el_content.content_title,el_category.category_id,el_site.site_id,(ISNULL(el_user.user_site_name,el_comment.comment_guest_name)) as comment_user_guest_name,(select count(*) from el_comment where el_comment.parent_comment = el_comment.comment_id ) as comment_reply_count,(ISNULL(el_user.user_email,el_comment.comment_guest_email)) as comment_user_guest_email,(el_comment.comment_date_send + ' + '''-''' + ' + el_comment.comment_time_send) as comment_date_and_time_send from el_comment
left join el_user on el_comment.user_id=el_user.user_id
left join el_content on el_comment.content_id=el_content.content_id
left join el_category on el_content.category_id=el_category.category_id 
left join el_site on el_category.site_id=el_site.site_id 
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_comment_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_comment_count] as
begin

select COUNT(el_comment.comment_id) as comment_count from el_comment

end
GO
/****** Object:  StoredProcedure [get_comment_date_time_create]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_comment_date_time_create](@comment_id int) as
begin

select (el_comment.comment_date_send + ' ' + el_comment.comment_time_send) as comment_date_time_create from el_comment
where el_comment.comment_id = @comment_id

end
GO
/****** Object:  StoredProcedure [get_comment_date_time_send]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_comment_date_time_send](@comment_id int) as
begin

select (el_comment.comment_date_send + ' ' + el_comment.comment_time_send) as comment_date_time_send from el_comment
where el_comment.comment_id = @comment_id

end
GO
/****** Object:  StoredProcedure [get_component]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
BEGIN 

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_component.*,(el_component.component_directory_path + ' + '''/''' + ' + el_component.component_physical_name) as component_physical_path from el_component
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_component_access_add]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component_access_add](@component_id int) as
begin

select el_component_role_access.* from el_component_role_access
where el_component_role_access.component_id = @component_id
and el_component_role_access.component_add = 1

end
GO
/****** Object:  StoredProcedure [get_component_access_delete_all]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component_access_delete_all](@component_id int) as
begin

select el_component_role_access.* from el_component_role_access
where el_component_role_access.component_id = @component_id
and el_component_role_access.component_delete_all = 1

end
GO
/****** Object:  StoredProcedure [get_component_access_delete_own]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component_access_delete_own](@component_id int) as
begin

select el_component_role_access.* from el_component_role_access
where el_component_role_access.component_id = @component_id
and el_component_role_access.component_delete_own = 1

end
GO
/****** Object:  StoredProcedure [get_component_access_edit_all]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component_access_edit_all](@component_id int) as
begin

select el_component_role_access.* from el_component_role_access
where el_component_role_access.component_id = @component_id
and el_component_role_access.component_edit_all = 1

end
GO
/****** Object:  StoredProcedure [get_component_access_edit_own]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component_access_edit_own](@component_id int) as
begin

select el_component_role_access.* from el_component_role_access
where el_component_role_access.component_id = @component_id
and el_component_role_access.component_edit_own = 1

end
GO
/****** Object:  StoredProcedure [get_component_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component_access_show](@component_id int) as
begin

select el_component_role_access.* from el_component_role_access
where el_component_role_access.component_id = @component_id
and el_component_role_access.component_show = 1

end
GO
/****** Object:  StoredProcedure [get_component_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component_count] as
begin

select COUNT(el_component.component_id) as component_count from el_component

end
GO
/****** Object:  StoredProcedure [get_component_id_by_component_directory_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component_id_by_component_directory_path](@component_directory_path nvarchar(800)) as
begin

select el_component.component_id from el_component
where el_component.component_directory_path = @component_directory_path

end
GO
/****** Object:  StoredProcedure [get_component_id_by_component_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component_id_by_component_name](@component_name nvarchar(50)) as
begin

select el_component.component_id from el_component
where el_component.component_name = @component_name

end
GO
/****** Object:  StoredProcedure [get_component_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component_list] as
begin

select el_component.component_id,el_component.component_name from  el_component

end
GO
/****** Object:  StoredProcedure [get_component_role_access]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component_role_access](@component_id int) as
begin

select el_component_role_access.* from el_component_role_access
where el_component_role_access.component_id = @component_id

end
GO
/****** Object:  StoredProcedure [get_component_role_access_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component_role_access_check](@component_id int, @role_id int) as
begin

declare @tmp_el_component table(component_access_show int, component_access_add int, component_access_edit_own int, component_access_delete_own int, component_access_edit_all int, component_access_delete_all int)

insert into @tmp_el_component
select el_component.component_public_access_show,
el_component.component_public_access_add,
el_component.component_public_access_edit_own,
el_component.component_public_access_delete_own,
el_component.component_public_access_edit_all,
el_component.component_public_access_delete_all
from el_component
where el_component.component_id = @component_id

if exists(select * from el_component_role_access
	left join el_role on el_role.role_id = el_component_role_access.role_id
	where el_component_role_access.component_id = @component_id
	and el_component_role_access.role_id = @role_id
	and el_role.role_active = 1)
	begin
		insert into @tmp_el_component
		select el_component_role_access.component_show,
		el_component_role_access.component_add,
		el_component_role_access.component_edit_own,
		el_component_role_access.component_delete_own,
		el_component_role_access.component_edit_all,
		el_component_role_access.component_delete_all
		from el_component_role_access
		left join el_role on el_role.role_id = el_component_role_access.role_id
		where el_component_role_access.component_id = @component_id
		and el_component_role_access.role_id = @role_id
		and el_role.role_active = 1
	end

select cast(sum(component_access_show) as bit) as component_access_show,
cast(sum(component_access_add) as bit) as component_access_add,
cast(sum(component_access_edit_own) as bit) as component_access_edit_own,
cast(sum(component_access_delete_own) as bit) as component_access_delete_own,
cast(sum(component_access_edit_all) as bit) as component_access_edit_all,
cast(sum(component_access_delete_all) as bit) as component_access_delete_all
from @tmp_el_component

end
GO
/****** Object:  StoredProcedure [get_component_role_access_check_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_component_role_access_check_by_group_id](@component_id int, @group_id int) as
begin

declare @tmp_el_component table(component_access_show int, component_access_add int, component_access_edit_own int, component_access_delete_own int, component_access_edit_all int, component_access_delete_all int)

insert into @tmp_el_component
select
el_component.component_public_access_show,
el_component.component_public_access_add,
el_component.component_public_access_edit_own,
el_component.component_public_access_delete_own,
el_component.component_public_access_edit_all,
el_component.component_public_access_delete_all
from el_component
where el_component.component_id = @component_id

if exists(select * from el_component_role_access
	join el_group_role on el_group_role.role_id = el_component_role_access.role_id
	where el_component_role_access.component_id = @component_id
	and el_group_role.group_id = @group_id)
	begin
		insert into @tmp_el_component
		select
		el_component_role_access.component_show,
		el_component_role_access.component_add,
		el_component_role_access.component_edit_own,
		el_component_role_access.component_delete_own,
		el_component_role_access.component_edit_all,
		el_component_role_access.component_delete_all
		from el_component_role_access
		join el_group_role on el_group_role.role_id = el_component_role_access.role_id
		where el_component_role_access.component_id = @component_id
		and el_group_role.group_id = @group_id
	end

select
cast(sum(component_access_show) as bit) as component_access_show,
cast(sum(component_access_add) as bit) as component_access_add,
cast(sum(component_access_edit_own) as bit) as component_access_edit_own,
cast(sum(component_access_delete_own) as bit) as component_access_delete_own,
cast(sum(component_access_edit_all) as bit) as component_access_edit_all,
cast(sum(component_access_delete_all) as bit) as component_access_delete_all
from @tmp_el_component

end
GO
/****** Object:  StoredProcedure [get_contact]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_contact](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
BEGIN 

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_contact.*,el_user.user_site_name,el_user.user_email,(ISNULL(el_user.user_site_name,el_contact.contact_guest_name)) as contact_user_guest_name,(ISNULL(el_user.user_email,el_contact.contact_guest_email)) as contact_user_guest_email,(el_contact.contact_date_send + ' + '''-''' + ' + el_contact.contact_time_send) as contact_date_and_time_send from el_contact left join el_user on el_contact.user_id = el_user.user_id
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_contact_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_contact_count] as
begin

select COUNT(el_contact.contact_id) as contact_count from el_contact

end
GO
/****** Object:  StoredProcedure [get_contact_response_text]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_contact_response_text](@contact_id int, @contact_response_code char(32)) as
begin

select contact_response_text from el_contact
where contact_id = @contact_id
and contact_response_code = @contact_response_code

end
GO
/****** Object:  StoredProcedure [get_content]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
BEGIN 

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end


declare @between nvarchar(max) = 'where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_content.*,(select count(*) from el_comment where el_comment.content_id = el_content.content_id and el_comment.comment_active = 1) as comment_count,(select count(*) from el_content_reply where el_content_reply.content_id = el_content.content_id and el_content_reply.content_reply_active = 1) as content_reply_count,el_category.category_name,el_user.user_site_name,el_user.user_name,el_user.user_real_name,el_content_rating.content_rating_number_of_voted,el_content_rating.content_rating_rating,el_content_icon.content_icon_physical_name,el_content_avatar.content_avatar_physical_name,el_site.site_name,el_site.site_id,el_site.site_global_name
from el_content 
left join el_category on el_content.category_id = el_category.category_id
left join el_user on el_content.user_id = el_user.user_id 
left join el_content_rating on el_content.content_id = el_content_rating.content_id 
left join el_content_icon on el_content.content_id = el_content_icon.content_id 
left join el_content_avatar on el_content.content_id = el_content_avatar.content_id 
left join el_site on el_category.site_id = el_site.site_id 
  '+ @inner_attach + ') tmp ' + @between + @outer_attach)
  
select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_content_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_access_show](@content_id int) as
begin

select el_content_access_show.* from el_content_access_show
where el_content_access_show.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_content_attachment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_attachment](@content_id int) as
begin

select el_attachment.*,(el_attachment.attachment_directory_path + '/' + el_attachment.attachment_physical_name) as attachment_physical_path from el_attachment 
left join el_content_attachment on el_attachment.attachment_id = el_content_attachment.attachment_id
where el_content_attachment.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_content_comment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_comment](@content_id int,@count int = 10) as
begin

declare @guest_id int
set @guest_id = 0

select top(@count) el_comment.*
,(ISNULL(el_user.user_id,@guest_id)) as user_guest_id
,(ISNULL(el_user.user_site_name,el_comment.comment_guest_name)) as comment_user_guest_name
,(el_comment.comment_date_send + '-' + el_comment.comment_time_send) as comment_date_and_time_send
,el_user.user_site_name,el_user.user_email as user_email,el_content.content_title from el_comment
left join el_user on el_comment.user_id=el_user.user_id
left join el_content on el_comment.content_id=el_content.content_id
where el_comment.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_content_comment_by_parent_comment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_comment_by_parent_comment](@content_id int, @parent_id int, @count int) as
begin

declare @guest_id int
set @guest_id = 0

select top(@count) el_comment.*
,(ISNULL(el_user.user_id,@guest_id)) as user_guest_id
,(ISNULL(el_user.user_site_name,el_comment.comment_guest_name)) as comment_user_guest_name
,(el_comment.comment_date_send + '-' + el_comment.comment_time_send) as comment_date_and_time_send
,el_user.user_site_name,el_user.user_email as user_email,el_content.content_title from el_comment
left join el_user on el_comment.user_id=el_user.user_id
left join el_content on el_comment.content_id=el_content.content_id
where el_comment.content_id = @content_id
and el_comment.parent_comment = @parent_id
order by el_comment.comment_date_send desc, el_comment.comment_time_send desc,el_comment.parent_comment

end
GO
/****** Object:  StoredProcedure [get_content_comment_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_comment_count](@content_id int) as
begin

select COUNT(el_comment.comment_id) as content_comment_count from el_comment
where el_comment.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_content_content_reply]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_content_reply](@content_id int) as
begin

select el_content_reply.* from el_content_reply where el_content_reply.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_content_content_reply_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_content_reply_count](@content_id int) as
begin

select COUNT(el_content_reply.content_id) as content_content_reply_count from el_content_reply
where el_content_reply.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_content_content_text]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_content_text](@content_id int) as
begin

select el_content.content_id, el_content.content_text, el_content.content_password from el_content
where el_content.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_content_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_count] as
begin

select COUNT(el_content.content_id) as content_count from el_content

end
GO
/****** Object:  StoredProcedure [get_content_date_range]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_date_range](@date1 char(10),@date2 char(10),@date3 char(10)) as
begin

select count(*) as date_range_count from el_content
where el_content.content_date_create = @date1 or el_content.content_date_create = @date2 or el_content.content_date_create = @date3

end
GO
/****** Object:  StoredProcedure [get_content_date_time_create]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_date_time_create](@content_id int) as
begin

select (el_content.content_date_create + ' ' + el_content.content_time_create) as content_date_time_create from el_content
where el_content.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_content_date_time_send]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_content_date_time_send](@content_id int) as
begin

select (el_content.content_date_create + ' ' + el_content.content_time_create) as content_date_time_create from el_content
where el_content.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_content_id_by_comment_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_id_by_comment_id](@comment_id int) as
begin

select el_comment.content_id from el_comment
where el_comment.comment_id = @comment_id

end
GO
/****** Object:  StoredProcedure [get_content_id_with_title]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_id_with_title](@site_id int) as
begin

select el_content.content_id,el_content.content_title from el_content
order by el_content.content_date_create desc,el_content.content_time_create desc

end
GO
/****** Object:  StoredProcedure [get_content_keywords]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_keywords](@content_id int) as
begin

select el_content_keywords.* from el_content_keywords 
where el_content_keywords.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_content_reply]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_reply](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin


declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @guest_id int
set @guest_id = 0

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_content_reply.*,(ISNULL(el_user.user_id,' + @guest_id + ')) as user_guest_id,(ISNULL(el_user.user_site_name,el_content_reply.content_reply_guest_name)) as content_reply_user_guest_name,(ISNULL(el_user.user_email,el_content_reply.content_reply_guest_email)) as content_reply_user_guest_email,(el_content_reply.content_reply_date_send + ' + '''-''' + ' + el_content_reply.content_reply_time_send) as content_reply_date_and_time_send,el_user.user_site_name,el_content.content_title,el_category.category_id,el_site.site_id from el_content_reply
left join el_user on el_content_reply.user_id = el_user.user_id
left join el_content on el_content_reply.content_id = el_content.content_id
left join el_category on el_content.category_id=el_category.category_id 
left join el_site on el_category.site_id=el_site.site_id 
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_content_reply_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_reply_count] as
begin

select COUNT(el_content_reply.content_reply_id) as content_reply_count from el_content_reply

end
GO
/****** Object:  StoredProcedure [get_content_source]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_source](@content_id int) as
begin

select el_content_source.* from el_content_source
where el_content_source.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_content_title]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_title](@content_id int) as
begin

select el_content.content_title from el_content where el_content.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_content_verify_comments_by_comment_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_verify_comments_by_comment_id](@comment_id int) as
begin 

declare @content_id int = (select el_comment.content_id from el_comment where el_comment.comment_id = @comment_id)

select el_content.content_verify_comments from el_content
where el_content.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_content_verify_comments_by_content_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_content_verify_comments_by_content_id](@content_id int) as
begin 

select el_content.content_verify_comments from el_content
where el_content.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_current_admin_style]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_admin_style](@admin_style_id int) as
begin

select el_admin_style.*,(el_admin_style.admin_style_directory_path + '/' + el_admin_style.admin_style_physical_name) as admin_style_physical_path from el_admin_style
where el_admin_style.admin_style_id = @admin_style_id

end
GO
/****** Object:  StoredProcedure [get_current_admin_template]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_admin_template](@admin_template_id int) as
begin

select el_admin_template.*,(el_admin_template.admin_template_directory_path + '/' + el_admin_template.admin_template_physical_name) as admin_template_physical_path from el_admin_template
where el_admin_template.admin_template_id = @admin_template_id

end
GO
/****** Object:  StoredProcedure [get_current_attachment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_attachment](@attachment_id int) as
begin

select el_attachment.*,(el_attachment.attachment_directory_path + '/' + el_attachment.attachment_physical_name) as attachment_physical_path from el_attachment 
where el_attachment.attachment_id = @attachment_id

end
GO
/****** Object:  StoredProcedure [get_current_category]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_category](@category_id int) as
begin

select el_category.*,tmp_el_category.category_name as parent_category_name,el_site.site_name,el_site.site_global_name,el_site_style.site_style_name,el_site_template.site_template_name from el_category
left join el_category tmp_el_category on el_category.parent_category = tmp_el_category.category_id
left join el_site on el_category.site_id = el_site.site_id
left join el_site_style on el_category.site_style_id = el_site_style.site_style_id
left join el_site_template on el_category.site_template_id = el_site_template.site_template_id
where el_category.category_id = @category_id

end
GO
/****** Object:  StoredProcedure [get_current_comment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_comment](@comment_id int) as
begin

select el_comment.*,el_user.user_site_name,el_user.user_email,el_content.content_title,el_category.category_id,el_site.site_id
,(ISNULL(el_user.user_site_name,el_comment.comment_guest_name)) as comment_user_guest_name
,(ISNULL(el_user.user_email,el_comment.comment_guest_email)) as comment_user_guest_email
,(select count(*) from el_comment where el_comment.parent_comment = el_comment.comment_id ) as comment_reply_count
,(el_comment.comment_date_send + '-' + el_comment.comment_time_send) as comment_date_and_time_send from el_comment
left join el_user on el_comment.user_id=el_user.user_id
left join el_content on el_comment.content_id=el_content.content_id
left join el_category on el_content.category_id=el_category.category_id 
left join el_site on el_category.site_id=el_site.site_id 
where el_comment.comment_id = @comment_id

end
GO
/****** Object:  StoredProcedure [get_current_component]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_component](@component_id int) as
begin

select el_component.*,(el_component.component_directory_path + '/' + el_component.component_physical_name) as component_physical_path from el_component 
where el_component.component_id = @component_id

end
GO
/****** Object:  StoredProcedure [get_current_contact]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_contact](@contact_id int) as
begin 

select el_contact.*,el_user.user_site_name,el_user.user_email,(ISNULL(el_user.user_site_name,el_contact.contact_guest_name)) as contact_user_guest_name,(ISNULL(el_user.user_email,el_contact.contact_guest_email)) as contact_user_guest_email,(el_contact.contact_date_send + '-' + el_contact.contact_time_send) as contact_date_and_time_send from el_contact
left join el_user on el_contact.user_id = el_user.user_id
where el_contact.contact_id = @contact_id

end
GO
/****** Object:  StoredProcedure [get_current_content]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_content](@content_id int) as
begin
 
select el_content.*,(select count(*) from el_comment where el_comment.content_id = el_content.content_id and el_comment.comment_active = 1) as comment_count
,(select count(*) from el_content_reply where el_content_reply.content_id = el_content.content_id and el_content_reply.content_reply_active = 1) as content_reply_count
,el_category.category_name,el_user.user_site_name,el_user.user_name,el_user.user_real_name,el_content_rating.content_rating_number_of_voted,el_content_rating.content_rating_rating,el_content_icon.content_icon_physical_name,el_content_avatar.content_avatar_physical_name,el_site.site_id,el_site.site_name,el_site.site_global_name
from el_content 
left join el_category on el_content.category_id = el_category.category_id 
left join el_user on el_content.user_id = el_user.user_id 
left join el_content_rating on el_content.content_id = el_content_rating.content_id 
left join el_content_icon on el_content.content_id = el_content_icon.content_id 
left join el_content_avatar on el_content.content_id = el_content_avatar.content_id 
left join el_site on el_category.site_id = el_site.site_id 
where el_content.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [get_current_content_reply]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_content_reply](@content_reply_id int) as
begin 

declare @guest_id int
set @guest_id = 0

select el_content_reply.*,(ISNULL(el_user.user_id,@guest_id)) as user_guest_id,(ISNULL(el_user.user_site_name,el_content_reply.content_reply_guest_name)) as content_reply_user_guest_name,(ISNULL(el_user.user_email,el_content_reply.content_reply_guest_email)) as content_reply_user_guest_email,(el_content_reply.content_reply_date_send + '-' + el_content_reply.content_reply_time_send) as content_reply_date_and_time_send,el_user.user_site_name,el_content.content_title,el_category.category_id,el_site.site_id from el_content_reply
left join el_user on el_content_reply.user_id = el_user.user_id
left join el_content on el_content_reply.content_id = el_content.content_id
left join el_category on el_content.category_id=el_category.category_id 
left join el_site on el_category.site_id=el_site.site_id 
where el_content_reply.content_reply_id = @content_reply_id

end
GO
/****** Object:  StoredProcedure [get_current_editor_template]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_editor_template](@editor_template_id int) as
begin

select el_editor_template.*, (el_editor_template.editor_template_directory_path + '/' + el_editor_template.editor_template_physical_name) as editor_template_physical_path from el_editor_template
where el_editor_template.editor_template_id = @editor_template_id
 
end
GO
/****** Object:  StoredProcedure [get_current_extra_helper]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_extra_helper](@extra_helper_id int) as
begin

select *,(el_extra_helper.extra_helper_directory_path + '/' + el_extra_helper.extra_helper_physical_name) as extra_helper_physical_path from  el_extra_helper 
where extra_helper_id = @extra_helper_id

end
GO
/****** Object:  StoredProcedure [get_current_fetch]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_fetch](@fetch_id int) as
begin

select el_fetch.* from el_fetch
where el_fetch.fetch_id = @fetch_id

end
GO
/****** Object:  StoredProcedure [get_current_fetch_by_fetch_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_fetch_by_fetch_name](@fetch_name nvarchar(50)) as
begin

select el_fetch.* from el_fetch
where el_fetch.fetch_name = @fetch_name

end
GO
/****** Object:  StoredProcedure [get_current_foot_print]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_foot_print](@foot_print_id int) as
begin

select el_foot_print.*,el_user.user_site_name, (el_user.user_site_name + '-' + el_foot_print.foot_print_event  + '-' + el_foot_print.foot_print_value) as foot_print_user_event_value ,(el_foot_print.foot_print_date_action + '-' + el_foot_print.foot_print_time_action) as foot_print_date_and_time_action from el_foot_print
left join el_user on el_foot_print.user_id = el_user.user_id
where el_foot_print.foot_print_id = @foot_print_id

end
GO
/****** Object:  StoredProcedure [get_current_group]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_current_group](@group_id int) as
begin

select el_group.* from el_group
where el_group.group_id = @group_id

end
GO
/****** Object:  StoredProcedure [get_current_item]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_item](@item_id int) as
begin

select el_item.* from el_item
where el_item.item_id = @item_id

end
GO
/****** Object:  StoredProcedure [get_current_language]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_language](@language_id int) as
begin

select el_language.*,el_site.site_name,el_site.site_global_name  from el_language
left join el_site on el_language.site_id = el_site.site_id
where el_language.language_id = @language_id

end
GO
/****** Object:  StoredProcedure [get_current_link]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_link](@link_id int) as
begin

select el_link.* from el_link
where el_link.link_id = @link_id

end
GO
/****** Object:  StoredProcedure [get_current_menu]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_menu](@menu_id int) as
begin

select el_menu.*,el_site.site_name,el_site.site_global_name from el_menu 
left join el_site on el_menu.site_id = el_site.site_id
where el_menu.menu_id = @menu_id

end
GO
/****** Object:  StoredProcedure [get_current_module]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_module](@module_id int) as
begin

select el_module.*,(el_module.module_directory_path + '/' + el_module.module_physical_name) as module_physical_path from el_module 
where el_module.module_id = @module_id

end
GO
/****** Object:  StoredProcedure [get_current_page]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_page](@page_id int) as
begin

select el_page.*,(el_page.page_directory_path + '/' + el_page.page_physical_name) as page_physical_path,el_site_style.site_style_name,(el_site_style.site_style_directory_path + '/' + el_site_style.site_style_physical_name) as site_style_physical_path, el_site_template.site_template_name,(el_site_template.site_template_directory_path + '/' + el_site_template.site_template_physical_name) as site_template_physical_path, el_user.user_site_name from el_page 
left join el_site_style on el_page.site_style_id = el_site_style.site_style_id
left join el_site_template on el_page.site_template_id = el_site_template.site_template_id
left join el_user on el_page.user_id = el_user.user_id
left join el_page_access_show on el_page.page_id = el_page_access_show.page_id
where el_page.page_id = @page_id

end
GO
/****** Object:  StoredProcedure [get_current_patch]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_current_patch](@patch_id int) as
begin

select el_patch.* from el_patch 
where el_patch.patch_id = @patch_id

end
GO
/****** Object:  StoredProcedure [get_current_plugin]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_plugin](@plugin_id int) as
begin

select el_plugin.*,(el_plugin.plugin_directory_path + '/' + el_plugin.plugin_physical_name) as plugin_physical_path from el_plugin 
where el_plugin.plugin_id = @plugin_id

end
GO
/****** Object:  StoredProcedure [get_current_role]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_role](@role_id int) as
begin

select el_role.* from el_role
where el_role.role_id = @role_id

end
GO
/****** Object:  StoredProcedure [get_current_role_aggregation]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_current_role_aggregation](@group_id int) as
begin

select el_group_role.*, el_role.* from el_group_role
left join el_role on el_role.role_id = el_group_role.role_id
where el_group_role.group_id = @group_id

end
GO
/****** Object:  StoredProcedure [get_current_site]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_site](@site_id int) as
begin

select el_site.*,el_page.page_global_name,el_page.page_name,el_language.language_global_name,el_language.language_name,el_site_style.site_style_name,(el_site_style.site_style_directory_path + '/' + el_site_style.site_style_physical_name) as site_style_physical_path, el_site_template.site_template_name,(el_site_template.site_template_directory_path + '/' + el_site_template.site_template_physical_name) as site_template_physical_path,el_admin_style.admin_style_name,(el_admin_style.admin_style_directory_path + '/' + el_admin_style.admin_style_physical_name) as admin_style_physical_path,el_admin_template.admin_template_name,(el_admin_template.admin_template_directory_path + '/' + el_admin_template.admin_template_physical_name) as admin_template_physical_path from el_site 
left join el_page on el_site.page_id = el_page.page_id
left join el_language on el_site.language_id = el_language.language_id
left join el_site_style on el_site.site_style_id = el_site_style.site_style_id
left join el_admin_style on el_site.admin_style_id = el_admin_style.admin_style_id
left join el_site_template on el_site.site_template_id = el_site_template.site_template_id
left join el_admin_template on el_site.admin_template_id = el_admin_template.admin_template_id
where el_site.site_id = @site_id

end
GO
/****** Object:  StoredProcedure [get_current_site_by_site_global_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_site_by_site_global_name](@site_global_name varchar(50)) as
begin

select el_site.*,el_page.page_global_name,el_page.page_name,el_language.language_global_name,el_language.language_name,el_site_style.site_style_name,(el_site_style.site_style_directory_path + '/' + el_site_style.site_style_physical_name) as site_style_physical_path, el_site_template.site_template_name,(el_site_template.site_template_directory_path + '/' + el_site_template.site_template_physical_name) as site_template_physical_path,el_admin_style.admin_style_name,(el_admin_style.admin_style_directory_path + '/' + el_admin_style.admin_style_physical_name) as admin_style_physical_path,el_admin_template.admin_template_name,(el_admin_template.admin_template_directory_path + '/' + el_admin_template.admin_template_physical_name) as admin_template_physical_path from el_site 
left join el_page on el_site.page_id = el_page.page_id
left join el_language on el_site.language_id = el_language.language_id
left join el_site_style on el_site.site_style_id = el_site_style.site_style_id
left join el_admin_style on el_site.admin_style_id = el_admin_style.admin_style_id
left join el_site_template on el_site.site_template_id = el_site_template.site_template_id
left join el_admin_template on el_site.admin_template_id = el_admin_template.admin_template_id
where el_site.site_global_name = @site_global_name

end
GO
/****** Object:  StoredProcedure [get_current_site_style]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_site_style](@site_style_id int) as
begin 

select el_site_style.*,(el_site_style.site_style_directory_path + '/' + el_site_style.site_style_physical_name) as site_style_physical_path from el_site_style
where el_site_style.site_style_id = @site_style_id

end
GO
/****** Object:  StoredProcedure [get_current_site_template]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_site_template](@site_template_id int) as
begin

select el_site_template.*,(el_site_template.site_template_directory_path + '/' + el_site_template.site_template_physical_name) as site_template_physical_path from el_site_template
where el_site_template.site_template_id = @site_template_id

end
GO
/****** Object:  StoredProcedure [get_current_user]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_user](@user_id int) as
begin

select el_user.*,DATEDIFF(hour,el_user.user_birthday,GETDATE())/8766 as user_age,el_group.group_name,
el_admin_style.admin_style_name,el_admin_template.admin_template_name,el_site_style.site_style_name,el_site_template.site_template_name,
(select COUNT(el_content.user_id) from el_content where el_content.user_id = @user_id) as number_of_content,
(select COUNT(el_comment.user_id) from el_comment where el_comment.user_id = @user_id) as number_of_comment 
from el_user
left join el_group on el_user.group_id = el_group.group_id
left join el_admin_style on el_user.admin_style_id = el_admin_style.admin_style_id
left join el_admin_template on el_user.admin_template_id = el_admin_template.admin_template_id
left join el_site_style on el_user.site_style_id = el_site_style.site_style_id
left join el_site_template on el_user.site_template_id = el_site_template.site_template_id
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [get_current_user_statistics]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_user_statistics](@user_id int) as
begin

declare @number_of_attachment int = (select COUNT(el_attachment.user_id) from el_attachment)
declare @number_of_content int = (select COUNT(el_content.user_id) from el_content)
declare @number_of_content_reply int = (select COUNT(el_content_reply.user_id) from el_content_reply)
declare @number_of_comment int = (select COUNT(el_comment.user_id) from el_comment)
declare @number_of_comment_reply int = (select COUNT(el_comment.user_id) from el_comment where el_comment.parent_comment <> 0)
 
declare @number_of_user_attachment int = (select COUNT(el_attachment.user_id) from el_attachment where el_attachment.user_id = @user_id)
declare @number_of_user_content int = (select COUNT(el_content.user_id) from el_content where el_content.user_id = @user_id)
declare @number_of_user_content_reply int = (select COUNT(el_content_reply.user_id) from el_content_reply where el_content_reply.user_id = @user_id)
declare @number_of_user_comment int = (select COUNT(el_comment.user_id) from el_comment where el_comment.user_id = @user_id)
declare @number_of_user_comment_reply int = (select COUNT(el_comment.user_id) from el_comment where el_comment.user_id = @user_id and el_comment.parent_comment <> 0)

declare @percent_of_user_attachment float = 0
declare @percent_of_user_content float = 0
declare @percent_of_user_content_reply float = 0
declare @percent_of_user_comment float = 0
declare @percent_of_user_comment_reply float = 0


if (@number_of_attachment > 0)
begin
	set @percent_of_user_attachment = (cast(@number_of_user_attachment AS NUMERIC(10,4)) / cast(@number_of_attachment AS NUMERIC(10,4)) * 100)
end

if (@number_of_content > 0)
begin
set @percent_of_user_content = (cast(@number_of_user_content AS NUMERIC(10,4)) / cast(@number_of_content AS NUMERIC(10,4)) * 100)
end

if (@number_of_content_reply > 0)
begin
set @percent_of_user_content_reply = (cast(@number_of_user_content_reply AS NUMERIC(10,4)) / cast(@number_of_content_reply AS NUMERIC(10,4)) * 100)
end

if (@number_of_comment > 0)
begin
set @percent_of_user_comment = (cast(@number_of_user_comment AS NUMERIC(10,4)) / cast(@number_of_comment AS NUMERIC(10,4)) * 100)
end

if (@number_of_comment_reply > 0)
begin
set @percent_of_user_comment_reply = (cast(@number_of_user_comment_reply AS NUMERIC(10,4)) / cast(@number_of_comment_reply AS NUMERIC(10,4)) * 100)
end

select
@number_of_user_attachment as number_of_user_attachment,
@number_of_user_content as number_of_user_content,
@number_of_user_content_reply as number_of_user_content_reply,
@number_of_user_comment as number_of_user_comment,
@number_of_user_comment_reply as number_of_user_comment_reply,
@percent_of_user_attachment as percent_of_user_attachment,
@percent_of_user_content as percent_of_user_content,
@percent_of_user_content_reply as percent_of_user_content_reply,
@percent_of_user_comment as percent_of_user_comment,
@percent_of_user_comment_reply as percent_of_user_comment_reply

end
GO
/****** Object:  StoredProcedure [get_current_view]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_view](@view_id int) as
begin 

select el_view.*,el_site_style.site_style_name,el_site_template.site_template_name from el_view
left join el_site_style on el_view.site_style_id = el_site_style.site_style_id
left join el_site_template on el_view.site_template_id = el_site_template.site_template_id
where el_view.view_id = @view_id

end
GO
/****** Object:  StoredProcedure [get_current_view_query_string]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_current_view_query_string](@view_id int) as
begin

select el_view_query_string.* from el_view_query_string 
where el_view_query_string.view_id = @view_id

end
GO
/****** Object:  StoredProcedure [get_delay_content_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_delay_content_count] as
begin

select COUNT(el_content.content_id) as delay_content_count from el_content
where el_content.content_status = 'delay'

end
GO
/****** Object:  StoredProcedure [get_dominant_role_type]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_dominant_role_type](@group_id int) as
begin

declare @dominant_role_type as nvarchar(50) = N'guest'

if exists(select * from el_group
	left join el_group_role on el_group_role.group_id = el_group.group_id
	left join el_role on el_role.role_id = el_group_role.role_id
	where el_group.group_id = @group_id
	and el_role.role_type = N'member')
	begin

		set @dominant_role_type = N'member'

	end
if exists(select * from el_group
	left join el_group_role on el_group_role.group_id = el_group.group_id
	left join el_role on el_role.role_id = el_group_role.role_id
	where el_group.group_id = @group_id
	and el_role.role_type = N'admin')
	begin

		set @dominant_role_type = N'admin'

	end

select @dominant_role_type as dominant_role_type

end
GO
/****** Object:  StoredProcedure [get_draft_content_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_draft_content_count] as
begin

select COUNT(el_content.content_id) as draft_content_count from el_content
where el_content.content_status = 'draft'

end
GO
/****** Object:  StoredProcedure [get_editor_template]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_editor_template](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin 

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_editor_template.*,(el_editor_template.editor_template_directory_path + ' + '''/''' + ' + el_editor_template.editor_template_physical_name) as editor_template_physical_path from el_editor_template
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_editor_template_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_editor_template_access_show](@editor_template_id int) as
begin

select el_editor_template_access_show.* from el_editor_template_access_show
where el_editor_template_access_show.editor_template_id = @editor_template_id

end
GO
/****** Object:  StoredProcedure [get_editor_template_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_editor_template_count] as
begin

select COUNT(el_editor_template.editor_template_id) as editor_template_count from el_editor_template

end
GO
/****** Object:  StoredProcedure [get_editor_template_id_by_editor_template_directory_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_editor_template_id_by_editor_template_directory_path](@editor_template_directory_path nvarchar(800)) as
begin

select el_editor_template.editor_template_id from el_editor_template
where el_editor_template.editor_template_directory_path = @editor_template_directory_path

end
GO
/****** Object:  StoredProcedure [get_editor_template_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_editor_template_list] as
begin

select el_editor_template.* from  el_editor_template
order by el_editor_template.editor_template_category

end
GO
/****** Object:  StoredProcedure [get_extra_helper]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_extra_helper](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin 

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_extra_helper.*,(el_extra_helper.extra_helper_directory_path + ' + '''/''' + ' + el_extra_helper.extra_helper_physical_name) as extra_helper_physical_path from el_extra_helper
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_extra_helper_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_extra_helper_access_show](@extra_helper_id int) as
begin

select el_extra_helper_access_show.* from el_extra_helper_access_show
where el_extra_helper_access_show.extra_helper_id = @extra_helper_id

end
GO
/****** Object:  StoredProcedure [get_extra_helper_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_extra_helper_count] as
begin

select COUNT(el_extra_helper.extra_helper_id) as extra_helper_count from el_extra_helper

end
GO
/****** Object:  StoredProcedure [get_extra_helper_id_by_extra_helper_directory_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_extra_helper_id_by_extra_helper_directory_path](@extra_helper_directory_path nvarchar(800)) as
begin

select el_extra_helper.extra_helper_id from el_extra_helper
where el_extra_helper.extra_helper_directory_path = @extra_helper_directory_path

end
GO
/****** Object:  StoredProcedure [get_extra_helper_id_by_extra_helper_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_extra_helper_id_by_extra_helper_name](@extra_helper_name nvarchar(50)) as
begin

select el_extra_helper.extra_helper_id from el_extra_helper
where el_extra_helper.extra_helper_name = @extra_helper_name

end
GO
/****** Object:  StoredProcedure [get_extra_helper_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_extra_helper_list] as
begin

select el_extra_helper.* from  el_extra_helper

end
GO
/****** Object:  StoredProcedure [get_fetch]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_fetch](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_fetch.* from el_fetch
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_fetch_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_fetch_access_show](@fetch_id int) as
begin

select el_fetch_access_show.* from el_fetch_access_show
where el_fetch_access_show.fetch_id = @fetch_id

end
GO
/****** Object:  StoredProcedure [get_fetch_menu]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_fetch_menu](@fetch_id int) as
begin

select el_menu_fetch.* from el_menu_fetch
where el_menu_fetch.fetch_id = @fetch_id

end
GO
/****** Object:  StoredProcedure [get_foot_print]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_foot_print](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_foot_print.*,el_user.user_site_name, (el_user.user_site_name + ' + '''-''' + ' + el_foot_print.foot_print_event  + ' + '''-''' + ' + el_foot_print.foot_print_value) as foot_print_user_event_value ,(el_foot_print.foot_print_date_action + ' + '''-''' + ' + el_foot_print.foot_print_time_action) as foot_print_date_and_time_action from el_foot_print 
left join el_user on el_foot_print.user_id = el_user.user_id
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_foot_print_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_foot_print_count] as
begin

select COUNT(el_foot_print.foot_print_id) as foot_print_count from el_foot_print

end
GO
/****** Object:  StoredProcedure [get_group]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_group](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_group.* from el_group
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_group_id_by_group_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_group_id_by_group_name](@group_name nvarchar(50)) as
begin

select el_group.group_id from el_group
where el_group.group_name = @group_name

end
GO
/****** Object:  StoredProcedure [get_group_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_group_list] as
begin

select * from el_group

end
GO
/****** Object:  StoredProcedure [get_group_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_group_name](@group_id int) as
begin

select el_group.group_name from el_group
where el_group.group_id = @group_id

end
GO
/****** Object:  StoredProcedure [get_group_role]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_group_role](@group_id int) as
begin

select el_group_role.* from el_group_role
where el_group_role.group_id = @group_id

end
GO
/****** Object:  StoredProcedure [get_inactive_comment_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_inactive_comment_count] as
begin

select COUNT(el_comment.comment_id) as inactive_comment_count from el_comment
where el_comment.comment_active = 0

end
GO
/****** Object:  StoredProcedure [get_inactive_content_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_inactive_content_count] as
begin

select COUNT(el_content.content_id) as inactive_content_count from el_content
where el_content.content_status = 'inactive'

end
GO
/****** Object:  StoredProcedure [get_item]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_item](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_item.* from el_item
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_item_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_item_access_show](@item_id int) as
begin

select el_item_access_show.* from el_item_access_show
where el_item_access_show.item_id = @item_id

end
GO
/****** Object:  StoredProcedure [get_item_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_item_count] as
begin

select COUNT(el_item.item_id) as item_count from el_item

end
GO
/****** Object:  StoredProcedure [get_item_id_by_item_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_item_id_by_item_name](@item_name nvarchar(50)) as
begin

select el_item.item_id from el_item
where el_item.item_name = @item_name

end
GO
/****** Object:  StoredProcedure [get_item_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_item_list] as
begin

select el_item.* from el_item

end
GO
/****** Object:  StoredProcedure [get_item_menu]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_item_menu](@item_id int) as
begin

select el_menu_item.* from el_menu_item
where el_menu_item.item_id = @item_id

end
GO
/****** Object:  StoredProcedure [get_item_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_item_name](@item_id int) as
begin

select el_item.item_name from el_item
where el_item.item_id = @item_id

end
GO
/****** Object:  StoredProcedure [get_language]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_language](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_language.*,el_site.site_name,el_site.site_global_name  from el_language
left join el_site on el_language.site_id = el_site.site_id
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_language_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_language_count] as
begin

select COUNT(el_language.language_id) as language_count from el_language

end
GO
/****** Object:  StoredProcedure [get_language_id_by_language_global_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_language_id_by_language_global_name](@language_global_name nvarchar(50)) as
begin

select el_language.language_id from el_language
where el_language.language_global_name = @language_global_name

end
GO
/****** Object:  StoredProcedure [get_language_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_language_list] as
begin

select el_language.language_id,el_language.language_global_name,el_language.language_name  from  el_language

end
GO
/****** Object:  StoredProcedure [get_language_name_and_global_name_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_language_name_and_global_name_list] as
begin

select el_language.language_name,el_language.language_global_name from el_language

end
GO
/****** Object:  StoredProcedure [get_last_attachment_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_last_attachment_name](@count int = 10) as
begin

select top(@count) el_attachment.attachment_name,el_attachment.attachment_physical_name from el_attachment
order by el_attachment.attachment_id desc

end
GO
/****** Object:  StoredProcedure [get_last_content]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_last_content](@number_of_rows int) as
begin

select top(@number_of_rows) el_content.content_id,el_content.content_date_create,el_content.content_time_create,el_content.content_title,el_user.user_site_name from el_content,el_user,el_category where el_content.user_id = el_user.user_id and el_content.category_id = el_category.category_id order by el_content.content_date_create desc, el_content.content_time_create desc 

end
GO
/****** Object:  StoredProcedure [get_last_content_category_date_time]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_last_content_category_date_time](@category_id int) as
begin

select top(1) el_content.content_date_create,el_content.content_time_create from el_content
where el_content.category_id = @category_id
order by el_content.content_date_create desc, el_content.content_time_create desc

end
GO
/****** Object:  StoredProcedure [get_last_content_date_create]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_last_content_date_create] as
begin

select top(1) el_content.content_date_create from el_content
order by el_content.content_date_create desc, el_content.content_time_create desc

end
GO
/****** Object:  StoredProcedure [get_last_content_date_time_create_by_site_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_last_content_date_time_create_by_site_id](@site_id int) as
begin

select top(1) (el_content.content_date_create + ' ' + el_content.content_time_create) as last_content_date_time_create from el_content
left join el_category on el_category.category_id = el_content.category_id
left join el_site on el_category.site_id = el_site.site_id
where el_site.site_id = @site_id
order by el_content.content_date_create desc, el_content.content_time_create desc 

end
GO
/****** Object:  StoredProcedure [get_link]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_link](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_link.* from el_link
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_link_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_link_count] as
begin

select COUNT(el_link.link_id) as link_count from el_link

end
GO
/****** Object:  StoredProcedure [get_link_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_link_list] as
begin

select el_link.* from el_link

end
GO
/****** Object:  StoredProcedure [get_link_menu]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_link_menu](@link_id int) as
begin

select el_menu_link.* from el_menu_link
where el_menu_link.link_id = @link_id

end
GO
/****** Object:  StoredProcedure [get_link_value_and_title_and_href_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_link_value_and_title_and_href_list] as
begin

select el_link.link_value,el_link.link_title,el_link.link_href from el_link
where el_link.link_active = 1

end
GO
/****** Object:  StoredProcedure [get_member_page]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_member_page] as
begin

select *,(el_page.page_directory_path + '/' + el_page.page_physical_name) as page_physical_path from el_page
where page_active = 1
and page_category = 'member'
	
end
GO
/****** Object:  StoredProcedure [get_menu]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_menu.*,el_site.site_name,el_site.site_global_name from el_menu 
left join el_site on el_menu.site_id = el_site.site_id
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_menu_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu_access_show](@menu_id int) as
begin

select el_menu_access_show.* from el_menu_access_show
where el_menu_access_show.menu_id = @menu_id

end
GO
/****** Object:  StoredProcedure [get_menu_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu_count] as
begin

select COUNT(el_menu.menu_id) as menu_count from el_menu

end
GO
/****** Object:  StoredProcedure [get_menu_fetch]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu_fetch](@menu_id int, @role_id int) as
begin

select el_fetch.* from el_fetch
left join el_menu_fetch on el_fetch.fetch_id = el_menu_fetch.fetch_id
left join el_fetch_access_show on el_fetch.fetch_id = el_fetch_access_show.fetch_id
where el_menu_fetch.menu_id = @menu_id
and el_fetch.fetch_active = 1
and (el_fetch_access_show.role_id = @role_id or el_fetch.fetch_public_access_show = 1)
order by el_fetch.fetch_sort_index

end
GO
/****** Object:  StoredProcedure [get_menu_fetch_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu_fetch_by_group_id](@menu_id int, @group_id int) as
begin

select el_fetch.* from el_fetch
left join el_menu_fetch on el_fetch.fetch_id = el_menu_fetch.fetch_id
left join el_fetch_access_show on el_fetch.fetch_id = el_fetch_access_show.fetch_id
where el_menu_fetch.menu_id = @menu_id
and el_fetch.fetch_active = 1
and ((el_fetch.fetch_public_access_show = 1) or Exists(select el_fetch_access_show.fetch_access_show_id from el_fetch_access_show left join el_role on el_role.role_id = el_fetch_access_show.role_id join el_group_role on el_group_role.role_id = el_fetch_access_show.role_id where el_fetch_access_show.fetch_id = el_fetch.fetch_id and el_group_role.group_id = @group_id and el_role.role_active = 1))
order by el_fetch.fetch_sort_index

end
GO
/****** Object:  StoredProcedure [get_menu_item]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu_item](@menu_id int,@role_id int) as
begin

select el_item.* from el_item
left join el_menu_item on el_item.item_id = el_menu_item.item_id
left join el_item_access_show on el_item.item_id = el_item_access_show.item_id
where el_menu_item.menu_id = @menu_id
and el_item.item_active = 1
and (el_item_access_show.role_id = @role_id or el_item.item_public_access_show = 1)
order by el_item.item_sort_index

end
GO
/****** Object:  StoredProcedure [get_menu_item_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu_item_by_group_id](@menu_id int, @group_id int) as
begin

select el_item.* from el_item
left join el_menu_item on el_item.item_id = el_menu_item.item_id
where el_menu_item.menu_id = @menu_id
and el_item.item_active = 1
and ((el_item.item_public_access_show = 1) or Exists(select el_item_access_show.item_access_show_id from el_item_access_show left join el_role on el_role.role_id = el_item_access_show.role_id join el_group_role on el_group_role.role_id = el_item_access_show.role_id where el_item_access_show.item_id = el_item.item_id and el_group_role.group_id = @group_id and el_role.role_active = 1))
order by el_item.item_sort_index

end
GO
/****** Object:  StoredProcedure [get_menu_link]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu_link](@menu_id int) as
begin

select el_link.* from el_link
left join el_menu_link on el_link.link_id = el_menu_link.link_id
where el_menu_link.menu_id = @menu_id
and el_link.link_active = 1
order by el_link.link_sort_index

end
GO
/****** Object:  StoredProcedure [get_menu_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu_list] as
begin

select el_menu.*,el_site.site_name,el_site.site_global_name from el_menu 
left join el_site on el_menu.site_id = el_site.site_id
where el_menu.menu_active = 1

end
GO
/****** Object:  StoredProcedure [get_menu_list_by_location]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu_list_by_location](@location varchar(30), @group_id int) as
begin

select el_menu.*  from  el_menu
where el_menu.menu_active = 1
and el_menu.menu_location = @location
and ((el_menu.menu_public_access_show = 1) or (EXISTS(select el_menu_access_show.menu_access_show_id from el_menu_access_show left join el_role on el_role.role_id = el_menu_access_show.role_id join el_group_role on el_group_role.role_id = el_menu_access_show.role_id where el_menu_access_show.menu_id = el_menu.menu_id and el_group_role.group_id = @group_id and el_role.role_active = 1)))
order by menu_sort_index asc

end
GO
/****** Object:  StoredProcedure [get_menu_list_by_site_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu_list_by_site_id](@site_id int) as
begin

select el_menu.*,el_site.site_name,el_site.site_global_name from el_menu 
left join el_site on el_menu.site_id = el_site.site_id
where el_menu.menu_active = 1
and el_menu.site_id = @site_id

end
GO
/****** Object:  StoredProcedure [get_menu_module]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu_module](@menu_id int,@role_id int) as
begin

select el_module.*,(el_module.module_directory_path + '/' + el_module.module_physical_name) as module_physical_path, el_menu_module.menu_module_query_string from el_module
left join el_menu_module on el_module.module_id = el_menu_module.module_id
where el_menu_module.menu_id = @menu_id
and el_module.module_active = 1
and ((el_module.module_public_access_show = 1) or (EXISTS(select el_module_role_access.module_role_access_id from  el_module_role_access where el_module_role_access.module_id = el_module.module_id and el_module_role_access.role_id = @role_id and el_module_role_access.module_show = 1)))

order by el_module.module_sort_index

end
GO
/****** Object:  StoredProcedure [get_menu_module_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu_module_by_group_id](@menu_id int, @group_id int) as
begin

select el_module.*,(el_module.module_directory_path + '/' + el_module.module_physical_name) as module_physical_path, el_menu_module.menu_module_query_string from el_module
left join el_menu_module on el_module.module_id = el_menu_module.module_id
where el_menu_module.menu_id = @menu_id
and el_module.module_active = 1
and ((el_module.module_public_access_show = 1) or (EXISTS(select el_module_role_access.module_role_access_id from el_module_role_access left join el_role on el_role.role_id = el_module_role_access.role_id join el_group_role on el_group_role.role_id = el_module_role_access.role_id where el_module_role_access.module_id = el_module.module_id  and el_module_role_access.module_show = 1 and el_group_role.group_id = @group_id and el_role.role_active = 1)))
order by el_module.module_sort_index

end
GO
/****** Object:  StoredProcedure [get_menu_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_menu_name](@menu_id int) as
begin

select el_menu.menu_name from el_menu
where el_menu.menu_id = @menu_id

end
GO
/****** Object:  StoredProcedure [get_menu_plugin]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_menu_plugin](@menu_id int,@role_id int) as
begin

select el_plugin.*,(el_plugin.plugin_directory_path + '/' + el_plugin.plugin_physical_name) as plugin_physical_path, el_menu_plugin.menu_plugin_query_string from el_plugin
left join el_menu_plugin on el_plugin.plugin_id = el_menu_plugin.plugin_id
where el_menu_plugin.menu_id = @menu_id
and el_plugin.plugin_active = 1
and ((el_plugin.plugin_public_access_show = 1) or (EXISTS(select el_plugin_role_access.plugin_role_access_id from  el_plugin_role_access where el_plugin_role_access.plugin_id = el_plugin.plugin_id and el_plugin_role_access.role_id = @role_id and el_plugin_role_access.plugin_show = 1)))

order by el_plugin.plugin_sort_index

end
GO
/****** Object:  StoredProcedure [get_menu_plugin_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_menu_plugin_by_group_id](@menu_id int, @group_id int) as
begin

select el_plugin.*,(el_plugin.plugin_directory_path + '/' + el_plugin.plugin_physical_name) as plugin_physical_path, el_menu_plugin.menu_plugin_query_string from el_plugin
left join el_menu_plugin on el_plugin.plugin_id = el_menu_plugin.plugin_id
where el_menu_plugin.menu_id = @menu_id
and el_plugin.plugin_active = 1
and ((el_plugin.plugin_public_access_show = 1) or (EXISTS(select el_plugin_role_access.plugin_role_access_id from el_plugin_role_access left join el_role on el_role.role_id = el_plugin_role_access.role_id join el_group_role on el_group_role.role_id = el_plugin_role_access.role_id where el_plugin_role_access.plugin_id = el_plugin.plugin_id  and el_plugin_role_access.plugin_show = 1 and el_group_role.group_id = @group_id and el_role.role_active = 1)))

order by el_plugin.plugin_sort_index

end
GO
/****** Object:  StoredProcedure [get_module]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_module.*,(el_module.module_directory_path + ' + '''/''' + ' + el_module.module_physical_name) as module_physical_path from el_module
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_module_access_add]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module_access_add](@module_id int) as
begin

select el_module_role_access.* from el_module_role_access
where el_module_role_access.module_id = @module_id
and el_module_role_access.module_add = 1

end
GO
/****** Object:  StoredProcedure [get_module_access_delete_all]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module_access_delete_all](@module_id int) as
begin

select el_module_role_access.* from el_module_role_access
where el_module_role_access.module_id = @module_id
and el_module_role_access.module_delete_all = 1

end
GO
/****** Object:  StoredProcedure [get_module_access_delete_own]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module_access_delete_own](@module_id int) as
begin

select el_module_role_access.* from el_module_role_access
where el_module_role_access.module_id = @module_id
and el_module_role_access.module_delete_own = 1

end
GO
/****** Object:  StoredProcedure [get_module_access_edit_all]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module_access_edit_all](@module_id int) as
begin

select el_module_role_access.* from el_module_role_access
where el_module_role_access.module_id = @module_id
and el_module_role_access.module_edit_all = 1

end
GO
/****** Object:  StoredProcedure [get_module_access_edit_own]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module_access_edit_own](@module_id int) as
begin

select el_module_role_access.* from el_module_role_access
where el_module_role_access.module_id = @module_id
and el_module_role_access.module_edit_own = 1

end
GO
/****** Object:  StoredProcedure [get_module_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module_access_show](@module_id int) as
begin

select el_module_role_access.* from el_module_role_access
where el_module_role_access.module_id = @module_id
and el_module_role_access.module_show = 1

end
GO
/****** Object:  StoredProcedure [get_module_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module_count] as
begin

select COUNT(el_module.module_id) as module_count from el_module

end
GO
/****** Object:  StoredProcedure [get_module_id_by_module_directory_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module_id_by_module_directory_path](@module_directory_path nvarchar(800)) as
begin

select el_module.module_id from el_module
where el_module.module_directory_path = @module_directory_path

end
GO
/****** Object:  StoredProcedure [get_module_id_by_module_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module_id_by_module_name](@module_name nvarchar(50)) as
begin

select el_module.module_id from el_module
where el_module.module_name = @module_name

end
GO
/****** Object:  StoredProcedure [get_module_menu]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module_menu](@module_id int) as
begin

select el_menu_module.* from el_menu_module
where el_menu_module.module_id = @module_id

end
GO
/****** Object:  StoredProcedure [get_module_role_access]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module_role_access](@module_id int) as
begin

select el_module_role_access.* from el_module_role_access
where el_module_role_access.module_id = @module_id

end
GO
/****** Object:  StoredProcedure [get_module_role_access_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module_role_access_check](@module_id int, @role_id int) as
begin

declare @tmp_el_module table(module_access_show int, module_access_add int, module_access_edit_own int, module_access_delete_own int, module_access_edit_all int, module_access_delete_all int)

insert into @tmp_el_module
select el_module.module_public_access_show,
el_module.module_public_access_add,
el_module.module_public_access_edit_own,
el_module.module_public_access_delete_own,
el_module.module_public_access_edit_all,
el_module.module_public_access_delete_all
from el_module
where el_module.module_id = @module_id

if exists(select * from el_module_role_access
	left join el_role on el_role.role_id = el_module_role_access.role_id
	where el_module_role_access.module_id = @module_id
	and el_module_role_access.role_id = @role_id
	and el_role.role_active = 1)
	begin
		insert into @tmp_el_module
		select  el_module_role_access.module_show,
		el_module_role_access.module_add,
		el_module_role_access.module_edit_own,
		el_module_role_access.module_delete_own,
		el_module_role_access.module_edit_all,
		el_module_role_access.module_delete_all
		from el_module_role_access
		left join el_role on el_role.role_id = el_module_role_access.role_id
		where el_module_role_access.module_id = @module_id
		and el_module_role_access.role_id = @role_id
		and el_role.role_active = 1
	end

select cast(sum(module_access_show) as bit) as module_access_show,
cast(sum(module_access_add) as bit) as module_access_add,
cast(sum(module_access_edit_own) as bit) as module_access_edit_own,
cast(sum(module_access_delete_own) as bit) as module_access_delete_own,
cast(sum(module_access_edit_all) as bit) as module_access_edit_all,
cast(sum(module_access_delete_all) as bit) as module_access_delete_all
from @tmp_el_module

end
GO
/****** Object:  StoredProcedure [get_module_role_access_check_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_module_role_access_check_by_group_id](@module_id int, @group_id int) as
begin

declare @tmp_el_module table(module_access_show int, module_access_add int, module_access_edit_own int, module_access_delete_own int, module_access_edit_all int, module_access_delete_all int)

insert into @tmp_el_module
select
el_module.module_public_access_show,
el_module.module_public_access_add,
el_module.module_public_access_edit_own,
el_module.module_public_access_delete_own,
el_module.module_public_access_edit_all,
el_module.module_public_access_delete_all
from el_module
where el_module.module_id = @module_id

if exists(select * from el_module_role_access
	join el_group_role on el_group_role.role_id = el_module_role_access.role_id
	where el_module_role_access.module_id = @module_id
	and el_group_role.group_id = @group_id)
	begin
		insert into @tmp_el_module
		select
		el_module_role_access.module_show,
		el_module_role_access.module_add,
		el_module_role_access.module_edit_own,
		el_module_role_access.module_delete_own,
		el_module_role_access.module_edit_all,
		el_module_role_access.module_delete_all
		from el_module_role_access
		join el_group_role on el_group_role.role_id = el_module_role_access.role_id
		where el_module_role_access.module_id = @module_id
		and el_group_role.group_id = @group_id
	end

select
cast(sum(module_access_show) as bit) as module_access_show,
cast(sum(module_access_add) as bit) as module_access_add,
cast(sum(module_access_edit_own) as bit) as module_access_edit_own,
cast(sum(module_access_delete_own) as bit) as module_access_delete_own,
cast(sum(module_access_edit_all) as bit) as module_access_edit_all,
cast(sum(module_access_delete_all) as bit) as module_access_delete_all
from @tmp_el_module

end
GO
/****** Object:  StoredProcedure [get_number_of_all_visit_statistics]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_number_of_all_visit_statistics] as
begin

select sum(el_visit_statistics.visit_statistics_visit) as number_of_all_visit_statistics from el_visit_statistics

end
GO
/****** Object:  StoredProcedure [get_number_of_content]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_number_of_content] as
begin

select count(*) from el_content

end
GO
/****** Object:  StoredProcedure [get_number_of_content_with_date_create]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_number_of_content_with_date_create](@date_create char(10)) as
begin

select COUNT(*) from el_content where el_content.content_date_create = @date_create

end
GO
/****** Object:  StoredProcedure [get_number_of_date_visit_statistics]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_number_of_date_visit_statistics](@date char(10)) as
begin

select sum(el_visit_statistics.visit_statistics_visit) as number_of_date_visit_statistics from el_visit_statistics where el_visit_statistics.visit_statistics_date_visit = @date

end
GO
/****** Object:  StoredProcedure [get_number_of_inactive_comment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_number_of_inactive_comment] as
begin

select count(el_comment.comment_id) as inactive_comment_count from el_comment where el_comment.comment_active = 0

end
GO
/****** Object:  StoredProcedure [get_number_of_inactive_content]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_number_of_inactive_content] as
begin

select count(el_content.content_id) as inactive_content_count from el_content where el_content.content_status = 'inactive'

end
GO
/****** Object:  StoredProcedure [get_number_of_require_approval_comment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_number_of_require_approval_comment] as
begin

select count(el_comment.comment_id) from el_comment where el_comment.comment_active = 0

end
GO
/****** Object:  StoredProcedure [get_page]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_page](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_page.*,(el_page.page_directory_path + ' + '''/''' + ' + el_page.page_physical_name) as page_physical_path,el_site_style.site_style_name,(el_site_style.site_style_directory_path + ' + '''/''' + ' + el_site_style.site_style_physical_name) as site_style_physical_path, el_site_template.site_template_name,(el_site_template.site_template_directory_path + ' + '''/''' + ' + el_site_template.site_template_physical_name) as site_template_physical_path, el_user.user_site_name from el_page 
left join el_site_style on el_page.site_style_id = el_site_style.site_style_id
left join el_site_template on el_page.site_template_id = el_site_template.site_template_id
left join el_user on el_page.user_id = el_user.user_id
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_page_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_page_access_show](@page_id int) as
begin

select el_page_access_show.* from el_page_access_show
where el_page_access_show.page_id = @page_id

end
GO
/****** Object:  StoredProcedure [get_page_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_page_count] as
begin

select COUNT(el_page.page_id) as page_count from el_page

end
GO
/****** Object:  StoredProcedure [get_page_global_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_page_global_name](@page_id int) as
begin

select el_page.page_global_name from el_page
where el_page.page_id = @page_id

end
GO
/****** Object:  StoredProcedure [get_page_id_by_page_directory_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_page_id_by_page_directory_path](@page_directory_path nvarchar(800)) as
begin

select el_page.page_id from el_page
where el_page.page_directory_path = @page_directory_path

end
GO
/****** Object:  StoredProcedure [get_page_id_by_page_global_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_page_id_by_page_global_name](@page_global_name nvarchar(50)) as
begin

select el_page.page_id from el_page
where el_page.page_global_name = @page_global_name

end
GO
/****** Object:  StoredProcedure [get_page_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_page_list] as
begin

select el_page.page_id,el_page.page_global_name,el_page.page_name  from  el_page

end
GO
/****** Object:  StoredProcedure [get_page_list_by_site_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_page_list_by_site_id](@site_id int, @group_id int) as
begin

select el_page.*,(el_page.page_directory_path + '/' + el_page.page_physical_name) as page_physical_path,el_user.user_site_name from el_page
left join el_user on el_page.user_id = el_user.user_id
where el_page.page_active = 1
and el_page.page_show_link_in_site = 1
and ((el_page.page_public_access_show = 1) or (EXISTS(select el_page_access_show.page_access_show_id  from  el_page_access_show left join el_role on el_role.role_id = el_page_access_show.role_id join el_group_role on el_group_role.role_id = el_page_access_show.role_id where el_page_access_show.page_id = el_page.page_id and el_group_role.group_id = @group_id and el_role.role_active = 1)))
and ((el_page.page_public_site = 1) or (EXISTS(select el_site_page.site_page_id from  el_site_page where el_site_page.page_id = el_page.page_id and el_site_page.site_id = @site_id)))

end
GO
/****** Object:  StoredProcedure [get_page_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_page_name](@page_id int) as
begin

select el_page.page_name from el_page
where el_page.page_id = @page_id

end
GO
/****** Object:  StoredProcedure [get_page_name_and_global_name_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_page_name_and_global_name_list] as
begin

select el_page.page_name,el_page.page_global_name from el_page

end
GO
/****** Object:  StoredProcedure [get_page_site]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_page_site](@page_id int) as
begin

select el_site_page.* from el_site_page
where el_site_page.page_id = @page_id

end
GO
/****** Object:  StoredProcedure [get_page_title_by_page_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_page_title_by_page_id](@page_id int) as
begin

select el_page.page_title from el_page
where el_page.page_id = @page_id

end
GO
/****** Object:  StoredProcedure [get_parent_category]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_parent_category](@category_id int) as
begin

select el_category.parent_category,el_category.category_name from el_category 
where el_category.category_id = @category_id

end
GO
/****** Object:  StoredProcedure [get_patch]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_patch](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_patch.* from el_patch
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_patch_id_by_patch_directory_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_patch_id_by_patch_directory_path](@patch_directory_path nvarchar(800)) as
begin

select el_patch.patch_id from el_patch
where el_patch.patch_directory_path = @patch_directory_path

end
GO
/****** Object:  StoredProcedure [get_patch_id_by_patch_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_patch_id_by_patch_name](@patch_name nvarchar(50)) as
begin

select el_patch.patch_id from el_patch
where el_patch.patch_name = @patch_name

end
GO
/****** Object:  StoredProcedure [get_plugin]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_plugin.*,(el_plugin.plugin_directory_path + ' + '''/''' + ' + el_plugin.plugin_physical_name) as plugin_physical_path from el_plugin
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_plugin_access_add]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin_access_add](@plugin_id int) as
begin

select el_plugin_role_access.* from el_plugin_role_access
where el_plugin_role_access.plugin_id = @plugin_id
and el_plugin_role_access.plugin_add = 1

end
GO
/****** Object:  StoredProcedure [get_plugin_access_delete_all]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin_access_delete_all](@plugin_id int) as
begin

select el_plugin_role_access.* from el_plugin_role_access
where el_plugin_role_access.plugin_id = @plugin_id
and el_plugin_role_access.plugin_delete_all = 1

end
GO
/****** Object:  StoredProcedure [get_plugin_access_delete_own]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin_access_delete_own](@plugin_id int) as
begin

select el_plugin_role_access.* from el_plugin_role_access
where el_plugin_role_access.plugin_id = @plugin_id
and el_plugin_role_access.plugin_delete_own = 1

end
GO
/****** Object:  StoredProcedure [get_plugin_access_edit_all]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin_access_edit_all](@plugin_id int) as
begin

select el_plugin_role_access.* from el_plugin_role_access
where el_plugin_role_access.plugin_id = @plugin_id
and el_plugin_role_access.plugin_edit_all = 1

end
GO
/****** Object:  StoredProcedure [get_plugin_access_edit_own]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin_access_edit_own](@plugin_id int) as
begin

select el_plugin_role_access.* from el_plugin_role_access
where el_plugin_role_access.plugin_id = @plugin_id
and el_plugin_role_access.plugin_edit_own = 1

end
GO
/****** Object:  StoredProcedure [get_plugin_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin_access_show](@plugin_id int) as
begin

select el_plugin_role_access.* from el_plugin_role_access
where el_plugin_role_access.plugin_id = @plugin_id
and el_plugin_role_access.plugin_show = 1

end
GO
/****** Object:  StoredProcedure [get_plugin_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin_count] as
begin

select COUNT(el_plugin.plugin_id) as plugin_count from el_plugin

end
GO
/****** Object:  StoredProcedure [get_plugin_id_by_plugin_directory_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin_id_by_plugin_directory_path](@plugin_directory_path nvarchar(800)) as
begin

select el_plugin.plugin_id from el_plugin
where el_plugin.plugin_directory_path = @plugin_directory_path

end
GO
/****** Object:  StoredProcedure [get_plugin_id_by_plugin_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin_id_by_plugin_name](@plugin_name nvarchar(50)) as
begin

select el_plugin.plugin_id from el_plugin
where el_plugin.plugin_name = @plugin_name

end
GO
/****** Object:  StoredProcedure [get_plugin_menu]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin_menu](@plugin_id int) as
begin

select el_menu_plugin.* from el_menu_plugin
where el_menu_plugin.plugin_id = @plugin_id

end
GO
/****** Object:  StoredProcedure [get_plugin_role_access]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin_role_access](@plugin_id int) as
begin

select el_plugin_role_access.* from el_plugin_role_access
where el_plugin_role_access.plugin_id = @plugin_id

end
GO
/****** Object:  StoredProcedure [get_plugin_role_access_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin_role_access_check](@plugin_id int, @role_id int) as
begin

declare @tmp_el_plugin table(plugin_access_show int, plugin_access_add int, plugin_access_edit_own int, plugin_access_delete_own int, plugin_access_edit_all int, plugin_access_delete_all int)

insert into @tmp_el_plugin
select el_plugin.plugin_public_access_show,
el_plugin.plugin_public_access_add,
el_plugin.plugin_public_access_edit_own,
el_plugin.plugin_public_access_delete_own,
el_plugin.plugin_public_access_edit_all,
el_plugin.plugin_public_access_delete_all
from el_plugin
where el_plugin.plugin_id = @plugin_id

if exists(select * from el_plugin_role_access
	left join el_role on el_role.role_id = el_plugin_role_access.role_id
	where el_plugin_role_access.plugin_id = @plugin_id
	and el_plugin_role_access.role_id = @role_id
	and el_role.role_active = 1)
	begin
		insert into @tmp_el_plugin
		select  el_plugin_role_access.plugin_show,
		el_plugin_role_access.plugin_add,
		el_plugin_role_access.plugin_edit_own,
		el_plugin_role_access.plugin_delete_own,
		el_plugin_role_access.plugin_edit_all,
		el_plugin_role_access.plugin_delete_all
		from el_plugin_role_access
		left join el_role on el_role.role_id = el_plugin_role_access.role_id
		where el_plugin_role_access.plugin_id = @plugin_id
		and el_plugin_role_access.role_id = @role_id
		and el_role.role_active = 1
	end

select cast(sum(plugin_access_show) as bit) as plugin_access_show,
cast(sum(plugin_access_add) as bit) as plugin_access_add,
cast(sum(plugin_access_edit_own) as bit) as plugin_access_edit_own,
cast(sum(plugin_access_delete_own) as bit) as plugin_access_delete_own,
cast(sum(plugin_access_edit_all) as bit) as plugin_access_edit_all,
cast(sum(plugin_access_delete_all) as bit) as plugin_access_delete_all
from @tmp_el_plugin

end
GO
/****** Object:  StoredProcedure [get_plugin_role_access_check_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_plugin_role_access_check_by_group_id](@plugin_id int, @group_id int) as
begin

declare @tmp_el_plugin table(plugin_access_show int, plugin_access_add int, plugin_access_edit_own int, plugin_access_delete_own int, plugin_access_edit_all int, plugin_access_delete_all int)

insert into @tmp_el_plugin
select
el_plugin.plugin_public_access_show,
el_plugin.plugin_public_access_add,
el_plugin.plugin_public_access_edit_own,
el_plugin.plugin_public_access_delete_own,
el_plugin.plugin_public_access_edit_all,
el_plugin.plugin_public_access_delete_all
from el_plugin
where el_plugin.plugin_id = @plugin_id

if exists(select * from el_plugin_role_access
	join el_group_role on el_group_role.role_id = el_plugin_role_access.role_id
	where el_plugin_role_access.plugin_id = @plugin_id
	and el_group_role.group_id = @group_id)
	begin
		insert into @tmp_el_plugin
		select
		el_plugin_role_access.plugin_show,
		el_plugin_role_access.plugin_add,
		el_plugin_role_access.plugin_edit_own,
		el_plugin_role_access.plugin_delete_own,
		el_plugin_role_access.plugin_edit_all,
		el_plugin_role_access.plugin_delete_all
		from el_plugin_role_access
		join el_group_role on el_group_role.role_id = el_plugin_role_access.role_id
		where el_plugin_role_access.plugin_id = @plugin_id
		and el_group_role.group_id = @group_id
	end

select
cast(sum(plugin_access_show) as bit) as plugin_access_show,
cast(sum(plugin_access_add) as bit) as plugin_access_add,
cast(sum(plugin_access_edit_own) as bit) as plugin_access_edit_own,
cast(sum(plugin_access_delete_own) as bit) as plugin_access_delete_own,
cast(sum(plugin_access_edit_all) as bit) as plugin_access_edit_all,
cast(sum(plugin_access_delete_all) as bit) as plugin_access_delete_all
from @tmp_el_plugin

end
GO
/****** Object:  StoredProcedure [get_protection_attachment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_protection_attachment](@attachment_id int,@attachment_password nvarchar(50)) as
begin

select el_attachment.* from el_attachment
where el_attachment.attachment_id = @attachment_id
and  el_attachment.attachment_password = @attachment_password

end
GO
/****** Object:  StoredProcedure [get_protection_content]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_protection_content](@content_id int,@content_password nvarchar(50)) as
begin

select el_content.content_text from el_content
where el_content.content_id = @content_id
and  el_content.content_password = @content_password

end
GO
/****** Object:  StoredProcedure [get_role]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_role](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_role.* from el_role
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_role_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_role_count] as
begin

select COUNT(el_role.role_id) as role_count from el_role

end
GO
/****** Object:  StoredProcedure [get_role_id_and_name_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_role_id_and_name_by_group_id](@group_id int) as
begin

select el_role.role_id, el_role.role_name from el_role
left join el_group_role on el_group_role.role_id = el_role.role_id
where el_group_role.group_id = @group_id

end
GO
/****** Object:  StoredProcedure [get_role_id_by_role_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_role_id_by_role_name](@role_name nvarchar(50)) as
begin

select el_role.role_id from el_role
where el_role.role_name = @role_name

end
GO
/****** Object:  StoredProcedure [get_role_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_role_list] as
begin

select el_role.role_id,el_role.role_name,el_role.role_active from el_role

end
GO
/****** Object:  StoredProcedure [get_role_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_role_name](@role_id int) as
begin

select el_role.role_name from el_role
where el_role.role_id = @role_id

end
GO
/****** Object:  StoredProcedure [get_row_by_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [get_row_by_id](@table_name nvarchar(200), @column_key_name nvarchar(200), @column_key_value int) as
begin

exec('select * from ' + @table_name + ' where ' + @column_key_name + ' = ''' + @column_key_value + '''')

end
GO
/****** Object:  StoredProcedure [get_row_by_key_value]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [get_row_by_key_value](@table_name nvarchar(200), @column_key_name nvarchar(200), @column_key_value int) as
begin

exec('select * from ' + @table_name + ' where ' + @column_key_name + ' = ''' + @column_key_value + '''')

end
GO
/****** Object:  StoredProcedure [get_site]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_site.*,el_page.page_global_name,el_page.page_name,el_language.language_global_name,el_language.language_name,el_site_style.site_style_name,(el_site_style.site_style_directory_path + ' + '''/''' + ' + el_site_style.site_style_physical_name) as site_style_physical_path, el_site_template.site_template_name,(el_site_template.site_template_directory_path + ' + '''/''' + ' + el_site_template.site_template_physical_name) as site_template_physical_path,el_admin_style.admin_style_name,(el_admin_style.admin_style_directory_path + ' + '''/''' + ' + el_admin_style.admin_style_physical_name) as admin_style_physical_path,el_admin_template.admin_template_name,(el_admin_template.admin_template_directory_path + ' + '''/''' + ' + el_admin_template.admin_template_physical_name) as admin_template_physical_path from el_site 
left join el_page on el_site.page_id = el_page.page_id
left join el_language on el_site.language_id = el_language.language_id
left join el_site_style on el_site.site_style_id = el_site_style.site_style_id
left join el_admin_style on el_site.admin_style_id = el_admin_style.admin_style_id
left join el_site_template on el_site.site_template_id = el_site_template.site_template_id
left join el_admin_template on el_site.admin_template_id = el_admin_template.admin_template_id
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_site_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_access_show](@site_id int) as
begin

select el_site_access_show.* from el_site_access_show
where el_site_access_show.site_id = @site_id

end
GO
/****** Object:  StoredProcedure [get_site_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_count] as
begin

select COUNT(el_site.site_id) as site_count from el_site

end
GO
/****** Object:  StoredProcedure [get_site_date_create]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_date_create](@site_id int) as
begin 

select site_date_create from el_site
where site_id = @site_id

end
GO
/****** Object:  StoredProcedure [get_site_default_page]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_default_page](@site_id int) as
begin

select el_site.page_id from el_site
where el_site.site_id = @site_id

end
GO
/****** Object:  StoredProcedure [get_site_global_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_global_name](@site_id int) as
begin

select el_site.site_global_name from el_site
where el_site.site_id = @site_id

end
GO
/****** Object:  StoredProcedure [get_site_id_by_site_global_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_id_by_site_global_name](@site_global_name varchar(50)) as
begin

select el_site.site_id from el_site
where el_site.site_global_name = @site_global_name

end
GO
/****** Object:  StoredProcedure [get_site_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_list] as
begin

select el_site.site_id,el_site.site_global_name,el_site.site_name  from  el_site

end
GO
/****** Object:  StoredProcedure [get_site_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_name](@site_id int) as
begin

select el_site.site_name from el_site
where el_site.site_id = @site_id

end
GO
/****** Object:  StoredProcedure [get_site_name_and_global_name_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_name_and_global_name_list] as
begin

select el_site.site_name,el_site.site_global_name from el_site

end
GO
/****** Object:  StoredProcedure [get_site_name_by_site_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_name_by_site_id](@site_id int) as
begin

select el_site.site_name from el_site
where el_site.site_id = @site_id

end
GO
/****** Object:  StoredProcedure [get_site_style]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_style](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_site_style.*,(el_site_style.site_style_directory_path + ' + '''/''' + ' + el_site_style.site_style_physical_name) as site_style_physical_path from el_site_style
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_site_style_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_style_count] as
begin

select COUNT(el_site_style.site_style_id) as site_style_count from el_site_style

end
GO
/****** Object:  StoredProcedure [get_site_style_directory_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_style_directory_path](@site_style_id int) as
begin

select site_style_directory_path from el_site_style
where site_style_id = @site_style_id

end
GO
/****** Object:  StoredProcedure [get_site_style_id_by_site_style_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_style_id_by_site_style_name](@site_style_name nvarchar(50)) as
begin

select el_site_style.site_style_id from el_site_style
where el_site_style.site_style_name = @site_style_name

end
GO
/****** Object:  StoredProcedure [get_site_style_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_style_list] as
begin

select el_site_style.* from el_site_style

end
GO
/****** Object:  StoredProcedure [get_site_style_physical_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_style_physical_path](@site_style_id int) as
begin

select (el_site_style.site_style_directory_path + '/' + el_site_style.site_style_physical_name) site_style_physical_path from el_site_style
where site_style_id = @site_style_id

end
GO
/****** Object:  StoredProcedure [get_site_template]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_template](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin 

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_site_template.*,(el_site_template.site_template_directory_path + ' + '''/''' + ' + el_site_template.site_template_physical_name) as site_template_physical_path from el_site_template
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_site_template_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_template_count] as
begin

select COUNT(el_site_template.site_template_id) as site_template_count from el_site_template

end
GO
/****** Object:  StoredProcedure [get_site_template_id_by_site_template_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_template_id_by_site_template_name](@site_template_name nvarchar(50)) as
begin

select el_site_template.site_template_id from el_site_template
where el_site_template.site_template_name = @site_template_name

end
GO
/****** Object:  StoredProcedure [get_site_template_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_template_list] as
begin

select el_site_template.* from el_site_template

end
GO
/****** Object:  StoredProcedure [get_site_template_physical_path]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_site_template_physical_path](@site_template_id int) as
begin

select (el_site_template.site_template_directory_path + '/' + el_site_template.site_template_physical_name) site_template_physical_path from el_site_template
where site_template_id = @site_template_id

end
GO
/****** Object:  StoredProcedure [get_sorted_attachment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_sorted_attachment](@column_name nvarchar(200),@sort_type nvarchar(200)) as
begin

exec('select el_attachment.*,el_content.content_title from el_attachment left join el_content on el_attachment.content_id = el_content.content_id order by ' + @column_name + ' ' + @sort_type )

end
GO
/****** Object:  StoredProcedure [get_system_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_system_list] as
begin

select distinct(el_component.component_category) as system_name from el_component
order by el_component.component_category asc

end
GO
/****** Object:  StoredProcedure [get_three_last_content_category_date]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_three_last_content_category_date](@category_id int) as
begin

select top(3) el_content.content_date_create from el_content where el_content.category_id = @category_id order by el_content.content_date_create desc

end
GO
/****** Object:  StoredProcedure [get_today_active_content_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_today_active_content_count](@content_date_create char(10)) as
begin

select COUNT(el_content.content_id) as today_active_content_count from el_content
where el_content.content_status = 'active'
and el_content.content_date_create = @content_date_create

end
GO
/****** Object:  StoredProcedure [get_today_comment_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_today_comment_count](@comment_date_send char(10)) as
begin

select COUNT(el_comment.comment_id) as today_comment_count from el_comment
where el_comment.comment_date_send = @comment_date_send

end
GO
/****** Object:  StoredProcedure [get_today_contact_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_today_contact_count](@contact_date_send char(10)) as
begin

select COUNT(el_contact.contact_id) as today_contact_count from el_contact
where el_contact.contact_date_send = @contact_date_send

end
GO
/****** Object:  StoredProcedure [get_today_content_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_today_content_count](@content_date_create char(10)) as
begin

select COUNT(el_content.content_id) as today_content_count from el_content
where el_content.content_date_create = @content_date_create

end
GO
/****** Object:  StoredProcedure [get_today_draft_content_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_today_draft_content_count](@date_create char(10)) as
begin

declare @content_status varchar(20) = 'draft'
select COUNT(el_content.content_id) as today_draft_content_count from el_content where el_content.content_status = @content_status and el_content.content_date_create = @date_create

end
GO
/****** Object:  StoredProcedure [get_today_foot_print_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_today_foot_print_count](@foot_print_date_action char(10)) as
begin

select count(el_foot_print.user_id) as today_foot_print_count from el_foot_print
where el_foot_print.foot_print_date_action = @foot_print_date_action

end
GO
/****** Object:  StoredProcedure [get_today_inactive_content_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_today_inactive_content_count](@content_date_create char(10)) as
begin

select COUNT(el_content.content_id) as today_inactive_content_count from el_content
where el_content.content_status = 'inactive'
and el_content.content_date_create = @content_date_create

end
GO
/****** Object:  StoredProcedure [get_today_new_user_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_today_new_user_count](@user_date_create char(10)) as
begin

select COUNT(el_user.user_id) as today_user_count from el_user
where el_user.user_date_create = @user_date_create

end
GO
/****** Object:  StoredProcedure [get_today_visit_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_today_visit_count](@visit_statistics_date_visit char(10)) as
begin

select sum(el_visit_statistics.visit_statistics_visit) as today_visit_count from el_visit_statistics
where el_visit_statistics.visit_statistics_date_visit = @visit_statistics_date_visit

end
GO
/****** Object:  StoredProcedure [get_trash_content_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_trash_content_count] as
begin

select COUNT(el_content.content_id) as trash_content_count from el_content
where el_content.content_status = 'trash'

end
GO
/****** Object:  StoredProcedure [get_user]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_user.*,DATEDIFF(hour,el_user.user_birthday,GETDATE())/8766 as user_age, el_group.group_name,
el_admin_style.admin_style_name,el_admin_template.admin_template_name,el_site_style.site_style_name,el_site_template.site_template_name,
(SELECT COUNT(el_content.user_id) FROM el_content) as number_of_content,
(select COUNT(el_comment.user_id) FROM el_comment) as number_of_comment 
from el_user
left join el_group on el_user.group_id = el_group.group_id
left join el_admin_style on el_user.admin_style_id = el_admin_style.admin_style_id
left join el_admin_template on el_user.admin_template_id = el_admin_template.admin_template_id
left join el_site_style on el_user.site_style_id = el_site_style.site_style_id
left join el_site_template on el_user.site_template_id = el_site_template.site_template_id
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_user_attachment_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_attachment_count](@user_id int) as
begin

select COUNT(el_attachment.attachment_id) as user_attachment_count from el_attachment
where el_attachment.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [get_user_attachment_size_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_attachment_size_list](@user_id int) as
begin

select el_attachment.attachment_size from el_attachment
where el_attachment.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [get_user_comment_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_comment_count](@user_id int) as
begin

select COUNT(el_comment.comment_id) as user_comment_count from el_comment
where el_comment.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [get_user_contact_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_contact_count](@user_id int) as
begin

select COUNT(el_contact.contact_id) as user_contact_count from el_contact
where el_contact.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [get_user_content_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_content_count](@user_id int) as
begin

select COUNT(el_content.content_id) as user_content_count from el_content
where el_content.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [get_user_content_reply_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_content_reply_count](@user_id int) as
begin

select COUNT(el_content_reply.content_reply_id) as user_content_reply_count from el_content_reply
where el_content_reply.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [get_user_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_count] as
begin

select COUNT(el_user.user_id) as user_count from el_user

end
GO
/****** Object:  StoredProcedure [get_user_email]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [get_user_email](@user_id int) as
begin

select el_user.user_email from el_user
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [get_user_id_by_user_name_or_user_email]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_id_by_user_name_or_user_email](@user_name_or_user_email nvarchar(50)) as
begin
 
select el_user.user_id, el_user.user_name, el_user.user_email from el_user
where el_user.user_name = @user_name_or_user_email or el_user.user_email = @user_name_or_user_email

end
GO
/****** Object:  StoredProcedure [get_user_id_by_user_site_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [get_user_id_by_user_site_name](@user_site_name nvarchar(50)) as
begin

select el_user.user_id from el_user
where el_user.user_site_name = @user_site_name

end
GO
/****** Object:  StoredProcedure [get_user_info]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_info](@user_id int) as
begin
 
select el_user.*,DATEDIFF(hour,el_user.user_birthday,GETDATE())/8766 as user_age,el_group.group_name ,
(SELECT COUNT(el_content.user_id) FROM el_content WHERE el_content.user_id = @user_id) as user_content_count,
(select COUNT(el_comment.user_id) FROM el_comment WHERE el_comment.user_id = @user_id) as user_comment_count,
(((select COUNT(el_content.user_id) FROM el_content where el_content.user_id = @user_id) * 100) / (select COUNT(el_content.user_id) FROM el_content)) as user_percent_of_content,
el_site_style.site_style_name,el_site_template.site_template_name,el_admin_style.admin_style_name,el_admin_template.admin_template_name

from el_user
left join el_content on el_user.user_id = (el_content.user_id)
left join el_comment on el_user.user_id = el_comment.user_id
left join el_group on el_group.group_id = el_user.group_id
left join el_site_style on el_user.site_style_id = el_site_style.site_style_id
left join el_site_template on el_user.site_template_id = el_site_template.site_template_id
left join el_admin_style on el_user.admin_style_id = el_admin_style.admin_style_id
left join el_admin_template on el_user.admin_template_id = el_admin_template.admin_template_id
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [get_user_list]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_list] as
begin

select el_user.*,DATEDIFF(hour,el_user.user_birthday,GETDATE())/8766 as user_age, el_group.group_name,
el_admin_style.admin_style_name,el_admin_template.admin_template_name,el_site_style.site_style_name,el_site_template.site_template_name,
(select COUNT(el_content.user_id) from el_content) as number_of_content,
(select COUNT(el_comment.user_id) from el_comment) as number_of_comment 
from el_user
left join el_group on el_user.group_id = el_group.group_id
left join el_admin_style on el_user.admin_style_id = el_admin_style.admin_style_id
left join el_admin_template on el_user.admin_template_id = el_admin_template.admin_template_id
left join el_site_style on el_user.site_style_id = el_site_style.site_style_id
left join el_site_template on el_user.site_template_id = el_site_template.site_template_id

end
GO
/****** Object:  StoredProcedure [get_user_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_name](@user_id int) as
begin

select el_user.user_name from el_user
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [get_user_setting]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_setting](@user_id int) as
begin 

select el_user.user_id,
el_user.user_name,
el_user.user_site_name,
el_user.group_id,
el_user.site_style_id,
el_user.site_template_id,
el_user.admin_style_id,
el_user.admin_template_id,
el_user.site_language_id,
el_user.admin_language_id,
el_user.user_calendar,
el_user.user_first_day_of_week,
el_user.user_time_zone,
el_user.user_date_format,
el_user.user_time_format,
el_user.user_day_difference,
el_user.user_time_hours_difference,
el_user.user_time_minutes_difference,
el_group.group_name,
(select el_language.language_global_name from el_language where el_language.language_id = el_user.site_language_id) as site_language_global_name,
(select el_language.language_global_name from el_language where el_language.language_id = el_user.admin_language_id) as admin_language_global_name
from el_user
left join el_group on el_group.group_id = el_user.group_id
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [get_user_site_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_site_name](@user_id int) as
begin

select el_user.user_site_name from el_user
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [get_user_view]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_user_view](@user_id int) as
begin 

select user_background_color, user_font_size,user_natural_dark_text_color, user_natural_dark_background_color, user_natural_middle_text_color, user_natural_middle_background_color, user_natural_light_text_color, user_natural_light_background_color, user_common_dark_background_color, user_common_dark_text_color, user_common_middle_text_color, user_common_middle_background_color, user_common_light_text_color, user_common_light_background_color from el_user
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [get_view]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_view](@inner_attach nvarchar(max) =null,@outer_attach nvarchar(max) =null,@count int = 0,@from_number_row int = 0,@until_number_row int = 0) as
begin 

declare @top varchar(max) = ' top (' + Convert(nvarchar(max),@count) + ') '
IF @count = 0
begin
set @top = null
end

declare @between nvarchar(max) = ' where tmp.row_number between ' + Convert(nvarchar(max),@from_number_row) + ' and ' + Convert(nvarchar(max),@until_number_row) + ' '
IF @from_number_row = 0 and @until_number_row = 0
begin
set @between = null
end

exec('select' + @top + '* from(
select row_number() over(order by (select 0)) row_number,el_view.*,el_site_style.site_style_name,el_site_template.site_template_name from el_view
left join el_site_style on el_view.site_style_id = el_site_style.site_style_id
left join el_site_template on el_view.site_template_id = el_site_template.site_template_id
 ' + @inner_attach + '
) tmp ' + @between + @outer_attach)

select @@ROWCOUNT as row_count

end
GO
/****** Object:  StoredProcedure [get_view_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_view_count] as
begin

select COUNT(el_view.view_id) as view_count
from el_view

end
GO
/****** Object:  StoredProcedure [get_view_id_by_query_string]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_view_id_by_query_string](@query_string nvarchar(max)) as
begin

select * from el_view_query_string

end
GO
/****** Object:  StoredProcedure [get_view_name]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_view_name](@view_id int) as
begin

select el_view.view_name from el_view
where el_view.view_id = @view_id

end
GO
/****** Object:  StoredProcedure [get_view_query_string]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_view_query_string] as
begin
 
select el_view_query_string.*, el_view.view_name,el_view.view_match_type from el_view_query_string 
left join el_view on el_view.view_id = el_view_query_string.view_id

end
GO
/****** Object:  StoredProcedure [get_visit_count]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [get_visit_count] as
begin

select sum(el_visit_statistics.visit_statistics_visit) as visit_count from el_visit_statistics

end
GO
/****** Object:  StoredProcedure [group_active_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [group_active_check](@group_id int) as
begin

select el_group.group_active from el_group 
where el_group.group_id = @group_id

end
GO
/****** Object:  StoredProcedure [inactive_admin_style]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_admin_style](@admin_style_id int) as
begin 

update el_admin_style set admin_style_active = 0
where el_admin_style.admin_style_id = @admin_style_id

end
GO
/****** Object:  StoredProcedure [inactive_admin_template]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_admin_template](@admin_template_id int) as
begin 

update el_admin_template set admin_template_active = 0
where el_admin_template.admin_template_id = @admin_template_id

end
GO
/****** Object:  StoredProcedure [inactive_attachment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_attachment](@attachment_id int) as
begin

update el_attachment set attachment_active = 0 where el_attachment.attachment_id = @attachment_id

end
GO
/****** Object:  StoredProcedure [inactive_category]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_category](@category_id int) as
begin
 
update el_category set category_active = 0 where el_category.category_id = @category_id

end
GO
/****** Object:  StoredProcedure [inactive_comment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_comment](@comment_id int) as
begin

update el_comment set comment_active = 0 where el_comment.comment_id = @comment_id

end
GO
/****** Object:  StoredProcedure [inactive_component]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_component](@component_id int) as
begin

update el_component set component_active = 0 where el_component.component_id = @component_id

end
GO
/****** Object:  StoredProcedure [inactive_content]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_content](@content_id int) as
begin

update el_content set content_status = 'inactive'  where el_content.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [inactive_content_reply]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_content_reply](@content_reply_id int) as
begin

update el_content_reply set content_reply_active = 0 where el_content_reply.content_reply_id = @content_reply_id

end
GO
/****** Object:  StoredProcedure [inactive_editor_template]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_editor_template](@editor_template_id int) as
begin

update el_editor_template set editor_template_active = 0 where el_editor_template.editor_template_id = @editor_template_id

end
GO
/****** Object:  StoredProcedure [inactive_extra_helper]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_extra_helper](@extra_helper_id int) as
begin

update el_extra_helper set extra_helper_active = 0 where el_extra_helper.extra_helper_id = @extra_helper_id

end
GO
/****** Object:  StoredProcedure [inactive_fetch]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_fetch](@fetch_id int) as
begin

update el_fetch set fetch_active = 0 where el_fetch.fetch_id = @fetch_id

end
GO
/****** Object:  StoredProcedure [inactive_group]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [inactive_group](@group_id int) as
begin
 
update el_group set group_active = 0 where el_group.group_id = @group_id

end
GO
/****** Object:  StoredProcedure [inactive_item]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_item](@item_id int) as
begin

update el_item set item_active = 0 where el_item.item_id = @item_id

end
GO
/****** Object:  StoredProcedure [inactive_language]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_language](@language_id int) as
begin

update el_language set language_active = 0 where el_language.language_id = @language_id

end
GO
/****** Object:  StoredProcedure [inactive_link]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_link](@link_id int) as
begin

update el_link set link_active = 0 where el_link.link_id = @link_id

end
GO
/****** Object:  StoredProcedure [inactive_menu]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_menu](@menu_id int) as
begin

update el_menu set menu_active = 0 where el_menu.menu_id = @menu_id

end
GO
/****** Object:  StoredProcedure [inactive_module]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_module](@module_id int) as
begin

update el_module set module_active = 0 where el_module.module_id = @module_id

end
GO
/****** Object:  StoredProcedure [inactive_page]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_page](@page_id int) as
begin

update el_page set page_active = 0 where el_page.page_id = @page_id

end
GO
/****** Object:  StoredProcedure [inactive_patch]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [inactive_patch](@patch_id int) as
begin

update el_patch set patch_active = 0 where el_patch.patch_id = @patch_id

end
GO
/****** Object:  StoredProcedure [inactive_plugin]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_plugin](@plugin_id int) as
begin

update el_plugin set plugin_active = 0 where el_plugin.plugin_id = @plugin_id

end
GO
/****** Object:  StoredProcedure [inactive_role]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_role](@role_id int) as
begin

update el_role set role_active = 0 where el_role.role_id = @role_id

end
GO
/****** Object:  StoredProcedure [inactive_site]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_site](@site_id int) as
begin

update el_site set site_active = 0 where el_site.site_id = @site_id

end
GO
/****** Object:  StoredProcedure [inactive_site_style]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_site_style](@site_style_id int) as
begin 

update el_site_style set site_style_active = 0
where el_site_style.site_style_id = @site_style_id

end
GO
/****** Object:  StoredProcedure [inactive_site_template]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_site_template](@site_template_id int) as
begin 

update el_site_template set site_template_active = 0
where el_site_template.site_template_id = @site_template_id

end
GO
/****** Object:  StoredProcedure [inactive_user]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_user](@user_id int) as
begin

update el_user set user_active = 0 where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [inactive_view]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [inactive_view](@view_id int) as
begin

update el_view set view_active = 0
where el_view.view_id = @view_id

end
GO
/****** Object:  StoredProcedure [increase_attachment_visit]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [increase_attachment_visit](@attachment_id int) as
begin

update el_attachment set attachment_number_of_visit = attachment_number_of_visit + 1
where el_attachment.attachment_id = @attachment_id

end
GO
/****** Object:  StoredProcedure [increase_content_visit]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [increase_content_visit](@content_id int) as
begin

update el_content set content_visit = content_visit + 1 where el_content.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [increase_page_visit]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [increase_page_visit](@page_id int) as
begin

update el_page set page_visit = page_visit + 1 where el_page.page_id = @page_id

end
GO
/****** Object:  StoredProcedure [increase_site_visit]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [increase_site_visit](@site_id int) as
begin

update el_site set site_visit = site_visit + 1 where el_site.site_id = @site_id

end
GO
/****** Object:  StoredProcedure [increase_user_upload]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [increase_user_upload](@user_id int, @file_size varchar(13)) as
begin

declare @tmp_size_of_upload bigint = convert(bigint, (select el_user.user_size_of_upload from el_user))
declare @tmp_file_size bigint = convert(bigint, @file_size)
declare @new_size_of_upload bigint = @tmp_size_of_upload + @tmp_file_size

update el_user set
user_size_of_upload = convert(varchar(13), @new_size_of_upload),
user_number_of_upload = user_number_of_upload + 1
where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [increase_visit_statistics]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [increase_visit_statistics](@date_visit char(10)) as
BEGIN 

if (select visit_statistics_id from el_visit_statistics where visit_statistics_date_visit = @date_visit) > 0
	update el_visit_statistics set visit_statistics_visit = visit_statistics_visit + 1 where visit_statistics_date_visit = cast(@date_visit as char(10))
else
	insert into el_visit_statistics (visit_statistics_date_visit,visit_statistics_visit) values (@date_visit,1)

end
GO
/****** Object:  StoredProcedure [is_user_attachment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [is_user_attachment](@user_id int, @attachment_id int) as
begin

declare @is_user_attachment bit = (select COUNT(*) from el_attachment where el_attachment.attachment_id = @attachment_id and el_attachment.user_id = @user_id)

select @is_user_attachment as is_user_attachment

end
GO
/****** Object:  StoredProcedure [is_user_comment]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [is_user_comment](@user_id int, @comment_id int) as
begin

declare @is_user_comment bit = (select COUNT(*) from el_comment where el_comment.comment_id = @comment_id and el_comment.user_id = @user_id)

select @is_user_comment as is_user_comment

end
GO
/****** Object:  StoredProcedure [is_user_contact]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [is_user_contact](@user_id int, @contact_id int) as
begin

declare @is_user_contact bit = (select COUNT(*) from el_contact where el_contact.contact_id = @contact_id and el_contact.user_id = @user_id)

select @is_user_contact as is_user_contact

end
GO
/****** Object:  StoredProcedure [is_user_content]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [is_user_content](@user_id int, @content_id int) as
begin

declare @is_user_content bit = (select COUNT(*) from el_content where el_content.content_id = @content_id and el_content.user_id = @user_id)

select @is_user_content as is_user_content

end
GO
/****** Object:  StoredProcedure [is_user_content_reply]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [is_user_content_reply](@user_id int, @content_reply_id int) as
begin

declare @is_user_content_reply bit = (select COUNT(*) from el_content_reply where el_content_reply.content_reply_id = @content_reply_id and el_content_reply.user_id = @user_id)

select @is_user_content_reply as is_user_content_reply

end
GO
/****** Object:  StoredProcedure [is_user_foot_print]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [is_user_foot_print](@user_id int, @foot_print_id int) as
begin

declare @is_user_foot_print bit = (select COUNT(*) from el_foot_print where el_foot_print.foot_print_id = @foot_print_id and el_foot_print.user_id = @user_id)

select @is_user_foot_print as is_user_foot_print

end
GO
/****** Object:  StoredProcedure [is_user_page]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [is_user_page](@user_id int, @page_id int) as
begin

declare @is_user_page bit = (select COUNT(*) from el_page where el_page.page_id = @page_id and el_page.user_id = @user_id)

select @is_user_page as is_user_page

end
GO
/****** Object:  StoredProcedure [language_global_name_to_language_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [language_global_name_to_language_id](@language_global_name varchar(50)) as
begin

select el_language.language_id from el_language where el_language.language_global_name = @language_global_name

end
GO
/****** Object:  StoredProcedure [page_access_show_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [page_access_show_check](@page_id int, @role_id int) as
begin

if ((select el_page.page_public_access_show from el_page
	where el_page.page_id = @page_id) = 1)
	begin
		select 1 as page_access_show
	end
else if exists(select * from el_page_access_show
	left join el_role on el_role.role_id = el_page_access_show.role_id
	where el_page_access_show.page_id = @page_id
	and el_page_access_show.role_id = @role_id
	and el_role.role_active = 1)
	begin
		select 1 as page_access_show
	end
else
	begin
		select 0 as page_access_show
	end

end
GO
/****** Object:  StoredProcedure [page_access_show_check_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [page_access_show_check_by_group_id](@page_id int, @group_id int) as
begin

if ((select el_page.page_public_access_show from el_page
	where el_page.page_id = @page_id) = 1)
	begin
		select 1 as page_access_show
	end
else if exists(select * from el_page_access_show
	left join el_role on el_role.role_id = el_page_access_show.role_id
	join el_group_role on el_group_role.role_id = el_page_access_show.role_id
	where el_page_access_show.page_id = @page_id
	and el_group_role.group_id = @group_id
	and el_role.role_active = 1)
	begin
		select 1 as page_access_show
	end
else
	begin
		select 0 as page_access_show
	end

end
GO
/****** Object:  StoredProcedure [restore_backup]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [restore_backup](@database_name nvarchar(max),@backup_directory_path nvarchar(max),@backup_physical_name nvarchar(max)) as
begin

DECLARE @BackupFile varchar(max)
SET @BackupFile = @backup_directory_path + @backup_physical_name

RESTORE DATABASE @database_name
FROM DISK = @BackupFile

end
GO
/****** Object:  StoredProcedure [restore_content]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [restore_content](@content_id int) as
begin

update el_content set content_status = 'active'  where el_content.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [robot_ip_is_blocked]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [robot_ip_is_blocked](@user_ip varchar(39)) as
begin

declare @robot_ip_is_blocked bit = (select COUNT(*) from el_robot_detection_ip_block where el_robot_detection_ip_block.robot_detection_ip_block_ip_address = @user_ip)

select @robot_ip_is_blocked as robot_ip_is_blocked

end
GO
/****** Object:  StoredProcedure [role_active_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [role_active_check](@role_id int) as
begin

select el_role.role_active from el_role 
where el_role.role_id = @role_id

end
GO
/****** Object:  StoredProcedure [role_active_check_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [role_active_check_by_group_id](@group_id int) as
begin

select
cast(sum(cast(el_role.role_active as int)) as bit) as role_active 

from el_role
join el_group_role on el_group_role.role_id = el_role.role_id
where el_group_role.group_id =@group_id

end
GO
/****** Object:  StoredProcedure [set_attachment_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_attachment_access_show](@attachment_id int,@role_id int) as
begin

insert into el_attachment_access_show (attachment_id,role_id) values (@attachment_id,@role_id)

end
GO
/****** Object:  StoredProcedure [set_category_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_category_access_show](@category_id int,@role_id int) as
begin

insert into el_category_access_show (category_id,role_id) values (@category_id,@role_id)

end
GO
/****** Object:  StoredProcedure [set_component_role_access]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_component_role_access](@component_id int,@role_id int,@access_show bit,@access_add bit, @access_edit_own bit, @access_delete_own bit, @access_edit_all bit, @access_delete_all bit) as
begin 

insert into el_component_role_access (component_id,role_id,component_show,component_add,component_edit_own,component_delete_own,component_edit_all,component_delete_all) 
values (@component_id,@role_id,@access_show,@access_add,@access_edit_own,@access_delete_own,@access_edit_all,@access_delete_all)

end
GO
/****** Object:  StoredProcedure [set_content_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_content_access_show](@content_id int,@role_id int) as
begin

insert into el_content_access_show (content_id,role_id) values (@content_id,@role_id)

end
GO
/****** Object:  StoredProcedure [set_content_rating]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_content_rating](@content_id int,@content_rate int) as
begin

update el_content_rating set content_rating_number_of_voted = content_rating_number_of_voted + 1,content_rating_rating = content_rating_rating + @content_rate where el_content_rating.content_id = @content_id

end
GO
/****** Object:  StoredProcedure [set_editor_template_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_editor_template_access_show](@editor_template_id int,@role_id int) as
begin

insert into el_editor_template_access_show (editor_template_id,role_id) values (@editor_template_id,@role_id)

end
GO
/****** Object:  StoredProcedure [set_extra_helper_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_extra_helper_access_show](@extra_helper_id int,@role_id int) as
begin

insert into el_extra_helper_access_show (extra_helper_id,role_id) values (@extra_helper_id,@role_id)

end
GO
/****** Object:  StoredProcedure [set_fetch_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_fetch_access_show](@fetch_id int,@role_id int) as
begin

insert into el_fetch_access_show (fetch_id,role_id) values (@fetch_id,@role_id)

end
GO
/****** Object:  StoredProcedure [set_group_role]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [set_group_role](@group_id int,@role_id int) as
begin

insert into el_group_role (group_id,role_id) values (@group_id,@role_id)

end
GO
/****** Object:  StoredProcedure [set_install_site]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_install_site](@site_time_zone float, @site_name nvarchar(50), @language_id int, @site_email nvarchar(254), @site_title nvarchar(400), @site_date_create char(10), @site_time_create char(8)) as
begin 

update el_site set
el_site.site_time_zone = @site_time_zone,
el_site.site_name = @site_name,
el_site.language_id = @language_id,
el_site.site_email = @site_email,
el_site.site_title = @site_title,
el_site.site_date_create = @site_date_create,
el_site.site_time_create = @site_time_create,
el_site.site_active = '1'
where el_site.site_global_name = 'default'
 
end
GO
/****** Object:  StoredProcedure [set_install_user]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_install_user](@user_site_name nvarchar(50), @user_name nvarchar(50), @user_real_name nvarchar(50), @user_real_last_name nvarchar(50), @user_email nvarchar(254), @user_password char(32)) as
begin 

update el_user set
el_user.user_site_name = @user_site_name,
el_user.user_name = @user_name,
el_user.user_real_name = @user_real_name,
el_user.user_real_last_name = @user_real_last_name,
el_user.user_email = @user_email,
el_user.user_password = @user_password
where el_user.user_name = 'admin'

end
GO
/****** Object:  StoredProcedure [set_item_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_item_access_show](@item_id int,@role_id int) as
begin

insert into el_item_access_show (item_id,role_id) values (@item_id,@role_id)

end
GO
/****** Object:  StoredProcedure [set_menu_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_menu_access_show](@menu_id int,@role_id int) as
begin

insert into el_menu_access_show (menu_id,role_id) values (@menu_id,@role_id)

end
GO
/****** Object:  StoredProcedure [set_module_role_access]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_module_role_access](@module_id int,@role_id int,@access_show bit,@access_add bit, @access_edit_own bit, @access_delete_own bit, @access_edit_all bit, @access_delete_all bit) as
begin

insert into el_module_role_access (module_id,role_id,module_show,module_add,module_edit_own,module_delete_own,module_edit_all,module_delete_all) 
values (@module_id,@role_id,@access_show,@access_add,@access_edit_own,@access_delete_own,@access_edit_all,@access_delete_all)

end
GO
/****** Object:  StoredProcedure [set_page_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_page_access_show](@page_id int,@role_id int) as
begin

insert into el_page_access_show (page_id,role_id) values (@page_id,@role_id)

end
GO
/****** Object:  StoredProcedure [set_page_site]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_page_site](@page_id int, @site_id int) as
begin

insert into el_site_page (page_id, site_id) values (@page_id, @site_id)

end
GO
/****** Object:  StoredProcedure [set_plugin_role_access]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_plugin_role_access](@plugin_id int,@role_id int,@access_show bit,@access_add bit, @access_edit_own bit, @access_delete_own bit, @access_edit_all bit, @access_delete_all bit) as
begin 

insert into el_plugin_role_access (plugin_id,role_id,plugin_show,plugin_add,plugin_edit_own,plugin_delete_own,plugin_edit_all,plugin_delete_all) 
values (@plugin_id,@role_id,@access_show,@access_add,@access_edit_own,@access_delete_own,@access_edit_all,@access_delete_all)

end
GO
/****** Object:  StoredProcedure [set_site_access_show]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_site_access_show](@site_id int,@role_id int) as
begin

insert into el_site_access_show (site_id,role_id) values (@site_id,@role_id)

end
GO
/****** Object:  StoredProcedure [set_user_last_login]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_user_last_login](@user_id int,@user_last_login char(19)) as
begin

update el_user set el_user.user_last_login = @user_last_login
where el_user.user_id = @user_id
 
end
GO
/****** Object:  StoredProcedure [set_user_upload]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [set_user_upload](@user_id int,@file_size float) as
begin

update el_user set el_user.user_size_of_upload = el_user.user_size_of_upload + @file_size,el_user.user_number_of_upload = el_user.user_number_of_upload + 1 where el_user.user_id = @user_id

end
GO
/****** Object:  StoredProcedure [site_access_show_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [site_access_show_check](@site_id int, @role_id int) as
begin

if ((select el_site.site_public_access_show from el_site
	where el_site.site_id = @site_id) = 1)
	begin
		select 1 as site_access_show
	end
else if exists(select * from el_site_access_show
	left join el_role on el_role.role_id = el_site_access_show.role_id
	where el_site_access_show.site_id = @site_id
	and el_site_access_show.role_id = @role_id
	and el_role.role_active = 1)
	begin
		select 1 as site_access_show
	end
else
	begin
		select 0 as site_access_show
	end

end
GO
/****** Object:  StoredProcedure [site_access_show_check_by_group_id]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [site_access_show_check_by_group_id](@site_id int, @group_id int) as
begin

if ((select el_site.site_public_access_show from el_site
	where el_site.site_id = @site_id) = 1)
	begin
		select 1 as site_access_show
	end
else if exists(select * from el_site_access_show
	left join el_role on el_role.role_id = el_site_access_show.role_id
	join el_group_role on el_group_role.role_id = el_site_access_show.role_id
	where el_site_access_show.site_id = @site_id
	and el_group_role.group_id = @group_id
	and el_role.role_active = 1)
	begin
		select 1 as site_access_show
	end
else
	begin
		select 0 as site_access_show
	end

end
GO
/****** Object:  StoredProcedure [start_backup]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [start_backup](@database_name nvarchar(max),@backup_directory_path nvarchar(max),@backup_physical_name nvarchar(max)) as
-- the original database (use 'SET @DB = NULL' to disable backup)
DECLARE @DB varchar(200)
SET @DB = @database_name

-- the backup filename
DECLARE @BackupFile varchar(max)
SET @BackupFile = @backup_directory_path + @backup_physical_name

-- the new database name
DECLARE @NewNameDB varchar(200)
SET @NewNameDB = @database_name

DECLARE @RestoreFile varchar(2000)
SET @RestoreFile = @backup_directory_path



DECLARE @query varchar(2000)

DECLARE @DataFile varchar(2000)
SET @DataFile = @RestoreFile + '.mdf'

DECLARE @LogFile varchar(2000)
SET @LogFile = @RestoreFile + '.ldf'

IF @DB IS NOT NULL
BEGIN
    SET @query = 'BACKUP DATABASE ' + @DB + ' TO DISK = ' + QUOTENAME(@BackupFile, '''')
    EXEC (@query)
END

IF EXISTS(SELECT * FROM sysdatabases WHERE name = @NewNameDB)
BEGIN
    SET @query = 'DROP DATABASE ' + @NewNameDB
    EXEC (@query)
END

RESTORE HEADERONLY FROM DISK = @BackupFile
DECLARE @File int
SET @File = @@ROWCOUNT

DECLARE @Data varchar(500)
DECLARE @Log varchar(500)

SET @query = 'RESTORE FILELISTONLY FROM DISK = ' + QUOTENAME(@BackupFile , '''')

CREATE TABLE #restoretemp
(
 LogicalName varchar(500),
 PhysicalName varchar(500),
 type varchar(10),
 FilegroupName varchar(200),
 size int,
 maxsize bigint
)
INSERT #restoretemp EXEC (@query)

SELECT @Data = LogicalName FROM #restoretemp WHERE type = 'D'
SELECT @Log = LogicalName FROM #restoretemp WHERE type = 'L'

PRINT @Data
PRINT @Log

TRUNCATE TABLE #restoretemp
DROP TABLE #restoretemp

IF @File > 0
BEGIN
    SET @query = 'RESTORE DATABASE ' + @NewNameDB + ' FROM DISK = ' + QUOTENAME(@BackupFile, '''') + 
        ' WITH MOVE ' + QUOTENAME(@Data, '''') + ' TO ' + QUOTENAME(@DataFile, '''') + ', MOVE ' +
        QUOTENAME(@Log, '''') + ' TO ' + QUOTENAME(@LogFile, '''') + ', FILE = ' + CONVERT(varchar, @File)
    EXEC (@query)
END
GO
/****** Object:  StoredProcedure [user_login_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [user_login_check](@user_name_or_user_email nvarchar(50),@password char(32)) as
begin

select el_user.user_id from el_user
where (el_user.user_name = @user_name_or_user_email or el_user.user_email = @user_name_or_user_email) and el_user.user_password = @password 

end
GO
/****** Object:  StoredProcedure [user_name_exist_check]    Script Date: 2023-09-01 6:01:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [user_name_exist_check](@user_name nvarchar(30)) as
begin

select COUNT(*) as user_name_count from el_user where user_name = @user_name

end
GO
