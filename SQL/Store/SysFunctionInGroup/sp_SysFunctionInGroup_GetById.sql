Create  Proc sp_SysFunctionInGroup_GetById
@SysFunctionInGroupId int
as
Begin
	Select A.*, B.GroupRolesName, C.FunctionName
	From SysFunctionInGroup A
	Left join SysGroupRoles B on A.GroupRolesId=B.GroupRolesId
	Left join SysFunction C on A.FuctionId=C.FunctionId
	Where A.SysFunctionInGroupId =@SysFunctionInGroupId
End