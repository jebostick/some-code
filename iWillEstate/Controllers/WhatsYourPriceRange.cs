using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace iWillEstate.Controllers
{

    [Route("api/[controller]")]
    public class WhatsYourPriceRangeController : Controller
    {
        // GET api/WhatsYourPriceRange
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "$0 - $1,000", "$1,001 - $1,500", "$1,501 - $2,000", "$2,001 - $3,200", "$3,201 + ..." };
        }

        // GET api/WhatsYourPriceRange/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/WhatsYourPriceRange/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/WhatsYourPriceRange/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
