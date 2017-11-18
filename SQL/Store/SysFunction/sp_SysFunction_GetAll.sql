Create Procedure sp_SysFunction_GetAll
@PageNumber INT = 1,
@PageSize   INT = 100
as
BEGIN
--var totalCount = this.clubRepository.Clubs.Count(); 
--            var totalPages = Math.Ceiling((double)totalCount / pageSize);
 SET NOCOUNT ON;	
	Select A.*,B.SysFunctionGroupName
	From SysFunction A
	Left join  SysFunctionGroup B on A.SysFunctionGroupId=B.SysFunctionGroupId
	ORDER BY A.FunctionId
	OFFSET  @PageSize * (@PageNumber - 1) ROWS -- lấy từ 0 đến ?
	FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE); -- lấy từ ?  đến hết

END