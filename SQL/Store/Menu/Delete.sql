Create Proc sp_Menu_Delete
@Menu_ID int
as
begin
	Delete A 
	From [Menu] A
	Where A.Menu_ID = @Menu_ID
end