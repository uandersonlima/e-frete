using System.ComponentModel.DataAnnotations;

namespace efrete.Addresses.Application.ViewModels
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(8, ErrorMessage = "Mínimo 8 dígitos")]
        [MaxLength(8, ErrorMessage = "Máximo 8 dígitos")]
        public string? ZipCode { get; set; }


        [Required(ErrorMessage = "Selecione uma UF")]
        public string? Uf { get; set; }


        public string? CityCode { get; set; }

        [Required(ErrorMessage = "Munícipio inválido")]
        public string? CityName { get; set; }

        public string? NeighborhoodName { get; set; }


        public string? StreetCode { get; set; }

        [Required(ErrorMessage = "Logradouro inválido")]
        public string? StreetName { get; set; }
    }
}