--select * from [dbo].[Category]

--EXISTS: ton tai
--NO EXISTS: ko ton tai
declare @Category_NameVN nvarchar(255) = N'death'

If EXISTS (select A.Category_NameVN from [dbo].[Category] A Where A.Category_NameVN = @Category_NameVN)
	Begin
		Print(N'Trùng tên ' + @Category_NameVN)
	End
Else
	Begin
		Print(N'OK')
	End


---Check-Null-Or-Exists---
--is null: khong dc rong
declare @Category_NameVN1 nvarchar(255)
Set @Category_NameVN1 ='sdd'
if (@Category_NameVN1  is null or @Category_NameVN1='')
	Begin
		Print(N'Null')
	End
Else
	Begin
		Print(N'OK')
	End