using efrete.Addresses.Application.Queries;
using efrete.Addresses.Application.ViewModels;
using efrete.Addresses.Domain;
using efrete.Core.Communication;
using efrete.Core.Messages.Common.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace efrete.WebApp.MVC.Controllers
{

    public class AddressController : BaseController
    {
        private readonly IAddressQueries _addressQueries;
        private readonly IAddressService _addressService;

        public AddressController(IAddressQueries addressQueries,
                            IAddressService addressService,
                            IMediatorHandler mediatorHandler,
                            INotificationHandler<DomainNotification> notification)
                            : base(notification, mediatorHandler)
        {
            _addressQueries = addressQueries;
            _addressService = addressService;
        }


        [HttpGet("search-address")]
        public IActionResult SearchAddress()
        {
            return View();
        }


        [HttpPost("search-address")]
        public IActionResult SearchAddress([FromForm] AddressViewModel addressView)
        {
            ModelState.Remove("UF");
            ModelState.Remove("CityName");
            ModelState.Remove("StreetName");

            if (ModelState.IsValid)
            {
                var result = _addressQueries.GetAddressByZipCode(UInt32.Parse(addressView.ZipCode));
                if (result is not null) ViewBag.ZipCode = result.ZipCode;
                return RedirectToAction(nameof(ResultAddress), result);
            }

            return View(addressView);
        }

        [HttpGet]
        [Route("result-address")]
        public IActionResult ResultAddress(AddressViewModel addressView)
        {
            return View(addressView);
        }


        [HttpGet("search-zip-code")]
        public IActionResult SearchZipCode()
        {
            var uFs = _addressService.UFStateList();
            List<SelectListItem> items = new List<SelectListItem>();
            uFs.ForEach(uf => items.Add(new SelectListItem { Text = uf.Item2, Value = uf.Item1 }));
            ViewBag.Ufs = items.OrderBy(i => i.Text);

            return View();
        }


        [HttpPost("search-zip-code")]
        public IActionResult SearchZipCode([FromForm] AddressViewModel addressView)
        {
            ModelState.Remove("ZipCode");

            if (ModelState.IsValid)
            {
                var result = _addressQueries.GetZipCodeByAddress(addressView);
                if (result is not null) ViewBag.ZipCode = result.ZipCode;
                return RedirectToAction(nameof(ResultZipCode), result);
            }

            var uFs = _addressService.UFStateList();
            List<SelectListItem> items = new List<SelectListItem>();
            uFs.ForEach(uf => items.Add(new SelectListItem { Text = uf.Item2, Value = uf.Item1 }));
            ViewBag.Ufs = items.OrderBy(i => i.Text);

            return View();
        }

        [HttpGet]
        [Route("result-zip-code")]
        public IActionResult ResultZipCode(AddressViewModel addressView)
        {
            return View(addressView);
        }
    }
}
