using AutoMapper;
using efrete.Addresses.Application.ViewModels;
using efrete.Addresses.Domain;

namespace efrete.Addresses.Application.Queries
{
    public class AddressQueries : IAddressQueries
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressQueries(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public AddressViewModel GetAddressByZipCode(uint zipCode)
        {
            return _mapper.Map<AddressViewModel>(_addressRepository.GetAddressByZipCode(zipCode));
        }
        public AddressViewModel GetZipCodeByAddress(AddressViewModel addressVM)
        {
            var address = _mapper.Map<Address>(addressVM);
            return _mapper.Map<AddressViewModel>(_addressRepository.GetZipCodeByAddress(address));
        }


        public List<AddressViewModel> GetAllAddresses()
        {

            return _mapper.Map<List<AddressViewModel>>(_addressRepository
                     .GetAllAddresses());
        }

        public List<string?> GetCityNamesByUf(string uf, string query)
        {
            return _addressRepository.GetCityNamesByUf(uf, query);
        }

        public List<string?> GetStreetNamesByCityName(string cityName, string query)
        {
            return _addressRepository.GetStreetNamesByCityName(cityName, query);
        }
    }
}