using efrete.Addresses.Domain;
using efrete.Core.Communication;
using efrete.Core.Messages.Common.Notifications;

namespace efrete.Addresses.Data.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressContext _context;
        private readonly IMediatorHandler _mediatorHandler;

        public AddressRepository(AddressContext context, IMediatorHandler mediatorHandler)
        {
            _context = context;
            _mediatorHandler = mediatorHandler;
        }

        public Address GetAddressByZipCode(uint zipCode)
        {
            if (_context.Succeeded)
            {
                return _context.Addresses.Where(a => a.ZipCode == zipCode).FirstOrDefault();
            }

            _mediatorHandler.PublishNotificationAsync(new DomainNotification("FileError", "Erro durante a leitura de dados"));

            return null;
        }
        public Address GetZipCodeByAddress(Address address)
        {
            if (_context.Succeeded)
            {
                return _context.Addresses.Where(a => a.Uf.Equals(address.Uf) && a.CityName.Equals(address.CityName) && a.StreetName.Equals(address.StreetName)).FirstOrDefault();
            }

            _mediatorHandler.PublishNotificationAsync(new DomainNotification("FileError", "Erro durante a leitura de dados"));

            return null;
        }

        public List<Address> GetAllAddresses()
        {
            if (_context.Succeeded)
            {
                return _context.Addresses.ToList();
            }

            _mediatorHandler.PublishNotificationAsync(new DomainNotification("FileError", "Erro durante a leitura de dados"));

            return new List<Address>();
        }

        public List<string?> GetCityNamesByUf(string uf, string query)
        {
            return GetAllAddresses()
                    .Where(a => a.Uf == uf && a.CityName.ToLower().Contains(query.ToLower()))
                    .Select(a => a.CityName)
                    .Distinct()
                    .Take(30)
                    .ToList();
        }

        public List<string?> GetStreetNamesByCityName(string cityName, string query)
        {
            return GetAllAddresses()
                        .Where(a => a.CityName == cityName && a.StreetName.ToLower().Contains(query.ToLower()))
                        .Select(a => a.StreetName)
                        .Distinct()
                        .Take(30)
                        .ToList();
        }
    }
}