using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Abstraction.Models
{
    public class User : IUser
    {
        public string Id { get; set; }
        public DateTime Time { get; set; }
        public string Name { get; set; }
        public EnumGender Gender { get; set; }        
    }
}
