namespace MICRO.WMS.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mac11241830 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemuInfor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MemuName = c.String(maxLength: 50),
                        MemuCode = c.String(maxLength: 50),
                        FatherMemu = c.String(maxLength: 50),
                        FatherMemuCode = c.String(maxLength: 50),
                        MemuStatus = c.String(maxLength: 10),
                        REMARK = c.String(maxLength: 500),
                        ADDWHO = c.String(maxLength: 20),
                        ADDID = c.String(maxLength: 20),
                        ADDTS = c.DateTime(),
                        EDITWHO = c.String(maxLength: 20),
                        EDITID = c.String(maxLength: 50),
                        EDITTS = c.DateTime(),
                        OP_POINT = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MemuInfor");
        }
    }
}
