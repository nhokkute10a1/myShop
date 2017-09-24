Create Procedure sp_UserProfile_Delete
@UserProfile_ID int
as
begin
	Delete Ur
	From UserProfile Ur
	Where Ur.UserProfile_ID=@UserProfile_ID
end