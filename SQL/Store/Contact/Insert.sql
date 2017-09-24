CREATE PROCEDURE sp_Contact_Insert
--@Contact_ID int,
@Contact_Name nvarchar(50) ,
@Contact_CellPhone varchar(50) =NULL,
@Contact_Email varchar(50) =NULL,
@Contact_Address nvarchar(max) =NULL,
@Contact_Date datetime,
@Is_Active bit =NULL
AS
BEGIN
	INSERT INTO Contact( 
	Contact_Name,
	Contact_CellPhone,
	Contact_Email,
	Contact_Address,
	Contact_Date,
	Is_Active
	)
	VALUES (
	@Contact_Name,
	@Contact_CellPhone,
	@Contact_Email,
	@Contact_Address,
	@Contact_Date,
	@Is_Active
	)
END