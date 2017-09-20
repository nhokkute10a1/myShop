--Get By Id category--
Create Procedure sp_GetByIdCate
	@ID int
	--With Encryption Đoạn mã hoá Store,khuyến cáo k nên xài khi dùng Azure
as
Begin
	Select C.*
	From Category C
	Where Category_ID=@ID
end