using efrete.Addresses.Domain;

namespace efrete.Addresses.Data.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressContext _context;

        public AddressRepository(AddressContext context)
        {
            _context = context;
        }

        public void Dispose()
        {

        }

        public List<Address> GetAllAddressesAsync()
        {
            if (_context.Succeeded)
            {
                return _context.Addresses.ToList();
            }
            //ADICIONAR NOTIFICAÇÕES
            return new List<Address>();
        }

        public List<string> GetCityByUFAsync(string uf)
        {
            throw new NotImplementedException();
        }

        public List<string> GetUFsAsync()
        {
            throw new NotImplementedException();
        }
    }
}