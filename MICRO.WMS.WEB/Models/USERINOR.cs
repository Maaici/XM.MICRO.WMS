using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MICRO.WMS.WEB.Models
{
    public class USERINOR : BaseEntity
    {
        [Key]
        [Display(Name = "ID", Description = "ID")]
        public int ID { get; set; }

        [Display(Name = "用户名", Description = "用户名")]
        [StringLength(20)]
        public string USERNAME { get; set; }

        [Display(Name = "用户ID", Description = "用户ID")]
        [StringLength(20)]
        public string USERCODE { get; set; }

        [Display(Name = "角色", Description = "角色")]
        [StringLength(20)]
        public string USERROLE { get; set; }
        
    }
}