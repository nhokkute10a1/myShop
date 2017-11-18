Create Proc sp_SysUserInGroup_Insert
--@SysUserInGroupId int,
@GroupRolesId int,
@UserId int,
@Descriptions nvarchar(max) null,
@DisplayOrder int null,
@IsActive bit null,
@CreateDate datetime null,
@CreateBy datetime null,
@UpdateDate datetime null,
@UpdateBy int null 
as
Begin
	Insert into  SysUserInGroup(
	GroupRolesId,
	UserId,
	Descriptions,
	DisplayOrder,
	IsActive,
	CreateDate,
	CreateBy,
	UpdateDate,
	UpdateBy
	)
	Values(
	@GroupRolesId,
	@UserId,
	@Descriptions,
	@DisplayOrder,
	@IsActive,
	@CreateDate,
	@CreateBy,
	@UpdateDate,
	@UpdateBy
	)
End