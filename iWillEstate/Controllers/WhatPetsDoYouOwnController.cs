using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace iWillEstate.Controllers
{

    [Route("api/[controller]")]
    public class WhatPetsDoYouOwnController : Controller
    {
        // GET api/WhatPetsDoYouOwn
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "do not own pets.", "own 1 or 2 cats.", "own 3+ cats."
                , "own 1 or 2 small dogs", "own 2+ small dogs."
                , "own 2+ cat(s)/dog(s)", "own other animals." };
        }

        // GET api/WhatPetsDoYouOwn/5
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

        // PUT api/WhatPetsDoYouOwn/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/WhatPetsDoYouOwn/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
