Create Procedure sp_SysFunctionInGroup_GetAll
@PageNumber INT = 1,
@PageSize   INT = 100
as
BEGIN
--var totalCount = this.clubRepository.Clubs.Count(); 
--            var totalPages = Math.Ceiling((double)totalCount / pageSize);
 SET NOCOUNT ON;	
	Select A.*, B.GroupRolesName, C.FunctionName
	From SysFunctionInGroup A
	Left join SysGroupRoles B on A.GroupRolesId=B.GroupRolesId
	Left join SysFunction C on A.FuctionId=C.FunctionId
	ORDER BY A.SysFunctionInGroupId
	OFFSET  @PageSize * (@PageNumber - 1) ROWS -- lấy từ 0 đến ?
	FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE); -- lấy từ ?  đến hết

END