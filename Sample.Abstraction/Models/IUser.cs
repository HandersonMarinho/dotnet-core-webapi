using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Abstraction.Models
{
    public interface IUser : IAggregate
    {
        string Name { get; set; }
        EnumGender Gender { get; set; }
    }
}
