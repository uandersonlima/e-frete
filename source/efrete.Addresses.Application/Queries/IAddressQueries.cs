using efrete.Addresses.Application.ViewModels;

namespace efrete.Addresses.Application.Queries
{
    public interface IAddressQueries
    {
        List<AddressViewModel> GetAllAddresses();
        AddressViewModel GetAddressByZipCode(uint zipCode);
        AddressViewModel GetZipCodeByAddress(AddressViewModel addressVM);

        List<string?> GetCityNamesByUf(string uf, string query);
        List<string?> GetStreetNamesByCityName(string cityName, string query);
    }
}