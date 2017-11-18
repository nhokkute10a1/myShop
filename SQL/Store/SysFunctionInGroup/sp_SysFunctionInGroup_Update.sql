Create  Proc sp_SysFunctionInGroup_Update
@SysFunctionInGroupId int,
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
	Update A
	Set A.GroupRolesId=@GroupRolesId,
		A.FuctionId=@FuctionId,
		A.Descriptions=@Descriptions,
		A.Display_Order=@Display_Order,
		A.Is_Active=@Is_Active,
		A.CreateDate=@CreateDate,
		A.CreateBy=@CreateBy,
		A.UpdateDate=@UpdateDate,
		A.UpdateBy=@UpdateBy

	From SysFunctionInGroup A
	Where A.SysFunctionInGroupId =@SysFunctionInGroupId
End