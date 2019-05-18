namespace AsusLaptop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Title = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 300),
                        ImageL = c.String(maxLength: 300),
                        ImageS = c.String(maxLength: 300),
                        CreateAt = c.DateTime(nullable: false),
                        UpdateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Imgsmultiple");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Imgsmultiple",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Blog");
        }
    }
}
