namespace AccidentRepost.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        lat = c.String(),
                        lon = c.String(),
                        video_url = c.String(),
                        date = c.String(),
                        important = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
