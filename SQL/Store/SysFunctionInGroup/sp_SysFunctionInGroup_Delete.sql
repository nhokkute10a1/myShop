Create  Proc sp_SysFunctionInGroup_Delete
@SysFunctionInGroupId int
as
Begin
	Delete A
	From SysFunctionInGroup A
	Where A.SysFunctionInGroupId =@SysFunctionInGroupId
End