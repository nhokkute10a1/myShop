USE [EShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_Category_GetAll]    Script Date: 11/6/2017 8:31:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[sp_Category_GetAll]
@PageNumber INT = 1,
@PageSize   INT = 100,
@KeyWord nvarchar (255) = ''
as
BEGIN
--var totalCount = this.clubRepository.Clubs.Count(); 
--            var totalPages = Math.Ceiling((double)totalCount / pageSize);
 SET NOCOUNT ON;
	Declare @totalCount int = (select count(1)  FROM Category C Where (C.Category_NameVN like '%'+ @KeyWord + '%' Or C.Category_NameEN like '%'+ @KeyWord + '%'))
	Declare @totalPages Float = CEILING(@totalCount/@PageSize)
	SELECT C.*,@totalCount as totalCount ,@totalPages as totalPages
	FROM Category C 
	Where (C.Category_NameVN like '%'+ @KeyWord + '%' Or C.Category_NameEN like '%'+ @KeyWord + '%')
	ORDER BY c.Category_ID
	OFFSET  @PageSize * (@PageNumber - 1) ROWS -- lấy từ 0 đến ?
	FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE); -- lấy từ ?  đến hết

END

[sp_Category_GetAll] 1,10,'koko'