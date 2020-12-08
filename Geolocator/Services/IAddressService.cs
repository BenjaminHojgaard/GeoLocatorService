using Geolocator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geolocator.Services
{
    public interface IAddressService
    {
        public Task<ICollection<Coordinates>> getHotelCoordinates(ICollection<string> addresses);
    }
}
