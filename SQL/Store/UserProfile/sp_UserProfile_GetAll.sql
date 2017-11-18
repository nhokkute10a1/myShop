Create Procedure sp_UserProfile_GetAll
@PageNumber INT = 1,
@PageSize   INT = 100
as
BEGIN
--var totalCount = this.clubRepository.Clubs.Count(); 
--            var totalPages = Math.Ceiling((double)totalCount / pageSize);
 SET NOCOUNT ON;	
	Select U.*
	From UserProfile U
	ORDER BY U.UserProfile_ID
	OFFSET  @PageSize * (@PageNumber - 1) ROWS -- lấy từ 0 đến ?
	FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE); -- lấy từ ?  đến hết

END

sp_UserProfile_GetAll 1,10