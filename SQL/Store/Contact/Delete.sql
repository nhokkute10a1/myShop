CREATE PROCEDURE sp_Contact_Delete
@Contact_ID int
AS
BEGIN 
	DELETE C
	FROM Contact C
	WHERE C.Contact_ID=@Contact_ID
END