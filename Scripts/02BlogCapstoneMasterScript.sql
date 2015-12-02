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

----------------------------------------------------------

USE [BlogCapstone]
GO

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

----------------------------------------------------------------------------------

USE [BlogCapstone]
GO

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

--------------------------------------------------------------------------

USE [BlogCapstone]
GO

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

--------------------------------------------------------------------------

USE [BlogCapstone]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[GetAllBlogPostsOrderByCategory]
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

-----------------------------------------------------------

USE [BlogCapstone]
GO

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

----------------------------------------------

USE [BlogCapstone]
GO

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

-------------------------------------------------

USE [BlogCapstone]
GO

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

--------------------------------------------------

USE [BlogCapstone]
GO

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