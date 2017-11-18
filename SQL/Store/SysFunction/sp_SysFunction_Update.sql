Create Proc sp_SysFunction_Update
@FunctionId int,
@TreePanelId int =null,
@SysFunctionGroupId int ,
@FunctionCode varchar(50) =null,
@FunctionName nvarchar(50) =null,
@ButtonId varchar(50) =null,
@Display_Order int =null,
@Is_Active bit =null,
@CreateDate date =null,
@CreateBy int =null,
@UpateDate date =null,
@UpdateBy int 	  
as
Begin
	Update A
	Set  A.TreePanelId=@TreePanelId,
		A.SysFunctionGroupId=@SysFunctionGroupId,
		A.FunctionCode=@FunctionCode,
		A.FunctionName=@FunctionName,
		A.ButtonId=@ButtonId,
		A.Display_Order=@Display_Order,
		A.Is_Active=@Is_Active,
		A.CreateDate=@CreateDate,
		A.CreateBy=@CreateBy,
		A.UpateDate=@UpateDate,
		A.UpdateBy=@UpdateBy

	From SysFunction A
	Where  A.FunctionId=@FunctionId
End