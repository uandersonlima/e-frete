using efrete.Addresses.Application.Queries;
using efrete.Addresses.Application.ViewModels;
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

        [HttpGet]
        [Route("search-address")]
        public IActionResult SearchAddress()
        {
            return View();
        }

        [HttpPost]
        [Route("search-address")]
        public IActionResult SearchAddress([FromForm] AddressViewModel addressView)
        {
            if (ModelState.IsValid)
            {
                var result = _addressQueries.GetAddressByZipCode(UInt32.Parse(addressView.ZipCode));
                return RedirectToAction(nameof(ResultAddress), result);
            }

            return View();
        }

        [HttpGet]
        [Route("result-address")]
        public IActionResult ResultAddress(AddressViewModel addressView)
        {
            return View(addressView);
        }

        [HttpGet]
        [Route("search-zip-code")]
        public IActionResult SearchZipCode()
        {

            return View();
        }

        [HttpPost]
        [Route("search-zip-code")]
        public IActionResult SearchZipCode([FromForm] string uF, [FromForm] string city, [FromForm] string street)
        {

            return View();
        }
    }
}
