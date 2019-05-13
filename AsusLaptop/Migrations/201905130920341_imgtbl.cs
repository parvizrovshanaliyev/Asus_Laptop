namespace AsusLaptop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgtbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Imgsmultiple",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Imgsmultiple");
        }
    }
}
