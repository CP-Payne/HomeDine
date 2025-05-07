using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDine.Domain.Common.Models;

namespace HomeDine.Domain.Dinner.ValueObjects
{
    public sealed class Location : ValueObject
    {
        public string Name { get; }
        public string Address { get; }
        public long Latitude { get; }
        public long Longitude { get; }

        private Location(string name, string address, long latitude, long longitude)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Location name cannot be empty.", nameof(name));
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Location address cannot be empty.", nameof(address));
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Location Create(string name, string address, long latitude, long longitude)
        {
            return new Location(name, address, latitude, longitude);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Address;
            yield return Latitude;
            yield return Longitude;
        }
    }
}
