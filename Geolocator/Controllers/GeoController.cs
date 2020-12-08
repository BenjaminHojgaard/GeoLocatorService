using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geolocator.Models;
using Geolocator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Geolocator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoController : ControllerBase
    {

        public GeoController(IConfiguration configuration, IAddressService addressService)
        {
            Configuration = configuration;
            _addressService = addressService;
        }

        public IConfiguration Configuration { get; }
        public IAddressService _addressService { get; }

        // POST: api/Geo/
        [HttpPost]
        public async Task<ICollection<Coordinates>> Get([FromBody]ICollection<string> addresses)
        {
            return await _addressService.getHotelCoordinates(addresses);
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
