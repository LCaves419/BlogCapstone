--------------------------------
-- Followup Master SQL Script --
--------------------------------

use BlogCapstone
go

alter table BlogPosts
add UserID nvarchar(128),
	foreign key(UserID) references AspNetUsers(Id)
go

alter table BlogPosts
add [Status] int
go

USE [BlogCapstone]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[BlogPostInsert] (
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

USE [BlogCapstone]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[HashTagInsert] (
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

USE [BlogCapstone]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[HashTagPostInsert] (
	@HashTagID int,
	@BlogPostID int
)
as
begin
	insert into HashTagPosts (HashTagID, BlogPostID)
		values (@HashTagID, @BlogPostID)
end
GO