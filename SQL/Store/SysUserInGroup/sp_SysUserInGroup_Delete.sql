Create Proc sp_SysUserInGroup_Delete
@SysUserInGroupId int
as
Begin
	DELETE A
	From SysUserInGroup A
	Where A.SysUserInGroupId=@SysUserInGroupId
End