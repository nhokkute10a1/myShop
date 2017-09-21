Create Proc sp_Menu_Update
@Menu_ID int,
@Parent_ID int = 0,
@Menu_Name nvarchar(50) = Null,
@Display_Order int = 1,
@Is_Active bit  = 1
as
begin
	Update A Set A.Parent_ID = @Parent_ID,
	A.Menu_Name = @Menu_Name,
	A.Display_Order = @Display_Order,
	A.Is_Active = @Is_Active
	From [Menu] A
	Where A.Menu_ID = @Menu_ID
end