namespace MICRO.WMS.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.USERINFOR", "OP_POINT", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.USERINFOR", "OP_POINT");
        }
    }
}
