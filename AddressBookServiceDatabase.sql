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