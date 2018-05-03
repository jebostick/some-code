using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace iWillEstate.Controllers
{

    [Route("api/[controller]")]
    public class NavigationController : Controller
    {
        // GET api/Navigation
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Rent", "Lease", "Buy", "Sell" };
        }




        // GET api/Navigation/home
        [HttpGet("{nextRoutePath}")]
        public IEnumerable<string> Get(string nextRoutePath)
        {
            var angularWebPage = new TheCustomizedWebPage();

            switch (nextRoutePath)
            {
                case "login":
                {
                    
                    angularWebPage.CurrentPath = "login";
                    break;
                }
                case "home":
                {
                    angularWebPage.CurrentPath = "home";
                    break;
                }
                case "main":
                {
                    
                    angularWebPage.CurrentPath = "main";
                    break;
                }
                case "buyer-renter":
                {
                    
                    angularWebPage.CurrentPath = "buyer-renter";
                    angularWebPage.Url = "BuyerRenterOrOwnerSeller";
                    angularWebPage.QuestionTextToDisplay = "I wish to ";
                    angularWebPage.BackNavButton = "home";
                    angularWebPage.NextNavButton = "buyer-renter";
                    angularWebPage.CurrentPath = "buyer-renter";
                    
                    angularWebPage.AnswerButtons = new string[] { "Rent", "Lease", "Buy", "Sell" };
                    angularWebPage.AnswerTextToDisplay = "what's your answer? ";
                    break;
                }
                default:
                {
                    angularWebPage.CurrentPath = "";
                    break;
                }
            }

            return new string[] { angularWebPage.QuestionTextToDisplay, 
                angularWebPage.BackNavButton, 
                angularWebPage.NextNavButton, 
                angularWebPage.AnswerTextToDisplay };
        }

        //// GET api/Navigation/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/Navigation
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/NavigationController/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/Navigation/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }

    public enum AngularWebPage
    {
        home = 1
        , main = 2
        , login = 3
        , buyerRenter = 4
        , sellerOwner = 5
        , resumeApplication = 6

        , pageNotFound = 99
    }

    public class TheCustomizedWebPage
    {
        public string Url { get; set; } = "BuyerRenterOrOwnerSeller";
        public string QuestionTextToDisplay { get; set; } = "I wish to ";
        public string BackNavButton { get; set; } = "home";
        public string NextNavButton { get; set; } = "buyer-renter";
        public string CurrentPath { get; set; } = "buyer-renter";
        public string AnswerTextToDisplay { get; set; } = "I wish to ";
        public string[] AnswerButtons { get; set; } = new string[]{ "Rent", "Lease", "Buy", "Sell" };
    }
}