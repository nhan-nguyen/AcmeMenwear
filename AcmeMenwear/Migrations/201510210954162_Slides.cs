namespace AcmeMenwear.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Slides : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SlideImgs",
                c => new
                    {
                        SlideImgId = c.Int(nullable: false, identity: true),
                        SlideImgName = c.String(maxLength: 255),
                        SlideImgContentType = c.String(maxLength: 100),
                        SlideImgContent = c.Binary(),
                        FileType = c.Int(nullable: false),
                        SlideId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SlideImgId)
                .ForeignKey("dbo.Slides", t => t.SlideId, cascadeDelete: true)
                .Index(t => t.SlideId);
            
            CreateTable(
                "dbo.Slides",
                c => new
                    {
                        SlideId = c.Int(nullable: false, identity: true),
                        SlideLink = c.String(nullable: false, maxLength: 100),
                        SlideDescription = c.String(),
                    })
                .PrimaryKey(t => t.SlideId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SlideImgs", "SlideId", "dbo.Slides");
            DropIndex("dbo.SlideImgs", new[] { "SlideId" });
            DropTable("dbo.Slides");
            DropTable("dbo.SlideImgs");
        }
    }
}
