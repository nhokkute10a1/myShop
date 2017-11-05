Create Procedure sp_PageSetting_GetAllById
@PageSetting_ID int
as
begin
Select P.*
From PageSetting P
Where  P.PageSetting_ID = @PageSetting_ID
end
