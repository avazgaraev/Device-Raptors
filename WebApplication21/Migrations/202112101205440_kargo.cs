namespace WebApplication21.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kargo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.kargofollows",
                c => new
                    {
                        kargofollowid = c.Int(nullable: false, identity: true),
                        kargono = c.String(maxLength: 25, unicode: false),
                        kargodetail = c.String(maxLength: 100, unicode: false),
                        kargofoldate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.kargofollowid);
            
            CreateTable(
                "dbo.kargoes",
                c => new
                    {
                        kargodetid = c.Int(nullable: false, identity: true),
                        kargodetail = c.String(maxLength: 300, unicode: false),
                        kargono = c.String(maxLength: 10, unicode: false),
                        kargorec = c.String(maxLength: 50, unicode: false),
                        kargodate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.kargodetid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.kargoes");
            DropTable("dbo.kargofollows");
        }
    }
}
