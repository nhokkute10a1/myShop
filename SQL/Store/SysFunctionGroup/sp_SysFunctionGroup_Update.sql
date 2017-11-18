Create Proc sp_SysFunctionGroup_Update
@SysFunctionGroupId int,
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
	Update A
	Set A.SysFunctionGroupCode=@SysFunctionGroupCode,
		A.SysFunctionGroupName=@SysFunctionGroupName,
		A.Descriptions=@Descriptions,
		A.DisplayOrder=@DisplayOrder,
		A.IsActive=@IsActive,
		A.CreateDate=@CreateDate,
		A.CreateBy=@CreateBy,
		A.UpdateDate=@UpdateDate,
		A.UpdateBy=@UpdateBy
	 From SysFunctionGroup A
	 Where  A.SysFunctionGroupId=@SysFunctionGroupId
	
End