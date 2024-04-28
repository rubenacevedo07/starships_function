using FunctionStarships.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FunctionStarships.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarshipsController : ControllerBase
    {
        
        // GET: api/<StarshipsController>
        [HttpGet]
        public IEnumerable<SimpleStarship>? Get()
        {
            string st = System.IO.File.ReadAllText(@"starships.json");

            List<SimpleStarship> starships1 = JsonConvert.DeserializeObject<List<SimpleStarship>>(st);
           
            return starships1;
        }

       

        // GET api/<StarshipsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StarshipsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StarshipsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StarshipsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
