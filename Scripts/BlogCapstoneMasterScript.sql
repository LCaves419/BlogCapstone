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

create table UserLevels (
	UserLevelID int identity(1,1) primary key,
	UserLevelName varchar(50) not null
)
go

create table Users (
	UserID int identity(1,1) primary key,
	UserName varchar(50) not null,
	UserLevelID int foreign key references UserLevels(UserLevelID) not null
)
go

create table BlogPosts (
	BlogPostID int identity(1,1) primary key,
	Title varchar(50) null,
	Body varchar(max) not null,
	PostDate [date] not null,
	CategoryID int foreign key references Categories(CategoryID) not null,
	UserID int foreign key references Users(UserID) not null
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

insert into UserLevels (UserLevelName)
	values ('Administrator'),
		('Public Relations'),
		('Public')
go

insert into Users (UserName, UserLevelID)
	values ('FreshFindsDummy', 1),
		('PublicRelationsPerson', 2)
go

insert into BlogPosts (Title, Body, PostDate, CategoryID, UserID)
	values ('Black Friday Deals', 'Come early for our best Black Friday deals!', '2015-11-24', 2, 1),
		('Cyber Monday Deals', 'Best electronic deals on the web!', '2015-11-30', 5, 2)
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
	select *
	from BlogPosts bp inner join
		Categories c
			on bp.CategoryID = c.CategoryID
	order by c.CategoryName asc
end
go