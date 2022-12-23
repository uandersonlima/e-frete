using AutoMapper;
using efrete.Addresses.Application.ViewModels;
using efrete.Addresses.Domain;

namespace efrete.Addresses.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AddressViewModel, Address>()
            .ConstructUsing(aVM => new Address(UInt32.Parse(aVM.ZipCode ?? "0"), aVM.Uf, null, aVM.CityCode, aVM.CityName, aVM.NeighborhoodName, aVM.StreetCode, aVM.StreetName));
        }

    }
}