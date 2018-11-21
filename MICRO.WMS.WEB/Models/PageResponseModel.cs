using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace MICRO.WMS.WEB.Models
{
    public class PageResponseModel
    {
        public int code;
        public string msg;
        public int count;
        public dynamic data;
    }
}