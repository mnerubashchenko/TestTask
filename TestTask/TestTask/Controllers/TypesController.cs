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

        [HttpPost]
        [Route("AddType")]
        public void AddType(TypesOfDep newType)
        {
            using (var db = new TestContext())
            {
                db.TypesOfDep.Add(newType);
                db.SaveChanges();
            }
        }

        [HttpPut]
        [Route("UpdateType")]
        public void UpdateType(TypesOfDep updatedType)
        {
            using (var db = new TestContext())
            {
                db.TypesOfDep.Update(updatedType);
                db.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("DeleteType")]
        public void DeleteType(Guid idType)
        {
            using (var db = new TestContext())
            {
                db.TypesOfDep.Remove(db.TypesOfDep.Find(idType));
                db.SaveChanges();
            }
        }
    }
}
