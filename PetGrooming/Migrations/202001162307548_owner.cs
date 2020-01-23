namespace PetGrooming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class owner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroomBookings",
                c => new
                    {
                        GroomBookingID = c.Int(nullable: false, identity: true),
                        GroomBookingTime = c.DateTime(nullable: false),
                        GroomBookingCost = c.Double(nullable: false),
                        GroomerID = c.Int(nullable: false),
                        PetID = c.Int(nullable: false),
                        OwnerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroomBookingID)
                .ForeignKey("dbo.Groomers", t => t.GroomerID, cascadeDelete: true)
                .ForeignKey("dbo.Owners", t => t.OwnerID, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.PetID, cascadeDelete: true)
                .Index(t => t.GroomerID)
                .Index(t => t.PetID)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.GroomServices",
                c => new
                    {
                        GroomServiceID = c.Int(nullable: false, identity: true),
                        GroomServiceName = c.String(),
                        GroomServiceCost = c.Double(nullable: false),
                        GroomServiceDuration = c.String(),
                        GroomBooking_GroomBookingID = c.Int(),
                    })
                .PrimaryKey(t => t.GroomServiceID)
                .ForeignKey("dbo.GroomBookings", t => t.GroomBooking_GroomBookingID)
                .Index(t => t.GroomBooking_GroomBookingID);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerID = c.Int(nullable: false, identity: true),
                        OwnerFName = c.String(),
                        OwnerLName = c.String(),
                        OwnerAddress = c.String(),
                        OwnerHomePhone = c.String(),
                        OwnerWorkPhone = c.String(),
                    })
                .PrimaryKey(t => t.OwnerID);
            
            AddColumn("dbo.Pets", "Owner_OwnerID", c => c.Int());
            CreateIndex("dbo.Pets", "Owner_OwnerID");
            AddForeignKey("dbo.Pets", "Owner_OwnerID", "dbo.Owners", "OwnerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroomBookings", "PetID", "dbo.Pets");
            DropForeignKey("dbo.GroomBookings", "OwnerID", "dbo.Owners");
            DropForeignKey("dbo.Pets", "Owner_OwnerID", "dbo.Owners");
            DropForeignKey("dbo.GroomServices", "GroomBooking_GroomBookingID", "dbo.GroomBookings");
            DropForeignKey("dbo.GroomBookings", "GroomerID", "dbo.Groomers");
            DropIndex("dbo.Pets", new[] { "Owner_OwnerID" });
            DropIndex("dbo.GroomServices", new[] { "GroomBooking_GroomBookingID" });
            DropIndex("dbo.GroomBookings", new[] { "OwnerID" });
            DropIndex("dbo.GroomBookings", new[] { "PetID" });
            DropIndex("dbo.GroomBookings", new[] { "GroomerID" });
            DropColumn("dbo.Pets", "Owner_OwnerID");
            DropTable("dbo.Owners");
            DropTable("dbo.GroomServices");
            DropTable("dbo.GroomBookings");
        }
    }
}
