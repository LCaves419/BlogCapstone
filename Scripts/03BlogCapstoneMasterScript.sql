------------------------------------
------- STORED PROCEDURES ----------
------------------------------------

USE [BlogCapstone]
GO

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

------------------------------------------------

USE [BlogCapstone]
GO

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

-------------------------------------------------

USE [BlogCapstone]
GO

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

-------------------------------------------------------

USE [BlogCapstone]
GO

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

--------------------------------------------------

