using MICRO.WMS.WEB.Models;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MICRO.WMS.WEB.Services.UserInforService
{
    public class UserInforService : Service<USERINOR> , IUserInforService
    {
        private readonly IRepositoryAsync<USERINOR> _repository;
        public UserInforService(IRepositoryAsync<USERINOR> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}