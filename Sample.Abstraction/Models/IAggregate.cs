using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Abstraction.Models
{
    public interface IAggregate
    {
        string Id { get; set; }
        DateTime Time { get; set; }
    }
}
