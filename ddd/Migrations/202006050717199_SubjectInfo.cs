namespace ddd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubjectInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "Room", c => c.String());
            AddColumn("dbo.Subjects", "CourseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "CourseName");
            DropColumn("dbo.Subjects", "Room");
        }
    }
}
