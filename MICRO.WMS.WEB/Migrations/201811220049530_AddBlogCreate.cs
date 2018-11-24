namespace MICRO.WMS.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.USERINFOR",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        USERNAME = c.String(maxLength: 20),
                        USERCODE = c.String(maxLength: 20),
                        USERROLE = c.String(maxLength: 20),
                        REMARK = c.String(maxLength: 500),
                        ADDWHO = c.String(maxLength: 20),
                        ADDID = c.String(maxLength: 20),
                        ADDTS = c.DateTime(),
                        EDITWHO = c.String(maxLength: 20),
                        EDITID = c.String(maxLength: 50),
                        EDITTS = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.USERINFOR");
        }
    }
}
