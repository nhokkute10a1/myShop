Create Procedure sp_SysUserInGroup_GetAll
@PageNumber INT = 1,
@PageSize   INT = 100
as
BEGIN
--var totalCount = this.clubRepository.Clubs.Count(); 
--            var totalPages = Math.Ceiling((double)totalCount / pageSize);
 SET NOCOUNT ON;	
	SELECT s.*, u.UserProfile_Email,a.GroupRolesName
	FROM SysUserInGroup s
	Left Join UserProfile u on s.UserId =u.UserProfile_ID
	Left Join SysGroupRoles a on s.GroupRolesId=a.GroupRolesId
	ORDER BY s.SysUserInGroupId
	OFFSET  @PageSize * (@PageNumber - 1) ROWS -- lấy từ 0 đến ?
	FETCH NEXT @PageSize ROWS ONLY OPTION (RECOMPILE); -- lấy từ ?  đến hết

END