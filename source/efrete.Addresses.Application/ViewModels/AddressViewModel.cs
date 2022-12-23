using System.ComponentModel.DataAnnotations;

namespace efrete.Addresses.Application.ViewModels
{
    public class AddressViewModel
    {
        [MinLength(8), MaxLength(8)]
        public uint ZipCode { get; private set; }
        public string Uf { get; set; }
        public string CityName { get; private set; }
        public string NeighborhoodName { get; private set; }
        public string StreetName { get; private set; }
    }
}