Alter Proc sp_SysFunction_GetById
@FunctionId int 
as
Begin
	Select A.*,B.SysFunctionGroupName
	From SysFunction A
	Left join  SysFunctionGroup B on A.SysFunctionGroupId=B.SysFunctionGroupId
	Where  A.FunctionId=@FunctionId
End
