Create Procedure sp_Roles_Insert
--@Roles_ID int IDENTITY(1,1) ,
@Roles_Name nvarchar(20) ,
@Is_Active bit =NULL,
@Display_Order int =NULL
As
Begin
	Insert into  Roles
	( 
	  Roles_Name,
      Is_Active,
      Display_Order
	)
	Values
	(
	@Roles_Name ,
	@Is_Active,
	@Display_Order
	)
End
