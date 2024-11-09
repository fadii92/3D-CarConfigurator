create database Car_Configurator
use Car_Configurator
create table Categories(
CateId INT IDENTITY (1, 1) PRIMARY KEY,
Rims VARCHAR (255) NOT NULL,
Paints VARCHAR (255) NOT NULL,
Models VARCHAR (255) NOT NULL,
Stickers VARCHAR (255),
Vendors VARCHAR (255),
Price VARCHAR (255) NOT NULL
)

create proc SP_SaveCateInfo(
@Rims varchar(255),
@Paints varchar (255),
@Models VARCHAR (255),
@Stickers VARCHAR (255),
@Vendors VARCHAR (255),
@Price VARCHAR (255)
)
as
begin 
insert into Categories(Rims, Paints, Stickers, Models, Vendors, Price )
values(@Rims, @Paints, @Stickers, @Models, @Vendors, @Price)
end


create proc Sp_GetCateInfo
as begin
select * from Categories
end


create table Registration(
RegId INT IDENTITY (1, 1) PRIMARY KEY,
FirstName varchar(255),
LastName varchar(255),
Phone VARCHAR (25),
Email VARCHAR (255),
Username VARCHAR (25),
City VARCHAR (50),
Pass VARCHAR (25),
ConfirmPassword VARCHAR (25),
[Role] VARCHAR (50)
)
create proc SP_UserRegInfo(
@FirstName varchar(255),
@LastName varchar(255),
@Phone VARCHAR (25),
@Email VARCHAR (255),
@Username VARCHAR (25),
@City VARCHAR (50),
@Pass VARCHAR (25),
@ConfirmPassword VARCHAR (25),
@role varchar(50)
)
as
begin
insert into Registration(FirstName, LastName, Phone, Email, Username, City, Pass, ConfirmPassword, [Role] )
values(@FirstName, @LastName, @Phone, @Email, @Username, @City, @Pass, @ConfirmPassword, @role)
insert into Authenticate(Username, pass,[Role])
values(@Username, @Pass,@role)
end

create proc Sp_GetUsers
as begin
select * from Registration
end

create  table Authenticate(
AuthId INT IDENTITY (1, 1) PRIMARY KEY,
Username varchar(255),
Pass varchar(255),
[Role] varchar (50)
)

insert into Authenticate (Username,Pass,[Role]) values('Admin','123','Administrator')

create proc SP_SaveAuthInfo(
@Username varchar(255),
@Pass varchar (255),
@Role varchar(50)
)
as
begin
insert into Authenticate (Username, Pass,[Role])
values(@Username, @Pass,@Role)
end


create proc Sp_GetUserAndPass
as begin
select * from Authenticate
end

create table UserModify(
Rims VARCHAR (255) NOT NULL,
Paints VARCHAR (255) NOT NULL,
Stickers VARCHAR (255),
Models VARCHAR (255) NOT NULL,
Vendors VARCHAR (255),
Price VARCHAR (255) NOT NULL
)

create proc SP_UserModify(
@Rims VARCHAR (255),
@Paints varchar (255),
@Models VARCHAR (255),
@Stickers VARCHAR (255),
@Vendors VARCHAR (255),
@Price VARCHAR (255)
)
as
begin 
insert into UserModify(Rims, Paints, Stickers, Models, Vendors, Price )
values(@Rims, @Paints, @Stickers, @Models, @Vendors, @Price)
end

create proc SP_GetUserModify
as begin
select * from UserModify
end

select * from Authenticate