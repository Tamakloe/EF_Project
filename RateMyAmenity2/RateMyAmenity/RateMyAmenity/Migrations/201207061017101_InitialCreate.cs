namespace RateMyAmenity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 4000),
                        Email = c.String(maxLength: 4000),
                        Password = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        RatingValue = c.Single(nullable: false),
                        Comments = c.String(maxLength: 4000),
                        Image = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.RatingID);
            
            CreateTable(
                "dbo.Amenities",
                c => new
                    {
                        AmenityID = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 4000),
                        Name = c.String(maxLength: 4000),
                        Address1 = c.String(maxLength: 4000),
                        Address2 = c.String(maxLength: 4000),
                        Address3 = c.String(maxLength: 4000),
                        Address4 = c.String(maxLength: 4000),
                        Phone = c.String(maxLength: 4000),
                        Email = c.String(maxLength: 4000),
                        Website = c.String(maxLength: 4000),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                        DefaultImage = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.AmenityID);
            
            CreateTable(
                "dbo.RatingUsers",
                c => new
                    {
                        Rating_RatingID = c.Int(nullable: false),
                        User_UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Rating_RatingID, t.User_UserID })
                .ForeignKey("dbo.Ratings", t => t.Rating_RatingID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .Index(t => t.Rating_RatingID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.AmenityRatings",
                c => new
                    {
                        Amenity_AmenityID = c.Int(nullable: false),
                        Rating_RatingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Amenity_AmenityID, t.Rating_RatingID })
                .ForeignKey("dbo.Amenities", t => t.Amenity_AmenityID, cascadeDelete: true)
                .ForeignKey("dbo.Ratings", t => t.Rating_RatingID, cascadeDelete: true)
                .Index(t => t.Amenity_AmenityID)
                .Index(t => t.Rating_RatingID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AmenityRatings", new[] { "Rating_RatingID" });
            DropIndex("dbo.AmenityRatings", new[] { "Amenity_AmenityID" });
            DropIndex("dbo.RatingUsers", new[] { "User_UserID" });
            DropIndex("dbo.RatingUsers", new[] { "Rating_RatingID" });
            DropForeignKey("dbo.AmenityRatings", "Rating_RatingID", "dbo.Ratings");
            DropForeignKey("dbo.AmenityRatings", "Amenity_AmenityID", "dbo.Amenities");
            DropForeignKey("dbo.RatingUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.RatingUsers", "Rating_RatingID", "dbo.Ratings");
            DropTable("dbo.AmenityRatings");
            DropTable("dbo.RatingUsers");
            DropTable("dbo.Amenities");
            DropTable("dbo.Ratings");
            DropTable("dbo.Users");
        }
    }
}
