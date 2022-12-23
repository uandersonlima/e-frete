using AutoMapper;
using efrete.Addresses.Application.AutoMapper;
using efrete.Addresses.Application.ViewModels;
using efrete.Addresses.Domain;

namespace efrete.Addresses.Application.Tests
{
    public class ApplicationTests
    {
        private readonly IMapper _mapper;

        public ApplicationTests()
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ViewModelToDomainMappingProfile());
                opt.AddProfile(new DomainToViewModelMappingProfile());
            });
            _mapper = config.CreateMapper();
        }

        [Fact(DisplayName = "Map: 01 - deve mapear corretamente o objeto AddressViewModel para Address")]
        public void Verificar_Conversao_Automapper_Viewmodel_Para_Model()
        {
            AddressViewModel aVW = new AddressViewModel
            {
                ZipCode = "12345678",
                StreetCode = "012345678",
                StreetName = "Rua do jardim",
                Uf = "Ba",
                CityCode = "012345678",
                CityName = "Catu",
                NeighborhoodName = "Planalto 1"
            };

            Address? EXPECTED = new(12345678, "Ba", "012345678", "Catu", "Planalto 1", "012345678", "Rua do jardim");

            var result = _mapper.Map<Address>(aVW);

            NUnit.Framework.Assert.AreEqual(EXPECTED.ZipCode, result.ZipCode);
            NUnit.Framework.Assert.AreEqual(EXPECTED.StreetCode, result.StreetCode);
            NUnit.Framework.Assert.AreEqual(EXPECTED.StreetName, result.StreetName);
            NUnit.Framework.Assert.AreEqual(EXPECTED.Uf, result.Uf);
            NUnit.Framework.Assert.AreEqual(EXPECTED.NeighborhoodName, result.NeighborhoodName);
            NUnit.Framework.Assert.AreEqual(EXPECTED.CityCode, result.CityCode);
            NUnit.Framework.Assert.AreEqual(EXPECTED.CityName, result.CityName);
            NUnit.Framework.Assert.AreEqual(EXPECTED.NeighborhoodName, result.NeighborhoodName);
        }

        [Fact(DisplayName = "Map: 02 - deve mapear corretamente o objeto Address para AddressViewModel")]
        public void Verificar_Conversao_Automapper_Model_Para_Viewmodel()
        {

            Address a = new(12345678, "Ba", "012345678", "Catu", "Planalto 1", "012345678", "Rua do jardim");

            AddressViewModel EXPECTED = new AddressViewModel
            {
                ZipCode = "12345678",
                StreetCode = "012345678",
                StreetName = "Rua do jardim",
                Uf = "Ba",
                CityCode = "012345678",
                CityName = "Catu",
                NeighborhoodName = "Planalto 1"
            };

            var result = _mapper.Map<AddressViewModel>(a);


            NUnit.Framework.Assert.AreEqual(EXPECTED.ZipCode, result.ZipCode);
            NUnit.Framework.Assert.AreEqual(EXPECTED.StreetCode, result.StreetCode);
            NUnit.Framework.Assert.AreEqual(EXPECTED.StreetName, result.StreetName);
            NUnit.Framework.Assert.AreEqual(EXPECTED.Uf, result.Uf);
            NUnit.Framework.Assert.AreEqual(EXPECTED.CityCode, result.CityCode);
            NUnit.Framework.Assert.AreEqual(EXPECTED.CityName, result.CityName);
            NUnit.Framework.Assert.AreEqual(EXPECTED.NeighborhoodName, result.NeighborhoodName);

        }
    }
}