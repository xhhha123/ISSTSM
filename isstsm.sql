USE [master]
GO
/****** Object:  Database [ISSTSM]    Script Date: 03/17/2014 23:25:43 ******/
CREATE DATABASE [ISSTSM] ON  PRIMARY 
( NAME = N'ISSTSM', FILENAME = N'E:\NET训练营\SQL数据库文件\ISSTSM.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ISSTSM_log', FILENAME = N'E:\NET训练营\SQL数据库文件\ISSTSM_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ISSTSM] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ISSTSM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ISSTSM] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ISSTSM] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ISSTSM] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ISSTSM] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ISSTSM] SET ARITHABORT OFF
GO
ALTER DATABASE [ISSTSM] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ISSTSM] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ISSTSM] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ISSTSM] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ISSTSM] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ISSTSM] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ISSTSM] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ISSTSM] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ISSTSM] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ISSTSM] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ISSTSM] SET  DISABLE_BROKER
GO
ALTER DATABASE [ISSTSM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ISSTSM] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ISSTSM] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ISSTSM] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ISSTSM] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ISSTSM] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ISSTSM] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ISSTSM] SET  READ_WRITE
GO
ALTER DATABASE [ISSTSM] SET RECOVERY FULL
GO
ALTER DATABASE [ISSTSM] SET  MULTI_USER
GO
ALTER DATABASE [ISSTSM] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ISSTSM] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'ISSTSM', N'ON'
GO
USE [ISSTSM]
GO
/****** Object:  Table [dbo].[Section]    Script Date: 03/17/2014 23:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL,
	[SectionName] [nvarchar](50) NULL,
	[SectionCode] [nvarchar](50) NULL,
	[Sort] [int] NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'SectionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'SectionCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'Description'
GO
SET IDENTITY_INSERT [dbo].[Section] ON
INSERT [dbo].[Section] ([ID], [ParentID], [SectionName], [SectionCode], [Sort], [Description]) VALUES (1, 0, N'广州GES', N'gzges', 0, NULL)
INSERT [dbo].[Section] ([ID], [ParentID], [SectionName], [SectionCode], [Sort], [Description]) VALUES (2, 0, N'Avon', N'avon', 1, N'Avon guest')
INSERT [dbo].[Section] ([ID], [ParentID], [SectionName], [SectionCode], [Sort], [Description]) VALUES (3, 1, N'Gomac', N'gzgesGomac', 2, N'广州Ges Gomac')
INSERT [dbo].[Section] ([ID], [ParentID], [SectionName], [SectionCode], [Sort], [Description]) VALUES (4, 1, N'Aslf', N'gzgesAslf', 1, N'广州ges Aslf')
INSERT [dbo].[Section] ([ID], [ParentID], [SectionName], [SectionCode], [Sort], [Description]) VALUES (5, 1, N'Axapta', N'gzgesAx', 3, N'广州ges Ax')
SET IDENTITY_INSERT [dbo].[Section] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 03/17/2014 23:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[Sort] [int] NULL,
	[IsDeleted] [bit] NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名
角色名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'CreateUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可以删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Description'
GO
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([ID], [RoleName], [CreateUserID], [CreateDate], [Sort], [IsDeleted], [Description]) VALUES (1, N'admin', 1, CAST(0x0000A29600000000 AS DateTime), NULL, 0, N'admin')
INSERT [dbo].[Role] ([ID], [RoleName], [CreateUserID], [CreateDate], [Sort], [IsDeleted], [Description]) VALUES (2, N'staff', 1, CAST(0x0000A29800000000 AS DateTime), 1, 0, N'staff普通用户')
INSERT [dbo].[Role] ([ID], [RoleName], [CreateUserID], [CreateDate], [Sort], [IsDeleted], [Description]) VALUES (3, N'guest', 1, CAST(0x0000A29800000000 AS DateTime), 2, 0, N'Avon客户')
INSERT [dbo].[Role] ([ID], [RoleName], [CreateUserID], [CreateDate], [Sort], [IsDeleted], [Description]) VALUES (4, N'RoleTest', 1, CAST(0x0000A2A600000000 AS DateTime), 3, 1, N'RoleTest')
INSERT [dbo].[Role] ([ID], [RoleName], [CreateUserID], [CreateDate], [Sort], [IsDeleted], [Description]) VALUES (5, N'newstaff', 1, CAST(0x0000A2B500000000 AS DateTime), 4, 1, N'newstaff')
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  Table [dbo].[Permission]    Script Date: 03/17/2014 23:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PermissionName] [nvarchar](50) NULL,
	[Sort] [int] NULL,
	[Icon] [nvarchar](50) NULL,
	[IsVisible] [bit] NULL,
	[Description] [nvarchar](50) NULL,
	[IsButton] [bit] NULL,
	[PermissionCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'PermissionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可见' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'IsVisible'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'Description'
GO
SET IDENTITY_INSERT [dbo].[Permission] ON
INSERT [dbo].[Permission] ([ID], [PermissionName], [Sort], [Icon], [IsVisible], [Description], [IsButton], [PermissionCode]) VALUES (2, N'编辑', 3, N'aa', 1, N'修改', 1, N'Edit')
INSERT [dbo].[Permission] ([ID], [PermissionName], [Sort], [Icon], [IsVisible], [Description], [IsButton], [PermissionCode]) VALUES (3, N'添加', 2, N'aa', 1, N'增加', 1, N'Add')
INSERT [dbo].[Permission] ([ID], [PermissionName], [Sort], [Icon], [IsVisible], [Description], [IsButton], [PermissionCode]) VALUES (4, N'删除', 4, N'aa', 1, N'删除', 1, N'Delete')
INSERT [dbo].[Permission] ([ID], [PermissionName], [Sort], [Icon], [IsVisible], [Description], [IsButton], [PermissionCode]) VALUES (5, N'导入', 5, N'aa', 1, N'导入', 1, N'Import')
INSERT [dbo].[Permission] ([ID], [PermissionName], [Sort], [Icon], [IsVisible], [Description], [IsButton], [PermissionCode]) VALUES (6, N'导出', 6, N'aa', 1, N'导出', 1, N'Export')
INSERT [dbo].[Permission] ([ID], [PermissionName], [Sort], [Icon], [IsVisible], [Description], [IsButton], [PermissionCode]) VALUES (7, N'设置权限', 7, N'aa', 1, N'设置权限', 1, N'Setup')
INSERT [dbo].[Permission] ([ID], [PermissionName], [Sort], [Icon], [IsVisible], [Description], [IsButton], [PermissionCode]) VALUES (15, N'重置密码', 8, N'aa', 1, N'重置密码', 1, N'PwdSet')
INSERT [dbo].[Permission] ([ID], [PermissionName], [Sort], [Icon], [IsVisible], [Description], [IsButton], [PermissionCode]) VALUES (18, N'显示', 0, N'bb', 1, N'显示', 1, N'View')
INSERT [dbo].[Permission] ([ID], [PermissionName], [Sort], [Icon], [IsVisible], [Description], [IsButton], [PermissionCode]) VALUES (19, N'显示子节点', 0, N'aa', 1, N'Search', 1, N'Search')
INSERT [dbo].[Permission] ([ID], [PermissionName], [Sort], [Icon], [IsVisible], [Description], [IsButton], [PermissionCode]) VALUES (23, N'角色权限设置', 1, N'aa', 1, N'角色权限设置', 1, N'Authorize')
INSERT [dbo].[Permission] ([ID], [PermissionName], [Sort], [Icon], [IsVisible], [Description], [IsButton], [PermissionCode]) VALUES (24, N'模块授权', 1, N'aa', 1, N'模块授权', 1, N'ModuleAuthorize')
INSERT [dbo].[Permission] ([ID], [PermissionName], [Sort], [Icon], [IsVisible], [Description], [IsButton], [PermissionCode]) VALUES (25, N'角色模块设置', 0, N'aa', 1, N'角色模块设置', 1, N'AuthorizeMol')
INSERT [dbo].[Permission] ([ID], [PermissionName], [Sort], [Icon], [IsVisible], [Description], [IsButton], [PermissionCode]) VALUES (26, N'填写TimeSheet', 0, N'aa', 1, N'填写TimeSheet', 1, N'FillTS')
SET IDENTITY_INSERT [dbo].[Permission] OFF
/****** Object:  Table [dbo].[Module]    Script Date: 03/17/2014 23:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [nvarchar](50) NOT NULL,
	[ModuleName] [nvarchar](50) NULL,
	[ModuleUrl] [nvarchar](50) NULL,
	[Icon] [nvarchar](50) NULL,
	[Sort] [int] NULL,
	[IsVisible] [bit] NULL,
	[IsMenu] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级模块ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'ModuleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'ModuleUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可见' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'IsVisible'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否是菜单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'IsMenu'
GO
SET IDENTITY_INSERT [dbo].[Module] ON
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (1, N'0', N'TS管理后台', N'Index.aspx', N'0', 1, 1, 1, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (2, N'11', N'员工管理', N'views/Admin/UserManager.aspx', N'0', 11, 1, 1, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (3, N'11', N'部门管理', N'Views/Admin/SectionManager.aspx', N'0', 12, 1, 1, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (4, N'11', N'角色管理', N'Views/Admin/RoleManager.aspx', N'0', 13, 1, 1, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (5, N'11', N'模块管理', N'Views/Admin/ModulePermissionManager.aspx', N'0', 14, 1, 1, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (6, N'11', N'字典管理', N'Views/Admin/DicManager.aspx', N'0', 15, 1, 1, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (7, N'1', N'工作管理', N'aabb', N'0', 1, 1, 1, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (8, N'7', N'TimeSheet', N'Views/Admin/TSManager.aspx', N'0', 1, 1, 1, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (9, N'7', N'TSforStaff', N'Views/Staff/TSStaffManager.aspx', N'0', 1, 1, 1, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (10, N'7', N'TSforAvon', N'a', N'0', 23, 1, 1, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (11, N'1', N'系统管理', N'#', N'0', 10, 1, 1, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (12, N'7', N'Incident', N'Views/Admin/IncManager.aspx', N'0', 24, 1, 1, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (13, N'11', N'权限管理', N'Views/Admin/PermissionManager.aspx', N'0', 1, 1, 1, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (14, N'', N'', N'', N'', 0, 0, 0, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (15, N'', N'', N'', N'', 0, 0, 0, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (16, N'', N'', N'', N'', 0, 0, 0, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (17, N'', N'', N'', N'', 0, 0, 0, 0)
INSERT [dbo].[Module] ([ID], [ParentID], [ModuleName], [ModuleUrl], [Icon], [Sort], [IsVisible], [IsMenu], [IsDeleted]) VALUES (18, N'7', N'MyIncident', N'Views/Staff/IncManager.aspx', N'', 1, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[Module] OFF
/****** Object:  Table [dbo].[Incident]    Script Date: 03/17/2014 23:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incident](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IncidentNumber] [nvarchar](50) NOT NULL,
	[AssignedTo] [int] NULL,
	[ReportedBy] [int] NULL,
	[DicPriority] [int] NULL,
	[DicCountry] [int] NULL,
	[DicProduct] [int] NULL,
	[DicStatus] [int] NULL,
	[CreateDate] [datetime] NULL,
	[StatusFollowUp] [nvarchar](max) NULL,
	[Summary] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsFill] [int] NULL,
 CONSTRAINT [PK_Incident] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0:未填写Timesheet 1 ：已经填写' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Incident', @level2type=N'COLUMN',@level2name=N'IsFill'
GO
SET IDENTITY_INSERT [dbo].[Incident] ON
INSERT [dbo].[Incident] ([ID], [IncidentNumber], [AssignedTo], [ReportedBy], [DicPriority], [DicCountry], [DicProduct], [DicStatus], [CreateDate], [StatusFollowUp], [Summary], [Description], [IsFill]) VALUES (1, N'INC000002068928', 6, 1, 55, 50, 58, 62, CAST(0x0000A2A600000000 AS DateTime), N'Feb 20: SM approved. Start DEV. Sent our release doc.', N'Contribution Table import problem (QA)', N'"1) We are now using COM Connector instead of .Net Connector.  Perhaps we need to use .net connector.2) Create one subsystem for application/data dictionary refresh purpose.3) SOP seem miss out certain step which I still unsure whether it is relate to AOS stability issue.  E.g. they logout the user from Citrix instead of AX.  4) Sysclientsessions table may need to truncate.5) Change in AxPosting.dll to retry the logon() x 200 6) Still searching how svchost.exe relate to axComm.dll. - This need to create a dummy subsystem to simulate multiple login into the AX4 via biz connector."', 0)
INSERT [dbo].[Incident] ([ID], [IncidentNumber], [AssignedTo], [ReportedBy], [DicPriority], [DicCountry], [DicProduct], [DicStatus], [CreateDate], [StatusFollowUp], [Summary], [Description], [IsFill]) VALUES (2, N'INC000002068934', 7, 1, 55, 51, 59, 32, CAST(0x0000A2B400000000 AS DateTime), N'taa', N'taa', N'sa', 0)
INSERT [dbo].[Incident] ([ID], [IncidentNumber], [AssignedTo], [ReportedBy], [DicPriority], [DicCountry], [DicProduct], [DicStatus], [CreateDate], [StatusFollowUp], [Summary], [Description], [IsFill]) VALUES (3, N'INC000002068234', 4, 1, 55, 51, 59, 62, CAST(0x0000A2AC00000000 AS DateTime), N'a', N'a', N'a', 0)
INSERT [dbo].[Incident] ([ID], [IncidentNumber], [AssignedTo], [ReportedBy], [DicPriority], [DicCountry], [DicProduct], [DicStatus], [CreateDate], [StatusFollowUp], [Summary], [Description], [IsFill]) VALUES (4, N'INC000002068211', 3, 1, 55, 51, 59, 62, CAST(0x0000A2B500000000 AS DateTime), N'fda', N'daf', N'da', 0)
INSERT [dbo].[Incident] ([ID], [IncidentNumber], [AssignedTo], [ReportedBy], [DicPriority], [DicCountry], [DicProduct], [DicStatus], [CreateDate], [StatusFollowUp], [Summary], [Description], [IsFill]) VALUES (5, N'INC000002062312', 7, 1, 55, 52, 59, 62, CAST(0x0000A2AC00000000 AS DateTime), N'w1', N'w1', N'w1', 0)
INSERT [dbo].[Incident] ([ID], [IncidentNumber], [AssignedTo], [ReportedBy], [DicPriority], [DicCountry], [DicProduct], [DicStatus], [CreateDate], [StatusFollowUp], [Summary], [Description], [IsFill]) VALUES (6, N'INC000002021211', 2, 1, 55, 52, 59, 62, CAST(0x0000A2B600000000 AS DateTime), N'wqwqaa', N'wqwqaa', N'wqwqwa', 0)
INSERT [dbo].[Incident] ([ID], [IncidentNumber], [AssignedTo], [ReportedBy], [DicPriority], [DicCountry], [DicProduct], [DicStatus], [CreateDate], [StatusFollowUp], [Summary], [Description], [IsFill]) VALUES (8, N'INC000002068932', 44, 1, 55, 50, 59, 62, CAST(0x0000A2B700000000 AS DateTime), N'爱的', N'阿道夫', N'发', 1)
INSERT [dbo].[Incident] ([ID], [IncidentNumber], [AssignedTo], [ReportedBy], [DicPriority], [DicCountry], [DicProduct], [DicStatus], [CreateDate], [StatusFollowUp], [Summary], [Description], [IsFill]) VALUES (9, N'INC000002068912', 44, 1, 55, 50, 59, 62, CAST(0x0000A2B700000000 AS DateTime), N'ads', N'的萨芬', N'的', 1)
INSERT [dbo].[Incident] ([ID], [IncidentNumber], [AssignedTo], [ReportedBy], [DicPriority], [DicCountry], [DicProduct], [DicStatus], [CreateDate], [StatusFollowUp], [Summary], [Description], [IsFill]) VALUES (10, N'INC000002068122', 44, 1, 55, 52, 58, 65, CAST(0x0000A2B900000000 AS DateTime), N'aa', N'sd', N'asd', 1)
INSERT [dbo].[Incident] ([ID], [IncidentNumber], [AssignedTo], [ReportedBy], [DicPriority], [DicCountry], [DicProduct], [DicStatus], [CreateDate], [StatusFollowUp], [Summary], [Description], [IsFill]) VALUES (11, N'INC000002068123', 44, 1, 55, 50, 59, 65, CAST(0x0000A2BA00000000 AS DateTime), N'aa', N'bb', N'bb', 0)
SET IDENTITY_INSERT [dbo].[Incident] OFF
/****** Object:  Table [dbo].[DataDictionary]    Script Date: 03/17/2014 23:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataDictionary](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL,
	[ItemCode] [nvarchar](50) NULL,
	[ItemName] [nvarchar](50) NULL,
	[IsVisible] [bit] NULL,
	[Sort] [int] NULL,
 CONSTRAINT [PK_DataDictionary] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DataDictionary] ON
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (1, 0, N'Sex', N'Sex', 0, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (2, 1, N'Male', N'男', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (3, 1, N'FeMale', N'女', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (4, 0, N'Resource', N'Resource', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (5, 0, N'DicTitle', N'Title', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (6, 5, N'Support Team Manager', N'Support Team Manager', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (7, 5, N'Tech Lead', N'Tech Lead', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (8, 5, N'System Architect', N'System Architect', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (9, 5, N'Sr. Support Specialist', N'Sr. Support Specialist', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (10, 5, N'Support Specialist', N'Support Specialist', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (11, 0, N'DicProject', N'Project', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (12, 11, N'Enhancement', N'Enhancement', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (13, 11, N'Support', N'Support', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (14, 11, N'Training', N'Training', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (15, 0, N'DicGroup', N'Group', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (16, 15, N'ASLF', N'ASLF', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (17, 15, N'AX', N'AX', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (18, 15, N'BILLING', N'BILLING', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (19, 15, N'WEBE', N'WEBE', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (20, 15, N'DRM', N'DRM', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (21, 0, N'DicType', N'Type', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (22, 21, N'PROJ', N'PROJ', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (24, 21, N'CR', N'CR', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (25, 21, N'CR(WEBE)', N'CR(WEBE)', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (26, 21, N'INC', N'INC', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (27, 21, N'INC(WEBE)', N'INC(WEBE)', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (28, 21, N'PBI', N'PBI', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (29, 21, N'Training', N'Training', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (30, 0, N'DicStatus', N'Status', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (31, 30, N'Cancel', N'Cancel', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (32, 30, N'Closed', N'Closed', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (33, 0, N'DicSex', N'Sex', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (34, 33, N'Male', N'男', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (35, 33, N'Female', N'女', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (36, 0, N'test', N'test', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (37, 36, N'sub1', N'sub1', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (38, 36, N'sub', N'sub', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (39, 36, N'aa', N'aa', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (40, 36, N'修改', N'修改', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (41, 36, N'新增', N'新增', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (42, 0, N'测试', N'测试', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (43, 0, N'测试2', N'测试2', 1, 2)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (44, 43, N'tt', N'tt', 1, 5)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (45, 47, N'aa', N'aa', 1, 0)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (46, 43, N'bb', N'bb', 1, 3)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (47, 0, N'测试3', N'测试3', 1, 11)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (48, 47, N'测试3子节点', N'测试3子节点', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (49, 0, N'DicCountry', N'Country', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (50, 49, N'Turkey', N'Turkey', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (51, 49, N'Poland', N'Poland', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (52, 49, N'India', N'India', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (53, 0, N'DicPriority', N'Priority', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (54, 53, N'High', N'High', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (55, 53, N'Medium', N'Medium', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (56, 53, N'Low', N'Low', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (57, 0, N'DicProduct', N'Product', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (58, 57, N'GOMAC', N'GOMAC', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (59, 57, N'WEBE', N'WEBE', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (60, 42, N'TES', N'TES', 0, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (61, 42, N'TT', N'TTT', 0, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (62, 30, N'UDT', N'UDT', 1, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (63, 30, N'TT', N'TTT', 0, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (64, 30, N'tt', N'tt', 0, 1)
INSERT [dbo].[DataDictionary] ([ID], [ParentID], [ItemCode], [ItemName], [IsVisible], [Sort]) VALUES (65, 30, N'Start', N'Start', 1, 2)
SET IDENTITY_INSERT [dbo].[DataDictionary] OFF
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_SectionEntity]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：xhh
--时间：2013/12/24
-------------------------------------------------------------
--存储过程的功能：对表 Section 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@ID  
@ParentID  上级部门 
@SectionName  部门名称 
@SectionCode  部门编号 
@Sort   
@Description  描述 
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_SectionEntity]
	@DataAction int,
	@ID int = 0,
	@ParentID int=0,
	@SectionName nvarchar(50)='',
	@SectionCode nvarchar(50)='',
	@Sort int=0,
	@Description nvarchar(50)=''
AS
 if @DataAction=0
begin
	insert into Section
	(
		[ParentID],
		[SectionName],
		[SectionCode],
		[Sort],
		[Description]
	) 
	values
	(
		@ParentID,
		@SectionName,
		@SectionCode,
		@Sort,
		@Description
	)
	set 
		@ID=scope_identity()
end
if @DataAction=1
begin
	UPDATE [Section] SET
		[ParentID] = @ParentID,
		[SectionName] = @SectionName,
		[SectionCode] = @SectionCode,
		[Sort] = @Sort,
		[Description] = @Description
	WHERE
		
		[ID] = @ID
end
if @DataAction=2
begin
	delete from [Section] where  [ID] = @ID
end
select @ID
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_ModuleEntity]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：xhh
--时间：2013/12/24
-------------------------------------------------------------
--存储过程的功能：对表 Module 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@ID  
@ParentID  上级模块ID 
@ModuleName  模块名称 
@ModuleUrl  模块路径 
@Icon  图标路径 
@Sort   
@IsVisible  是否可见 
@IsMenu  是否是菜单 
@IsDeleted   
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_ModuleEntity]
	@DataAction int,
	@ID int = 0,
	@ParentID nvarchar(50),
	@ModuleName nvarchar(50),
	@ModuleUrl nvarchar(50),
	@Icon nvarchar(50),
	@Sort int,
	@IsVisible bit,
	@IsMenu bit,
	@IsDeleted bit
AS
 if @DataAction=0
begin
	insert into Module
	(
		[ParentID],
		[ModuleName],
		[ModuleUrl],
		[Icon],
		[Sort],
		[IsVisible],
		[IsMenu],
		[IsDeleted]
	) 
	values
	(
		@ParentID,
		@ModuleName,
		@ModuleUrl,
		@Icon,
		@Sort,
		@IsVisible,
		@IsMenu,
		@IsDeleted
	)
	set 
		@ID=scope_identity()
end
if @DataAction=1
begin
	UPDATE [Module] SET
		[ParentID] = @ParentID,
		[ModuleName] = @ModuleName,
		[ModuleUrl] = @ModuleUrl,
		[Icon] = @Icon,
		[Sort] = @Sort,
		[IsVisible] = @IsVisible,
		[IsMenu] = @IsMenu,
		[IsDeleted] = @IsDeleted
	WHERE
		
		[ID] = @ID
end
if @DataAction=2
begin
	delete from [Module] where  [ID] = @ID
end
select @ID
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_IncidentEntity]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：xhh
--时间：2014/1/17
-------------------------------------------------------------
--存储过程的功能：对表 Incident 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@ID  
@IncidentNumber   
@AssignedTo   
@ReportedBy   
@DicPriority   
@DicCountry   
@DicProduct   
@DicStatus   
@CreateDate   
@StatusFollowUp   
@Summary   
@Description   
@IsFill  0:未填写Timesheet 1 ：已经填写 
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_IncidentEntity]
	@DataAction int,
	@ID int = 0,
	@IncidentNumber nvarchar(50),
	@AssignedTo int=0,
	@ReportedBy int=0,
	@DicPriority int=0,
	@DicCountry int=0,
	@DicProduct int=0,
	@DicStatus int=0,
	@CreateDate datetime='1900-1-1',
	@StatusFollowUp nvarchar(1000)='',
	@Summary nvarchar(1000)='',
	@Description nvarchar(1000)='',
	@IsFill int=0
AS
 if @DataAction=0
begin
	insert into Incident
	(
		[IncidentNumber],
		[AssignedTo],
		[ReportedBy],
		[DicPriority],
		[DicCountry],
		[DicProduct],
		[DicStatus],
		[CreateDate],
		[StatusFollowUp],
		[Summary],
		[Description],
		[IsFill]
	) 
	values
	(
		@IncidentNumber,
		@AssignedTo,
		@ReportedBy,
		@DicPriority,
		@DicCountry,
		@DicProduct,
		@DicStatus,
		@CreateDate,
		@StatusFollowUp,
		@Summary,
		@Description,
		@IsFill
	)
	set 
		@ID=scope_identity()
end
if @DataAction=1
begin
	UPDATE [Incident] SET
		[IncidentNumber] = @IncidentNumber,
		[AssignedTo] = @AssignedTo,
		[ReportedBy] = @ReportedBy,
		[DicPriority] = @DicPriority,
		[DicCountry] = @DicCountry,
		[DicProduct] = @DicProduct,
		[DicStatus] = @DicStatus,
		[CreateDate] = @CreateDate,
		[StatusFollowUp] = @StatusFollowUp,
		[Summary] = @Summary,
		[Description] = @Description,
		[IsFill] = @IsFill
	WHERE
		
		[ID] = @ID
end
if @DataAction=2
begin
	delete from [Incident] where  [ID] = @ID
end
select @ID
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_DataDictionaryEntity]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：xhh
--时间：2013/12/24
-------------------------------------------------------------
--存储过程的功能：对表 DataDictionary 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@ID  
@ParentID   
@ItemCode   
@ItemName   
@@IsVisible   
@Sort   
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_DataDictionaryEntity]
	@DataAction int,
	@ID int = 0,
	@ParentID int,
	@ItemCode nvarchar(50),
	@ItemName nvarchar(50),
	@IsVisible bit,
	@Sort int
AS
 if @DataAction=0
begin
	insert into DataDictionary
	(
		[ParentID],
		[ItemCode],
		[ItemName],
		[IsVisible],
		[Sort]
	) 
	values
	(
		@ParentID,
		@ItemCode,
		@ItemName,
		@IsVisible,
		@Sort
	)
	set 
		@ID=scope_identity()
end
if @DataAction=1
begin
	UPDATE [DataDictionary] SET
		[ParentID] = @ParentID,
		[ItemCode] = @ItemCode,
		[ItemName] = @ItemName,
		[IsVisible] = @IsVisible,
		[Sort] = @Sort
	WHERE
		
		[ID] = @ID
end
if @DataAction=2
begin
	delete from [DataDictionary] where  [ID] = @ID
end
select @ID
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_RoleEntity]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：xhh
--时间：2013/12/24
-------------------------------------------------------------
--存储过程的功能：对表 Role 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@ID  
@RoleName  角色名
角色名 
@CreateUserID  创建人 
@CreateDate  创建日期 
@Sort  排序 
@IsDeleted  是否可以删除 
@Description  描述 
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_RoleEntity]
	@DataAction int,
	@ID int = 0,
	@RoleName nvarchar(50),
	@CreateUserID int,
	@CreateDate datetime,
	@Sort int,
	@IsDeleted bit,
	@Description nvarchar(50)
AS
 if @DataAction=0
begin
	insert into Role
	(
		[RoleName],
		[CreateUserID],
		[CreateDate],
		[Sort],
		[IsDeleted],
		[Description]
	) 
	values
	(
		@RoleName,
		@CreateUserID,
		@CreateDate,
		@Sort,
		@IsDeleted,
		@Description
	)
	set 
		@ID=scope_identity()
end
if @DataAction=1
begin
	UPDATE [Role] SET
		[RoleName] = @RoleName,
		[CreateUserID] = @CreateUserID,
		[CreateDate] = @CreateDate,
		[Sort] = @Sort,
		[IsDeleted] = @IsDeleted,
		[Description] = @Description
	WHERE
		
		[ID] = @ID
end
if @DataAction=2
begin
	delete from [Role] where  [ID] = @ID
end
select @ID
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_PermissionEntity]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：xhh
--时间：2013/12/24
-------------------------------------------------------------
--存储过程的功能：对表 Permission 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@ID  
@PermissionName  权限名称 
@Sort   
@Icon  图标路径 
@IsVisible  是否可见 
@Description  描述 
@IsButton   
@PermissionCode   
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_PermissionEntity]
	@DataAction int,
	@ID int = 0,
	@PermissionName nvarchar(50)='',
	@Sort int=0,
	@Icon nvarchar(50)='',
	@IsVisible bit=1,
	@Description nvarchar(50)='',
	@IsButton bit=1,
	@PermissionCode nvarchar(50)=''
AS
 if @DataAction=0
begin
	insert into Permission
	(
		[PermissionName],
		[Sort],
		[Icon],
		[IsVisible],
		[Description],
		[IsButton],
		[PermissionCode]
	) 
	values
	(
		@PermissionName,
		@Sort,
		@Icon,
		@IsVisible,
		@Description,
		@IsButton,
		@PermissionCode
	)
	set 
		@ID=scope_identity()
end
if @DataAction=1
begin
	UPDATE [Permission] SET
		[PermissionName] = @PermissionName,
		[Sort] = @Sort,
		[Icon] = @Icon,
		[IsVisible] = @IsVisible,
		[Description] = @Description,
		[IsButton] = @IsButton,
		[PermissionCode] = @PermissionCode
	WHERE
		
		[ID] = @ID
end
if @DataAction=2
begin
	delete from [Permission] where  [ID] = @ID
end
select @ID
GO
/****** Object:  Table [dbo].[ModulePermission]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModulePermission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [int] NULL,
	[PermissionID] [int] NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_ModulePermission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ModulePermission] ON
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (15, 2, 2, 1, CAST(0x0000A29200000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (16, 2, 3, 1, CAST(0x0000A29200000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (17, 2, 4, 1, CAST(0x0000A29200000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (18, 2, 6, 1, CAST(0x0000A29200000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (19, 2, 15, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (21, 13, 2, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (22, 13, 3, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (23, 13, 4, 1, CAST(0x0000A29200000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (24, 6, 2, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (25, 6, 3, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (26, 6, 4, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (29, 12, 2, 1, CAST(0x0000A29A00000000 AS DateTime), 1)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (30, 12, 3, 1, CAST(0x0000A29A00000000 AS DateTime), 1)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (31, 12, 4, 1, CAST(0x0000A29A00000000 AS DateTime), 1)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (32, 3, 2, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (33, 3, 3, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (34, 3, 4, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (35, 4, 2, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (36, 4, 3, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (37, 4, 4, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (38, 5, 2, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (39, 5, 3, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (40, 5, 4, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (41, 8, 2, 1, CAST(0x0000A29A00000000 AS DateTime), 1)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (42, 8, 3, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (43, 8, 4, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (47, 10, 2, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (48, 10, 3, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (49, 10, 4, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (50, 13, 18, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (53, 5, 24, 1, CAST(0x0000A29A00000000 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (56, 2, 7, 1, CAST(0x0000A2B2009FD43D AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (57, 2, 18, 1, CAST(0x0000A2B2009FD444 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (58, 2, 5, 1, CAST(0x0000A2B200C6829B AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (59, 2, 19, 1, CAST(0x0000A2B200C7730E AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (60, 4, 25, 1, CAST(0x0000A2B20105A4B8 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (62, 4, 23, 1, CAST(0x0000A2B201075399 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (63, 8, 5, 1, CAST(0x0000A2B4009D0468 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (64, 8, 6, 1, CAST(0x0000A2B4009D047A AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (65, 10, 5, 1, CAST(0x0000A2B500A8D7C2 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (66, 12, 26, 1, CAST(0x0000A2B500E1D939 AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (68, 18, 26, 1, CAST(0x0000A2B500F7928A AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (69, 9, 5, 1, CAST(0x0000A2B600B7651C AS DateTime), 0)
INSERT [dbo].[ModulePermission] ([ID], [ModuleID], [PermissionID], [CreateUserID], [CreateDate], [IsDeleted]) VALUES (70, 9, 6, 1, CAST(0x0000A2B600B76525 AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[ModulePermission] OFF
/****** Object:  Table [dbo].[UserInfo]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[RealName] [nvarchar](50) NULL,
	[SectionID] [int] NULL,
	[Telephone] [nvarchar](50) NULL,
	[Pwd] [nvarchar](50) NULL,
	[QQ] [nvarchar](50) NULL,
	[Photopath] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DicSex] [int] NULL,
	[DicAddress] [int] NULL,
	[DicStatus] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户真实姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'RealName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'SectionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'照片物理地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Photopath'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'DicSex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态   0:启用  1：禁用  2：注销' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'DicStatus'
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON
INSERT [dbo].[UserInfo] ([ID], [UserName], [RealName], [SectionID], [Telephone], [Pwd], [QQ], [Photopath], [Email], [DicSex], [DicAddress], [DicStatus]) VALUES (1, N'admin', N'系统管理员', 1, N'18122759129', N'123456', N'252222906', N'', N'252222906@qq.com', 34, 0, 31)
INSERT [dbo].[UserInfo] ([ID], [UserName], [RealName], [SectionID], [Telephone], [Pwd], [QQ], [Photopath], [Email], [DicSex], [DicAddress], [DicStatus]) VALUES (3, N'scott', N'scott', 1, N'111', N'123456', N'1111', N'', N'', 34, 0, 31)
INSERT [dbo].[UserInfo] ([ID], [UserName], [RealName], [SectionID], [Telephone], [Pwd], [QQ], [Photopath], [Email], [DicSex], [DicAddress], [DicStatus]) VALUES (4, N'edward', N'edward', 1, N'111', N'123456', N'1111', N'', N'', 34, 0, 31)
INSERT [dbo].[UserInfo] ([ID], [UserName], [RealName], [SectionID], [Telephone], [Pwd], [QQ], [Photopath], [Email], [DicSex], [DicAddress], [DicStatus]) VALUES (5, N'avon', N'Company AVON', 2, N'11', N'111111', N'1111', N'', NULL, NULL, NULL, NULL)
INSERT [dbo].[UserInfo] ([ID], [UserName], [RealName], [SectionID], [Telephone], [Pwd], [QQ], [Photopath], [Email], [DicSex], [DicAddress], [DicStatus]) VALUES (6, N'xhh', N'xhh', 1, N'181181818181', N'123456', N'1111', N'', N'', 0, 0, 0)
INSERT [dbo].[UserInfo] ([ID], [UserName], [RealName], [SectionID], [Telephone], [Pwd], [QQ], [Photopath], [Email], [DicSex], [DicAddress], [DicStatus]) VALUES (7, N'staff', N'员工测试', 3, N'111111111111', N'11111', N'1111', N'', N'1', 0, 0, 0)
INSERT [dbo].[UserInfo] ([ID], [UserName], [RealName], [SectionID], [Telephone], [Pwd], [QQ], [Photopath], [Email], [DicSex], [DicAddress], [DicStatus]) VALUES (44, N'alex', N'alex', 3, N'', N'123456', N'', N'', N'', 34, 0, 65)
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
/****** Object:  Table [dbo].[TimeSheet]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSheet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IncidentID] [int] NULL,
	[Date] [datetime] NULL,
	[BillableHour] [real] NULL,
	[UserID] [int] NULL,
	[DicTitle] [int] NULL,
	[DicProject] [int] NULL,
	[DicGroup] [int] NULL,
	[DicType] [int] NULL,
	[SubProject] [nvarchar](max) NULL,
	[Tasks] [nvarchar](max) NULL,
 CONSTRAINT [PK_TimeSheet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Incident对应的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimeSheet', @level2type=N'COLUMN',@level2name=N'IncidentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'UserInfo对应的ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TimeSheet', @level2type=N'COLUMN',@level2name=N'UserID'
GO
SET IDENTITY_INSERT [dbo].[TimeSheet] ON
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (3, 1, CAST(0x0000A2A600000000 AS DateTime), 6, 1, 1, 1, 1, 1, N'1', N'1')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (4, 2, CAST(0x0000A2E100000000 AS DateTime), 6, 6, 13, 18, 29, 27, N'Global OMS CoE Support and Maintenance', N'INC000002438273:discuss the issue with Alex')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (5, 3, CAST(0x0000A2A700000000 AS DateTime), 6, 6, 13, 18, 29, 27, N'Global OMS CoE Support and Maintenance', N'INC000002438273:discuss the issue with Alex')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (6, 4, CAST(0x0000A2B000000000 AS DateTime), 6, 6, 13, 18, 29, 27, N'Global OMS CoE Support and Maintenance', N'INC000002438273:discuss the issue with Alex')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (7, 5, CAST(0x0000A2A600000000 AS DateTime), 6, 6, 13, 18, 29, 27, N'Global OMS CoE Support and Maintenance', N'INC000002438273:discuss the issue with Alex')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (8, 3, CAST(0x0000A2A600000000 AS DateTime), 6, 6, 13, 18, 29, 27, N'Global OMS CoE Support and Maintenance', N'INC000002438273:discuss the issue with Alex')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (9, 6, CAST(0x0000A2BA00000000 AS DateTime), 6, 6, 13, 18, 29, 27, N'Global OMS CoE Support and Maintenance', N'INC000002438273:discuss the issue with Alex')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (10, 2, CAST(0x0000A2A600000000 AS DateTime), 6, 6, 13, 18, 29, 27, N'Global OMS CoE Support and Maintenance', N'INC000002438273:discuss the issue with Alex')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (11, 3, CAST(0x0000A2B100000000 AS DateTime), 6, 6, 13, 18, 29, 27, N'Global OMS CoE Support and Maintenance', N'INC000002438273:discuss the issue with Alex')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (12, 2, CAST(0x0000A2A800000000 AS DateTime), 6, 6, 13, 18, 29, 27, N'Global OMS CoE Support and Maintenance', N'INC000002438273:discuss the issue with Alex')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (13, 2, CAST(0x0000A2AA00000000 AS DateTime), 6, 6, 13, 18, 29, 27, N'Global OMS CoE Support and Maintenance', N'INC000002438273:discuss the issue with Alex')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (14, 2, CAST(0x0000A2A700000000 AS DateTime), 6, 6, 13, 18, 29, 27, N'Global OMS CoE Support and Maintenance', N'INC000002438273:discuss the issue with Alex')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (15, 2, CAST(0x0000A2AC00000000 AS DateTime), 6, 6, 13, 18, 29, 27, N'Global OMS CoE Support and Maintenance', N'INC000002438273:discuss the issue with Alex')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (16, 9, CAST(0x0000A2B500000000 AS DateTime), 6, 7, 10, 13, 18, 25, N'G', N'P')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (17, 8, CAST(0x0000A2B700000000 AS DateTime), 4, 7, 10, 12, 17, 25, N'asd', N'dfs')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (18, 8, CAST(0x0000A2B700000000 AS DateTime), 4, 7, 10, 12, 17, 25, N'asd', N'dfs')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (19, 8, CAST(0x0000A2B700000000 AS DateTime), 4, 7, 10, 12, 17, 25, N'asd', N'dfs')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (20, 9, CAST(0x0000A2AD00000000 AS DateTime), 3, 7, 10, 12, 16, 25, N'afd', N'asdf')
INSERT [dbo].[TimeSheet] ([ID], [IncidentID], [Date], [BillableHour], [UserID], [DicTitle], [DicProject], [DicGroup], [DicType], [SubProject], [Tasks]) VALUES (21, 10, CAST(0x0000A2B700000000 AS DateTime), 6, 44, 10, 13, 17, 26, N'adf', N'asdf')
SET IDENTITY_INSERT [dbo].[TimeSheet] OFF
/****** Object:  Table [dbo].[RoleModulePermission]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleModulePermission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[ModulePermissionID] [int] NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_RoleModule] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RoleModulePermission] ON
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (20, 1, 15, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (21, 1, 16, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (22, 1, 17, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (23, 1, 18, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (24, 1, 19, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (26, 1, 21, 1, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (27, 1, 22, 1, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (30, 1, 23, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (31, 1, 24, 1, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (32, 1, 25, 1, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (33, 1, 26, 1, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (36, 1, 29, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (37, 1, 30, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (38, 1, 31, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (39, 1, 32, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (40, 1, 33, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (41, 1, 34, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (42, 1, 35, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (43, 1, 36, 1, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (44, 1, 37, 1, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (45, 1, 38, 1, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (48, 1, 39, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (49, 1, 40, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (50, 1, 41, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (51, 1, 42, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (52, 1, 43, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (54, 1, 40, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (55, 1, 41, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (56, 1, 42, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (57, 1, 43, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (64, 1, 50, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (67, 1, 53, 1, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (68, 1, 58, 1, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (69, 1, 62, 1, CAST(0x0000A29A00000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (70, 1, 60, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (75, 4, 15, 1, CAST(0x0000A2B30096F08B AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (76, 4, 16, 1, CAST(0x0000A2B30096F096 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (77, 4, 17, 1, CAST(0x0000A2B30096F099 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (78, 4, 18, 1, CAST(0x0000A2B30096F09B AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (79, 4, 19, 1, CAST(0x0000A2B30096F09E AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (80, 4, 56, 1, CAST(0x0000A2B30096F0A0 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (81, 4, 57, 1, CAST(0x0000A2B30096F0A3 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (82, 4, 58, 1, CAST(0x0000A2B30096F0A5 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (83, 4, 59, 1, CAST(0x0000A2B30096F0A8 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (87, 4, 35, 1, CAST(0x0000A2B3009DBFBC AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (88, 4, 36, 1, CAST(0x0000A2B3009DBFC5 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (89, 4, 37, 1, CAST(0x0000A2B3009DBFC7 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (90, 4, 60, 1, CAST(0x0000A2B3009DBFCA AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (91, 4, 62, 1, CAST(0x0000A2B3009DBFCC AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (92, 4, 24, 1, CAST(0x0000A2B3009EEECA AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (93, 4, 24, 1, CAST(0x0000A2B3009EEECB AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (94, 4, 25, 1, CAST(0x0000A2B3009EEED2 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (95, 4, 25, 1, CAST(0x0000A2B3009EEED5 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (96, 4, 26, 1, CAST(0x0000A2B3009EEED7 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (97, 4, 26, 1, CAST(0x0000A2B3009EEEDA AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (100, 4, 24, 1, CAST(0x0000A2B3009EEEE3 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (101, 4, 25, 1, CAST(0x0000A2B3009EEEE6 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (102, 4, 26, 1, CAST(0x0000A2B3009EEEE9 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (104, 4, 29, 1, CAST(0x0000A2B300A1354C AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (105, 4, 30, 1, CAST(0x0000A2B300A13550 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (106, 4, 29, 1, CAST(0x0000A2B300A13550 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (107, 4, 31, 1, CAST(0x0000A2B300A13552 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (108, 4, 29, 1, CAST(0x0000A2B300A13553 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (109, 4, 30, 1, CAST(0x0000A2B300A13555 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (110, 4, 29, 1, CAST(0x0000A2B300A13559 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (111, 4, 30, 1, CAST(0x0000A2B300A1355A AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (112, 4, 31, 1, CAST(0x0000A2B300A1355C AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (113, 4, 30, 1, CAST(0x0000A2B300A1355F AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (114, 4, 31, 1, CAST(0x0000A2B300A13561 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (115, 4, 31, 1, CAST(0x0000A2B300A13566 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (116, 4, 21, 1, CAST(0x0000A2B300A42B66 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (117, 4, 22, 1, CAST(0x0000A2B300A42B6B AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (118, 4, 21, 1, CAST(0x0000A2B300A42B6B AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (119, 4, 21, 1, CAST(0x0000A2B300A42B6D AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (120, 4, 21, 1, CAST(0x0000A2B300A42B6E AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (121, 4, 21, 1, CAST(0x0000A2B300A42B6F AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (122, 4, 23, 1, CAST(0x0000A2B300A42B6D AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (123, 4, 22, 1, CAST(0x0000A2B300A42B72 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (124, 4, 22, 1, CAST(0x0000A2B300A42B70 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (125, 4, 22, 1, CAST(0x0000A2B300A42B75 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (126, 4, 22, 1, CAST(0x0000A2B300A42B77 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (127, 4, 50, 1, CAST(0x0000A2B300A42B7A AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (128, 4, 23, 1, CAST(0x0000A2B300A42B7C AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (129, 4, 23, 1, CAST(0x0000A2B300A42B7F AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (130, 4, 23, 1, CAST(0x0000A2B300A42B81 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (131, 4, 23, 1, CAST(0x0000A2B300A42B84 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (132, 4, 50, 1, CAST(0x0000A2B300A42B89 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (133, 4, 50, 1, CAST(0x0000A2B300A42B8C AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (134, 4, 50, 1, CAST(0x0000A2B300A42B8E AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (135, 4, 50, 1, CAST(0x0000A2B300A42B90 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (136, 4, 41, 1, CAST(0x0000A2B4009D37E2 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (137, 4, 42, 1, CAST(0x0000A2B4009D37E6 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (138, 4, 43, 1, CAST(0x0000A2B4009D37E9 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (140, 4, 63, 1, CAST(0x0000A2B4009D37F6 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (141, 4, 64, 1, CAST(0x0000A2B4009D3802 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (142, 1, 63, 1, CAST(0x0000A2B400000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (143, 1, 64, 1, CAST(0x0000A2B400000000 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (158, 2, 30, 1, CAST(0x0000A2B400EBFC42 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (159, 2, 31, 1, CAST(0x0000A2B400EBFC49 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (161, 2, 30, 1, CAST(0x0000A2B400EBFC55 AS DateTime))
GO
print 'Processed 100 total records'
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (162, 2, 31, 1, CAST(0x0000A2B400EBFC5B AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (191, 5, 68, 1, CAST(0x0000A2B500FB818B AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (192, 5, 68, 1, CAST(0x0000A2B500FB818B AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (193, 5, 68, 1, CAST(0x0000A2B500FB8191 AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (194, 5, 69, 1, CAST(0x0000A2B600B7934B AS DateTime))
INSERT [dbo].[RoleModulePermission] ([ID], [RoleID], [ModulePermissionID], [CreateUserID], [CreateDate]) VALUES (195, 5, 70, 1, CAST(0x0000A2B600B79354 AS DateTime))
SET IDENTITY_INSERT [dbo].[RoleModulePermission] OFF
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_ModulePermissionEntity]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：xhh
--时间：2013/12/24
-------------------------------------------------------------
--存储过程的功能：对表 ModulePermission 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@ID  
@ModuleID   
@PermissionID   
@CreateUserID   
@CreateDate   
@IsDeleted   
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_ModulePermissionEntity]
	@DataAction int,
	@ID int = 0,
	@ModuleID int,
	@PermissionID int,
	@CreateUserID int,
	@CreateDate datetime,
	@IsDeleted bit
AS
 if @DataAction=0
begin
	insert into ModulePermission
	(
		[ModuleID],
		[PermissionID],
		[CreateUserID],
		[CreateDate],
		[IsDeleted]
	) 
	values
	(
		@ModuleID,
		@PermissionID,
		@CreateUserID,
		@CreateDate,
		@IsDeleted
	)
	set 
		@ID=scope_identity()
end
if @DataAction=1
begin
	UPDATE [ModulePermission] SET
		[ModuleID] = @ModuleID,
		[PermissionID] = @PermissionID,
		[CreateUserID] = @CreateUserID,
		[CreateDate] = @CreateDate,
		[IsDeleted] = @IsDeleted
	WHERE
		
		[ID] = @ID
end
if @DataAction=2
begin
	delete from [ModulePermission] where  [ID] = @ID
end
select @ID
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_UserInfoEntity]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：xhh
--时间：2013/12/24
-------------------------------------------------------------
--存储过程的功能：对表 UserInfo 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@ID  
@UserName  用户名 
@RealName  用户真实姓名 
@SectionID  部门 
@Telephone   
@Pwd   
@QQ   
@Photopath  照片物理地址 
@Email   
@DicSex  性别 
@DicAddress   
@DicStatus  状态   0:启用  1：禁用  2：注销 
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_UserInfoEntity]
	@DataAction int,
	@ID int = 0,
	@UserName nvarchar(50)='',
	@RealName nvarchar(50)='',
	@SectionID int=0,
	@Telephone nvarchar(50)='',
	@Pwd nvarchar(50)='',
	@QQ nvarchar(50)='',
	@Photopath nvarchar(50)='',
	@Email nvarchar(50)='',
	@DicSex int=0,
	@DicAddress int=0,
	@DicStatus int=0
AS
 if @DataAction=0
begin
	insert into UserInfo
	(
		[UserName],
		[RealName],
		[SectionID],
		[Telephone],
		[Pwd],
		[QQ],
		[Photopath],
		[Email],
		[DicSex],
		[DicAddress],
		[DicStatus]
	) 
	values
	(
		@UserName,
		@RealName,
		@SectionID,
		@Telephone,
		@Pwd,
		@QQ,
		@Photopath,
		@Email,
		@DicSex,
		@DicAddress,
		@DicStatus
	)
	set 
		@ID=scope_identity()
end
if @DataAction=1
begin
	UPDATE [UserInfo] SET
		[UserName] = @UserName,
		[RealName] = @RealName,
		[SectionID] = @SectionID,
		[Telephone] = @Telephone,
		[Pwd] = @Pwd,
		[QQ] = @QQ,
		[Photopath] = @Photopath,
		[Email] = @Email,
		[DicSex] = @DicSex,
		[DicAddress] = @DicAddress,
		[DicStatus] = @DicStatus
	WHERE
		
		[ID] = @ID
end
if @DataAction=2
begin
	delete from [UserInfo] where  [ID] = @ID
end
select @ID
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[RoleID] [int] NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id中间表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRole', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserRole', @level2type=N'COLUMN',@level2name=N'CreateUserID'
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON
INSERT [dbo].[UserRole] ([ID], [UserID], [RoleID], [CreateUserID], [CreateDate]) VALUES (1, 1, 1, 1, CAST(0x0000A29200000000 AS DateTime))
INSERT [dbo].[UserRole] ([ID], [UserID], [RoleID], [CreateUserID], [CreateDate]) VALUES (3, 3, 1, 1, CAST(0x0000A29800000000 AS DateTime))
INSERT [dbo].[UserRole] ([ID], [UserID], [RoleID], [CreateUserID], [CreateDate]) VALUES (6, 5, 3, 1, CAST(0x0000A29800000000 AS DateTime))
INSERT [dbo].[UserRole] ([ID], [UserID], [RoleID], [CreateUserID], [CreateDate]) VALUES (13, 1, 2, 1, CAST(0x0000A29800000000 AS DateTime))
INSERT [dbo].[UserRole] ([ID], [UserID], [RoleID], [CreateUserID], [CreateDate]) VALUES (14, 7, 5, 1, CAST(0x0000A2A600000000 AS DateTime))
INSERT [dbo].[UserRole] ([ID], [UserID], [RoleID], [CreateUserID], [CreateDate]) VALUES (16, 44, 5, 1, CAST(0x0000A2B600B3EF01 AS DateTime))
SET IDENTITY_INSERT [dbo].[UserRole] OFF
/****** Object:  StoredProcedure [dbo].[usp_GetChildParentModulebyUserID]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[usp_GetChildParentModulebyUserID]
@UserID int
AS
--创建存储UserID所属的子模块ID列表,生成本地临时表#tmpChildModuleID
BEGIN
select moduleid 
INTO #tmpChildModuleID
from modulepermission mp 
where EXISTS 
(  select modulepermissionid from rolemodulepermission rp WHERE  mp.id=rp.modulePermissionID and rp.roleid
 in (select roleid from userrole where userid=@UserID)
 ) 
 
END 
--使用CTE得到子模块ID中所属的父模块ID及本身,生成本地临时表#tmpParentModuleID
BEGIN
	WITH RecursiveCte AS
	(
	select h1.id ,h1.parentid from [module]  h1 WHERE h1.id in (SELECT moduleid FROM #tmpChildModuleID)
	union all select h2.id, h2.parentid from [module] h2 join RecursiveCte on h2.id=RecursiveCte.parentid 
	) 
	select id 
	INTO #tmpParentModuleID
	FROM RecursiveCte
	
END
---获取所有模块的详细信息
BEGIN
	select ModuleName,ModuleUrl,Sort,Module.ID,ParentID,Icon,IsVisible 
	FROM dbo.Module  WHERE Module.id IN( SELECT #tmpParentModuleID.id FROM  #tmpParentModuleID) and IsVisible=1 AND isdeleted=0
	ORDER BY Sort DESC 
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_UserRoleEntity]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：xhh
--时间：2014/1/10
-------------------------------------------------------------
--存储过程的功能：对表 UserRole 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@ID  id中间表
@UserID   
@RoleID   
@CreateUserID  创建时间 
@CreateDate   
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_UserRoleEntity]
	@DataAction int,
	@ID int = 0,
	@UserID int=0,
	@RoleID int=0,
	@CreateUserID int=1,
	@CreateDate datetime='1990-01-01'
AS
 if @DataAction=0
begin
	insert into UserRole
	(
		[UserID],
		[RoleID],
		[CreateUserID],
		[CreateDate]
	) 
	values
	(
		@UserID,
		@RoleID,
		@CreateUserID,
		@CreateDate
	)
	set 
		@ID=scope_identity()
end
if @DataAction=1
begin
	UPDATE [UserRole] SET
		[UserID] = @UserID,
		[RoleID] = @RoleID,
		[CreateUserID] = @CreateUserID,
		[CreateDate] = @CreateDate
	WHERE
		
		[ID] = @ID
end
if @DataAction=2
begin
	delete from [UserRole] where  [ID] = @ID
end
select @ID
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_TimeSheetEntity]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：xhh
--时间：2014/1/9
-------------------------------------------------------------
--存储过程的功能：对表 TimeSheet 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@ID  
@IncidentID   
@Date   
@BillableHour   
@UserID  UserInfo对应的ID 
@DicTitle   
@DicProject   
@DicGroup   
@DicType   
@SubProject   
@Tasks   
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_TimeSheetEntity]
	@DataAction int,
	@ID int = 0,
	@IncidentID int,
	@Date datetime,
	@BillableHour real,
	@UserID int,
	@DicTitle int,
	@DicProject int,
	@DicGroup int,
	@DicType int,
	@SubProject nvarchar(1000),
	@Tasks nvarchar(1000)
AS
 if @DataAction=0
begin
	insert into TimeSheet
	(
		[IncidentID],
		[Date],
		[BillableHour],
		[UserID],
		[DicTitle],
		[DicProject],
		[DicGroup],
		[DicType],
		[SubProject],
		[Tasks]
	) 
	values
	(
		@IncidentID,
		@Date,
		@BillableHour,
		@UserID,
		@DicTitle,
		@DicProject,
		@DicGroup,
		@DicType,
		@SubProject,
		@Tasks
	)
	set 
		@ID=scope_identity()
end
if @DataAction=1
begin
	UPDATE [TimeSheet] SET
		[IncidentID] = @IncidentID,
		[Date] = @Date,
		[BillableHour] = @BillableHour,
		[UserID] = @UserID,
		[DicTitle] = @DicTitle,
		[DicProject] = @DicProject,
		[DicGroup] = @DicGroup,
		[DicType] = @DicType,
		[SubProject] = @SubProject,
		[Tasks] = @Tasks
	WHERE
		
		[ID] = @ID
end
if @DataAction=2
begin
	delete from [TimeSheet] where  [ID] = @ID
end
select @ID
GO
/****** Object:  StoredProcedure [dbo].[CreateUpdateDelete_RoleModulePermissionEntity]    Script Date: 03/17/2014 23:25:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------
--作者：xhh
--时间：2013/12/24
-------------------------------------------------------------
--存储过程的功能：对表 RoleModulePermission 进行添加、更新、删除操作。
-------------------------------------------------------------
--参数说明：
-------------------------------------------------------------
/*
@DataAction 添加更新删除的标志位
@ID  
@RoleID   
@ModulePermissionID   
@CreateUserID   
@CreateDate   
*/	
CREATE PROCEDURE [dbo].[CreateUpdateDelete_RoleModulePermissionEntity]
	@DataAction int,
	@ID int = 0,
	@RoleID int=0,
	@ModulePermissionID int=0,
	@CreateUserID int=0,
	@CreateDate datetime='1990-1-1'
AS
 if @DataAction=0
begin
	insert into RoleModulePermission
	(
		[RoleID],
		[ModulePermissionID],
		[CreateUserID],
		[CreateDate]
	) 
	values
	(
		@RoleID,
		@ModulePermissionID,
		@CreateUserID,
		@CreateDate
	)
	set 
		@ID=scope_identity()
end
if @DataAction=1
begin
	UPDATE [RoleModulePermission] SET
		[RoleID] = @RoleID,
		[ModulePermissionID] = @ModulePermissionID,
		[CreateUserID] = @CreateUserID,
		[CreateDate] = @CreateDate
	WHERE
		
		[ID] = @ID
end
if @DataAction=2
begin
	delete from [RoleModulePermission] where  [ID] = @ID
end
select @ID
GO
/****** Object:  Default [DF_Section_ParentID]    Script Date: 03/17/2014 23:25:45 ******/
ALTER TABLE [dbo].[Section] ADD  CONSTRAINT [DF_Section_ParentID]  DEFAULT ((0)) FOR [ParentID]
GO
/****** Object:  Default [DF_Role_IsDeleted]    Script Date: 03/17/2014 23:25:45 ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_Permission_IsVisible]    Script Date: 03/17/2014 23:25:45 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_IsVisible]  DEFAULT ((1)) FOR [IsVisible]
GO
/****** Object:  Default [DF_Permission_IsButton]    Script Date: 03/17/2014 23:25:45 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_IsButton]  DEFAULT ((1)) FOR [IsButton]
GO
/****** Object:  Default [DF_Module_ParentID]    Script Date: 03/17/2014 23:25:45 ******/
ALTER TABLE [dbo].[Module] ADD  CONSTRAINT [DF_Module_ParentID]  DEFAULT ((0)) FOR [ParentID]
GO
/****** Object:  Default [DF_DataDictionary_ParentID]    Script Date: 03/17/2014 23:25:45 ******/
ALTER TABLE [dbo].[DataDictionary] ADD  CONSTRAINT [DF_DataDictionary_ParentID]  DEFAULT ((0)) FOR [ParentID]
GO
/****** Object:  Default [DF_DataDictionary_IsVisabled]    Script Date: 03/17/2014 23:25:45 ******/
ALTER TABLE [dbo].[DataDictionary] ADD  CONSTRAINT [DF_DataDictionary_IsVisabled]  DEFAULT ((1)) FOR [IsVisible]
GO
/****** Object:  Default [DF_DataDictionary_Sort]    Script Date: 03/17/2014 23:25:45 ******/
ALTER TABLE [dbo].[DataDictionary] ADD  CONSTRAINT [DF_DataDictionary_Sort]  DEFAULT ((0)) FOR [Sort]
GO
/****** Object:  Default [DF_ModulePermission_IsDeleted]    Script Date: 03/17/2014 23:25:49 ******/
ALTER TABLE [dbo].[ModulePermission] ADD  CONSTRAINT [DF_ModulePermission_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  ForeignKey [FK_ModulePermission_Module]    Script Date: 03/17/2014 23:25:49 ******/
ALTER TABLE [dbo].[ModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_ModulePermission_Module] FOREIGN KEY([ModuleID])
REFERENCES [dbo].[Module] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ModulePermission] CHECK CONSTRAINT [FK_ModulePermission_Module]
GO
/****** Object:  ForeignKey [FK_ModulePermission_Permission]    Script Date: 03/17/2014 23:25:49 ******/
ALTER TABLE [dbo].[ModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_ModulePermission_Permission] FOREIGN KEY([PermissionID])
REFERENCES [dbo].[Permission] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ModulePermission] CHECK CONSTRAINT [FK_ModulePermission_Permission]
GO
/****** Object:  ForeignKey [FK_User_Section]    Script Date: 03/17/2014 23:25:49 ******/
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_User_Section] FOREIGN KEY([SectionID])
REFERENCES [dbo].[Section] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_User_Section]
GO
/****** Object:  ForeignKey [FK_TimeSheet_Incident]    Script Date: 03/17/2014 23:25:49 ******/
ALTER TABLE [dbo].[TimeSheet]  WITH CHECK ADD  CONSTRAINT [FK_TimeSheet_Incident] FOREIGN KEY([IncidentID])
REFERENCES [dbo].[Incident] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TimeSheet] CHECK CONSTRAINT [FK_TimeSheet_Incident]
GO
/****** Object:  ForeignKey [FK_TimeSheet_UserInfo]    Script Date: 03/17/2014 23:25:49 ******/
ALTER TABLE [dbo].[TimeSheet]  WITH CHECK ADD  CONSTRAINT [FK_TimeSheet_UserInfo] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserInfo] ([ID])
GO
ALTER TABLE [dbo].[TimeSheet] CHECK CONSTRAINT [FK_TimeSheet_UserInfo]
GO
/****** Object:  ForeignKey [FK_RoleModule_Role]    Script Date: 03/17/2014 23:25:49 ******/
ALTER TABLE [dbo].[RoleModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_RoleModule_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleModulePermission] CHECK CONSTRAINT [FK_RoleModule_Role]
GO
/****** Object:  ForeignKey [FK_RoleModule_RoleModule]    Script Date: 03/17/2014 23:25:49 ******/
ALTER TABLE [dbo].[RoleModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_RoleModule_RoleModule] FOREIGN KEY([ModulePermissionID])
REFERENCES [dbo].[ModulePermission] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleModulePermission] CHECK CONSTRAINT [FK_RoleModule_RoleModule]
GO
/****** Object:  ForeignKey [FK_UserRole_Role]    Script Date: 03/17/2014 23:25:49 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
/****** Object:  ForeignKey [FK_UserRole_User]    Script Date: 03/17/2014 23:25:49 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserInfo] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO
