namespace MICRO.WMS.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.USERINFOR", "USERDEPT", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.USERINFOR", "USERDEPT");
        }
    }
}
