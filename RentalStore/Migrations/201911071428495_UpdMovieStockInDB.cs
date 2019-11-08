namespace mvc2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdMovieStockInDB : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET NumberInStock = 20");
            Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
        }
    }
}
