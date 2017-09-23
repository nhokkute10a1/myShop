Create Proc sp_Menu_GetByIdParent
@Parent_ID int
as
begin
	Select m.*
	From Menu m
	Where m.Parent_ID=@Parent_ID
end

--test
sp_Menu_GetByIdParent 0