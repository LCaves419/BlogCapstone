use master
go

drop database BlogCapstone
go

create database BlogCapstone
go

use BlogCapstone
go

create table Categories (
	CategoryID int identity(1,1) primary key,
	CategoryName varchar(50) not null 
)
go

create table HashTags (
	HashTagID int identity(1,1) primary key,
	HashTagName varchar(50) not null,
)
go

create table BlogPosts (
	BlogPostID int identity(1,1) primary key,
	Title varchar(50) null,
	Body varchar(max) not null,
	PostDate [date] not null,
	CategoryID int foreign key references Categories(CategoryID) not null
)
go

create table HashTagPosts (
	HashTagID int foreign key references HashTags(HashTagID) not null,
	BlogPostID int foreign key references BlogPosts(BlogPostID) not null,
	primary key (HashTagID, BlogPostID)
)
go

insert into Categories (CategoryName)
	values ('On the Farm'),
		('Daily Picks'),
		('In the News'),
		('Social Responsibility'),
		('Just Because')
go

insert into HashTags (HashTagName)
	values ('#savings'),
		('#noGMO'),
		('#freshfood'),
		('#vegetarian'),
		('#vegan'),
		('#lifestyle'),
		('#healthychoices')
go

insert into BlogPosts (Title, Body, PostDate, CategoryID)
	values ('Black Friday Deals', 'Come early for our best Black Friday deals!', '2015-11-24', 2),
		('Cyber Monday Deals', 'Best electronic deals on the web!', '2015-11-30', 5)
go

insert into HashTagPosts (HashTagID, BlogPostID)
	values (1, 1),
		(6, 1)
go

-------------------------------------------------------------------------------
-- STORED PROCEDURES --
-------------------------------------------------------------------------------

USE [BlogCapstone]
GO

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
		c.CategoryName,
		ht.HashTagID,
		ht.HashTagName
	from BlogPosts bp 
			inner join Categories c
				on bp.CategoryID = c.CategoryID
			inner join HashTagPosts htp
				on htp.BlogPostID = bp.BlogPostID
			inner join HashTags ht
				on ht.HashTagID = htp.HashTagID
	order by c.CategoryName asc
end
go