using MICRO.WMS.WEB.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MICRO.WMS.WEB.Services.UserInforService
{
    public class UserInforService : Service<USERINFOR> , IUserInforService
    {
        private readonly IRepositoryAsync<USERINFOR> _repository;
        public UserInforService(IRepositoryAsync<USERINFOR> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}