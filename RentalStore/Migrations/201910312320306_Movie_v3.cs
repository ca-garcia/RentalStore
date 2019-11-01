namespace mvc2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movie_v3 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET GenreTypeId = 5 WHERE id = 1;");
            Sql("UPDATE Movies SET GenreTypeId = 2 WHERE id = 2;");
            Sql("UPDATE Movies SET GenreTypeId = 2 WHERE id = 3;");
            Sql("UPDATE Movies SET GenreTypeId = 1 WHERE id = 4;");
            Sql("UPDATE Movies SET GenreTypeId = 1 WHERE id = 5;");

            DropForeignKey("dbo.Movies", "GenreTypeId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreTypeId" });
            AlterColumn("dbo.Movies", "GenreTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreTypeId");
            AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.Genres", "Id", cascadeDelete: true);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreTypeId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreTypeId" });
            AlterColumn("dbo.Movies", "GenreTypeId", c => c.Int());
            CreateIndex("dbo.Movies", "GenreTypeId");
            AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.Genres", "Id");
        }
    }
}
