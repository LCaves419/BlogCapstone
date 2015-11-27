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
	PostDate date not null,
	CategoryID int foreign key references Categories(CategoryID) not null,
	HashTagID int foreign key references HashTags(HashTagID) not null,
	UserID int foreign key references Users(UserID) not null
)
go