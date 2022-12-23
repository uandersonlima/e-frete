using efrete.Core.Data;

namespace efrete.Addresses.Domain
{
    public interface IAddressRepository : IRepository<Address>
    {
        List<Address> GetAllAddresses();
        Address GetAddressByZipCode(uint zipCode);
        Address GetZipCodeByAddress(Address address);

        List<string?> GetCityNamesByUf(string uf, string query);
        List<string?> GetStreetNamesByCityName(string cityName, string query);
    }
}