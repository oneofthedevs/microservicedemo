using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Micro.Database;
using Micro.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Micro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        DBContext db;
        public HomeController()
        {
            db = new DBContext();
        }

        //Fetch All users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }

        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return db.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post([FromBody] User obj)
        {
            try
            {
                db.Users.Add(obj);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("{id}", Name = "Delete")]
        public bool Delete(int id)
        {
            try
            {
                db.Users.Remove(db.Users.Where(x => x.Id == id).FirstOrDefault());
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        public IActionResult Edit([FromBody]User obj)
        {
            try
            {
                db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}