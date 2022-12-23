using efrete.Core.DomainObjects;

namespace efrete.Addresses.Domain
{
    public class Address : IAggregateRoot
    {
        public Address(uint? zipCode, string? uf, string? cityCode, string? cityName, string? neighborhoodName, string? streetCode, string? streetName)
        {
            ZipCode = zipCode;
            Uf = uf;
            CityCode = cityCode;
            CityName = cityName;
            NeighborhoodName = neighborhoodName;
            StreetCode = streetCode;
            StreetName = streetName;
        }


        public uint? ZipCode { get; private set; }
        public string? Uf { get; private set; }


        public string? CityCode { get; private set; }
        public string? CityName { get; private set; }

        public string? NeighborhoodName { get; private set; }


        public string? StreetCode { get; private set; }
        public string? StreetName { get; private set; }
    }
}


