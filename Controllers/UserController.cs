using ConnectionWithAzure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionWithAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataBaseContext _mycast;

        public UserController(DataBaseContext context)
        {
            _mycast = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(_mycast.Users.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> Post(User newuser)
        {
            _mycast.Add(newuser);
            _mycast.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            _mycast.Remove(_mycast.Users.ToList().Find(e => e.Id == id));
            _mycast.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(User newcast)
        {
            _mycast.Update(newcast);
            _mycast.SaveChanges();
            return Ok();
        }
    }
}
