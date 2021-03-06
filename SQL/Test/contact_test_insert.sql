USE [EShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_Contact_Insert]    Script Date: 11/4/2017 11:28:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_Contact_Insert]
--@Contact_ID int,
@Contact_Name nvarchar(50) ,
@Contact_CellPhone varchar(50) =NULL,
@Contact_Email varchar(50) =NULL,
@Contact_Address nvarchar(max) =NULL,
@Contact_Date datetime =NULL,
@Is_Active bit =NULL
AS
BEGIN
if(@Contact_Name is null or @Contact_Name= '')
	 begin
		Print(N'Tên địa chỉ không được trống')
	 end
else if EXISTS(Select C.Contact_Email from Contact C where C.Contact_Email =@Contact_Email)
	Begin
		Print(N'Không được trùng ' + @Contact_Email)
	end
else if(@Contact_Email is null or @Contact_Email= '')
	 begin
		Print(N'Tên địa chỉ mail không được trống')
	 end

else
	Begin
		INSERT INTO Contact( 
		Contact_Name,
		Contact_CellPhone,
		Contact_Email,
		Contact_Address,
		Contact_Date,
		Is_Active
		)
		VALUES (
		@Contact_Name,
		@Contact_CellPhone,
		@Contact_Email,
		@Contact_Address,
		@Contact_Date,
		@Is_Active
		)
	end
	
END

sp_Contact_Insert 'Gaio','123','Gaio@gmail.com','123','2017-11-04 23:44:36',1

select SysDatetime()