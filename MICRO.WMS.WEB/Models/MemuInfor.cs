using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MICRO.WMS.WEB.Models
{
    public class MemuInfor :BaseEntity
    {
        [Key]
        [Display(Name = "ID", Description = "ID")]
        public int ID { get; set; }

        [Display(Name = "菜单", Description = "菜单")]
        [StringLength(50)]
        public string MemuName { get; set; }

        [Display(Name = "菜单编号", Description = "菜单编号")]
        [StringLength(50)]
        public string MemuCode { get; set; }

        [Display(Name = "上级菜单", Description = "上级菜单")]
        [StringLength(50)]
        public string FatherMemu { get; set; }

        [Display(Name = "上级菜单编号", Description = "上级菜单编号")]
        [StringLength(50)]
        public string FatherMemuCode { get; set; }

        [Display(Name = "菜单状态", Description = "菜单状态")]
        [StringLength(10)]
        public string MemuStatus { get; set; }
        
    }
}