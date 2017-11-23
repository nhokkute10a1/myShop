DELETE 
FROM SysFunction

DELETE 
FROM SysFunctionGroup

DELETE 
FROM SysFunctionInGroup

DELETE 
FROM SysGroupRoles

DELETE 
FROM SysUserInGroup

--reset idetity
DBCC CHECKIDENT ('SysUserInGroup', RESEED, 0);