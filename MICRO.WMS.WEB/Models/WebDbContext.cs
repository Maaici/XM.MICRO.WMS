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
        public DbSet<USERINFOR> UserInfor { get; set; }
        public DbSet<MemuInfor> MemuInfor { get; set; }

        public override int SaveChanges()
        {
            int ret = 0;
            var Entitys = ChangeTracker.Entries();
            //没有变动跳过
            if (Entitys.Any(_e => _e.State != EntityState.Unchanged))
            {
                string CurrentUserId = "Y10112116";
                string CurrentUserName = "马爱慈";
                var CurrentUserOperatePoint = new List<OperationPoint>();

                //新增时需要自动设置的字段
                List<string> insertAutoProps = new List<string> { "ADDWHO", "ADDTS", "ADDID" };
                //修改时需要自动设置的字段
                List<string> updateAutoProps = new List<string> { "EDITWHO", "EDITTS", "EDITID" };

                try
                {

                    #region 获取所有新增的数据

                    var _entitiesAdded = Entitys.Where(_e => _e.State == EntityState.Added).ToList();

                    foreach (var entityitem in _entitiesAdded)
                    {
                        var _entity = entityitem.Entity;
                        var _entityProptys = _entity.GetType().GetProperties();

                        //自动设置属性
                        var AutoSetProtityS = _entityProptys.Where(x => insertAutoProps.Contains(x.Name));

                        foreach (var propinfo in AutoSetProtityS)
                        {
                            #region 自动设置

                            if (propinfo.Name == "ADDID")
                            {
                                if (propinfo.GetValue(_entity) != null)
                                {
                                    if (string.IsNullOrEmpty(propinfo.GetValue(_entity).ToString()))
                                    {
                                        propinfo.SetValue(_entity, CurrentUserId);
                                    }
                                }
                                else
                                    propinfo.SetValue(_entity, CurrentUserId);
                            }

                            if (propinfo.Name == "ADDWHO")
                            {
                                if (propinfo.GetValue(_entity) != null)
                                {
                                    if (string.IsNullOrEmpty(propinfo.GetValue(_entity).ToString()))
                                    {
                                        propinfo.SetValue(_entity, CurrentUserName);
                                    }
                                }
                                else
                                    propinfo.SetValue(_entity, CurrentUserName);
                            }

                            if (propinfo.Name == "ADDTS")
                            {
                                if (propinfo.GetValue(_entity) != null)
                                {
                                    if (string.IsNullOrEmpty(propinfo.GetValue(_entity).ToString()))
                                    {
                                        propinfo.SetValue(_entity, DateTime.Now);
                                    }
                                }
                                else
                                    propinfo.SetValue(_entity, DateTime.Now);
                            }

                            if (propinfo.Name == "OP_POINT")//操作点
                            {
                                var ObjOperatingPoint = propinfo.GetValue(_entity);
                                int OperatePointListID = 0;
                                if (ObjOperatingPoint != null)
                                {
                                    if (int.TryParse(ObjOperatingPoint.ToString(), out OperatePointListID))
                                    {
                                        if (OperatePointListID == 0)
                                        {
                                            if (CurrentUserOperatePoint != null)
                                            {
                                                if (CurrentUserOperatePoint.Any())
                                                {
                                                    if (CurrentUserOperatePoint.Count == 1)
                                                    {
                                                        OperatePointListID = CurrentUserOperatePoint.FirstOrDefault().ID;
                                                        propinfo.SetValue(_entity, OperatePointListID);
                                                    }
                                                    else
                                                        propinfo.SetValue(_entity, ObjOperatingPoint);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (CurrentUserOperatePoint != null)
                                        {
                                            if (CurrentUserOperatePoint.Any())
                                            {
                                                if (CurrentUserOperatePoint.Count == 1)
                                                    OperatePointListID = CurrentUserOperatePoint.FirstOrDefault().ID;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (CurrentUserOperatePoint != null)
                                    {
                                        if (CurrentUserOperatePoint.Any())
                                        {
                                            if (CurrentUserOperatePoint.Count == 1)
                                                OperatePointListID = CurrentUserOperatePoint.FirstOrDefault().ID;
                                        }
                                    }
                                }
                                propinfo.SetValue(_entity, OperatePointListID);
                            }

                            #endregion
                        }
                    }

                    #endregion

                    #region 获取所有更新的数据

                    var _entitiesChanged = ChangeTracker.Entries().Where(_e => _e.State == EntityState.Modified).ToList();
                    foreach (var entityitem in _entitiesChanged)
                    {
                        var _entity = entityitem.Entity;
                        var _entityProptys = _entity.GetType().GetProperties();
                        //自动设置属性
                        var AutoSetProtityS = _entityProptys.Where(x => updateAutoProps.Contains(x.Name));

                        foreach (var propinfo in AutoSetProtityS)
                        {
                            #region 自动设置

                            if (propinfo.Name == "EDITID")
                            {
                                propinfo.SetValue(_entity, CurrentUserId);
                            }
                            if (propinfo.Name == "EDITWHO")
                            {
                                //var objEDITWHO = propinfo.GetValue(_entity);
                                //if (string.IsNullOrEmpty(objEDITWHO.ToString()))
                                //{
                                propinfo.SetValue(_entity, CurrentUserName);
                                //}
                            }
                            if (propinfo.Name == "EDITTS")
                            {
                                propinfo.SetValue(_entity, DateTime.Now);
                            }

                            #endregion

                        }
                    }

                    #endregion

                    #region 获取所有删除的数据

                    //删除之前需要做的操作

                    #endregion

                    ret = base.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ret;
            }

            return 0;
        }

    }
}