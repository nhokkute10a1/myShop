Alter Proc sp_Menu_Insert
	@Parent_ID int = 0,
    @Menu_Name nvarchar(50) = Null,
    @Display_Order int = 1,
    @Is_Active bit  = 1
as
begin

	Insert into Menu(Parent_ID,Menu_Name,Display_Order,Is_Active)
	Values(@Parent_ID,@Menu_Name,@Display_Order,@Is_Active)
end