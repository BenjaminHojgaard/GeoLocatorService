using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geolocator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Geolocator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoController : ControllerBase
    {
        // GET: api/Geo/
        [HttpGet(Name = "Get")]
        public ICollection<Restaurant> Get([FromHeader]ICollection<string> addresses)
        {
            var restaurants = new List<Restaurant>();
            // HTTP GET
            // loop over addresses
            // GET request to fetch lat and long of address

            return restaurants;
        }

        // POST: api/Geo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Geo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
