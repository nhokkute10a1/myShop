Create Procedure sp_Roles_Update
@Roles_ID int ,
@Roles_Name nvarchar(20) ,
@Is_Active bit =NULL,
@Display_Order int =NULL
As
Begin
	Update R
	Set  R.Roles_Name=@Roles_Name,
     R.Is_Active=@Is_Active,
     R.Display_Order=@Display_Order
	From  Roles R
	Where R.Roles_ID=@Roles_ID
End

