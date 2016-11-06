namespace BM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BirthdayArrangements",
                c => new
                    {
                        BirthdayArrangementId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        GiftId = c.Int(nullable: false),
                        BirthdayManId = c.Int(nullable: false),
                        BirthdayMan_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BirthdayArrangementId)
                .ForeignKey("dbo.Users", t => t.BirthdayMan_Id)
                .ForeignKey("dbo.Gifts", t => t.GiftId, cascadeDelete: true)
                .Index(t => t.GiftId)
                .Index(t => t.BirthdayMan_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AdditionalId = c.Int(nullable: false),
                        OldUsername = c.String(nullable: false, maxLength: 100),
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
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
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
                "dbo.Gifts",
                c => new
                    {
                        GiftId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.GiftId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DateCreated = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Gadgets",
                c => new
                    {
                        GadgetID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 8, scale: 2),
                        Image = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GadgetID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BirthdayArrangementAppUsers",
                c => new
                    {
                        BirthdayArrangement_BirthdayArrangementId = c.Int(nullable: false),
                        AppUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.BirthdayArrangement_BirthdayArrangementId, t.AppUser_Id })
                .ForeignKey("dbo.BirthdayArrangements", t => t.BirthdayArrangement_BirthdayArrangementId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.AppUser_Id, cascadeDelete: true)
                .Index(t => t.BirthdayArrangement_BirthdayArrangementId)
                .Index(t => t.AppUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Gadgets", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.BirthdayArrangementAppUsers", "AppUser_Id", "dbo.Users");
            DropForeignKey("dbo.BirthdayArrangementAppUsers", "BirthdayArrangement_BirthdayArrangementId", "dbo.BirthdayArrangements");
            DropForeignKey("dbo.BirthdayArrangements", "GiftId", "dbo.Gifts");
            DropForeignKey("dbo.IdentityUserRoles", "AppUser_Id", "dbo.Users");
            DropForeignKey("dbo.Payments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.IdentityUserLogins", "AppUser_Id", "dbo.Users");
            DropForeignKey("dbo.IdentityUserClaims", "AppUser_Id", "dbo.Users");
            DropForeignKey("dbo.BirthdayArrangements", "BirthdayMan_Id", "dbo.Users");
            DropIndex("dbo.BirthdayArrangementAppUsers", new[] { "AppUser_Id" });
            DropIndex("dbo.BirthdayArrangementAppUsers", new[] { "BirthdayArrangement_BirthdayArrangementId" });
            DropIndex("dbo.Gadgets", new[] { "CategoryID" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "AppUser_Id" });
            DropIndex("dbo.Payments", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "AppUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "AppUser_Id" });
            DropIndex("dbo.BirthdayArrangements", new[] { "BirthdayMan_Id" });
            DropIndex("dbo.BirthdayArrangements", new[] { "GiftId" });
            DropTable("dbo.BirthdayArrangementAppUsers");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Gadgets");
            DropTable("dbo.Categories");
            DropTable("dbo.Gifts");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.Payments");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.BirthdayArrangements");
        }
    }
}
