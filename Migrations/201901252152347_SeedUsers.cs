namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2a0887b9-1b69-4bea-9658-0d3a4b88af89', N'admin@vidly.com', 0, N'AHQ5o50nlbHOxHr4zyLH4EvHJqRRpdEBFd6fWX4roFns9N2bjNX8ZMP27Uf6Lq2pGA==', N'82c5e8fa-e5f4-4390-944a-1606b5692d89', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd1426c9d-4403-4ded-a948-f4d0db162768', N'guest@domain.com', 0, N'ABAgpgIGQxyr3kCHb/rgjrPZfYlP0nPqNg66lk3pbvxI4R90aMzFM9MGKA/zc1zgMA==', N'60476a23-7ada-4bfa-9d40-2113728bde52', NULL, 0, 0, NULL, 1, 0, N'guest@domain.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'837f19a1-8314-446f-8eea-24e9100d1fa6', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2a0887b9-1b69-4bea-9658-0d3a4b88af89', N'837f19a1-8314-446f-8eea-24e9100d1fa6')

");
        }
        
        public override void Down()
        {
        }
    }
}
