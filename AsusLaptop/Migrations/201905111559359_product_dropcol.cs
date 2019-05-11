namespace AsusLaptop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product_dropcol : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "Count", c => c.Int(nullable: false));
        }
    }
}
