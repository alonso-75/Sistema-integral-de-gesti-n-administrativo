using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sistema_integral_api.Controllers.CitizenAttentionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenAttentionController : ControllerBase
    {
        // GET: api/<CitizenAttentionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CitizenAttentionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CitizenAttentionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CitizenAttentionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CitizenAttentionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
