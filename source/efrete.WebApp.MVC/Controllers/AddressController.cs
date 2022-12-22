using efrete.Addresses.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace efrete.WebApp.MVC.Controllers
{
    [Controller]
    public class AddressController : Controller
    {
        private readonly IAddressQueries _addressQueries;

        public AddressController(IAddressQueries addressQueries)
        {
            _addressQueries = addressQueries;
        }

        [Route("search-address")]
        public IActionResult SearchAddress()
        {
            var list = _addressQueries.GetAllAddressesAsync();
            return View();
        }
        [Route("search-zip-code")]
        public IActionResult SearchZipCode()
        {
            var list = _addressQueries.GetAllAddressesAsync();
            return View();
        }
    }
}
