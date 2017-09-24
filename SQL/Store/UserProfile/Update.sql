Create Procedure sp_UserProfile_Update
@UserProfile_ID int ,
@UserProfile_LastName nvarchar(50) ,
@UserProfile_FirstName nvarchar(50) ,
@UserProfile_FullName nvarchar(255) ,
@UserProfile_Birth_Day int ,
@UserProfile_Birth_Month int ,
@UserProfile_Birth_Year int ,
@UserProfile_Age int =NULL,
@UserProfile_Gender nvarchar(10) ,
@UserProfile_Phone varchar(20) ,
@UserProfile_Email varchar(50) ,
@UserProfile_Pass varchar(50) ,
@UserProfile_About_Me nvarchar(max) =NULL,
@UserProfile_Avatar varchar(500) =NULL,
@UserProfile_ConnectID varchar(max) =NULL,
@CreateDate datetime =NULL,
@UpdateDate datetime =NULL,
@Lock int =NULL,
@Is_Active bit =NULL
as
begin
	Update Ur
	Set Ur.UserProfile_LastName=@UserProfile_LastName,
      Ur.UserProfile_FirstName=@UserProfile_FirstName,
      Ur.UserProfile_FullName=@UserProfile_FullName,
      Ur.UserProfile_Birth_Day=@UserProfile_Birth_Day,
      Ur.UserProfile_Birth_Month=@UserProfile_Birth_Month,
      Ur.UserProfile_Birth_Year=@UserProfile_Birth_Year,
      Ur.UserProfile_Age=@UserProfile_Age,
      Ur.UserProfile_Gender=@UserProfile_Gender,
      Ur.UserProfile_Phone=@UserProfile_Phone,
      Ur.UserProfile_Email=@UserProfile_Email,
      Ur.UserProfile_Pass=@UserProfile_Pass,
      Ur.UserProfile_About_Me=@UserProfile_About_Me,
      Ur.UserProfile_Avatar=@UserProfile_Avatar,
      Ur.UserProfile_ConnectID=@UserProfile_ConnectID,
      Ur.CreateDate=@CreateDate,
      Ur.UpdateDate=@UpdateDate,
      Ur.Lock=@Lock,
      Ur.Is_Active=@Is_Active
	From UserProfile Ur
	Where Ur.UserProfile_ID=@UserProfile_ID
end