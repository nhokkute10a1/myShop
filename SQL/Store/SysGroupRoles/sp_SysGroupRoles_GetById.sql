Create Proc sp_SysGroupRoles_GetAll
@GroupRolesId int
as
Begin
	Select A.*
	From SysGroupRoles A
	Where A.GroupRolesId=@GroupRolesId
End

sp_SysGroupRoles_GetAll 1