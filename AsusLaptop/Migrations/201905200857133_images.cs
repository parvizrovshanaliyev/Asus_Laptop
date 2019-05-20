namespace AsusLaptop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class images : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItem", "ImageS", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItem", "ImageS");
        }
    }
}
