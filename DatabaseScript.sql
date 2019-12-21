CREATE TABLE RoleTable
(
	RoleID int,
	RoleDescription varchar(30),
	primary key(RoleID)
)

CREATE TABLE UserTable
(
	UserID INT identity(1, 1),
	UserName varchar(30) unique,
	U_Pwd varchar(30),
	RoleID int,
	primary key(UserID),
	foreign key(RoleID) references RoleTable(RoleID) ON DELETE NO ACTION ON UPDATE CASCADE
)

CREATE TABLE UserInfoTable
(
	UserID INT,
	FirstName varchar(20),
	LastName varchar(20),
	U_Email varchar(30) unique,
	U_PhoneNumber varchar(11),
	U_Address varchar(50),
	primary key(UserID),
	foreign key(UserID) references UserTable(UserID) ON DELETE NO ACTION ON UPDATE CASCADE
)

CREATE TABLE AuthorTable
(
	AuthorID int identity(1, 1),
	AuthorName varchar(40),
	primary key(AuthorID)
)

CREATE TABLE PublisherTable
(
	PublisherID int identity(1, 1),
	PublisherName varchar(20),
	P_Email varchar(30) unique,
	P_PhoneNumber varchar(11),
	P_Address varchar(50),
	primary key(PublisherID)
)

CREATE TABLE BookDetailTable
(
	ISBN varchar(15) UNIQUE,
	Title varchar(40),
	Summary varchar(max),
	AuthorID int,
	PublisherID int,
	primary key(ISBN),
	foreign key(AuthorID) references AuthorTable(AuthorID) ON DELETE NO ACTION ON UPDATE CASCADE,
	foreign key(PublisherID) references PublisherTable(PublisherID) ON DELETE NO ACTION ON UPDATE CASCADE
)

CREATE TABLE BookTable
(
	BookID int identity(1, 1),
	ISBN varchar(15) not null,
	BookStatus bit default 1,
	primary key(BookID),
	foreign key(ISBN) references BookDetailTable(ISBN) ON DELETE NO ACTION ON UPDATE CASCADE
)

CREATE TABLE RentTable
(
	RentID int identity(1, 1),
	BookID int,
	ISBN varchar(15),
	UserID int,
	RentDate date,
	DueDate date,
	primary key(RentID),
	foreign key(BookID) references BookTable(BookID) ON DELETE NO ACTION ON UPDATE CASCADE,
	foreign key(ISBN) references BookDetailTable(ISBN) ON DELETE NO ACTION ON UPDATE CASCADE,
	foreign key(UserID) references UserTable(UserID) ON DELETE NO ACTION ON UPDATE CASCADE,
	constraint CHK_RentDate check(RentDate < DueDate)
)

CREATE TABLE RentDetailTable
(
	RentID int,
	BookID int,
	ISBN varchar(15),
	UserID int,
	RentDate date,
	DueDate date,
	ReturnDate date,
	Cost float,
	Paid float,
	Deposit float,
	Note varchar(90),
	primary key(RentID),
	foreign key(RentID) references RentTable(RentID) ON DELETE NO ACTION ON UPDATE CASCADE,
	foreign key(BookID) references BookTable(BookID) ON DELETE NO ACTION ON UPDATE CASCADE,
	foreign key(ISBN) references BookDetailTable(ISBN) ON DELETE NO ACTION ON UPDATE CASCADE,
	foreign key(UserID) references UserTable(UserID) ON DELETE NO ACTION ON UPDATE CASCADE,
	constraint CHK_ReturnDate check(RentDate < ReturnDate)
)

--GO

--IF EXISTS (SELECT name FROM sys.objects
--      WHERE name = 'Tgr_RentDateUpdate' AND type = 'TR')
--   DROP TRIGGER dbo.Tgr_RentDateUpdate;
--GO

--CREATE TRIGGER Tgr_RentDateUpdate
--ON dbo.RentTable
--AFTER INSERT, UPDATE
--AS
--IF(UPDATE(BookID) or UPDATE(ISBN) or UPDATE(UserID) or UPDATE(RentDate) or UPDATE(DueDate))
--	UPDATE RentDetailTable
--		SET BookID = R.BookID,
--			ISBN = R.ISBN,
--			UserID = R.UserID,
--			RentDate = R.RentDate,
--			DueDate = R.DueDate
--		FROM RentDetailTable RD
--		INNER JOIN RentTable R
--		ON RD.RentID = R.RentID
