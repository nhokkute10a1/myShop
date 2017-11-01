Create Procedure sp_Category_GetAllById
@Category_ID int
as
BEGIN
	SELECT C.*
	FROM Category C
	Where C.Category_ID=@Category_ID
END