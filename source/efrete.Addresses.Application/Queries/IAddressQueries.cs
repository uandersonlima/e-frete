using efrete.Addresses.Application.ViewModels;

namespace efrete.Addresses.Application.Queries
{
    public interface IAddressQueries
    {
        List<AddressViewModel> GetAllAddressesAsync();
    }
}