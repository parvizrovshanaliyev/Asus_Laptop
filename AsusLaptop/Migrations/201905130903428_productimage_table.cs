namespace AsusLaptop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productimage_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Image = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImage", "ProductId", "dbo.Product");
            DropIndex("dbo.ProductImage", new[] { "ProductId" });
            DropTable("dbo.ProductImage");
        }
    }
}
