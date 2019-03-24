using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SampleService.Controllers
{
    [Route("api")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        [Route("GetMethod")]
        public IActionResult Get(int id)
        {
            return new ObjectResult("{value:'Returned'}");
        }

        [HttpPost]
        [Route("PostMethod")]
        public IActionResult Post([FromBody]string value)
        {
            return new ObjectResult("{result:'true',message:'post successful'}");                   
        }

        [HttpPut("{id}")]
        [Route("PutMethod")]
        public IActionResult Put([FromBody]string value)
        {
            return new ObjectResult("{result:'true',message:'update successful'}");
        }

        [HttpDelete("{id}")]
        [Route("DeleteMethod")]
        public IActionResult Delete(int id)
        {
            return new ObjectResult("{result:'true',message:'delete successful'}");
        }
    }
}
