namespace PetGrooming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class groomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groomers",
                c => new
                    {
                        GroomerID = c.Int(nullable: false, identity: true),
                        GroomerFName = c.String(),
                        GroomerLName = c.String(),
                        GroomerPhone = c.String(),
                        GroomerDOB = c.DateTime(nullable: false),
                        GroomerRate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Groomers");
        }
    }
}
