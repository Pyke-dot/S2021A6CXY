namespace S2021A6CXY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trackclipcontentType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "ClipContentType", c => c.String(maxLength: 200));
            AddColumn("dbo.Tracks", "Clip", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tracks", "Clip");
            DropColumn("dbo.Tracks", "ClipContentType");
        }
    }
}
