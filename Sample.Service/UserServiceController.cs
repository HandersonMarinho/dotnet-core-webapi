using Sample.Abstraction.Models;
using Sample.Abstraction.Repositories;
using Sample.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Service
{
    public class UserServiceController : IUserServiceController
    {
        public UserServiceController
        (
            IAppConfiguration configuration,
            ILoggerService loggerService,
            IRepository<IUser> repository
        )
        {

        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<IUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public IUser GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IUser Save(IUser user)
        {
            throw new NotImplementedException();
        }

        public IUser Update(IUser user)
        {
            throw new NotImplementedException();
        }
    }
}
