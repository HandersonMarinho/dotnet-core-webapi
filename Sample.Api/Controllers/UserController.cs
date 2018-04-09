using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Abstraction.Models;
using Sample.Abstraction.Services;

namespace Sample.Api.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        public UserController(IUserServiceController userServiceController)
        {
            UserServiceController = userServiceController ?? throw new ArgumentException($"{nameof(userServiceController)} is mandatory");
        }

        private IUserServiceController UserServiceController { get; set; }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return UserServiceController.GetAll().Cast<User>();
        }

        [HttpGet("{id}")]
        public User Get(string id)
        {
            return (User)UserServiceController.GetById(id);
        }

        [HttpPost]
        public User Post([FromBody]User value)
        {
            return (User)UserServiceController.Save(value);
        }

        [HttpPut()]
        public User Put([FromBody]User value)
        {
            return (User)UserServiceController.Update(value);
        }
        
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            UserServiceController.Delete(id);
        }
    }
}
