Create Procedure sp_PageSetting_Delete
@PageSetting_ID int
as
begin
	Delete Ps
	From PageSetting Ps
	Where Ps.PageSetting_ID=@PageSetting_ID
end