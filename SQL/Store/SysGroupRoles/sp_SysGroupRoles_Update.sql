Create Proc sp_SysGroupRoles_Update
@GroupRolesId int,
@GroupRolesCode varchar(50) =null,
@GroupRolesName nvarchar(50) =null,
@Is_Active bit =null,
@Display_Order int =null,
@CreateDate date =null,
@CreateBy int =null,
@UpdateDate date =null,
@UpdateBy  int
as
Begin
	Update A
	Set A.GroupRolesCode=@GroupRolesCode,
		A.GroupRolesName=@GroupRolesName,
		A.Is_Active=@Is_Active,
		A.Display_Order=@Display_Order,
		A.CreateDate=@CreateDate,
		A.CreateBy=@CreateBy,
		A.UpdateDate=@UpdateDate,
		A.UpdateBy=@UpdateBy
	From SysGroupRoles A
	Where A.GroupRolesId=@GroupRolesId
End