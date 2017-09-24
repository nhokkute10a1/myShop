Create Procedure sp_UserRoles_Insert
--@UserRoles_ID int ,
@Roles_ID int =NULL,
@UserProfile_ID int =NULL,
@Is_Active bit =NULL,
@Display_Order int =NULL
as
begin
	Insert into UserRoles(
	 Roles_ID,
      UserProfile_ID,
      Is_Active,
      Display_Order
	)
	Values(
	@Roles_ID,
	@UserProfile_ID,
	@Is_Active,
	@Display_Order
	)
end
