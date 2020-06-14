namespace Historical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePodaci : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Podacis",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Timestamp = c.String(),
                        AreaID = c.String(),
                        Consumption = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Podacis");
        }
    }
}
