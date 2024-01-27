using ConnectionWithAzure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionWithAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataBaseContext _mycast;

        public ValuesController(DataBaseContext context) 
        {
        _mycast = context;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<Customer>>> Get()
        {
            return Ok(_mycast.Customers.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Customer newcast)
        {
            _mycast.Add<Customer>(newcast);
            _mycast.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            _mycast.Remove(_mycast.Customers.ToList().Find(e=>e.Id==id));
            _mycast.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Customer newcast)
        {
            _mycast.Update(newcast);
            _mycast.SaveChanges();
            return Ok();
        }
    }
}
