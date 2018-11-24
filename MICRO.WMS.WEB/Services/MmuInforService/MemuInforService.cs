using MICRO.WMS.WEB.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MICRO.WMS.WEB.Services
{
    public class MemuInforService : Service<MemuInfor> , IMemuInforService
    {
        private readonly IRepositoryAsync<MemuInfor> _repository;
        public MemuInforService(IRepositoryAsync<MemuInfor> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}