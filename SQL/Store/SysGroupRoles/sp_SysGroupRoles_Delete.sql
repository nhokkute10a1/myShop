Create Proc sp_SysGroupRoles_Delete
@GroupRolesId int
as
Begin
	Delete A
	From SysGroupRoles A
	Where A.GroupRolesId=@GroupRolesId
End