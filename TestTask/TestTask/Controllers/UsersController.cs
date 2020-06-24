using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Model;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UsersController : Controller
    {
        [HttpGet]
        [Route("GetUsers")]
        public List<Users> GetUsers()
        {
            using (var db = new TestContext())
            {
                return db.Users.ToList();
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public void AddUser(Users newUser)
        {
            using (var db = new TestContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public void UpdateUser(Users updatedUser)
        {
            using (var db = new TestContext())
            {
                db.Users.Update(updatedUser);
                db.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public void DeleteUser(Guid idUser)
        {
            using (var db = new TestContext())
            {
                db.Users.Remove(db.Users.Find(idUser));
                db.SaveChanges();
            }
        }
    }
}
