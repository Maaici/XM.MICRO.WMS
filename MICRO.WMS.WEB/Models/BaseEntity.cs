using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MICRO.WMS.WEB.Models
{
    public class BaseEntity : Entity
    {
        [Display(Name = "备注", Description = "备注")]
        [StringLength(500)]
        public string REMARK { get; set; }

        [Display(Name = "创建人", Description = "创建人")]
        [StringLength(20)]
        public string ADDWHO { get; set; }

        [Display(Name = "创建人ID", Description = "创建人ID")]
        [StringLength(20)]
        public string ADDID { get; set; }

        [Display(Name = "创建时间", Description = "创建时间")]
        public DateTime? ADDTS { get; set; }

        [Display(Name = "修改人", Description = "修改人")]
        [StringLength(20)]
        public string EDITWHO { get; set; }

        [Display(Name = "修改人ID", Description = "修改人ID")]
        [StringLength(50)]
        public string EDITID { get; set; }

        [Display(Name = "修改时间", Description = "修改时间")]
        public DateTime? EDITTS { get; set; }

    }
}