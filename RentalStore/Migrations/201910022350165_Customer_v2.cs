namespace mvc2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer_v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fee = c.Short(nullable: false),
                        DurationInMonths = c.Short(nullable: false),
                        Discount = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "IsSubscribe", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.Memberships", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.Memberships");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            DropColumn("dbo.Customers", "IsSubscribe");
            DropTable("dbo.Memberships");
        }
    }
}
