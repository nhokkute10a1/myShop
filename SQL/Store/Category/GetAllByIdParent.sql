Create Procedure sp_Category_GetAllByIdParent
@Category_Parent_ID int
as
BEGIN
	SELECT C.*
	FROM Category C
	Where C.Category_Parent_ID=@Category_Parent_ID
END

----
sp_Category_GetAllByIdParent 0