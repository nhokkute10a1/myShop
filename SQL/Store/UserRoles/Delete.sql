Create Procedure sp_UserRoles_Delete
@UserRoles_ID int
as
Begin
	Delete Up
	From UserRoles Up
	Where Up.UserRoles_ID=@UserRoles_ID
end