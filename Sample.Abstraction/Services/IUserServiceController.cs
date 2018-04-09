using Sample.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Abstraction.Services
{
    public interface IUserServiceController
    {
        IUser Save(IUser user);
        IUser Update(IUser user);
        void Delete(string id);
        IUser GetById(string id);
        List<IUser> GetAll();
    }
}
