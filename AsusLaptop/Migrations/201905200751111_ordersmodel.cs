namespace AsusLaptop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordersmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "AcceptedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Order", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.OrderItem", "Color");
            DropColumn("dbo.OrderItem", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItem", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItem", "Color", c => c.String(maxLength: 50));
            AlterColumn("dbo.Order", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "AcceptedDate");
        }
    }
}
