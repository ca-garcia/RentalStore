namespace mvc2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genre3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreTypeId", c => c.Int());
            CreateIndex("dbo.Movies", "GenreTypeId");
            AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.Genres", "Id");
            DropColumn("dbo.Movies", "Genre");

            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) VALUES ('Drama')");
            Sql("INSERT INTO Genres (Name) VALUES ('Romance')");
            Sql("INSERT INTO Genres (Name) VALUES ('Adventure')");
            Sql("INSERT INTO Genres (Name) VALUES ('ScFi')");
            Sql("INSERT INTO Genres (Name) VALUES ('Terror')");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
            DropForeignKey("dbo.Movies", "GenreTypeId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreTypeId" });
            DropColumn("dbo.Movies", "GenreTypeId");
            DropTable("dbo.Genres");
        }
    }
}
