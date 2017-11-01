Create Procedure [dbo].[sp_Product_GetAllById]
@Product_ID int
as
BEGIN
	SELECT P.*, C.Category_NameVN
	FROM Product P 
	Left Join Category C on P.Category_Parent_ID= C.Category_ID
	Where P.Product_ID=@Product_ID
END