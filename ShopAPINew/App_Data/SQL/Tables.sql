CREATE TABLE Product(
	ID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) 
)
-- insert into Product values(N'Ð¡Ã×note2')
-- select * from Product

CREATE TABLE [News]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	Title NVARCHAR(50),
	Content NTEXT,
	Author NVARCHAR(20),
	ViewCount INT,
	AddDateTime DATETIME,
	UpdateTime DATETIME,
)

CREATE TABLE SiteUser(
	ID INT PRIMARY KEY IDENTITY,
	UserID VARCHAR(20) NOT NULL,
	UserPass VARCHAR(20) NOT NULL,
	UserName NVARCHAR(20)
)
