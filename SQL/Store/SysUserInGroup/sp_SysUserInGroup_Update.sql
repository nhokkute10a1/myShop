Create Proc sp_SysUserInGroup_Update
@SysUserInGroupId int,
@Descriptions nvarchar(max) null,
@DisplayOrder int null,
@IsActive bit null,
@CreateDate datetime null,
@CreateBy datetime null,
@UpdateDate datetime null,
@UpdateBy int null 
as
Begin
	Update A
	Set A.Descriptions=@Descriptions,
		A.DisplayOrder=@DisplayOrder,
		A.IsActive=@IsActive,
		A.CreateDate=@CreateDate,
		A.CreateBy=@CreateBy,
		A.UpdateDate=@UpdateDate,
		A.UpdateBy=@UpdateBy
	From SysUserInGroup A
	Where A.SysUserInGroupId=@SysUserInGroupId
 
End