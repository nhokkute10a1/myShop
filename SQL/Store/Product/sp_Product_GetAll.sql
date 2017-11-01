Create Procedure [dbo].[sp_Product_GetAll]
as
BEGIN
	SELECT C.Category_NameVN,
	P.*
	FROM Product P
	Left Join Category C on P.Category_Parent_ID= C.Category_ID
END