Create Procedure sp_UserRoles_Update
@UserRoles_ID int ,
@Roles_ID int =NULL,
@UserProfile_ID int =NULL,
@Is_Active bit =NULL,
@Display_Order int =NULL
as
Begin
	Update Up
	Set Up.Roles_ID=@Roles_ID,
      Up.UserProfile_ID=@UserProfile_ID,
      Up.Is_Active=@Is_Active,
      Up.Display_Order=@Display_Order
	From UserRoles Up
	Where Up.UserRoles_ID=@UserRoles_ID
end