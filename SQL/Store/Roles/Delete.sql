Create Procedure sp_Roles_Delete
@Roles_ID int
as
Begin
	Delete R
	From  Roles R
	Where R.Roles_ID=@Roles_ID
End