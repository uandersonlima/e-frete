using efrete.Core.Data;

namespace efrete.Addresses.Domain
{
    public interface IAddressRepository : IRepository<Address>
    {
        List<string> GetUFsAsync();
        List<string> GetCityByUFAsync(string uf);
        List<Address> GetAllAddressesAsync();
        
    }
}