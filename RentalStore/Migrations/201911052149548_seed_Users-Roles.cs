namespace mvc2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed_UsersRoles : DbMigration
    {
        public override void Up()
        {
            //Password all users: Qwerty1*
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8a79e096-052b-4057-9683-7a7443aa305a', N'admin@domain.com', 0, N'AJSiH2aeyttGIFGiUdDI85MUgb9/gKDxVDcCS5NjZbtXtno9N1xjUqLUA66hb82iOQ==', N'467b70f2-2e2d-43b5-aa43-df05fb57d231', NULL, 0, 0, NULL, 1, 0, N'admin@domain.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b38fafbd-3156-440a-88ab-851b2433fefc', N'guest@domain.com', 0, N'AJSiH2aeyttGIFGiUdDI85MUgb9/gKDxVDcCS5NjZbtXtno9N1xjUqLUA66hb82iOQ==', N'bb97d846-7e91-4b40-a1cd-94e996ffa47c', NULL, 0, 0, NULL, 1, 0, N'guest@domain.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'mf696c9b-fa26-4f46-b2b1-ad753ea50361', N'CanManageMovies')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cf696c9b-fa26-4f46-b2b1-ad753ea50361', N'CanManageCustomers')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8a79e096-052b-4057-9683-7a7443aa305a', N'cf696c9b-fa26-4f46-b2b1-ad753ea50361')
");
        }
        
        public override void Down()
        {
        }
    }
}
