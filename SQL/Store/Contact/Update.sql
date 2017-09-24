CREATE PROCEDURE sp_Contact_Update
@Contact_ID int,
@Contact_Name nvarchar(50) ,
@Contact_CellPhone varchar(50) =NULL,
@Contact_Email varchar(50) =NULL,
@Contact_Address nvarchar(max) =NULL,
@Contact_Date datetime,
@Is_Active bit =NULL
AS
BEGIN
	UPDATE C
	SET Contact_Name=@Contact_Name,
	Contact_CellPhone=@Contact_CellPhone,
	Contact_Email=@Contact_Email,
	Contact_Address=@Contact_Address,
	Contact_Date=@Contact_Date,
	Is_Active=@Is_Active
	FROM  Contact C
	WHERE C.Contact_ID=@Contact_ID
END