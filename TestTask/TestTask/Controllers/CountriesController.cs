using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Model;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/country")]
    public class CountriesController : Controller
    {
        [HttpGet]
        [Route("GetCountries")]
        public List<Countries> GetCountries()
        {
            using (var db = new TestContext())
            {
                return db.Countries.ToList();
            }
        }
    }
}
