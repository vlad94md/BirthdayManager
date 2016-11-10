namespace BM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIndentity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BirthdayArrangementUsers", newName: "BirthdayArrangementAppUsers");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.BirthdayArrangements", "BirthdayManId", "dbo.Users");
            DropForeignKey("dbo.Payments", "UserId", "dbo.Users");
            DropIndex("dbo.BirthdayArrangements", new[] { "BirthdayManId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Payments", new[] { "UserId" });
            DropIndex("dbo.BirthdayArrangementAppUsers", new[] { "User_UserId" });
            RenameColumn(table: "dbo.BirthdayArrangementAppUsers", name: "User_UserId", newName: "AppUser_Id");
            DropPrimaryKey("dbo.BirthdayArrangementAppUsers");
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AdditionalId = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AppUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Users", t => t.AppUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.AppUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BirthdayArrangements", "BirthdayMan_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Payments", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.BirthdayArrangementAppUsers", "AppUser_Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.BirthdayArrangementAppUsers", new[] { "BirthdayArrangement_BirthdayArrangementId", "AppUser_Id" });
            CreateIndex("dbo.BirthdayArrangements", "BirthdayMan_Id");
            CreateIndex("dbo.Payments", "User_Id");
            CreateIndex("dbo.BirthdayArrangementAppUsers", "AppUser_Id");
            AddForeignKey("dbo.BirthdayArrangements", "BirthdayMan_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Payments", "User_Id", "dbo.Users", "Id");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropForeignKey("dbo.Payments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BirthdayArrangements", "BirthdayMan_Id", "dbo.Users");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.IdentityUserRoles", "AppUser_Id", "dbo.Users");
            DropForeignKey("dbo.IdentityUserLogins", "AppUser_Id", "dbo.Users");
            DropForeignKey("dbo.IdentityUserClaims", "AppUser_Id", "dbo.Users");
            DropIndex("dbo.BirthdayArrangementAppUsers", new[] { "AppUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "AppUser_Id" });
            DropIndex("dbo.Payments", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "AppUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "AppUser_Id" });
            DropIndex("dbo.BirthdayArrangements", new[] { "BirthdayMan_Id" });
            DropPrimaryKey("dbo.BirthdayArrangementAppUsers");
            AlterColumn("dbo.BirthdayArrangementAppUsers", "AppUser_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Payments", "User_Id");
            DropColumn("dbo.BirthdayArrangements", "BirthdayMan_Id");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.Users");
            AddPrimaryKey("dbo.BirthdayArrangementAppUsers", new[] { "BirthdayArrangement_BirthdayArrangementId", "User_UserId" });
            RenameColumn(table: "dbo.BirthdayArrangementAppUsers", name: "AppUser_Id", newName: "User_UserId");
            CreateIndex("dbo.BirthdayArrangementAppUsers", "User_UserId");
            CreateIndex("dbo.Payments", "UserId");
            CreateIndex("dbo.Users", "RoleId");
            CreateIndex("dbo.BirthdayArrangements", "BirthdayManId");
            AddForeignKey("dbo.Payments", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.BirthdayArrangements", "BirthdayManId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
            RenameTable(name: "dbo.BirthdayArrangementAppUsers", newName: "BirthdayArrangementUsers");
        }
    }
}
