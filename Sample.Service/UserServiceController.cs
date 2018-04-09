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
            IAppConfiguration appConfiguration,
            ILoggerService loggerService,
            IRepository<IUser> repository
        )
        {
            AppConfiguration = appConfiguration ?? throw new ArgumentException($"{nameof(appConfiguration)} is mandatory.");
            LoggerService = loggerService ?? throw new ArgumentException($"{nameof(loggerService)} is mandatory.");
            Repository = repository ?? throw new ArgumentException($"{nameof(repository)} is mandatory.");
        }

        private IAppConfiguration AppConfiguration { get; set; }

        private ILoggerService LoggerService { get; set; }

        private IRepository<IUser> Repository { get; set; }

        public void Delete(string id)
        {
            if(string.IsNullOrWhiteSpace(id))
                throw new ArgumentException($"{nameof(id)} is mandatory.");

            Repository.Delete(id);
        }

        public List<IUser> GetAll()
        {
            return Repository.GetAll();
        }

        public IUser GetById(string id)
        {
            return Repository.GetOne(x => x.Id == id);
        }

        public IUser Save(IUser user)
        {
            VerifyObject(user);
            return Repository.Add(user);
        }

        public IUser Update(IUser user)
        {
            VerifyObject(user);
            return Repository.Update(user);
        }

        private void VerifyObject(IUser user)
        {
            if (user.Gender == EnumGender.Undefined)
                throw new ArgumentException($"{nameof(user.Gender)} is mandatory.");

            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ArgumentException($"{nameof(user.Name)} is mandatory.");
        }
    }
}
