Create Proc sp_SysFunctionGroup_Delete
@SysFunctionGroupId int
as
Begin
	Delete A
	 From SysFunctionGroup A
	 Where  A.SysFunctionGroupId=@SysFunctionGroupId
	
End