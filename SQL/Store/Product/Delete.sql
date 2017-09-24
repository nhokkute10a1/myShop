Create Procedure sp_Product_Delete
@Product_ID int
As
Begin
	Delete P
	From Product P
	Where P.Product_ID=@Product_ID
End