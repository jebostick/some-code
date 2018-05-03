using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace iWillEstate.Controllers
{

    [Route("api/[controller]")]
    public class BuyerRenterOrOwnerSellerController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Rent", "Lease", "Buy", "Sell" };
        }

        // GET api/Navigation/home
        [HttpGet("{nextRoutePath}")]
        public string[] Get(string nextRoutePath)
        {
            var myString = new string[] { "No", "It", "Did", "Not", "Work", "Out!" };
            System.Diagnostics.Debugger.Break();
            var angularWebPage = new TheCustomizedWebPage();

            if (nextRoutePath == AngularWebPage.home.ToString())
            {

                myString[0] = "Yes";
                myString[2] = "Worked";
                myString[3] = "Out";
                myString[4] = "In";
            }
            switch (nextRoutePath)
            {
                case "home":
                    {
                        angularWebPage.Url = nextRoutePath;
                        myString[4] = "SWITCH";
                        break;
                    }
                default:
                    {
                        myString[0] = "Defalut";
                        myString[1] = "Worked";

                        angularWebPage.Url = "page-not-found";
                        break;
                    }
            }

            Json(angularWebPage);

            return myString;
        }

        // GET api/BuyerRenterOrOwnerSeller/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/BuyerRenterOrOwnerSeller
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/BuyerRenterOrOwnerSeller/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/BuyerRenterOrOwnerSeller/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
