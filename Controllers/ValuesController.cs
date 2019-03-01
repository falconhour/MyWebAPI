using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Model;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public List<User> users = new List<User>();

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return new User[] {
                new User {
                    Id = 1,
                    Name = "Diane",
                    Email = "d@mail.com"
                },
                new User {
                    Id = 2,
                    Name = "Kenneth",
                    Email = "s@mail.com"
                }
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Post([FromBody]User user)
        {
            users.Add(user);
            bool isPosted = users.Contains(user);

            if (isPosted)
                return Ok(user);

            return BadRequest(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
