namespace mvc2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movie_v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.Memberships");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int());
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.Memberships", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.Memberships");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Movies", "Genre", c => c.String());
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.Memberships", "Id", cascadeDelete: true);
        }
    }
}
