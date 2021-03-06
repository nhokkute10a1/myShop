USE [EShop]
GO
/****** Object:  StoredProcedure [dbo].[sp_SysUserInGroup_GetById]    Script Date: 11/16/2017 1:34:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sp_SysUserInGroup_GetById]
@SysUserInGroupId int
as
begin
	SELECT s.*, u.UserProfile_Email,a.GroupRolesName
	FROM SysUserInGroup s
	Left Join UserProfile u on s.UserId =u.UserProfile_ID
	Left Join SysGroupRoles a on s.GroupRolesId=a.GroupRolesId
	where s.SysUserInGroupId=@SysUserInGroupId
end