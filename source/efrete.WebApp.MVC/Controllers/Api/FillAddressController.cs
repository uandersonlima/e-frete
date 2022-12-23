using efrete.Addresses.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace efrete.WebApp.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FillAddressController : ControllerBase
    {
        private readonly IAddressQueries _addressQueries;


        public FillAddressController(IAddressQueries addressQueries)
        {
            _addressQueries = addressQueries;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AutoCompleteCity(string uf, string query)
        {
            try
            {
                var cityNames = _addressQueries.GetCityNamesByUf(uf, query);

                return Ok(cityNames);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> AutoCompleteStreet(string cityName, string query)
        {
            try
            {
                var streetNames = _addressQueries.GetStreetNamesByCityName(cityName, query);

                return Ok(streetNames);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
