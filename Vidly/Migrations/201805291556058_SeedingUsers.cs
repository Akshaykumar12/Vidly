namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'384e4653-1ed6-4b5c-8632-795156db5856', N'admin@gmail.com', 0, N'AKjDMe0X4ufNRbMJO2NV6W+fL4p7E38yAHryebuCNrnakjbDZSP7dvuhbPRuJcGWiQ==', N'b1518309-a5f8-45b5-8ea4-d26d09f85a97', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')");
            Sql("INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'69a2d48b-baf7-4b9f-910d-876f26efb4b0', N'guest@gmail.com', 0, N'ACQrurztQ7oQMXm2XWF4TpLs1DWFzvhsZyVKgTSNblH1YWyw8I0ZIvYfTakV5edGZA==', N'ed0118e0-06db-476f-bd2f-f7bff390eecf', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'34bb421e-a18c-4783-8023-b37f142d24e1', N'CanManageMovies')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'384e4653-1ed6-4b5c-8632-795156db5856', N'34bb421e-a18c-4783-8023-b37f142d24e1')");
        }
        
        public override void Down()
        {
        }
    }
}
