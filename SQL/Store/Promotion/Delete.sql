Create Procedure sp_Promotion_Delete
@Promotion_ID int
As
Begin
	Delete Pr
	From Promotion Pr
	Where Pr.Promotion_ID=@Promotion_ID
End