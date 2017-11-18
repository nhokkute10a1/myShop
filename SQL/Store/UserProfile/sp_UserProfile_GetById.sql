Create Procedure sp_UserProfile_GetById 
@UserProfile_ID int
as
begin
	Select Ur.*
	From UserProfile Ur
	Where Ur.UserProfile_ID=@UserProfile_ID
end