create database AddressBookServiceADO


use AddressBookServiceADO

create table AddressBook
(
	FirstName varchar(20) not null,
	LastName varchar(20) not null,
	Address varchar(20) not null,
	City varchar(20) not null,
	State varchar(20) not null,
	Zip float not null,
	PhoneNumber float not null,
	Email varchar(50) not null
)


Insert into AddressBook(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email)
values
('Akshay','Patil','Chennai','Chennai','Tamil Nadu',400000,9999900000,'Akshay@gmail.com'),
('Dnyanesh','Gawade','pune','Pune','Maharashtra',411060,7878787878,'dnyanesh@gmail.com'),
('Sagar','Deshmukh','Mulund','Mumbai','Maharashtra',410006,9898989898,'Saumya@gmail.com'),
('Onkar','Kulkarni','Panjim','Panjim','Goa',100000,9999999999,'onkar@gmail.com')

alter table Addressbook Add AddressId int identity(1,1) primary key
select * from AddressBook