using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Model;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostsController : Controller
    {
        [HttpGet]
        [Route("GetPosts")]
        public List<Posts> GetPosts()
        {
            using (var db = new TestContext())
            {
                return db.Posts.ToList();
            }
        }

        [HttpPost]
        [Route("AddPost")]
        public void AddPost(Posts newPost)
        {
            using (var db = new TestContext())
            {
                db.Posts.Add(newPost);
                db.SaveChanges();
            }
        }

        [HttpPut]
        [Route("UpdatePost")]
        public void UpdatePost(Posts updatedPost)
        {
            using (var db = new TestContext())
            {
                db.Posts.Update(updatedPost);
                db.SaveChanges();
            }
        }

        [HttpDelete]
        [Route("DeletePost")]
        public void DeletePost(Guid idPost)
        {
            using (var db = new TestContext())
            {
                db.Posts.Remove(db.Posts.Find(idPost));
                db.SaveChanges();
            }
        }
    }
}
