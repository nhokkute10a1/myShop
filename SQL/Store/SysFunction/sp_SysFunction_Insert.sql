Create Proc sp_SysFunction_Insert
--@FunctionId,
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
	Insert into SysFunction(
	  --FunctionId,
		TreePanelId,
		SysFunctionGroupId,
		FunctionCode,
		FunctionName,
		ButtonId,
		Display_Order,
		Is_Active,
		CreateDate,
		CreateBy,
		UpateDate,
		UpdateBy
		)Values(
	  --@FunctionId,
		@TreePanelId,
		@SysFunctionGroupId,
		@FunctionCode,
		@FunctionName,
		@ButtonId,
		@Display_Order,
		@Is_Active,
		@CreateDate,
		@CreateBy,
		@UpateDate,
		@UpdateBy
		)
End