Create Proc sp_SysFunctionGroup_Insert
--@SysFunctionGroupId int,
@SysFunctionGroupCode varchar(50) =null,
@SysFunctionGroupName nvarchar(255) =null,
@Descriptions nvarchar(MAX) =null,
@DisplayOrder int =null,
@IsActive bit =null,
@CreateDate date =null,
@CreateBy int =null,
@UpdateDate date =null,
@UpdateBy int
as
Begin
	Insert into SysFunctionGroup(
		--SysFunctionGroupId,
		SysFunctionGroupCode,
		SysFunctionGroupName,
		Descriptions,
		DisplayOrder,
		IsActive,
		CreateDate,
		CreateBy,
		UpdateDate,
		UpdateBy
		)Values (
		--@SysFunctionGroupId,
		@SysFunctionGroupCode,
		@SysFunctionGroupName,
		@Descriptions,
		@DisplayOrder,
		@IsActive,
		@CreateDate,
		@CreateBy,
		@UpdateDate,
		@UpdateBy
		)
End