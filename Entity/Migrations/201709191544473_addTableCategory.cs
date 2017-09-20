namespace Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Category_ID = c.Int(nullable: false, identity: true),
                        Category_Parent_ID = c.Int(nullable: false),
                        Category_NameVN = c.String(nullable: false, maxLength: 50),
                        Category_NameEN = c.String(nullable: false, maxLength: 50),
                        Category_UrlOut = c.String(maxLength: 255),
                        Category_Rewrite = c.String(nullable: false, maxLength: 255),
                        Category_SearchVN = c.String(maxLength: 50, unicode: false),
                        Category_SearchEN = c.String(maxLength: 50, unicode: false),
                        Category_Icon = c.String(maxLength: 255, unicode: false),
                        Category_Img = c.String(maxLength: 255, unicode: false),
                        Keyword_Titile = c.String(maxLength: 50),
                        Keyword_Content = c.String(),
                        Keyword_Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.Int(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        UpdateBy = c.Int(nullable: false),
                        Lock = c.Int(nullable: false),
                        Is_Active = c.Boolean(nullable: false),
                        Is_HomePage = c.Boolean(nullable: false),
                        Is_TopMenu = c.Boolean(nullable: false),
                        Is_BottomMenu = c.Boolean(nullable: false),
                        Display_Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Category_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Category");
        }
    }
}
