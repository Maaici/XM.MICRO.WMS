using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MICRO.WMS.WEB.Models
{
    public class WebDbContext : DataContext
    {
        //在config中配置数据库的名称
        //private static string dbName = System.Configuration.ConfigurationManager.AppSettings["dbName"];

        public WebDbContext() : base("Name=wmsConn")
        {
            //解决团队开发中，多人迁移数据库造成的修改覆盖问题。
            Database.SetInitializer<WebDbContext>(null);
            //base.Configuration.AutoDetectChangesEnabled = false;
            ////关闭EF6.x 默认自动生成null判断语句
            //base.Configuration.UseDatabaseNullSemantics = true;
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //表名不用复数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //移除一对多的级联删除约定，想要级联删除可以在 EntityTypeConfiguration<TEntity>的实现类中进行控制
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //多对多启用级联删除约定，不想级联删除可以在删除前判断关联的数据进行拦截
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        //下面放置的是数据库对应的实体对象
        public DbSet<USERINOR> UserInfor { get; set; }

    }
}