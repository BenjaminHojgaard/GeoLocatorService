using Geolocator.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Geolocator.Services
{
    public class AddressService : IAddressService
    {
        public AddressService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<ICollection<Coordinates>> getHotelCoordinates(ICollection<string> addresses)
        {
            string apiKey = Configuration["ExternalProviders:Google:ApiKey"];

            ICollection<Coordinates> coordinates = new List<Coordinates>();

            foreach (var address in addresses)
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(Configuration["ApiEndpoints:Google:GeoCode:LongLatDiscoverer"] + address + "&key=" + apiKey);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        coordinates.Add(unwrapCoordsFromJson(content));
                    }
                    else
                    {
                        throw new HttpRequestException("Couldn't get response... StatusCode: " + response.StatusCode);
                    }
                }
            }

            return coordinates;
        }

        private Coordinates unwrapCoordsFromJson(string json)
        {
            JObject coords = JsonConvert.DeserializeObject<dynamic>(json);
            var lat = (double) coords.SelectToken("results[0].geometry.location.lat");
            var lng = (double) coords.SelectToken("results[0].geometry.location.lng");

            return new Coordinates { Lat = lat, Long = lng };
        }
    }
}
