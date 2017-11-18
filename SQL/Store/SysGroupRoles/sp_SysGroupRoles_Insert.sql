Create Proc sp_SysGroupRoles_Insert
--@GroupRolesId,
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
Insert into SysGroupRoles(
	 -- GroupRolesId,
      GroupRolesCode,
      GroupRolesName,
      Is_Active,
      Display_Order,
      CreateDate,
      CreateBy,
      UpdateDate,
      UpdateBy
	  )Values
	  (
	  --@GroupRolesId,
      @GroupRolesCode,
      @GroupRolesName,
      @Is_Active,
      @Display_Order,
      @CreateDate,
      @CreateBy,
      @UpdateDate,
      @UpdateBy
	  )
End