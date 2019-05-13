namespace AsusLaptop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product_isnew_cilumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "IsNew", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "IsNew");
        }
    }
}
