using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        // api/values is the "relative route", which is the route that follows the "base url".
            // Every request has a base url (a localhost url in this case) followed by the "relative route" (endpoints).
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // The POST, PUT, and DELETE methods have no return type because there is no "body" sent back
            // However, there will be a response code (e.g., 200 Ok, 404 Error, etc.)
        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
