namespace mvc2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Membership_v3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Memberships", "Name", c => c.String(nullable: false));

            Sql("UPDATE Memberships SET Name = 'No Member' WHERE id = 1;");
            Sql("UPDATE Memberships SET Name = 'Bronze Member' WHERE id = 2;");
            Sql("UPDATE Memberships SET Name = 'Silver Member' WHERE id = 3;");
            Sql("UPDATE Memberships SET Name = 'Gold Member' WHERE id = 4;");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Memberships", "Name", c => c.Short(nullable: false));
        }
    }
}
