using efrete.Core.DomainObjects;

namespace efrete.Addresses.Domain
{
    public class Address : Entity<int>, IAggregateRoot
    {
        public Address(int id, UFState uFState, City city, string neighborhoodName, string streetName, string zipCode) : base(id)
        {
            UFState = uFState;
            City = city;
            NeighborhoodName = neighborhoodName;
            StreetName = streetName;
            ZipCode = zipCode;
        }

        public UFState UFState { get; set; }
        public City City { get; private set; }
        public string NeighborhoodName { get; private set; }
        public string StreetName { get; private set; }
        public string ZipCode { get; private set; }
    }
}


