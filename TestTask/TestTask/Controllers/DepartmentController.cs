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
    }
}
