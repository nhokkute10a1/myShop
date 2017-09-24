CREATE PROCEDURE sp_Advertisement_Update 
@Advertisement_ID int,
@Advertisement_NameVN nvarchar(50),
@Advertisement_NameEN nvarchar(50),
@Advertisement_UrlOut nvarchar(255) = NULL,
@Advertisement_Rewrite nvarchar(255),
@Advertisement_SearchVN varchar(50) = NULL,
@Advertisement_SearchEN varchar(50) = NULL,
@Advertisement_ContentVN nvarchar(max) = NULL,
@Advertisement_ContentEN nvarchar(max) = NULL,
@Advertisement_DescriptionVN nvarchar(max) = NULL,
@Advertisement_DescriptionEN nvarchar(max) = NULL,
@Advertisement_Img varchar(255) = NULL,
@Img_Width int = NULL,
@Img_Unit_Width varchar(10) = NULL,
@Img_Height int = NULL,
@Img_Unit_Height varchar(10) = NULL,
@Keyword_Titile nvarchar(50) = NULL,
@Keyword_Content nvarchar(max) = NULL,
@Keyword_Description nvarchar(max) = NULL,
@CreateDate datetime = NULL,
@CreateBy int = NULL,
@UpdateDate datetime = NULL,
@UpdateBy int = NULL,
@Lock int = NULL,
@Is_Active bit = NULL,
@Is_TopPage bit = NULL,
@Is_LeftPage bit = NULL,
@Is_RightPage bit = NULL,
@Is_BottomPage bit = NULL,
@Display_Order int = NULL
AS
BEGIN
  UPDATE A
  SET A.Advertisement_NameVN = @Advertisement_NameVN,
      A.Advertisement_NameEN = @Advertisement_NameEN,
      A.Advertisement_UrlOut = @Advertisement_UrlOut,
      A.Advertisement_Rewrite = @Advertisement_Rewrite,
      A.Advertisement_SearchVN = @Advertisement_SearchVN,
      A.Advertisement_SearchEN = @Advertisement_SearchEN,
      A.Advertisement_ContentVN = @Advertisement_ContentVN,
      A.Advertisement_ContentEN = @Advertisement_ContentEN,
      A.Advertisement_DescriptionVN = @Advertisement_DescriptionVN,
      A.Advertisement_DescriptionEN = @Advertisement_DescriptionEN,
      A.Advertisement_Img = @Advertisement_Img,
      A.Img_Width = @Img_Width,
      A.Img_Unit_Width = @Img_Unit_Width,
      A.Img_Height = @Img_Height,
      A.Img_Unit_Height = @Img_Unit_Height,
      A.Keyword_Titile = @Keyword_Titile,
      A.Keyword_Content = @Keyword_Content,
      A.Keyword_Description = @Keyword_Description,
      A.CreateDate = @CreateDate,
      A.CreateBy = @CreateBy,
      A.UpdateDate = @UpdateDate,
      A.UpdateBy = @UpdateBy,
      A.Lock = @Lock,
      A.Is_Active = @Is_Active,
      A.Is_TopPage = @Is_TopPage,
      A.Is_LeftPage = @Is_LeftPage,
      A.Is_RightPage = @Is_RightPage,
      A.Is_BottomPage = @Is_BottomPage,
      A.Display_Order = @Display_Order
  FROM Advertisement A
  WHERE A.Advertisement_ID = @Advertisement_ID
END