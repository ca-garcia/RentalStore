namespace mvc2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populate_Memberships : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO Memberships (Id, Fee, DurationInMonths, Discount) VALUES (1,0,0,0)");
            Sql("INSERT INTO Memberships (Fee, DurationInMonths, Discount) VALUES (0,0,0)");
            //Sql("INSERT INTO Memberships (Id, Fee, DurationInMonths, Discount) VALUES (2,30,1,5)");
            Sql("INSERT INTO Memberships (Fee, DurationInMonths, Discount) VALUES (30,1,5)");
            //Sql("INSERT INTO Memberships (Id, Fee, DurationInMonths, Discount) VALUES (3,60,3,10)");
            Sql("INSERT INTO Memberships (Fee, DurationInMonths, Discount) VALUES (60,3,10)");
            //Sql("INSERT INTO Memberships (Id, Fee, DurationInMonths, Discount) VALUES (4,120,12,20)");
            Sql("INSERT INTO Memberships (Fee, DurationInMonths, Discount) VALUES (120,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
