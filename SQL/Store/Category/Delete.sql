Create Procedure sp_Category_Delete 
@Category_ID int
as
begin
	Delete C
	From Category C
	Where C.Category_ID = @Category_ID
end