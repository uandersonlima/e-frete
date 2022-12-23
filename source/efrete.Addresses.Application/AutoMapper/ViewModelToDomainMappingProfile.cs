using AutoMapper;
using efrete.Addresses.Application.ViewModels;
using efrete.Addresses.Domain;

namespace efrete.Addresses.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AddressViewModel, Address>();
        }

    }
}