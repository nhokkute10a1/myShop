Create Proc sp_SysFunction_Delete
@FunctionId int 
as
Begin
	DElete A
	From SysFunction A
	Where  A.FunctionId=@FunctionId
End