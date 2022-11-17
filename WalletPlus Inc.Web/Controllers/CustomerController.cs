using Microsoft.AspNetCore.Mvc;
using WalletPlus_Inc.Web.Data.Entities;
using WalletPlus_Inc.Web.Data.Repositories.Interfaces;

namespace WalletPlus_Inc.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _customerRepository.Get("");
            return View(customers);
        }

        public IActionResult Create()
        {
            var model = new Customer { DateOfBirth = DateTime.Now};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.Add(model);

                return RedirectToAction("Index", "Customer");
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await _customerRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Customer model)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.Update(model);

                return RedirectToAction("Index", "Customer");
            }

            return View(model);
        }

        //[HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _customerRepository.Delete(id);

            return RedirectToAction("Index", "Customer");
        }
    }
}
