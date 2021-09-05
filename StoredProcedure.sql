Create or Alter Procedure spInsertAddress
(
	@AddressId int ,
	@FirstName varchar(20),
	@LastName varchar(20),
	@Address varchar(100), 
	@City varchar(50),
	@State varchar(200),
	@Zip varchar(20),
	@PhoneNumber varchar(20),
	@Email varchar(50)
)
As
Begin Try
Insert into AddressBook (FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email) values(@FirstName,@LastName,@Address,@City,@State,@Zip,@PhoneNumber,@Email)
End Try
Begin Catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH






Create or Alter Procedure spDeleteAddress
(
	@FirstName varchar(20)
)
As
Begin Try
Delete from AddressBook Where FirstName=@FirstName
End Try
Begin Catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH


Create or Alter Procedure spRetrieveAddressBelongsToCityOrState
(
	@City varchar(20),
	@State varchar(20)
)
As
Begin Try
Select * From AddressBook Where City=@City or State=@State
End Try
Begin Catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH


Create or Alter Procedure spRetrieveAddressBookSizeByCity
(
	@City varchar(20)
)
As
Begin Try
Select count(FirstName) From AddressBook Where City=@City group by City
end Try
Begin Catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH

Create or Alter Procedure spRetrieveAddressBookSizeByState
(
	@State varchar(20)
)
As
Begin Try
Select count(FirstName) From AddressBook Where State=@State group by State
End Try
Begin Catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH

