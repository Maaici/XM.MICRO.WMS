using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MICRO.WMS.WEB.Models
{
    public class OperationPoint :BaseEntity
    {
        [Display(Name = "主键")]
        public int ID { get; set; }

        [Display(Name = "代码")]
        [Required, StringLength(50)]
        public string OperatePointCode { get; set; }

        [Display(Name = "名称")]
        [Required, StringLength(100)]
        public string OperatePointName { get; set; }

        [Display(Name = "描述")]
        [StringLength(100)]
        public string Description { get; set; }

        [Display(Name = "是否启用")]
        public bool IsEnabled { get; set; }
    }
}