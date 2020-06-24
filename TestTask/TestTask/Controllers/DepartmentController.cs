using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Model;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/dep")]
    public class DepartmentController : Controller
    {
        [HttpGet]
        [Route("GetDepartments")]
        public List<Departaments> GetDepartaments()
        {
            using (var db = new TestContext())
            {
                return db.Departaments.ToList();
            }
        }

        [HttpPost]
        [Route("AddDepartament")]
        public void AddDepartament(Departaments newDepartament)
        {
            using (var db = new TestContext())
            {
                db.Departaments.Add(newDepartament);
                db.SaveChanges();
            }
        }

        [HttpPut]
        [Route("UpdateDepartament")]
        public void UpdateDepartament(Departaments updatedDepartament)
        {
            using (var db = new TestContext())
            {
                db.Departaments.Update(updatedDepartament);
                db.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("DeleteDepartament")]
        public void DeleteDepartament(Guid idDep)
        {
            using (var db = new TestContext())
            {
                db.Departaments.Remove(db.Departaments.Find(idDep));
                db.SaveChanges();
            }
        }
    }
}
