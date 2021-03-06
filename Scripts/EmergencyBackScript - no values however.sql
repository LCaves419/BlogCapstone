USE [master]
GO
/****** Object:  Database [BlogCapstone]    Script Date: 12/11/2015 9:43:04 AM ******/
CREATE DATABASE [BlogCapstone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlogCapstone', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\BlogCapstone.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BlogCapstone_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\BlogCapstone_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BlogCapstone] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlogCapstone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlogCapstone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogCapstone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogCapstone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogCapstone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogCapstone] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogCapstone] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BlogCapstone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogCapstone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogCapstone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogCapstone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlogCapstone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogCapstone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogCapstone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogCapstone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogCapstone] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BlogCapstone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogCapstone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlogCapstone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlogCapstone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlogCapstone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogCapstone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlogCapstone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlogCapstone] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BlogCapstone] SET  MULTI_USER 
GO
ALTER DATABASE [BlogCapstone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlogCapstone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlogCapstone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlogCapstone] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BlogCapstone] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BlogCapstone]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogPosts]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BlogPosts](
	[BlogPostID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Body] [varchar](max) NOT NULL,
	[PostDate] [date] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[UserID] [nvarchar](128) NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BlogPostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HashTagPosts]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HashTagPosts](
	[HashTagID] [int] NOT NULL,
	[BlogPostID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HashTagID] ASC,
	[BlogPostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HashTags]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HashTags](
	[HashTagID] [int] IDENTITY(1,1) NOT NULL,
	[HashTagName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HashTagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StaticPages]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StaticPages](
	[StaticPageID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Body] [varchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[UserID] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StaticPageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 12/11/2015 9:43:04 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 12/11/2015 9:43:04 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 12/11/2015 9:43:04 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 12/11/2015 9:43:04 AM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 12/11/2015 9:43:04 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 12/11/2015 9:43:04 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[BlogPosts]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[BlogPosts]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[HashTagPosts]  WITH CHECK ADD FOREIGN KEY([BlogPostID])
REFERENCES [dbo].[BlogPosts] ([BlogPostID])
GO
ALTER TABLE [dbo].[HashTagPosts]  WITH CHECK ADD FOREIGN KEY([HashTagID])
REFERENCES [dbo].[HashTags] ([HashTagID])
GO
ALTER TABLE [dbo].[StaticPages]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[ApproveBlogPostByID]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ApproveBlogPostByID] (
	@BlogPostID int
)
as
begin
	update BlogPosts
	set [Status] = 1
	where BlogPostID = @BlogPostID
end

GO
/****** Object:  StoredProcedure [dbo].[ApproveStaticPageByID]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ApproveStaticPageByID] (
	@StaticPageID int
)
as
begin
	update StaticPages
	set [Status] = 1
	where StaticPageID = @StaticPageID
end

GO
/****** Object:  StoredProcedure [dbo].[ArchiveBlogPostByID]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ArchiveBlogPostByID] (
	@BlogPostID int
)
as
begin
	update BlogPosts
	set [Status] = 3
	where BlogPostID = @BlogPostID
end

GO
/****** Object:  StoredProcedure [dbo].[ArchiveStaticPageByID]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ArchiveStaticPageByID] (
	@StaticPageID int
)
as
begin
	update StaticPages
	set [Status] = 3
	where StaticPageID = @StaticPageID
end

GO
/****** Object:  StoredProcedure [dbo].[BlogPostInsert]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[BlogPostInsert] (
	@Title varchar(50),
	@Body varchar(max),
	@PostDate date,
	@CategoryID int,
	@UserID nvarchar(128),
	@Status int,
	@BlogPostID int output
)
as
begin
	insert into BlogPosts (Title, Body, PostDate, CategoryID, UserID, [Status])
		values (@Title, @Body, @PostDate, @CategoryID, @UserID, @Status)

	set @BlogPostID = SCOPE_IDENTITY()
end

GO
/****** Object:  StoredProcedure [dbo].[GetAllBlogPostsOrderByCategory]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetAllBlogPostsOrderByCategory]
as
begin
	select bp.BlogPostID,
		bp.Title,
		bp.Body,
		bp.PostDate,
		bp.CategoryID,
		bp.[Status],
		c.CategoryName,
		ht.HashTagID,
		ht.HashTagName,
		anu.Id,
		anu.UserName
	from BlogPosts bp 
			inner join Categories c
				on bp.CategoryID = c.CategoryID
			inner join HashTagPosts htp
				on htp.BlogPostID = bp.BlogPostID
			inner join HashTags ht
				on ht.HashTagID = htp.HashTagID
			inner join AspNetUsers anu
				on bp.UserID = anu.Id
	order by c.CategoryName asc
end

GO
/****** Object:  StoredProcedure [dbo].[GetAllCategories]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetAllCategories]
as
begin
	select *
	from Categories
end

GO
/****** Object:  StoredProcedure [dbo].[GetAllHashTags]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetAllHashTags]
as
begin
	select *
	from HashTags
end

GO
/****** Object:  StoredProcedure [dbo].[GetAllStaticPages]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetAllStaticPages]
as
begin
	select *
	from StaticPages
end

GO
/****** Object:  StoredProcedure [dbo].[GetBlogPostByID]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetBlogPostByID] (
	@BlogPostID int
)
as
begin
	select bp.BlogPostID,
		bp.Title,
		bp.Body,
		bp.PostDate,
		bp.CategoryID,
		bp.[Status],
		c.CategoryName,
		ht.HashTagID,
		ht.HashTagName,
		anu.Id,
		anu.UserName
	from BlogPosts bp 
			inner join Categories c
				on bp.CategoryID = c.CategoryID
			inner join HashTagPosts htp
				on htp.BlogPostID = bp.BlogPostID
			inner join HashTags ht
				on ht.HashTagID = htp.HashTagID
			inner join AspNetUsers anu
				on bp.UserID = anu.Id
	where bp.BlogPostID = @BlogPostID
end

GO
/****** Object:  StoredProcedure [dbo].[GetCategoryByID]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetCategoryByID] (
	@CategoryID int
)
as
begin
	select *
	from Categories
	where CategoryID = @CategoryID
end

GO
/****** Object:  StoredProcedure [dbo].[GetHashTagByID]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetHashTagByID] (
	@HashTagID int
)
as
begin
	select *
	from HashTags
	where HashTagID = @HashTagID
end

GO
/****** Object:  StoredProcedure [dbo].[GetStaticPageByID]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetStaticPageByID] (
	@StaticPageID int
)
as
begin
	select *
	from StaticPages
	where StaticPageID = @StaticPageID
end

GO
/****** Object:  StoredProcedure [dbo].[HashTagInsert]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[HashTagInsert] (
	@HashTagName varchar(50),
	@HashTagID int output
)
as
begin
	insert into HashTags (HashTagName)
		values (@HashTagName)

	set @HashTagID = SCOPE_IDENTITY()
end

GO
/****** Object:  StoredProcedure [dbo].[HashTagPostInsert]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[HashTagPostInsert] (
	@HashTagID int,
	@BlogPostID int
)
as
begin
	insert into HashTagPosts (HashTagID, BlogPostID)
		values (@HashTagID, @BlogPostID)
end

GO
/****** Object:  StoredProcedure [dbo].[StaticPageInsert]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[StaticPageInsert] (
	@Date date,
	@Title varchar(50),
	@Body varchar(max),
	@Status int,
	@UserID nvarchar(128),
	@StaticPageID int output
)
as
begin
	insert into StaticPages ([Date], Title, Body, [Status], UserID)
		values (@Date, @Title, @Body, @Status, @UserID)

	set @StaticPageID = SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[UnapproveBlogPostByID]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UnapproveBlogPostByID] (
	@BlogPostID int
)
as
begin
	update BlogPosts
	set [Status] = 2
	where BlogPostID = @BlogPostID
end

GO
/****** Object:  StoredProcedure [dbo].[UnapproveStaticPageByID]    Script Date: 12/11/2015 9:43:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[UnapproveStaticPageByID] (
	@StaticPageID int
)
as
begin
	update StaticPages
	set [Status] = 2
	where StaticPageID = @StaticPageID
end

GO
USE [master]
GO
ALTER DATABASE [BlogCapstone] SET  READ_WRITE 
GO
