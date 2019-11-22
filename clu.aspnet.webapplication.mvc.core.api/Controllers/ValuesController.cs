using System.Collections.Generic;
using clu.aspnet.webapplication.mvc.core.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Dictionary<string, string> _items = new Dictionary<string, string>();

        public ValuesController()
        {
            _items["key1"] = "value1";
            _items["key2"] = "value2";
        }

        [HttpGet("{id}")]
        //public IActionResult Get(string id)
        public ActionResult<string> Get(string id)
        {
            if (_items.ContainsKey(id) == false)
            {
                return NotFound();
            }

            return Ok(_items[id]);

            /*
            
            https://localhost:44337/api/values/key1
            https://localhost:44337/api/values/key2

            */
        }

        [HttpPost]
        public IActionResult Post(Entry entry)
        {
            if (_items.ContainsKey(entry.Key) == true)
            {
                return BadRequest();
            }

            _items.Add(entry.Key, entry.Value);

            return CreatedAtAction(nameof(Get), new { id = entry.Key }, entry);
        }

        /*
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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

        */
    }
}