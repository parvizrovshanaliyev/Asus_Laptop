namespace AsusLaptop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Token", c => c.String());
            DropColumn("dbo.AspNetUsers", "CreateAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CreateAt", c => c.DateTime());
            DropColumn("dbo.AspNetUsers", "Token");
        }
    }
}
