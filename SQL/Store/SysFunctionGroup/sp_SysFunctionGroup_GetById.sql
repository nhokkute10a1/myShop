Create Proc sp_SysFunctionGroup_GetById
@SysFunctionGroupId int
as
Begin
	 Select A.*
	 From SysFunctionGroup A
	 Where  A.SysFunctionGroupId=@SysFunctionGroupId
	
End