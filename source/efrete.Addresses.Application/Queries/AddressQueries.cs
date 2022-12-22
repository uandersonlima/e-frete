using efrete.Addresses.Application.ViewModels;
using efrete.Addresses.Domain;

namespace efrete.Addresses.Application.Queries
{
    public class AddressQueries : IAddressQueries
    {
        private readonly IAddressRepository _addressRepository;

        public AddressQueries(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public List<AddressViewModel> GetAllAddressesAsync()
        {
            var addressVMList = new List<AddressViewModel>();
            _addressRepository
                     .GetAllAddressesAsync()
                        .ForEach(a => addressVMList.Add(new AddressViewModel
                        (
                                new UFStateViewModel(a.UFState.Id, a.UFState.Name), 
                                //a.CityName, 
                                a.NeighborhoodName, 
                                a.StreetName, 
                                a.ZipCode
                        )));
            return addressVMList;
        }
    }
}