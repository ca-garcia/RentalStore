namespace mvc2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnnotationsMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            AddColumn("dbo.Movies", "Duration", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "Duration");
            DropColumn("dbo.Movies", "Genre");
        }
    }
}
