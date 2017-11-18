Create  Proc sp_SysFunctionInGroup_Insert
--@SysFunctionInGroupId,
@GroupRolesId int,
@FuctionId int,
@Descriptions nvarchar(MAX)=null,
@Display_Order int =null,
@Is_Active bit =null,
@CreateDate date =null,
@CreateBy int =null,
@UpdateDate date =null,
@UpdateBy int =null
as
Begin
	Insert into SysFunctionInGroup(
		--SysFunctionInGroupId,
		GroupRolesId,
		FuctionId,
		Descriptions,
		Display_Order,
		Is_Active,
		CreateDate,
		CreateBy,
		UpdateDate,
		UpdateBy
		)Values(
		--@SysFunctionInGroupId,
		@GroupRolesId,
		@FuctionId,
		@Descriptions,
		@Display_Order,
		@Is_Active,
		@CreateDate,
		@CreateBy,
		@UpdateDate,
		@UpdateBy
		)
End