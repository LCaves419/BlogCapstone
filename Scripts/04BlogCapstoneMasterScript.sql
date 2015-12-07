use BlogCapstone
go

drop table StaticPages
go

create table StaticPages (
	StaticPageID int identity(1,1) primary key,
	[Date] date not null,
	Title varchar(50) not null,
	Body varchar(max) not null,
	[Status] int not null,
	UserID nvarchar(128) foreign key references AspNetUsers(Id) not null
)
go

insert into StaticPages ([Date],Title, Body, [Status], UserID)
	values ('12/1/2015', 'First Static Page', 'This is a test of the first static page from the DB', 1, 'a3f07804-62e1-4682-a89a-bc6218f72860'),
		('12/7/2015', 'Holiday Advertisement', 'Sale on all fresh produce and dry goods', 2, '2598e14d-88d0-46a7-ace9-f323ffe89181')
go

----------------------------------------------------
------- STORED PROCEDURES --------------------------
----------------------------------------------------

USE [BlogCapstone]
GO

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

----------------------------------------------

USE [BlogCapstone]
GO

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

-----------------------------------------------

USE [BlogCapstone]
GO

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

------------------------------------------------

USE [BlogCapstone]
GO

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

-------------------------------------------------

USE [BlogCapstone]
GO

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

----------------------------------------------------

USE [BlogCapstone]
GO

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