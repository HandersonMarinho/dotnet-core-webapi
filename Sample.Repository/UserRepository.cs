using Sample.Abstraction.Models;
using Sample.Abstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Repository
{
    public class UserRepository: InMemoryGenericDatabase<IUser>, IRepository<IUser>
    {
    }
}
