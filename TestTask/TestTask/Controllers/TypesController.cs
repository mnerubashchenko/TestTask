using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Model;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/type")]
    public class TypesController : Controller
    {
        [HttpGet]
        [Route("GetTypes")]
        public List<TypesOfDep> GetTypes()
        {
            using (var db = new TestContext())
            {
                return db.TypesOfDep.ToList();
            }
        }
    }
}
